using BankingSystemDomain;
using BankingSystemDomain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystemAPI.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase {

        private readonly IBankingSystemUserDomain _users;

        public UsersController(IBankingSystemUserDomain users) {
            _users = users;
        }

        [HttpGet(Name = "Get")]
        public ActionResult<IEnumerable<User>> Get() {
            try {
                return _users.GetAllUsers();
            }
            catch (Exception) {

                return Problem();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(uint id) {
            try {
                return _users.GetUser(id);
            }
            catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
            catch (Exception) {

                return Problem();
            }
        }
    }
}