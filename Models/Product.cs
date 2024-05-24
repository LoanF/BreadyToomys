using MySql.Data.MySqlClient;
using BreadyToomys.Controlers;

namespace BreadyToomys.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public decimal Price { get; set; }
        public string? Picture { get; set; }

        private DatabaseManager dbManager = new DatabaseManager();

        public void Create(DatabaseManager dbManager)
        {
            string query = "INSERT INTO Product (Id, Name, Description, Type, Price, Picture) VALUES (@Id, @Name, @Description, @Type, @Price, @Picture)";

            if (dbManager.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbManager.Connection);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@Picture", Picture);
                cmd.ExecuteNonQuery();
                dbManager.CloseConnection();
            }
        }

        public List<Product> Read(int? id = null)
        {
            List<Product> products = new List<Product>();
            string query = id != null ? "SELECT * FROM Product WHERE Id = @Id" : "SELECT * FROM Product";

            if (this.dbManager.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, this.dbManager.Connection);

                if (id != null)
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                }

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Product product = new Product
                    {
                        Id = Convert.ToInt32(dataReader["Id"]),
                        Name = dataReader["Name"].ToString(),
                        Description = dataReader["Description"].ToString(),
                        Type = dataReader["Type"].ToString(),
                        Price = Convert.ToDecimal(dataReader["Price"]),
                        Picture = dataReader["Picture"].ToString()
                    };

                    products.Add(product);
                }

                dataReader.Close();
                this.dbManager.CloseConnection();
            }

            return products;
        }

        public void Update(DatabaseManager dbManager)
        {
            string query = "UPDATE Product SET Name = @Name, Description = @Description, Type = @Type, Price = @Price, Picture = @Picture WHERE Id = @Id";

            if (dbManager.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbManager.Connection);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@Picture", Picture);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
                dbManager.CloseConnection();
            }
        }

        public void Delete(DatabaseManager dbManager)
        {
            string query = "DELETE FROM Product WHERE Id = @Id";

            if (dbManager.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbManager.Connection);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
                dbManager.CloseConnection();
            }
        }
    }
}
