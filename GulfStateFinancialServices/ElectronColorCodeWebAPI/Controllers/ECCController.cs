using System;
using ElectronColorCode;
using ElectronColorCodeWebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronColorCodeWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ECCController : Controller
    {
        private ECCTable eccTable = new ();

        // GET: api/ECC
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(JsonConvert.SerializeObject(eccTable.eccTable));
        }

        // GET api/ECC/green
        [HttpGet("{eccColor}")]
        public IActionResult Get(string eccColor)
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(eccTable.GetElectronColorCode(eccColor)));
            }
            catch (ApplicationException appEx)
            {
                return NotFound(JsonConvert.SerializeObject(new APIException(appEx)));

            }
        }
    }
}
