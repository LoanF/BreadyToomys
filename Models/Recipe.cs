using MySql.Data.MySqlClient;
using BreadyToomys.Controlers;

namespace BreadyToomys.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual required List<RecipeStep> Steps { get; set; }

        public void AddStep(RecipeStep step)
        {
            Steps.Add(step);
        }

        public void Create(DatabaseManager dbManager)
        {
            string query = "INSERT INTO Recipe (Id, Name, Description) VALUES (@Id, @Name, @Description)";

            if (dbManager.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbManager.Connection);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.ExecuteNonQuery();

                foreach (RecipeStep step in Steps)
                {
                    step.Create(dbManager, Id);
                }

                dbManager.CloseConnection();
            }
        }

        public void Read(DatabaseManager dbManager, int id)
        {
            string query = "SELECT * FROM Recipe WHERE Id = @Id";

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

                    Steps = new List<RecipeStep>();
                    RecipeStep step = new RecipeStep();
                    step.Read(dbManager, Id);
                    Steps.Add(step);
                }

                dataReader.Close();
                dbManager.CloseConnection();
            }
        }

        public void Update(DatabaseManager dbManager)
        {
            string query = "UPDATE Recipe SET Name = @Name, Description = @Description WHERE Id = @Id";

            if (dbManager.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbManager.Connection);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();

                foreach (RecipeStep step in Steps)
                {
                    step.Update(dbManager, Id);
                }

                dbManager.CloseConnection();
            }
        }

        public void Delete(DatabaseManager dbManager)
        {
            string query = "DELETE FROM Recipe WHERE Id = @Id";

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
