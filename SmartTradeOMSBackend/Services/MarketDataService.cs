using Grpc.Core;
using SmartTradeOMSBackend.Protos;

namespace SmartTradeOMSBackend.Services
{
    public class MarketDataService: MarketDataProtoService.MarketDataProtoServiceBase
    {
        public override async Task SubscribeMarketData(MarketDataRequest request, IServerStreamWriter<MarketDataResponse> responseStream, ServerCallContext context)
        {
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += async (sender, e) => {
                var marketData = new MarketDataResponse
                {
                    Symbol = request.Symbol,
                    Price = new Random().NextDouble() * 100,
                    Timestamp = DateTime.UtcNow.ToString("O")
                };
                await responseStream.WriteAsync(marketData);
            };

            timer.Start();
            await Task.Delay(-1, context.CancellationToken);
            timer.Stop();
        }

    }
}
