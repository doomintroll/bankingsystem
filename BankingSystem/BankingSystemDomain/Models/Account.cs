using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace BankingSystemDomain.Models {
    public class Account {
        [Required]
        public uint Id { get; set; }
        public int Balance { get; set; }

        public Account() { }
        public Account(uint id, int balance)
        {
            Id = id;
            Balance = balance;
        }
    }

    public class AccountValidator : AbstractValidator<Account> {
        public AccountValidator()
        {
            RuleFor(a => a.Balance).GreaterThanOrEqualTo(100);
        }
    }
}
