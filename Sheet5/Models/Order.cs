using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sheet5.Models
{
    public class Order
    {

        public SubType type { get; set; }
        public SubSize size { get; set; }
        [Required]
        public IEnumerable<SelectListItem> TypeList { get; set; }
        [Required]
        public IEnumerable<string> SelectedType { set; get; }

        public String deal { get; set; }

        public int quantity;
        public double tax;
        public double total;
        /*
        public Boolean dealnone { get; set; }
        public Boolean deal1 { get; set; }
        public Boolean deal2 { get; set; }

    */

        public Order(SubType type, SubSize size, String deal, int qty, double tax, double total)
        {
            this.type = type;
            this.size = size;

            this.deal = deal;
            this.quantity = qty;
            this.tax = tax;
            this.total = total; 

        }

    }

    public enum SubType
    {
        Peperonie, Cheese, Alldress, Vege
    }

    public enum SubSize
    {
        Small, Medium, Large, XLarge
    }
}