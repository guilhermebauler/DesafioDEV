using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDEV.Models
{
    public class Harvest
    {
        public Harvest(string _information, string _tree, DateTime _date, float _weigth)
            {
            information = _information;
            tree = _tree;
            date = _date;
            weigth = _weigth;
            }
        public string information { get; set; }

        public string tree { get; set; }

        public DateTime date { get; set; }

        public float weigth { get; set; }
    }
}
