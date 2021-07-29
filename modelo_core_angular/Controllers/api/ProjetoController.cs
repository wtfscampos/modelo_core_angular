using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Security.Authentication;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Text;
using modelo_core_angular.Models;

namespace modelo_core_angular.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetoController : ControllerBase
    {
        protected readonly ILogger<ProjetoController> Logger;

        protected IConfiguration Configuration;

        protected HttpClient httpClient;
        private readonly string apiEndereco;

        public ProjetoController(IConfiguration pConfiguration,
                                 ILogger<ProjetoController> pLogger)
        {
            this.Configuration = pConfiguration;
            this.Logger = pLogger;

            var handler = new HttpClientHandler();
            handler.SslProtocols = SslProtocols.None;

            this.httpClient = new HttpClient(handler);

            this.apiEndereco = this.Configuration["apiendereco:url"];
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IEnumerable<Projeto>> Get()
        {
            var url_api = new Uri(apiEndereco);
            var response = await httpClient.GetAsync(url_api);

            response.EnsureSuccessStatusCode();

            var responseJsonStr = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<IEnumerable<Projeto>>(responseJsonStr);
            return responseObj;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<Projeto> Get(int id)
        {
            var base_url_api = new Uri(apiEndereco);
            var url_api = new Uri(base_url_api, "./" + id);

            var response = await httpClient.GetAsync(url_api);

            response.EnsureSuccessStatusCode();

            var responseJsonStr = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<Projeto>(responseJsonStr);
            return responseObj;
        }

        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<Projeto> Put([FromBody] Projeto projeto)
        {
            var url_api = new Uri(apiEndereco);
            var postDataStr = JsonConvert.SerializeObject(projeto);
            var postDataContent = new StringContent(postDataStr, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url_api, postDataContent);

            response.EnsureSuccessStatusCode();

            var responseJsonStr = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<Projeto>(responseJsonStr);
            return responseObj;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<Projeto> Post([FromBody] Projeto projeto)
        {
            var url_api = new Uri(apiEndereco);
            var postDataStr = JsonConvert.SerializeObject(projeto);
            var postDataContent = new StringContent(postDataStr, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url_api, postDataContent);

            response.EnsureSuccessStatusCode();

            var responseJsonStr = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<Projeto>(responseJsonStr);
            return responseObj;
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<Projeto> Delete(int id)
        {
            var base_url_api = new Uri(apiEndereco);
            var url_api = new Uri(base_url_api, "./" + id);

            var response = await httpClient.DeleteAsync(url_api);

            response.EnsureSuccessStatusCode();

            var responseJsonStr = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<Projeto>(responseJsonStr);
            return responseObj;
        }

        [HttpGet("status")]
        [Produces("application/json")]
        public async Task<string> Status(string status)
        {
            var url_api = new Uri(apiEndereco + "/status");
            var response = await httpClient.GetAsync(url_api);
            response.EnsureSuccessStatusCode();
            var responseStr = await response.Content.ReadAsStringAsync();
            return responseStr;
        }

        [HttpGet("conexao")]
        [Produces("application/json")]
        public async Task<string> Conexao(string status)
        {
            var url_api = new Uri(apiEndereco + "/conexao");
            var response = await httpClient.GetAsync(url_api);
            response.EnsureSuccessStatusCode();
            var responseStr = await response.Content.ReadAsStringAsync();
            return responseStr;
        }
    }
}