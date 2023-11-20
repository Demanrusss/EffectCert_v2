using EffectCert.BLL.Contractors;
using EffectCert.ViewModels.Contractors;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Contractors
{
    public class BankAccountController : Controller
    {
        private readonly BankAccountBLL bankAccountBLL;

        public BankAccountController(BankAccountBLL bankAccountBLL)
        {
            this.bankAccountBLL = bankAccountBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Банковские счета";

            var bankAccountes = await bankAccountBLL.FindAll();

            return View("~/Views/Catalogues/Contractors/BankAccount/Index.cshtml", bankAccountes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные банковского счета";

            var bankAccount = await bankAccountBLL.Get(id);
            if (bankAccount.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/BankAccount/Details.cshtml", bankAccount);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание банковского счета";

            return View("~/Views/Catalogues/Contractors/BankAccount/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BankAccountViewModel bankAccount)
        {
            if (ModelState.IsValid)
            {
                await bankAccountBLL.UpdateOrCreate(bankAccount);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Contractors/BankAccount/Create.cshtml", bankAccount);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в банковский счет";

            var bankAccount = await bankAccountBLL.Get(id);
            if (bankAccount.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/BankAccount/Edit.cshtml", bankAccount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BankAccountViewModel bankAccount)
        {
            if (id != bankAccount.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await bankAccountBLL.UpdateOrCreate(bankAccount);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/BankAccount/Edit.cshtml", bankAccount);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление банковского счета";

            var bankAccount = await bankAccountBLL.Get(id);
            if (bankAccount.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/BankAccount/Delete.cshtml", bankAccount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, BankAccountViewModel bankAccount)
        {
            if (id != bankAccount.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await bankAccountBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/BankAccount/Delete.cshtml", bankAccount);
        }

        public async Task<JsonResult> GetBankAccounts(string searchStr)
        {
            var bankAccountsList = new List<Dictionary<string, string>>();
            var allBankAccounts = await bankAccountBLL.Find(searchStr);

            foreach (var item in allBankAccounts)
            {
                var bankAccountItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.IIK }
                };

                bankAccountsList.Add(bankAccountItem);
            }

            return Json(bankAccountsList);
        }
    }
}
