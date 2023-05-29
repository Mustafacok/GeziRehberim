using Microsoft.AspNetCore.Mvc;

namespace GeziRehberim.PresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutNavbarPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
