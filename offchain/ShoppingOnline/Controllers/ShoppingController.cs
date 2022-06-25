using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Shared;
using track = ShoppingOnline.Repositories.ShoppingRepository;

namespace ShoppingOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        [HttpPost]
        public BuyResponse Buy([FromBody] BuyRequest request)
        {
            var trackingId = Guid.NewGuid().ToString();
            track.SaveTrack(trackingId, request);
            return new BuyResponse
            {
                TrackingId = trackingId,
                Nounce = request.Nounce,
                WalletAddress = request.WalletAddress,
            };
        }
    }
}
