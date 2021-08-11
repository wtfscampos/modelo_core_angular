using Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace modelo_core_angular.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfiguracaoController : ControllerBase
    {
        private IConfiguration _configuration;
        public Usuario _usuario { get; private set; }

        public ConfiguracaoController(IConfiguration configuration, Usuario usuario)
        {
            _configuration = configuration;
            _usuario = usuario;
        }

        [HttpGet("{parametro}")]
        public ActionResult Configuracao(string parametro)
        {
            var configuracao = new { valor = _configuration[parametro] };
            return new JsonResult(configuracao);
        }

        [HttpGet()]
        [Produces("application/json")]
        public ActionResult appSettings()
        {
            return new JsonResult(JsonSerializer.Deserialize<object>(System.IO.File.ReadAllText("./appsettings.json")));
        }

        [HttpGet("usuario")]
        [Produces("application/json")]
        public ActionResult usuario()
        {
            return new JsonResult(JsonSerializer.Deserialize<object>(JsonSerializer.Serialize(_usuario)));
        }
    }
}
