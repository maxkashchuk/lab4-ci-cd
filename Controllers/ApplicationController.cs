using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab_4.Services;
using lab_4.Models.ModelsController;

namespace lab_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IShipService _shipService;
        public ApplicationController(IShipService shipService) 
        {
            _shipService = shipService;
        }

        [HttpPost("ship_create")]
        public async Task<IActionResult> ShipCreate(ShipController ship)
        {
            await _shipService.CreateShip(ship);
            return Ok();
        }

        [HttpPost("container_create")]
        public async Task<IActionResult> ContainerCreate(ContainerController container)
        {
            await _shipService.CreateContainer(container);
            return Ok();
        }

        [HttpPost("port_create")]
        public async Task<IActionResult> PortCreate(PortController port)
        {
            await _shipService.CreatePort(port);
            return Ok();
        }

        [HttpGet("incoming")]
        public async Task<IActionResult> IncomingShip(int ship_id, int port_id)
        {
            await _shipService.IncomingShip(ship_id, port_id);
            return Ok();
        }

        [HttpGet("outgoing")]
        public async Task<IActionResult> OutgoingShip(int ship_id, int port_id)
        {
            await _shipService.OutgoingShip(ship_id, port_id);
            return Ok();
        }

        [HttpGet("distance")]
        public async Task<IActionResult> Distance(int port_one_id, int port_two_id)
        {
            return Ok(await _shipService.GetDistance(port_one_id, port_two_id));
        }
    }
}
