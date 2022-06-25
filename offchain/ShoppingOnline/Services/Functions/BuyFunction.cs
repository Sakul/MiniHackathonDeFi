using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace ShoppingOnline.Services.Functions
{
    [Function("buy")]
    public class BuyFunction : FunctionMessage
    {
        [Parameter("string", "productId", 1, false)]
        public string ProductId { get; set; }

        [Parameter("address", "receiver", 2, false)]
        public string Receiver { get; set; }

        [Parameter("uint256", "amount", 3, false)]
        public int Amount { get; set; }
    }
}
