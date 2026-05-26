using System;
using System.Linq;
using System.Collections.Generic;
using booking.Data;
using System.Windows.Forms; 

namespace booking.Business
{
    public class BookingController
    {
        private BookingRepositoryDA bookingRepo;
        private RoomRepository roomRepo;
        private SeasonRepository seasonRepo;
        private AccountController accountController;

        public BookingController()
        {
            bookingRepo = new BookingRepositoryDA();
            roomRepo = new RoomRepository();
            seasonRepo = new SeasonRepository();
            accountController = new AccountController();
        }

        // Returns a status string for UI feedback
        public string CreateReservation(Guest guest, string roomId, DateTime checkIn, DateTime checkOut, int guests, string specialReq = "", int bankAccountNumber = 123456)
        {
            if (guest == null)
                return "Guest not found.";

            if (string.IsNullOrWhiteSpace(roomId))
            {
                var rooms = roomRepo.GetAvailableRooms(checkIn, checkOut, guests);
                if (rooms.Count == 0)
                    return "No rooms are available for the selected dates.";

                roomId = rooms[0].RoomId;
            }

            decimal totalCost = seasonRepo.CalculateStayCost(checkIn, checkOut);
            decimal deposit = seasonRepo.CalculateDeposit(totalCost);

            var random = new Random();
            string reservationId = random.Next(1000000, 9999999).ToString();
            var booking = new Booking(reservationId, guest.GuestId, roomId, checkIn, checkOut, guests, specialReq, deposit, BookingStatus.Pending);
            bookingRepo.AddBooking(booking);
            bookingRepo.UpdateDataSource();

            var account = accountController.CreateAccount(guest, bankAccountNumber);
            accountController.AddCharge(account.AccountID, totalCost);
            bool depositPaid = accountController.ProcessPayment(account.AccountID, deposit);

            booking.AccountId = account.AccountID;
            if (depositPaid)
            {
                booking.Status = BookingStatus.Confirmed;
                bookingRepo.UpdateBookingStatus(reservationId, BookingStatus.Confirmed);
            }

            bookingRepo.UpdateDataSource();

            return $"Booking {reservationId} created for {guest.FullName}.\nDeposit: {deposit:C}, Total: {totalCost:C}";
        }

        public string CreateReservations(Guest guest, List<string> roomIds, DateTime checkIn, DateTime checkOut, int guests, string specialReq = "", int bankAccountNumber = 123456)
        {
            if (guest == null)
                return "Guest not found.";

            roomIds = roomIds?
                .Where(roomId => !string.IsNullOrWhiteSpace(roomId))
                .Distinct()
                .ToList();

            if (roomIds == null || roomIds.Count == 0)
                return "No rooms selected for this reservation.";

            roomIds = roomIds
                .Where(roomId => roomRepo.AllRooms.Any(room => room.RoomId == roomId))
                .ToList();

            if (roomIds.Count == 0)
                return "None of the selected rooms exist.";

            int totalCapacity = roomRepo.AllRooms
                .Where(room => roomIds.Contains(room.RoomId))
                .Sum(room => room.MaxGuests);

            if (guests > totalCapacity)
                return "The selected rooms do not have enough capacity for all guests.";

            decimal stayCost = seasonRepo.CalculateStayCost(checkIn, checkOut);
            decimal totalCost = stayCost * roomIds.Count;
            decimal totalDeposit = seasonRepo.CalculateDeposit(totalCost);
            decimal depositPerRoom = totalDeposit / roomIds.Count;

            var account = accountController.CreateAccount(guest, bankAccountNumber);
            accountController.AddCharge(account.AccountID, totalCost);
            bool depositPaid = accountController.ProcessPayment(account.AccountID, totalDeposit);

            var random = new Random();
            var reservationIds = new List<string>();
            int remainingGuests = guests;

            foreach (string roomId in roomIds)
            {
                int roomCapacity = roomRepo.AllRooms.First(room => room.RoomId == roomId).MaxGuests;
                int roomGuests = Math.Min(roomCapacity, remainingGuests);
                remainingGuests -= roomGuests;

                string reservationId = random.Next(1000000, 9999999).ToString();
                while (bookingRepo.GetBookingById(reservationId) != null)
                    reservationId = random.Next(1000000, 9999999).ToString();

                var booking = new Booking(reservationId, guest.GuestId, roomId, checkIn, checkOut, roomGuests, specialReq, depositPerRoom, BookingStatus.Pending)
                {
                    AccountId = account.AccountID
                };

                bookingRepo.AddBooking(booking);
                if (depositPaid)
                {
                    booking.Status = BookingStatus.Confirmed;
                    bookingRepo.UpdateBookingStatus(reservationId, BookingStatus.Confirmed);
                }

                reservationIds.Add(reservationId);
            }

            return $"Booking(s) {string.Join(", ", reservationIds)} created for {guest.FullName}.\nDeposit: {totalDeposit:C}, Total: {totalCost:C}";
        }

        public string ChangeBooking(string reservationId, DateTime newCheckIn, DateTime newCheckOut, int newGuests, string newSpecialRequests)
        {
            var booking = bookingRepo.GetBookingById(reservationId);
            if (booking == null)
                return "Booking not found.";

            var availableRooms = roomRepo.GetAvailableRooms(newCheckIn, newCheckOut, newGuests, reservationId);
            if (!availableRooms.Any(r => r.RoomId == booking.RoomId))
                return "Room not available for the new dates.";

            booking.CheckInDate = newCheckIn;
            booking.CheckOutDate = newCheckOut;
            booking.Guests = newGuests;
            booking.SpecialRequests = newSpecialRequests;

            decimal totalCost = seasonRepo.CalculateStayCost(newCheckIn, newCheckOut);
            booking.Deposit = seasonRepo.CalculateDeposit(totalCost);

            booking.Status = BookingStatus.Pending;
            bookingRepo.UpdateBooking(booking);

            return "Booking updated successfully.";
        }

        public string CancelBooking(string reservationId)
        {
            var booking = bookingRepo.GetBookingById(reservationId);
            if (booking == null)
                return "Booking not found.";

            booking.Status = BookingStatus.Cancelled;
            bookingRepo.UpdateBookingStatus(reservationId, BookingStatus.Cancelled);
            bookingRepo.UpdateDataSource();

            roomRepo.UpdateAvailability(booking.RoomId, true);

            return "Booking cancelled and occupancy updated.";
        }

        public Booking GetBookingById(string reservationId)
        {
            return bookingRepo.GetBookingById(reservationId);
        }

        public List<Booking> GetBookingsByGuestId(string guestId)
        {
            if (string.IsNullOrWhiteSpace(guestId))
                return bookingRepo.AllBookings.ToList();

            return bookingRepo.AllBookings.Where(b => b.GuestId == guestId).ToList();
        }

        public bool IsBookingConfirmed(string reservationId)
        {
            var booking = bookingRepo.GetBookingById(reservationId);
            if (booking == null) return false;

            return booking.Status == BookingStatus.Confirmed;
        }
    }
}
