using System;
using System.Collections.Generic;

namespace DesafioDEV.Models
{
    public class Tree
    {
        public Tree(string _description, int _age, string _species)
        {
            description = _description;
            age = _age;
            species = _species;
        }
        public string description { get; set; }

        public int age { get; set; }

        public string species { get; set; }
    }
}
