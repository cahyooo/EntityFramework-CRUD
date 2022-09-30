using Microsoft.EntityFrameworkCore;
using SIBKMNET_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApplication.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext>dbContext) : base(dbContext)
        {

        }

        // mengatur koneksi string (done)
        //   migrasi (done)

        public DbSet<Province> Provinces { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}
