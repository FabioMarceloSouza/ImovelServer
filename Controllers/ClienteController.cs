using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entrevistaServer.Dtos.ClienteDtos;
using entrevistaServer.Models;
using entrevistaServer.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace entrevistaServer.Controllers
{
    [ApiController]
    [Route("api/v1/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteRequest request)
        {
            try
            {
                var cliente  = await _clienteRepository.CreateCliente(request);

                return StatusCode(201, cliente);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(new {
                    error = true,
                    message = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteRepository.GetAllClientes();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetCliente(id);

                return Ok(cliente);
            }
            catch (System.Exception ex)
            {
                
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Cliente request)
        {
            try
            {
                var cliente  = await _clienteRepository.UpdateCliente(request);
                return Ok(cliente);
            }
            catch (System.Exception ex)
            {
                
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _clienteRepository.DeleteCliente(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                
                return NotFound(ex.Message);
            }
        }
    }
}