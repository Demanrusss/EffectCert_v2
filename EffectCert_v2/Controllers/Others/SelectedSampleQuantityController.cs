using EffectCert.BLL.Others;
using EffectCert.ViewModels.Others;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Others
{
    public class SelectedSampleQuantityController : Controller
    {
        private readonly SelectedSampleQuantityBLL selectedSampleQuantityBLL;

        public SelectedSampleQuantityController(SelectedSampleQuantityBLL selectedSampleQuantityBLL)
        {
            this.selectedSampleQuantityBLL = selectedSampleQuantityBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Количества отобранных образцов продукции";

            var selectedSampleQuantityes = await selectedSampleQuantityBLL.FindAll();

            return View("~/Views/Catalogues/Others/SelectedSampleQuantity/Index.cshtml", selectedSampleQuantityes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные количества отобранных образцов продукции";

            var selectedSampleQuantity = await selectedSampleQuantityBLL.Get(id);
            if (selectedSampleQuantity.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/SelectedSampleQuantity/Details.cshtml", selectedSampleQuantity);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание количества отобранных образцов продукции";

            return View("~/Views/Catalogues/Others/SelectedSampleQuantity/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SelectedSampleQuantityViewModel selectedSampleQuantity)
        {
            if (ModelState.IsValid)
            {
                await selectedSampleQuantityBLL.UpdateOrCreate(selectedSampleQuantity);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Others/SelectedSampleQuantity/Create.cshtml", selectedSampleQuantity);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в количество отобранных образцов продукции";

            var selectedSampleQuantity = await selectedSampleQuantityBLL.Get(id);
            if (selectedSampleQuantity.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/SelectedSampleQuantity/Edit.cshtml", selectedSampleQuantity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SelectedSampleQuantityViewModel selectedSampleQuantity)
        {
            if (id != selectedSampleQuantity.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await selectedSampleQuantityBLL.UpdateOrCreate(selectedSampleQuantity);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/SelectedSampleQuantity/Edit.cshtml", selectedSampleQuantity);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление количества отобранных образцов продукции";

            var selectedSampleQuantity = await selectedSampleQuantityBLL.Get(id);
            if (selectedSampleQuantity.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/SelectedSampleQuantity/Delete.cshtml", selectedSampleQuantity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, SelectedSampleQuantityViewModel selectedSampleQuantity)
        {
            if (id != selectedSampleQuantity.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await selectedSampleQuantityBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/SelectedSampleQuantity/Delete.cshtml", selectedSampleQuantity);
        }

        public async Task<JsonResult> GetSelectedSampleQuantities(string searchStr)
        {
            var selectedSampleQuantitiesList = new List<Dictionary<string, string>>();
            var allSelectedSampleQuantities = await selectedSampleQuantityBLL.Find(searchStr);

            foreach (var item in allSelectedSampleQuantities)
            {
                var selectedSampleQuantityItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", String.Format("{0} {1}", item.Quantity.ToString(), item.Product.Name) }
                };

                selectedSampleQuantitiesList.Add(selectedSampleQuantityItem);
            }

            return Json(selectedSampleQuantitiesList);
        }
    }
}
