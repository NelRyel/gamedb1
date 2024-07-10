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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppTestDb
{
    /// <summary>
    /// Логика взаимодействия для YesNo.xaml
    /// </summary>
    public partial class YesNo : Window
    {
        public YesNo(string msg="")
        {
            InitializeComponent();
            int i = msg.Count();
            mWind.Width += i*5;
            LabelMaybe.Text = msg ;

        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;

        }
    }
}
