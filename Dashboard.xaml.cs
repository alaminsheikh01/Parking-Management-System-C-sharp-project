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

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public Dashboard()
        {
            //d_name.Content = "Hi mr. " + UserNam;
            InitializeComponent();
            
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login entry = new Login();
            entry.ShowDialog();
            this.Close();
        }
    }
}
