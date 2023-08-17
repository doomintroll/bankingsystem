using BankingSystemDomain.Models;

namespace BankingSystemDomain.MockDb
{
    public interface IBankingSystemDbContext
    {
        public List<User> GetUsers();
    }
}
