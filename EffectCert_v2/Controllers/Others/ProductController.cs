using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Others;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Others
{
    public class ProductController : Controller
    {
        private readonly IProductBLL productBLL;

        public ProductController(IProductBLL productBLL)
        {
            this.productBLL = productBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Продукция";

            var productes = await productBLL.FindAll();

            return View("~/Views/Catalogues/Others/Product/Index.cshtml", productes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные продукции";

            var product = await productBLL.Get(id);
            if (product.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/Product/Details.cshtml", product);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание продукции";

            return View("~/Views/Catalogues/Others/Product/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                await productBLL.UpdateOrCreate(product);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Others/Product/Create.cshtml", product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в продукцию";

            var product = await productBLL.Get(id);
            if (product.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/Product/Edit.cshtml", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel product)
        {
            if (id != product.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await productBLL.UpdateOrCreate(product);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/Product/Edit.cshtml", product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление продукции";

            var product = await productBLL.Get(id);
            if (product.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/Product/Delete.cshtml", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ProductViewModel product)
        {
            if (id != product.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await productBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/Product/Delete.cshtml", product);
        }

        public async Task<JsonResult> GetProducts(string searchStr)
        {
            var productsList = new List<Dictionary<string, string>>();
            var allProducts = await productBLL.Find(searchStr);

            foreach (var item in allProducts)
            {
                var productItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Name }
                };

                productsList.Add(productItem);
            }

            return Json(productsList);
        }
    }
}
