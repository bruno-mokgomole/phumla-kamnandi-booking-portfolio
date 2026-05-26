using booking.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace booking.Data
{
    public class ReportController
    {
        private GuestController guestController;
        private BookingController bookingController;

        public ReportController()
        {
            guestController = new GuestController();
            bookingController = new BookingController();
        }

        // Generates a simple report with the total number of guests in the system
        public string GenerateGuestReport()
        {
            int totalGuests = guestController.GetsTotalGuests();
            return $"Total number of guests: {totalGuests}";
        }

        // Generates a report of all bookings for a particular guest
        public string GenerateBookingReport(string guestId)
        {
            var bookings = bookingController.GetBookingsByGuestId(guestId);
            if (bookings.Count == 0)
                return "No bookings found for this guest.";

            StringBuilder report = new StringBuilder();
            report.AppendLine($"Booking Report for Guest ID {guestId}:");
            foreach (var booking in bookings)
            {
                report.AppendLine($"Reservation ID: {booking.Booking_Reference}");
                report.AppendLine($"Room ID: {booking.RoomId}");
                report.AppendLine($"Check-in: {booking.CheckInDate?.ToShortDateString() ?? "N/A"}");
                report.AppendLine($"Check-out: {booking.CheckOutDate?.ToShortDateString() ?? "N/A"}");
                report.AppendLine($"Guests: {booking.Guests}");
                report.AppendLine($"Status: {booking.Status}");
                report.AppendLine($"Deposit: {booking.Deposit:C}");
                decimal totalCost = booking.Deposit * 2; // formula will change
                report.AppendLine($"Total Cost: {totalCost:C}");
                report.AppendLine("-------------------------------");
            }
            return report.ToString();
        }

        // Generates a report of all bookings that are confirmed
        public string GenerateConfirmedBookingsReport()
        {
            // Get all bookings (pass null to get all)
            var allBookings = bookingController.GetBookingsByGuestId(null);
            var confirmedBookings = allBookings.Where(b => b.Status == BookingStatus.Confirmed).ToList();

            if (confirmedBookings.Count == 0)
                return "No confirmed bookings found.";

            StringBuilder report = new StringBuilder();
            report.AppendLine("Confirmed Bookings Report:");
            foreach (var booking in confirmedBookings)
            {
                report.AppendLine($"Reservation ID: {booking.Booking_Reference}");
                report.AppendLine($"Guest ID: {booking.GuestId}");
                report.AppendLine($"Room ID: {booking.RoomId}");
                report.AppendLine($"Check-in: {booking.CheckInDate?.ToShortDateString() ?? "N/A"}");
                report.AppendLine($"Check-out: {booking.CheckOutDate?.ToShortDateString() ?? "N/A"}");
                report.AppendLine($"Guests: {booking.Guests}");
                decimal totalCost = booking.Deposit * 2; // formula will change
                report.AppendLine($"Total Cost: {totalCost:C}");
                report.AppendLine("-------------------------------");
            }

            return report.ToString();
        }

        // Generates a summary of guest and booking statistics (e.g., total guests, total bookings, confirmed bookings)
        public string GenerateSummaryReport()
        {
            int totalGuests = guestController.GetsTotalGuests();
            var allBookings = bookingController.GetBookingsByGuestId(null); // Get all bookings
            int totalBookings = allBookings.Count;
            int confirmedBookings = allBookings.Count(b => b.Status == BookingStatus.Confirmed);

            StringBuilder report = new StringBuilder();
            report.AppendLine("System Summary Report:");
            report.AppendLine($"Total number of guests: {totalGuests}");
            report.AppendLine($"Total number of bookings: {totalBookings}");
            report.AppendLine($"Total confirmed bookings: {confirmedBookings}");
            report.AppendLine($"Total unconfirmed bookings: {totalBookings - confirmedBookings}");

            return report.ToString();
        }
    }
}
