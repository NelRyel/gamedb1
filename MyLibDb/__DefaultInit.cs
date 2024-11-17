using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibDb
{
    public static class __DefaultInit
    {
        /*Базовое заполнение БД. Сделал больше для тестов. Запускается вручную, тупо, вручную в Мэйне, есть закоментированная эта штука, мне было лень делать проверки, на есть или нет БД
        т.е. если запустится приложение и там пусто, то раскоментируй в мэйне и перезапустить. 
         Но на примере этого я могу рассказать как работать с БД
         */
        public static void OnStart()
        {
            using (_TestContext db = new _TestContext())/*Собственно с этого у нас начинается подключение, с создания обьекта Контекста. Есть несколько путей, но я люблю через Юзинг, 
                                                          это просто проще, юзинг сам закроет подключение, и всё что может быть связано. В то время как если просто создать обьект Контекста
                                                          ему нужно откртыть подключение, сделать манипуляции с базой и закрыть подключние. Если это пропустить то будут баги*/
            {
                Genre genreFPS = new Genre {  Name = "First-person" }; //создаём обьекты жанров, давая им значение
                Genre genreTPS = new Genre {  Name = "Third-person" };
                Genre genreShouter = new Genre { Name = "Shouter" };
                Genre genreRPG = new Genre { Name = "RPG" };
                Genre genreStrategy = new Genre {Name = "Strategy" };
                Genre genreTactic = new Genre {  Name = "Tactics" };
                Genre genreFantasy = new Genre {  Name = "Fantasy" };

                db.Genres.AddRange(genreFantasy,genreFPS,genreRPG,genreShouter,genreStrategy,genreTactic,genreTPS); //через обьект Контекста обращаемся к базе добавляя обьекты. 

                Publisher DoomPub = new Publisher { Name = "Bethesda Softworks" }; //тоже самое с отальными обьектами
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

                //тут начинается часть посложнее

                Game DoomGame = new Game(); //создаём игру
                DoomGame.Name = "DOOM Eternal";

                db.Games.Add(DoomGame);//добавляем 

               GameDescription DoomDesc = new GameDescription();//создаем описание игры, которое собственно хранит всю инфу о игре, и связано с игрой один-ко-однму.
                DoomDesc.Description = "DOOM Eternal от id Software — прямое продолжение хита DOOM, получившего награду «Лучший боевик» на церемонии T" +
                    "he Game Awards 2016 года. Прорывайтесь сквозь измерения, сокрушая всё на своём пути с невероятной силой и скоростью. " +
                    "Эта игра задаёт новый стандарт для шутеров с видом от первого лица. Она создана на движке id Tech 7 и " +
                    "сопровождается взрывным саундтреком от композитора Мика Гордона. Хватайте мощное оружие и в роли Палача Рока " +
                    "отправляйтесь разносить в клочья новых и хорошо знакомых демонов, заполонивших неизведанные миры DOOM Eternal.";
                DoomDesc.ReleaseYear = 2020;
                DoomDesc.Game = DoomGame;       //и вот таким хитрым макаром, как бы через обьект описания, обращаемся к Игре, и приравниваем её обьекту игры. так мы их связали

                DoomPub.GameDescriptions.Add(DoomDesc); //тут с другой стороны подход. через обьект Паблишера обращаемся к описанию игры и прикрепляем к нему описание игры. 
                DooDev.GameDescriptions.Add(DoomDesc);

                // а от сюда начинается добавление того, что один через многие-ко-многим 
                DoomDesc.Genres.Add(genreFPS);
                DoomDesc.Genres.Add(genreShouter);

                DoomDesc.Platforms.Add(platformPCWin);
                DoomDesc.Platforms.Add(platformSony4);
                DoomDesc.Platforms.Add(platformSony5);
                DoomDesc.Platforms.Add(platformXboxOne);
                DoomDesc.Platforms.Add(platformXboxXS);
                DoomDesc.Platforms.Add(platformNintendoSwitch);


                db.GameDescriptions.Add(DoomDesc); //не забываем добавить в базу заполненное описание 
           
                


                db.SaveChanges(); // И САМОЕ главное, сохраняем состояние. Т.е. эта штука отрабатывает ещё и как Транзакция, т.е. если что-то идёт не так, 
                                // не будет такого, что пол инфы записалось, а другая потерялась. 
                                //ну и по окончаниюю Юзинга оно закрывает подключение.
            }
        }

    }
}
