using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        public AdminLogin()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void button_GoLogin(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PM9NGM3\SQLEXPRESS;Initial Catalog=PMS;Integrated Security=True");

            if (username.Text != "" && password.Password != "")
            {

                try
                {
                    con.Open();
                    string query = "select count(*) from [AdminAuth] where UserName= '" + username.Text + "' AND Password='" + password.Password + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int a = Convert.ToInt32(cmd.ExecuteScalar());

                    if(a == 1)
                    {
                        //MessageBox.Show("valid");
                        this.Hide();
                        Admin signup = new Admin();
                        signup.ShowDialog();
                        this.Close();
                    }


                    else
                    {
                        MessageBox.Show("Invalid");
                    } 
    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid Credientials");
            }
        }

        private void Back_btn(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Entry signup = new Entry();
            signup.ShowDialog();
            this.Close();
        }
    }
}
