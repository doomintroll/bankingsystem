using BankingSystemDomain;
using BankingSystemDomain.MockDb;
using BankingSystemDomain.Models;

namespace BankingSystemDomainTest {
    [TestFixture]
    [Category("Banking System Account Domain Update Tests")]
    public class BakingSystemAccountDomainUpdateTests {
        public IBankingSystemAccountDomain _bankingSystemAccountDomain { get; set; }

        [SetUp]
        public void Setup() {
            var mockBankingSystemDbContext = new MockBankingSystemDbContext();
            _bankingSystemAccountDomain = new BankingSystemAccountDomain(mockBankingSystemDbContext);
        }

        [Test]
        public void CreateAccount_CreateAccountForUser() {
            var expectedAccount = new Account {
                Id = 3,
                Balance = 260
            };

            var actualAccount = _bankingSystemAccountDomain.CreateAccount(1, new Account {
                Id = 3,
                Balance = 260
            });

            Assert.That(expectedAccount.Id, Is.EqualTo(actualAccount.Id));
            Assert.That(expectedAccount.Balance, Is.EqualTo(actualAccount.Balance));
        }

        [Test]
        public void DeleteAccount_DeleteSpecificAccountForUser() {
            _bankingSystemAccountDomain.DeleteAccount(2, 4);
            Assert.Throws<ArgumentOutOfRangeException>(() => _bankingSystemAccountDomain.GetAccount(2, 4));
        }

        [Test]
        public void DepositToAccount_DepositedToAccount() {
            var expectedAccount = new Account {
                Id = 5,
                Balance = 220
            };

            var actualAccount = _bankingSystemAccountDomain.DepositToAccount(2, 5, 100);

            Assert.That(expectedAccount.Id, Is.EqualTo(actualAccount.Id));
            Assert.That(expectedAccount.Balance, Is.EqualTo(actualAccount.Balance));
        }

        [Test]
        public void WithdrawFromAccount_WithdrawnFromAccount() {
            var expectedAccount = new Account {
                Id = 6,
                Balance = 200
            };

            var actualAccount = _bankingSystemAccountDomain.WithdrawFromAccount(2, 6, 20);

            Assert.That(expectedAccount.Id, Is.EqualTo(actualAccount.Id));
            Assert.That(expectedAccount.Balance, Is.EqualTo(actualAccount.Balance));
        }

        [Test]
        public void DepositToAccount_InvalidOperationForTooMoreThen10000Deposit() {
            Assert.Throws<InvalidOperationException>(() => _bankingSystemAccountDomain.DepositToAccount(2, 5, 10001));
        }

        [Test]
        public void WithdrawFromAccount_WithdrawnFromAccountToExactly100Balance() {
            var expectedAccount = new Account {
                Id = 3,
                Balance = 100
            };

            var actualAccount = _bankingSystemAccountDomain.WithdrawFromAccount(2, 3, 20);

            Assert.That(expectedAccount.Id, Is.EqualTo(actualAccount.Id));
            Assert.That(expectedAccount.Balance, Is.EqualTo(actualAccount.Balance));
        }

        [Test]
        public void WithdrawFromAccount_InvalidOperationForLessThen100BalanceLeft() {
            Assert.Throws<InvalidOperationException>(() => _bankingSystemAccountDomain.WithdrawFromAccount(2, 3, 21));
        }

        [Test]
        public void WithdrawFromAccount_InvalidOperationForMoreThen90PercentBalanceWithdraw() {
            Assert.Throws<InvalidOperationException>(() => _bankingSystemAccountDomain.WithdrawFromAccount(2, 7, 2800));
        }
    }
}