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
                Genre genre = new Genre { GenreName = "First-person shooter" };



            }

        }

    }
}
