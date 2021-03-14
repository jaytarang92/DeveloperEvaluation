using System.Linq;
using ElectronColorCode;
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
        public string Get()
        {
            return JsonConvert.SerializeObject(eccTable.eccTable.ToArray());
        }

        // GET api/ECC/green
        [HttpGet("{eccColor}")]
        public string Get(string eccColor)
        { 
            return JsonConvert.SerializeObject(eccTable.GetElectronColorCode(eccColor));
        }
    }
}
