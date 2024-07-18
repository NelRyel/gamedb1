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

namespace WpfAppTestDb.gameCrud
{
    /// <summary>
    /// Логика взаимодействия для EditGameWindow.xaml
    /// </summary>
    public partial class EditGameWindow : Window
    {
        public EditGameWindow()
        {
            InitializeComponent();
        }



        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string name = txtBoxName.Text;
            string decs = txtBoxDesc.Text;


            MessageBox.Show(name);
        }

        private void btnDelPub_Click(object sender, RoutedEventArgs e)
        {
            tbSelectedPub.Text = null;
        }

        private void btnAddPub_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
