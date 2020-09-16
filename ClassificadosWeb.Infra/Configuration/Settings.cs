namespace ClassificadosWeb.Infra.Configuration
{
    public class Settings
    {
        public string Connection { get; set; }
        public string DatabaseName { get; set; }

        public Settings(string connection, string databaseName)
        {
            Connection = connection;
            DatabaseName = databaseName;
        }
    }
}