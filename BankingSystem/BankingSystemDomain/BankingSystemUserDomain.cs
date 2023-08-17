using BankingSystemDomain.MockDb;
using BankingSystemDomain.Models;

namespace BankingSystemDomain
{
    public class BankingSystemUserDomain : IBankingSystemUserDomain
    {
        private IBankingSystemDbContext _dbContext;

        public BankingSystemUserDomain(IBankingSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAllUsers()
        {
            var users = _dbContext.GetUsers();
            return users;
        }

        public User GetUser(uint id)
        {
            var user = _dbContext.GetUsers().Where(u => u.Id == id).FirstOrDefault();

            if (user == null)
            {
                throw new ArgumentOutOfRangeException($"User with id {id} could not be found.");
            }

            return user;
        }
    }
}
