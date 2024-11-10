using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using teledok.Class_Library.Core.Entiuties;
using teledok.Teledoc.Application.Services;
using teledok.Teledok.Application.Services;
using teledok.Teledok.Controllers.Contracts.Founder;
using Teledok.Core.Utils;

namespace teledok.Teledok.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FounderController : ControllerBase
    {
        private readonly IFounderService _founderService;
        //private readonly IClientService _clientService;

        public FounderController(IFounderService FounderService)
        {
            _founderService = FounderService;
        }

        [HttpGet("GetFounders")]
        public async Task<ActionResult<List<FounderResponse>>> GetFounders()
        {
            var founder = await _founderService.GetAllFounders();
            var response = founder.Select(b => new FounderResponse(b.id, b.Full_Name, b.INN, b.Create_Date, b.Update_Date));
            return Ok(response);
        }

        [HttpPost("CreateFounder")]
        public async Task<ActionResult<Guid>> CreateFounder([FromBody] FounderRequest request)
        {
            var (founder, Error) = Founder.Create_Founder(
            Guid.NewGuid(),
            request.INN,
            request.Full_Name,
            request.Client_id);
            
            if (!string.IsNullOrEmpty(Error))
            {
                return BadRequest(Error);
            }
            var id = await _founderService.CreateFounder(founder);
            return Ok(id);
        }

        [HttpPut("UpdateFounder{update_id:Guid}")]
        public async Task<ActionResult<Guid>> UpdateFounder(Guid update_id, [FromBody] FounderRequest request)
        {
            var error = string.Empty;
            Utils.CheckINN(request.INN,ref error);
            Utils.CheckFullName(request.Full_Name,ref error);

            if (string.IsNullOrEmpty(error))
            {
                var id = await _founderService.UpdateFounder(update_id, request.INN, request.Full_Name, request.Client_id);
                return Ok(id);
            }
            else
            {
                return BadRequest(error);
            }
        }

        [HttpDelete("DeleteFounder{delete_id:Guid}")]
        public async Task<ActionResult<Guid>> DeleteFounder(Guid delete_id)
        {
            var id = await _founderService.DeleteFounder(delete_id);
            return Ok(id);
        }
    }
}

