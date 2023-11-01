using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewModels.Contractors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Contractors
{
    public class AssessBodyController : Controller
    {
        private readonly AssessBodyBLL assessBodyBLL;

        public AssessBodyController(AssessBodyBLL assessBodyBLL)
        {
            this.assessBodyBLL = assessBodyBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Органы подтверждения соответствия";

            var assessBodies = await assessBodyBLL.FindAll();

            return View("~/Views/Catalogues/Contractors/AssessBody/Index.cshtml", assessBodies);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные ОПС";

            var assessBody = await assessBodyBLL.Get(id);
            if (assessBody.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/AssessBody/Details.cshtml", assessBody);
        }

        // GET: AssessBodyController/Create
        public IActionResult Create()
        {
            ViewData["Title"] = "Создание ОПС";

            return View("~/Views/Catalogues/Contractors/AssessBody/Create.cshtml");
        }

        // POST: AssessBodyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssessBodyViewModel assessBody)
        {
            if (ModelState.IsValid)
            {
                await assessBodyBLL.UpdateOrCreate(assessBody);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Contractors/AssessBody/Create.cshtml", assessBody);
        }

        // GET: AssessBodyController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в данные ОПС";

            var assessBody = await assessBodyBLL.Get(id);
            if (assessBody.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/AssessBody/Edit.cshtml", assessBody);
        }

        // POST: AssessBodyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AssessBodyViewModel assessBody)
        {
            if (id != assessBody.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await assessBodyBLL.UpdateOrCreate(assessBody);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/AssessBody/Edit.cshtml", assessBody);
        }

        // GET: AssessBodyController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление ОПС";

            var assessBody = await assessBodyBLL.Get(id);
            if (assessBody.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Contractors/AssessBody/Delete.cshtml", assessBody);
        }

        // POST: AssessBodyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AssessBodyViewModel assessBody)
        {
            if (id != assessBody.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await assessBodyBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Contractors/AssessBody/Delete.cshtml", assessBody);
        }
    }
}
