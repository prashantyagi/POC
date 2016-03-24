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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Product_Click(object sender, RoutedEventArgs e)
        {
            ShowControl(sender as UserControl);
        }

        private void MenuItem_Client_Click(object sender, RoutedEventArgs e)
        {
            ShowControl(sender as UserControl);
        }

        private void MenuItem_Invoice_Click(object sender, RoutedEventArgs e)
        {
            ShowControl(sender as UserControl);
        }

        private void ShowControl(UserControl control)
        {
            if (control != null)
            {
                indexControl.Visibility = Visibility.Hidden;
                invoiceControl.Visibility = Visibility.Hidden;

                control.Visibility = Visibility.Visible;
            }
        }
    }
}
