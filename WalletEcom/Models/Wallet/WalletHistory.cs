using WalletEcom.Models.Account;
using WalletEcom.Models.Action;

namespace WalletEcom.Models.Wallet
{
    public class WalletHistory
    {
        public int Id { get; set; }
        public Wallet Wallet { get; set; } = null!;

        public decimal Amount { get; set; }

        public AccountType? AccountType { get; set; } = null!;

        public ActionType? ActionType { get; set; } = null!;

        public int AccountTypeId { get; set; }

        public int ActionTypeId { get; set; }

        public int? SourceWalletId { get; set; }
        public int? DestinationWalletId { get; set; }

        public decimal Fee { get; set; } = 0;

        public DateTime CreatedAt { get; set; }

        public WalletHistory() { }
        public WalletHistory(int senderWalletId, int receiverWalletId, decimal fee, int accountTypeId, int actionTypeId, decimal amount) {
            SourceWalletId = senderWalletId;
            DestinationWalletId = receiverWalletId;
            Fee = fee;
            AccountTypeId = accountTypeId;
            ActionTypeId = actionTypeId;
            Amount = amount;
            CreatedAt = DateTime.Now;
        }
    }
}