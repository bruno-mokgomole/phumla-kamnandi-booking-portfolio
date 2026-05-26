using booking.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using booking.Business;

namespace booking.Presentation
{
    public partial class BookingForm : Form
    {
        private const int MaxGuestsPerRoom = 4;
        private List<Room> availableRooms = new List<Room>();
        private decimal currentTotalCost;
        private decimal currentDeposit;
        private Booking bookingToModify;

        public BookingForm()
        {
            InitializeComponent();
            pictureBox2.SendToBack();
            pictureBox1.SendToBack();
            NavigationHelper.ApplyReadableControls(this);
            NavigationHelper.AddHomeButton(this);
            dateTimePickerCheckIn.MinDate = DateTime.Today;
            dateTimePickerCheckOut.MinDate = DateTime.Today.AddDays(1);
            dateTimePickerCheckOut.Value = DateTime.Today.AddDays(1);
            numericUpDownRooms.Minimum = 1;
            numericUpDownRooms.Value = 1;
            numericUpDownRooms.Maximum = 20;
            numericUpDownAdults.Minimum = 1;
            numericUpDownAdults.Value = 1;
            numericUpDownAdults.Maximum = 80;
            numericUpDownChildren.Maximum = 80;
            rdbNewGuest.Checked = true;
        }

        public BookingForm(Booking booking) : this()
        {
            bookingToModify = booking;
            Text = "Modify Booking";
            btnReservation.Visible = false;
            rdbExisting.Visible = false;
            rdbNewGuest.Visible = false;
            grpBoxPersonalInfo.Visible = false;
            btnSubmit.Visible = true;
            btnSubmit.Text = "Save Changes";

            if (booking.CheckInDate.HasValue && booking.CheckInDate.Value < dateTimePickerCheckIn.MinDate)
                dateTimePickerCheckIn.MinDate = booking.CheckInDate.Value;

            if (booking.CheckOutDate.HasValue && booking.CheckOutDate.Value < dateTimePickerCheckOut.MinDate)
                dateTimePickerCheckOut.MinDate = booking.CheckOutDate.Value;

            if (booking.CheckInDate.HasValue)
                dateTimePickerCheckIn.Value = booking.CheckInDate.Value;

            if (booking.CheckOutDate.HasValue)
                dateTimePickerCheckOut.Value = booking.CheckOutDate.Value;

            numericUpDownRooms.Value = 1;
            numericUpDownAdults.Value = Math.Max(1, Math.Min(numericUpDownAdults.Maximum, booking.Guests));
            numericUpDownChildren.Value = 0;
            availableRooms = new List<Room> { new Room(booking.RoomId, 0m, Math.Max(booking.Guests, 1)) };
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void rdbExisting_CheckedChanged(object sender, EventArgs e)
        {
            bool existing = rdbExisting.Checked;
            txtAddress.ReadOnly = existing;
            txtDOB.ReadOnly = existing;
            txtEmail.ReadOnly = existing;
            txtName.ReadOnly = existing;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (bookingToModify != null)
                {
                    SaveBookingChanges();
                    return;
                }

                if (availableRooms.Count < (int)numericUpDownRooms.Value)
                    throw new Exception("Please search availability before confirming the reservation.");

                Guest guest;
                string id = txtID.Text.Trim();

                if (rdbExisting.Checked)
                {
                    if (string.IsNullOrWhiteSpace(id))
                        throw new Exception("Please enter the existing guest ID.");

                    GuestController guestController = new GuestController();
                    guest = guestController.GetGuestById(id);

                    if (guest == null)
                        throw new Exception("Existing guest was not found.");
                }
                else
                {
                    string name = txtName.Text.Trim();
                    string dobText = txtDOB.Text.Trim();
                    string email = txtEmail.Text.Trim();
                    string address = txtAddress.Text.Trim();

                    if (string.IsNullOrWhiteSpace(name))
                        throw new Exception("Full name is required.");

                    if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
                        throw new Exception("Full name can only contain letters and spaces.");

                    if (string.IsNullOrWhiteSpace(dobText))
                        throw new Exception("Date of Birth is required.");

                    if (!DateTime.TryParse(dobText, out DateTime dob))
                        throw new Exception("Date of Birth must be a valid date.");

                    if (dob >= DateTime.Today)
                        throw new Exception("Date of Birth must be in the past.");

                    int age = DateTime.Today.Year - dob.Year;
                    if (dob > DateTime.Today.AddYears(-age)) age--;
                    if (age < 18)
                        throw new Exception("Guest must be at least 18 years old.");

                    if (string.IsNullOrWhiteSpace(email))
                        throw new Exception("Email is required.");

                    if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                        throw new Exception("Invalid email format.");

                    if (string.IsNullOrWhiteSpace(address))
                        throw new Exception("Address is required.");

                    GuestController guestController = new GuestController();
                    guest = guestController.AddGuestAndReturn(name, email, address, id, dob);
                }

                // If all validations pass
                DialogResult result = MessageBox.Show("Please proceed to enter banking details", "Success", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    Payment form = new Payment(
                        guest,
                        dateTimePickerCheckIn.Value.Date,
                        dateTimePickerCheckOut.Value.Date,
                        (int)numericUpDownAdults.Value + (int)numericUpDownChildren.Value,
                        availableRooms.Take((int)numericUpDownRooms.Value).Select(room => room.RoomId).ToList(),
                        currentDeposit);
                    form.Show();
                    this.Hide();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("ID must be a number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearchAvailability_Click(object sender, EventArgs e)
        {
            DateTime checkInDate = dateTimePickerCheckIn.Value.Date;
            DateTime checkOutDate = dateTimePickerCheckOut.Value.Date;

            // Validate dates
            if (checkInDate >= checkOutDate)
            {
                MessageBox.Show("Check-out date must be after check-in date.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                availableRooms.Clear();
                return;
            }

            int numberOfRooms = (int)numericUpDownRooms.Value;
            int adults = (int)numericUpDownAdults.Value;
            int children = (int)numericUpDownChildren.Value; // Can be 0
            int totalGuests = adults + children;

            // Validate room and adult input
            if (numberOfRooms <= 0)
            {
                MessageBox.Show("You must book at least one room.", "Invalid Room Count", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                availableRooms.Clear();
                return;
            }

            if (adults <= 0)
            {
                MessageBox.Show("At least one adult is required per booking.", "Invalid Guest Count", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                availableRooms.Clear();
                return;
            }

            if (totalGuests > numberOfRooms * MaxGuestsPerRoom)
            {
                MessageBox.Show("No more than 4 people may stay in one room. Please add more rooms or reduce the number of guests.", "Invalid Guest Count", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                availableRooms.Clear();
                return;
            }

            RoomRepository roomRepo = new RoomRepository();
            SeasonRepository seasonRepo = new SeasonRepository();

            // Find rooms that match guest count and are not booked for these dates.
            availableRooms = roomRepo.GetAvailableRooms(checkInDate, checkOutDate, 1).ToList();

            if (availableRooms.Count >= numberOfRooms && availableRooms.Take(numberOfRooms).Sum(room => room.MaxGuests) >= totalGuests)
            {
                currentTotalCost = seasonRepo.CalculateStayCost(checkInDate, checkOutDate) * numberOfRooms;
                currentDeposit = seasonRepo.CalculateDeposit(currentTotalCost);

                string message = $"Rooms are available!\n\n" +
                                 $"Check-In: {checkInDate:dd MMM yyyy}\n" +
                                 $"Check-Out: {checkOutDate:dd MMM yyyy}\n" +
                                 $"Guests: {totalGuests} (Adults: {numericUpDownAdults.Value}, Children: {numericUpDownChildren.Value})\n" +
                                 $"Rooms: {numericUpDownRooms.Value}\n" +
                                 $"Stay Duration: {(checkOutDate - checkInDate).Days} night(s)\n" +
                                 $"Total Price: R{currentTotalCost:F2}\n" +
                                 $"Deposit (10%): R{currentDeposit:F2}";

                MessageBox.Show(message, "Availability Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Not enough rooms are available for your selected dates and guest count.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Please adjust your check-in/check-out dates or reduce number of rooms.", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please proceed to enter guest details.", "Reservation", MessageBoxButtons.OK);
            rdbExisting.Visible = true;
            rdbNewGuest.Visible = true;
            grpBoxPersonalInfo.Visible = true;
            btnSubmit.Visible = true;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveBookingChanges()
        {
            DateTime checkInDate = dateTimePickerCheckIn.Value.Date;
            DateTime checkOutDate = dateTimePickerCheckOut.Value.Date;

            if (checkInDate >= checkOutDate)
                throw new Exception("Check-out date must be after check-in date.");

            int guests = (int)numericUpDownAdults.Value + (int)numericUpDownChildren.Value;
            if (guests <= 0)
                throw new Exception("At least one guest is required.");

            if (guests > MaxGuestsPerRoom)
                throw new Exception("No more than 4 people may stay in one room.");

            BookingController controller = new BookingController();
            string result = controller.ChangeBooking(
                bookingToModify.Booking_Reference,
                checkInDate,
                checkOutDate,
                guests,
                bookingToModify.SpecialRequests);

            MessageBox.Show(result, "Modify Booking", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (!result.StartsWith("Booking updated", StringComparison.OrdinalIgnoreCase))
                return;

            Search form = new Search(SearchMode.Modify);
            form.Show();
            Hide();
        }
    }
}
