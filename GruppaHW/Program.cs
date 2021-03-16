using System;
using System.Data.SqlClient;
using System.Data;

namespace GruppaHW
{
    class Program
    {
        private static readonly SqlParameter parametr;

        public static string SqlParameter { get; private set; }

        static void Main(string[] args)
        {
            string connStr = @"Data Source=(local)\SQLEXPRESS;
                            Initial Catalog=Test;
                            Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
            }
            catch (SqlException se)
            {
                Console.WriteLine("Ошибка подключения:{0}", se.Message);
                return;
            }
            Console.WriteLine("Соедение успешно произведено");
            SqlCommand comand = new SqlCommand("Insert into Students" + "(ID,FIO,Grupa) Values (@ID,@FIO,@Grupa)", conn);
            SqlParameter parametr = new SqlParameter();
            param.ParameterName = "@ID";
            param.Value = 10;
            param.SqlDbType = SqlDbType.Int;
            comand.Parameters.Add(SqlParameter);
            parametr = new SqlParameter();
            param.ParameterName = "@FIO";
            param.Value = "Константин Хабенский Юрьевич";
            param.SqlDbType = SqlDbType.Text;
            comand.Parameters.Add(parametr);
            parametr = new SqlParameter();
            param.ParameterName = "@Grupa";
            param.Value = "201/1";
            param.SqlDbType = SqlDbType.Text;
            comand.Parameters.Add(param);
            Console.WriteLine("Вставляем запись");
            try
            {
                comand.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Ошибка, при выполнении запроса на добавление записи");
                return;
            }
            comand = new SqlCommand("Select * From Students", conn);
            using (SqlDataReader dr = comand.ExecuteReader(CommandBehavior.CloseConnection))
            {
                for (int i = 0; i < dr.FieldCount; i++)
                    Console.Write("{0}\t", dr.GetName(i).ToString().Trim());
                Console.WriteLine();
                while (dr.Read())
                {
                    Console.WriteLine("{0}\t{1}\t{2}", dr.GetValue(0).ToString().Trim(),
                     dr.GetValue(1).ToString().Trim(),
                     dr.GetValue(2).ToString().Trim());
                }
            }
            conn.Close();
            conn.Dispose();
            Console.WriteLine();
        }
    }
}

