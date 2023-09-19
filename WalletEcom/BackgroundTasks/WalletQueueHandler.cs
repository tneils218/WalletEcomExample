using System.Text.Json;
using WalletEcom.Services;

namespace WalletEcom.BackgroundTasks
{
    public class WalletQueueHandler : BackgroundService
    {
        private readonly IWalletQueueService _queueService;
        private readonly IWalletService _walletService;
        private readonly ILogger<WalletQueueHandler> _logger;

        public WalletQueueHandler(IWalletQueueService queueService, IWalletService walletService, ILogger<WalletQueueHandler> logger)
        {
            _queueService = queueService;
            _walletService = walletService;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var data = await _queueService.Dequeue();
                _logger.LogInformation(JsonSerializer.Serialize(data));
            }
        }
    }
}
