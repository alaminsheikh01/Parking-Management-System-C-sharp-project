using System;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;



namespace FinalProject
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            txtduration.IsEnabled = false;
            txtpayment.IsEnabled = false;
            inTime.IsEnabled = false;
            
            TimeUpdater();
            Bindata();
            BindataUser();
            BindataGuest();
            //TimeShow();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PM9NGM3\SQLEXPRESS;Initial Catalog=PMS;Integrated Security=True");
        async void TimeUpdater()
        {
          
                inTime.Text = DateTime.Now.ToString();
                outTime.Text = DateTime.Now.ToString();
                await Task.Delay(1000);
            
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {

            if (carid.Text != "" && cartype.Text != "" && model.Text != "" && inTime.Text != "" && outTime.Text != "")
            {

                try
                {
                    con.Open();

                    string newcon = "insert into CarAdd (carid, cartype, carmodel, duration, payment, slot_book, insertdate) values ('" + carid.Text + "','" + cartype.Text + "','" + model.Text + "', '" + txtduration.Text + "','" + txtpayment.Text + "', '" +slotgroup.Text+ "',getdate())";
                    SqlCommand cmd = new SqlCommand(newcon, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully inserted");
                    
                    Bindata();
                    TimeShow();



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
        
        void TimeShow()
        {
            DateTime dtintime = DateTime.Parse(inTime.Text);
            DateTime dtouttime = DateTime.Parse(outTime.Text);

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
        }



        void Bindata()
        {
            SqlCommand cmd = new SqlCommand("select * from CarAdd", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.ItemsSource = dt.DefaultView;
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            if (carid.Text != "" && cartype.Text != "" && model.Text != "")
            {

                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update CarAdd set carId ='" + carid.Text + "',cartype = '" + cartype.Text + "', carmodel='" + model.Text + "', updatedate=getdate() where carid='" + carid.Text + "'", con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("succesfully updated");
                    Bindata();
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
                MessageBox.Show("input is required");
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (carid.Text != "")
                {
                    //if(MessageBox.Show("Are you sure to delete?", "Delete Record", MessageBoxButton.YesNo))
                    //{

                    //}
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete CarAdd where carid = '" + carid.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Succesfully Deleted");
                    Bindata();
                }
                else
                {
                    MessageBox.Show("Please insert carid");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (carid.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select * from CarAdd where carid='" + carid.Text + "'", con);
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    dataGridView1.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("Please inter carid");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            //foreach (Control x in this.Controls)
            //{
            //    if (x is TextBox)
            //    {
            //        ((TextBox)x).Clear();
            //    }
            //}


        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminLogin signup = new AdminLogin();
            signup.ShowDialog();
            this.Close();
        }

        private void calPayment(object sender, RoutedEventArgs e)
        {
            DateTime dtintime = DateTime.Parse(inTime.Text);
            DateTime dtouttime = DateTime.Parse(outTime.Text);

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




        //Useradding start

        void BindataUser()
        {
            SqlCommand cmd = new SqlCommand("select * from UserAuth", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            UserGrid.ItemsSource = dt.DefaultView;


        }
        void BindataGuest()
        {
            SqlCommand cmd = new SqlCommand("select * from GuestAuth", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            GuestGrid.ItemsSource = dt.DefaultView;


        }

        private void saveUser(object sender, RoutedEventArgs e)
        {
            if (usernameG.Text!="" && phonenoG.Text!="" && passwordG.Text!="")
            {

                try
                {
                    con.Open();

                    string newcon = "insert into UserAuth (UserName, PhoneNo, Password) values ('" + usernameG.Text + "', '"+phonenoG.Text+"', '"+passwordG.Text+"')";
                    SqlCommand cmd = new SqlCommand(newcon, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully inserted");

                    BindataUser();
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
                MessageBox.Show("Input is required");
            }

        }

        private void updateUser(object sender, RoutedEventArgs e)
        {
            if (usernameG.Text != "")
            {

                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update UserAuth set UserName ='" + usernameG.Text + "',PhoneNo = '" + phonenoG.Text + "', Password='" + passwordG.Text + "' where UserName='" + usernameG.Text + "'", con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("succesfully updated");
                    BindataUser();
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
                MessageBox.Show("At least Username is required");
            }

        }

        private void deleteUser(object sender, RoutedEventArgs e)
        {
            try
            {
                if (usernameG.Text != "")
                {

                   
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Delete UserAuth where UserName = '" + usernameG.Text + "'", con);
                        
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Succesfully Deleted");
                        BindataUser();
                       
                    
                }
                else
                {
                    MessageBox.Show("Please input valid UserName");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void searchUser(object sender, RoutedEventArgs e)
        {
            try
            {
                if (usernameG.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select * from UserAuth where UserName='" + usernameG.Text + "'", con);
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    UserGrid.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("Please input valid UserName");
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveGuest(object sender, RoutedEventArgs e)
        {
            if (usernameGuest.Text != "" && phonenoGuest.Text != "")
            {

                try
                {
                    con.Open();

                    string newcon = "insert into GuestAuth (UserName, PhoneNo) values ('" + usernameGuest.Text + "', '" + phonenoGuest.Text + "')";
                    SqlCommand cmd = new SqlCommand(newcon, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully inserted");

                    BindataGuest();
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
                MessageBox.Show("Input is required");
            }

        }

        private void updateGuest(object sender, RoutedEventArgs e)
        {
            if (usernameGuest.Text != "")
            {

                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update GuestAuth set UserName ='" + usernameGuest.Text + "',PhoneNo = '" + phonenoGuest.Text + "' where UserName='" + usernameGuest.Text + "'", con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("succesfully updated");
                    BindataGuest();
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
                MessageBox.Show("At least Username is required");
            }

        }

        private void deleteGuest(object sender, RoutedEventArgs e)
        {
            try
            {
                if (usernameGuest.Text != "")
                {


                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete GuestAuth where UserName = '" + usernameGuest.Text + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Succesfully Deleted");
                    BindataGuest();


                }
                else
                {
                    MessageBox.Show("Please input valid UserName");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void searchGuest(object sender, RoutedEventArgs e)
        {
            try
            {
                if (usernameGuest.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select * from GuestAuth where UserName='" + usernameGuest.Text + "'", con);
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    GuestGrid.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("Please input valid UserName");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //UserAdding end



    }
}
