using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NFSUOnline.Core.Database.Models;

namespace NFSUOnline.Core.Database
{
    public class Context : DbContext
    {
        public DbSet<PlayerModel> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder.UseMySql("Server=localhost;database=nfsuonline;uid=root");
        }
    }
}
