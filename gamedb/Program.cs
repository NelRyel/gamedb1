// See https://aka.ms/new-console-template for more information
using gamedb;
using Microsoft.EntityFrameworkCore;
using static gamedb.GameModel;

Console.WriteLine("Hello, World!");

GameDefaultSeed seed = new GameDefaultSeed();
seed.OnStartAppDb();


Console.WriteLine(  "End_____________________________");




void PrintOneGame(int id)
{
    using (DbContextGame db = new DbContextGame())
    {
      

        Game game = db.Games.Include(d => d.Genres).Include(g => g.Publisher).Include(g => g.Developer).Include(g => g.Platforms).Include(g => g.GameDescription).FirstOrDefault(g=>g.Id == id);

        var platforms = game.Platforms.ToList();
        var genres = game.Genres.ToList();

        Console.WriteLine($"Name: {game.GameName}");
        Console.WriteLine($"Year: {game.GameDescription.ReleaseYear}");
        Console.WriteLine($"Publisher: {game.Publisher.PubName}");
        Console.WriteLine($"DeveloperL {game.Developer.DevName}");
        Console.Write($"Platforms: ");
        platforms.ForEach(x => Console.Write($" {x.PlatformName}"));
        Console.WriteLine("");
        Console.Write($"Genres: ");
        genres.ForEach(x => Console.Write($" {x.GenreName}"));
        Console.WriteLine("");
        Console.WriteLine($"Description: {game.GameDescription.Description}");


        //foreach (var item in platforms)
        //{
        //    Console.WriteLine( item.PlatformName.ToString());
        //}

        //Console.WriteLine(msg);

    }
}

PrintOneGame(2);

//using(DbContextGame db = new DbContextGame())
//{
//    Console.WriteLine(  "in using");
//}

