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
    /// Логика взаимодействия для PublisherEditWindow.xaml
    /// </summary>
    public partial class PublisherEditWindow : Window {
        int id;
        string newName;
        public PublisherEditWindow(Publisher publisher) {
            InitializeComponent();
            id = publisher.Id;
            labelOldName.Content = "id - " + publisher.Id.ToString()+"; Title - "+publisher.Name.ToString();
            tbEditPub.Text = publisher.Name;

        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e) {

            

            using (_TestContext db = new _TestContext()) {
                Publisher p = db.Publishers.Find(id);

            
            }

        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
