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
namespace printTest
{
    /// <summary>
    /// Interaction logic for supervReport.xaml
    /// </summary>
    public partial class supervReport : Window
    {
        string d1, d2, d3, d4, d5, d6, d7, d8, dtl;

        List<string> coin_data = new List<string>();
        List<string> coins = new List<string>();
        public static List<int> inventory = new List<int>();
        public static List<int> inventory1 = new List<int>();
        public static List<int> inventory2 = new List<int>();
        public static List<int> inventory3 = new List<int>();
        public static List<int> inventory4 = new List<int>();
        public static List<int> inventory5 = new List<int>();
        public static List<int> inventory6 = new List<int>();
        public static List<int> inventory7 = new List<int>();
        double pound_c1, pound_c2, pound_c5, pound_c10, pound_c20, pound_c50, pound_e1, pound_e2, total_pounds, percent;
        private Font printFont, titleFont, urlFont;
        int t = 0;
        public supervReport()
        {
            InitializeComponent();
            date.Content = DateTime.Now.ToString(("dddd dd MMM yyyy HH:mm"));
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                date.Content = DateTime.Now.ToString(("dddd dd MMM yyyy HH:mm"));
            }, this.Dispatcher);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            coin1.Text = "0";
            coin2.Text = "0";
            coin3.Text = "0";
            coin4.Text = "0";
            coin5.Text = "0";
            coin6.Text = "0";
            coin7.Text = "0";
            coin8.Text = "0";
            amount1.Text = "0";
            amount2.Text = "0";
            amount3.Text = "0";
            amount4.Text = "0";
            amount5.Text = "0";
            amount6.Text = "0";
            amount7.Text = "0";
            amount8.Text = "0";
            inventory.Clear();
            inventory1.Clear();
            inventory2.Clear();
            inventory3.Clear();
            inventory4.Clear();
            inventory5.Clear();
            inventory6.Clear();
            inventory7.Clear();
         
                coin1.Text = inventory.Sum().ToString();
                coin2.Text = inventory1.Sum().ToString();
                coin3.Text = inventory2.Sum().ToString();
                coin4.Text = inventory3.Sum().ToString();
                coin5.Text = inventory4.Sum().ToString();
                coin6.Text = inventory5.Sum().ToString();
                coin7.Text = inventory6.Sum().ToString();
                coin8.Text = inventory7.Sum().ToString();
                total_coins.Text = (inventory.Sum() + inventory2.Sum() + inventory3.Sum() + inventory4.Sum() + inventory5.Sum() +
                    inventory6.Sum() + inventory7.Sum()).ToString();


                amount1.Text = (inventory.Sum() * 0.01).ToString() + "€";
                amount2.Text = (inventory1.Sum() * 0.02).ToString() + "€";
                amount3.Text = (inventory2.Sum() * 0.05).ToString() + "€";
                amount4.Text = (inventory3.Sum() * 0.1).ToString() + "€";
                amount5.Text = (inventory4.Sum() * 0.2).ToString() + "€";
                amount6.Text = (inventory5.Sum() * 0.5).ToString() + "€";
                amount7.Text = (inventory6.Sum() * 1).ToString() + "€";
                amount8.Text = (inventory7.Sum() * 2).ToString() + "€";
                total_amount.Text = ((inventory.Sum() * 0.01) + (inventory1.Sum() * 0.02) + (inventory2.Sum() * 0.05) + (inventory3.Sum() * 0.1) + (inventory4.Sum() * 0.2) +
                    (inventory5.Sum() * 0.5) + (inventory6.Sum() * 1) + (inventory7.Sum() * 2)).ToString() + "€";
                pound_c1 = Convert.ToDouble(coin1.Text) * 23;
                pound_c2 = Convert.ToDouble(coin2.Text) * 30;
                pound_c5 = Convert.ToDouble(coin3.Text) * 39;
                pound_c10 = Convert.ToDouble(coin4.Text) * 41;
                pound_c20 = Convert.ToDouble(coin5.Text) * 57;
                pound_c50 = Convert.ToDouble(coin6.Text) * 78;
                pound_e1 = Convert.ToDouble(coin7.Text) * 75;
                pound_e2 = Convert.ToDouble(coin8.Text) * 85;
                total_pounds = pound_c1 + pound_c2 + pound_c5 + pound_c10 + pound_c20 + pound_c50 + pound_e1 + pound_e2;

                percent = Math.Ceiling((100 * total_pounds) / 90000);
                pososto.Content = percent.ToString() + "%";
                pbStatus.Value = percent;

                d1 = amount1.Text.Trim('€');
                d1 = string.Format("{0:#,##0.00}", Convert.ToDouble(d1));

                d2 = amount2.Text.Trim('€');
                d2 = string.Format("{0:#,##0.00}", Convert.ToDouble(d2));

                d3 = amount3.Text.Trim('€');
                d3 = string.Format("{0:#,##0.00}", Convert.ToDouble(d3));

                d4 = amount4.Text.Trim('€');
                d4 = string.Format("{0:#,##0.00}", Convert.ToDouble(d4));

                d5 = amount5.Text.Trim('€');
                d5 = string.Format("{0:#,##0.00}", Convert.ToDouble(d5));

                d6 = amount6.Text.Trim('€');
                d6 = string.Format("{0:#,##0.00}", Convert.ToDouble(d6));

                d7 = amount7.Text.Trim('€');
                d7 = string.Format("{0:#,##0.00}", Convert.ToDouble(d7));

                d8 = amount8.Text.Trim('€');
                d8 = string.Format("{0:#,##0.00}", Convert.ToDouble(d8));

