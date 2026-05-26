using System;
using System.Collections.Generic;
using booking.Data;

namespace booking.Business
{
    public class AccountController
    {
        private AccountRepository accountRepo;
        private List<GuestAccount> localCache;

        public AccountController()
        {
            accountRepo = new AccountRepository();
            localCache = new List<GuestAccount>(accountRepo.AllAccounts);
        }

        public GuestAccount CreateAccount(Guest guest, int bankAccountNumber)
        {
            int accountID = accountRepo.GetNextAccountId();
            var account = new GuestAccount(accountID, guest, bankAccountNumber);
            localCache.Add(account);
            accountRepo.AddAccount(account);
            accountRepo.UpdateDataSource();
            return account;
        }

        public GuestAccount GetAccountById(int accountID)
        {
            return accountRepo.GetAccountById(accountID);
        }

        public bool AddCharge(int accountID, decimal amount)
        {
            var account = accountRepo.GetAccountById(accountID);
            if (account != null)
            {
                account.AddCharge(amount);
                accountRepo.UpdateAccountBalance(accountID, account.Balance);
                accountRepo.UpdateDataSource();
                return true;
            }
            return false;
        }

        public bool ProcessPayment(int accountID, decimal amount)
        {
            var account = accountRepo.GetAccountById(accountID);
            if (account == null)
                return false;

            if (account.MakePayment(amount))
            {
                accountRepo.UpdateAccountBalance(accountID, account.Balance);
                accountRepo.UpdateDataSource();
                return true;
            }
            return false;
        }

        public bool ProcessCheckout(int accountID)
        {
            var account = accountRepo.GetAccountById(accountID);
            if (account == null)
                return false;

            bool closed = account.CloseAccount();
            accountRepo.UpdateDataSource();
            return closed;
        }
    }
}