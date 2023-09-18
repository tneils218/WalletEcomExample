using System.ComponentModel.DataAnnotations;

namespace WalletEcom.Controllers.Request
{
    public class WalletRequest

    {
        [Required]
        public int AccountId { get; set; }
    }
}
