using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace VendingMachineNew.Models
{
    public class Machines
    {
        [Key]
        public int Id { get; set; }

       public string Address { get; set; }

    }
}