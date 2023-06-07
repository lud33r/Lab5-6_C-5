using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class NhanVienDbContext : DbContext
    {
        public DbSet<NhanVien> nhanViens { get; set; }

        public NhanVienDbContext(){}
        public NhanVienDbContext(DbContextOptions options) : base(options){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LEMINHHIEU\SQLEXPRESS;Initial Catalog=hieulm_ph27350;Persist Security Info=True;User ID=lmaohieu;Password=1");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
