﻿using Microsoft.EntityFrameworkCore;
using WalletEcom.Controllers.Request;
using WalletEcom.DB;
using WalletEcom.Models.Wallet;
using WalletEcom.Services.DTOs;

namespace WalletEcom.Services.Impls
{
    public class WalletService : IWalletService
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

        public async Task<List<Wallet>> GetAllWallet(string id)
        {
            IQueryable<Wallet> query = _db.WalletDb.Include(o => o.Account); ;
            if (!string.IsNullOrEmpty(id))
            {
                query = query.Where(o => o.AccountId == int.Parse(id));
            }

            var wallets = await query.ToListAsync();
            return wallets;
        }
        public async Task<string> TransferWallet(int id, int walletId, WalletTransferRequest transferRequest)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();

            var sender = await _db.WalletDb.Include(o => o.Account)
                .FirstOrDefaultAsync(o => o.AccountId == id && o.Id == walletId);

            var receiver = await _db.WalletDb.Include(o => o.Account)
                .FirstOrDefaultAsync(o => o.AccountId == transferRequest.receiverId && o.Id == transferRequest.receiverWalletId);

            if (sender == null || receiver == null)
            {
                throw new ArgumentException("Invalid sender or receiver wallet ID.");
            }

            var transferFee = await _db.ActionFeeDb
                .FirstOrDefaultAsync(o => o.AccountTypeId == sender.Account.AccountTypeId && o.ActionTypeId == 2);

            if (transferFee == null)
            {
                throw new InvalidOperationException("Transfer fee not available for the given account type.");
            }

            if (sender.Amount < transferRequest.amount)
            {
                throw new InvalidOperationException("Insufficient balance in the sender's wallet.");
            }

            if (walletId == transferRequest.receiverWalletId && id == transferRequest.receiverId)
            {
                throw new InvalidOperationException("Không thể chuyển cùng ví");
            }

            try
            {
                sender.Amount -= transferRequest.amount + transferFee.Fee;
                receiver.Amount += transferRequest.amount;

                var walletTransferHistory = WalletHistory.CreateForSender(sender.Id, receiver.Id, transferFee.Fee, sender.Account.AccountTypeId, transferRequest.actionTypeId, transferRequest.amount);

                _db.WalletHistoryDb.Add(walletTransferHistory);

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();

                return "Chuyển khoản thành công";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
                throw;
            }
        }



        public async Task<Wallet> UpdateWallet(int id, int walletId, decimal amount, int actionTypeId)
        {
            try
            {
                var wallet = await _db.WalletDb.FirstOrDefaultAsync(o => o.AccountId == id);

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

                    await _db.SaveChangesAsync();

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
