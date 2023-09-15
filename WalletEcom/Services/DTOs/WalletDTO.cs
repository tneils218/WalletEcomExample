using WalletEcom.Services.DTOs.WalletEcom.Services.DTOs;

namespace WalletEcom.Services.DTOs
{
    public class WalletDTO
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }

        private WalletDTO(int accountId)
        {
            AccountId = accountId;
        }
      
        public static WalletDTO Create(int accountId)
        {
            return new WalletDTO(accountId);
        }
    }
}
