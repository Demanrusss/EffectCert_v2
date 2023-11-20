using EffectCert.BLL.Contractors;
using EffectCert.BLL.Documents;
using EffectCert.ViewModels.Contractors;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Contractors
{
    public class ContractorIndividualController : Controller
    {
        private readonly ContractorIndividualBLL contractorIndividualBLL;
        private readonly AttestateBLL attestateBLL;

        public ContractorIndividualController(ContractorIndividualBLL contractorIndividualBLL, AttestateBLL attestateBLL)
        {
            this.contractorIndividualBLL = contractorIndividualBLL;
            this.attestateBLL = attestateBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Физические лица";

            var contractorIndividuals = await contractorIndividualBLL.FindAll();

            return View("~/Views/Catalogues/Contractors/ContractorIndividual/Index.cshtml", contractorIndividuals);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные физического лица";

            var contractorIndividual = await contractorIndividualBLL.Get(id);
            if (contractorIndividual.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/ContractorIndividual/Details.cshtml", contractorIndividual);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание физического лица";

            return View("~/Views/Catalogues/Contractors/ContractorIndividual/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContractorIndividualViewModel contractorIndividual)
        {
            if (ModelState.IsValid)
            {
                await contractorIndividualBLL.UpdateOrCreate(contractorIndividual);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Contractors/ContractorIndividual/Create.cshtml", contractorIndividual);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в данные физического лица";

            var contractorIndividual = await contractorIndividualBLL.Get(id);
            if (contractorIndividual.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/ContractorIndividual/Edit.cshtml", contractorIndividual);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContractorIndividualViewModel contractorIndividual)
        {
            if (id != contractorIndividual.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await contractorIndividualBLL.UpdateOrCreate(contractorIndividual);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/ContractorIndividual/Edit.cshtml", contractorIndividual);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление физического лица";

            var contractorIndividual = await contractorIndividualBLL.Get(id);
            if (contractorIndividual.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/ContractorIndividual/Delete.cshtml", contractorIndividual);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ContractorIndividualViewModel contractorIndividual)
        {
            if (id != contractorIndividual.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await contractorIndividualBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/ContractorIndividual/Delete.cshtml", contractorIndividual);
        }

        public async Task<JsonResult> GetContractorIndividuals(string searchStr)
        {
            var contractorIndividualsList = new List<Dictionary<string, string>>();
            var allContractorIndividuals = await contractorIndividualBLL.Find(searchStr);

            foreach (var item in allContractorIndividuals)
            {
                var contractorIndividualItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", String.Format("{0} {1}.", item.LastName, item.FirstName[0]) }
                };

                contractorIndividualsList.Add(contractorIndividualItem);
            }

            return Json(contractorIndividualsList);
        }
    }
}
