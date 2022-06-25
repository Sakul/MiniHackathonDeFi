using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Services;
using ShoppingOnline.Shared;
using track = ShoppingOnline.Repositories.TrackingRepository;

namespace ShoppingOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IPointService pointService;

        public WalletController(IPointService pointService)
        {
            this.pointService = pointService;
        }

        [HttpPost]
        public async Task<TrackingResponse> AddPoint([FromBody] AddPointRequest request)
        {
            var trackingId = Guid.NewGuid().ToString();
            track.AddPointTracking(trackingId, request);
            await pointService.AddPoint(request.WalletAddress, request.Points);
            return new TrackingResponse(request)
            {
                TrackingId = trackingId,
            };
        }
    }
}
