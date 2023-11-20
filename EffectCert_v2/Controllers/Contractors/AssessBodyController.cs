using EffectCert.BLL.Contractors;
using EffectCert.BLL.Documents;
using EffectCert.ViewModels.Contractors;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Contractors
{
    public class AssessBodyController : Controller
    {
        private readonly AssessBodyBLL assessBodyBLL;
        private readonly AttestateBLL attestateBLL;

        public AssessBodyController(AssessBodyBLL assessBodyBLL, AttestateBLL attestateBLL)
        {
            this.assessBodyBLL = assessBodyBLL;
            this.attestateBLL = attestateBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Органы подтверждения соответствия";

            var assessBodies = await assessBodyBLL.FindAll();

            return View("~/Views/Catalogues/Contractors/AssessBody/Index.cshtml", assessBodies);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные ОПС";

            var assessBody = await assessBodyBLL.Get(id);
            if (assessBody.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/AssessBody/Details.cshtml", assessBody);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание ОПС";

            return View("~/Views/Catalogues/Contractors/AssessBody/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssessBodyViewModel assessBody)
        {
            if (ModelState.IsValid)
            {
                await assessBodyBLL.UpdateOrCreate(assessBody);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Contractors/AssessBody/Create.cshtml", assessBody);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в данные ОПС";

            var assessBody = await assessBodyBLL.Get(id);
            if (assessBody.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/AssessBody/Edit.cshtml", assessBody);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AssessBodyViewModel assessBody)
        {
            if (id != assessBody.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await assessBodyBLL.UpdateOrCreate(assessBody);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/AssessBody/Edit.cshtml", assessBody);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление ОПС";

            var assessBody = await assessBodyBLL.Get(id);
            if (assessBody.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/AssessBody/Delete.cshtml", assessBody);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AssessBodyViewModel assessBody)
        {
            if (id != assessBody.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await assessBodyBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/AssessBody/Delete.cshtml", assessBody);
        }

        public async Task<JsonResult> GetAssessBodies(string searchStr)
        {
            var assessBodiesList = new List<Dictionary<string, string>>();
            var allAssessBodies = await assessBodyBLL.Find(searchStr);

            foreach (var item in allAssessBodies)
            {
                var assessBodyItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.ShortName }
                };

                assessBodiesList.Add(assessBodyItem);
            }

            return Json(assessBodiesList);
        }
    }
}
