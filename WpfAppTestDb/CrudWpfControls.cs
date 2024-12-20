﻿using Microsoft.EntityFrameworkCore;
using MyLibDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppTestDb {
    public static class CrudWpfControls {

        //тут я собрал всё, что связано с КРУДами, не очень правильно, по хорошему бы разбить на ещё классы, и папки, но сделал как сделал. 
        


        //это у меня сравнивалка имени, ну чтобы не создавать одинаковых записей
        public static bool PubCompare(string name) {
            using (_TestContext db = new _TestContext()) {
                List<Publisher> publisher = db.Publishers.ToList();
                for (int i = 0; i < publisher.Count; i++) {
                    if (name == publisher[i].Name) {
                        return false;
                    }
                }
                return true;
            }
        
        }
        //это у меня сравнивалка имени, ну чтобы не создавать одинаковых записей

        public static bool GameNameCompare(string name) {
            using (_TestContext db = new _TestContext()) { 
            List<Game> games = db.Games.ToList();
                for (int i = 0; i < games.Count; i++) {
                    if (name == games[i].Name) {
                        return false;
                    }
                }
                return true;
            }

        
        }

        //это у меня сравнивалка имени, ну чтобы не создавать одинаковых записей

        public static bool GenreCompare(string name)
        {
            using (_TestContext db = new _TestContext())
            {
                List<Genre> g = db.Genres.ToList();
                for (int i = 0; i < g.Count; i++)
                {
                    if (name == g[i].Name)
                    {
                        return false;
                    }
                }
                return true;
            }

        }

        public static bool DevCompare(string name) {
            using (_TestContext db = new _TestContext()) {
                List<Developer> dev = db.Developers.ToList();
                for (int i = 0; i < dev.Count; i++) {
                    if (name == dev[i].Name) {
                        return false;
                    }
                }
                return true;
            }

        }
        public static bool PlatCompare(string name)
        {
            using (_TestContext db = new _TestContext())
            {
                List<Platform> p = db.Platforms.ToList();
                for (int i = 0; i < p.Count; i++)
                {
                    if (name == p[i].Name)
                    {
                        return false;
                    }
                }
                return true;
            }

        }

        //а вот создание записиа Игры.  в него из диалогово окна передаются собственно соответствующие обьекты, что не передавать отдельно стринги
        //всё это уже собрали в диалоговом
        public static void AddGame(Game game, GameDescription gameDescription) {
            using (_TestContext db = new _TestContext()) {
                Game g = new Game();                        //создали обьект игры
                GameDescription d = new GameDescription(); //и её описания
                g.Name = game.Name; //присваиваем значения
                
                d.Description = gameDescription.Description;
                d.ReleaseYear = gameDescription.ReleaseYear;

                
                Developer dev = db.Developers.Find(gameDescription.DeveloperId); /*здесь, поскольку нельзя просто взять и вытащить обьект Девелопера из обьекта Игры, мы его ищем в БД
                                                                                  по фату "db.Developers.Find(gameDescription.DeveloperId)" это тоже самое, что запрос
                                                                                  "SELECT from Developers WHERE ID = dev.Id" ну или как там правильно, я SQL cинтаксис плохо помню */
                Publisher pub = db.Publishers.Find(gameDescription.PublisherId)!;
                
                //Genre gg = db.Genres.Find(gameDescription.Genres.Id);
                for(int i = 0; i<gameDescription.Genres.Count(); i++) {
                   
                    Genre gen = db.Genres.Find(gameDescription.Genres[i].Id);
                    d.Genres.Add(gen);
                }
                for (int i = 0; i < gameDescription.Platforms.Count(); i++) {
                    Platform plt = db.Platforms.Find(gameDescription.Platforms[i].Id);
                    d.Platforms.Add(plt);
                }
                d.Developer = dev;
                d.Publisher = pub;
                //d.Developer = dev;
                //d.DeveloperId = dev.Id;
                d.Game = g;
                g.GameDescription = d;
                db.GameDescriptions.Add(d);
                db.Games.Add(g);
               
                db.SaveChanges();
            }
        }

        public static void AddPlatform(string name)
        {
            using (_TestContext db = new _TestContext())
            {
                Platform p = new Platform();
                p.Name = name;
                db.Platforms.Add(p);
                db.SaveChanges();
            }
        }

        public static void AddGenre(string name)
        {
            using (_TestContext db = new _TestContext())
            {
                Genre g = new Genre();
                g.Name = name;
                db.Genres.Add(g);
                db.SaveChanges();
            }
        }

        public static void AddPublisher(string name) {
            using (_TestContext db = new _TestContext()) {
                Publisher pub = new Publisher();
                pub.Name = name;
                db.Publishers.Add(pub);
                db.SaveChanges();
            }
        }

        public static void AddDeveloper(string name) {
            using (_TestContext db = new _TestContext()) {
                Developer dev = new Developer();
                dev.Name = name;
                db.Developers.Add(dev);
                db.SaveChanges();
            }
        }

        public static void tempDel(object t)
        {
            using (_TestContext db = new _TestContext()) {
                try {
                    if (t is Publisher p) {

                        int i = p.Id;
                        MessageBox.Show("Pub - " + i.ToString());
                       
                        Publisher pubDel = db.Publishers.Find(p.Id);
                        db.Publishers.Remove(pubDel);
                        db.SaveChanges();
                        return;
                    }
                    if (t is Developer d) {
                        int i = d.Id;
                        MessageBox.Show("Dev - " + i.ToString());
                        Developer dd = db.Developers.Find(d.Id);
                        db.Developers.Remove(dd);
                        db.SaveChanges();
                        return;
                    }
                    if (t is Genre g) {
                        int i = g.Id;
                        MessageBox.Show("Genre - " + i.ToString());
                        Genre gg = db.Genres.Find(g.Id);
                        db.Genres.Remove(gg);
                        db.SaveChanges();
                        return;
                    }
                    if(t is Platform plt)
                    {
                        int i = plt.Id;
                        MessageBox.Show("Platrform - " + i.ToString());
                        Platform platform = db.Platforms.Find(plt.Id);
                        db.Platforms.Remove(platform);
                        db.SaveChanges();
                        return;
                    }
                    
                }
                catch (Exception e) {
                    MessageBox.Show(e.ToString());
                }

               


            }
        }

        //public static void RemovePublisher(int id) {
        //    using (_TestContext db = new _TestContext()) {
        //        Publisher publisher = db.Publishers.Find(id);
        //        db.Publishers.Remove(publisher);
        //        db.SaveChanges();
        //    }
        //}

        public static void EditPublisher(int id, string newName) {
            using (_TestContext db = new _TestContext()) {
                Publisher publisher = db.Publishers.Find(id);
                publisher.Name = newName;
                db.SaveChanges();
                MessageBox.Show("done uspeshno");
            
            }
        }
        public static void EditPlatform(int id, string newName)
        {
            using (_TestContext db = new _TestContext())
            {
                Platform plt = db.Platforms.Find(id);
                plt.Name = newName;
                db.SaveChanges();
                MessageBox.Show("done uspeshno");

            }
        }

        public static void EditDev(int id, string newName) {
            using (_TestContext db = new _TestContext()) {
                Developer developer = db.Developers.Find(id);
                developer.Name = newName;
                db.SaveChanges();
                MessageBox.Show("done uspeshno");

            }
        }
        public static void EditGenre(int id, string newName)
        {
            using (_TestContext db = new _TestContext())
            {
                Genre g = db.Genres.Find(id);
                g.Name = newName;
                db.SaveChanges();
                MessageBox.Show("done uspeshno");

            }
        }

        public static void EditGame(int id, int idDesc, string newName, string newDesc, int newRelYear, int pubId,
            int devId, List<Genre> genres, List<Platform> platforms)
        { 
            using (_TestContext db = new _TestContext())
            {
                Game game = db.Games.Find(id);
                GameDescription gameDescription = db.GameDescriptions.Include(g=>g.Genres).Include(plt=>plt.Platforms).Include(p=>p.Publisher).Include(d=>d.Developer).First(gd=>gd.Id==id);
                game.Name = newName;

                gameDescription.Description = newDesc;
                gameDescription.ReleaseYear = newRelYear;

                Publisher p = db.Publishers.Find(pubId);
                gameDescription.Publisher = p;

                Developer d = db.Developers.Find(devId);
                gameDescription.Developer = d;

                gameDescription.Genres.Clear();
                gameDescription.Platforms.Clear();

                //gameDescription.Genres = null;
                //gameDescription.Platforms = null;



                for (int i = 0; i < genres.Count(); i++)
                {
                    Genre gen = db.Genres.Find(genres[i].Id);
                    gameDescription.Genres.Add(gen);
                }
                
                for(int i = 0; i < platforms.Count(); i++)
                {
                    Platform plt = db.Platforms.Find(platforms[i].Id);
                    gameDescription.Platforms.Add(plt);
                }

                db.SaveChanges();

            }

        }



        public static void DeleteGame(int id)
        {
            using (_TestContext db = new _TestContext())
            {
                Game g = db.Games.Find(id);
                GameDescription description = db.GameDescriptions.First(x => x.GameId == id);
                if (g != null && description!=null)
                {
                    db.Games.Remove(g);
                    db.GameDescriptions.Remove(description);
                    //System.Windows.Forms.MessageBox.Show(g.Name+" "+description.Description);
                    db.SaveChanges();
                }
                
            }
        }

    }
}
