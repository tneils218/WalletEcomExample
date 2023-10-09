using WalletEcom.Services.DTOs;

namespace WalletEcom.Services
{
    public interface IWalletQueueService
    {
        Task Queue(WalletQueueDataDTO data);
        Task<WalletQueueDataDTO> Dequeue();
    }
}
