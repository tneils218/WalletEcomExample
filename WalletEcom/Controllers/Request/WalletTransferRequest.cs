using System.ComponentModel.DataAnnotations;

namespace WalletEcom.Controllers.Request
{
    public class WalletTransferRequest
    {


        public int receiverId { get; set; }


        public int receiverWalletId { get; set; }

        [Required]
        public int actionTypeId { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal amount { get; set; }
    }
}
