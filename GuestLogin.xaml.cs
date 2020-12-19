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
    /// Interaction logic for GuestLogin.xaml
    /// </summary>
    public partial class GuestLogin : Window
    {
       
        public GuestLogin()
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


            
            if (username.Text != "" && phoneno.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PM9NGM3\SQLEXPRESS;Initial Catalog=PMS;Integrated Security=True");

                try
                {
                    con.Open();

                    string newcon = "insert into [GuestAuth] (UserName, PhoneNo) VALUES ('" + username.Text + "','" + phoneno.Text + "')";
                    SqlCommand cmd = new SqlCommand(newcon, con);

                    int a = Convert.ToInt32(cmd.ExecuteNonQuery());

                    if (a == 1)
                    {
                        //MessageBox.Show("Valid Crediential");

                        this.Hide();
                        string UserNam = username.Text.ToString();
                        CarAdd entry = new CarAdd(UserNam);
                        entry.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("invalid Crediental");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " something went wrong!");
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid crediential");
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
