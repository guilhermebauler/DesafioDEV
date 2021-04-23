using DesafioDEV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDEV.Interfaces.Repository
{
    interface IHarvestRepository
    {
        Task<Harvest> Add(Harvest harvest);
        Task<IEnumerable<Harvest>> Get(string information);
    }
}
