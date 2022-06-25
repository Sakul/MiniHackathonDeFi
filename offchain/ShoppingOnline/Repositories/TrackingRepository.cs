using ShoppingOnline.Shared;

namespace ShoppingOnline.Repositories
{
    public static class TrackingRepository
    {
        private static Dictionary<string, BuyResult> pointTracks = new();
        private static Dictionary<string, BuyResult> buyTracks = new();

        public static void AddPointTracking(string trackingId, CommunicationBase data)
        {
            if (pointTracks.ContainsKey(trackingId))
            {
                return;
            }

            var tempResult = new BuyResult(data.Nounce, data.WalletAddress)
            {
                CreatedDate = DateTime.Now,
            };
            pointTracks.Add(trackingId, tempResult);
        }

        public static void AddBuyTracking(string trackingId, CommunicationBase data)
        {
            if (buyTracks.ContainsKey(trackingId))
            {
                return;
            }

            var tempResult = new BuyResult(data.Nounce, data.WalletAddress)
            {
                CreatedDate = DateTime.Now,
            };
            buyTracks.Add(trackingId, tempResult);
        }

        public static void UpdateTrack(string trackingId, BuyResult data)
        {
            if (false == buyTracks.ContainsKey(trackingId))
            {
                return;
            }

            var result = buyTracks[trackingId];
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
