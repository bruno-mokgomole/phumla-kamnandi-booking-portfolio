using booking.Business;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace booking.Presentation
{
    public class BookingsList : Form
    {
        private readonly ListBox lstBookings;
        private readonly Button btnRefresh;
        private readonly Button btnReturn;

        public BookingsList()
        {
            Text = "All Bookings";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(760, 430);
            BackColor = Color.Black;

            Label heading = new Label
            {
                Text = "All Bookings",
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold),
                Location = new Point(20, 18),
                Size = new Size(250, 28)
            };

            lstBookings = new ListBox
            {
                Location = new Point(20, 58),
                Size = new Size(720, 310),
                Font = new Font("Consolas", 9F),
                HorizontalScrollbar = true
            };

            btnRefresh = new Button
            {
                Text = "Refresh",
                Location = new Point(20, 383),
                Size = new Size(120, 30)
            };
            btnRefresh.Click += (sender, args) => LoadBookings();

            btnReturn = new Button
            {
                Text = "Return to Home Screen",
                Location = new Point(555, 383),
                Size = new Size(185, 30)
            };
            btnReturn.Click += (sender, args) =>
            {
                ManageBooking home = new ManageBooking();
                home.Show();
                Hide();
            };

            Controls.Add(heading);
            Controls.Add(lstBookings);
            Controls.Add(btnRefresh);
            Controls.Add(btnReturn);
            NavigationHelper.ApplyReadableControls(this);

            LoadBookings();
        }

        private void LoadBookings()
        {
            lstBookings.Items.Clear();

            List<Booking> bookings = new BookingController()
                .GetBookingsByGuestId(null)
                .OrderBy(b => b.CheckInDate)
                .ThenBy(b => b.Booking_Reference)
                .ToList();

            if (bookings.Count == 0)
            {
                lstBookings.Items.Add("No bookings found.");
                return;
            }

            lstBookings.Items.Add("Reference  Status      Guest  Room  Check-in     Check-out    Guests  Deposit");
            lstBookings.Items.Add(new string('-', 86));

            foreach (Booking booking in bookings)
            {
                string checkIn = booking.CheckInDate.HasValue ? booking.CheckInDate.Value.ToString("yyyy-MM-dd") : "N/A";
                string checkOut = booking.CheckOutDate.HasValue ? booking.CheckOutDate.Value.ToString("yyyy-MM-dd") : "N/A";

                lstBookings.Items.Add(
                    $"{booking.Booking_Reference,-10} {booking.Status,-11} {booking.GuestId,-6} {booking.RoomId,-5} {checkIn,-12} {checkOut,-12} {booking.Guests,-7} {booking.Deposit:C}");
            }
        }
    }
}
