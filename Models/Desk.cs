using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeskRazor.Models {
    public class Desk {

        public int DeskId { get; set; }
        public decimal Depth { get; set; }
        public decimal Width { get; set; }
        public decimal SurfaceArea { get; set; }

        [Display(Name = "Number of Drawers")]
        public int NumDrawersId { get; set; }

        [Display(Name = "Surface Material")]
        public int SurfaceMaterialId { get; set; }


        /*Navigation*/
        public SurfaceMaterial SurfaceMaterial { get; set; }
        public NumDrawers NumberOfDrawers { get; set; }
    }


}
