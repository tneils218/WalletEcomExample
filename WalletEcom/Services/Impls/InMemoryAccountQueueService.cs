using System.Threading.Channels;
using WalletEcom.Services.DTOs.WalletEcom.Services.DTOs;

namespace WalletEcom.Services.Impls
{
    public class InMemoryAccountQueueService
    {
        private readonly Channel<AccountDTO> _queue;

        public InMemoryAccountQueueService(int size)
        {
            var options = new BoundedChannelOptions(size)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            _queue = Channel.CreateBounded<AccountDTO>(options);
        }

        public async Task<AccountDTO> Dequeue()
        {
            var data = await _queue.Reader.ReadAsync();
            return data;
        }

        public async Task Queue(AccountDTO data)
        {
            await _queue.Writer.WriteAsync(data);
        }
    }
}
