using WalletEcom.Controllers.Request;
using WalletEcom.Models.Wallet;
using WalletEcom.Services.DTOs;

namespace WalletEcom.Services
{
    public interface IWalletService
    {
        Task<Wallet> CreateWallet(WalletDTO walletDto);
        Task<string> TransferWallet(int id, int walletId, WalletTransferRequest tranferRequest);

        Task<List<Wallet>> GetAllWallet(string id);

        Task<Wallet> UpdateWallet(int id, int walletId, decimal amount, int actionTypeId);


    }
}
