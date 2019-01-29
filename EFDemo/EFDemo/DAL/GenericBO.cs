using EFDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFDemo.DAL
{
    public class GenericBO<T> where T : class
    {
        private EFDemoWithMVCDBEntities db = new EFDemoWithMVCDBEntities();

        DbSet es;

        public GenericBO()
        {
            es = db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return (IEnumerable<T>)es;
        }

        public T GetDetails(int id)
        {
            return (T)es.Find(id);
        }

        public T Insert(T entity)
        {
            es.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = (T)es.Find(id);
            es.Remove(entity);
            db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            db.Dispose();
            //base.Dispose(disposing);
        }
    }
}