using System;

namespace booking.Business
{
    public class GuestAccount
    {
        public int AccountID { get; set; }
        public decimal Balance { get; set; }
        public Guest Guest { get; set; }
        public int BankAccountNumber { get; set; }

        public GuestAccount() { }

        public GuestAccount(int accountID, Guest guest, int bankAccountNumber)
        {
            AccountID = accountID;
            Guest = guest;
            BankAccountNumber = bankAccountNumber;
            Balance = 0.0m;
        }

        public void AddCharge(decimal amount)
        {
            if (amount < 0) throw new ArgumentException("Charge amount cannot be negative.");
            Balance += amount;
        }

        public bool MakePayment(decimal amount)
        {
            if (amount <= 0)
            {
                // UI should handle error
                return false;
            }

            Balance -= amount;
            if (Balance < 0) Balance = 0;
            return true;
        }

        public bool CloseAccount()
        {
            return Balance == 0;
        }

        public override string ToString()
        {
            return $"AccountID: {AccountID}\nGuest: {Guest?.FullName}\nBank Acc: {BankAccountNumber}\nBalance: {Balance:C}";
        }
    }
}