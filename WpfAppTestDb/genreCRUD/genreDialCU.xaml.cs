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

namespace WpfAppTestDb.genreCRUD
{
    /// <summary>
    /// Логика взаимодействия для genreDialCU.xaml
    /// </summary>
    public partial class genreDialCU : Window

    {
        string NewName="";
        int id = 0;
        public genreDialCU(bool Add_Edit, Genre? genre = null)
        {
            InitializeComponent();
            labelWinTitle.Content = (Add_Edit == true) ? "Add New genre" : "Update genre";
            btnOk.Click += (Add_Edit==true)?btnAddClic:btnEditClik;
            tbEditName.Text = (Add_Edit==true) ? "" : genre.Name;
            id = (Add_Edit == true) ? 0: genre.Id;
            
            //if(Add_Edit==true)
            //{
            //    labelWinTitle.Content = "Add new genre";
              
            //}
            //else
            //{
            //    labelWinTitle.Content = "Update genre";

            //}


        }

     

        private void btnAddClic(object sender, RoutedEventArgs e)
        {
            string newName = tbEditName.Text;
            int ss = newName.Count();
            if (ss <= 2)
            {
                MessageBox.Show("имя должно быть больше двух символов");
                return;
            }

            if (CrudWpfControls.GenreCompare(newName) == false)
            {
                MessageBox.Show(newName + " уже существует");
                return;
            }
            CrudWpfControls.AddGenre(newName);

            MessageBox.Show(newName + " added ");
            tbEditName.Text = "";
            Close();
          

        }
        private void btnEditClik(object sender, RoutedEventArgs e)
        {

            NewName = tbEditName.Text.ToString();
            int c = NewName.Count();
            if(c <= 2)
            {
                MessageBox.Show("имя должно быть больше двух символов");
                return;
            }
            if (CrudWpfControls.GenreCompare(NewName) == false)
            {
                MessageBox.Show(NewName + " уже есть, или тоже самое имя");
                return;
            }
            //MessageBox.Show(newName);
            CrudWpfControls.EditGenre(id, NewName);
            Close();
            //MessageBox.Show("EDIT ");

            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
