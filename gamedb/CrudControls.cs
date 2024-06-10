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

        public static void AddGame()
        {
            using (DbContextGame db = new DbContextGame())
            {
                Game game = new Game();
                string GameName;
                Console.WriteLine("Enter Game Name: ");
                GameName = Console.ReadLine();
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

            }

        }
    }
}
