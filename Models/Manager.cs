using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public class Manager
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserID { get; set; }//Links created manager models to current logged in user.
    }
}