using System;

namespace booking.Business
{
    public class Room
    {
        public string RoomId { get; set; }
        public int MaxGuests { get; set; }
        public bool IsAvailable { get; set; }
        public decimal BasePrice { get; set; }

        public Room() { }

        public Room(string roomId, decimal basePrice, int maxGuests = 4)
        {
            RoomId = roomId;
            BasePrice = basePrice;
            MaxGuests = maxGuests;
            IsAvailable = true;
        }

        public override string ToString()
        {
            return $"Room {RoomId} (Max {MaxGuests}) - {(IsAvailable ? "Available" : "Unavailable")} - Base R{BasePrice:F2}";
        }
    }
}