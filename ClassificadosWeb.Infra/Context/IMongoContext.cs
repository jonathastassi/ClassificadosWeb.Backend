using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ClassificadosWeb.Infra.Context
{
    public interface IMongoContext
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}