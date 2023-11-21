using EffectCert.BLL.Documents;
using EffectCert.ViewModels.Documents;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Documents
{
    public class CertificateController : Controller
    {
        private readonly CertificateBLL certificateBLL;

        public CertificateController(CertificateBLL certificateBLL)
        {
            this.certificateBLL = certificateBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Сертификаты";

            var certificatees = await certificateBLL.FindAll();

            return View("~/Views/Catalogues/Documents/Certificate/Index.cshtml", certificatees);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные сертификата";

            var certificate = await certificateBLL.Get(id);
            if (certificate.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/Certificate/Details.cshtml", certificate);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание сертификата";

            return View("~/Views/Catalogues/Documents/Certificate/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CertificateViewModel certificate)
        {
            if (ModelState.IsValid)
            {
                await certificateBLL.UpdateOrCreate(certificate);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Documents/Certificate/Create.cshtml", certificate);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в сертификат";

            var certificate = await certificateBLL.Get(id);
            if (certificate.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/Certificate/Edit.cshtml", certificate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CertificateViewModel certificate)
        {
            if (id != certificate.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await certificateBLL.UpdateOrCreate(certificate);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/Certificate/Edit.cshtml", certificate);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление сертификата";

            var certificate = await certificateBLL.Get(id);
            if (certificate.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/Certificate/Delete.cshtml", certificate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CertificateViewModel certificate)
        {
            if (id != certificate.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await certificateBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/Certificate/Delete.cshtml", certificate);
        }

        public async Task<JsonResult> GetCertificates(string searchStr)
        {
            var certificatesList = new List<Dictionary<string, string>>();
            var allCertificates = await certificateBLL.Find(searchStr);

            foreach (var item in allCertificates)
            {
                var certificateItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number }
                };

                certificatesList.Add(certificateItem);
            }

            return Json(certificatesList);
        }
    }
}
