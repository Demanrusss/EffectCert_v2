using EffectCert.BLL.Others;
using EffectCert.ViewModels.Others;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Others
{
    public class RequirementController : Controller
    {
        private readonly RequirementBLL requirementBLL;

        public RequirementController(RequirementBLL requirementBLL)
        {
            this.requirementBLL = requirementBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Требования";

            var requirementes = await requirementBLL.FindAll();

            return View("~/Views/Catalogues/Others/Requirement/Index.cshtml", requirementes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные требования";

            var requirement = await requirementBLL.Get(id);
            if (requirement.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/Requirement/Details.cshtml", requirement);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание требования";

            return View("~/Views/Catalogues/Others/Requirement/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RequirementViewModel requirement)
        {
            if (ModelState.IsValid)
            {
                await requirementBLL.UpdateOrCreate(requirement);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Others/Requirement/Create.cshtml", requirement);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в требование";

            var requirement = await requirementBLL.Get(id);
            if (requirement.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/Requirement/Edit.cshtml", requirement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RequirementViewModel requirement)
        {
            if (id != requirement.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await requirementBLL.UpdateOrCreate(requirement);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/Requirement/Edit.cshtml", requirement);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление требования";

            var requirement = await requirementBLL.Get(id);
            if (requirement.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/Requirement/Delete.cshtml", requirement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, RequirementViewModel requirement)
        {
            if (id != requirement.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await requirementBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/Requirement/Delete.cshtml", requirement);
        }

        public async Task<JsonResult> GetRequirements(string searchStr)
        {
            var requirementsList = new List<Dictionary<string, string>>();
            var allRequirements = await requirementBLL.Find(searchStr);

            foreach (var item in allRequirements)
            {
                var requirementItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Name }
                };

                requirementsList.Add(requirementItem);
            }

            return Json(requirementsList);
        }
    }
}
