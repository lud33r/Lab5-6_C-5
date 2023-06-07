using AppData.IRepositories;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repositories
{
    public class AllRepository<T> : IAllRepository<T> where T : class
    {
        NhanVienDbContext context;
        DbSet<T> dbSet;
        public AllRepository(NhanVienDbContext context, DbSet<T> dbSet)
        {
            this.context = context;
            this.dbSet = dbSet;
        }
        public bool CreateItem(T item)
        {
            try
            {
                dbSet.Add(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool DeleteItem(T item)
        {
            try
            {
                dbSet.Remove(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public IEnumerable<T> GetAllItem()
        {
            return dbSet.ToList();
        }

        public bool UpdateItem(T item)
        {
            try
            {
                dbSet.Update(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
