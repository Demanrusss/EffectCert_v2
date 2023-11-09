using EffectCert.BLL.Documents;
using EffectCert.ViewModels.Documents;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Contractors
{
    public class AttestateController : Controller
    {
        private readonly AttestateBLL attestateBLL;

        public AttestateController(AttestateBLL attestateBLL)
        {
            this.attestateBLL = attestateBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Аттестаты";

            var attestates = await attestateBLL.FindAll();

            return View("~/Views/Catalogues/Contractors/Attestate/Index.cshtml", attestates);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные аттестата";

            var attestate = await attestateBLL.Get(id);
            if (attestate.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/Attestate/Details.cshtml", attestate);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание аттестата";

            return View("~/Views/Catalogues/Contractors/Attestate/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AttestateViewModel attestate)
        {
            if (ModelState.IsValid)
            {
                await attestateBLL.UpdateOrCreate(attestate);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Contractors/Attestate/Create.cshtml", attestate);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в аттестат";

            var attestate = await attestateBLL.Get(id);
            if (attestate.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/Attestate/Edit.cshtml", attestate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AttestateViewModel attestate)
        {
            if (id != attestate.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await attestateBLL.UpdateOrCreate(attestate);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/Attestate/Edit.cshtml", attestate);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление аттестата";

            var attestate = await attestateBLL.Get(id);
            if (attestate.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/Attestate/Delete.cshtml", attestate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AttestateViewModel attestate)
        {
            if (id != attestate.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await attestateBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/Attestate/Delete.cshtml", attestate);
        }

        public async Task<JsonResult> GetAttestates(string searchStr)
        {
            var attestatesList = new List<Dictionary<string, string>>();
            var allAttestates = await attestateBLL.Find(searchStr);

            foreach (var item in allAttestates)
            {
                var attestateItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number }
                };

                attestatesList.Add(attestateItem);
            }

            return Json(attestatesList);
        }
    }
}
