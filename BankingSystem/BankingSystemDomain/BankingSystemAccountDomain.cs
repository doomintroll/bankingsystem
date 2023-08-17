using BankingSystemDomain.MockDb;
using BankingSystemDomain.Models;
using FluentValidation;

namespace BankingSystemDomain
{
    public class BankingSystemAccountDomain : IBankingSystemAccountDomain
    {
        private readonly IBankingSystemDbContext _dbContext;
        public BankingSystemAccountDomain(IBankingSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Account CreateAccount(uint userId, Account newAccount)
        {
            var user = _dbContext.GetUsers().Where(u => u.Id == userId).FirstOrDefault();
            if (user == null) {
                throw new ArgumentOutOfRangeException($"User with id {userId} could not be found.");
            }

            var account = new Account { Id = newAccount.Id, Balance = newAccount.Balance };
            user.Accounts.Add(account);

            return account;
        }

        public void DeleteAccount(uint userId, uint accountId)
        {
            var user = _dbContext.GetUsers().Where(u => u.Id == userId).FirstOrDefault();
            if (user == null)
            {
                throw new ArgumentOutOfRangeException($"User with id {userId} could not be found.");
            }
            user.Accounts.RemoveAll(a => a.Id == accountId);
        }

        public Account GetAccount(uint userId, uint accountId)
        {
            var user = _dbContext.GetUsers().Where(u => u.Id == userId).FirstOrDefault();
            if (user == null)
            {
                throw new ArgumentOutOfRangeException($"User with id {userId} could not be found.");
            }

            var account = user.Accounts.Where(a => a.Id == accountId).FirstOrDefault();
            if (account == null)
            {
                throw new ArgumentOutOfRangeException($"Account with account id {accountId} could not be found.");
            }

            return account;
        }

        public List<Account> GetAllAccounts(uint userId)
        {
            var user = _dbContext.GetUsers().Where(u => u.Id == userId).FirstOrDefault();
            if (user == null)
            {
                throw new ArgumentOutOfRangeException($"User with id {userId} could not be found.");
            }

            return user.Accounts;
        }

        public Account DepositToAccount(uint userId, uint accountId, int amount)
        {
            if (amount > 10000)
            {
                throw new InvalidOperationException("Cannot deposit more than $10000.");
            }

            var user = _dbContext.GetUsers().Where(u => u.Id == userId).FirstOrDefault();
            if (user == null)
            {
                throw new ArgumentOutOfRangeException($"User with id {userId} could not be found.");
            }

            var account = user.Accounts.Where(a => a.Id == accountId).FirstOrDefault();
            if (account == null)
            {
                throw new ArgumentOutOfRangeException($"Account with account id {accountId} could not be found.");
            }

            account.Balance = account.Balance + amount;

            return account;
        }

        public Account WithdrawFromAccount(uint userId, uint accountId, int amount)
        {
            var user = _dbContext.GetUsers().Where(u => u.Id == userId).FirstOrDefault();
            if (user == null)
            {
                throw new ArgumentOutOfRangeException($"User with id {userId} could not be found.");
            }

            var account = user.Accounts.Where(a => a.Id == accountId).FirstOrDefault();
            if (account == null)
            {
                throw new ArgumentOutOfRangeException($"Account with account id {accountId} could not be found.");
            }

            if (amount / (double)account.Balance > 0.9)
            {
                throw new InvalidOperationException("Cannot withdraw more than 90% of the total balance.");
            }

            if (account.Balance - amount < 100)
            {
                throw new InvalidOperationException("Total balance cannot be under $100.");
            }

            account.Balance = account.Balance - amount;

            return account;
        }
    }
}
