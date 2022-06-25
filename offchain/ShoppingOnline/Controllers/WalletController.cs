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

        [HttpGet("{address}")]
        public async Task<GetPointResponse> GetPoint(string address)
        {
            address = address.ToLower();
            if (false == track.AccountBalance.ContainsKey(address))
            {
                return new GetPointResponse { Nounce = Guid.NewGuid().ToString() };
            }

            var trackingId = Guid.NewGuid().ToString();
            return new GetPointResponse
            {
                Nounce = Guid.NewGuid().ToString(),
                Points = track.AccountBalance[address],
                WalletAddress = address,
            };
        }

        [HttpPost]
        public async Task<TrackingResponse> AddPoint([FromBody] AddPointRequest request)
        {
            var trackingId = Guid.NewGuid().ToString();
            track.AddPointTracking(trackingId, request);
            await pointService.AddPoint(request.WalletAddress, request.Points);
            track.UpdateBalance(request.WalletAddress, request.Points);
            return new TrackingResponse(request)
            {
                TrackingId = trackingId,
            };
        }
    }
}
