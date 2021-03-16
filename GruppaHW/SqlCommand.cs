using System;
using System.Data;

namespace GruppaHW
{
    internal class SqlCommand
    {
        private string v;
        private SqlConnection conn;

        public SqlCommand(string v, SqlConnection conn)
        {
            this.v = v;
            this.conn = conn;
        }

        public object Parameters { get; internal set; }

        internal void ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        internal SqlDataReader ExecuteReader(CommandBehavior closeConnection)
        {
            throw new NotImplementedException();
        }
    }
}