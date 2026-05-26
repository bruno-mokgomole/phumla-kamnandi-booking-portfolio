using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using booking.Business;

namespace booking.Data
{
    public class RoomRepository : DB
    {
        private string table = "Rooms";
        private string sqlLocal = "SELECT * FROM Rooms";
        private Collection<Room> rooms;

        public Collection<Room> AllRooms => rooms;

        public RoomRepository() : base()
        {
            rooms = new Collection<Room>();
            FillDataSet(sqlLocal, table);
            Add2Collection();
        }

        private void Add2Collection()
        {
            foreach (DataRow row in dsMain.Tables[table].Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    var room = new Room
                    {
                        RoomId = Convert.ToString(row["RoomId"]),
                        MaxGuests = Convert.ToInt32(row["Capacity"]),
                        IsAvailable = true,
                        BasePrice = row["BasePrice"] == DBNull.Value ? 0m : Convert.ToDecimal(row["BasePrice"])
                    };
                    rooms.Add(room);
                }
            }
        }

        public Collection<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut, int guests, string excludeBookingId = null)
        {
            var availableRooms = new Collection<Room>();
            var bookingRepo = new BookingRepositoryDA();

            foreach (Room room in rooms)
            {
                bool hasOverlap = bookingRepo.AllBookings.Any(b =>
                    b.RoomId == room.RoomId &&
                    b.Booking_Reference != excludeBookingId &&
                    b.Status != BookingStatus.Cancelled &&
                    b.CheckInDate.HasValue &&
                    b.CheckOutDate.HasValue &&
                    checkIn < b.CheckOutDate.Value &&
                    checkOut > b.CheckInDate.Value);

                if (room.MaxGuests >= guests && !hasOverlap)
                {
                    availableRooms.Add(room);
                }
            }
            return availableRooms;
        }

        public void UpdateAvailability(string roomId, bool isAvailable)
        {
            foreach (Room room in rooms)
            {
                if (room.RoomId == roomId)
                {
                    room.IsAvailable = isAvailable;
                    break;
                }
            }

            // The database has no IsAvailable column. Availability is derived from
            // active bookings in GetAvailableRooms.
        }

        public bool UpdateDataSource()
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(daMain);
            return base.UpdateDataSource(sqlLocal, table, refreshData: false);
        }
    }
}
