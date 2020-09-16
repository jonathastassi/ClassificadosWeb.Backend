using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ClassificadosWeb.Domain.Entities;
using ClassificadosWeb.Domain.Repositories.Base;
using ClassificadosWeb.Infra.Context;
using MongoDB.Driver;

namespace ClassificadosWeb.Infra.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IMongoContext context;
        private readonly string collectionName;
        protected IMongoCollection<TEntity> DbSet;

        public BaseRepository(IMongoContext context, string collectionName)
        {
            this.context = context;
            this.collectionName = collectionName;
        }

        private void ConfigDbSet()
        {
            DbSet = this.context.GetCollection<TEntity>(collectionName);
        }

        public TEntity Add(TEntity entity)
        {
            ConfigDbSet();
            this.context.AddCommand(() => DbSet.InsertOneAsync(entity));
            return entity;
        }

        public void Delete(TEntity entity)
        {
            ConfigDbSet();
            this.context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.Id)));
        }

        public async Task<TEntity> FindOneBy(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                this.ConfigDbSet();            
            /* var data = await DbSet.Find<TEntity>(where).FirstOrDefaultAsync();
            return data; */
             var data = await DbSet.FindAsync(where);
            return data.SingleOrDefault();
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
            
        }

        public Task<List<TEntity>> ListBy(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> orderBy = null, bool asc = true, int limit = 0)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> ListByArray(Expression<Func<TEntity, IEnumerable<string>>> where, string field, Expression<Func<TEntity, object>> orderBy = null, bool asc = true, int limit = 0)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            ConfigDbSet();
            this.context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.Id), entity));
            return entity;
        }
    }
}