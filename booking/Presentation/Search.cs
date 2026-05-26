using booking.Business;
using System;
using System.Text;
using System.Windows.Forms;

namespace booking.Presentation
{
    public enum SearchMode
    {
        Enquiry,
        Modify,
        Cancel
    }

    public partial class Search : Form
    {
        private readonly SearchMode mode;
        private Booking selectedBooking;

        public Search() : this(SearchMode.Enquiry)
        {
        }

        public Search(SearchMode mode)
        {
            InitializeComponent();
            pictureBox2.SendToBack();
            NavigationHelper.ApplyReadableControls(this);
            this.mode = mode;
            ConfigureForMode();
        }

        private void ConfigureForMode()
        {
            textBox1.ReadOnly = true;
            btnProceed.Visible = mode == SearchMode.Modify;
            btnFInalizeDelete.Visible = mode == SearchMode.Cancel;

            if (mode == SearchMode.Enquiry)
            {
                Text = "Booking Enquiry";
                btnProceed.Visible = false;
                btnFInalizeDelete.Visible = false;
            }
            else if (mode == SearchMode.Modify)
            {
                Text = "Modify Booking";
                btnProceed.Text = "Proceed to Modify";
            }
            else
            {
                Text = "Cancel Booking";
                btnFInalizeDelete.Text = "Cancel Booking";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (!LoadBooking())
                return;

            DialogResult result = MessageBox.Show(
                "Would you like to proceed to modify this booking?",
                "Modify Booking",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                BookingForm form = new BookingForm(selectedBooking);
                form.Show();
                Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadBooking();
        }

        private void btnFInalizeDelete_Click(object sender, EventArgs e)
        {
            if (!LoadBooking())
                return;

            if (selectedBooking.Status == BookingStatus.Cancelled)
            {
                MessageBox.Show("This booking has already been cancelled.", "Cancel Booking", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel this booking?",
                "Cancel Booking",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            BookingController controller = new BookingController();
            MessageBox.Show(controller.CancelBooking(selectedBooking.Booking_Reference), "Cancel Booking", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadBooking();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            ManageBooking form = new ManageBooking();
            form.Show();
            Hide();
        }

        private bool LoadBooking()
        {
            string reference = textBox2.Text.Trim();
            if (string.IsNullOrWhiteSpace(reference))
            {
                MessageBox.Show("Please enter a booking reference.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            BookingController controller = new BookingController();
            selectedBooking = controller.GetBookingById(reference);

            if (selectedBooking == null)
            {
                textBox1.Text = "";
                MessageBox.Show("Booking not found.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            textBox1.Text = FormatBooking(selectedBooking);
            return true;
        }

        private string FormatBooking(Booking booking)
        {
            StringBuilder details = new StringBuilder();
            details.AppendLine($"Booking Reference: {booking.Booking_Reference}");
            details.AppendLine($"Status: {booking.Status}");
            details.AppendLine($"Deposit Paid: {(booking.Status == BookingStatus.Confirmed ? "Yes" : "No")}");
            details.AppendLine($"Guest ID: {booking.GuestId}");
            details.AppendLine($"Room ID: {booking.RoomId}");
            details.AppendLine($"Check-In: {FormatDate(booking.CheckInDate)}");
            details.AppendLine($"Check-Out: {FormatDate(booking.CheckOutDate)}");
            details.AppendLine($"Guests: {booking.Guests}");
            details.AppendLine($"Deposit Amount: {booking.Deposit:C}");
            details.AppendLine($"Special Requests: {(string.IsNullOrWhiteSpace(booking.SpecialRequests) ? "None" : booking.SpecialRequests)}");
            return details.ToString();
        }

        private string FormatDate(DateTime? date)
        {
            return date.HasValue ? date.Value.ToString("dd MMM yyyy") : "N/A";
        }
    }
}
