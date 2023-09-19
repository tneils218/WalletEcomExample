using WalletEcom.Services.DTOs.WalletEcom.Services.DTOs;

namespace WalletEcom.Services
{
    public interface IAccountQueueService
    {
        Task Queue(AccountDTO data);
        Task<AccountDTO> Dequeue();
    }
}
