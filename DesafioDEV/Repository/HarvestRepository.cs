using DesafioDEV.DataBase;
using DesafioDEV.Interfaces.Repository;
using DesafioDEV.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDEV.Repository
{
    public class HarvestRepository : IHarvestRepository
    {
        protected OracleConnection _conn;
        public HarvestRepository()
        {
            _conn = new Connection().getConnection();
        }
        public async Task<Harvest> Add(Harvest harvest)
        {
            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = $"select * from TB_HARVEST where INFORMATION = '{harvest.information}'";
            var reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows == false)
            {
                String script = "insert into TB_HARVEST (INFORMATION, HARVESTDATE) values (:INFORMATION, :HARVESTDATE)";
                cmd.CommandText = script;
                cmd.Parameters.Add(":INFORMATION", OracleDbType.Varchar2, harvest.information, ParameterDirection.Input);
                cmd.Parameters.Add(":HARVESTDATE", OracleDbType.Date, harvest.date, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
            }
            cmd.CommandText = $"select CODHARVEST from TB_HARVEST where INFORMATION = '{harvest.information}'";
            reader = cmd.ExecuteReader();
            reader.Read();
            var codHarvest = Int64.Parse(reader["CODHARVEST"].ToString());
            cmd.CommandText = "";
            cmd.CommandText = $"select CODTREE from TB_TREE where DESCRIPTION = '{harvest.tree}'";
            reader = cmd.ExecuteReader();
            if (reader.HasRows == false)
            {
                throw new InvalidConstraintException("Árvore não cadastrada!");
            }
            reader.Read();
            var codTree = Int64.Parse(reader["CODTREE"].ToString());
            cmd.CommandText = "";
            cmd.CommandText = $"insert into TB_HARVEST_HAS_TREE (CODTREE, CODHARVEST, WEIGHT) values ({codTree}, {codHarvest}, {harvest.weigth})";
            cmd.ExecuteNonQuery();
            _conn.Dispose();
            return harvest;
        }

        public async Task<IEnumerable<Harvest>> Get(string information)
        {
            String script = "select hr.INFORMATION, tr.description as tree_description, ht.WEIGHT, hr.HARVESTDATE from TB_HARVEST hr "+
                             "inner join TB_HARVEST_HAS_TREE ht on(hr.CODHARVEST = ht.CODHARVEST) "+
                             "inner join TB_TREE tr on(tr.CODTREE = ht.CODTREE) "+
                            $"where hr.INFORMATION = '{information}'";
            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = script;
            var reader = cmd.ExecuteReader();
            if (reader.HasRows == false)
            {
                throw new InvalidConstraintException("Informação da colheita não cadastrada!");
            }
            List<Harvest> harvestList = new List<Harvest>();
            while (reader.Read())
            {
                Harvest harvest = new Harvest(reader["INFORMATION"].ToString(), reader["TREE_DESCRIPTION"].ToString(), DateTime.Parse(reader["HARVESTDATE"].ToString()), float.Parse(reader["WEIGHT"].ToString()));
                harvestList.Add(harvest);
            }
            _conn.Dispose();
            return harvestList;
        }
    }
}
