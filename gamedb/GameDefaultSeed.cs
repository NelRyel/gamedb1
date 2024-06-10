using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static gamedb.GameModel;

namespace gamedb
{
    public class GameDefaultSeed

    {
        public void OnStartAppDb()
        {
            using (DbContextGame db = new DbContextGame())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();


                Genre genreFPS = new Genre { GenreName = "First-person shooter" };
                Genre genreRPG = new Genre { GenreName = "RPG" };
                Genre genreStrategy = new Genre { GenreName = "Strategy" };
                Genre genreTactic = new Genre { GenreName = "Tactics" };
                Genre genreFantasy = new Genre { GenreName = "Fantasy" };

               
                db.Genres.AddRange(genreFPS, genreRPG, genreStrategy, genreTactic, genreFantasy);

                Publisher publisher1 = new Publisher { PubName = "Bethesda Softworks" };
                Publisher DivPub = new Publisher { PubName = "Larian Studios" };
                db.Publishers.Add(DivPub);
                Developer DivDev = new Developer { DevName = "Larian Studios" };
                db.Developers.Add(DivDev);
                Developer developer1 = new Developer { DevName = "id Software" };

                db.Publishers.Add(publisher1);
                db.Developers.Add(developer1);
                



                Platform platformPCWin = new Platform { PlatformName = "Windows" };

                Platform platformSony1 = new Platform { PlatformName = "PlayStation One" };
                Platform platformSony2 = new Platform { PlatformName = "PlayStation 2" };
                Platform platformSony3 = new Platform { PlatformName = "PlayStation 3" };
                Platform platformSony4 = new Platform { PlatformName = "PlayStation 4" };
                Platform platformSony5 = new Platform { PlatformName = "PlayStation 5" };

                Platform platformXbox = new Platform { PlatformName = "XBox" };
                Platform platformXbox360 = new Platform { PlatformName = "XBox360" };
                Platform platformXboxOne = new Platform { PlatformName = "XBox One" };
                Platform platformXboxXS = new Platform { PlatformName = "XBox Series" };

                Platform platformNintendoSwitch = new Platform { PlatformName = "Nintendo Swithc" };
                Platform platformNintendoWiiU = new Platform { PlatformName = "Nintendo Wii U" };

                db.Platforms.AddRange(platformNintendoSwitch, platformNintendoWiiU, platformPCWin, platformSony1, platformSony2, platformSony3, platformSony4, platformSony5, platformXbox, platformXbox360, platformXboxOne, platformXboxXS);

                Game DoomGame = new Game();
                DoomGame.GameName = "DOOM Eternal";
                publisher1.Games.Add(DoomGame);
                developer1.Games.Add(DoomGame);
                DoomGame.Genres.Add(genreFPS);

                DoomGame.Platforms.Add(platformPCWin);
                DoomGame.Platforms.Add(platformSony4);
                DoomGame.Platforms.Add(platformSony5);
                DoomGame.Platforms.Add(platformXboxOne);
                DoomGame.Platforms.Add(platformXboxXS);
                DoomGame.Platforms.Add(platformNintendoSwitch);

                //db.Games.Add(DoomGame);

                GameDescription gameDescription1 = new GameDescription();
                gameDescription1.ReleaseYear = 2020;
                gameDescription1.Description = "DOOM Eternal от id Software — прямое продолжение хита DOOM, получившего награду «Лучший боевик» на церемонии The Game Awards 2016 года. Прорывайтесь сквозь измерения, сокрушая всё на своём пути с невероятной силой и скоростью. Эта игра задаёт новый стандарт для шутеров с видом от первого лица. Она создана на движке id Tech 7 и сопровождается взрывным саундтреком от композитора Мика Гордона. Хватайте мощное оружие и в роли Палача Рока отправляйтесь разносить в клочья новых и хорошо знакомых демонов, заполонивших неизведанные миры DOOM Eternal.";
                gameDescription1.Game = DoomGame;
                db.GameDescriptions.Add(gameDescription1); 

                db.Games.Add(DoomGame);
               

                //db.SaveChanges();
                // DoomGame.Platforms.AddRange(platformPCWin, platformSony4, platformSony5, platformXboxOne, platformXboxXS, platformNintendoSwitch);


                Game DivinityGame = new Game();
                DivinityGame.GameName = "Divinity: Original Sin II";
                DivPub.Games.Add(DivinityGame);
                DivDev.Games.Add(DivinityGame);
                DivinityGame.Genres.Add(genreRPG);
                DivinityGame.Genres.Add(genreFantasy);
                DivinityGame.Genres.Add(genreTactic);

                DivinityGame.Platforms.Add(platformPCWin);
                DivinityGame.Platforms.Add(platformSony4);
                DivinityGame.Platforms.Add(platformXboxOne);
                DivinityGame.Platforms.Add(platformNintendoSwitch);

               // db.Games.Add(DivinityGame);

                GameDescription DivDesc = new GameDescription();
                DivDesc.ReleaseYear = 2017;
                DivDesc.Description = "Божественный мертв. Пустота надвигается. А внутри вас просыпаются доселе неведомые силы. Битва за божественность началась. Тщательно выбирайте, кому верить: в эти непростые времена тьма может скрываться в каждом сердце.";
                DivDesc.Game = DivinityGame;
                db.GameDescriptions.Add(DivDesc);

                db.Games.Add(DivinityGame);

                db.SaveChanges();

            }

        }

    }
}
