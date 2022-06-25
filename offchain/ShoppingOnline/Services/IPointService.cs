using Nethereum.RPC.Eth.DTOs;

namespace ShoppingOnline.Services
{
    public interface IPointService
    {
        Task<TransactionReceipt> Buy(string productId, string fromAccount, int amount);
    }
}
