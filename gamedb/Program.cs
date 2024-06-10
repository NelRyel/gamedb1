// See https://aka.ms/new-console-template for more information
using gamedb;
using Microsoft.EntityFrameworkCore;
using static gamedb.GameModel;

Console.WriteLine("Hello, World!");

GameDefaultSeed seed = new GameDefaultSeed();

seed.OnStartAppDb();

CrudControls.PrintAllGame();

//Console.Write("enter ID: ");
//string id = Console.ReadLine();

//CrudControls.PrintOneGame(Convert.ToInt32(id));

Console.WriteLine(  "End_____________________________");

using (DbContextGame db = new DbContextGame())
{
    Console.WriteLine( "Genres: ");
    List<Genre> genres = db.Genres.ToList();
    genres.ForEach(x => Console.WriteLine($"{x.Id} - {x.GenreName}"));
    bool w = true;
    while (w == true)
    {
        Console.WriteLine("enter genre id: ");
        int GenId = Convert.ToInt32(Console.ReadLine());
        Genre genre = db.Genres.Find(GenId);
        Console.WriteLine( genre.GenreName);
        // game.Genres.Add(genre);
        Console.WriteLine("more? Y/N");
        string isDone = Console.ReadLine();
        w = (isDone == "Y") ? true : false;
    }



}