using EffectCert.BLL.Interfaces;
using EffectCert.ViewModels.Main;
using Microsoft.AspNetCore.Mvc;

namespace EffectCert.Controllers.Main
{
    public class RecommendationController : Controller
    {
        private readonly IRecommendationBLL recommendationBLL;

        public RecommendationController(IRecommendationBLL recommendationBLL)
        {
            this.recommendationBLL = recommendationBLL;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Рекомендации";

            var recommendationes = await recommendationBLL.FindAll();

            return View("~/Views/Catalogues/Main/Recommendation/Index.cshtml", recommendationes);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Полные данные рекомендации";

            var recommendation = await recommendationBLL.Get(id);
            if (recommendation.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/Recommendation/Details.cshtml", recommendation);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание рекомендации";

            return View("~/Views/Catalogues/Main/Recommendation/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecommendationViewModel recommendation)
        {
            if (ModelState.IsValid)
            {
                await recommendationBLL.UpdateOrCreate(recommendation);
                return RedirectToAction(nameof(Index));
            }
            
            return View("~/Views/Catalogues/Main/Recommendation/Create.cshtml", recommendation);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Внесение изменений в рекомендацию";

            var recommendation = await recommendationBLL.Get(id);
            if (recommendation.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/Recommendation/Edit.cshtml", recommendation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RecommendationViewModel recommendation)
        {
            if (id != recommendation.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await recommendationBLL.UpdateOrCreate(recommendation);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Main/Recommendation/Edit.cshtml", recommendation);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Удаление рекомендации";

            var recommendation = await recommendationBLL.Get(id);
            if (recommendation.Id == 0)
                return NotFound();

            return View("~/Views/Catalogues/Main/Recommendation/Delete.cshtml", recommendation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, RecommendationViewModel recommendation)
        {
            if (id != recommendation.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                await recommendationBLL.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Catalogues/Main/Recommendation/Delete.cshtml", recommendation);
        }

        public async Task<JsonResult> GetRecommendations(string searchStr)
        {
            var recommendationsList = new List<Dictionary<string, string>>();
            var allRecommendations = await recommendationBLL.Find(searchStr);

            foreach (var item in allRecommendations)
            {
                var recommendationItem = new Dictionary<string, string>
                {
                    { "id", item.Id.ToString() },
                    { "name", item.Number ?? item.Application?.Number ?? String.Empty }
                };

                recommendationsList.Add(recommendationItem);
            }

            return Json(recommendationsList);
        }
    }
}
