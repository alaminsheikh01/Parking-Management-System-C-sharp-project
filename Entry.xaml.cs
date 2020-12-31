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
    /// Interaction logic for Entry.xaml
    /// </summary>
    public partial class Entry : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public Entry()
        {
            InitializeComponent();
            
        }

        private void U_stuff_btn(object sender, EventArgs e)
        {
            this.Hide();
            SignUp signup = new SignUp();
            signup.ShowDialog();
            this.Close();

        }


        //private void Guest_btn(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    SignUp signup = new SignUp();
        //    signup.ShowDialog();
        //    this.Close();

        //}

        private void Admin_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminLogin signup = new AdminLogin();
            signup.ShowDialog();
            this.Close();
        }

        private void Guest_btn(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GuestLogin signup = new GuestLogin();
            signup.ShowDialog();
            this.Close();
        }
    }
}
