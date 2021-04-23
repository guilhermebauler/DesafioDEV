using DesafioDEV.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioDEV.Interfaces.Service
{
    public interface ITreeService
    {
        Task<Tree> Add(Tree tree);
        Task<IEnumerable<Tree>> Get(string description);
    }
}
