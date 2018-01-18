using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ExcelExpress.ComplexShape.ExcelTasks
{
    public abstract class Shape
    {
        //Form Inputs: hard inputs
        public abstract int ElementID { get; set; }
        public abstract string MatName { get; set; }
        public abstract string PointID { get; set; }
        public virtual bool MirrorX { get; set; } = false;
        public virtual bool MirrorY { get; set; } = false;

        //Excel Inputs: excel reference inputs -- "Sheet1!B3"
        public abstract string xp_formula { get; set; }
        public abstract string yp_formula { get; set; }
        public abstract string theta_formula { get; set; }

        //Excel Defined Names: created from excel ref inputs
        protected virtual string xp_defName { get; set; }
        protected virtual string yp_defName { get; set; }
        protected virtual string theta_defName { get; set; }

        protected abstract XElement CreateDimsensionsXElement();

        protected virtual string GetElementType()
        {
            return this.GetType().Name;
        }
    }
}
