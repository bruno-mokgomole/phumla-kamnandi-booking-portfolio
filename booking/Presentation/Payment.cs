using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using booking.Business;

namespace booking.Presentation
{
    public partial class Payment : Form
    {
        private readonly Guest guest;
        private readonly DateTime checkInDate;
        private readonly DateTime checkOutDate;
        private readonly int guests;
        private readonly List<string> roomIds;
        private readonly decimal deposit;

        public Payment()
        {
            InitializeComponent();
            pictureBox1.SendToBack();
            NavigationHelper.ApplyReadableControls(this);
            NavigationHelper.AddHomeButton(this);
        }

        public Payment(Guest guest, DateTime checkInDate, DateTime checkOutDate, int guests, List<string> roomIds, decimal deposit)
            : this()
        {
            this.guest = guest;
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
            this.guests = guests;
            this.roomIds = roomIds;
            this.deposit = deposit;
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            txtDeposit.Text = deposit.ToString("C");
        }

        private void lblReference_Click(object sender, EventArgs e)
        {

        }

        private void lblDeposit_Click(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                string accHolder = txtAccHolder.Text.Trim();
                string bank = txtBank.Text.Trim();
                string expires = txtExpires.Text.Trim();
                string accountNumber = txtAccNumber.Text.Trim();
                string cvvText = txtCVV.Text.Trim();

                // Validate string inputs
                if (string.IsNullOrWhiteSpace(accHolder))
                    throw new Exception("Account Holder name is required.");

                if (!Regex.IsMatch(accHolder, @"^[a-zA-Z\s'-]+$"))
                    throw new Exception("Account Holder name can only contain letters, spaces, apostrophes, or hyphens.");

                if (string.IsNullOrWhiteSpace(bank))
                    throw new Exception("Bank name is required.");

                if (!Regex.IsMatch(bank, @"^[a-zA-Z\s]+$"))
                    throw new Exception("Bank name can only contain letters and spaces.");

                if (string.IsNullOrWhiteSpace(expires) || !DateTime.TryParse(expires, out DateTime expiryDate))
                    throw new Exception("Expiration date is required and must be a valid date.");

                if (expiryDate.Date < DateTime.Today)
                    throw new Exception("The card has expired.");

                // Parse and validate Account Number
                if (!Regex.IsMatch(accountNumber, @"^\d{6,10}$") || !int.TryParse(accountNumber, out int accNumber))
                    throw new Exception("Account Number must be numeric and 6 to 10 digits.");

                // Parse and validate CVV
                if (!Regex.IsMatch(cvvText, @"^\d{3}$"))
                    throw new Exception("CVV must be a 3-digit number.");

                if (guest == null || roomIds == null || roomIds.Count == 0)
                    throw new Exception("Booking details are missing. Please return home and start the booking again.");

                BookingController bookingController = new BookingController();
                string result = bookingController.CreateReservations(guest, roomIds, checkInDate, checkOutDate, guests, "", accNumber);

                MessageBox.Show("Payment processed successfully!\n\n" + result, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Confirmation form = new Confirmation(
                    "Booking Confirmation\r\n\r\n" +
                    result +
                    "\r\n\r\nCheck-In: " + checkInDate.ToString("dd MMM yyyy") +
                    "\r\nCheck-Out: " + checkOutDate.ToString("dd MMM yyyy") +
                    "\r\nGuests: " + guests +
                    "\r\nRooms: " + string.Join(", ", roomIds) +
                    "\r\nDeposit Paid: " + deposit.ToString("C"));
                form.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    
}
