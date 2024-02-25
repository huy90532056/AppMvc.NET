using AppMvc.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMvc.Net.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;

        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService producService)
        {
            _logger = logger;
            _productService = producService;
        }
        public string Index()
        {
            
            _logger.LogInformation("Index Action");

            return "Toi la index cua first";
        }

        public void Nothing()
        {
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("Hi", "xin chao");
        }

        public IActionResult Readme()
        {
            var content = @"
            xin
            chao
            abc
            ";
            return this.Content(content, "text/plain");
        }

        public IActionResult Dog()
        {
            string filePath = Path.Combine(Startup.ContentRootPath, "Files", "Dog.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "image/jpg");
        }

        public IActionResult IphonePrice()
        {
            return Json(
                new {
                    ProductName = "Iphone14",
                    Price = 1000
                }
            );
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyen huong den" + url);
            return LocalRedirect(url); 
        }

        public IActionResult HelloView(string username){
            if(string.IsNullOrEmpty(username))
            {
                username = "Khach";
            }
            return View("xinchao3", username);
        }

        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if(product == null){
                TempData["StatusMessage"] = "san pham yeu cau k co";
                return Redirect(Url.Action("Index","Home"));
            }

            //View/First/ViewProduct.cshtml
            //MyView/First/ViewProduct.cshtml
            // return View(product);

            // controller => view
            // this.ViewData["product"] = product;
            // ViewData["Title"] = product.Name;

            // return View("ViewProduct2");

            

            ViewBag.product = product;
            return View("ViewProduct3");
        }
    }
}