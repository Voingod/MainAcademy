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
using System.Windows.Shapes;

namespace CSharp_Net_module2_1_2_lab
{
    /// <summary>
    /// Логика взаимодействия для Pictures.xaml
    /// </summary>
    public partial class Pictures : Window
    {
        private readonly List<string> images = new List<string>();
        int selected = 0;
        public Pictures()
        {
            for (int i = 1; i <= 3; i++)
                images.Add(@"D:\Projects\Main Academy\CSharp_Net_module2_1_2_lab"+
                            @"\CSharp_Net_module2_1_2_lab\images\planet"+i+".png");
            
            InitializeComponent();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            selected = selected == 0 ? images.Count-1 : selected - 1;
            ShowImage(images[selected]);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            selected = selected == images.Count - 1 ? 0: selected + 1;
            ShowImage(images[selected]);
        }
        private void ShowImage(string img)
        {
            Image.Source = new BitmapImage(new Uri(img, UriKind.Absolute));
        }
    }
}
