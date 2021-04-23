using DesafioDEV.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioDEV.Interfaces.Service
{
    public interface IHarvestService
    {
        Task<Harvest> Add(Harvest harvest);

        Task<IEnumerable<Harvest>> Get(string information);
    }
}
