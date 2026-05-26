using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using booking.Business;

namespace booking.Data
{
    public class AccountRepository : DB
    {
        private string table = "GuestAccounts";
        private string sqlLocal = "SELECT * FROM GuestAccounts";
        private Collection<GuestAccount> accounts;
        private GuestRepository guestRepo = new GuestRepository();

        public Collection<GuestAccount> AllAccounts => accounts;

        public AccountRepository() : base()
        {
            accounts = new Collection<GuestAccount>();
            FillDataSet(sqlLocal, table);
            Add2Collection();
        }

        private void Add2Collection()
        {
            foreach (DataRow row in dsMain.Tables[table].Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    string guestId = Convert.ToString(row["GuestID"]);
                    Guest guest = guestRepo.AllGuests.FirstOrDefault(g => g.GuestId == guestId);
                    var account = new GuestAccount
                    {
                        AccountID = Convert.ToInt32(row["AccountID"]),
                        Guest = guest ?? new Guest { GuestId = guestId },
                        BankAccountNumber = Convert.ToInt32(row["BankAccountNumber"]),
                        Balance = Convert.ToDecimal(row["Balance"])
                    };
                    accounts.Add(account);
                }
            }
        }

        public void AddAccount(GuestAccount account)
        {
            using (SqlCommand command = new SqlCommand(
                "INSERT INTO GuestAccounts (AccountID, GuestID, BankAccountNumber, Balance) VALUES (@AccountID, @GuestID, @BankAccountNumber, @Balance)",
                cnMain))
            {
                command.Parameters.AddWithValue("@AccountID", account.AccountID);
                command.Parameters.AddWithValue("@GuestID", account.Guest.GuestId);
                command.Parameters.AddWithValue("@BankAccountNumber", account.BankAccountNumber);
                command.Parameters.AddWithValue("@Balance", account.Balance);

                if (cnMain.State != ConnectionState.Open)
                    cnMain.Open();

                command.ExecuteNonQuery();
                cnMain.Close();
            }

            accounts.Add(account);
        }

        public void UpdateAccountBalance(int accountId, decimal newBalance)
        {
            foreach (DataRow row in dsMain.Tables[table].Rows)
            {
                if (Convert.ToInt32(row["AccountID"]) == accountId)
                {
                    row["Balance"] = newBalance;
                    break;
                }
            }

            using (SqlCommand command = new SqlCommand(
                "UPDATE GuestAccounts SET Balance = @Balance WHERE AccountID = @AccountID",
                cnMain))
            {
                command.Parameters.AddWithValue("@Balance", newBalance);
                command.Parameters.AddWithValue("@AccountID", accountId);

                if (cnMain.State != ConnectionState.Open)
                    cnMain.Open();

                command.ExecuteNonQuery();
                cnMain.Close();
            }
        }

        public GuestAccount GetAccountById(int accountId)
        {
            foreach (GuestAccount acc in accounts)
            {
                if (acc.AccountID == accountId)
                    return acc;
            }
            return null;
        }

        public int GetNextAccountId()
        {
            if (accounts.Count == 0) return 1000;
            return accounts.Max(a => a.AccountID) + 1;
        }

        public bool UpdateDataSource()
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(daMain);
            return base.UpdateDataSource(sqlLocal, table, refreshData: false);
        }
    }
}
