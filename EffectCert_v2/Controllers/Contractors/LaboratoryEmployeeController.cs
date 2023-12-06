using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Contractors;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Contractors
{
    public class LaboratoryEmployeeController : Controller
    {
        private readonly ILaboratoryEmployeeBLL laboratoryEmployeeBLL;

        public LaboratoryEmployeeController(ILaboratoryEmployeeBLL laboratoryEmployeeBLL)
        {
            this.laboratoryEmployeeBLL = laboratoryEmployeeBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Сотрудники лаборатории";

            var laboratoryEmployees = await laboratoryEmployeeBLL.FindAll();

            return View("~/Views/Catalogues/Contractors/LaboratoryEmployee/Index.cshtml", laboratoryEmployees);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные сотрудника лаборатории";

            var laboratoryEmployee = await laboratoryEmployeeBLL.Get(id);
            if (laboratoryEmployee.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/LaboratoryEmployee/Details.cshtml", laboratoryEmployee);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание сотрудника лаборатории";

            return View("~/Views/Catalogues/Contractors/LaboratoryEmployee/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LaboratoryEmployeeViewModel laboratoryEmployee)
        {
            if (ModelState.IsValid)
            {
                await laboratoryEmployeeBLL.UpdateOrCreate(laboratoryEmployee);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Contractors/LaboratoryEmployee/Create.cshtml", laboratoryEmployee);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в данные сотрудника лаборатории";

            var laboratoryEmployee = await laboratoryEmployeeBLL.Get(id);
            if (laboratoryEmployee.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/LaboratoryEmployee/Edit.cshtml", laboratoryEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LaboratoryEmployeeViewModel laboratoryEmployee)
        {
            if (id != laboratoryEmployee.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await laboratoryEmployeeBLL.UpdateOrCreate(laboratoryEmployee);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/LaboratoryEmployee/Edit.cshtml", laboratoryEmployee);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление записи о сотруднике лаборатории";

            var laboratoryEmployee = await laboratoryEmployeeBLL.Get(id);
            if (laboratoryEmployee.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/LaboratoryEmployee/Delete.cshtml", laboratoryEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, LaboratoryEmployeeViewModel laboratoryEmployee)
        {
            if (id != laboratoryEmployee.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await laboratoryEmployeeBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/LaboratoryEmployee/Delete.cshtml", laboratoryEmployee);
        }

        public async Task<JsonResult> GetLaboratoryEmployees(string searchStr)
        {
            var laboratoryEmployeesList = new List<Dictionary<string, string>>();
            var allLaboratoryEmployees = await laboratoryEmployeeBLL.Find(searchStr);

            foreach (var item in allLaboratoryEmployees)
            {
                var laboratoryEmployeeItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", String.Format("{0} {1}.", item.ContractorLegalEmployee.ContractorIndividual.LastName,
                                                           item.ContractorLegalEmployee.ContractorIndividual.FirstName)
                    }
                };

                laboratoryEmployeesList.Add(laboratoryEmployeeItem);
            }

            return Json(laboratoryEmployeesList);
        }
    }
}
