using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Contractors;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Contractors
{
    public class ContractorLegalEmployeeController : Controller
    {
        private readonly IContractorLegalEmployeeBLL contractorLegalEmployeeBLL;

        public ContractorLegalEmployeeController(IContractorLegalEmployeeBLL contractorLegalEmployeeBLL)
        {
            this.contractorLegalEmployeeBLL = contractorLegalEmployeeBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Сотрудники компании";

            var contractorLegalEmployees = await contractorLegalEmployeeBLL.FindAll();

            return View("~/Views/Catalogues/Contractors/ContractorLegalEmployee/Index.cshtml", contractorLegalEmployees);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные сотрудника компании";

            var contractorLegalEmployee = await contractorLegalEmployeeBLL.Get(id);
            if (contractorLegalEmployee.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/ContractorLegalEmployee/Details.cshtml", contractorLegalEmployee);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание сотрудника компании";

            return View("~/Views/Catalogues/Contractors/ContractorLegalEmployee/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContractorLegalEmployeeViewModel contractorLegalEmployee)
        {
            if (ModelState.IsValid)
            {
                await contractorLegalEmployeeBLL.UpdateOrCreate(contractorLegalEmployee);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Contractors/ContractorLegalEmployee/Create.cshtml", contractorLegalEmployee);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в данные сотрудника компании";

            var contractorLegalEmployee = await contractorLegalEmployeeBLL.Get(id);
            if (contractorLegalEmployee.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/ContractorLegalEmployee/Edit.cshtml", contractorLegalEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContractorLegalEmployeeViewModel contractorLegalEmployee)
        {
            if (id != contractorLegalEmployee.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await contractorLegalEmployeeBLL.UpdateOrCreate(contractorLegalEmployee);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/ContractorLegalEmployee/Edit.cshtml", contractorLegalEmployee);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление записи о сотруднике компании";

            var contractorLegalEmployee = await contractorLegalEmployeeBLL.Get(id);
            if (contractorLegalEmployee.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/ContractorLegalEmployee/Delete.cshtml", contractorLegalEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ContractorLegalEmployeeViewModel contractorLegalEmployee)
        {
            if (id != contractorLegalEmployee.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await contractorLegalEmployeeBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/ContractorLegalEmployee/Delete.cshtml", contractorLegalEmployee);
        }

        public async Task<JsonResult> GetContractorLegalEmployees(string searchStr)
        {
            var contractorLegalEmployeesList = new List<Dictionary<string, string>>();
            var allContractorLegalEmployees = await contractorLegalEmployeeBLL.Find(searchStr);

            foreach (var item in allContractorLegalEmployees)
            {
                var contractorLegalEmployeeItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", String.Format("{0} {1}.", item.ContractorIndividual.LastName,
                                                        item.ContractorIndividual.FirstName)
                    }
                };

                contractorLegalEmployeesList.Add(contractorLegalEmployeeItem);
            }

            return Json(contractorLegalEmployeesList);
        }
    }
}
