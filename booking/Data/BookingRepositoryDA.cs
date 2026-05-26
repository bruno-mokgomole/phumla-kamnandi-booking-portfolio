using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using booking.Business;

namespace booking.Data
{
    public class BookingRepositoryDA : DB
    {
        private string table = "Bookings";
        private string sqlLocal = "SELECT * FROM Bookings";
        private Collection<Booking> bookings;

        public Collection<Booking> AllBookings => bookings;

        public BookingRepositoryDA() : base()
        {
            bookings = new Collection<Booking>();
            FillDataSet(sqlLocal, table);
            Add2Collection();
        }

        private void Add2Collection()
        {
            foreach (DataRow row in dsMain.Tables[table].Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    BookingStatus status = BookingStatus.Pending;
                    var statusStr = row["Status"].ToString();
                    Enum.TryParse(statusStr, out status);

                    var booking = new Booking
                    {
                        Booking_Reference = Convert.ToString(row["BookingId"]),
                        GuestId = Convert.ToString(row["GuestId"]),
                        RoomId = Convert.ToString(row["RoomId"]),
                        CheckInDate = Convert.ToDateTime(row["CheckInDate"]),
                        CheckOutDate = Convert.ToDateTime(row["CheckOutDate"]),
                        Guests = row["Guests"] == DBNull.Value ? 1 : Convert.ToInt32(row["Guests"]),
                        Deposit = row["DepositAmount"] == DBNull.Value ? 0m : Convert.ToDecimal(row["DepositAmount"]),
                        SpecialRequests = Convert.ToString(row["SpecialRequests"]),
                        Status = status
                    };
                    bookings.Add(booking);
                }
            }
        }

        public void AddBooking(Booking b)
        {
            using (SqlCommand command = new SqlCommand(
                "INSERT INTO Bookings (BookingId, GuestId, RoomId, CheckInDate, CheckOutDate, Guests, DepositAmount, DepositPaid, SpecialRequests, Status) VALUES (@BookingId, @GuestId, @RoomId, @CheckInDate, @CheckOutDate, @Guests, @DepositAmount, @DepositPaid, @SpecialRequests, @Status)",
                cnMain))
            {
                command.Parameters.AddWithValue("@BookingId", b.Booking_Reference);
                command.Parameters.AddWithValue("@GuestId", b.GuestId);
                command.Parameters.AddWithValue("@RoomId", b.RoomId);
                command.Parameters.AddWithValue("@CheckInDate", b.CheckInDate);
                command.Parameters.AddWithValue("@CheckOutDate", b.CheckOutDate);
                command.Parameters.AddWithValue("@Guests", b.Guests.ToString());
                command.Parameters.AddWithValue("@DepositAmount", b.Deposit);
                command.Parameters.AddWithValue("@DepositPaid", b.Status == BookingStatus.Confirmed);
                command.Parameters.AddWithValue("@SpecialRequests", string.IsNullOrWhiteSpace(b.SpecialRequests) ? (object)DBNull.Value : b.SpecialRequests);
                command.Parameters.AddWithValue("@Status", b.Status.ToString());

                if (cnMain.State != ConnectionState.Open)
                    cnMain.Open();

                command.ExecuteNonQuery();
                cnMain.Close();
            }

            bookings.Add(b);
        }

        public void UpdateBookingStatus(string reservationId, BookingStatus status)
        {
            foreach (DataRow row in dsMain.Tables[table].Rows)
            {
                if (row["BookingId"].ToString() == reservationId)
                {
                    row["Status"] = status.ToString();
                    row["DepositPaid"] = status == BookingStatus.Confirmed;
                    break;
                }
            }

            var booking = GetBookingById(reservationId);
            if (booking != null)
                booking.Status = status;

            using (SqlCommand command = new SqlCommand(
                "UPDATE Bookings SET Status = @Status, DepositPaid = @DepositPaid WHERE BookingId = @BookingId",
                cnMain))
            {
                command.Parameters.AddWithValue("@Status", status.ToString());
                command.Parameters.AddWithValue("@DepositPaid", status == BookingStatus.Confirmed);
                command.Parameters.AddWithValue("@BookingId", reservationId);

                if (cnMain.State != ConnectionState.Open)
                    cnMain.Open();

                command.ExecuteNonQuery();
                cnMain.Close();
            }
        }

        public void UpdateBooking(Booking booking)
        {
            using (SqlCommand command = new SqlCommand(
                "UPDATE Bookings SET CheckInDate = @CheckInDate, CheckOutDate = @CheckOutDate, Guests = @Guests, DepositAmount = @DepositAmount, SpecialRequests = @SpecialRequests, Status = @Status, DepositPaid = @DepositPaid WHERE BookingId = @BookingId",
                cnMain))
            {
                command.Parameters.AddWithValue("@CheckInDate", booking.CheckInDate);
                command.Parameters.AddWithValue("@CheckOutDate", booking.CheckOutDate);
                command.Parameters.AddWithValue("@Guests", booking.Guests.ToString());
                command.Parameters.AddWithValue("@DepositAmount", booking.Deposit);
                command.Parameters.AddWithValue("@SpecialRequests", string.IsNullOrWhiteSpace(booking.SpecialRequests) ? (object)DBNull.Value : booking.SpecialRequests);
                command.Parameters.AddWithValue("@Status", booking.Status.ToString());
                command.Parameters.AddWithValue("@DepositPaid", booking.Status == BookingStatus.Confirmed);
                command.Parameters.AddWithValue("@BookingId", booking.Booking_Reference);

                if (cnMain.State != ConnectionState.Open)
                    cnMain.Open();

                command.ExecuteNonQuery();
                cnMain.Close();
            }
        }

        public Booking GetBookingById(string reservationId)
        {
            return bookings.FirstOrDefault(b => string.Equals(b.Booking_Reference, reservationId, StringComparison.OrdinalIgnoreCase));
        }

        public void RemoveBooking(string reservationId)
        {
            foreach (DataRow row in dsMain.Tables[table].Rows)
            {
                if (row["BookingId"].ToString() == reservationId)
                {
                    row.Delete();
                    break;
                }
            }
        }

        public bool UpdateDataSource()
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(daMain);
            return base.UpdateDataSource(sqlLocal, table, refreshData: false);
        }

    }
}
