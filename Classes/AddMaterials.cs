using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;
using sp = ExcelExpress.ComplexShape.SectionProperties;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace CreateElement
{
    /// <summary>
    /// Interaction logic for CreateElement.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> MatCollection = new ObservableCollection<string>();

        public void AddMaterial(string MatName)
        {
            MatCollection.Add(MatName);
        }



    }
}
