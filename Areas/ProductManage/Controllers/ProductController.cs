using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Services;

namespace MyFirstApp.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        
        // /Areas/AreaName/Views/ControllerName/Action.cshtml
        public ActionResult Index()
        {
            var products = _productService.OrderBy(p => p.Name).ToList();
            return View(products);  // Areas/ProductManage/Views/Product/Index.cshtml
        }

    }
}
