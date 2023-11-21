using EffectCert.BLL.Documents;
using EffectCert.ViewModels.Documents;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Documents
{
    public class ContractController : Controller
    {
        private readonly ContractBLL contractBLL;

        public ContractController(ContractBLL contractBLL)
        {
            this.contractBLL = contractBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Контракты";

            var contractes = await contractBLL.FindAll();

            return View("~/Views/Catalogues/Documents/Contract/Index.cshtml", contractes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные контракта";

            var contract = await contractBLL.Get(id);
            if (contract.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/Contract/Details.cshtml", contract);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание контракта";

            return View("~/Views/Catalogues/Documents/Contract/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContractViewModel contract)
        {
            if (ModelState.IsValid)
            {
                await contractBLL.UpdateOrCreate(contract);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Documents/Contract/Create.cshtml", contract);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в контракт";

            var contract = await contractBLL.Get(id);
            if (contract.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/Contract/Edit.cshtml", contract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContractViewModel contract)
        {
            if (id != contract.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await contractBLL.UpdateOrCreate(contract);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/Contract/Edit.cshtml", contract);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление контракта";

            var contract = await contractBLL.Get(id);
            if (contract.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/Contract/Delete.cshtml", contract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ContractViewModel contract)
        {
            if (id != contract.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await contractBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/Contract/Delete.cshtml", contract);
        }

        public async Task<JsonResult> GetContracts(string searchStr)
        {
            var contractsList = new List<Dictionary<string, string>>();
            var allContracts = await contractBLL.Find(searchStr);

            foreach (var item in allContracts)
            {
                var contractItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number }
                };

                contractsList.Add(contractItem);
            }

            return Json(contractsList);
        }
    }
}
