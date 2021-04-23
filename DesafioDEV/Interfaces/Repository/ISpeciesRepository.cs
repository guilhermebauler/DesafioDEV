using DesafioDEV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDEV.Interfaces.Repository
{
    interface ISpeciesRepository
    {
        Task<Species> Add(Species species);
        Task<IEnumerable<Species>> Get(string description);

    }
}
