using QuickFix.Fields;

namespace SmartTradeOMSBackend.Services
{
    public class FixService
    {
        public void SendOrder(string symbol, double quantity, double price, string orderType)
        {
            var message = new QuickFix.FIX50.NewOrderSingle(
                new ClOrdID("ORDER1"), new Side(Side.BUY), new TransactTime(DateTime.Now), new OrdType(orderType == "LIMIT" ? OrdType.LIMIT : OrdType.MARKET)
            );

            message.Set(new Symbol(symbol));
            message.Set(new OrderQty((decimal)quantity));
            message.Set(new Price((decimal)price));

            // Session.SendToTarget(message, sessionID); // সঠিক সেশন ID যোগ করুন

            Console.WriteLine($"অর্ডার পাঠানো হয়েছে: {symbol}, {quantity}, {price}");
        }
    }
}
