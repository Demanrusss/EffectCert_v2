using EffectCert.BLL.Documents;
using EffectCert.ViewModels.Documents;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.TestProtocolors
{
    public class TestProtocolController : Controller
    {
        private readonly TestProtocolBLL testProtocolBLL;

        public TestProtocolController(TestProtocolBLL testProtocolBLL)
        {
            this.testProtocolBLL = testProtocolBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Технические регламенты";

            var testProtocoles = await testProtocolBLL.FindAll();

            return View("~/Views/Catalogues/Documents/TestProtocol/Index.cshtml", testProtocoles);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные Технического регламента";

            var testProtocol = await testProtocolBLL.Get(id);
            if (testProtocol.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/TestProtocol/Details.cshtml", testProtocol);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание Технического регламента";

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
            ViewData["Title"] = "Внесение изменений в Технический регламент";

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
            ViewData["Title"] = "Удаление Технического регламента";

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
