using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Others;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Others
{
    public class MeasurementUnitController : Controller
    {
        private readonly IMeasurementUnitBLL measurementUnitBLL;

        public MeasurementUnitController(IMeasurementUnitBLL measurementUnitBLL)
        {
            this.measurementUnitBLL = measurementUnitBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Единицы измерения";

            var measurementUnites = await measurementUnitBLL.FindAll();

            return View("~/Views/Catalogues/Others/MeasurementUnit/Index.cshtml", measurementUnites);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные единицы измерения";

            var measurementUnit = await measurementUnitBLL.Get(id);
            if (measurementUnit.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/MeasurementUnit/Details.cshtml", measurementUnit);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание единицы измерения";

            return View("~/Views/Catalogues/Others/MeasurementUnit/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MeasurementUnitViewModel measurementUnit)
        {
            if (ModelState.IsValid)
            {
                await measurementUnitBLL.UpdateOrCreate(measurementUnit);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Others/MeasurementUnit/Create.cshtml", measurementUnit);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в единицу измерения";

            var measurementUnit = await measurementUnitBLL.Get(id);
            if (measurementUnit.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/MeasurementUnit/Edit.cshtml", measurementUnit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MeasurementUnitViewModel measurementUnit)
        {
            if (id != measurementUnit.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await measurementUnitBLL.UpdateOrCreate(measurementUnit);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/MeasurementUnit/Edit.cshtml", measurementUnit);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление единицы измерения";

            var measurementUnit = await measurementUnitBLL.Get(id);
            if (measurementUnit.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/MeasurementUnit/Delete.cshtml", measurementUnit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, MeasurementUnitViewModel measurementUnit)
        {
            if (id != measurementUnit.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await measurementUnitBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/MeasurementUnit/Delete.cshtml", measurementUnit);
        }

        public async Task<JsonResult> GetMeasurementUnits(string searchStr)
        {
            var measurementUnitsList = new List<Dictionary<string, string>>();
            var allMeasurementUnits = await measurementUnitBLL.Find(searchStr);

            foreach (var item in allMeasurementUnits)
            {
                var measurementUnitItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.ShortName }
                };

                measurementUnitsList.Add(measurementUnitItem);
            }

            return Json(measurementUnitsList);
        }
    }
}
