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
    public partial class MainWindow : Window
    {
        public ObservableCollection<ShapePoint> ShapePoints = new ObservableCollection<ShapePoint>();

        public List<string> _pointlist;


        public class ShapePoint : INotifyPropertyChanged
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

            public event PropertyChangedEventHandler PropertyChanged;

            public void NotifyPropertyChanged(string propName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }



        private void GetPoints(sp.Shape shape)
        {
            _pointlist = shape.ShapePointList;
        }

        private void AddPointsToObservableCollection()
        {
            ShapePoints.Clear();
            foreach (string point in _pointlist)
            {
                ShapePoint pnt = new ShapePoint() { Name = point };
                ShapePoints.Add(pnt);

            }
        }

        private class ReflectiveEnumerator
        {
            static ReflectiveEnumerator() { }

            public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class//, IComparable<T>
            {
                List<T> objects = new List<T>();
                foreach (Type type in
                    Assembly.GetAssembly(typeof(T)).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
                {
                    objects.Add((T)Activator.CreateInstance(type, constructorArgs));
                }
                //objects.Sort();
                return objects;
            }
        }



    }
}
