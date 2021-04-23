using DesafioDEV.Interfaces.Repository;
using DesafioDEV.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioDEV.DataBase;
using System.Data;

namespace DesafioDEV.Repository
{
    public class SpeciesRepository : ISpeciesRepository
    {
        protected OracleConnection _conn;
        public SpeciesRepository()
        {
            _conn = new Connection().getConnection();
        }
        public async Task<Species> Add(Species species)
        {
            String script = $"insert into TB_SPECIES (DESCRIPTION) values ('{species.description}')";
            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = script;
            cmd.ExecuteNonQuery();
            _conn.Dispose();
            return species;
        }

        public async Task<IEnumerable<Species>> Get(string description)
        {

            String script = $"select DESCRIPTION from TB_SPECIES where DESCRIPTION = '{description}'";
            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = script;
            var reader = cmd.ExecuteReader();
            if (reader.HasRows == false)
            {
                throw new InvalidConstraintException("Descrição da espécie não cadastrada!");
            }
            List<Species> speciesList = new List<Species>();
            while (reader.Read())
            {
                Species species = new Species(reader["DESCRIPTION"].ToString());
                speciesList.Add(species);
            }
            _conn.Dispose();
            return speciesList;
        }

    }
}
