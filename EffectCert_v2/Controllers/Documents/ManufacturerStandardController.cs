using EffectCert.BLL.Documents;
using EffectCert.ViewModels.Documents;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.ManufacturerStandardors
{
    public class ManufacturerStandardController : Controller
    {
        private readonly ManufacturerStandardBLL manufacturerStandardBLL;

        public ManufacturerStandardController(ManufacturerStandardBLL manufacturerStandardBLL)
        {
            this.manufacturerStandardBLL = manufacturerStandardBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "СТ ТОО";

            var manufacturerStandardes = await manufacturerStandardBLL.FindAll();

            return View("~/Views/Catalogues/Documents/ManufacturerStandard/Index.cshtml", manufacturerStandardes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные СТ ТОО";

            var manufacturerStandard = await manufacturerStandardBLL.Get(id);
            if (manufacturerStandard.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/ManufacturerStandard/Details.cshtml", manufacturerStandard);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание СТ ТОО";

            return View("~/Views/Catalogues/Documents/ManufacturerStandard/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ManufacturerStandardViewModel manufacturerStandard)
        {
            if (ModelState.IsValid)
            {
                await manufacturerStandardBLL.UpdateOrCreate(manufacturerStandard);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Documents/ManufacturerStandard/Create.cshtml", manufacturerStandard);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в СТ ТОО";

            var manufacturerStandard = await manufacturerStandardBLL.Get(id);
            if (manufacturerStandard.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/ManufacturerStandard/Edit.cshtml", manufacturerStandard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ManufacturerStandardViewModel manufacturerStandard)
        {
            if (id != manufacturerStandard.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await manufacturerStandardBLL.UpdateOrCreate(manufacturerStandard);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/ManufacturerStandard/Edit.cshtml", manufacturerStandard);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление СТ ТОО";

            var manufacturerStandard = await manufacturerStandardBLL.Get(id);
            if (manufacturerStandard.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/ManufacturerStandard/Delete.cshtml", manufacturerStandard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ManufacturerStandardViewModel manufacturerStandard)
        {
            if (id != manufacturerStandard.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await manufacturerStandardBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/ManufacturerStandard/Delete.cshtml", manufacturerStandard);
        }

        public async Task<JsonResult> GetManufacturerStandards(string searchStr)
        {
            var manufacturerStandardsList = new List<Dictionary<string, string>>();
            var allManufacturerStandards = await manufacturerStandardBLL.Find(searchStr);

            foreach (var item in allManufacturerStandards)
            {
                var manufacturerStandardItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number }
                };

                manufacturerStandardsList.Add(manufacturerStandardItem);
            }

            return Json(manufacturerStandardsList);
        }
    }
}
