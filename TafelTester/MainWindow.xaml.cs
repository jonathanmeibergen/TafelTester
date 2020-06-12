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
        private Random rnd = new Random();
        private List<int> reeks = new List<int>();
        private List<UIElement> uieSommen = new List<UIElement>();
        public MainWindow()
        {
            InitializeComponent();
            


        }


        private void Beoordeel_click(object sender, RoutedEventArgs e)
        {
            float score = 0;

            foreach (StackPanel som in uieSommen)
            {
                TextBox tbUserAnswer = som.Children[1] as TextBox;

                if (tbUserAnswer.Text == "")
                {
                    // Configure the message box to be displayed
                    string messageBoxText = "Niet alle sommen zijn ingevuld";
                    string caption = "Beoordeling";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Exclamation;

                    MessageBox.Show(messageBoxText, caption, button, icon);

                    return;
                }

            }

            foreach (StackPanel som in uieSommen)
            {
                Label lbNotitie = som.Children[2] as Label; //index 2 is 3rd item
                TextBox tbUserAnswer = som.Children[1] as TextBox;

                int userAnswer = Convert.ToInt32(tbUserAnswer.Text);

                if (Convert.ToInt32(som.Tag) == userAnswer)
                {
                    lbNotitie.Content = "Goed";
                    lbNotitie.Foreground = Brushes.Green;
                    score++;
                }
                else
                {
                    lbNotitie.Content = "Fout";
                    lbNotitie.Foreground = Brushes.Red;
                }

                lbResultaat.Content = score != (float)0 ? (score / (float)reeks.Count * 10.0).ToString("0.##") : 1.ToString();

            }

    }

        private StackPanel CreateSom(int tafel, int random)
        {
            TextBox tbAntwoord = new TextBox();
            tbAntwoord.Width = 50;
            Label lbSom = new Label();
            lbSom.Width = 60;
            lbSom.HorizontalAlignment = HorizontalAlignment.Right;
            lbSom.Content = tafel + " x " + random;
            Label lbGoedFout = new Label();
            lbGoedFout.Width = 100;
            lbGoedFout.Content = "";
            lbGoedFout.Visibility = Visibility.Visible;

            StackPanel stp = new StackPanel();
            stp.Orientation = Orientation.Horizontal;
            stp.Children.Add(lbSom);
            stp.Children.Add(tbAntwoord);
            stp.Children.Add(lbGoedFout);

            //save answer in panel for easy acces later
            stp.Tag = tafel * random;

            wrpSommen.Children.Add(stp);

            return stp;
        }

        private void MaakSommen(object sender, RoutedEventArgs e)
        {

            reeks.Clear();
            uieSommen.Clear();

            //vullen
            for (int j = 0; j < 10; j++)
            {
                reeks.Add(j + 1);
                if (wrpSommen.Children.Count != 0)
                {
                    wrpSommen.Children.RemoveAt(0);
                }
            }

            //Fisher-Yates shuffle
            for (int i = reeks.Count; i > 0; i--)
            {
                //take a random number
                int k = rnd.Next(1, i);

                //swap
                int temp = reeks[k - 1];
                reeks[k - 1] = reeks[i - 1];
                reeks[i - 1] = temp;

                uieSommen.Add(CreateSom(Convert.ToInt32(tbTafel.Text), temp));
            }
       
        }
    }
}
