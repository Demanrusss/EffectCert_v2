using EffectCert.BLL.Contractors;
using EffectCert.ViewModels.Contractors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EffectCert.Controllers.Contractors
{
    public class AddressController : Controller
    {
        private readonly AddressBLL addressBLL;

        public AddressController(AddressBLL addressBLL)
        {
            this.addressBLL = addressBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Адреса";

            var addresses = await addressBLL.FindAll();

            return View("~/Views/Catalogues/Contractors/Address/Index.cshtml", addresses);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные адреса";

            var address = await addressBLL.Get(id);
            if (address.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/Address/Details.cshtml", address);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание адреса";

            return View("~/Views/Catalogues/Contractors/Address/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddressViewModel address)
        {
            if (ModelState.IsValid)
            {
                await addressBLL.UpdateOrCreate(address);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Contractors/Address/Create.cshtml", address);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в адрес";

            var address = await addressBLL.Get(id);
            if (address.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/Address/Edit.cshtml", address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AddressViewModel address)
        {
            if (id != address.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await addressBLL.UpdateOrCreate(address);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/Address/Edit.cshtml", address);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление адреса";

            var address = await addressBLL.Get(id);
            if (address.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/Address/Delete.cshtml", address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AddressViewModel address)
        {
            if (id != address.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await addressBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/Address/Delete.cshtml", address);
        }

        public async Task<JsonResult> GetAddresses(string searchStr)
        {
            var addressesList = new List<Dictionary<string, string>>();
            var allAddresses = await addressBLL.Find(searchStr);

            foreach (var item in allAddresses)
            {
                var addressItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.AddressLine ?? item.Country }
                };

                addressesList.Add(addressItem);
            }

            return Json(addressesList);
        }
    }
}
