using MySql.Data.MySqlClient;
using BreadyToomys.Controlers;

namespace BreadyToomys.Models
{
    public class Aliment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Picture { get; set; }

        public Aliment()
        {
        }

        public void Create(DatabaseManager dbManager)
        {
            string query = "INSERT INTO Aliment (Id, Name, Picture) VALUES (@Id, @Name, @Picture)";

            if (dbManager.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbManager.Connection);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Picture", Picture);
                cmd.ExecuteNonQuery();
                dbManager.CloseConnection();
            }
        }

        public void Read(DatabaseManager dbManager, int id)
        {
            string query = "SELECT * FROM Aliment WHERE Id = @Id";

            if (dbManager.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbManager.Connection);
                cmd.Parameters.AddWithValue("@Id", id);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    Id = Convert.ToInt32(dataReader["Id"]);
                    Name = dataReader["Name"].ToString();
                    Picture = dataReader["Picture"].ToString();
                }

                dataReader.Close();
                dbManager.CloseConnection();
            }
        }

        public void Update(DatabaseManager dbManager)
        {
            string query = "UPDATE Aliment SET Name = @Name, Picture = @Picture WHERE Id = @Id";

            if (dbManager.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbManager.Connection);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Picture", Picture);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
                dbManager.CloseConnection();
            }
        }

        public void Delete(DatabaseManager dbManager)
        {
            string query = "DELETE FROM Aliment WHERE Id = @Id";

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
