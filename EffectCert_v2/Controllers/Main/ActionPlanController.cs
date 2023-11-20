using EffectCert.BLL.Main;
using EffectCert.ViewModels.Main;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Main
{
    public class ActionPlanController : Controller
    {
        private readonly ActionPlanBLL actionPlanBLL;

        public ActionPlanController(ActionPlanBLL actionPlanBLL)
        {
            this.actionPlanBLL = actionPlanBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Планы действий";

            var actionPlanes = await actionPlanBLL.FindAll();

            return View("~/Views/Catalogues/Main/ActionPlan/Index.cshtml", actionPlanes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные плана действий";

            var actionPlan = await actionPlanBLL.Get(id);
            if (actionPlan.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/ActionPlan/Details.cshtml", actionPlan);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание плана действий";

            return View("~/Views/Catalogues/Main/ActionPlan/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActionPlanViewModel actionPlan)
        {
            if (ModelState.IsValid)
            {
                await actionPlanBLL.UpdateOrCreate(actionPlan);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Main/ActionPlan/Create.cshtml", actionPlan);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в план действий";

            var actionPlan = await actionPlanBLL.Get(id);
            if (actionPlan.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/ActionPlan/Edit.cshtml", actionPlan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ActionPlanViewModel actionPlan)
        {
            if (id != actionPlan.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await actionPlanBLL.UpdateOrCreate(actionPlan);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Main/ActionPlan/Edit.cshtml", actionPlan);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление плана действий";

            var actionPlan = await actionPlanBLL.Get(id);
            if (actionPlan.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/ActionPlan/Delete.cshtml", actionPlan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ActionPlanViewModel actionPlan)
        {
            if (id != actionPlan.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await actionPlanBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Main/ActionPlan/Delete.cshtml", actionPlan);
        }

        public async Task<JsonResult> GetActionPlans(string searchStr)
        {
            var actionPlansList = new List<Dictionary<string, string>>();
            var allActionPlans = await actionPlanBLL.Find(searchStr);

            foreach (var item in allActionPlans)
            {
                var actionPlanItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number ?? item.Application.Number }
                };

                actionPlansList.Add(actionPlanItem);
            }

            return Json(actionPlansList);
        }
    }
}
