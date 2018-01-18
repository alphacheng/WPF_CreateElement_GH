using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelExpress.ComplexShape.ExcelTasks
{
    public partial class ElementXML
    {
        public class CircularArc : Shape
        {
            public override int ElementID { get; set; }
            public override string MatName { get; set; }
            public override string PointID { get; set; }
            public override bool MirrorX { get; set; } = false;
            public override bool MirrorY { get; set; } = false;

            public override string xp_formula { get; set; }
            public override string yp_formula { get; set; }
            public override string theta_formula { get; set; }

            protected override string xp_defName { get; set; }
            protected override string yp_defName { get; set; }
            protected override string theta_defName { get; set; }

            public string r_formula { get; set; }
            public string t_formula { get; set; }
            public string phi_formula { get; set; }

            protected string r_defName { get; set; }
            protected string t_defName { get; set; }
            protected string phi_defName { get; set; }


            protected override XElement CreateDimsensionsXElement()
            {
                XElement xel = new XElement("Dimensions");
                xel.Add(
                    new XElement("r",
                        new XElement("formula", r_defName),
                        new XElement("value", 0)),
                    new XElement("t",
                        new XElement("formula", t_defName),
                        new XElement("value", 0)),
                    new XElement("phi",
                        new XElement("formula", phi_defName),
                        new XElement("value", 0)));

                return xel;
            }
            
        }
    }
}
