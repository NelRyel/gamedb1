// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using MyLibDb;
using System.Runtime.Serialization;

Console.WriteLine("Hello, World!");
using (_TestContext db = new _TestContext())
{
    Console.WriteLine( "in using");

    __DefaultInit.OnStart();


    // Game game = db.Games.Include(g=>g.GameDescription).Include(a=>a.).FirstOrDefault();
    GameDescription gameDescription = db.GameDescriptions.Include(q => q.Game).Include(w => w.Genres).Include(p=>p.Platforms).Include(d=>d.Developer).Include(pb=>pb.Publisher).FirstOrDefault();

    Console.WriteLine(gameDescription.Game.Name);




    //g.ForEach(x => Console.WriteLine("genre ID: " + x.Id + " - " + "Genre Name: " + x.Name));


}



    Console.WriteLine("END__________________________________");