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

namespace WpfAppTestDb.platformCrud
{
    /// <summary>
    /// Логика взаимодействия для PlatformCUdial.xaml
    /// </summary>
    public partial class PlatformCUdial : Window
    {
        int id;
        string newName;
        public PlatformCUdial(bool Add_Edit, Platform? plat = null)
        {
            InitializeComponent();
            labelWinTitle.Content = (Add_Edit == true) ? "Add New genre" : "Update genre";
            btnOk.Click += (Add_Edit == true) ? btnAddClic : btnEditClik;
            tbEditName.Text = (Add_Edit == true) ? "" : plat.Name;
            id = (Add_Edit == true) ? 0 : plat.Id;
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

            if (CrudWpfControls.PlatCompare(newName) == false)
            {
                MessageBox.Show(newName + " уже существует");
                return;
            }
            CrudWpfControls.AddPlatform(newName);

            MessageBox.Show(newName + " added ");
            tbEditName.Text = "";
            Close();
        }
        private void btnEditClik(object sender, RoutedEventArgs e)
        {
            newName = tbEditName.Text.ToString();
            int c = newName.Count();
            if (c <= 2)
            {
                MessageBox.Show("имя должно быть больше двух символов");
                return;
            }
            if (CrudWpfControls.PlatCompare(newName) == false)
            {
                MessageBox.Show(newName + " уже есть, или тоже самое имя");
                return;
            }
            //MessageBox.Show(newName);
            CrudWpfControls.EditPlatform(id, newName);
            Close();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
