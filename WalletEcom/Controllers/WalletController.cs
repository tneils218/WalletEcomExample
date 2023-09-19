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
        [HttpPut("{id}")]
        [Route("tranfer")]
        public async Task<IActionResult> TransferWallet(int id, int walletId, WalletTransferRequest request)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            try
            {

                switch (request.actionTypeId)
                {
                    case 1:
                        var wallets = await _walletService.UpdateWallet(id, walletId, request.amount, request.actionTypeId);
                        return Ok(wallets);
                    case 2:

                        var transferResult = await _walletService.TransferWallet(id, walletId, request);
                        return Ok(transferResult);

                    //case 3:
                    //    var receiveResult = await _walletService.ReceiveMoney(id, walletId, request.receiverId, request.receiverWalletId, request.amount);
                    //    return Ok(receiveResult);
                    case 4:
                        var withdrawResult = await _walletService.UpdateWallet(id, walletId, request.amount, request.actionTypeId);
                        return Ok(withdrawResult);
                    default:
                        return BadRequest("Invalid actionTypeId.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
