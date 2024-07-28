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
    /// Логика взаимодействия для EditPlatformWindow.xaml
    /// </summary>
    public partial class EditPlatformWindow : Window
    {
        List<Platform> platforms;
        public EditPlatformWindow(bool ForEditGame = false)
        {
            InitializeComponent();
            pltDataGrid.MouseDoubleClick += (ForEditGame == true) ? pltDataGrid_MouseDoubleClickForGameEdit : pltDataGrid_MouseDoubleClick;
            listBoxSelectedItems.Visibility = (ForEditGame == true) ? Visibility.Visible : Visibility.Hidden;
            stcPnlOkCancel.Visibility = (ForEditGame == true) ? Visibility.Visible : Visibility.Hidden;
            if(ForEditGame == true) {
                platforms = new List<Platform>();
            }
            PlatDataGridUpdate();
        }
        public List<Platform> GetPlatforms() {
            return platforms;
        }

        private void pltDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
                int i = pltDataGrid.SelectedIndex;
                if (i == -1)
                {
                    return;
                }
                //var s = pubDataGrid.Items.GetItemAt(1);
                Platform plt = (Platform)pltDataGrid.Items.GetItemAt(i);
                MessageBox.Show("get item " + "ID " + plt.Id.ToString() + " Title " + plt.Name.ToString());

                PlatformCUdial platformCUdial = new PlatformCUdial(false, plt);
                platformCUdial.ShowDialog();
                PlatDataGridUpdate();
            
          
        }
        private void pltDataGrid_MouseDoubleClickForGameEdit(object sender, MouseButtonEventArgs e) {

            int i = pltDataGrid.SelectedIndex;
            if (i == -1) {
                return;
            }
            //var s = pubDataGrid.Items.GetItemAt(1);
            Platform plt = (Platform)pltDataGrid.Items.GetItemAt(i);
            foreach (var item in platforms) {
                if (item.Id == plt.Id) {
                    System.Windows.Forms.MessageBox.Show(item.Name+"уже добавлено");
                    return;
                }
            }
            platforms.Add(plt);
            listBoxSelectedItems.Items.Add(plt.Id + "." + plt.Name);
            //MessageBox.Show("get item " + "ID " + plt.Id.ToString() + " Title " + plt.Name.ToString());

            //PlatformCUdial platformCUdial = new PlatformCUdial(false, plt);
            //ShowDialog();
            //PlatDataGridUpdate();


        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PlatformCUdial platformCUdial = new PlatformCUdial(true);
            platformCUdial.ShowDialog();
            PlatDataGridUpdate();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            int i = pltDataGrid.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("select wrong item");
                return;
            }
            Platform p = (Platform)pltDataGrid.Items.GetItemAt(i);
            string msg = "Точно удалить ID - " + p.Id + " Name - " + p.Name;

            YesNo yesNo = new YesNo(msg);
           if(yesNo.ShowDialog() == false)
            {
                //MessageBox.Show("no no");
                return;
            }

            CrudWpfControls.tempDel(p);
            PlatDataGridUpdate();
        }
        public void PlatDataGridUpdate()
        {
            pltDataGrid.ItemsSource = null;
            using (_TestContext db = new _TestContext())
            {
                List<Platform> plt = db.Platforms.ToList();
                pltDataGrid.ItemsSource = plt;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbTitleChange == null)
            {
                return;
            }
            string title = tbTitleChange.Text;
            string id = tbIdChange.Text;
            pltDataGrid.ItemsSource = null;
            using (_TestContext db = new _TestContext())
            {
                //List<Developer> developers = db.Developers.Where(q => q.Name.Contains(title)).ToList();
                //List<Developer> developers = db.Developers.Where(q => q.Name.ToLower().Contains(title.ToLower())).ToList();
                List<Platform> items = db.Platforms.Where(q => q.Id.ToString().ToLower().Contains(id)).Where(w => w.Name.ToLower().Contains(title.ToLower())).ToList();

                pltDataGrid.ItemsSource = items;

            }

        }

        private void listBoxSelectedItems_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            int i = listBoxSelectedItems.SelectedIndex;
            if(i == -1) { return; }
            string s = listBoxSelectedItems.Items.GetItemAt(i).ToString();
            string s2 = "";
            int iD = 0;
            for (int j = 0; j < s.Length; j++) {
                if (s[j] == '.') { break; }
                s2+= s[j];
                iD = Convert.ToInt32(s2);
            }
            Platform p = platforms.Where(x => x.Id == iD).First();
            platforms.Remove(p);
            listBoxSelectedItems.Items.Clear();
            foreach (var item in platforms) {
                listBoxSelectedItems.Items.Add(item.Id + "." + item.Name);
            }

        }

        private void btnOk_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            platforms.Clear();
            platforms = null;
            Close();
        }
    }
}
