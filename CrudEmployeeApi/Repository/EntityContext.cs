using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CrudEmployeeApi.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace CrudEmployeeApi.Repository
{
    public class EntityContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}