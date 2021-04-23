using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDEV.Models
{
    public class Species
    {
        public Species(string _description)
        {
            description = _description;

        }
        public string description { get; set; }
    }
}
