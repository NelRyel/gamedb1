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
using static System.Windows.Forms.LinkLabel;

namespace WpfAppTestDb {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {

            


            InitializeComponent();

            UpdaterDataGrid();

            using (_TestContext db = new _TestContext()) {

                //Game game = db.Games.Include(d => d.Genres).Include(g => g.Publisher).Include(g => g.Developer).Include(g => g.Platforms).Include(g => g.GameDescription).FirstOrDefault(g => g.Id == id);

               // var data = db.GameDescriptions.Include(g => g.Game).Include(p => p.Publisher).Include(d => d.Developer).ToList();
                // var data = db.Games.ToList();
                // mainGameData.ItemsSource = data;
                //var dt = data.FirstOrDefault();
                // var data = db.Games.ToList();


                //var lin = from l in db.GameDescriptions join gg in db.Games on l.GameId equals gg.Id select new { Id = gg.Id, Name = gg.Name, Desc = l.Description };
                //mainGameData.ItemsSource = lin.ToList();



                //var datasTest = new[] 
                //{ 
                //     new {name = "Tt"}
                //}; анонимный массив




                //var dataD = db.GameDescriptions.Include(g => g.Game).Include(p => p.Publisher).Include(d => d.Developer).ToList();
                //var gridData = new {Id = dataD.Id, Title = dataD.Game.Name, Desc = dataD.Description, Dev = dataD.Developer.Name, Publ = dataD.Publisher.Name };

                //MessageBox.Show(gridData.ToString());

                //mainGameData.ItemsSource = data;


            }

        }

        public void UpdaterDataGrid() {
            mainGameData.ItemsSource = null;
            using (_TestContext db = new _TestContext()) {

                var lin = from l in db.GameDescriptions join gg in db.Games on l.GameId equals gg.Id select new { Id = gg.Id, Name = gg.Name, Desc = l.Description };
                mainGameData.ItemsSource = lin.ToList();
                //return lin.ToList();

            }
        }

        private void Button_ClickAddPub(object sender, RoutedEventArgs e) {
            AddPubWindow addPubWindow = new AddPubWindow();
            addPubWindow.Owner =   this;
            addPubWindow.Show();

        }

        private void Button_Click_Dev(object sender, RoutedEventArgs e) {
            EditDevWindow editDevWindow = new EditDevWindow();
            editDevWindow.Owner = this;
            editDevWindow.Show();

        }

        private void Button_Click_Genre(object sender, RoutedEventArgs e)
        {

        }
    }
}