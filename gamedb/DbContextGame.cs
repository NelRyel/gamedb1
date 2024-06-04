using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static gamedb.GameModel;

namespace gamedb
{
    public class DbContextGame: DbContext
    {
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;
        public DbSet<Developer> Developers { get; set; } = null!;
        public DbSet<Platform> Platforms { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<GameDescription> GameDescriptions { get; set; } = null!;

        public DbContextGame()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=gameapp.db");
        }
    }
}
