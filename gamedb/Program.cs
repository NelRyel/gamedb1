// See https://aka.ms/new-console-template for more information
using gamedb;
using Microsoft.EntityFrameworkCore;
using static gamedb.GameModel;

Console.WriteLine("Hello, World!");

GameDefaultSeed seed = new GameDefaultSeed();
seed.OnStartAppDb();


Console.WriteLine(  "End_____________________________");


using (DbContextGame db = new DbContextGame())
{
    //Game? game = db.Games.FirstOrDefault();
    Game game = db.Games.Include(d => d.Genres).Include(g => g.Publisher).Include(g=>g.Developer).Include(g=>g.Platforms).Include(g=>g.GameDescription).FirstOrDefault();
    //if(game == null)
    //{
    //    Console.WriteLine("NULL");
    //    return;
    //}
    var msg = game.Platforms.ToList();

    Console.WriteLine($"Name: {game.GameName}");

    foreach (var item in msg)
    {
        Console.WriteLine( item.PlatformName.ToString());
    }

    //Console.WriteLine(msg);

}

//using(DbContextGame db = new DbContextGame())
//{
//    Console.WriteLine(  "in using");
//}

