using Microsoft.AspNetCore.Mvc;

namespace GeziRehberim.PresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutFooterPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
