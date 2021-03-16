using System;

namespace GruppaHW
{
    internal class SqlConnection
    {
        private string connStr;

        public SqlConnection(string connStr)
        {
            this.connStr = connStr;
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }
}