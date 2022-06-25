using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace ShoppingOnline.Services.Functions
{
    [Function("mint")]
    public class MintFunction : FunctionMessage
    {
        [Parameter("address", "to", 1, false)]
        public string To { get; set; }

        [Parameter("uint256", "amount", 2, false)]
        public int Amount { get; set; }
    }
}
