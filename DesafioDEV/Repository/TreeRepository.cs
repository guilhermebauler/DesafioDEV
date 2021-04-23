using Dapper;
using Dapper.Oracle;
using DesafioDEV.DataBase;
using DesafioDEV.Interfaces.Repository;
using DesafioDEV.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;


namespace DesafioDEV.Repository
{
    public class TreeRepository : ITreeRepository
    {
        protected OracleConnection _conn;
        public TreeRepository() {
            _conn = new Connection().getConnection();
        } 
        public async Task<Tree> Add(Tree tree)
        {
            String script = "insert into TB_TREE (DESCRIPTION, AGE, SPECIES) values (:DESCRIPTION, :AGE, :SPECIES)";
            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = $"select CODSPECIES from TB_SPECIES where DESCRIPTION = '{tree.species}'";
            var reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows == false)
            {
                throw new InvalidConstraintException("Espécie não cadastrada!");
            }
            cmd.CommandText = "";
            cmd.CommandText = script;
            cmd.Parameters.Add(":DESCRIPTION", OracleDbType.Varchar2, tree.description, ParameterDirection.Input);
            cmd.Parameters.Add(":AGE", OracleDbType.Int64, tree.age, ParameterDirection.Input);
            cmd.Parameters.Add(":SPECIES", OracleDbType.Int64, Int64.Parse(reader["CODSPECIES"].ToString()), ParameterDirection.Input);
            cmd.ExecuteNonQuery();
            _conn.Dispose();
            return tree;
        }

        public async Task<IEnumerable<Tree>> Get(string description)
        {
            String script = "select tr.description, CAST (tr.age AS INT) as AGE, sp.description as specie_description from TB_TREE Tr " +
                            "left outer join TB_SPECIES sp on(tr.species = sp.codspecies) " +
                            "where tr.DESCRIPTION = :DESCRIPTION ";
            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = script;
            cmd.Parameters.Add(":DESCRIPTION", OracleDbType.Varchar2, description, ParameterDirection.Input);
            var reader = cmd.ExecuteReader();
            if (reader.HasRows == false)
            {
                throw new InvalidConstraintException("Descrição da árvore não cadastrada!");
            }
            List<Tree> treeList = new List<Tree>();
            while (reader.Read())
            {
                Tree tree = new Tree(reader["DESCRIPTION"].ToString(), Convert.ToInt32(reader["AGE"].ToString()), reader["SPECIE_DESCRIPTION"].ToString());
                treeList.Add(tree);
            }
            _conn.Dispose();
            return treeList;
        }
    }
}
