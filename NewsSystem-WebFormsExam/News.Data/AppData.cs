using System;
using System.Collections.Generic;
using System.Data.Entity;
using News.Data.Contracts;
using News.Data.Repositories;
using News.Models;

namespace News.Data
{
    public class AppData : IAppData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        public AppData()
            : this(new ApplicationDbContext())
        {
        }

        public AppData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IGenericRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IGenericRepository<Article> Articles
        {
            get
            {
                return this.GetRepository<Article>();
            }
        }

        public IGenericRepository<Like> Likes
        {
            get
            {
                return this.GetRepository<Like>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
