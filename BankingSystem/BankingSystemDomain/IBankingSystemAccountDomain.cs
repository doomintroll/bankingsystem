using BankingSystemDomain.Models;

namespace BankingSystemDomain
{
    public interface IBankingSystemAccountDomain
    {
        public List<Account> GetAllAccounts(uint userId);
        public Account GetAccount(uint userId, uint accountId);
        public Account CreateAccount(uint userId, Account account);
        public void DeleteAccount(uint userId, uint accountId);
        public Account DepositToAccount(uint userId, uint accountId, int amount);
        public Account WithdrawFromAccount(uint userId, uint accountId, int amount);
    }
}
