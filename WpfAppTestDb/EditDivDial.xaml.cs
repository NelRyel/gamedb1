using MyLibDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppTestDb {
    /// <summary>
    /// Логика взаимодействия для EditDivDial.xaml
    /// </summary>
    public partial class EditDivDial : Window {
        int id;
        string newName = "";
        public EditDivDial(bool Click_DblClick, Developer? developer = null) {
            InitializeComponent();
            labelWinTitle.Content = (Click_DblClick == true) ? "Add new Developer" : "Edit Developer";
            if (Click_DblClick == true) 
            {
                btnOk.Click += Button_Click;
            }
            else {
                tbEditDev.Text = developer.Name;
                id = developer.Id;
                btnOk.Click += Button_ClickEdit;
            }

        }
        private void Button_ClickEdit(object sender, RoutedEventArgs e) {
            newName = tbEditDev.Text.ToString();
            if (CrudWpfControls.DevCompare(newName) == false) {
                MessageBox.Show(newName + " уже есть, или тоже самое имя");
                return;
            }
            //MessageBox.Show(newName);
            CrudWpfControls.EditDev(id, newName);
            Close();
            //MessageBox.Show("EDIT ");
           

        }
        private void Button_Click_Close(object sender, RoutedEventArgs e) {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            string newName = tbEditDev.Text;
            int ss = newName.Count();
            if (ss <= 2) {
                MessageBox.Show("имя должно быть больше двух символов");
                return;
            }

            if (CrudWpfControls.DevCompare(newName) == false) {
                MessageBox.Show(newName + " уже существует");
                return;
            }
            CrudWpfControls.AddDeveloper(newName);

            MessageBox.Show(newName + " added ");
            tbEditDev.Text = "";
            Close();
            //System.Windows.Forms.MessageBox.Show("ADD");
           

        }
    }
}
