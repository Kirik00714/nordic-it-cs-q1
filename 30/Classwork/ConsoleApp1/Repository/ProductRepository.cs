using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace ConsoleApp1
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connection;

        public ProductRepository (string connection)
        {
            _connection = connection;
        }
        public int GetCount()
        {

            using var connection = CreateConnection();
            using var command = connection.CreateCommand();
            
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT COUNT(*) FROM [Product]";
            var result = command.ExecuteScalar();
            return (int)result;
        }

        private SqlConnection CreateConnection()
        {
            var connection = new System.Data.SqlClient.SqlConnection(_connection);
            connection.Open();
            return connection;
        }
        public class Product
        {
            public Product(int id, string name, decimal price)
            {
                Id = id;
                Name = name;
                Price = price;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }

        }

        public List<Product> GetAll()
        {
            using var connection = CreateConnection();
            using var command = connection.CreateCommand();

            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT [Id],[Name],[Price] FROM [Product] ORDER BY [Name];";

            using var reader = command.ExecuteReader();

            var result = new List<Product>();

            if(!reader.HasRows)
            {
                return result;
            }

            var idIndex = reader.GetOrdinal("Id");
            var nameIndex = reader.GetOrdinal("Name");
            var priceIndex = reader.GetOrdinal("price");

            while (reader.Read())
            {
                // first option
                //var id = reader.GetInt32("Id");
                //var name = reader.GetString("Name");
                //var price = reader.GetDecimal("Price");
                //var product = new Product(id, name, price);
                //result.Add(product);
                var id = reader.GetInt32(idIndex);
                var name = reader.GetString(nameIndex);
                var price = reader.GetDecimal(priceIndex);
                var product = new Product(id, name, price);
                result.Add(product);
            }

            return result;
        }

        public int Insert(string name, decimal price)
        {
            using var connection = CreateConnection();
            using var command = connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_AddProduct";
            command.Parameters.AddWithValue("@p_name", name);
            command.Parameters.AddWithValue("@p_price", price);

            var idParameter = new SqlParameter("@p_id", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(idParameter);
            command.ExecuteNonQuery();

            return (int)idParameter.Value;
        }
    }
}
