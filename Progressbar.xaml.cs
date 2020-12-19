using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for Progressbar.xaml
    /// </summary>
    public partial class Progressbar : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public Progressbar()
           {
            
                InitializeComponent();
                dispatcherTimer.Tick += new EventHandler(dt_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
                dispatcherTimer.Start();
            }
            private void dt_Tick(object sender, EventArgs e)
            {
                this.Hide();
                Entry entry = new Entry();
                entry.ShowDialog();
                //this.Close();
                dispatcherTimer.Stop();
                this.Close();
            }
            private void Window_ContentRendered(object sender, EventArgs e)
            {
                for (int i = 0; i < 100; i++)
                {
                    pbStatus.Value++;
                    Thread.Sleep(3000);
                }

            }
            void worker_DoWork(object sender, DoWorkEventArgs e)
            {
                for (int i = 0; i < 100; i++)
                {
                    (sender as BackgroundWorker).ReportProgress(i);
                    Thread.Sleep(3000);
                }



            }


            private void pbStatus_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
            {
                // //this.Hide();
                // Entry entry = new Entry();
                // entry.ShowDialog();
                //// entry.Close();
            }
        }
    }


