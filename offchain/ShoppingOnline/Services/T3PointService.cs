﻿using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using ShoppingOnline.Services.Functions;
using track = ShoppingOnline.Repositories.TrackingRepository;

namespace ShoppingOnline.Services
{
    public class T3PointService : IPointService
    {
        private Web3 web3;
        private string[] accounts;
        private string ownerAccount;

        public string SmartContractAddress { get; }

        public T3PointService(string nodeEndpoint, string smartContractAddress)
        {
            web3 = new Web3(nodeEndpoint);
            SmartContractAddress = smartContractAddress;
        }

        public async Task Initialize()
        {
            accounts = await web3.Eth.Accounts.SendRequestAsync();
            track.Initialize(accounts);
            ownerAccount = accounts[0];
        }

        public async Task<TransactionReceipt> AddPoint(string toAccount, int amount)
        {
            var callback = web3.Eth.GetContractTransactionHandler<MintFunction>();
            var result = await callback.SendRequestAndWaitForReceiptAsync(SmartContractAddress,
                new MintFunction
                {
                    FromAddress = ownerAccount,
                    To = toAccount,
                    Amount = amount,
                });
            return result;
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
