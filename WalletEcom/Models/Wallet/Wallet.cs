namespace WalletEcom.Models.Wallet
{
    public class Wallet
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Account.Account Account { get; set; } = null!;
    }
}