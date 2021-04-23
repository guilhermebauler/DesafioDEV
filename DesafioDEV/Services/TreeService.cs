using DesafioDEV.Interfaces.Service;
using DesafioDEV.Models;
using DesafioDEV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDEV.Services
{
    public class TreeService : ITreeService
    {
        public async Task<Tree> Add(Tree tree)
        {
            TreeRepository treerepository = new TreeRepository();
            return await treerepository.Add(tree);
        }

        public async Task<IEnumerable<Tree>> Get(string description)
        {
            TreeRepository treerepository = new TreeRepository();
            return await treerepository.Get(description);
        }
    }
}
