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
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TafelTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> reeks = new List<int>();
        //private List<int> sommen;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private StackPanel CreateSom(int tafel, int random)
        {
            TextBox tbAntwoord = new TextBox();
            tbAntwoord.Width = 150;
            Label lbSom = new Label();
            lbSom.Content = tafel + " x " + random;
            Label lbGoedFout = new Label();
            lbGoedFout.Content = "Goed";
            lbGoedFout.Visibility = Visibility.Visible;

            StackPanel stp = new StackPanel();
            stp.Orientation = Orientation.Horizontal;
            stp.Children.Add(lbSom);
            stp.Children.Add(tbAntwoord);
            stp.Children.Add(lbGoedFout);

            wpSommen.Children.Add(stp);

            return stp;
        }


        private void MaakSommenClick(object sender, RoutedEventArgs e)
        {
            //vullen
            for (int j = 0; j < 10; j++)
            {
                reeks.Add(j + 1);
            }

            Random random = new Random();
            int n = reeks.Count;

            for (int i = reeks.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);

                int value = reeks[rnd];
                reeks[rnd] = reeks[i];
                reeks[i] = value;
                CreateSom(Convert.ToInt32(tbTafel.Text), reeks[i]);
            }
        }      
    }
}

