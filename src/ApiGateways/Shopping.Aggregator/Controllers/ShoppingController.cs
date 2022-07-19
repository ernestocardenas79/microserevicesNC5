using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShoppingController: ControllerBase
    {
        private readonly ICatalogService catalog;
        private readonly IOrderService order;
        private readonly IBasketService basket;

        public ShoppingController(ICatalogService catalog, IOrderService order, IBasketService basket)
        {
            this.catalog = catalog;
            this.order = order;
            this.basket = basket;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<ShoppingModel>> GetShopping(string userName) {

            var basketResponse = await basket.GetBasket(userName);

            basketResponse.Items.ForEach(async(i) => {
                var product = await catalog.GetCatalog(i.ProductId);

                i.ProductName = product.ProductName;
                i.Category = product.Category;
                i.Summary = product.Summary;
                i.Description = product.Description;
                i.ImageFile = product.ImageFile;
            });

            var orders = await order.GetOrdersByUserName(userName);

            var result = new ShoppingModel() { 
               UserName = userName,
               BasketWithProdcuts=basketResponse,
               Orders=orders
            };

            return Ok(result);
        }
    }
}
