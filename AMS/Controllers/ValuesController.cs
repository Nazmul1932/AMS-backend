using AMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController(AuthenticationContext context)
        {

        }

        [HttpGet]
        public ActionResult<IEnumerable<String>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
