using WalletEcom.Models.Wallet;
using WalletEcom.Services.DTOs;

namespace WalletEcom.Services
{
    public interface IWalletService
    {
        Task<Wallet> CreateWallet(WalletDTO walletDto);
        Task<string> TransferWallet(int sourceId, int walletId, decimal amount, int destinationId, int destinationWalletId, int actionTypeId);

        Task<List<Wallet>> GetAllWallet(string id);

        Task<Wallet> UpdateWallet(int walletId, decimal amount, int actionTypeId);

    }
}
