using System;
using System.Threading.Tasks;
using BillDesk;
using Microsoft.AspNetCore.Mvc;

namespace BillDeskApi.Controllers
{
    [ApiController]
    [Route("api/BillDesk")]
    public class Controller : ControllerBase
    {
        private readonly Iintegration _Iintegration;
        public Controller(
            Iintegration integration)
        {
            _Iintegration = integration;
        }

        [HttpGet("CreateDataString")]
        public async Task<string> Get()
        {
            var response = await _Iintegration.CreateHMAC();
            Console.WriteLine(response);
            return response;
        }

        [HttpPost("CreateDataString")]
        public async Task<string> CreateDataString([FromBody] DataEntryModel dataEntry)
        {
            var response = await _Iintegration.CreateHMAC(dataEntry);
            return response;
        }
    }
}
