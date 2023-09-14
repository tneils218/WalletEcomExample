using Microsoft.EntityFrameworkCore;
using WalletEcom.DB;
using WalletEcom.Models.Account;
using WalletEcom.Services.DTOs;

namespace WalletEcom.Services.Impls
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _db;

        public AccountService(AppDbContext db)
        {
            _db = db;
        }

        public Task<Account> CreateAccount(AccountDTO account)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Account>> GetAccounts()
        {
            var accounts = await _db.AccountDb.ToListAsync();
            return accounts;
        }
    }
}
