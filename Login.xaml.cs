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
using System.Data;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for UserAuth.xaml
    /// </summary>
    public partial class Login : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public Login()
        {
            InitializeComponent();
        }

        private void Back_btn(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SignUp entry = new SignUp();
            entry.ShowDialog();
            this.Close();
        }

        private void Home_btn(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Entry entry = new Entry();
            entry.ShowDialog();
            this.Close();
        }

        private void sub_register(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SignUp entry = new SignUp();
            entry.ShowDialog();
            this.Close();
        }

        private void button_GoLogin(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PM9NGM3\SQLEXPRESS;Initial Catalog=PMS;Integrated Security=True");

            try
            {
                con.Open();

                string newcon = "select * from UserAuth where UserName='" + username.Text + "' and Password ='" + password.Password + "'";

                SqlDataAdapter adp = new SqlDataAdapter(newcon, con);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count >= 1)
                {

                    this.Hide();
                    string UserNam = username.Text.ToString();
                    CarAdd entry = new CarAdd(UserNam);
                    entry.ShowDialog();
                    this.Close();
                }
                else
                {
                    
                    MessageBox.Show("Invalid login Credential");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + " Something went wrong!");
            }
        }

        private void reset_button(object sender, RoutedEventArgs e)
        {
            username.Text = "";
            password.Password = "";
        }
    }
}
