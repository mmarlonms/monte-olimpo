﻿using Microsoft.EntityFrameworkCore;
using MonteOlimpo.Domain.Models;

namespace MonteOlimpo.Data
{
   public class MonteOlimpoContext : DbContext
    {
        public DbSet<God> God { get; set; }

        public MonteOlimpoContext()
        {

        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<God>().HasKey(c => c.Id);
        }
    }
}