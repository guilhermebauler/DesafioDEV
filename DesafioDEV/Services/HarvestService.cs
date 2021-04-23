using DesafioDEV.Interfaces.Service;
using DesafioDEV.Models;
using DesafioDEV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDEV.Services
{
    public class HarvestService : IHarvestService
    {
        public async Task<Harvest> Add(Harvest harvest)
        {
            if (harvest.information == "")
            {
                throw new Exception("Campo descrição é obrigatório!");
            }
            HarvestRepository harvestrepository = new HarvestRepository();
            return await harvestrepository.Add(harvest);
        }

        public async Task<IEnumerable<Harvest>> Get(string information)
        {
            HarvestRepository harvestrepository = new HarvestRepository();
            return await harvestrepository.Get(information);
        }
    }
}
