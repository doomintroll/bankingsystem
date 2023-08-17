using BankingSystemDomain;
using BankingSystemDomain.MockDb;
using BankingSystemDomain.Models;

namespace BankingSystemDomainTest {
    [TestFixture]
    [Category("Banking System Account Domain Get Tests")]
    public class BakingSystemAccountDomainTests {
        public IBankingSystemAccountDomain _bankingSystemAccountDomain { get; set; }

        [SetUp]
        public void Setup() {
            var mockBankingSystemDbContext = new MockBankingSystemDbContext();
            _bankingSystemAccountDomain = new BankingSystemAccountDomain(mockBankingSystemDbContext);
        }

        [Test]
        public void GetAllAccounts_GetAllAccountsForUser() {
            var expectedNumberOfAccounts = 2;

            var actualNumberOfAccounts = _bankingSystemAccountDomain.GetAllAccounts(1).Count;

            Assert.That(actualNumberOfAccounts, Is.EqualTo(expectedNumberOfAccounts));
        }

        [Test]
        public void GetAccount_GetSpecificAccountForUser() {
            var expectedAccount = new Account {
                Id = 1,
                Balance = 220
            };

            var actualAccount = _bankingSystemAccountDomain.GetAccount(1, 1);

            Assert.That(expectedAccount.Id, Is.EqualTo(actualAccount.Id));
            Assert.That(expectedAccount.Balance, Is.EqualTo(actualAccount.Balance));
        }

        [Test]
        public void GetAccount_ArgumentOutOfRangeExceptionThrownForNonExistingUser() {
            Assert.Throws<ArgumentOutOfRangeException>(() => _bankingSystemAccountDomain.GetAccount(0, 1));
        }

        [Test]
        public void GetAccount_ArgumentOutOfRangeExceptionThrownForNonExistingAccount() {
            Assert.Throws<ArgumentOutOfRangeException>(() => _bankingSystemAccountDomain.GetAccount(1, 5));
        }
    }
}