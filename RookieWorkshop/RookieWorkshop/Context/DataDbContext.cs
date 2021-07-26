using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RookieWorkshop.Table;

namespace RookieWorkshop.Context
{
    public class DataDbContext : DbContext
    {
        public DbSet<Data> Data { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1,1433;Database=Data;User Id=SA;Password=Krita123");
    }
}
