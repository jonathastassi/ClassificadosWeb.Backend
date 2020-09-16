using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassificadosWeb.Infra.Configuration;
using MongoDB.Driver;

namespace ClassificadosWeb.Infra.Context
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; }
        private readonly List<Func<Task>> commands;
        private readonly Settings setting;

        public MongoContext(Settings setting)
        {
            if (setting == null) 
            {
                throw new ArgumentException("Connection settings is necessary!");
            } 

            this.setting = setting;
            commands = new List<Func<Task>>();
        }

        
        public void AddCommand(Func<Task> func)
        {
            commands.Add(func);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();
            return Database.GetCollection<T>(name);
        }

        public async Task<int> SaveChanges()
        {
            ConfigureMongo();

            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();
                var commandTasks = commands.Select(c => c());
                await Task.WhenAll(commandTasks);
                await Session.CommitTransactionAsync();
            }

            return commands.Count;
        }

        private void ConfigureMongo()
        {
            if (MongoClient != null)
                return;

            MongoClient = new MongoClient(setting.Connection);
            Database = MongoClient.GetDatabase(setting.DatabaseName);
        }
    }
}