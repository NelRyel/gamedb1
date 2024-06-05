// See https://aka.ms/new-console-template for more information
using gamedb;using static gamedb.GameModel;

Console.WriteLine("Hello, World!");

GameDefaultSeed seed = new GameDefaultSeed();
seed.OnStartAppDb();


Console.WriteLine(  "End_____________________________");


using (DbContextGame db = new DbContextGame())
{
    Game? game = db.Games.FirstOrDefault();
    //if(game == null)
    //{
    //    Console.WriteLine("NULL");
    //    return;
    //}
    Console.WriteLine($"Name: {game.GameName}");

}

//using(DbContextGame db = new DbContextGame())
//{
//    Console.WriteLine(  "in using");
//}

