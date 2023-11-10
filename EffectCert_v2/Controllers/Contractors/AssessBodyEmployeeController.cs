using EffectCert.BLL.Contractors;
using EffectCert.ViewModels.Contractors;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Contractors
{
    public class AssessBodyEmployeeController : Controller
    {
        private readonly AssessBodyEmployeeBLL assessBodyEmployeeBLL;

        public AssessBodyEmployeeController(AssessBodyEmployeeBLL assessBodyEmployeeBLL)
        {
            this.assessBodyEmployeeBLL = assessBodyEmployeeBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Сотрудники ОПС";

            var assessBodyEmployees = await assessBodyEmployeeBLL.FindAll();

            return View("~/Views/Catalogues/Contractors/AssessBodyEmployee/Index.cshtml", assessBodyEmployees);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные сотрудника ОПС";

            var assessBodyEmployee = await assessBodyEmployeeBLL.Get(id);
            if (assessBodyEmployee.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/AssessBodyEmployee/Details.cshtml", assessBodyEmployee);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание сотрудника ОПС";

            return View("~/Views/Catalogues/Contractors/AssessBodyEmployee/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssessBodyEmployeeViewModel assessBodyEmployee)
        {
            if (ModelState.IsValid)
            {
                await assessBodyEmployeeBLL.UpdateOrCreate(assessBodyEmployee);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Contractors/AssessBodyEmployee/Create.cshtml", assessBodyEmployee);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в данные сотрудника ОПС";

            var assessBodyEmployee = await assessBodyEmployeeBLL.Get(id);
            if (assessBodyEmployee.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/AssessBodyEmployee/Edit.cshtml", assessBodyEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AssessBodyEmployeeViewModel assessBodyEmployee)
        {
            if (id != assessBodyEmployee.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await assessBodyEmployeeBLL.UpdateOrCreate(assessBodyEmployee);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/AssessBodyEmployee/Edit.cshtml", assessBodyEmployee);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление записи о сотруднике ОПС";

            var assessBodyEmployee = await assessBodyEmployeeBLL.Get(id);
            if (assessBodyEmployee.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/AssessBodyEmployee/Delete.cshtml", assessBodyEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AssessBodyEmployeeViewModel assessBodyEmployee)
        {
            if (id != assessBodyEmployee.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await assessBodyEmployeeBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/AssessBodyEmployee/Delete.cshtml", assessBodyEmployee);
        }

        public async Task<JsonResult> GetAssessBodyEmployees(string searchStr)
        {
            var assessBodyEmployeesList = new List<Dictionary<string, string>>();
            var allAssessBodyEmployees = await assessBodyEmployeeBLL.Find(searchStr);

            foreach (var item in allAssessBodyEmployees)
            {
                var assessBodyEmployeeItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", String.Format("{0} {1} {2}", item.ContractorLegalEmployee.ContractorIndividual.LastName,
                                                           item.ContractorLegalEmployee.ContractorIndividual.FirstName,
                                                           item.ContractorLegalEmployee.ContractorIndividual.MiddleName ?? String.Empty)
                    }
                };

                assessBodyEmployeesList.Add(assessBodyEmployeeItem);
            }

            return Json(assessBodyEmployeesList);
        }
    }
}
