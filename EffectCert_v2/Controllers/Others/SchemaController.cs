using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Others;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EffectCert.Controllers.Others
{
    public class SchemaController : Controller
    {
        private readonly ISchemaBLL schemaBLL;

        public SchemaController(ISchemaBLL schemaBLL)
        {
            this.schemaBLL = schemaBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Схемы подтверждения соответствия";

            var schemaes = await schemaBLL.FindAll();

            return View("~/Views/Catalogues/Others/Schema/Index.cshtml", schemaes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные схемы";

            var schema = await schemaBLL.Get(id);
            if (schema.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/Schema/Details.cshtml", schema);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание схемы";

            return View("~/Views/Catalogues/Others/Schema/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SchemaViewModel schema)
        {
            if (ModelState.IsValid)
            {
                if (schema.CertObjectIds != null)
                    foreach (var certObject in schema.CertObjectIds)
                        schema.CertObjects.Add(new CertObjectViewModel() { Id = certObject });

                await schemaBLL.UpdateOrCreate(schema);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Others/Schema/Create.cshtml", schema);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в схему";

            var schema = await schemaBLL.Get(id);
            if (schema.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/Schema/Edit.cshtml", schema);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SchemaViewModel schema)
        {
            if (id != schema.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                if (schema.CertObjectIds != null)
                    foreach (var certObject in schema.CertObjectIds)
                        schema.CertObjects.Add(new CertObjectViewModel() { Id = certObject });

                await schemaBLL.UpdateOrCreate(schema);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/Schema/Edit.cshtml", schema);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление схемы";

            var schema = await schemaBLL.Get(id);
            if (schema.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Others/Schema/Delete.cshtml", schema);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, SchemaViewModel schema)
        {
            if (id != schema.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await schemaBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Others/Schema/Delete.cshtml", schema);
        }

        public async Task<JsonResult> GetSchemas(string searchStr)
        {
            var schemasList = new List<Dictionary<string, string>>();
            var allSchemas = await schemaBLL.Find(searchStr);

            foreach (var item in allSchemas)
            {
                var schemaItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Name },
                    { "info", GenerateItemsStr(item.CertObjects) }
                };

                schemasList.Add(schemaItem);
            }

            return Json(schemasList);
        }

        private string GenerateItemsStr(ICollection<CertObjectViewModel> certObjects)
        {
            var sb = new StringBuilder();

            foreach (var certObject in certObjects)
                sb.AppendFormat("{0};", certObject.Name);

            return sb.ToString();
        }
    }
}
