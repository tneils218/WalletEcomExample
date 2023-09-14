using Microsoft.EntityFrameworkCore;
using WalletEcom.DB;
using WalletEcom.Models.Account;

namespace WalletEcom.Services.Impls
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _db;

        public AccountService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<Account>> GetAccounts()
        {
            var accounts = await _db.AccountDb.ToListAsync();
            return accounts;
        }
    }
}
