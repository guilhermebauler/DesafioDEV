using DesafioDEV.Interfaces.Service;
using DesafioDEV.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioDEV.Controllers
{
    [Route("species")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private ISpeciesService _service;

        public SpeciesController(ISpeciesService speciesService)
        {
            _service = speciesService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Species obj)
        {
            try
            {
                if (obj.description == "")
                {
                    return StatusCode(400, new ReturnErrors("Campo descrição é obrigatório!"));
                }
                Species result = await _service.Add(obj);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex);
            }

        }
        [HttpGet("{description}")]
        public async Task<IActionResult> Get(string description)
        {
            try
            {
                IEnumerable<Species> result = await _service.Get(description);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex);
            }

        }

    }
}
