using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstApp.Services;

namespace MyFirstApp
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public string Index() 
        {
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData

            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData
            _logger.LogInformation("Index Action");

            return "I am index of first";
        }

        public void Nothing()
        {
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("Hi", "Xin chao cac ban");
        }

        // ContentResult               | Content()
        // EmptyResult                 | new EmptyResult()
        // FileResult                  | File()
        // ForbidResult                | Forbid()
        // JsonResult                  | Json()
        // LocalRedirectResult         | LocalRedirect()
        // RedirectResult              | Redirect()
        // RedirectToActionResult      | RedirectToAction()
        // RedirectToPageResult        | RedirectToRoute()
        // RedirectToRouteResult       | RedirectToPage()
        // PartialViewResult           | PartialView()
        // ViewComponentResult         | ViewComponent()
        // StatusCodeResult            | StatusCode()
        // ViewResult                  | View()

        public IActionResult Readme()
        {
            var content = @"
            Hello cac ban,

            this is action readme
            ";

            return Content(content, "text/plain");
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Redirect to " + url);
            return LocalRedirect(url);
        }

        // ViewResult | View()
        public IActionResult HelloView(string username)
        {
            if (string.IsNullOrEmpty(username))
                username = "client";
            // View() => Razor Engine, doc .cshtml (template)
            // ----------------------------------------
            // View(template) - template duong dan tuyet doi toi .cshtml
            // view(template, model)
            // return View("/MyView/xinchao1.cshtml", username);

            // xinchao2.cshtml -> /View/First/xinchao2.cshtml
            // return View("xinchao2", username);

            // Helloview.cshtml -> /View/First/HelloView.cshtml
            // /View/Controller/Action.cshtml
            return View((object)username);
        }

        [TempData]
        public string StatusMessage {get; set;}
        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.FirstOrDefault(p => p.Id == id);
            if (product == null){
                // TempData["StatusMessage"] = "San pham ban yeu cau khong co";
                StatusMessage = "San pham ban yeu cau khong co";
                return Redirect(Url.Action("Index", "Home"));
            }
                

            // /View/First/ViewProduct.cshtml
            // /MyView/First/ViewProduct.cshtml

            // Model
            // return View(product);

            // ViewData
            // this.ViewData["product"] = product;
            // ViewData["Title"] = product.Name;
            // return View("ViewProduct2");

            // ViewBag
            this.ViewBag.product = product;
            ViewBag.Title = product.Name;
            return View("ViewProduct3");
        }
    }
}