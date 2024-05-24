using MySql.Data.MySqlClient;
using BreadyToomys.Controlers;

namespace BreadyToomys.Models
{
    public class RecipeStep
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public void Create(DatabaseManager dbManager, int recipeId)
        {
            string query = "INSERT INTO RecipeStep (Id, Name, Description, RecipeId) VALUES (@Id, @Name, @Description, @RecipeId)";

            if (dbManager.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbManager.Connection);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@RecipeId", recipeId);
                cmd.ExecuteNonQuery();
                dbManager.CloseConnection();
            }
        }

        public void Read(DatabaseManager dbManager, int id)
        {
            string query = "SELECT * FROM RecipeStep WHERE Id = @Id";

            if (dbManager.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbManager.Connection);
                cmd.Parameters.AddWithValue("@Id", id);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    Id = Convert.ToInt32(dataReader["Id"]);
                    Name = dataReader["Name"].ToString();
                    Description = dataReader["Description"].ToString();
                }

                dataReader.Close();
                dbManager.CloseConnection();
            }
        }

        public void Update(DatabaseManager dbManager, int recipeId)
        {
            string query = "UPDATE RecipeStep SET Name = @Name, Description = @Description, RecipeId = @RecipeId WHERE Id = @Id";

            if (dbManager.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbManager.Connection);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@RecipeId", recipeId);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
                dbManager.CloseConnection();
            }
        }

        public void Delete(DatabaseManager dbManager)
        {
            string query = "DELETE FROM RecipeStep WHERE Id = @Id";

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
