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

namespace CreateElement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            combo.ItemsSource = ShapePoints;
            PropListView.ItemsSource = ShapeProperties;
            
        }

        private void button_AddShape(object sender, RoutedEventArgs e)
        {
            //Add shape to Excel custom xml part
        }

        private void ShowPointsHelperImage(object sender, EventArgs e)
        {
            if (isTreeViewSelected)
            {
                HelperImage.Source = _imgpnt;
                HelperImage.Stretch = System.Windows.Media.Stretch.Uniform;
                HelperBorder.Background = Brushes.White;
                HelperBorder.BorderBrush = Brushes.DarkGray;
            }
        }

        private void ShowDimensionHelperImage(object sender, EventArgs e)
        {
            if (isTreeViewSelected)
            {
                HelperImage.Source = _imgdim;
                HelperImage.Stretch = System.Windows.Media.Stretch.Uniform;
                HelperBorder.Background = Brushes.White;
                HelperBorder.BorderBrush = Brushes.DarkGray;
            }
        }
    }
}
