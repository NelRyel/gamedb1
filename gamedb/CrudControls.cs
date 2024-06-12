using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static gamedb.GameModel;

namespace gamedb
{
    public static class CrudControls
    {
        public static void PrintOneGame(int id)
        {
            using (DbContextGame db = new DbContextGame())
            {

                Game game = db.Games.Include(d => d.Genres).Include(g => g.Publisher).Include(g => g.Developer).Include(g => g.Platforms).Include(g => g.GameDescription).FirstOrDefault(g => g.Id == id);

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

        public static void PrintAllGame()
        {
            using (DbContextGame db = new DbContextGame())
            {
                List<Game> games = db.Games.ToList();
                foreach (var item in games)
                {
                    Console.WriteLine($"ID: {item.Id} - Name: {item.GameName}");
                }

            }
        }

        public static void GenrePrintAll()
        {
            using (DbContextGame db = new DbContextGame())
            {
                    List<Genre> i = db.Genres.ToList();
                i.ForEach(x => Console.WriteLine("genre ID: " + x.Id + " - " + "Genre Name: " + x.GenreName));
               
            }
        }

        public static void PlatformsPrintAll()
        {
            using (DbContextGame db = new DbContextGame())
            {
                List<Platform> i = db.Platforms.ToList();
                i.ForEach(x => Console.WriteLine("Platform ID: " + x.Id + " - " + "Platform Name: " + x.PlatformName));

            }
        }
        public static void DevPrintAll()
        {
            using (DbContextGame db = new DbContextGame())
            {
                List<Developer> i = db.Developers.ToList();
                i.ForEach(x => Console.WriteLine("Developer ID: " + x.Id + " - " + "Developer Name: " + x.DevName));

            }
        }
        public static void PublisherPrintAll()
        {
            using (DbContextGame db = new DbContextGame())
            {
                List<Publisher> i = db.Publishers.ToList();
                i.ForEach(x => Console.WriteLine("Publisher ID: " + x.Id + " - " + "Publisher Name: " + x.PubName));

            }
        }

        public static void PubDel()
        {
            using(DbContextGame db = new DbContextGame())
            {
                Console.WriteLine( "before del: ");
                PublisherPrintAll();
                int PubID = Convert.ToInt32(Console.ReadLine());
                Publisher pub = db.Publishers.Find(PubID);
                db.Publishers.Remove(pub);
                db.SaveChanges();
                Console.WriteLine("after del: ");
                PublisherPrintAll();
            }
        }

        public static void GenreAdd()
        {
            using (DbContextGame db = new DbContextGame())
            {
                bool w = true;
                while (w)
                {
                    GenrePrintAll();

                    Console.WriteLine("Enter new genre: ");
                    string name = "";
                    name = Console.ReadLine();
                    Genre genre = new Genre();
                    genre.GenreName = name;
                    Console.WriteLine("more? Y/N");
                    string isDone = Console.ReadLine();
                    w = (isDone == "Y") ? true : false;
                    db.Genres.Add(genre);
                    db.SaveChanges();
                }

                GenrePrintAll();


            }
        }

        public static void DevAdd()
        {
            using (DbContextGame db = new DbContextGame())
            {
                bool w = true;
                while (w)
                {
                    DevPrintAll();

                    Console.WriteLine("Enter new developer: ");
                    string name = "";
                    name = Console.ReadLine();
                    Developer d = new Developer();
                    d.DevName = name;
                    Console.WriteLine("more? Y/N");
                    string isDone = Console.ReadLine();
                    w = (isDone == "Y") ? true : false;
                    db.Developers.Add(d);
                    db.SaveChanges();
                }

                DevPrintAll();


            }
        }

        public static void PubAdd()
        {
            using (DbContextGame db = new DbContextGame())
            {
                bool w = true;
                while (w)
                {
                    PublisherPrintAll();

                    Console.WriteLine("Enter new publisher: ");
                    string name = "";
                    name = Console.ReadLine();
                    Publisher d = new Publisher();
                    d.PubName = name;
                    Console.WriteLine("more? Y/N");
                    string isDone = Console.ReadLine();
                    w = (isDone == "Y") ? true : false;
                    db.Publishers.Add(d);
                    db.SaveChanges();
                }
                PublisherPrintAll();




            }
        }

        public static void PlatformAdd()
        {
            using (DbContextGame db = new DbContextGame())
            {
                bool w = true;
                while (w)
                {
                    PlatformsPrintAll();

                    Console.WriteLine("Enter new Platform: ");
                    string name = "";
                    name = Console.ReadLine();
                    Platform d = new Platform();
                    d.PlatformName = name;
                    Console.WriteLine("more? Y/N");
                    string isDone = Console.ReadLine();
                    w = (isDone == "Y") ? true : false;
                    db.Platforms.Add(d);
                    db.SaveChanges();
                }

                GenrePrintAll();


            }
        }

        public static void AddGame()
        {
            using (DbContextGame db = new DbContextGame())
            {
                Game game = new Game();
                string GameName;
                Console.WriteLine("Enter Game Name: ");
                GameName = Console.ReadLine();
                game.GameName = GameName;
                List<Genre> genres = db.Genres.ToList();
                List<Platform> platforms = db.Platforms.ToList();
                bool w = true;
                while(w == true)
                {
                    genres.ForEach(x => Console.WriteLine(x.Id + " " + x.GenreName));
                    Console.WriteLine("enter genre id: ");
                    int GenId = Convert.ToInt32( Console.ReadLine());
                    Genre genre = db.Genres.Find(GenId);
                    game.Genres.Add(genre);
                    Console.WriteLine("more? Y/N");
                    string isDone = Console.ReadLine();
                    w = (isDone=="Y")?true:false;
                }

                w = true;
                while (w == true)
                {
                    platforms.ForEach(x => Console.WriteLine(x.Id + " " + x.PlatformName));
                    Console.WriteLine( "enter platform ID: ");
                    int PlatId = Convert.ToInt32( Console.ReadLine());
                    Platform platform = db.Platforms.Find(PlatId);
                    game.Platforms.Add(platform);
                    Console.WriteLine("more? Y/N");
                    string isDone = Console.ReadLine();
                    w = (isDone == "Y") ? true : false;
                }

                
                    CrudControls.DevPrintAll();
                    Console.WriteLine( "Enter dev ID: ");
                    int DevId = Convert.ToInt32( Console.ReadLine());
                    Developer dev = db.Developers.Find(DevId);
                    dev.Games.Add(game);

                CrudControls.PublisherPrintAll();
                Console.WriteLine("enter Pub ID: ");
                int PubId = Convert.ToInt32( Console.ReadLine());
                Publisher pub = db.Publishers.Find(PubId);
                pub.Games.Add(game);

                GameDescription gameDescription = new GameDescription();
                Console.WriteLine("Enter Releasy year: ");
                int rel = Convert.ToInt32( Console.ReadLine());
                gameDescription.ReleaseYear = rel;
                Console.WriteLine("Enter Description");
                string desc = Console.ReadLine();
                gameDescription.Description = desc;
                gameDescription.Game = game;

                db.GameDescriptions.Add(gameDescription);

                db.SaveChanges();


            }

        } //ne zakonchen 
    }
}
