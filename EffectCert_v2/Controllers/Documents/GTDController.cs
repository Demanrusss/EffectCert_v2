using EffectCert.BLL.Documents;
using EffectCert.ViewModels.Documents;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Documents
{
    public class GTDController : Controller
    {
        private readonly GTDBLL gTDBLL;

        public GTDController(GTDBLL gTDBLL)
        {
            this.gTDBLL = gTDBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "ГТД";

            var gTDes = await gTDBLL.FindAll();

            return View("~/Views/Catalogues/Documents/GTD/Index.cshtml", gTDes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные ГТД";

            var gTD = await gTDBLL.Get(id);
            if (gTD.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/GTD/Details.cshtml", gTD);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание ГТД";

            return View("~/Views/Catalogues/Documents/GTD/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GTDViewModel gTD)
        {
            if (ModelState.IsValid)
            {
                await gTDBLL.UpdateOrCreate(gTD);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Documents/GTD/Create.cshtml", gTD);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в ГТД";

            var gTD = await gTDBLL.Get(id);
            if (gTD.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/GTD/Edit.cshtml", gTD);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GTDViewModel gTD)
        {
            if (id != gTD.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await gTDBLL.UpdateOrCreate(gTD);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/GTD/Edit.cshtml", gTD);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление ГТД";

            var gTD = await gTDBLL.Get(id);
            if (gTD.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/GTD/Delete.cshtml", gTD);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, GTDViewModel gTD)
        {
            if (id != gTD.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await gTDBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/GTD/Delete.cshtml", gTD);
        }

        public async Task<JsonResult> GetGTDs(string searchStr)
        {
            var gTDsList = new List<Dictionary<string, string>>();
            var allGTDs = await gTDBLL.Find(searchStr);

            foreach (var item in allGTDs)
            {
                var gTDItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number }
                };

                gTDsList.Add(gTDItem);
            }

            return Json(gTDsList);
        }
    }
}
