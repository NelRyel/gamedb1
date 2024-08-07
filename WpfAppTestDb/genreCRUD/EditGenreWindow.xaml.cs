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
        List<Genre> genreList;
        public EditGenreWindow(bool ForEditGame = false)
        {
            InitializeComponent();
            
            genreDataGrid.MouseDoubleClick += (ForEditGame == true) ? genreDataGrid_MouseDoubleClickForGameEdit : genreDataGrid_MouseDoubleClick;
            if (ForEditGame == true) {
                genreList = new List<Genre>();
            }
            
            listBoxSelectedItems.Visibility = (ForEditGame == true) ? Visibility.Visible : Visibility.Hidden;
            stcPnlOkCancel.Visibility = (ForEditGame == true) ? Visibility.Visible : Visibility.Hidden;
            stackPanelTop.Height = (ForEditGame == true) ? 110 : 50;
            GenreDataGridUpdate();
        }
        public List<Genre> GetGenres() {
            return genreList;
        }
        public void GenreDataGridUpdate()
        {
            genreDataGrid.ItemsSource = null;
            using (_TestContext db = new _TestContext())
            {
                List<Genre> genres = db.Genres.ToList();
                genreDataGrid.ItemsSource = genres;
            }
        }

        private void listBoxSelectedItems_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            int i = listBoxSelectedItems.SelectedIndex;
            if(i == -1) {return; }
            string s = listBoxSelectedItems.Items.GetItemAt(i).ToString();
            //System.Windows.Forms.MessageBox.Show(s);
            string i2="";
            int iD=0;
            for (int j = 0; j < s.Length; j++) 
            {
                //System.Windows.Forms.MessageBox.Show(s[j].ToString());
                if (s[j] == '.') { break; }
                i2 += s[j];
                iD = Convert.ToInt32(i2);
            }
            Genre g = genreList.Where(x=>x.Id==iD).First();
            genreList.Remove(g);
            listBoxSelectedItems.Items.Clear();

            foreach (var item in genreList) {
                listBoxSelectedItems.Items.Add(item.Id + "." + item.Name);
            }
            //string ssss = g.Name.ToString();

            //System.Windows.Forms.MessageBox.Show(ssss);
            // System.Windows.Forms.MessageBox.Show(g.Name.ToString());
        }

        private void genreDataGrid_MouseDoubleClickForGameEdit(object sender, MouseButtonEventArgs e) {

            int i = genreDataGrid.SelectedIndex;
            if (i == -1) {
                return;
            }
            //var s = pubDataGrid.Items.GetItemAt(1);
            Genre g = (Genre)genreDataGrid.Items.GetItemAt(i);
            //MessageBox.Show("get item " + "ID " + g.Id.ToString() + " Title " + g.Name.ToString());
            foreach (var item in genreList) {
                if (item.Id == g.Id) {
                    System.Windows.Forms.MessageBox.Show(item.Name+" уже добавлено");
                    return; 
                }
            }
            genreList.Add(g);
            
            //string ss="";
            //foreach (var item in genreList) {
            //    ss += "ID " + item.Id + " Name " + item.Name+" // ";
                
            //}
            listBoxSelectedItems.Items.Add(g.Id+"."+g.Name);
            //System.Windows.Forms.MessageBox.Show(ss);
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbTitleChange == null)
            {
                return;
            }
            string title = tbTitleChange.Text;
            string id = tbIdChange.Text;
            genreDataGrid.ItemsSource = null;
            using (_TestContext db = new _TestContext())
            {
                //List<Developer> developers = db.Developers.Where(q => q.Name.Contains(title)).ToList();
                //List<Developer> developers = db.Developers.Where(q => q.Name.ToLower().Contains(title.ToLower())).ToList();
                List<Genre> items = db.Genres.Where(q => q.Id.ToString().ToLower().Contains(id)).Where(w => w.Name.ToLower().Contains(title.ToLower())).ToList();

                genreDataGrid.ItemsSource = items;

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

        private void Button_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            genreList.Clear();
            genreList = null;
            Close();
        }
    }
}
