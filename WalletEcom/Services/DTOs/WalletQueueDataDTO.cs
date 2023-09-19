namespace WalletEcom.Services.DTOs
{
    public class WalletQueueDataDTO
    {
        public int ActionId { get; set; }
        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public int DestinationId { get; set; }
        public int DestinationWalletID { get; set; }
        public int SourceId { get; set; }

        private WalletQueueDataDTO(int actionID, int walletId, decimal amount, int sourceId, int destinationId, int destinationWalletID)
        {
            ActionId = actionID;
            WalletId = walletId;
            Amount = amount;
            DestinationId = destinationId;
            SourceId = sourceId;
            DestinationWalletID = destinationWalletID;
        }

        private WalletQueueDataDTO(int actionID, int walletId, decimal amount)
            : this(actionID, walletId, amount, 0, 0, 0)
        {
        }

        public static WalletQueueDataDTO CreateForAddMoney(int actionID, int walletId, decimal amount)
        {
            return new WalletQueueDataDTO(actionID, walletId, amount);
        }

        public static WalletQueueDataDTO CreateForTransfer(int actionID, int walletId, decimal amount, int sourceId, int destinationId, int destinationWalletId)
        {
            return new WalletQueueDataDTO(actionID, walletId, amount, sourceId, destinationId, destinationWalletId);
        }
    }
}
