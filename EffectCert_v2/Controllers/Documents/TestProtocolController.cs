using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Documents;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Documents
{
    public class TestProtocolController : Controller
    {
        private readonly ITestProtocolBLL testProtocolBLL;

        public TestProtocolController(ITestProtocolBLL testProtocolBLL)
        {
            this.testProtocolBLL = testProtocolBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Протоколы испытаний";

            var testProtocols = await testProtocolBLL.FindAll();

            return View("~/Views/Catalogues/Documents/TestProtocol/Index.cshtml", testProtocols);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные протокола испытаний";

            var testProtocol = await testProtocolBLL.Get(id);
            if (testProtocol.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/TestProtocol/Details.cshtml", testProtocol);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание протокола испытаний";

            return View("~/Views/Catalogues/Documents/TestProtocol/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestProtocolViewModel testProtocol)
        {
            if (ModelState.IsValid)
            {
                await testProtocolBLL.UpdateOrCreate(testProtocol);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Documents/TestProtocol/Create.cshtml", testProtocol);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в протокол испытаний";

            var testProtocol = await testProtocolBLL.Get(id);
            if (testProtocol.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/TestProtocol/Edit.cshtml", testProtocol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TestProtocolViewModel testProtocol)
        {
            if (id != testProtocol.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await testProtocolBLL.UpdateOrCreate(testProtocol);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/TestProtocol/Edit.cshtml", testProtocol);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление протокола испытаний";

            var testProtocol = await testProtocolBLL.Get(id);
            if (testProtocol.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/TestProtocol/Delete.cshtml", testProtocol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, TestProtocolViewModel testProtocol)
        {
            if (id != testProtocol.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await testProtocolBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/TestProtocol/Delete.cshtml", testProtocol);
        }

        public async Task<JsonResult> GetTestProtocols(string searchStr)
        {
            var testProtocolsList = new List<Dictionary<string, string>>();
            var allTestProtocols = await testProtocolBLL.Find(searchStr);

            foreach (var item in allTestProtocols)
            {
                var testProtocolItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number }
                };

                testProtocolsList.Add(testProtocolItem);
            }

            return Json(testProtocolsList);
        }
    }
}
