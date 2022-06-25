using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using ShoppingOnline.Services.Functions;

namespace ShoppingOnline.Services
{
    public class T3PointService : IPointService
    {
        private const string nodeUrl = "http://127.0.0.1:7545";
        private Web3 web3;
        private string[] accounts;
        private string ownerAccount;

        public string SmartContractAddress { get; }

        public T3PointService(string smartContractAddress)
        {
            web3 = new Web3(nodeUrl);
            SmartContractAddress = smartContractAddress;
        }

        public async Task Initialize()
        {
            accounts = await web3.Eth.Accounts.SendRequestAsync();
            ownerAccount = accounts[0];
        }

        public async Task<TransactionReceipt> Buy(string productId, string fromAccount, int amount)
        {
            var callback = web3.Eth.GetContractTransactionHandler<BuyFunction>();
            var result = await callback.SendRequestAndWaitForReceiptAsync(SmartContractAddress,
                new BuyFunction
                {
                    FromAddress = fromAccount,
                    ProductId = productId,
                    Receiver = ownerAccount,
                    Amount = amount,
                });
            return result;
        }
    }
}
