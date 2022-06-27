using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{

    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
        public IActionResult geProducts()
        {
            return Ok('A');
        }

        [HttpGet("{name}")]
        public IActionResult GetProductByName(string name)
        {
            return Ok(name);
        }
    }
}
