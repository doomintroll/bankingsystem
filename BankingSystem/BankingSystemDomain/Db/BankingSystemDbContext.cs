using BankingSystemDomain.Models;

namespace BankingSystemDomain.MockDb
{
    public class BankingSystemDbContext : IBankingSystemDbContext
    {

        private static List<User> Users { get; set; } = new List<User>() {
            new User
            {
                Id = 1,
                Name = "User 1 Name",
                Surname = "User 1 Surname",
                Accounts = new List<Account>() {
                    new Account {
                        Id = 1,
                        Balance = 220
                    },
                    new Account {
                        Id = 2,
                        Balance = 320
                    }
                }
            },
            new User
            {
                Id = 2,
                Name = "User 2 Name",
                Surname = "User 2 Surname",
                Accounts = new List<Account>() {
                    new Account {
                        Id = 3,
                        Balance = 120
                    }
                }
            }
        };

        public List<User> GetUsers()
        {
            return Users;
        }
    }
}
