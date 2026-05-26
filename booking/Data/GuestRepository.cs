using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using booking.Business;

namespace booking.Data
{
    public class GuestRepository : DB
    {
        private string table = "Guests";
        private string sqlLocal = "SELECT * FROM Guests";
        private Collection<Guest> guests;

        public Collection<Guest> AllGuests => guests;

        public GuestRepository() : base()
        {
            guests = new Collection<Guest>();
            FillDataSet(sqlLocal, table);
            Add2Collection();
        }

        private void Add2Collection()
        {
            foreach (DataRow row in dsMain.Tables[table].Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    var g = new Guest
                    {
                        GuestId = Convert.ToString(row["GuestId"]),
                        FullName = Convert.ToString(row["FullName"]),
                        Email = Convert.ToString(row["Email"]),
                        Address = Convert.ToString(row["Address_"]),
                        PhoneNumber = Convert.ToString(row["Phone"]),
                        DateOfBirth = row["DOB"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["DOB"])
                    };
                    guests.Add(g);
                }
            }
        }

        public void AddGuest(Guest g)
        {
            using (SqlCommand command = new SqlCommand(
                "DECLARE @GuestId INT = ISNULL((SELECT MAX(GuestId) FROM Guests), 0) + 1; INSERT INTO Guests (GuestId, FullName, Email, Address_, Phone, DOB) VALUES (@GuestId, @FullName, @Email, @Address, @Phone, @DOB); SELECT @GuestId;",
                cnMain))
            {
                command.Parameters.AddWithValue("@FullName", g.FullName);
                command.Parameters.AddWithValue("@Email", g.Email);
                command.Parameters.AddWithValue("@Address", g.Address);
                command.Parameters.AddWithValue("@Phone", string.IsNullOrWhiteSpace(g.PhoneNumber) ? (object)DBNull.Value : g.PhoneNumber);
                command.Parameters.AddWithValue("@DOB", g.DateOfBirth ?? DateTime.Today.AddYears(-18));

                if (cnMain.State != ConnectionState.Open)
                    cnMain.Open();

                object result = command.ExecuteScalar();
                cnMain.Close();
                g.GuestId = Convert.ToString(result);
            }

            guests.Add(g);
        }

        public bool UpdateDataSource()
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(daMain);
            return base.UpdateDataSource(sqlLocal, table, refreshData: false);
        }
    }
}
