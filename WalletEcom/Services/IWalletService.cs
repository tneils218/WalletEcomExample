using WalletEcom.Models.Wallet;
using WalletEcom.Services.DTOs;

namespace WalletEcom.Services
{
    public interface IWalletService
    {
        Task<Wallet> CreateWallet(WalletDTO walletDto);
    }
}
