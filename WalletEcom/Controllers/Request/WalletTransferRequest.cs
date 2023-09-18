using System.ComponentModel.DataAnnotations;

namespace WalletEcom.Controllers.Request
{
    public class WalletTransferRequest
    {
        [Required]
        public int senderId { get; set; }
        [Required]
        public int senderWalletId { get; set; }

        [Required]
        public int receiverId { get; set; }

        [Required]
        public int receiverWalletId { get; set; }

        [Range(1, double.MaxValue)]
        public decimal amount { get; set; }
    }
}
