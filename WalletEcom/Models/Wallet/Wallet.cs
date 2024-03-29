﻿namespace WalletEcom.Models.Wallet
{
    public class Wallet
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        public DateTime UpdatedAt { get; set; }
        public int AccountId { get; set; }
        public Account.Account? Account { get; set; }

        public Wallet(int accountId)
        {
            UpdatedAt = DateTime.Now;
            AccountId = accountId;
        }
    }
}