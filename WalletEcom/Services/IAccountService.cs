using WalletEcom.Models.Account;

namespace WalletEcom.Services
{
    public interface IAccountService
    {
        Task<List<Account>> GetAccounts();

    }
}