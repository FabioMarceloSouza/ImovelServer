using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entrevistaServer.Dtos.ImovelDtos;
using entrevistaServer.Models;
using entrevistaServer.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace entrevistaServer.Controllers
{
    [ApiController]
    [Route("api/v1/imoveis")]
    public class ImovelController : ControllerBase
    {
        private readonly IImovelRepository _imovelRepository;

        public ImovelController(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ImovelRequest request)
        {
            try
            {
                var imovel = await _imovelRepository.CreateImovel(request);
                return StatusCode(201, imovel);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes  = await _imovelRepository.GetAllImovels();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var cliente = await _imovelRepository.GetImovel(id);
                return Ok(cliente);
            }
            catch (System.Exception ex)
            {
                
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Imovel request)
        {
             try
            {
                var cliente  = await _imovelRepository.UpdateImovel(request);
                return Ok(cliente);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
               await _imovelRepository.DeleteImovel(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                
                return NotFound(ex.Message);
            }
        }
    }
}