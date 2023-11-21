using EffectCert.BLL.Documents;
using EffectCert.ViewModels.Documents;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Documents
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceBLL invoiceBLL;

        public InvoiceController(InvoiceBLL invoiceBLL)
        {
            this.invoiceBLL = invoiceBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Инвойсы";

            var invoicees = await invoiceBLL.FindAll();

            return View("~/Views/Catalogues/Documents/Invoice/Index.cshtml", invoicees);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные инвойса";

            var invoice = await invoiceBLL.Get(id);
            if (invoice.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/Invoice/Details.cshtml", invoice);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание инвойса";

            return View("~/Views/Catalogues/Documents/Invoice/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceViewModel invoice)
        {
            if (ModelState.IsValid)
            {
                await invoiceBLL.UpdateOrCreate(invoice);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Documents/Invoice/Create.cshtml", invoice);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в инвойсе";

            var invoice = await invoiceBLL.Get(id);
            if (invoice.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/Invoice/Edit.cshtml", invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InvoiceViewModel invoice)
        {
            if (id != invoice.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await invoiceBLL.UpdateOrCreate(invoice);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/Invoice/Edit.cshtml", invoice);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление инвойса";

            var invoice = await invoiceBLL.Get(id);
            if (invoice.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Documents/Invoice/Delete.cshtml", invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, InvoiceViewModel invoice)
        {
            if (id != invoice.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await invoiceBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Documents/Invoice/Delete.cshtml", invoice);
        }

        public async Task<JsonResult> GetInvoices(string searchStr)
        {
            var invoicesList = new List<Dictionary<string, string>>();
            var allInvoices = await invoiceBLL.Find(searchStr);

            foreach (var item in allInvoices)
            {
                var invoiceItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number }
                };

                invoicesList.Add(invoiceItem);
            }

            return Json(invoicesList);
        }
    }
}
