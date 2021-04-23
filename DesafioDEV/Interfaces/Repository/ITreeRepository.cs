using DesafioDEV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDEV.Interfaces.Repository
{
    public interface ITreeRepository
    {
        Task<Tree> Add(Tree tree);
        Task<IEnumerable<Tree>> Get(string description);
    }
}
