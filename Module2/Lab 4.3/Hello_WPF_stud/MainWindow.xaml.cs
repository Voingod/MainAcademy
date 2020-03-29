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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Hello_WPF_stud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }

        private void ClearButton(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "";
        }

        private void parseStringAndCalculate(string s)
        {
            try
            {
                NCalc.Expression e = new NCalc.Expression(s);
                textBlock.Text = e.Evaluate().ToString();
            }
            catch (Exception exception)
            {
                MessageBoxResult result = MessageBox.Show("Ow, you have entered an invalid expression. Calculator cannot calculate it. Please enter a valid expression.", "Invalid expression", MessageBoxButton.OK, MessageBoxImage.Warning);
                textBlock.Text = "";
                if (result == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = (string)((Button)e.OriginalSource).Content;

            if (s == "CLEAR")
            {
                ClearButton(sender, e);
                return;
            }
            else if (s == "=")
            {
                parseStringAndCalculate(textBlock.Text);
            }
            else
            {
                textBlock.Text += s;
            }

        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {           
            Application.Current.Shutdown();
        }

    }
}