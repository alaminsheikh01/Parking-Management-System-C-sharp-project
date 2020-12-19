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
using System.Data.SqlClient;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        string userError;
        string phoneError;
        string passError;

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public SignUp()
        {
            InitializeComponent();
        }

        private void Back_btn(object sender, EventArgs e)
        {
            this.Hide();
            Entry entry = new Entry();
            entry.ShowDialog();
            this.Close();
        }

        private void sub_login(object sender, EventArgs e)
        {
            this.Hide();
            Login entry = new Login();
            entry.ShowDialog();
            this.Close();
        }

        private void button_GoSignUp(object sender, RoutedEventArgs e)
        {

            if(username.Text == "")
            {
                userError = "UserName is Required";
                Uname.Content = userError;
            }
            else
            {
                Uname.Content = "";
            }
            if(phoneno.Text == "")
            {
                phoneError = "Phone no is required";
                Uphone.Content = phoneError;
            }
            else
            {
                Uphone.Content = "";
            }
            if(password.Password == "")
            {
                passError = "Password is required";
                Upass.Content = passError;
            }
            else
            {
                Upass.Content = "";
            }
            if (username.Text != "" && phoneno.Text != "" && password.Password != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PM9NGM3\SQLEXPRESS;Initial Catalog=PMS;Integrated Security=True");

                try
                {
                    con.Open();

                    string newcon = "insert into [UserAuth] (UserName, PhoneNo, Password) VALUES ('" + username.Text + "','" + phoneno.Text + "','" + password.Password + "')";
                    SqlCommand cmd = new SqlCommand(newcon, con);

                    int a = Convert.ToInt32(cmd.ExecuteNonQuery());

                    if (a == 1)
                    {
                        //MessageBox.Show("Valid Crediential");

                        this.Hide();
                        Login entry = new Login();
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

        }

        private void btn_reset(object sender, RoutedEventArgs e)
        {
            username.Text = "";
            phoneno.Text = "";
            password.Password = "";
        }
    }
}
