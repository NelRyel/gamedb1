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
using WpfAppTestDb.platformCrud;

namespace WpfAppTestDb.publisherCrudNew
{
    /// <summary>
    /// Логика взаимодействия для EditPubWindow.xaml
    /// </summary>
    public partial class EditPubWindow : Window
    {
        public EditPubWindow(bool ForEditGame = false)
        {
            InitializeComponent();
            //pubDataGrid.MouseDoubleClick += (ForEditGame == true) ? pubDataGrid_MouseDoubleClickForGameEdit : pubDataGrid_MouseDoubleClick;
            pubDataGrid.MouseDoubleClick += pubDataGrid_MouseDoubleClickForGameEdit;

            PubltDataGridUpdate();
        }

        private void pubDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int i = pubDataGrid.SelectedIndex;
            //var s = pubDataGrid.Items.GetItemAt(1);
            Publisher pub = (Publisher)pubDataGrid.Items.GetItemAt(i);
            MessageBox.Show("get item " + "ID " + pub.Id.ToString() + " Title " + pub.Name.ToString());

            PublisherDialCU publisherDial = new PublisherDialCU(false, pub);
            publisherDial.ShowDialog();
            PubltDataGridUpdate();
        }

        private Publisher pubDataGrid_MouseDoubleClickForGameEdit(object sender, MouseButtonEventArgs e)
        {
            int i = pubDataGrid.SelectedIndex;
            //var s = pubDataGrid.Items.GetItemAt(1);
            Publisher pub = (Publisher)pubDataGrid.Items.GetItemAt(i);
            MessageBox.Show("get item " + "ID " + pub.Id.ToString() + " Title " + pub.Name.ToString());
            Close();
            return pub;
            
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PublisherDialCU publisherDial = new PublisherDialCU(true);
            publisherDial.ShowDialog();
            PubltDataGridUpdate();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            int i = pubDataGrid.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("select wrong item");
                return;
            }
            Publisher p = (Publisher)pubDataGrid.Items.GetItemAt(i);
            string msg = "Точно удалить ID - " + p.Id + " Name - " + p.Name;

            YesNo yesNo = new YesNo(msg);
            if (yesNo.ShowDialog() == false)
            {
                //MessageBox.Show("no no");
                return;
            }

            CrudWpfControls.tempDel(p);
            PubltDataGridUpdate();
        }

        public void PubltDataGridUpdate()
        {
            pubDataGrid.ItemsSource = null;
            using (_TestContext db = new _TestContext())
            {
                List<Publisher> pub = db.Publishers.ToList();
                pubDataGrid.ItemsSource = pub;
            }
        }
    }
}
