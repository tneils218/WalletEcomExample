using Microsoft.AspNetCore.Mvc;
using WalletEcom.Controllers.Request;
using WalletEcom.Services;
using WalletEcom.Services.DTOs;

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
        [HttpGet]
        public async Task<IActionResult> getAllWallet([FromQuery] string? id = "")
        {
            var wallelts = await _walletService.GetAllWallet(id);
            return Ok(wallelts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWallet(WalletRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            try
            {
                var walletDto = WalletDTO.Create(request.AccountId);
                var wallets = await _walletService.CreateWallet(walletDto);
                return CreatedAtAction(nameof(CreateWallet), new { }, wallets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }
        [HttpPost]
        [Route("tranfer")]
        public async Task<IActionResult> TransferWallet(WalletTransferRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            try
            {

                var wallets = await _walletService.TransferWallet(request);
                return Ok(wallets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAmount(string id, [FromBody] WalletAmountRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            try
            {

                var wallets = await _walletService.UpdateWallet(id, request.amount);
                return Ok(wallets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }
    }
}
