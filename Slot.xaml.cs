using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Media;
using System.Drawing;


namespace FinalProject
{
    /// <summary>
    /// Interaction logic for Slot.xaml
    /// </summary>
    public partial class Slot : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PM9NGM3\SQLEXPRESS;Initial Catalog=PMS;Integrated Security=True");

        public Slot(string UserNam)
        {
            InitializeComponent();
            nextname.Content = "Hi " + UserNam + " Welcome to our Parking management system";
            //SlotLogic();
            book_now.IsEnabled = false;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void Book_Now(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            //string slotone = slot1.ContextMenu.ToString();
            //CarAdd entry = new CarAdd();
            //entry.ShowDialog();
            //this.Close();
        }

        void Bindata()
        {
            SqlCommand cmd = new SqlCommand("select * from UserAuth", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            //dataGridView1.ItemsSource = dt.DefaultView;
        }

        private bool isSlot_1Clicked = false;
        void SlotLogic()
        {

            //con.Open();
            //SqlCommand cmd = new SqlCommand("select UserName from UserAuth", con);
            //cmd.ExecuteNonQuery();
            //con.Close();



        }

        //private bool isSlot_2Clicked = false;
        private bool slot_one = false;
        private bool slot_two = false;
        private void slot_1(object sender, RoutedEventArgs e)
        {
            //SlotLogic();
            if(slot_one)
            {
                slot1.Background = Brushes.White;
            }
            else
            {
                slot1.Background = Brushes.Green;
                book_now.IsEnabled = true;
            }
            isSlot_1Clicked = !isSlot_1Clicked;


        }

        private void slot_2(object sender, RoutedEventArgs e)
        {
            // SlotLogic();
            if (slot_two)
            {
                slot2.Background = Brushes.White;
            }
            else
            {
                slot2.Background = Brushes.Green;
                book_now.IsEnabled = true;
            }
            isSlot_1Clicked = !isSlot_1Clicked;

        }

        private void slot_3(object sender, RoutedEventArgs e)
        {
           // SlotLogic();
        }

        private void slot_4(object sender, RoutedEventArgs e)
        {
            //SlotLogic();
        }

        private void slot_5(object sender, RoutedEventArgs e)
        {
            //SlotLogic();
        }

        private void slot_6(object sender, RoutedEventArgs e)
        {
            //SlotLogic();
        }

        private void slot_7(object sender, RoutedEventArgs e)
        {
            //SlotLogic();
        }
    }
}
