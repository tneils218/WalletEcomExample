using WalletEcom.Models.Account;
using WalletEcom.Services.DTOs;
using WalletEcom.Services.DTOs.WalletEcom.Services.DTOs;

namespace WalletEcom.Services
{
    public interface IAccountService
    {
        Task<List<Account>> GetAccounts();
        Task<Account> CreateAccount(AccountDTO account);
    }
}