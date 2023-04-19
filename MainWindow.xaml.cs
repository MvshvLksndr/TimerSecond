using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TimerSecund
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        bool isPause = false;
        TimeSpan time = TimeSpan.Zero;
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;

            tbTime.Text = time.ToString();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (isPause) return;
            time += new TimeSpan(0, 0, 1);
            tbTime.Text = time.ToString();
        }

        private void ButtonPause_Click(object sender, RoutedEventArgs e)
        {
            isPause = !isPause;

            if (isPause)
            {
                btnPause.Content = "Продолжить";
                btnPause.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                btnPause.Content = "Остановить";
                btnPause.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            time = TimeSpan.Zero;
            timer.Stop();
            tbTime.Text = time.ToString();
        }
    }
}
