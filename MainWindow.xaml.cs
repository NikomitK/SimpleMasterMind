using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mastermindgui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int a = 0;
        int b = 0;
        int c = 0;
        int d = 0;
        int azversuche = 0;
        private String[] farben = new string[4];
        public SolidColorBrush[] farbe = new SolidColorBrush[4];
        private bool[] richtige = { false, false, false, false };
        SolidColorBrush af = new SolidColorBrush(Colors.Blue);
        private bool won = false;
        public Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
            textBoxeins.Text = "rofl";
            for(int i = 0; i<4; i++)
            {
                int k = r.Next(6);
                farben[i] = btnshow(k);
            }
            btneins.Background = af;
            btnzwei.Background = af;
            btndrei.Background = af;
            btnvier.Background = af;
            for(int i = 0; i<4; i++)
            {
                farbe[i] = af;
            }
        }

        // methode die durch eine Zahl einen String mit einer Farbe returned
        public String btnshow(int i)
        {
            String s = "";
            switch (i)
            {
                case 0: s = "blau"; break;
                case 1: s = "grün"; break;
                case 2: s = "rot"; break;
                case 3: s = "braun"; break;
                case 4: s = "gelb"; break;
                case 5: s = "schwarz"; break;
            }
            return s;
        }

        public SolidColorBrush btncolor(int i)
        {
            Color c;
            switch (i)
            {
                case 0: c = Colors.Blue; break;
                case 1: c = Colors.Green; break;
                case 2: c = Colors.Red; break;
                case 3: c = Colors.Brown; break;
                case 4: c = Colors.Yellow; break;
                case 5: c = Colors.Black; break;
            }
           SolidColorBrush scb = new SolidColorBrush(c);
            return scb;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            a++;
            if (a == 6)
            {
                a = 0;
            }
            btneins.Content = btnshow(a);
            farbe[0] = btncolor(a);
            btneins.Background = farbe[0];
        }

        private void btnzwei_Click(object sender, RoutedEventArgs e)
        {
            b++;
            if(b == 6)
            {
                b = 0;
            }
            btnzwei.Content = btnshow(b);
            farbe[1] = btncolor(b);
            btnzwei.Background = farbe[1];
        }

        private void btndrei_Click(object sender, RoutedEventArgs e)
        {
            c++;
            if (c == 6)
            {
                c = 0;
            }
            btndrei.Content = btnshow(c);
            farbe[2] = btncolor(c);
            btndrei.Background = farbe[2];
        }

        private void btnvier_Click(object sender, RoutedEventArgs e)
        {
            d++;
            if (d == 6)
            {
                d = 0;
            }
            btnvier.Content = btnshow(d);
            farbe[3] = btncolor(d);
            btnvier.Background = farbe[3];
        }

        private void submit1_Click(object sender, RoutedEventArgs e)
        {
            if(btneins.Content == farben[0])
            {
                btneins.IsEnabled = false;
                richtige[0] = true;
                textBlockeins.Background = farbe[0];
            }
            if(btnzwei.Content == farben[1])
            {
                btnzwei.IsEnabled = false;
                richtige[1] = true;
                textBlockzwei.Background = farbe[1];
            }
            if(btndrei.Content == farben[2])
            {
                btndrei.IsEnabled = false;
                richtige[2] = true;
                textBlockdrei.Background = farbe[2];
            }
            if(btnvier.Content == farben[3])
            {
                btnvier.IsEnabled = false;
                richtige[3] = true;
                textBlockvier.Background = farbe[3];
            }
            azversuche++;
            textBoxeins.Text = "" + azversuche;
            for (int i = 0; i<4; i++)
            {
                if(richtige[i] != true)
                {
                    won = false;
                    break;
                }
                else if(richtige[i] == true && i == 3)
                {
                    won = true;
                    break;
                }
            }
            if(azversuche == 8 && !won)
            {
                btneins.IsEnabled = false;
                btnzwei.IsEnabled = false;
                btndrei.IsEnabled = false;
                btnvier.IsEnabled = false;
                MessageBox.Show("Der Computer hat gewonnen!");
            }
            if(won)
            {
                btneins.IsEnabled = false;
                btnzwei.IsEnabled = false;
                btndrei.IsEnabled = false;
                btnvier.IsEnabled = false;
                MessageBox.Show("Du hast gewonnen!");
            }

        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            a = 0;
            b = 0;
            c = 0;
            d = 0; 
            btneins.IsEnabled = true;
            btnzwei.IsEnabled = true; 
            btndrei.IsEnabled = true; 
            btnvier.IsEnabled = true; 
            azversuche = 0;
            textBoxeins.Text = azversuche + "";
        farben = new string[4];
       farbe = new SolidColorBrush[4];
            for (int i = 0; i < 4; i++)
            {
                farbe[i] = af;
            }
            for (int i = 0; i<4; i++)
            {
                richtige[i] = false;
            }
            farbe[0] = btncolor(a);
            btneins.Background = farbe[0];
            btneins.Content = btnshow(a);
            btnzwei.Background = farbe[0];
            btnzwei.Content = btnshow(a);
            btndrei.Background = farbe[0];
            btndrei.Content = btnshow(a);
            btnvier.Background = farbe[0];
            btnvier.Content = btnshow(a);
            textBlockeins.Background = new SolidColorBrush(Colors.LightGray);
            textBlockzwei.Background = new SolidColorBrush(Colors.LightGray);
            textBlockdrei.Background = new SolidColorBrush(Colors.LightGray);
            textBlockvier.Background = new SolidColorBrush(Colors.LightGray);
            for (int i = 0; i < 4; i++)
            {
                int k = r.Next(6);
                farben[i] = btnshow(k);
            }
            won = false;
    }
    }
}
