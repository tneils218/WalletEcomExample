using WalletEcom.DB;
using WalletEcom.Models.Account;
using WalletEcom.Models.Wallet;
using WalletEcom.Services.DTOs;
using WalletEcom.Services.DTOs.WalletEcom.Services.DTOs;

namespace WalletEcom.Services.Impls
{
    public class WalletService: IWalletService
    {
        private readonly AppDbContext _db;

        public WalletService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Wallet> CreateWallet(WalletDTO walletDTO)
        {
            var wallet = new Wallet(walletDTO.AccountId);

            _db.WalletDb.Add(wallet);
            await _db.SaveChangesAsync();
            return wallet;
        }


    }
}
