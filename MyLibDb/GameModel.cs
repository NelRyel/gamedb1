using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibDb
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<GameDescription> GameDescriptions { get; set; } = new();

    }

    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GameDescription> GameDescriptions { get; set; } = new();

    }

    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<GameDescription> GameDescriptions { get; set; } = new();

    }
    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<GameDescription> GameDescriptions { get; set; } = new();
    }


    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GameDescription GameDescription { get; set; }



    }

    public class GameDescription
    {
        public int Id { get; set; }

        public string? Description { get; set; }
        public int ReleaseYear { get; set; }

        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        public int DeveloperId { get; set; }
        public Developer? Developer { get; set; }

       

        public List<Genre> Genres { get; set; } = new();
        public List<Platform> Platforms { get; set; } = new();



        public int GameId { get; set; }
        public Game? Game { get; set; }



    }
}
