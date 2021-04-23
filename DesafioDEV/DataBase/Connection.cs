using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace DesafioDEV.DataBase
{
    public class Connection
    {

        private static readonly string connectinString = "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.10)(PORT = 1521)))(CONNECT_DATA = (SID = xe)));Persist Security Info=True;User ID=system;Password=123;Pooling=True;Connection Timeout=60;";
        public OracleConnection getConnection()
        {
            var connection = new OracleConnection(connectinString);
            return connection;
        }  
            

    }
}
