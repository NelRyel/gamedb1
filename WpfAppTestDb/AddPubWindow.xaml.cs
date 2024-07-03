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

namespace WpfAppTestDb {
    /// <summary>
    /// Логика взаимодействия для AddPubWindow.xaml
    /// </summary>
    public partial class AddPubWindow : Window {
        public AddPubWindow() {
            InitializeComponent();
            pubDataGridUpdate();
        }

        public void pubDataGridUpdate() {
            pubDataGrid.ItemsSource = null;
            using (_TestContext db = new _TestContext()) {
                List<Publisher> publisher = db.Publishers.ToList();
                pubDataGrid.ItemsSource = publisher;
            }
        }
       

        private void btnPubAdd_Click(object sender, RoutedEventArgs e) {
           
            string pubName = tbPub.Text.ToString();
            int ss = pubName.Count();
            if (ss <= 2) { 
                MessageBox.Show("имя должно быть больше двух символов");
                return;
            }
           
                if (CrudWpfControls.PubCompare(pubName) == false) {
                    MessageBox.Show(pubName + " уже существует");
                    return;
                }
                CrudWpfControls.AddPublisher(pubName);

            MessageBox.Show(pubName + " added ");
            tbPub.Text = "";
            pubDataGridUpdate();
        }

        private void pubDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            int i = pubDataGrid.SelectedIndex;
            //var s = pubDataGrid.Items.GetItemAt(1);
            Publisher pub = (Publisher)pubDataGrid.Items.GetItemAt(i);
            //MessageBox.Show("get item "+"ID " + pub.Id.ToString() +"Title " + pub.Name.ToString());
            PublisherEditWindow editWindow = new PublisherEditWindow(pub);
            editWindow.ShowDialog();
            pubDataGridUpdate();


           // MessageBox.Show("index "+i.ToString());
        }

        private void btnDelPub_Click(object sender, RoutedEventArgs e)
        {
            int i = pubDataGrid.SelectedIndex;
            if (i == -1) {
                MessageBox.Show("select wrong item");
                return;
            }
            var s = pubDataGrid.Items.GetItemAt(1);
            Publisher pub = (Publisher)pubDataGrid.Items.GetItemAt(i);
            CrudWpfControls.tempDel(pub);
            pubDataGridUpdate();

        }
    }
}
