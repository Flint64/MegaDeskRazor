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

        [Display(Name = "Rush Option")]
        public int RushOptionId { get; set; }


        /*Navigation*/
        public Desk Desk { get; set; }
        public RushOption RushOption { get; set; }








        public decimal GetQuote(MegaDeskRazorContext context) {

            //Desk base price
            Price = 200;

            //If surface area is over 1000, charge for every inch over 1000
            if (this.Desk.SurfaceArea > 1000) {
                Price += (this.Desk.SurfaceArea - 1000);
            }

            //$50 for each drawer
            //TODO: Change this to pull from the database
            //switch (desk.NumberOfDrawers) {
            //    case (NumDrawers.Zero) : price += 0; break;
            //    case (NumDrawers.One)  : price += 50; break;
            //    case (NumDrawers.Two)  : price += (50 * 2); break;
            //    case (NumDrawers.Three): price += (50 * 3); break;
            //    case (NumDrawers.Four) : price += (50 * 4); break;
            //    case (NumDrawers.Five) : price += (50 * 5); break;
            //    case (NumDrawers.Six)  : price += (50 * 6); break;
            //    case (NumDrawers.Seven): price += (50 * 7); break;
            //}

            //Check the surface material choice and 
            //add the correct amount to the price

            //TODO: Change this to pull from the database

            //switch (desk.SurfaceMaterial) {
            //    case SurfaceMaterial.Laminate: { price += 100; break; }
            //    case SurfaceMaterial.Oak:      { price += 200; break; }
            //    case SurfaceMaterial.Pine:     { price += 50;  break; }
            //    case SurfaceMaterial.Rosewood: { price += 300; break; }
            //    case SurfaceMaterial.Veneer:   { price += 125; break; }
            //}

            //Check rush order options and add to price
            //Price += calcRushPrice(Desk.RushOption);


            return Price;
        }

        //TODO: Change this to pull from the database
        //private void loadRushPrices() {
        //    int counter = 0;
        //    int position = 0;
        //    string line;

        //    // Read the file and display it line by line.  
        //    System.IO.StreamReader file = new System.IO.StreamReader(@"rushOrderPrices.txt");
        //    while ((line = file.ReadLine()) != null) {

        //        if (counter < 3) {
        //            rushPrices[0, position] = Decimal.Parse(line);
        //        }
        //        if (counter > 2 && counter < 6) {
        //            rushPrices[1, position] = Decimal.Parse(line);
        //        }
        //        if (counter > 5 && counter < 9) {
        //            rushPrices[2, position] = Decimal.Parse(line);
        //        }

        //        counter++;
        //        position++;

        //        if (position > 2) {
        //            position = 0;
        //        }

        //    }

        //    file.Close();

        //}


        /*********************************************************
         * Calculates the rush price based on the enum value 
         * and surface area. Returns rush price.
         *********************************************************/
        private decimal calcRushPrice(RushOption option) {

            //loadRushPrices();
            decimal rushPrice = 0;

            //switch (option) {

            //    case RushOption.none: {
            //        break;
            //    }

            //    case RushOption.day_3: {
            //        if (desk.SurfaceArea < 1000) {
            //            rushPrice = rushPrices[0,0];
            //        } else if (desk.SurfaceArea >= 1000 && desk.SurfaceArea <= 2000) {
            //            rushPrice = rushPrices[0, 1];
            //        } else if (desk.SurfaceArea > 2000) {
            //            rushPrice = rushPrices[0, 2];
            //        }
            //        break;
            //    }

            //    case RushOption.day_5: {
            //        if (desk.SurfaceArea < 1000) {
            //            rushPrice = rushPrices[1, 0];
            //        } else if (desk.SurfaceArea >= 1000 && desk.SurfaceArea <= 2000) {
            //            rushPrice = rushPrices[1, 1];
            //        } else if (desk.SurfaceArea > 2000) {
            //            rushPrice = rushPrices[1, 2];
            //        }
            //        break;
            //    }

            //    case RushOption.day_7: {
            //        if (desk.SurfaceArea < 1000) {
            //            rushPrice = 30;
            //        } else if (desk.SurfaceArea >= 1000 && desk.SurfaceArea <= 2000) {
            //            rushPrice = 35;
            //        } else if (desk.SurfaceArea > 2000) {
            //            rushPrice = 40;
            //        }
            //        break;
            //    }
            //}

            return rushPrice;
        }
    }
}