                dtl = total_amount.Text.Trim('€');
                dtl = string.Format("{0:#,##0.00}", Convert.ToDouble(dtl));
        
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

                System.Drawing.Image newImage = printTest.Properties.Resources.logo;

                //print merchand logo
                ev.Graphics.DrawImage(newImage, new System.Drawing.Rectangle(50, 30, 186, 51));

                //print url
                ev.Graphics.DrawString("tcr.cmn342.com", urlFont, System.Drawing.Brushes.Black, 100, 70);

                //print date.now
                ev.Graphics.DrawString(date.Content.ToString(), printFont, System.Drawing.Brushes.Black, 50, 90);

                //print entity and user
                ev.Graphics.DrawString("'MTNECTTQ02' media cash inventory", printFont, System.Drawing.Brushes.Black, 20, 120);
                ev.Graphics.DrawString("for nectar", printFont, System.Drawing.Brushes.Black, 120, 135);
                ev.Graphics.DrawString("by user  CIT" , printFont, System.Drawing.Brushes.Black, 110, 150);

                // Set format of string.
                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                //print the denom column
                ev.Graphics.DrawString("Denom", printFont, System.Drawing.Brushes.Black, 70, 180, drawFormat);
                ev.Graphics.DrawString(cent1.Text.ToString(), printFont, System.Drawing.Brushes.Black, 70, 210, drawFormat);
                ev.Graphics.DrawString(cent2.Text.ToString(), printFont, System.Drawing.Brushes.Black, 70, 240, drawFormat);
                ev.Graphics.DrawString(cent5.Text.ToString(), printFont, System.Drawing.Brushes.Black, 70, 270, drawFormat);
                ev.Graphics.DrawString(cent10.Text.ToString(), printFont, System.Drawing.Brushes.Black, 70, 300, drawFormat);
                ev.Graphics.DrawString(cent20.Text.ToString(), printFont, System.Drawing.Brushes.Black, 70, 330, drawFormat);
                ev.Graphics.DrawString(cent50.Text.ToString(), printFont, System.Drawing.Brushes.Black, 70, 360, drawFormat);
                ev.Graphics.DrawString(euro1.Text.ToString(), printFont, System.Drawing.Brushes.Black, 70, 390, drawFormat);
                ev.Graphics.DrawString(euro2.Text.ToString(), printFont, System.Drawing.Brushes.Black, 70, 420, drawFormat);

                ev.Graphics.DrawString(totals.Text.ToString(), printFont, System.Drawing.Brushes.Black, 70, 450, drawFormat);

                //print the coin column
                ev.Graphics.DrawString(notes.Content.ToString(), printFont, System.Drawing.Brushes.Black, 150, 180, drawFormat);
                ev.Graphics.DrawString(coin1.Text.ToString(), printFont, System.Drawing.Brushes.Black, 150, 210, drawFormat);
                ev.Graphics.DrawString(coin2.Text.ToString(), printFont, System.Drawing.Brushes.Black, 150, 240, drawFormat);
                ev.Graphics.DrawString(coin3.Text.ToString(), printFont, System.Drawing.Brushes.Black, 150, 270, drawFormat);
                ev.Graphics.DrawString(coin4.Text.ToString(), printFont, System.Drawing.Brushes.Black, 150, 300, drawFormat);
                ev.Graphics.DrawString(coin5.Text.ToString(), printFont, System.Drawing.Brushes.Black, 150, 330, drawFormat);
                ev.Graphics.DrawString(coin6.Text.ToString(), printFont, System.Drawing.Brushes.Black, 150, 360, drawFormat);
                ev.Graphics.DrawString(coin7.Text.ToString(), printFont, System.Drawing.Brushes.Black, 150, 390, drawFormat);
                ev.Graphics.DrawString(coin8.Text.ToString(), printFont, System.Drawing.Brushes.Black, 150, 420, drawFormat);

                ev.Graphics.DrawString(total_coins.Text.ToString(), printFont, System.Drawing.Brushes.Black, 150, 450, drawFormat);

                //print the amount column
                ev.Graphics.DrawString(amount.Content.ToString(), printFont, System.Drawing.Brushes.Black, 250, 180, drawFormat);
                ev.Graphics.DrawString(d1 + "€", printFont, System.Drawing.Brushes.Black, 250, 210, drawFormat);
                ev.Graphics.DrawString(d2 + "€", printFont, System.Drawing.Brushes.Black, 250, 240, drawFormat);
                ev.Graphics.DrawString(d3 + "€", printFont, System.Drawing.Brushes.Black, 250, 270, drawFormat);
                ev.Graphics.DrawString(d4 + "€", printFont, System.Drawing.Brushes.Black, 250, 300, drawFormat);
                ev.Graphics.DrawString(d5 + "€", printFont, System.Drawing.Brushes.Black, 250, 330, drawFormat);
                ev.Graphics.DrawString(d6 + "€", printFont, System.Drawing.Brushes.Black, 250, 360, drawFormat);
                ev.Graphics.DrawString(d7 + "€", printFont, System.Drawing.Brushes.Black, 250, 390, drawFormat);
                ev.Graphics.DrawString(d8 + "€", printFont, System.Drawing.Brushes.Black, 250, 420, drawFormat);

                ev.Graphics.DrawString(dtl + "€", printFont, System.Drawing.Brushes.Black, 250, 450, drawFormat);



                ev.Graphics.DrawString("* * * * * * * * * * * * * * * * * * * * * * * * * * * * *", printFont, System.Drawing.Brushes.Black, 5, 480);

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
