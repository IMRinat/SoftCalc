using System.Windows;
using CalcCore;


namespace SoftCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var calc1 = new CalcMainClass();
            result.Text = calc1.Calc_string(query.Text);
        }
    }
}
