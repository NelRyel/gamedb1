using Microsoft.VisualBasic;
using MyLibDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfAppTestDb {
    public  class UpdateDataGrid {

       
        public void uuUpdaterDataGrid() {
            //MainWindow m = new MainWindow();
            using (_TestContext db = new _TestContext()) {

                var lin = from l in db.GameDescriptions join gg in db.Games on l.GameId equals gg.Id select new { Id = gg.Id, Name = gg.Name, Desc = l.Description };
                //mainGameData.ItemsSource = lin.ToList();
                //return lin.ToList();

            }
        }
    }
}

