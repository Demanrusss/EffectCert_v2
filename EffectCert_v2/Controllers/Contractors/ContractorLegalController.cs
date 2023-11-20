using EffectCert.BLL.Contractors;
using EffectCert.BLL.Documents;
using EffectCert.ViewModels.Contractors;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Contractors
{
    public class ContractorLegalController : Controller
    {
        private readonly ContractorLegalBLL contractorLegalBLL;
        private readonly AttestateBLL attestateBLL;

        public ContractorLegalController(ContractorLegalBLL contractorLegalBLL, AttestateBLL attestateBLL)
        {
            this.contractorLegalBLL = contractorLegalBLL;
            this.attestateBLL = attestateBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Юридические лица";

            var contractorLegals = await contractorLegalBLL.FindAll();

            return View("~/Views/Catalogues/Contractors/ContractorLegal/Index.cshtml", contractorLegals);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные юридического лица";

            var contractorLegal = await contractorLegalBLL.Get(id);
            if (contractorLegal.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/ContractorLegal/Details.cshtml", contractorLegal);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание юридического лица";

            return View("~/Views/Catalogues/Contractors/ContractorLegal/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContractorLegalViewModel contractorLegal)
        {
            if (ModelState.IsValid)
            {
                await contractorLegalBLL.UpdateOrCreate(contractorLegal);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Contractors/ContractorLegal/Create.cshtml", contractorLegal);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в данные юридического лица";

            var contractorLegal = await contractorLegalBLL.Get(id);
            if (contractorLegal.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/ContractorLegal/Edit.cshtml", contractorLegal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContractorLegalViewModel contractorLegal)
        {
            if (id != contractorLegal.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await contractorLegalBLL.UpdateOrCreate(contractorLegal);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/ContractorLegal/Edit.cshtml", contractorLegal);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление ОПС";

            var contractorLegal = await contractorLegalBLL.Get(id);
            if (contractorLegal.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/ContractorLegal/Delete.cshtml", contractorLegal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ContractorLegalViewModel contractorLegal)
        {
            if (id != contractorLegal.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await contractorLegalBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/ContractorLegal/Delete.cshtml", contractorLegal);
        }

        public async Task<JsonResult> GetContractorLegals(string searchStr)
        {
            var contractorLegalsList = new List<Dictionary<string, string>>();
            var allContractorLegals = await contractorLegalBLL.Find(searchStr);

            foreach (var item in allContractorLegals)
            {
                var contractorLegalItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.ShortName }
                };

                contractorLegalsList.Add(contractorLegalItem);
            }

            return Json(contractorLegalsList);
        }
    }
}
