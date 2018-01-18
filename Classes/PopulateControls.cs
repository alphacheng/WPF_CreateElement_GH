using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using sp = ExcelExpress.ComplexShape.SectionProperties;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;


namespace CreateElement
{
    /// <summary>
    /// Interaction logic for CreateElement.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isTreeViewSelected = false;
        BitmapImage _imgpnt = new BitmapImage();
        BitmapImage _imgdim = new BitmapImage();

        private void PopulateControls(object sender, System.EventArgs e)
        {
            TreeViewItem selectedTVI = (TreeViewItem)treeView.SelectedItem;
            isTreeViewSelected = true;
            string selectedShape = selectedTVI.Header.ToString();

            IEnumerable<sp.Shape> Eshape = ReflectiveEnumerator.GetEnumerableOfType<sp.Shape>();
            List<string> shape_str = new List<string>();

            foreach (sp.Shape sh in Eshape)
            {
                shape_str.Add(sh.GetType().Name);
            }

            bool test = selectedTVI.HasItems;
            string parentName = null;
            if (selectedTVI.Parent.GetType() == typeof(TreeViewItem)) // verify that parent is TreeViewItem
            {
                TreeViewItem parent = (TreeViewItem)selectedTVI.Parent;
                parentName = parent.Header.ToString();
            }

            if (!test)
            {
                if (parentName == "Basic Shapes")
                {
                    foreach (sp.Shape sh in Eshape)
                    {
                        if (sh.GetType().Name == selectedShape.Replace(" ", string.Empty))
                        {

                            GetPoints(sh);
                            AddPointsToObservableCollection();

                            GetProperties(sh);
                            AddPropsToObservableCollection();

                            _imgdim = ImageUtil.GetBitmapImage(selectedShape.Replace(" ", string.Empty) + "_dim");
                            _imgpnt = ImageUtil.GetBitmapImage(selectedShape.Replace(" ", string.Empty) + "_pnt");


                        }
                    }
                }

                if (parentName == "Machined Shapes")
                {
                    foreach (sp.Shape sh in Eshape)
                    {
                        if (sh.GetType().Name == "Machined" + selectedShape.Replace(" ", string.Empty))
                        {
                            GetPoints(sh);
                            AddPointsToObservableCollection();

                            GetProperties(sh);
                            AddPropsToObservableCollection();
                                                        
                            _imgdim = ImageUtil.GetBitmapImage("Machined" + selectedShape.Replace(" ", string.Empty) + "_dim");
                            _imgpnt = ImageUtil.GetBitmapImage("Machined" + selectedShape.Replace(" ", string.Empty) + "_pnt");

                        }
                    }
                }

                if (parentName == "Formed Shapes")
                {
                    foreach (sp.Shape sh in Eshape)
                    {
                        if (sh.GetType().Name == "Formed" + selectedShape.Replace(" ", string.Empty))
                        {
                            GetPoints(sh);
                            AddPointsToObservableCollection();

                            GetProperties(sh);
                            AddPropsToObservableCollection();

                            _imgdim = ImageUtil.GetBitmapImage("Formed" + selectedShape.Replace(" ", string.Empty) + "_dim");
                            _imgpnt = ImageUtil.GetBitmapImage("Formed" + selectedShape.Replace(" ", string.Empty) + "_pnt");

                        }
                    }
                }

                HelperImage.Source = _imgdim;
                HelperImage.Stretch = System.Windows.Media.Stretch.Uniform;
                HelperBorder.Background = Brushes.White;
                HelperBorder.BorderBrush = Brushes.DarkGray;

            }
        }
    }
}
