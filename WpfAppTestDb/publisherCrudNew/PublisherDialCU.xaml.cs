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

namespace WpfAppTestDb.publisherCrudNew
{
    /// <summary>
    /// Логика взаимодействия для PublisherDialCU.xaml
    /// </summary>
    public partial class PublisherDialCU : Window
    {
        int id;
        string newName ="";
        public PublisherDialCU(bool Add_Edit, Publisher? pub = null)
        {
            InitializeComponent();
            labelWinTitle.Content = (Add_Edit == true) ? "Add New Publisher" : "Update Publisher";
            btnOk.Click += (Add_Edit == true) ? btnAddClic : btnEditClik;
            tbEditName.Text = (Add_Edit == true) ? "" : pub.Name;
            id = (Add_Edit == true) ? 0 : pub.Id;
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

            if (CrudWpfControls.PubCompare(newName) == false)
            {
                MessageBox.Show(newName + " уже существует");
                return;
            }
            CrudWpfControls.AddPublisher(newName);

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
            if (CrudWpfControls.PubCompare(newName) == false)
            {
                MessageBox.Show(newName + " уже есть, или тоже самое имя");
                return;
            }
            //MessageBox.Show(newName);
            CrudWpfControls.EditPublisher(id, newName);
            Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
