using Microsoft.EntityFrameworkCore;
using WalletEcom.DB;
using WalletEcom.Models.Account;
using WalletEcom.Services.DTOs.WalletEcom.Services.DTOs;

namespace WalletEcom.Services.Impls
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _db;

        public AccountService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Account> CreateAccount(AccountDTO accountDTO)
        {
            var account = new Account(accountDTO.UserName, accountDTO.FullName, accountDTO.Email, accountDTO.DOB, accountDTO.AccountTypeId);

            _db.AccountDb.Add(account);
            await _db.SaveChangesAsync();
            return account;
        }



        public async Task<List<Account>> GetAccounts()
        {
            var accounts = await _db.AccountDb.Include(a => a.AccountType).ToListAsync();
            return accounts;
        }
    }
}
