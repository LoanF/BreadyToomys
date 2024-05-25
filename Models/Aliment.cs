using MySql.Data.MySqlClient;
using BreadyToomys.Controlers;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace BreadyToomys.Models
{
    public class Aliment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Picture { get; set; }
        public ImageSource? PictureImage { get; set; }

        private DatabaseManager dbManager = new DatabaseManager();

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

        public List<Aliment> Read(int? id = null)
        {
            List<Aliment> aliments = new List<Aliment>();
            string query = id != null ? "SELECT * FROM Aliment WHERE Id = @Id" : "SELECT * FROM Aliment";

            try
            {
                if (dbManager.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbManager.Connection);

                    if (id != null)
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                    }

                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        string? base64String = dataReader["Picture"].ToString();

                        if (!string.IsNullOrWhiteSpace(base64String) && IsBase64String(base64String))
                        {
                            Aliment aliment = new Aliment
                            {
                                Id = Convert.ToInt32(dataReader["Id"]),
                                Name = dataReader["Name"].ToString(),
                                Picture = dataReader["Picture"].ToString(),
                                PictureImage = LoadImage(dataReader["Picture"].ToString())
                            };

                            aliments.Add(aliment);
                        }
                    }

                    dataReader.Close();
                    dbManager.CloseConnection();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySqlException: " + ex.Message);
                Console.WriteLine("Number: " + ex.Number);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }


            return aliments;
        }

        private ImageSource? LoadImage(string? base64String)
        {
            if (string.IsNullOrWhiteSpace(base64String)) return null;

            byte[] binaryData = Convert.FromBase64String(base64String);
            BitmapImage bitmap = new BitmapImage();
            using (MemoryStream stream = new MemoryStream(binaryData))
            {
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
            }
            return bitmap;
        }

        private bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
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
