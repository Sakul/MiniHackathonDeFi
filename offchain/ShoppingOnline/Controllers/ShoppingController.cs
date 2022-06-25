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

        // HACK: TEMPORARY PRODUCTS
        private static IEnumerable<KeyValuePair<string, int>> products = new List<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>("P01", 10),
            new KeyValuePair<string, int>("P02", 3),
            new KeyValuePair<string, int>("P03", 5),
        };

        public ShoppingController(IPointService pointService)
        {
            this.pointService = pointService;
        }

        [HttpPost]
        public async Task<ActionResult<TrackingResponse>> Buy([FromBody] BuyRequest request)
        {
            if (products.Any(it => it.Key == request.ProductId))
            {
                return BadRequest("Product not found");
            }
            var selectedProduct = products.FirstOrDefault(it => it.Key == request.ProductId);
            var productPrice = selectedProduct.Value;

            var trackingId = Guid.NewGuid().ToString();
            track.AddBuyTracking(trackingId, request);
            await pointService.Buy(request.ProductId, request.WalletAddress, productPrice);
            track.UpdateBalance(request.WalletAddress, -productPrice);
            return new TrackingResponse(request)
            {
                TrackingId = trackingId,
            };
        }
    }
}
