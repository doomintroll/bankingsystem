using System.ComponentModel.DataAnnotations;

namespace BankingSystemDomain.Models
{
    public class User {
        [Required]
        public uint Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public List<Account> Accounts { get; set; }

        public User() {}
        public User(uint id, string name, string surname, List<Account> accounts) {
            Id = id;
            Name = name;
            Surname = surname;
            Accounts = accounts;
        }
    }
}