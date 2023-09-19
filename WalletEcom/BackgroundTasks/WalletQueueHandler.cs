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
                await _walletService.UpdateWallet(data.WalletId, data.Amount, data.ActionId);
                await _walletService.TransferWallet(data.SourceId, data.WalletId, data.Amount, data.DestinationId, data.DestinationWalletID, data.ActionId);
            }

        }
    }
}
