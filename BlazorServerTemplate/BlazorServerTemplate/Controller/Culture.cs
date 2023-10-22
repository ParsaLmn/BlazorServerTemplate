using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerTemplate.Controller
{
    [Route("/[controller]")]
    [ApiController]
    public class Culture : ControllerBase
    {
        public ActionResult SetCulture()
        {
            IRequestCultureFeature culture = HttpContext.Features.Get<IRequestCultureFeature>();
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(new string[] { "en-US", "fa-IR" }
                    .Where(s => s != culture.RequestCulture.Culture.Name)
                    .FirstOrDefault())));

            return Redirect("/");
        }
    }
}
