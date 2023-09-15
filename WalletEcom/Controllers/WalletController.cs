using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletEcom.Controllers.Request;
using WalletEcom.Services;
using WalletEcom.Services.DTOs;
using WalletEcom.Services.DTOs.WalletEcom.Services.DTOs;
using WalletEcom.Services.Impls;

namespace WalletEcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;

        }
        [HttpPost]
        public async Task<IActionResult> CreateWallet(WalletRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            try
            {
                var walletDto = WalletDTO.Create(request.AccountId);
                var wallets = await _walletService.CreateWallet( walletDto);
                return CreatedAtAction(nameof(CreateWallet), new { }, wallets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }
    }
}
