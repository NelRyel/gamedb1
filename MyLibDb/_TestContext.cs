using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibDb
{
    // а это у нас по факту описание подключения к БД и описания создания БД
    public class _TestContext: DbContext
    {

        //здесь указывается какие классы станут таблицами
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;
        public DbSet<Developer> Developers { get; set; } = null!;
        public DbSet<Platform> Platforms { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<GameDescription> GameDescriptions { get; set; } = null!;



        //здесь мы как бы говорим ему Создать БД
        public _TestContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        //здесь тип бд и путь, 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=appdb.db");
        }


        //это я воевал с заполнением по умолчанию но забил и решил с сделать отдельный класс который разово потом вызывал. больше для тестов, чем для надобности. 

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    Genre genreFPS = new Genre { Id = 1, Name = "First-person" };
        //    Genre genreTPS = new Genre { Id = 2, Name = "Third-person" };
        //    Genre genreShouter = new Genre { Id = 3, Name = "Shouter" };
        //    Genre genreRPG = new Genre { Id = 4, Name = "RPG" };
        //    Genre genreStrategy = new Genre { Id = 5, Name = "Strategy" };
        //    Genre genreTactic = new Genre { Id = 6, Name = "Tactics" };
        //    Genre genreFantasy = new Genre { Id = 7, Name = "Fantasy" };
        //    modelBuilder.Entity<Genre>().HasData(genreFantasy, genreFPS, genreTPS, genreShouter, genreRPG, genreStrategy, genreTactic);
        //}

    }
}
