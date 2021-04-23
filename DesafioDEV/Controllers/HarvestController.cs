using DesafioDEV.Interfaces.Service;
using DesafioDEV.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioDEV.Controllers
{
    [Route("harvest")]
    [ApiController]
    public class HarvestController : ControllerBase
    {
        private IHarvestService _service;

        public HarvestController(IHarvestService harvestService)
        {
            _service = harvestService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Harvest obj)
        {
            try
            {
                if (obj.information == "" || obj.tree.ToString() == "" || obj.date.ToString() == "" || obj.weigth.ToString() == "")
                {
                    return StatusCode(400, new ReturnErrors("Todos os campos são obrigatório!"));
                }
                Harvest result = await _service.Add(obj);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex);
            }

        }
        [HttpGet("{information}")]
        public async Task<IActionResult> Get(string information)
        {
            try
            {
                IEnumerable<Harvest> result = await _service.Get(information);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex);
            }

        }
    }
}
