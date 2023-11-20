using EffectCert.BLL.Others;
using EffectCert.ViewModels.Others;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Others
{
    public class ProductQuantityController : Controller
    {
        private readonly ProductQuantityBLL productQuantityBLL;

        public ProductQuantityController(ProductQuantityBLL productQuantityBLL)
        {
            this.productQuantityBLL = productQuantityBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Количества продукции";

            var productQuantityes = await productQuantityBLL.FindAll();

            return View("~/Views/Catalogues/Others/ProductQuantity/Index.cshtml", productQuantityes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные количества продукции";

            var productQuantity = await productQuantityBLL.Get(id);
            if (productQuantity.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/ProductQuantity/Details.cshtml", productQuantity);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание количества продукции";

            return View("~/Views/Catalogues/Others/ProductQuantity/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductQuantityViewModel productQuantity)
        {
            if (ModelState.IsValid)
            {
                await productQuantityBLL.UpdateOrCreate(productQuantity);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Others/ProductQuantity/Create.cshtml", productQuantity);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в количество продукции";

            var productQuantity = await productQuantityBLL.Get(id);
            if (productQuantity.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/ProductQuantity/Edit.cshtml", productQuantity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductQuantityViewModel productQuantity)
        {
            if (id != productQuantity.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await productQuantityBLL.UpdateOrCreate(productQuantity);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/ProductQuantity/Edit.cshtml", productQuantity);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление количества продукции";

            var productQuantity = await productQuantityBLL.Get(id);
            if (productQuantity.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/ProductQuantity/Delete.cshtml", productQuantity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ProductQuantityViewModel productQuantity)
        {
            if (id != productQuantity.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await productQuantityBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/ProductQuantity/Delete.cshtml", productQuantity);
        }

        public async Task<JsonResult> GetProductQuantities(string searchStr)
        {
            var productQuantitiesList = new List<Dictionary<string, string>>();
            var allProductQuantities = await productQuantityBLL.Find(searchStr);

            foreach (var item in allProductQuantities)
            {
                var productQuantityItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", String.Format("{0} {1}", item.Quantity.ToString(), item.Product.Name) }
                };

                productQuantitiesList.Add(productQuantityItem);
            }

            return Json(productQuantitiesList);
        }
    }
}
