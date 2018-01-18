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
    /// 

    public partial class MainWindow : Window
    {
        //https://stackoverflow.com/questions/26224666/creating-a-variable-number-of-textboxes-on-a-wpf-form

        public ObservableCollection<ShapeProperty> ShapeProperties = new ObservableCollection<ShapeProperty>();

        public List<string> _shapeprops;

        public class ShapeProperty : INotifyPropertyChanged
        {
            private string name;
            public string Name
            {
                get { return this.name; }
                set
                {
                    if (this.name != value)
                    {
                        this.name = value;
                        this.NotifyPropertyChanged("Name");
                    }
                }
            }

            private string _value;
            public string Value
            {
                get { return this._value; }
                set
                {
                    if (this._value != value)
                    {
                        this._value = value;
                        this.NotifyPropertyChanged("Value");
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public void NotifyPropertyChanged(string propName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void GetProperties(sp.Shape shp)
        {
            List<string> proplist = new List<string>();

            var Dimprops = shp.GetType().GetProperties().Where(
                prop => Attribute.IsDefined(prop, typeof(sp.DimensionAttribute)));

            foreach (PropertyInfo prop in Dimprops)
            {
                proplist.Add(prop.Name);
            }

            _shapeprops = proplist;
        }


        private void AddPropsToObservableCollection()
        {
            ShapeProperties.Clear();
            foreach (string prop in _shapeprops)
            {
                ShapeProperty prp = new ShapeProperty() { Name = prop, Value = null };
                ShapeProperties.Add(prp);

            }
        }

    }
}