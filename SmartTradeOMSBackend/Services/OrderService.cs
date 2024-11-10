using Grpc.Core;
using SmartTradeOMSBackend.Protos;

namespace SmartTradeOMSBackend.Services
{
    public class OrderService : OrderProtoService.OrderProtoServiceBase
    {
        private readonly FixService _fixService;

        public OrderService(FixService fixService)
        {
            _fixService = fixService;
        }

        public override Task<OrderResponse> PlaceOrder(OrderRequest request, ServerCallContext context)
        {
            _fixService.SendOrder(request.Symbol, request.Quantity, request.Price, request.OrderType);

            return Task.FromResult(new OrderResponse
            {
                Message = "অর্ডার সফলভাবে পাঠানো হয়েছে!"
            });
        }

    }
}
