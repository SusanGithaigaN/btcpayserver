using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace BTCPayServer.Hosting;

public class SetCultureMiddleware(RequestDelegate next)
{

    public async Task Invoke(HttpContext httpContext)
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

        var cultureCookie = httpContext.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
        if (cultureCookie != null)
        {
            var providerResult = CookieRequestCultureProvider.ParseCookieValue(cultureCookie);
            if (providerResult != null)
            {
                CultureInfo.CurrentUICulture = new CultureInfo(providerResult.UICultures[0].Value);
            }
        }

        await next(httpContext);
    }
}
