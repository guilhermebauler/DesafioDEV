using DesafioDEV.Interfaces.Service;
using DesafioDEV.Models;
using DesafioDEV.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioDEV.Services
{
    public class SpeciesService: ISpeciesService
    {
        public async Task<Species> Add(Species tree)
        {
            if (tree.description == "")
            {
                throw new Exception("Campo descrição é obrigatório!");
            }
            SpeciesRepository speciesrepository = new SpeciesRepository();
            return await speciesrepository.Add(tree);
        }

        public async Task<IEnumerable<Species>> Get(string description)
        {
            SpeciesRepository speciesrepository = new SpeciesRepository();
            return await speciesrepository.Get(description);
        }
    }
}
