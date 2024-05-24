using MySql.Data.MySqlClient;
using BreadyToomys.Controlers;

namespace BreadyToomys.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }

        public void Create(DatabaseManager dbManager)
        {
            string query = "INSERT INTO `Order` (Id, OrderNumber, Description, Status) VALUES (@Id, @OrderNumber, @Description, @Status)";

            if (dbManager.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbManager.Connection);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@OrderNumber", OrderNumber);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.ExecuteNonQuery();
                dbManager.CloseConnection();
            }
        }

        public void Read(DatabaseManager dbManager, int id)
        {
            string query = "SELECT * FROM `Order` WHERE Id = @Id";

            if (dbManager.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbManager.Connection);
                cmd.Parameters.AddWithValue("@Id", id);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    Id = Convert.ToInt32(dataReader["Id"]);
                    OrderNumber = Convert.ToInt32(dataReader["OrderNumber"]);
                    Description = dataReader["Description"].ToString();
                    Status = dataReader["Status"].ToString();
                }

                dataReader.Close();
                dbManager.CloseConnection();
            }
        }

        public void Update(DatabaseManager dbManager)
        {
            string query = "UPDATE `Order` SET OrderNumber = @OrderNumber, Description = @Description, Status = @Status WHERE Id = @Id";

            if (dbManager.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbManager.Connection);
                cmd.Parameters.AddWithValue("@OrderNumber", OrderNumber);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
                dbManager.CloseConnection();
            }
        }

        public void Delete(DatabaseManager dbManager)
        {
            string query = "DELETE FROM `Order` WHERE Id = @Id";

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
