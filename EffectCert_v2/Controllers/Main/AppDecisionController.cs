using EffectCert.BLL.Main;
using EffectCert.ViewModels.Main;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Main
{
    public class AppDecisionController : Controller
    {
        private readonly AppDecisionBLL appDecisionBLL;

        public AppDecisionController(AppDecisionBLL appDecisionBLL)
        {
            this.appDecisionBLL = appDecisionBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Решения по заявкам";

            var appDecisiones = await appDecisionBLL.FindAll();

            return View("~/Views/Catalogues/Main/AppDecision/Index.cshtml", appDecisiones);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные решения по заявке";

            var appDecision = await appDecisionBLL.Get(id);
            if (appDecision.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/AppDecision/Details.cshtml", appDecision);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание решения по заявке";

            return View("~/Views/Catalogues/Main/AppDecision/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppDecisionViewModel appDecision)
        {
            if (ModelState.IsValid)
            {
                await appDecisionBLL.UpdateOrCreate(appDecision);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Main/AppDecision/Create.cshtml", appDecision);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в решение по заявке";

            var appDecision = await appDecisionBLL.Get(id);
            if (appDecision.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/AppDecision/Edit.cshtml", appDecision);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AppDecisionViewModel appDecision)
        {
            if (id != appDecision.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await appDecisionBLL.UpdateOrCreate(appDecision);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Main/AppDecision/Edit.cshtml", appDecision);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление решения по заявке";

            var appDecision = await appDecisionBLL.Get(id);
            if (appDecision.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/AppDecision/Delete.cshtml", appDecision);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AppDecisionViewModel appDecision)
        {
            if (id != appDecision.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await appDecisionBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Main/AppDecision/Delete.cshtml", appDecision);
        }

        public async Task<JsonResult> GetAppDecisions(string searchStr)
        {
            var appDecisionsList = new List<Dictionary<string, string>>();
            var allAppDecisions = await appDecisionBLL.Find(searchStr);

            foreach (var item in allAppDecisions)
            {
                var appDecisionItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number ?? item.Application.Number }
                };

                appDecisionsList.Add(appDecisionItem);
            }

            return Json(appDecisionsList);
        }
    }
}
