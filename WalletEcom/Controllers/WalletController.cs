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
        private readonly IWalletQueueService _walletQueueService;

        public WalletController(IWalletService walletService, IWalletQueueService walletQueueService)
        {
            _walletService = walletService;
            _walletQueueService = walletQueueService;

        }
        [HttpGet]
        public async Task<IActionResult> getAllWallet([FromQuery] string? id = "")
        {
            var wallelts = await _walletService.GetAllWallet(id ?? "");
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
        public async Task<IActionResult> TransferWallet(int id, int walletId, WalletTransferRequest request)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            try
            {
                await _walletQueueService.Queue(WalletQueueDataDTO.Create(
                            request.actionTypeId, walletId, request.amount, id, request.receiverId, request.receiverWalletId));
                return Ok();

                //switch (request.actionTypeId)
                //{
                //    case 1:
                //    case 4:

                //        await _walletQueueService.Queue(WalletQueueDataDTO.CreateForAddMoney(request.actionTypeId, walletId, request.amount));
                //        return Ok("Nạp tiền thành công");
                //    case 2:

                //        await _walletQueueService.Queue(WalletQueueDataDTO.CreateForTransfer(
                //            request.actionTypeId, walletId, request.amount, id, request.receiverId, request.receiverWalletId));

                //        return Ok("Chuyển tiền thành công");

                //    //case 3:
                //    //    var receiveResult = await _walletService.ReceiveMoney(id, walletId, request.receiverId, request.receiverWalletId, request.amount);
                //    //    return Ok(receiveResult);

                //    default:
                //        return BadRequest("Invalid actionTypeId.");
                //}
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
