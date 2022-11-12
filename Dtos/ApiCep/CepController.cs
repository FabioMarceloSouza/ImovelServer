using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace entrevistaServer.Dtos.ApiCep
{
    [ApiController]
    [Route("api/v1/cep")]
    public class CepController : ControllerBase
    {
        
        [HttpGet("{cep}")]
        public async Task<IActionResult> GetCep([FromRoute] string cep)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
               var response  = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json"); 
               var jsonString = await response.Content.ReadAsStringAsync();
            
               CepModelApi cepResponse = JsonConvert.DeserializeObject<CepModelApi>(jsonString);

               return Ok(cepResponse);
            }
            catch (System.Exception)
            {
                
                return NotFound(new { erro = true });
            }
        }
    }


    class CepModelApi {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }
    }

}