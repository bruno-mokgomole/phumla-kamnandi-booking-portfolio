using System;

namespace booking.Business
{
    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }
    public class Booking
    {
        public string Booking_Reference { get; set; }
        public string GuestId { get; set; }
        public string RoomId { get; set; }
        public int? AccountId { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int Guests { get; set; }
        public string SpecialRequests { get; set; }
        public decimal Deposit { get; set; }
        public BookingStatus Status { get; set; }

        public Booking() { }

        public Booking(string reservationId, string guestId, string roomId,
            DateTime inDate, DateTime outDate, int guests, string specialReq, decimal deposit, BookingStatus status = BookingStatus.Pending)
        {
            Booking_Reference = reservationId;
            GuestId = guestId;
            RoomId = roomId;
            CheckInDate = inDate;
            CheckOutDate = outDate;
            Guests = guests;
            SpecialRequests = specialReq;
            Deposit = deposit;
            Status = status;
        }
    }
}