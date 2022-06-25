using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Services;
using ShoppingOnline.Shared;
using track = ShoppingOnline.Repositories.TrackingRepository;

namespace ShoppingOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IPointService pointService;

        public ShoppingController(IPointService pointService)
        {
            this.pointService = pointService;
        }

        [HttpPost]
        public async Task<TrackingResponse> Buy([FromBody] BuyRequest request)
        {
            var trackingId = Guid.NewGuid().ToString();
            track.AddBuyTracking(trackingId, request);
            var productPrice = 1;
            await pointService.Buy(request.ProductId, request.WalletAddress, productPrice);
            track.UpdateBalance(request.WalletAddress, -productPrice);
            return new TrackingResponse(request)
            {
                TrackingId = trackingId,
            };
        }
    }
}
