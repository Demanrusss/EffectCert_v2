using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Main;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Main
{
    public class ExpertDecisionController : Controller
    {
        private readonly IExpertDecisionBLL expertDecisionBLL;

        public ExpertDecisionController(IExpertDecisionBLL expertDecisionBLL)
        {
            this.expertDecisionBLL = expertDecisionBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Заключения эксперта";

            var expertDecisiones = await expertDecisionBLL.FindAll();

            return View("~/Views/Catalogues/Main/ExpertDecision/Index.cshtml", expertDecisiones);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные заключения эксперта";

            var expertDecision = await expertDecisionBLL.Get(id);
            if (expertDecision.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/ExpertDecision/Details.cshtml", expertDecision);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание заключения эксперта";

            return View("~/Views/Catalogues/Main/ExpertDecision/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpertDecisionViewModel expertDecision)
        {
            if (ModelState.IsValid)
            {
                await expertDecisionBLL.UpdateOrCreate(expertDecision);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Main/ExpertDecision/Create.cshtml", expertDecision);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в заключение эксперта";

            var expertDecision = await expertDecisionBLL.Get(id);
            if (expertDecision.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/ExpertDecision/Edit.cshtml", expertDecision);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExpertDecisionViewModel expertDecision)
        {
            if (id != expertDecision.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await expertDecisionBLL.UpdateOrCreate(expertDecision);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Main/ExpertDecision/Edit.cshtml", expertDecision);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление заключения эксперта";

            var expertDecision = await expertDecisionBLL.Get(id);
            if (expertDecision.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/ExpertDecision/Delete.cshtml", expertDecision);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ExpertDecisionViewModel expertDecision)
        {
            if (id != expertDecision.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await expertDecisionBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Main/ExpertDecision/Delete.cshtml", expertDecision);
        }

        public async Task<JsonResult> GetExpertDecisions(string searchStr)
        {
            var expertDecisionsList = new List<Dictionary<string, string>>();
            var allExpertDecisions = await expertDecisionBLL.Find(searchStr);

            foreach (var item in allExpertDecisions)
            {
                var expertDecisionItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number ?? item.Application?.Number ?? String.Empty }
                };

                expertDecisionsList.Add(expertDecisionItem);
            }

            return Json(expertDecisionsList);
        }
    }
}
