using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletEcom.Services;

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
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
         
        }
    }
}
