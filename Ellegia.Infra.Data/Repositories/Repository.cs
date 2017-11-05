using System;
using System.Collections.ObjectModel;
using System.Linq;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ellegia.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly EllegiaContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(EllegiaContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}