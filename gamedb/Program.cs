// See https://aka.ms/new-console-template for more information

using gamedb;
using Microsoft.EntityFrameworkCore;
using System.Data;

using static gamedb.GameModel;

Console.WriteLine("Hello, World!");

GameDefaultSeed seed = new GameDefaultSeed();

//seed.OnStartAppDb();

CrudControls.PrintAllGame();

//Console.Write("enter ID: ");
//string id = Console.ReadLine();

//CrudControls.PrintOneGame(Convert.ToInt32(id));


Console.WriteLine(  "End_____________________________");

//Console.WriteLine( "GENRES ");

//CrudControls.GenrePrintAll();
//Console.WriteLine();

//Console.WriteLine( "Platform:  " );

//CrudControls.PlatformsPrintAll();
//Console.WriteLine("END ");

//Console.WriteLine(" Developers: ");

//CrudControls.DevPrintAll();

//Console.WriteLine("END ");
//Console.WriteLine("Publishers ");
//CrudControls.PublisherPrintAll();

//Console.WriteLine("END ");

//Console.WriteLine("ADD GENRE _____________");
//CrudControls.GenreAdd();
//Console.WriteLine("start add pub_________________");
//CrudControls.PubAdd();
//Console.WriteLine("end add pub_________________");

////CrudControls.DevAdd();

//Console.WriteLine(  "Begin ADD GAME__________________");
//CrudControls.AddGame();

//Console.WriteLine("DONE ADD________________________________________");

////CrudControls.PrintAllGame();
//Console.WriteLine( "Enter ID ");
//int idd = Convert.ToInt32(Console.ReadLine());
//CrudControls.PrintOneGame(idd);

Console.WriteLine("done");
