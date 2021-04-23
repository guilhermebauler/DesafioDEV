using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDEV.Models
{
    public class ReturnErrors
    {
        public ReturnErrors(string _message)
        {
            error = _message;
        }
        public string error { get; set; }

    }
}
