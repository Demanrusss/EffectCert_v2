using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Others;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Others
{
    public class CertObjectController : Controller
    {
        private readonly ICertObjectBLL certObjectBLL;

        public CertObjectController(ICertObjectBLL certObjectBLL)
        {
            this.certObjectBLL = certObjectBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Объекты подтверждения соответствия";

            var certObjectes = await certObjectBLL.FindAll();

            return View("~/Views/Catalogues/Others/CertObject/Index.cshtml", certObjectes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные объекта подтверждения соответствия";

            var certObject = await certObjectBLL.Get(id);
            if (certObject.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/CertObject/Details.cshtml", certObject);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание объекта подтверждения соответствия";

            return View("~/Views/Catalogues/Others/CertObject/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CertObjectViewModel certObject)
        {
            if (ModelState.IsValid)
            {
                await certObjectBLL.UpdateOrCreate(certObject);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Others/CertObject/Create.cshtml", certObject);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в объект подтверждения соответствия";

            var certObject = await certObjectBLL.Get(id);
            if (certObject.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/CertObject/Edit.cshtml", certObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CertObjectViewModel certObject)
        {
            if (id != certObject.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await certObjectBLL.UpdateOrCreate(certObject);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/CertObject/Edit.cshtml", certObject);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление объекта подтверждения соответствия";

            var certObject = await certObjectBLL.Get(id);
            if (certObject.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/CertObject/Delete.cshtml", certObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CertObjectViewModel certObject)
        {
            if (id != certObject.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await certObjectBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/CertObject/Delete.cshtml", certObject);
        }

        public async Task<JsonResult> GetCertObjects(string searchStr)
        {
            var certObjectsList = new List<Dictionary<string, string>>();
            var allCertObjects = await certObjectBLL.Find(searchStr);

            foreach (var item in allCertObjects)
            {
                var certObjectItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Name }
                };

                certObjectsList.Add(certObjectItem);
            }

            return Json(certObjectsList);
        }
    }
}
