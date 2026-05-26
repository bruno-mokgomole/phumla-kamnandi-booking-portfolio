using System;

namespace booking.Business
{
    public class Guest
    {
        public string GuestId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public Guest() { }

        public Guest(string guestID, string fullName, string email, string address, string phoneNumber, DateTime? dob = null)
        {
            GuestId = guestID;
            FullName = fullName;
            Email = email;
            Address = address;
            DateOfBirth = dob;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"ID: {GuestId} | {FullName} ({Email})";
        }
    }
}