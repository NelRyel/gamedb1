using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibDb
{
    public static class __DefaultInit
    {
        public static void OnStart()
        {
            using (_TestContext db = new _TestContext())
            {
                Genre genreFPS = new Genre {  Name = "First-person" };
                Genre genreTPS = new Genre {  Name = "Third-person" };
                Genre genreShouter = new Genre { Name = "Shouter" };
                Genre genreRPG = new Genre { Name = "RPG" };
                Genre genreStrategy = new Genre {Name = "Strategy" };
                Genre genreTactic = new Genre {  Name = "Tactics" };
                Genre genreFantasy = new Genre {  Name = "Fantasy" };

                db.Genres.AddRange(genreFantasy,genreFPS,genreRPG,genreShouter,genreStrategy,genreTactic,genreTPS);

                Publisher DoomPub = new Publisher { Name = "Bethesda Softworks" };
                db.Publishers.Add(DoomPub);

                Publisher DivPub = new Publisher { Name = "Larian Studios" };
                db.Publishers.Add(DivPub);

                Developer DivDev = new Developer { Name = "Larian Studios" };
                db.Developers.Add(DivDev);

                Developer DooDev = new Developer { Name = "id Software" };
                db.Developers.Add(DooDev);

                Platform platformPCWin = new Platform { Name = "Windows" };

                Platform platformSony1 = new Platform { Name = "PlayStation One" };
                Platform platformSony2 = new Platform { Name = "PlayStation 2" };
                Platform platformSony3 = new Platform { Name = "PlayStation 3" };
                Platform platformSony4 = new Platform { Name = "PlayStation 4" };
                Platform platformSony5 = new Platform { Name = "PlayStation 5" };

                Platform platformXbox = new Platform { Name = "XBox" };
                Platform platformXbox360 = new Platform { Name = "XBox360" };
                Platform platformXboxOne = new Platform { Name = "XBox One" };
                Platform platformXboxXS = new Platform { Name = "XBox Series" };

                Platform platformNintendoSwitch = new Platform { Name = "Nintendo Switch" };
                Platform platformNintendoWiiU = new Platform { Name = "Nintendo Wii U" };

                db.Platforms.AddRange(platformNintendoSwitch, platformNintendoWiiU, platformPCWin, platformSony1, platformSony2, platformSony3, platformSony4, platformSony5, platformXbox, platformXbox360, platformXboxOne, platformXboxXS);

                Game DoomGame = new Game();
                DoomGame.Name = "DOOM Eternal";

                db.Games.Add(DoomGame);

               GameDescription DoomDesc = new GameDescription();
                DoomDesc.Description = "DOOM Eternal от id Software — прямое продолжение хита DOOM, получившего награду «Лучший боевик» на церемонии T" +
                    "he Game Awards 2016 года. Прорывайтесь сквозь измерения, сокрушая всё на своём пути с невероятной силой и скоростью. " +
                    "Эта игра задаёт новый стандарт для шутеров с видом от первого лица. Она создана на движке id Tech 7 и " +
                    "сопровождается взрывным саундтреком от композитора Мика Гордона. Хватайте мощное оружие и в роли Палача Рока " +
                    "отправляйтесь разносить в клочья новых и хорошо знакомых демонов, заполонивших неизведанные миры DOOM Eternal.";
                DoomDesc.ReleaseYear = 2020;
                DoomDesc.Game = DoomGame;
                DoomPub.GameDescriptions.Add(DoomDesc);
                DooDev.GameDescriptions.Add(DoomDesc);
                DoomDesc.Genres.Add(genreFPS);
                DoomDesc.Genres.Add(genreShouter);

                DoomDesc.Platforms.Add(platformPCWin);
                DoomDesc.Platforms.Add(platformSony4);
                DoomDesc.Platforms.Add(platformSony5);
                DoomDesc.Platforms.Add(platformXboxOne);
                DoomDesc.Platforms.Add(platformXboxXS);
                DoomDesc.Platforms.Add(platformNintendoSwitch);


                db.GameDescriptions.Add(DoomDesc);
           
                


                db.SaveChanges();
            }
        }

    }
}
