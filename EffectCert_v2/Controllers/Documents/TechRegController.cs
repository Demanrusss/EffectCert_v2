using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Documents;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Documents
{
    public class TechRegController : Controller
    {
        private readonly ITechRegBLL techRegBLL;

        public TechRegController(ITechRegBLL techRegBLL)
        {
            this.techRegBLL = techRegBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Технические регламенты";

            var techReges = await techRegBLL.FindAll();

            return View("~/Views/Catalogues/Documents/TechReg/Index.cshtml", techReges);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные Технического регламента";

            var techReg = await techRegBLL.Get(id);
            if (techReg.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/TechReg/Details.cshtml", techReg);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание Технического регламента";

            return View("~/Views/Catalogues/Documents/TechReg/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TechRegViewModel techReg)
        {
            if (ModelState.IsValid)
            {
                await techRegBLL.UpdateOrCreate(techReg);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Documents/TechReg/Create.cshtml", techReg);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в Технический регламент";

            var techReg = await techRegBLL.Get(id);
            if (techReg.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/TechReg/Edit.cshtml", techReg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TechRegViewModel techReg)
        {
            if (id != techReg.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await techRegBLL.UpdateOrCreate(techReg);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/TechReg/Edit.cshtml", techReg);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление Технического регламента";

            var techReg = await techRegBLL.Get(id);
            if (techReg.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/TechReg/Delete.cshtml", techReg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, TechRegViewModel techReg)
        {
            if (id != techReg.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await techRegBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/TechReg/Delete.cshtml", techReg);
        }

        public async Task<JsonResult> GetTechRegs(string searchStr)
        {
            var techRegsList = new List<Dictionary<string, string>>();
            var allTechRegs = await techRegBLL.Find(searchStr);

            foreach (var item in allTechRegs)
            {
                var techRegItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.ShortName }
                };

                techRegsList.Add(techRegItem);
            }

            return Json(techRegsList);
        }
    }
}
