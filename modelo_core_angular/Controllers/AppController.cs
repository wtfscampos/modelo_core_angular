using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.WsFederation;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Diagnostics;
using System.Net.Http;


namespace modelo_core_angular.Controllers
{
    [Authorize]
    public class AppController : ControllerBase
    {

        private readonly ILogger<AppController> Logger;

        private IConfiguration Configuration;

        public AppController(IConfiguration pConfiguration, ILogger<AppController> pLogger)
        {
            Configuration = pConfiguration;
            Logger = pLogger;
        }

        [HttpGet]
        [Authorize]
        public async Task Sair()
        {
           await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

           await this.HttpContext.SignOutAsync(WsFederationDefaults.AuthenticationScheme, 
                 new AuthenticationProperties{
                    RedirectUri="/"
                 });
        }

        [Route("/erro")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Erro()
        {
            ProblemDetails problemDetail = new ProblemDetails();
            problemDetail.Status=HttpContext.Response.StatusCode;
            problemDetail.Title = "Erro no processamento da requisição";

            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (exceptionHandler!=null){
                var exception = exceptionHandler.Error;
                problemDetail.Detail = exception.StackTrace;

                if (exceptionHandler.Error is HttpRequestException httpException){
                    problemDetail.Title = httpException.Message;
                    if (httpException.InnerException !=null){
                      problemDetail.Title = problemDetail.Title +"\n" + httpException.InnerException.Message;
                    }
               }
            }

            return new JsonResult(new {
                statusCode=problemDetail.Status.Value,
                message=problemDetail.Title,
                detail=problemDetail.Detail,
            });
        }

     }
}
