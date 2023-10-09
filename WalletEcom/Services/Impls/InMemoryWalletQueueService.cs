using System.Threading.Channels;
using WalletEcom.Services.DTOs;

namespace WalletEcom.Services.Impls
{
    public class InMemoryWalletQueueService : IWalletQueueService
    {
        private readonly Channel<WalletQueueDataDTO> _queue;

        public InMemoryWalletQueueService(int size)
        {
            var options = new BoundedChannelOptions(size)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            _queue = Channel.CreateBounded<WalletQueueDataDTO>(options);
        }

        public async Task<WalletQueueDataDTO> Dequeue()
        {
            var data = await _queue.Reader.ReadAsync();
            return data;
        }

        public async Task Queue(WalletQueueDataDTO data)
        {
            await _queue.Writer.WriteAsync(data);
        }
    }
}
