using BankingSystemDomain;
using BankingSystemDomain.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BankingSystemAPI.Controllers
{
    [ApiController]
    [Route("api/v1/users/{userId}/accounts")]
    public class AccountsController : ControllerBase {
        private readonly IBankingSystemAccountDomain _accounts;
        private readonly IValidator<Account> _validator;

        public AccountsController(IBankingSystemAccountDomain accounts, IValidator<Account> validator) {
            _accounts = accounts;
            _validator = validator;
        }

        [HttpGet]
        public ActionResult<List<Account>> GetAccount(uint userId) {
            try {
                return _accounts.GetAllAccounts(userId);
            }
            catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
            catch (Exception) {

                return Problem();
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(uint userId, uint id) {
            try {
                return _accounts.GetAccount(userId, id);
            }
            catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
            catch (Exception) {

                return Problem();
            }
        }
        [HttpPost]
        public async Task<ActionResult<Account>> CreateAccount(uint userId, Account account) {
            try {
                ValidationResult result = await _validator.ValidateAsync(account);

                if (result.IsValid) {
                    return _accounts.CreateAccount(userId, account);
                }
                else { 
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception) {
                return Problem();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteAccount(uint userId, uint id) {
            try {
                _accounts.DeleteAccount(userId, id);
                return Ok();
            }
            catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
            catch (Exception) {

                return Problem();
            }
        }
        [HttpPost]
        [Route("{id}/deposit")]
        public ActionResult<Account> DepositToAccount(uint userId, uint id, int amount) {
            try {
                return _accounts.DepositToAccount(userId, id, amount);
            }
            catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex) {
                return BadRequest(ex.Message);
            }
            catch (Exception) {

                return Problem();
            }
            
        }
        [HttpPost]
        [Route("{id}/withdraw")]
        public ActionResult<Account> WithdrawFromAccount(uint userId, uint id, int amount) {
            try {
                return _accounts.WithdrawFromAccount(userId, id, amount);
            }
            catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex) {
                return BadRequest(ex.Message);
            }
            catch (Exception) {

                return Problem();
            }
        }
    }
}
