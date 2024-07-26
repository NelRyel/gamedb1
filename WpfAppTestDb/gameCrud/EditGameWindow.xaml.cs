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
using WpfAppTestDb.publisherCrudNew;

namespace WpfAppTestDb.gameCrud
{
    /// <summary>
    /// Логика взаимодействия для EditGameWindow.xaml
    /// </summary>
    public partial class EditGameWindow : Window
    {
        Publisher pub;
        Developer dev;
        List<Platform> platforms;


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
            Game game = new Game();
            GameDescription description = new GameDescription();    
            string name = txtBoxName.Text;
            string decs = txtBoxDesc.Text;
            game.Name = txtBoxName.Text;
            description.Description = txtBoxDesc.Text;
            description.Publisher = pub;
            description.Developer = dev;
            description.Game= game;





            MessageBox.Show(name);
        }

        private void btnDelPub_Click(object sender, RoutedEventArgs e)
        {
            tbSelectedPub.Text = null;
            pub = null;
        }

        private void btnAddPub_Click(object sender, RoutedEventArgs e)
        {
            EditPubWindow editPubWindow = new EditPubWindow(true);
            editPubWindow.ShowDialog();

            if (editPubWindow.pp == null)
            {
                System.Windows.Forms.MessageBox.Show("wrong item pub");
                return;
            }
            pub = editPubWindow.pp;
            tbSelectedPub.Text = pub.Name;
        }

        private void btnAddDev_Click(object sender, RoutedEventArgs e)
        {
            EditDevWindow editDevWindow = new EditDevWindow(true);
            editDevWindow.ShowDialog();
            if(editDevWindow.developer == null)
            {
                System.Windows.Forms.MessageBox.Show("wrong item dev");
                return;
            }
            dev = editDevWindow.developer;
            tbSelectedDev.Text = dev.Name;

        }

        private void btnDelDev_Click(object sender, RoutedEventArgs e)
        {
            tbSelectedDev.Text = "";
            dev = null;
        }

        private void btnAddPlatform_Click(object sender, RoutedEventArgs e) {

        }

        private void btnAddGenre_Click(object sender, RoutedEventArgs e) {
            EditGenreWindow edit = new EditGenreWindow(true);
            edit.ShowDialog();
            
        }
    }
}
