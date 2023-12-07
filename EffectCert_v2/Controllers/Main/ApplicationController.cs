using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Main;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Main
{
    public class ApplicationController : Controller
    {
        private readonly IApplicationBLL applicationBLL;

        public ApplicationController(IApplicationBLL applicationBLL)
        {
            this.applicationBLL = applicationBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Заявки";

            var applicationes = await applicationBLL.FindAll();

            return View("~/Views/Catalogues/Main/Application/Index.cshtml", applicationes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные заявки";

            var application = await applicationBLL.Get(id);
            if (application.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/Application/Details.cshtml", application);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание заявки";

            return View("~/Views/Catalogues/Main/Application/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationViewModel application)
        {
            if (ModelState.IsValid)
            {
                await applicationBLL.UpdateOrCreate(application);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Main/Application/Create.cshtml", application);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в заявку";

            var application = await applicationBLL.Get(id);
            if (application.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/Application/Edit.cshtml", application);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApplicationViewModel application)
        {
            if (id != application.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await applicationBLL.UpdateOrCreate(application);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Main/Application/Edit.cshtml", application);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление заявки";

            var application = await applicationBLL.Get(id);
            if (application.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/Application/Delete.cshtml", application);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ApplicationViewModel application)
        {
            if (id != application.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await applicationBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Main/Application/Delete.cshtml", application);
        }

        public async Task<JsonResult> GetApplications(string searchStr)
        {
            var applicationsList = new List<Dictionary<string, string>>();
            var allApplications = await applicationBLL.Find(searchStr);

            foreach (var item in allApplications)
            {
                var applicationItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number }
                };

                applicationsList.Add(applicationItem);
            }

            return Json(applicationsList);
        }
    }
}
