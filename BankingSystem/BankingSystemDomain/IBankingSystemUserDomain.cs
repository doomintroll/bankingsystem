using BankingSystemDomain.Models;

namespace BankingSystemDomain
{
    public interface IBankingSystemUserDomain
    {
        public List<User> GetAllUsers();
        public User GetUser(uint id);
    }
}
