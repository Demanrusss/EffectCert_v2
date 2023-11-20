using EffectCert.BLL.Documents;
using EffectCert.ViewModels.Documents;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Declarationors
{
    public class DeclarationController : Controller
    {
        private readonly DeclarationBLL declarationBLL;

        public DeclarationController(DeclarationBLL declarationBLL)
        {
            this.declarationBLL = declarationBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Декларации";

            var declarationes = await declarationBLL.FindAll();

            return View("~/Views/Catalogues/Documents/Declaration/Index.cshtml", declarationes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные декларации";

            var declaration = await declarationBLL.Get(id);
            if (declaration.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/Declaration/Details.cshtml", declaration);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание декларации";

            return View("~/Views/Catalogues/Documents/Declaration/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeclarationViewModel declaration)
        {
            if (ModelState.IsValid)
            {
                await declarationBLL.UpdateOrCreate(declaration);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Documents/Declaration/Create.cshtml", declaration);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в декларацию";

            var declaration = await declarationBLL.Get(id);
            if (declaration.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/Declaration/Edit.cshtml", declaration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DeclarationViewModel declaration)
        {
            if (id != declaration.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await declarationBLL.UpdateOrCreate(declaration);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/Declaration/Edit.cshtml", declaration);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление декларации";

            var declaration = await declarationBLL.Get(id);
            if (declaration.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/Declaration/Delete.cshtml", declaration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, DeclarationViewModel declaration)
        {
            if (id != declaration.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await declarationBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/Declaration/Delete.cshtml", declaration);
        }

        public async Task<JsonResult> GetDeclarations(string searchStr)
        {
            var declarationsList = new List<Dictionary<string, string>>();
            var allDeclarations = await declarationBLL.Find(searchStr);

            foreach (var item in allDeclarations)
            {
                var declarationItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number }
                };

                declarationsList.Add(declarationItem);
            }

            return Json(declarationsList);
        }
    }
}
