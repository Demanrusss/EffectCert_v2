using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Contractors;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Contractors
{
    public class LaboratoryController : Controller
    {
        private readonly ILaboratoryBLL laboratoryBLL;
        private readonly IAttestateBLL attestateBLL;

        public LaboratoryController(ILaboratoryBLL laboratoryBLL, IAttestateBLL attestateBLL)
        {
            this.laboratoryBLL = laboratoryBLL;
            this.attestateBLL = attestateBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Лаборатории";

            var assessBodies = await laboratoryBLL.FindAll();

            return View("~/Views/Catalogues/Contractors/Laboratory/Index.cshtml", assessBodies);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные лаборатории";

            var laboratory = await laboratoryBLL.Get(id);
            if (laboratory.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/Laboratory/Details.cshtml", laboratory);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание лаборатории";

            return View("~/Views/Catalogues/Contractors/Laboratory/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LaboratoryViewModel laboratory)
        {
            if (ModelState.IsValid)
            {
                await laboratoryBLL.UpdateOrCreate(laboratory);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Contractors/Laboratory/Create.cshtml", laboratory);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в данные лаборатории";

            var laboratory = await laboratoryBLL.Get(id);
            if (laboratory.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/Laboratory/Edit.cshtml", laboratory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LaboratoryViewModel laboratory)
        {
            if (id != laboratory.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await laboratoryBLL.UpdateOrCreate(laboratory);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/Laboratory/Edit.cshtml", laboratory);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление лаборатории";

            var laboratory = await laboratoryBLL.Get(id);
            if (laboratory.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/Laboratory/Delete.cshtml", laboratory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, LaboratoryViewModel laboratory)
        {
            if (id != laboratory.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await laboratoryBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/Laboratory/Delete.cshtml", laboratory);
        }

        public async Task<JsonResult> GetLaboratories(string searchStr)
        {
            var laboratoriesList = new List<Dictionary<string, string>>();
            var allLaboraties = await laboratoryBLL.Find(searchStr);

            foreach (var item in allLaboraties)
            {
                var laboratoryItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.ShortName }
                };

                laboratoriesList.Add(laboratoryItem);
            }

            return Json(laboratoriesList);
        }
    }
}
