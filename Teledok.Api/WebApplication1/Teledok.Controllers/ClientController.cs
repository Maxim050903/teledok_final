using Microsoft.AspNetCore.Mvc;
using teledok.Class_Library.Core.Entiuties;
using teledok.Teledoc.Application.Services;
using teledok.Teledok.Controllers.Contracts;
using teledok.Teledok.Controllers.Contracts.Client;
using teledok.Teledok.Controllers.Contracts.Founder;
using Teledok.Core.Utils;

namespace teledok.Teledok.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("GetAllClients")]
        public async Task<ActionResult<List<ClientResponse>>> GetClients(int page)
        {
            var Clients = await _clientService.GetAllClients(page);
            var response = Clients.Select(b => new ClientResponse(b.id, b.Name, b.INN, b.Create_Date, b.Update_Date,b.Client_Type));
            return Ok(response);
        }

        [HttpGet("GetAllFoundersFoClient{Client_id:Guid}")]
        public async Task<ActionResult<List<ClientResponse>>> GetAllFoundersFoClient(Guid Client_id)
        {
            var Founders = await _clientService.GetAllFounderFromClient(Client_id);
            var response = Founders.Select(b => new FounderResponse(b.id, b.Full_Name, b.INN, b.Create_Date, b.Update_Date));
            return Ok(response);
        }

        [HttpPost("CreateClient")]
        public async Task<ActionResult<Guid>> CreateClient([FromBody] ClientRequest request)
        {
            var (client, Error) = Client.CreateClient(
                Guid.NewGuid(),
                request.INN,
                request.Name,
                request.Client_Type);
            if (!string.IsNullOrEmpty(Error))
            {
                return BadRequest(Error);
            }
            await _clientService.CreateClient(client);
            return Ok(client.id);
        }

        [HttpPut("UpdateClient{update_id:Guid}")]
        public async Task<ActionResult<Guid>> UpdateClient(Guid update_id, [FromBody] ClientRequest request)
        {
            var error = string.Empty;
            Utils.CheckINN(request.INN,ref error);
            Utils.CheckClientType(request.Client_Type,ref error);
            Utils.CheckName(request.Name,ref error);
            if (string.IsNullOrEmpty(error))
            {
                var id = await _clientService.UpdateClient(update_id, request.INN, request.Name, request.Client_Type);
                return Ok(id);
            }
            else
            {
                return BadRequest(error);
            }
        }

        [HttpDelete("DeleteClient{delete_id:Guid}")]
        public async Task<ActionResult<Guid>> DeleteClient(Guid delete_id)
        {
            var id = await _clientService.DeleteClient(delete_id);
            return Ok(id);
        }
    }
}