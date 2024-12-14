﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace places.data
{
    public class PlacesDbContext : DbContext
    {
        private readonly string ConnectionString;

        public DbSet<Place> Places { get; set; }
        public DbSet<RequestLog> RequestLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(ConnectionString);

        public PlacesDbContext()
            => ConnectionString = "Data Source=places.db";
        public PlacesDbContext(IConfiguration configuration)
            => ConnectionString = configuration.GetConnectionString("DefaultConnection")!;
    }
}
