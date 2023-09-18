using WalletEcom.Controllers.Request;
using WalletEcom.Models.Wallet;
using WalletEcom.Services.DTOs;

namespace WalletEcom.Services
{
    public interface IWalletService
    {
        Task<Wallet> CreateWallet(WalletDTO walletDto);
        Task<string> TransferWallet(WalletTransferRequest tranferRequest);

        Task<List<Wallet>> GetAllWallet(string id);

        Task<Wallet> UpdateWallet(string id, decimal newWallet);

        Task<Wallet> WithdrawMoney(string id, decimal newMoney);
    }
}
