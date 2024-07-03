﻿using MyLibDb;
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
    /// Логика взаимодействия для EditDevWindow.xaml
    /// </summary>
    public partial class EditDevWindow : Window {
        public EditDevWindow() {
            InitializeComponent();
            DevDataGridUpdate();
        }





        public void DevDataGridUpdate() {
            devDataGrid.ItemsSource = null;
            using (_TestContext db = new _TestContext()) {
                List<Developer> dev = db.Developers.ToList();
                devDataGrid.ItemsSource = dev;
            }
        }

        private void Button_ClickDel(object sender, RoutedEventArgs e) {
            int i = devDataGrid.SelectedIndex;
            if (i == -1) {
                MessageBox.Show("select wrong item");
                return;
            }
           // var s = devDataGrid.Items.GetItemAt(1);
            Developer dev = (Developer)devDataGrid.Items.GetItemAt(i);
            MessageBox.Show("ID - "+dev.Id+"Name - "+dev.Name);
            CrudWpfControls.tempDel(dev);
            DevDataGridUpdate();
        }

        private void Button_ClickAdd(object sender, RoutedEventArgs e) {
            bool Click_DblClick = true;
            EditDivDial editDivDial = new EditDivDial(Click_DblClick);
            editDivDial.ShowDialog();
            DevDataGridUpdate();

        }

        private void devDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            bool Click_DblClick = false;

            int i = devDataGrid.SelectedIndex;
            //var s = pubDataGrid.Items.GetItemAt(1);
            Developer dev = (Developer)devDataGrid.Items.GetItemAt(i);
            MessageBox.Show("get item "+"ID " + dev.Id.ToString() +" Title " + dev.Name.ToString());
            EditDivDial editDivDial = new EditDivDial(Click_DblClick, dev);
            editDivDial.ShowDialog();
            DevDataGridUpdate();

            //PublisherEditWindow editWindow = new PublisherEditWindow(pub);
            //editWindow.ShowDialog();
            //pubDataGridUpdate();


        }
    }
}
