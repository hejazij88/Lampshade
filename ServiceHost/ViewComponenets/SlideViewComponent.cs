using _01_LampshadeQuery.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponenets;

public class SlideViewComponent : ViewComponent
{
    private readonly ISlideQuery _slideQuery;

    public SlideViewComponent(ISlideQuery slideQuery)
    {
        _slideQuery = slideQuery;
    }

    public IViewComponentResult Invoke()
    {
        var slides = _slideQuery.GetSlides();
        return View(slides);


    }
}