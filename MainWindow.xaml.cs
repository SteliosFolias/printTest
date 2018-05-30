using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace printTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Mutex _mutex;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        string d1, d2, d3, d4, d5, d6, d7;

        public static List<int> inventory = new List<int>();

        public static List<int> inventory1 = new List<int>();
        public static List<int> inventory2 = new List<int>();

        private void svisor_Click(object sender, RoutedEventArgs e)
        {
            supervReport supervReport = new supervReport();
            supervReport.Show();
            this.Close();
        }

        public static List<int> inventory3 = new List<int>();
        public static List<int> inventory4 = new List<int>();
        public static List<int> inventory5 = new List<int>();
        public static List<int> inventory6 = new List<int>();
        public static List<int> inventory7 = new List<int>();
        List<string> coins = new List<string>();
        private int reqID = 1;
        private Font printFont, titleFont, urlFont;
        int t = 0;

        public Action<object, EventArgs> Exit { get; }

        public MainWindow()
        {
            InitializeComponent();
            date.Content = DateTime.Now.ToString(("dddd dd MMM yyyy HH:mm"));
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                date.Content = DateTime.Now.ToString(("dddd dd MMM yyyy HH:mm"));
            }, this.Dispatcher);


            // Try to grab mutex
            bool createdNew;
            _mutex = new Mutex(true, "WpfApplication", out createdNew);

            if (!createdNew)
            {
                // Bring other instance to front and exit.
                Process current = Process.GetCurrentProcess();
                foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                {
                    if (process.Id != current.Id)
                    {
                        SetForegroundWindow(process.MainWindowHandle);
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Application already running");

                    }
                }
                Application.Current.Shutdown();
            }
            else
            {
                // Add Event handler to exit event.
                Exit += CloseMutexHandler;
            }
        }

        protected virtual void CloseMutexHandler(object sender, EventArgs e)
        {
            _mutex?.Close();
        }

        private int GetNextReqID()
        {
            return this.reqID++;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            inventory.Clear();
            inventory1.Clear();
            inventory2.Clear();
            inventory3.Clear();
            inventory4.Clear();
            inventory5.Clear();
            inventory6.Clear();
            inventory7.Clear();
          
          
                DAY1.Text = (DateTime.Today.AddDays(0).Date).ToShortDateString();
                DAY2.Text = (DateTime.Today.AddDays(-1).Date).ToShortDateString();
                DAY3.Text = (DateTime.Today.AddDays(-2).Date).ToShortDateString();
                DAY4.Text = (DateTime.Today.AddDays(-3).Date).ToShortDateString();
                DAY5.Text = (DateTime.Today.AddDays(-4).Date).ToShortDateString();
                DAY6.Text = (DateTime.Today.AddDays(-5).Date).ToShortDateString();
                DAY7.Text = (DateTime.Today.AddDays(-6).Date).ToShortDateString();              

                d1 = ttlamount1.Text.Trim('€');
                d1 = string.Format("{0:#,##0.00}", Convert.ToDouble(d1));

                d2 = ttlamount2.Text.Trim('€');
                d2 = string.Format("{0:#,##0.00}", Convert.ToDouble(d2));

                d3 = ttlamount3.Text.Trim('€');
                d3 = string.Format("{0:#,##0.00}", Convert.ToDouble(d3));

                d4 = ttlamount4.Text.Trim('€');
                d4 = string.Format("{0:#,##0.00}", Convert.ToDouble(d4));

                d5 = ttlamount5.Text.Trim('€');
                d5 = string.Format("{0:#,##0.00}", Convert.ToDouble(d5));

                d6 = ttlamount6.Text.Trim('€');
                d6 = string.Format("{0:#,##0.00}", Convert.ToDouble(d6));

                d7 = ttlamount7.Text.Trim('€');
                d7 = string.Format("{0:#,##0.00}", Convert.ToDouble(d7));

            }
          
        private void print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1170);
                printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);
                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured while printing" + ex.ToString());
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs ev)
        {
            if (t < 1)
            {
                printFont = new Font("Arial", 10);
                titleFont = new Font("Arial", 20);
                urlFont = new Font("Arial", 8);


                //print url
                ev.Graphics.DrawString("tcr.cmn342.com", urlFont, System.Drawing.Brushes.Black, 100, 70);

                //print date.now
                ev.Graphics.DrawString(date.Content.ToString(), printFont, System.Drawing.Brushes.Black, 50, 90);

                //print entity and user
                ev.Graphics.DrawString("'MTNECTTTQ02' user report", printFont, System.Drawing.Brushes.Black, 50, 120);
                ev.Graphics.DrawString("for nectar", printFont, System.Drawing.Brushes.Black, 100, 135);
                ev.Graphics.DrawString("by user  USER" , printFont, System.Drawing.Brushes.Black, 85, 150);

                // Set format of string.
                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;


                //print the date column
                ev.Graphics.DrawString(deposit_date.Content.ToString(), printFont, System.Drawing.Brushes.Black, 120, 180, drawFormat);
                ev.Graphics.DrawString(DAY1.Text.ToString(), printFont, System.Drawing.Brushes.Black, 50, 210);
                ev.Graphics.DrawString(DAY2.Text.ToString(), printFont, System.Drawing.Brushes.Black, 50, 240);
                ev.Graphics.DrawString(DAY3.Text.ToString(), printFont, System.Drawing.Brushes.Black, 50, 270);
                ev.Graphics.DrawString(DAY4.Text.ToString(), printFont, System.Drawing.Brushes.Black, 50, 300);
                ev.Graphics.DrawString(DAY5.Text.ToString(), printFont, System.Drawing.Brushes.Black, 50, 330);
                ev.Graphics.DrawString(DAY6.Text.ToString(), printFont, System.Drawing.Brushes.Black, 50, 360);
                ev.Graphics.DrawString(DAY7.Text.ToString(), printFont, System.Drawing.Brushes.Black, 50, 390);

                //print the amount column
                ev.Graphics.DrawString(total.Content.ToString(), printFont, System.Drawing.Brushes.Black, 220, 180, drawFormat);
                ev.Graphics.DrawString(d1 + "€", printFont, System.Drawing.Brushes.Black, 220, 210, drawFormat);
                ev.Graphics.DrawString(d2 + "€", printFont, System.Drawing.Brushes.Black, 220, 240, drawFormat);
                ev.Graphics.DrawString(d3 + "€", printFont, System.Drawing.Brushes.Black, 220, 270, drawFormat);
                ev.Graphics.DrawString(d4 + "€", printFont, System.Drawing.Brushes.Black, 220, 300, drawFormat);
                ev.Graphics.DrawString(d5 + "€", printFont, System.Drawing.Brushes.Black, 220, 330, drawFormat);
                ev.Graphics.DrawString(d6 + "€", printFont, System.Drawing.Brushes.Black, 220, 360, drawFormat);
                ev.Graphics.DrawString(d7 + "€", printFont, System.Drawing.Brushes.Black, 220, 390, drawFormat);


                t++;
                if (t < 1)
                {
                    ev.HasMorePages = true;
                }
                else
                {
                    ev.HasMorePages = false;
                }
            }
        }


    }
}
