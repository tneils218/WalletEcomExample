﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WalletEcom.Controllers.Request;
using WalletEcom.DB;
using WalletEcom.Models.Account;
using WalletEcom.Models.Wallet;
using WalletEcom.Services.DTOs;
using WalletEcom.Services.DTOs.WalletEcom.Services.DTOs;
using ZstdSharp;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<string> TransferWallet(WalletTransferRequest transferRequest)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();

            var sender = await _db.WalletDb.Include(o => o.Account)
                .FirstOrDefaultAsync(o => o.AccountId == transferRequest.senderId && o.Id == transferRequest.senderWalletId);

            var actionType = 2;
            var receiver = await _db.WalletDb.Include(o => o.Account)
                .FirstOrDefaultAsync(o => o.AccountId == transferRequest.receiverId && o.Id == transferRequest.receiverWalletId);



            var transferFee = await _db.ActionFeeDb.FirstOrDefaultAsync(o => o.AccountTypeId == sender.Account.AccountTypeId && o.ActionTypeId == 2);



            if (sender == null || receiver == null)
            {
                throw new ArgumentException("Invalid sender or receiver wallet ID.");
            }

            
            if (sender.Amount < transferRequest.amount)
            {
                throw new InvalidOperationException("Insufficient balance in the sender's wallet.");
            }
            if (transferRequest.senderWalletId == transferRequest.receiverWalletId && transferRequest.senderId == transferRequest.receiverId )
            {
                throw new InvalidOperationException("Không thể chuyển cùng ví");
            }


            try
            {

                sender.Amount -= transferRequest.amount + transferFee.Fee;
                receiver.Amount += transferRequest.amount;
                //var walletHistory = new WalletHistory(sender.Id, receiver.Id, transferRequest.fee, transferRequest.accountTypeId, transferRequest.actionTypeId, transferRequest.amount);
                //_db.WalletHistoryDb.Add(walletHistory);
                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
            return "Chuyển khoản thành công";

            }
            catch (Exception)
            {

                await transaction.RollbackAsync();
                throw;
            }
        }


        public async Task<Wallet> UpdateWallet(string id, decimal newAmount)
        {
            try
            {
                if (!int.TryParse(id, out int walletId))
                {
                    throw new ArgumentException("Invalid wallet ID format.");
                }

                var wallet = await _db.WalletDb.FirstOrDefaultAsync(o => o.AccountId == walletId);

                if (wallet != null)
                {
                
                    wallet.Amount += newAmount;

            
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

        public Task<Wallet> WithdrawMoney(string id, decimal newMoney)
        {
            throw new NotImplementedException();
        }
    }
}
