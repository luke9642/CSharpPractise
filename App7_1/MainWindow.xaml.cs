using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace App7_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateSales();
        }

        public void UpdateSales()
        {
            new List<string>() { "Orlen", "Pkobp", "Kghm", "Lotos" }.ForEach(elem => Task.Run(() => UpdatePanel(elem)));
        }

        private static double FindRandomValue() => Math.Round(new Random(Guid.NewGuid().GetHashCode()).NextDouble() * 2 - 1, 2);

        private static SolidColorBrush GetBackground(double value) => value >= 0f
            ? new SolidColorBrush(Color.FromRgb(0, 128, 0))
            : new SolidColorBrush(Color.FromRgb(255, 0, 0));

        private static SolidColorBrush GetBorder(double value) => value >= 0f
            ? new SolidColorBrush(Color.FromRgb(8, 246, 8))
            : new SolidColorBrush(Color.FromRgb(165, 42, 42));

        private async void UpdatePanel(string elem)
        {
            while (true)
            {
                var randomValue = FindRandomValue();

                Dispatcher.Invoke(() =>
                {
                    var border = FindName(elem + "Border") as Border;
                    var panel = FindName(elem + "Panel") as StackPanel;
                    var exchange = FindName(elem + "Exchange") as Run;
                    var value = FindName(elem + "Value") as Run;

                    border.Background = GetBorder(randomValue);
                    panel.Background = GetBackground(randomValue);
                    exchange.Text = $"{(double.Parse(exchange.Text.Replace(".", ",")) + randomValue):0.00}";
                    value.Text = $"{randomValue:0.00}";
                });

                await Task.Delay(2000);
            }
        }
    }
}
