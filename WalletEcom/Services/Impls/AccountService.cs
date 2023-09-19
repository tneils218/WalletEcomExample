using Microsoft.EntityFrameworkCore;
using WalletEcom.DB;
using WalletEcom.Models.Account;
using WalletEcom.Services.DTOs.WalletEcom.Services.DTOs;

namespace WalletEcom.Services.Impls
{
    public class AccountService : IAccountService
    {
        private readonly IDbContextFactory<AppDbContext> dbContextContextFactory;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IDbContextFactory<AppDbContext> dbContextFactory, ILogger<AccountService> logger)
        {
            dbContextContextFactory = dbContextFactory;
            _logger = logger;
        }

        public async Task<Account> CreateAccount(AccountDTO accountDTO)
        {
            using (var dbContext = dbContextContextFactory.CreateDbContext())
            {
                var account = new Account(accountDTO.UserName, accountDTO.FullName, accountDTO.Email, accountDTO.DOB, accountDTO.AccountTypeId);

                dbContext.AccountDb.Add(account);
                await dbContext.SaveChangesAsync();
                return account;
            }
        }



        public async Task<List<Account>> GetAccounts()
        {
            using (var dbContext = dbContextContextFactory.CreateDbContext())
            {
                var accounts = await dbContext.AccountDb.Include(a => a.AccountType).ToListAsync();
                return accounts;
            }

        }
    }
}
