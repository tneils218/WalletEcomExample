using Microsoft.EntityFrameworkCore;
using WalletEcom.Controllers.Request;
using WalletEcom.DB;
using WalletEcom.Models.Wallet;
using WalletEcom.Services.DTOs;

namespace WalletEcom.Services.Impls
{
    public class WalletService : IWalletService
    {
        private readonly IDbContextFactory<AppDbContext> dbContextContextFactory;
        private readonly ILogger<WalletService> _logger;

        public WalletService(IDbContextFactory<AppDbContext> dbContextFactory, ILogger<WalletService> logger)
        {
            dbContextContextFactory = dbContextFactory;
            _logger = logger;
        }
        public async Task<Wallet> CreateWallet(WalletDTO walletDTO)
        {
            using (var dbContext = dbContextContextFactory.CreateDbContext())
            {

                var wallet = new Wallet(walletDTO.AccountId);

                dbContext.WalletDb.Add(wallet);
                await dbContext.SaveChangesAsync();
                return wallet;
            }
        }

        public async Task<List<Wallet>> GetAllWallet(string id)
        {
            using (var dbContext = dbContextContextFactory.CreateDbContext())
            {
                IQueryable<Wallet> query = dbContext.WalletDb.Include(o => o.Account); ;
                if (!string.IsNullOrEmpty(id))
                {
                    query = query.Where(o => o.AccountId == int.Parse(id));
                }

                var wallets = await query.ToListAsync();
                return wallets;
            }
        }
        public async Task<string> TransferWallet(int id, int walletId, WalletTransferRequest transferRequest)
        {
            using (var dbContext = dbContextContextFactory.CreateDbContext())
            {
                if (walletId == transferRequest.receiverWalletId && id == transferRequest.receiverId)
                {
                    throw new InvalidOperationException("Không thể chuyển cùng ví");
                }

                using var transaction = await dbContext.Database.BeginTransactionAsync();

                var sender = await dbContext.WalletDb.Include(o => o.Account)
                    .FirstOrDefaultAsync(o => o.AccountId == id && o.Id == walletId);

                var receiver = await dbContext.WalletDb.Include(o => o.Account)
                    .FirstOrDefaultAsync(o => o.AccountId == transferRequest.receiverId && o.Id == transferRequest.receiverWalletId);

                if (sender == null || receiver == null)
                {
                    throw new ArgumentException("Invalid sender or receiver wallet ID.");
                }

                var transferFee = await dbContext.ActionFeeDb
                    .FirstOrDefaultAsync(o => o.AccountTypeId == sender.Account.AccountTypeId && o.ActionTypeId == transferRequest.actionTypeId);

                if (transferFee == null)
                {
                    throw new InvalidOperationException("Transfer fee not available for the given account type.");
                }

                if (sender.Amount < transferRequest.amount)
                {
                    throw new InvalidOperationException("Insufficient balance in the sender's wallet.");
                }



                try
                {
                    sender.Amount -= transferRequest.amount + transferFee.Fee;
                    receiver.Amount += transferRequest.amount;

                    var walletTransferHistory = WalletHistory.CreateForSender(sender.Id, receiver.Id, transferFee.Fee, sender.Account.AccountTypeId, transferRequest.actionTypeId, transferRequest.amount);

                    dbContext.WalletHistoryDb.Add(walletTransferHistory);

                    await dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return "Chuyển khoản thành công";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(ex.Message, ex);
                    throw;
                }
            }
        }



        public async Task<Wallet> UpdateWallet(int id, int walletId, decimal amount, int actionTypeId)
        {
            using (var dbContext = dbContextContextFactory.CreateDbContext())
            {
                try
                {
                    var wallet = await dbContext.WalletDb.FirstOrDefaultAsync(o => o.AccountId == id && o.Id == walletId);

                    if (wallet != null)
                    {
                        switch (actionTypeId)
                        {
                            case 1:
                                wallet.Amount += amount;
                                break;
                            default:
                                wallet.Amount -= amount;
                                break;
                        }

                        await dbContext.SaveChangesAsync();

                        return wallet;
                    }
                    else
                    {
                        throw new Exception("Wallet not found."); // Custom exception for not found case
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating wallet.", ex); // Custom exception for other errors
                }
            }
        }
    }
}
