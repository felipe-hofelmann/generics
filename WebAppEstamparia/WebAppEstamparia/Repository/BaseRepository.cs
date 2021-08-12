using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppEstamparia.Context;
using WebAppEstamparia.Models;

namespace WebAppEstamparia.Repository
{
    public class BaseRepository<T> : BaseModel where T:BaseModel
    {
        public void Create(T model)
        {
            using (var context = new ProdContext())
            {
                context.Entry<T>(model);
                context.SaveChanges();
            }
        }

        public List<T> Read()
        {
            List<T> list = new List<T>();
            using (var context = new ProdContext())
            {
                list = context.Set<T>().ToList();
            }
            return list;
        }

        public T Read(int id)
        {
            T model = Activator.CreateInstance<T>();
            using (var context = new ProdContext())
            {
                model = context.Set<T>().Find(id);
            }
            return model;
        }
        public void Update(T model)
        {
            using (var context = new ProdContext())
            {
                context.Entry<T>(model).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var context = new ProdContext())
            {
                context.Entry<T>(this.Read(id)).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}