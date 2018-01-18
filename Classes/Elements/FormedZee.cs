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
        public class FormedZee : Shape
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

            public string b1_formula { get; set; }
            public string t_formula { get; set; }
            public string b2_formula { get; set; }
            public string h_formula { get; set; }
            public string r1_formula { get; set; }
            public string r2_formula { get; set; }


            public string b1_defName { get; set; }
            public string t_defName { get; set; }
            public string b2_defName { get; set; }
            public string h_defName { get; set; }
            public string r1_defName { get; set; }
            public string r2_defName { get; set; }



            protected override XElement CreateDimsensionsXElement()
            {
                XElement xel = new XElement("Dimensions");
                xel.Add(
                    new XElement("b1",
                        new XElement("formula", b1_defName),
                        new XElement("value", 0)),
                    new XElement("b2",
                        new XElement("formula", b2_defName),
                        new XElement("value", 0)),
                    new XElement("h",
                        new XElement("formula", h_defName),
                        new XElement("value", 0)),
                    new XElement("t",
                        new XElement("formula", t_defName),
                        new XElement("value", 0)),
                    new XElement("r1",
                        new XElement("formula", r1_defName),
                        new XElement("value", 0)),
                    new XElement("r2",
                        new XElement("formula", r2_defName),
                        new XElement("value", 0)));

                return xel;
            }
            
        }
    }
}

