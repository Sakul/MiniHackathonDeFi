namespace ShoppingOnline.Shared
{
    public class TrackingResponse : CommunicationBase
    {
        public string TrackingId { get; set; }

        public TrackingResponse(CommunicationBase origin)
        {
            Nounce = origin.Nounce;
            WalletAddress = origin.WalletAddress;
        }
    }
}
