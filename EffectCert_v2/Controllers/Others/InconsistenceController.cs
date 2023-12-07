using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Others;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Others
{
    public class InconsistenceController : Controller
    {
        private readonly IInconsistenceBLL inconsistenceBLL;

        public InconsistenceController(IInconsistenceBLL inconsistenceBLL)
        {
            this.inconsistenceBLL = inconsistenceBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Несоответствия";

            var inconsistencees = await inconsistenceBLL.FindAll();

            return View("~/Views/Catalogues/Others/Inconsistence/Index.cshtml", inconsistencees);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные несоответствия";

            var inconsistence = await inconsistenceBLL.Get(id);
            if (inconsistence.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/Inconsistence/Details.cshtml", inconsistence);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание несоответствия";

            return View("~/Views/Catalogues/Others/Inconsistence/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InconsistenceViewModel inconsistence)
        {
            if (ModelState.IsValid)
            {
                await inconsistenceBLL.UpdateOrCreate(inconsistence);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Others/Inconsistence/Create.cshtml", inconsistence);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в несоответствие";

            var inconsistence = await inconsistenceBLL.Get(id);
            if (inconsistence.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/Inconsistence/Edit.cshtml", inconsistence);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InconsistenceViewModel inconsistence)
        {
            if (id != inconsistence.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await inconsistenceBLL.UpdateOrCreate(inconsistence);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/Inconsistence/Edit.cshtml", inconsistence);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление несоответствия";

            var inconsistence = await inconsistenceBLL.Get(id);
            if (inconsistence.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/Inconsistence/Delete.cshtml", inconsistence);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, InconsistenceViewModel inconsistence)
        {
            if (id != inconsistence.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await inconsistenceBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/Inconsistence/Delete.cshtml", inconsistence);
        }

        public async Task<JsonResult> GetInconsistences(string searchStr)
        {
            var inconsistencesList = new List<Dictionary<string, string>>();
            var allInconsistences = await inconsistenceBLL.Find(searchStr);

            foreach (var item in allInconsistences)
            {
                var inconsistenceItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Name }
                };

                inconsistencesList.Add(inconsistenceItem);
            }

            return Json(inconsistencesList);
        }
    }
}
