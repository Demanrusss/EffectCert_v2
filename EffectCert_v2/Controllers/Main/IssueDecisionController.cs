using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Main;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Main
{
    public class IssueDecisionController : Controller
    {
        private readonly IIssueDecisionBLL issueDecisionBLL;

        public IssueDecisionController(IIssueDecisionBLL issueDecisionBLL)
        {
            this.issueDecisionBLL = issueDecisionBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Решения ОПС";

            var issueDecisiones = await issueDecisionBLL.FindAll();

            return View("~/Views/Catalogues/Main/IssueDecision/Index.cshtml", issueDecisiones);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные решения ОПС";

            var issueDecision = await issueDecisionBLL.Get(id);
            if (issueDecision.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/IssueDecision/Details.cshtml", issueDecision);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание решения ОПС";

            return View("~/Views/Catalogues/Main/IssueDecision/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IssueDecisionViewModel issueDecision)
        {
            if (ModelState.IsValid)
            {
                await issueDecisionBLL.UpdateOrCreate(issueDecision);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Main/IssueDecision/Create.cshtml", issueDecision);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в решения ОПС";

            var issueDecision = await issueDecisionBLL.Get(id);
            if (issueDecision.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/IssueDecision/Edit.cshtml", issueDecision);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IssueDecisionViewModel issueDecision)
        {
            if (id != issueDecision.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await issueDecisionBLL.UpdateOrCreate(issueDecision);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Main/IssueDecision/Edit.cshtml", issueDecision);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление решения ОПС";

            var issueDecision = await issueDecisionBLL.Get(id);
            if (issueDecision.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/IssueDecision/Delete.cshtml", issueDecision);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IssueDecisionViewModel issueDecision)
        {
            if (id != issueDecision.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await issueDecisionBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Main/IssueDecision/Delete.cshtml", issueDecision);
        }

        public async Task<JsonResult> GetIssueDecisions(string searchStr)
        {
            var issueDecisionsList = new List<Dictionary<string, string>>();
            var allIssueDecisions = await issueDecisionBLL.Find(searchStr);

            foreach (var item in allIssueDecisions)
            {
                var issueDecisionItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number ?? item.Application.Number }
                };

                issueDecisionsList.Add(issueDecisionItem);
            }

            return Json(issueDecisionsList);
        }
    }
}
