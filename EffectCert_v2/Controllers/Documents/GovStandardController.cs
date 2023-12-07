using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Documents;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Documents
{
    public class GovStandardController : Controller
    {
        private readonly IGovStandardBLL govStandardBLL;

        public GovStandardController(IGovStandardBLL govStandardBLL)
        {
            this.govStandardBLL = govStandardBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "ГОСТы";

            var govStandardes = await govStandardBLL.FindAll();

            return View("~/Views/Catalogues/Documents/GovStandard/Index.cshtml", govStandardes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные контракта";

            var govStandard = await govStandardBLL.Get(id);
            if (govStandard.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/GovStandard/Details.cshtml", govStandard);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание ГОСТа";

            return View("~/Views/Catalogues/Documents/GovStandard/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GovStandardViewModel govStandard)
        {
            if (ModelState.IsValid)
            {
                await govStandardBLL.UpdateOrCreate(govStandard);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Documents/GovStandard/Create.cshtml", govStandard);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в ГОСТ";

            var govStandard = await govStandardBLL.Get(id);
            if (govStandard.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/GovStandard/Edit.cshtml", govStandard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GovStandardViewModel govStandard)
        {
            if (id != govStandard.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await govStandardBLL.UpdateOrCreate(govStandard);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/GovStandard/Edit.cshtml", govStandard);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление ГОСТа";

            var govStandard = await govStandardBLL.Get(id);
            if (govStandard.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/GovStandard/Delete.cshtml", govStandard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, GovStandardViewModel govStandard)
        {
            if (id != govStandard.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await govStandardBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/GovStandard/Delete.cshtml", govStandard);
        }

        public async Task<JsonResult> GetGovStandards(string searchStr)
        {
            var govStandardsList = new List<Dictionary<string, string>>();
            var allGovStandards = await govStandardBLL.Find(searchStr);

            foreach (var item in allGovStandards)
            {
                var govStandardItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number }
                };

                govStandardsList.Add(govStandardItem);
            }

            return Json(govStandardsList);
        }
    }
}
