using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using WalletEcom.Controllers.Request;
using WalletEcom.Services;
using WalletEcom.Services.DTOs;
using WalletEcom.Services.DTOs.WalletEcom.Services.DTOs;

namespace WalletEcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var accounts = await _accountService.GetAccounts();
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateAccount(AccountRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            try
            {
                var accountDto = AccountDTO.Create(request.UserName, request.FullName, request.Email, request.DOB, request.AccountTypeId);
                var product = await _accountService.CreateAccount(accountDto);
                return CreatedAtAction(nameof(CreateAccount), new {}, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }
    }
}
