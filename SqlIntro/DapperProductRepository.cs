using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SqlIntro
{
    public class DapperProductRepository
    {
        private readonly IDbConnection conn;

        public DapperProductRepository(IDbConnection conn)
        {
            this.conn = conn;
        }

        public IEnumerable<Product> GetProducts()
        {
            return conn.Query<Product>("Select * from product");
        }

        public void DeleteProduct(int id)
        {
            conn.Execute("Delete from product where id =@id");
        }

        public void UpdateProduct(Product prod)
        {
            conn.Execute("Update product set name = @name where id=@id");
        }

        public void InsertProduct(Product prod)
        {
            conn.Execute("Insert into product (name) value (@name)", new {name = prod.Name});
        }
    }
}
