namespace ShoppingOnline.Shared
{
    public class BuyResult
    {
        public string Nounce { get; }
        public string BuyerWalletAddress { get; }

        public int Amount { get; set; }
        public string ProductId { get; set; }
        public string ReceiverWalletAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        public BuyResult(string nounce, string walletAddress)
        {
            Nounce = nounce;
            BuyerWalletAddress = walletAddress;
        }
    }
}
