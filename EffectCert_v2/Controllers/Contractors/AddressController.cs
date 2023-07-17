using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewModels.Contractors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Contractors
{
    public class AddressController : Controller
    {
        private readonly AddressBLL addressBLL;

        public AddressController(AddressBLL addressBLL)
        {
            this.addressBLL = addressBLL;
        }

        // GET: AddressController
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Адреса";

            var allAddresses = await addressBLL.FindAll();

            return View(allAddresses);
        }

        // GET: AddressController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные адреса";

            var address = await addressBLL.Get(id);
            if (address.Id == 0)
                return NotFound();

            return View(address);
        }

        // GET: AddressController/Create
        public IActionResult Create()
        {
            ViewData["Title"] = "Создание адреса";

            return View();
        }

        // POST: AddressController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddressViewModel addressViewModel)
        {
            if (ModelState.IsValid)
            {
                Address address = AddressMapper.MapAddressViewModelToAddress(addressViewModel);
                await addressBLL.UpdateOrCreate(address);
                return RedirectToAction(nameof(Index));
            }
            
            return View(addressViewModel);
        }

        // GET: AddressController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в адрес";

            Address address = await addressBLL.Get(id);
            if (address.Id == 0)
                return NotFound();

            AddressViewModel addressViewModel = AddressMapper.MapAddressToAddressViewModel(address);
            return View(addressViewModel);
        }

        // POST: AddressController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AddressViewModel addressViewModel)
        {
            if (id != addressViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                Address address = AddressMapper.MapAddressViewModelToAddress(addressViewModel);
                await addressBLL.UpdateOrCreate(address);
                return RedirectToAction(nameof(Index));
            }

            return View(addressViewModel);
        }

        // GET: AddressController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление адреса";

            Address address = await addressBLL.Get(id);
            if (address.Id == 0)
                return NotFound();

            AddressViewModel addressViewModel = AddressMapper.MapAddressToAddressViewModel(address);
            return View(addressViewModel);
        }

        // POST: AddressController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AddressViewModel addressViewModel)
        {
            if (id != addressViewModel.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                Address address = AddressMapper.MapAddressViewModelToAddress(addressViewModel);
                await addressBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View(addressViewModel);
        }
    }
}
