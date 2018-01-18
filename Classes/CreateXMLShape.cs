using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using sp = ExcelExpress.ComplexShape.SectionProperties;
using task = ExcelExpress.ComplexShape.ExcelTasks;


namespace CreateElement
{
    public partial class MainWindow : Window
    {

        public task.Shape CreateXMLShape(int elementID, string Material, string point, string xp, string yp, string theta, bool xmirror, bool ymirror)
        {
            IEnumerable<task.Shape> Eshape = ReflectiveEnumerator.GetEnumerableOfType<task.Shape>();

            task.Shape shape = null;

            TreeViewItem selectedTVI = (TreeViewItem)treeView.SelectedItem;

            string selectedShape = selectedTVI.Header.ToString();

            bool test = selectedTVI.HasItems;
            string parentName = null;
            if (selectedTVI.Parent.GetType() == typeof(TreeViewItem)) // verify that parent is TreeViewItem
            {
                TreeViewItem parent = (TreeViewItem)selectedTVI.Parent;
                parentName = parent.Header.ToString();
            }



            int elmID = elementID;

            if (!test)
            {
                if (parentName == "Basic Shapes")
                {
                    foreach (task.Shape sh in Eshape)
                    {
                        if (sh.GetType().Name == selectedShape.Replace(" ", string.Empty))
                        {
                            sh.MatName = Material;
                            sh.PointID = point;
                            sh.xp_formula = xp;
                            sh.yp_formula = yp;
                            sh.theta_formula = theta;
                            sh.MirrorX = xmirror;
                            sh.MirrorY = ymirror;
                            sh.ElementID = elmID;

                            foreach (ShapeProperty shape_prop in ShapeProperties)
                            {
                                object[] myobject = new object[1]; //[shape_prop.Value];
                                myobject[0] = shape_prop.Value;
                                //dynamic value = shape_prop.Value;
                                string sh_property = shape_prop.Name + "_formula";
                                sh.GetType().InvokeMember(sh_property, BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty, Type.DefaultBinder, sh, myobject);
                            }

                            shape = sh;
                        }


                    }
                }

                if (parentName == "Machined Shapes")
                {
                    foreach (task.Shape sh in Eshape)
                    {
                        if (sh.GetType().Name == "Machined" + selectedShape.Replace(" ", string.Empty))
                        {
                            sh.MatName = Material;
                            sh.PointID = point;
                            sh.xp_formula = xp;
                            sh.yp_formula = yp;
                            sh.theta_formula = theta;
                            sh.MirrorX = xmirror;
                            sh.MirrorY = ymirror;
                            sh.ElementID = elmID;

                            foreach (ShapeProperty shape_prop in ShapeProperties)
                            {
                                object[] myobject = new object[1]; //[shape_prop.Value];
                                myobject[0] = shape_prop.Value;
                                //dynamic value = shape_prop.Value;
                                string sh_property = shape_prop.Name + "_formula";
                                sh.GetType().InvokeMember(sh_property, BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty, Type.DefaultBinder, sh, myobject);
                            }

                            shape = sh;

                        }
                    }
                }

                if (parentName == "Formed Shapes")
                {
                    foreach (task.Shape sh in Eshape)
                    {
                        if (sh.GetType().Name == "Formed" + selectedShape.Replace(" ", string.Empty))
                        {
                            sh.MatName = Material;
                            sh.PointID = point;
                            sh.xp_formula = xp;
                            sh.yp_formula = yp;
                            sh.theta_formula = theta;
                            sh.MirrorX = xmirror;
                            sh.MirrorY = ymirror;
                            sh.ElementID = elmID;

                            foreach (ShapeProperty shape_prop in ShapeProperties)
                            {
                                object[] myobject = new object[1]; //[shape_prop.Value];
                                myobject[0] = shape_prop.Value;
                                //dynamic value = shape_prop.Value;
                                string sh_property = shape_prop.Name + "_formula";
                                sh.GetType().InvokeMember(sh_property, BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty, Type.DefaultBinder, sh, myobject);
                            }

                            shape = sh;

                        }
                    }
                }
            }

            return shape;

        }

    }
}
