using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;
using MegaDeskRazor.Data;

namespace MegaDeskRazor.Models {
    public class DeskQuote {
       
        public int DeskQuoteId { get; set; }

        //Display the Current Date
        [Display(Name = "Current Date")]
        public DateTime CurrentDate { get; set; }

        //Display the customer name
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        public int DeskId { get; set; }
        //public string RushOptionName { get; set; }

        [Display(Name = "Rush Option")]
        public int RushOptionId { get; set; }



        /*Navigation*/
        public Desk Desk { get; set; }

        [Display(Name = "Rush Option")]
        public RushOption RushOption { get; set; }








        public decimal GetQuote(MegaDeskRazorContext context) {

            //Desk base price
            Price = 200;

            this.Desk.SurfaceArea = (this.Desk.Width * this.Desk.Depth);

            //If surface area is over 1000, charge for every inch over 1000
            if (this.Desk.SurfaceArea > 1000) {
                Price += (this.Desk.SurfaceArea - 1000);
            }

            /*Pull from the database*/
            Price += context.SurfaceMaterial.Where(d => d.SurfaceMaterialId == this.Desk.SurfaceMaterialId).FirstOrDefault().Price;

            Price += context.NumDrawers.Where(d => d.NumDrawersId == this.Desk.NumDrawersId).FirstOrDefault().Price;

            if (this.Desk.SurfaceArea < 1000)
            {
                Price += context.RushOption.Where(d => d.RushOptionId == this.RushOptionId).FirstOrDefault().PriceUnder1000;
            } else if (this.Desk.SurfaceArea >= 1000 && this.Desk.SurfaceArea < 2000)
            {
                Price += context.RushOption.Where(d => d.RushOptionId == this.RushOptionId).FirstOrDefault().PriceBetween1000And2000;
            } else if (this.Desk.SurfaceArea > 2000)
            {
                Price += context.RushOption.Where(d => d.RushOptionId == this.RushOptionId).FirstOrDefault().PriceOver2000;
            }
            return Price;
        }
    }
}
