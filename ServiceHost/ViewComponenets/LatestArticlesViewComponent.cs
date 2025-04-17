using _01_LampshadeQuery.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponenets
{
    public class LatestArticlesViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly IArticleQuery _articleQuery;

        public LatestArticlesViewComponent(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public IViewComponentResult Invoke()
        {
            var articles = _articleQuery.LatestArticles();
            return View(articles);
        }
    }
}
