using MySql.Data.MySqlClient;
using System;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            //var test = new DapperProductRepository();
            var connectionString = "Server=localHost;Database=adventureworks;Uid=aervin;Pwd=myPassword;"; //get connectionString format from connectionstrings.com and change to match your database
            using (var conn = new MySqlConnection(connectionString))
            {
                var repo = new DapperProductRepository(conn);
                foreach (var prod in repo.GetProducts())
                {
                    Console.WriteLine("Product Name:" + prod.Name);
                }

                Console.ReadLine();
         
            }
        }
    }
}
