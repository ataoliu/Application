using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Application.Util.Extention;
using Application.Entity;

namespace Application.Data.EF
{
    public class SqlServerDbContext : DbContext, IDbContext, IDisposable
    {
        public string connectionString = "Server=47.102.44.102;Initial Catalog=Application;User ID=sa;Password=lat_123456";
        #region 构造函数
      public SqlServerDbContext(string key="")
        {
          
           
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            //if (connectionString.IsEmpty())
            //{
            //    connectionString = "Server=47.102.44.102;Initial Catalog=Application;User ID=sa;Password=lat_123456";
            //}
            //connectionString = "Server=47.102.44.102;Initial Catalog=Application;User ID=sa;Password=lat_123456";
            //Server=47.104.155.169;Initial Catalog=Test_Finance;User ID=sa;Password=sasasa_123
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        #region 重载
        //通过程序集注册到DbSet 里
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MethodInfo? entityMethod = typeof(ModelBuilder).GetMethod(nameof(modelBuilder.Entity),new Type[] { });
            var assemblypath = AppDomain.CurrentDomain.BaseDirectory + "Application.Mapping.dll";
            var assembly = Assembly.LoadFrom(assemblypath);
            foreach (var type in assembly.ExportedTypes)
            {
                if (type.IsClass && type != typeof(BaseEntity) && typeof(BaseEntity).IsAssignableFrom((Type)type)&& entityMethod!=null)
                {
                    entityMethod.MakeGenericMethod(type).Invoke(modelBuilder, new object[] { });
                }
            }
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
