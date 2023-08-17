using BankingSystemDomain;
using BankingSystemDomain.MockDb;
using BankingSystemDomain.Models;

namespace BankingSystemDomainTest {
    [TestFixture]
    [Category("Banking System User Domain Get Tests")]
    public class BakingSystemUserDomainTests {
        public IBankingSystemUserDomain _bankingSystemUserDomain { get; set; }

        [SetUp]
        public void Setup() {
            var mockBankingSystemDbContext = new MockBankingSystemDbContext();
            _bankingSystemUserDomain = new BankingSystemUserDomain(mockBankingSystemDbContext);
        }

        [Test]
        public void GetAllUsers_GetAllUsers() {
            var expectedNumberOfUsers = 2;

            var actualNumberOfUsers = _bankingSystemUserDomain.GetAllUsers().Count;

            Assert.That(actualNumberOfUsers, Is.EqualTo(expectedNumberOfUsers));
        }

        [Test]
        public void GetUser_GetSpecificUser() {
            var expectedUser = new User {
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
            };

            var actualUser = _bankingSystemUserDomain.GetUser(1);

            Assert.That(expectedUser.Id, Is.EqualTo(actualUser.Id));
            Assert.That(expectedUser.Name, Is.EqualTo(actualUser.Name));
            Assert.That(expectedUser.Surname, Is.EqualTo(actualUser.Surname));
        }

        [Test]
        public void GetUser_GetAccountsOfSpecificUser() {
            var expectedUser = new User {
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
            };

            var actualUser = _bankingSystemUserDomain.GetUser(1);

            Assert.That(expectedUser.Accounts[0].Id, Is.EqualTo(actualUser.Accounts[0].Id));
            Assert.That(expectedUser.Accounts[0].Balance, Is.EqualTo(actualUser.Accounts[0].Balance));
            Assert.That(expectedUser.Accounts[1].Id, Is.EqualTo(actualUser.Accounts[1].Id));
            Assert.That(expectedUser.Accounts[1].Balance, Is.EqualTo(actualUser.Accounts[1].Balance));
        }

        [Test]
        public void GetUser_ArgumentOutOfRangeExceptionThrownForNonExistingUser() {
            var actualUser = _bankingSystemUserDomain.GetUser(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => _bankingSystemUserDomain.GetUser(3));
        }
    }
}