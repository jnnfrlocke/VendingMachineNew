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
            public int id { get; set; }
            public string typeProduct { get; set; }
            public string name { get; set; }
            public int quantity { get; set; }
            public double price { get; set; }


    }
}