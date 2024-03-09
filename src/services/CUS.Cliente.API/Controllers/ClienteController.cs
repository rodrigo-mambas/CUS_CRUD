using Microsoft.AspNetCore.Mvc;
using MediatR;
using CUS.Cliente.API.Context;
using CUS.Cliente.API.Recursos.Queries;
using CUS.Cliente.API.Recursos.Commands;

namespace CUS.Cliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ClienteController(AppDbContext context, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CUS.Cliente.API.Models.Cliente>>> GetClientes()
        {
            try
            {
                var command = new GetTodosClientesQuery();
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CUS.Cliente.API.Models.Cliente>> GetClientes(int id)
        {
            try
            {
                var command = new GetClientePorIdQuery { Id = id };
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CUS.Cliente.API.Models.Cliente>> PostCliente([FromBody] ClienteCreateCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CUS.Cliente.API.Models.Cliente>> DeleteCliente(int id)
        {
            try
            {
                var command = new ClienteDeleteCommand { Id = id };
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CUS.Cliente.API.Models.Cliente>> PutCliente([FromBody] ClienteUpdateCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
