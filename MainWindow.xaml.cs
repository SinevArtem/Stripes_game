using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Работа__3_через_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        static int count_butten = 0;
        DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };


        public MainWindow()
        {
            InitializeComponent();
            Form1.IsEnabled = false;
            timer.Tick += Timer_Tick;
            timer.Start();
            

        }
        bool CheckSize(Control C, Button button) 
        {
            button.HorizontalAlignment = HorizontalAlignment.Left;
            button.VerticalAlignment = VerticalAlignment.Top;
            C.HorizontalAlignment = HorizontalAlignment.Left;
            C.VerticalAlignment = VerticalAlignment.Top;
            bool w = button.Margin.Left >= C.Margin.Left + C.Width || button.Margin.Left + button.Width <= C.Margin.Left;
            bool h = button.Margin.Top >= C.Margin.Top + C.Height || button.Margin.Top + button.Height <= C.Margin.Top;
            bool result = w || h;
            return result;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {


            int w, h;
            Button myButton = new Button();
            Random rand = new Random();
            if (rand.Next(2) == rand.Next(2))
            {
                h = 50;
                w = 300;
            }
            else
            {
                h = 300;
                w = 50;
            }
            myButton.Width = w;
            myButton.Height = h;
            myButton.HorizontalAlignment = HorizontalAlignment.Left;
            myButton.VerticalAlignment = VerticalAlignment.Top;
            myButton.Margin = new Thickness(rand.Next(1100), rand.Next(700), 0, 0);
            count_butten += 1;
            myButton.Background = new SolidColorBrush(Color.FromArgb(Convert.ToByte(rand.Next(256)), Convert.ToByte(rand.Next(256)), Convert.ToByte(rand.Next(256)), Convert.ToByte(rand.Next(256))));
            myButton.Click += Button_Click;
            Form1.Children.Add(myButton);
            if (count_butten == 10)
            {
                timer.Stop();
                lable1.Visibility= Visibility.Visible;
                lable1.Content = "Поражение";
                
            }
            if (count_butten==5) Form1.IsEnabled = true;
            
            
        }
        
        private void Button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int count = 0;
            for(int i=1;i<Form1.Children.Count;i++)
            {
                Control C = (Control)Form1.Children[i];
                if (CheckSize(C, button) || Form1.Children.IndexOf(C) <= Form1.Children.IndexOf(button))
                {
                    count++;
                }
            }
            if (count==Form1.Children.Count-1)
            {
                Form1.Children.Remove(button);
                count_butten--;
            }
            
            if (count_butten == 0)
            {
                lable1.Visibility = Visibility.Visible;
                timer.Stop();
            }
            
        }



    }
}
