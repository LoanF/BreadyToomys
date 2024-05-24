using MySql.Data.MySqlClient;

namespace BreadyToomys.Controlers
{
    public class DatabaseManager
    {
        private MySqlConnection? connection;
        private string? server;
        private string? port;
        private string? database;
        private string? uid;
        private string? password;

        public MySqlConnection? Connection { get { return connection; } }

        public DatabaseManager()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "87.106.205.180";
            port = "45783";
            database = "BreadyToomyDB";
            uid = "bready";
            password = "X6f$!E$LEN6c9$dP";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "PORT=" + port + ";";

            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Impossible de se connecter au serveur.");
                        break;
                    case 1045:
                        Console.WriteLine("Nom d'utilisateur ou mot de passe incorrect, veuillez réessayer.");
                        break;
                    default:
                        Console.WriteLine("Erreur de connexion: " + ex.Message);
                        break;
                }
                return false;
            }

            return false;
        }

        public bool CloseConnection()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return false;
        }
    }
}
