using ShoppingOnline.Shared;

namespace ShoppingOnline.Repositories
{
    public static class ShoppingRepository
    {
        private static Dictionary<string, BuyResult> tracking = new();

        public static void SaveTrack(string trackingId, CommunicationBase data)
        {
            if (tracking.ContainsKey(trackingId))
            {
                return;
            }

            var tempResult = new BuyResult(data.Nounce, data.WalletAddress)
            {
                CreatedDate = DateTime.Now,
            };
            tracking.Add(trackingId, tempResult);
        }

        public static void UpdateTrack(string trackingId, BuyResult data)
        {
            if (false == tracking.ContainsKey(trackingId))
            {
                return;
            }

            var result = tracking[trackingId];
            if (null == result || result.CompletedDate.HasValue)
            {
                return;
            }

            result.Amount = data.Amount;
            result.CompletedDate = DateTime.Now;
            result.ReceiverWalletAddress = data.ReceiverWalletAddress;
        }
    }
}
