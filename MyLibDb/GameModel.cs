using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibDb
{
    //на след. раз. можно попробовать создать один родительский класс, имеющий ИД и ИМЯ. и от него наследовать остальные. И тогда
    // передавая в круд контроллер можно передавать модель родительского класса 


    /* 
     Здесь начинается Энтити Фрэймворк. Прежде чем начать нужно зайти в управление NuGet пакетами и найти и поставить  Microsoft.EntityFrameworkCore.Sqlite 
    и возможно обновить using-и. Тупая студия иногда тупит. 

     Далее, каждый класс, соответсвуте таблице в базе данных. (подключение к ней в _TestContext.cs)  
    здесь у меня простые классы и разные типы связей. 
     */
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<GameDescription> GameDescriptions { get; set; } = new();//по факту это и есть многие ко многим. такой же обратный лист в Классе GameDescription.

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

        //--------
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        //------- а вот так реализуется связь один-к-однму. т.е. в таблице будет столбец с PublisherId который собственно имеет ключ к ID этого самого паблишера


        public int DeveloperId { get; set; }
        public Developer? Developer { get; set; }

       

        public List<Genre> Genres { get; set; } = new();
        public List<Platform> Platforms { get; set; } = new();



        public int GameId { get; set; }
        public Game? Game { get; set; }



    }
}
