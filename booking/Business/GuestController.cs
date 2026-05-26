using booking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking.Business
{
    public class GuestController
    {
        private GuestRepository guestRepo;

        public GuestController()
        {
            guestRepo = new GuestRepository();
        }

        // Adds a new guest to the system
        public string AddGuest(string fullName, string email, string address, string phoneNumber, DateTime? dob = null)
        {
            Guest guest = AddGuestAndReturn(fullName, email, address, phoneNumber, dob);
            return $"Guest {guest.FullName} has been added successfully.";
        }

        public Guest AddGuestAndReturn(string fullName, string email, string address, string phoneNumber, DateTime? dob = null)
        {
            var guest = new Guest
            {
                FullName = fullName,
                Email = email,
                Address = address,
                PhoneNumber = phoneNumber,
                DateOfBirth = dob
            };

            guestRepo.AddGuest(guest);
            return guest;
        }

        // Updates guest information (e.g., address, phone number, email)
        public string UpdateGuest(string guestId, string fullName = null, string email = null, string address = null, string phoneNumber = null, DateTime? dob = null)
        {
            Guest guest = null;
            foreach (var g in guestRepo.AllGuests)
            {
                if (g.GuestId == guestId)
                {
                    guest = g;
                    break;
                }
            }

            if (guest == null)
                return "Guest not found.";

            guest.FullName = fullName ?? guest.FullName;
            guest.Email = email ?? guest.Email;
            guest.Address = address ?? guest.Address;
            guest.PhoneNumber = phoneNumber ?? guest.PhoneNumber;
            guest.DateOfBirth = dob ?? guest.DateOfBirth;

            guestRepo.UpdateDataSource();

            return $"Guest {guest.FullName} information updated successfully.";
        }

        // Gets a guest by their ID
        public Guest GetGuestById(string guestId)
        {
            foreach (var guest in guestRepo.AllGuests)
            {
                if (guest.GuestId == guestId)
                    return guest;
            }
            return null; // Not found
        }

        // Retrieves a list of all guests
        public List<Guest> GetAllGuests()
        {
            return guestRepo.AllGuests.ToList();
        }

        // Deletes a guest from the system
        public string DeleteGuest(string guestId)
        {
            Guest guest = null;
            foreach (var g in guestRepo.AllGuests)
            {
                if (g.GuestId == guestId)
                {
                    guest = g;
                    break;
                }
            }

            if (guest == null)
                return "Guest not found.";

            guestRepo.AllGuests.Remove(guest);
            guestRepo.UpdateDataSource();

            return $"Guest {guest.FullName} has been deleted.";
        }

        // Gets the total number of guests in the system
        public int GetsTotalGuests()
        {
            return guestRepo.AllGuests.Count;
        }
    }
}

