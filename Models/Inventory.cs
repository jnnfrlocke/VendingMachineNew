using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public class Inventory
    {
           [Key]
            [Display(Name = "Product ID")]
            public int id { get; set; }
            [Display(Name = "Product Type")]
            public string typeProduct { get; set; }
            [Display(Name = "Product Name")]
            public string name { get; set; }
            [Display(Name = "Quantity")]
            public int quantity { get; set; }
            [Display(Name = "Price")]
            public double price { get; set; }

    }
}