using Microsoft.EntityFrameworkCore;
using MyLibDb;
using System.Text;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {

            InitializeComponent();

            using (_TestContext db = new _TestContext()) {

                //Game game = db.Games.Include(d => d.Genres).Include(g => g.Publisher).Include(g => g.Developer).Include(g => g.Platforms).Include(g => g.GameDescription).FirstOrDefault(g => g.Id == id);
                
                var data = db.GameDescriptions.Include(g => g.Game).Include(p => p.Publisher).Include(d => d.Developer).ToList();

                mainGameData.ItemsSource = data.FirstOrDefault().Game.Name;
                var dt = data.FirstOrDefault();
                // var data = db.Games.ToList();
                
              


               // mainGameData.ItemsSource = data;


            }

        }



    }
}