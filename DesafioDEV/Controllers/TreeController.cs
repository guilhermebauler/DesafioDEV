using DesafioDEV.Interfaces.Service;
using DesafioDEV.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDEV.Controllers
{
    [Route("tree")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        private ITreeService _service;

        public TreeController(ITreeService treeService)
        {
            _service = treeService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tree obj)
        {
            try
            {
                if (obj.description == "" || obj.age.ToString() == "" || obj.species.ToString() == "")
                {
                    return StatusCode(400, new ReturnErrors("Todos os campos são obrigatório!"));
                }
                Tree result = await _service.Add(obj);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: "+ ex);
            }

        }
        [HttpGet("{description}")]
        public async Task<IActionResult> Get(string description)
        {
            try
            {
                IEnumerable<Tree> result = await _service.Get(description);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex);
            }

        }
    }

}
