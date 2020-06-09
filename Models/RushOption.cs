using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskRazor.Models {
    public class RushOption {

        public int RushOptionId { get; set; }

        [Display(Name = "Rush Option")]
        public string RushOptionName { get; set; }
        public decimal PriceUnder1000 { get; set; }
        public decimal PriceBetween1000And2000 { get; set; }
        public decimal PriceOver2000 { get; set; }

    }
}
