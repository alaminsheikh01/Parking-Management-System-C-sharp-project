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
using Castle.MicroKernel.Registration;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for CarAdd.xaml
    /// </summary>
    public partial class CarAdd : Window
    {
        public CarAdd(string Uname)
        {
            InitializeComponent();
            UserNamenext.Content = "UserName:  " +Uname;
            //slot_book.Text = slotone;
            intime.IsEnabled = false;
            txtduration.IsEnabled = false;
            txtpayment.IsEnabled = false;
            save.IsEnabled = false;
            //BindataUserName();
            TimeUpdater1();
            Bindata(); // sob gula data show table a show korbe
            TimeUpdater();



        }
         void TimeUpdater()
        {

            intime.Text = DateTime.Now.ToString();
            outtime.Text = DateTime.Now.ToString();
            Task.Delay(1000);

        }
        async void TimeUpdater1()
        {
            while (true)
            {
               timeUp.Content = DateTime.Now.ToString();
               
                await Task.Delay(1000);
            }
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PM9NGM3\SQLEXPRESS;Initial Catalog=PMS;Integrated Security=True");

        private void save_Click(object sender, RoutedEventArgs e)
        {

            if (carid.Text != "" && cartype.Text != "" && model.Text != "" && intime.Text!="" && outtime.Text!="" && slotgroup.Text!="")
            {

                try
                {
                    con.Open();
                    BindataUserName();
                    string newcon = "insert into CarAdd  ( carid, cartype, carmodel, duration, payment, slot_book, insertdate)  values  ('" + carid.Text + "','" + cartype.Text + "','" + model.Text + "', '" +txtduration.Text+ "','" +txtpayment.Text+ "','"+ slotgroup.Text + "' ,getdate())";
                    SqlCommand cmd = new SqlCommand(newcon, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully inserted");
                    Bindata();
                    
                    //TimeShow();



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
                MessageBox.Show("Invalid crediential");
            }

        }

        void BindataUserName()
        {
            SqlCommand cmd = new SqlCommand("select UserName from UserAuth where UserName='UserName'", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            //UserNamenext.Content = dt.DefaultView;

        }
      

        void Bindata()
        {
            SqlCommand cmd = new SqlCommand("select * from CarAdd", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.ItemsSource = dt.DefaultView;
            
        }
        
        private void search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (carid.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select * from CarAdd where carid='" + carid.Text+"'", con);
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    dataGridView1.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("Please enter carid");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void slot4_Selected(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select slot_book from CarAdd where slot_book = ");
            //select slot_book from CarAdd where slot_book = Slot 1

        }

        private void logout(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login entry = new Login();
            entry.ShowDialog();
            this.Close();
        }

        private void calPayment(object sender, RoutedEventArgs e)
        {
            DateTime dtintime = DateTime.Parse(intime.Text);
            DateTime dtouttime = DateTime.Parse(outtime.Text);

            float duration = float.Parse((dtouttime - dtintime).TotalMinutes.ToString());
            var span = System.TimeSpan.FromMinutes(duration);
            var hour = ((int)span.TotalHours).ToString();
            var Minute = span.Minutes.ToString();
            txtduration.Text = hour + " Hour: " + "" + Minute + " Min";
            if ((duration / 60) > 0)
            {
                if ((duration / 60) <= 0.5)
                {
                    txtpayment.Text = "" + 0 + "$";
                }
                else
                {
                    txtpayment.Text = "" + (duration / 60) * 1 + "$";
                }
            }
            save.IsEnabled = true;
        }

        private void btn_reset(object sender, RoutedEventArgs e)
        {
            carid.Text = "";
            model.Text = "";
            txtduration.Text = "";
            txtpayment.Text = "";
            save.IsEnabled = false;
        }

       

    }
}
