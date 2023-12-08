using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Main;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Main
{
    public class SelectProductsActController : Controller
    {
        private readonly ISelectProductsActBLL selectProductsActBLL;

        public SelectProductsActController(ISelectProductsActBLL selectProductsActBLL)
        {
            this.selectProductsActBLL = selectProductsActBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Акты отбора образцов";

            var selectProductsActes = await selectProductsActBLL.FindAll();

            return View("~/Views/Catalogues/Main/SelectProductsAct/Index.cshtml", selectProductsActes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные акта отбора образцов";

            var selectProductsAct = await selectProductsActBLL.Get(id);
            if (selectProductsAct.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/SelectProductsAct/Details.cshtml", selectProductsAct);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание акта отбора образцов";

            return View("~/Views/Catalogues/Main/SelectProductsAct/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SelectProductsActViewModel selectProductsAct)
        {
            if (ModelState.IsValid)
            {
                await selectProductsActBLL.UpdateOrCreate(selectProductsAct);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Main/SelectProductsAct/Create.cshtml", selectProductsAct);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в акт отбора образцов";

            var selectProductsAct = await selectProductsActBLL.Get(id);
            if (selectProductsAct.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/SelectProductsAct/Edit.cshtml", selectProductsAct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SelectProductsActViewModel selectProductsAct)
        {
            if (id != selectProductsAct.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await selectProductsActBLL.UpdateOrCreate(selectProductsAct);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Main/SelectProductsAct/Edit.cshtml", selectProductsAct);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление акта отбора образцов";

            var selectProductsAct = await selectProductsActBLL.Get(id);
            if (selectProductsAct.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/SelectProductsAct/Delete.cshtml", selectProductsAct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, SelectProductsActViewModel selectProductsAct)
        {
            if (id != selectProductsAct.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await selectProductsActBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Main/SelectProductsAct/Delete.cshtml", selectProductsAct);
        }

        public async Task<JsonResult> GetSelectProductsActs(string searchStr)
        {
            var selectProductsActsList = new List<Dictionary<string, string>>();
            var allSelectProductsActs = await selectProductsActBLL.Find(searchStr);

            foreach (var item in allSelectProductsActs)
            {
                var selectProductsActItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number ?? item.Application?.Number ?? String.Empty }
                };

                selectProductsActsList.Add(selectProductsActItem);
            }

            return Json(selectProductsActsList);
        }
    }
}
