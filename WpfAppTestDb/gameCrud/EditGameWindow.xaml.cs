using MyLibDb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        List<Genre> genres;
        List<Platform> platforms;


        public EditGameWindow(bool IsForEdit = false)
        {
            InitializeComponent();
            //IEnumerable<Button> collection = MainEditGameGrid.Children.OfType<Button>();
            //foreach (var item in collection) {
            //    System.Windows.Forms.MessageBox.Show(item.Content.ToString());
            //}
            //int i = collection.Count();
            //System.Windows.Forms.MessageBox.Show(i.ToString());



        }



        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game();
            GameDescription description = new GameDescription();    
            //string name = txtBoxName.Text;
            //string decs = txtBoxDesc.Text;

            game.GameDescription = description;
            description.Game = game;

            game.Name = txtBoxName.Text;
            description.ReleaseYear = Convert.ToInt32(tbRelYear.Text);
            description.Description = txtBoxDesc.Text;
            description.Publisher = pub;
            description.Developer = dev;
            description.PublisherId = pub.Id;
            description.DeveloperId = dev.Id;
          
            description.Genres = genres;
            description.Platforms = platforms;
            CrudWpfControls.AddGame(game, description);
            Close();

            //string s = "";
            //foreach (var item in game.GameDescription.Platforms) {
            //    s += item.Name + "/"+ Environment.NewLine;
            //}

            //System.Windows.Forms.MessageBox.Show(s);


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
            EditPlatformWindow editPlatformWindow = new EditPlatformWindow(true);
            editPlatformWindow.ShowDialog();
            platforms = editPlatformWindow.GetPlatforms();
            if (platforms == null) { return; }
            dtGrdPlat.ItemsSource = platforms;
        }

        private void btnAddGenre_Click(object sender, RoutedEventArgs e) {
            EditGenreWindow edit = new EditGenreWindow(true);
            edit.ShowDialog();
            genres = edit.GetGenres();
            if (genres == null) { return; } 
            //foreach (var item in genres) {
            //    System.Windows.Forms.MessageBox.Show(item.Name);
            //}
            dtGrdGenre.ItemsSource = genres;


        }

        private void btnDelGenre_Click(object sender, RoutedEventArgs e) {
            dtGrdGenre.ItemsSource = null;
        }

        private void btnDelPlatform_Click(object sender, RoutedEventArgs e) {
            dtGrdPlat.ItemsSource = null;
        }

        private void tbRelYear_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            CheckIsNum(e);
        }

        private void CheckIsNum(TextCompositionEventArgs e) {
            int result;

            if (!(int.TryParse(e.Text, out result) || e.Text == ".")) {
                e.Handled = true;
            }
        }

        private void btnTestBtn_Click(object sender, RoutedEventArgs e) {
            //var rr = EditWind.GetTemplateChild;
            //btnAddGenre.Visibility = Visibility.Hidden;
            EditGameWindow edit = new EditGameWindow();
            var ee = "";
            //int ii = VisualTreeHelper.GetChildrenCount(edit);
            IEnumerable<StackPanel> collection = MainEditGameGrid.Children.OfType<StackPanel>();
            //Button childVisual = (Button)VisualTreeHelper.GetChild(edit, 1);
            //foreach (var item in collection) {
            //    System.Windows.Forms.MessageBox.Show(item.);
            //}
            //int i = collection.Count();
            foreach (var item in collection) {
                IEnumerable<Button> buttons = item.Children.OfType<Button>();
            }
            System.Windows.Forms.MessageBox.Show(collection.Count().ToString());
            Some = false;

        }
        private bool some = true;

        public bool Some {
            get { return some; }
            set { some = value; }
        }

        

    }
}
