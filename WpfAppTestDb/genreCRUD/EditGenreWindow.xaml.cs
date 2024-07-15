using MyLibDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAppTestDb.genreCRUD;

namespace WpfAppTestDb
{
    /// <summary>
    /// Логика взаимодействия для EditGenreWindow.xaml
    /// </summary>
    public partial class EditGenreWindow : Window
    {
        public EditGenreWindow()
        {
            InitializeComponent();
            GenreDataGridUpdate();
        }
        public void GenreDataGridUpdate()
        {
            genreDataGrid.ItemsSource = null;
            using (_TestContext db = new _TestContext())
            {
                List<Genre> dev = db.Genres.ToList();
                genreDataGrid.ItemsSource = dev;
            }
        }

        private void Button_ClickAddGenre(object sender, RoutedEventArgs e)
        {

            genreDialCU genreDialCU = new genreDialCU(true);
            genreDialCU.ShowDialog();
            GenreDataGridUpdate();
        }

        private void Button_ClickDelGenre(object sender, RoutedEventArgs e)
        {
            int i = genreDataGrid.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("select wrong item");
                return;
            }
            // var s = devDataGrid.Items.GetItemAt(1);
            Genre g = (Genre)genreDataGrid.Items.GetItemAt(i);
            MessageBox.Show("ID - " + g.Id + "Name - " + g.Name);
            string msg = "Точно удалить ID - " + g.Id + " Name - " + g.Name;

            YesNo yesNo = new YesNo(msg);
            if (yesNo.ShowDialog() == false)
            {
                //MessageBox.Show("no no");
                return;
            }

            CrudWpfControls.tempDel(g);
            GenreDataGridUpdate();
        }

        private void genreDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            int i = genreDataGrid.SelectedIndex;
            //var s = pubDataGrid.Items.GetItemAt(1);
            Genre g = (Genre)genreDataGrid.Items.GetItemAt(i);
            MessageBox.Show("get item " + "ID " + g.Id.ToString() + " Title " + g.Name.ToString());
            
            genreDialCU genreDialCU = new genreDialCU(false, g);
            genreDialCU.ShowDialog();
            GenreDataGridUpdate();
        }
    }
}
