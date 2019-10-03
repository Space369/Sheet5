using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sheet5.Models;

namespace Sheet5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            List<SelectListItem> meals = new List<SelectListItem>();
            meals.Add(new SelectListItem { Text = "Pepperoni", Value = "Pepperoni" });

            meals.Add(new SelectListItem { Text = "Cheese", Value = "Cheese" });

            /*
            var model = new Order {

            }
            */

            return View();
        }

        public ActionResult Sales()
        {
            return View();
        }

        public ActionResult Receipt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
           


            Dictionary<string, double> typePricesList = new Dictionary<string, double>()
            {
                {"Peperonie", 13.5 },
                {"Cheese", 12 },
                {"Alldress", 14 },
                {"Vege", 13.5 }

            };

            Dictionary<string, double> sizePricesList = new Dictionary<string, double>()
            {
                {"Small", 0 },
                {"Medium", 1 },
                {"Large", 2 },
                {"XLarge", 3 }

            };

            Dictionary<string, double> dealPricesList = new Dictionary<string, double>()
            {
                {"none", 0 },
                {"chips", 1 },
                {"cookies", 2 }
            };

            String typetest = collection["type"];

            double typePrice = typePricesList[collection["type"]];

            double sizePrice = sizePricesList[collection["size"]];

            double deal = dealPricesList[collection["deal"]];

            int quantity = Int32.Parse(collection["quantity"]);

            // Code for viewbag (output) 
            ViewBag.TypeName = collection["type"];

            //TempData["type"] = collection["type"]; 


            ViewBag.SizeName = collection["size"];
            ViewBag.DealName = collection["deal"];
            ViewBag.TotalPizza = typePrice + sizePrice;
            ViewBag.TotalDeal = deal;

            double cost = typePrice + sizePrice + deal;
            ViewBag.Cost = cost;


            ViewBag.Quantity = quantity;

            double subTotal = cost * quantity;
            ViewBag.SubTotal = subTotal;

            double tax = subTotal * 0.15;
            ViewBag.Tax = tax;
            double total = subTotal + tax;
            ViewBag.Total = total;


            SubType typeEnum = (SubType)Enum.Parse(typeof(SubType), collection["type"]);
            SubSize sizeEnum = (SubSize)Enum.Parse(typeof(SubSize), collection["size"]);
            //
            if (Session["OrderList"] == null)
            {
                List<Order> SaleList = new List<Order>();

                //SubType typeEnum = (SubType)Enum.Parse(typeof(SubType), collection["type"]);
              //  SubSize sizeEnum = (SubSize)Enum.Parse(typeof(SubSize), collection["size"]);

                Order order1 = new Order(typeEnum, sizeEnum, collection["deal"], quantity, tax, total);

                SaleList.Add(order1);

                Session["OrderList"] = SaleList;

            }
            else
            {
               

                var SaleList = Session["OrderList"] as List<Order>;

                Order order1 = new Order(typeEnum, sizeEnum, collection["deal"], quantity, tax, total);
                SaleList.Add(order1);

                Session["OrderList"] = SaleList;
                //SaleList



            }

            //TempData["TotalTax"] = Double.Parse(TempData["TotalTax"]) + tax;

            //Session["TotalTax"] = Double.Parse(Session["TotalTax"]) + tax;

            return View("Receipt");
        }

        public enum subType
        {
            Peperonie, Cheese, Alldress, Vege
        }

        public enum subSize
        {
            Small, Medium, Large, XLarge
        }


    }
}