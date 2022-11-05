using Microsoft.AspNetCore.Mvc;
using joespizza.Models;

namespace joespizza.Controllers
{
    public class PizzaController : Controller
    {
        List<PizzaModel> p = new List<PizzaModel>();
        static List<OrderModel> or = new List<OrderModel>();
        public PizzaController()
        {
            p.Add(new PizzaModel() { ID = 1, PizzaName = "Veg Pizza", Price = 150});
            p.Add(new PizzaModel() { ID = 2, PizzaName = "Chicken Pizza", Price = 250 });
            p.Add(new PizzaModel() { ID = 3, PizzaName = "Cheese Pizza", Price = 190 });
            p.Add(new PizzaModel() { ID = 4, PizzaName = "Chicken BBQ Pizza", Price = 300 });
        }
        public IActionResult Index()
        {
            return View(p);
        }
        public IActionResult CheckoutPage(int id)
        {
            var d = p.Find(x => x.ID == id);

            Random rnd = new Random();
            int num = rnd.Next();

            OrderModel o = new OrderModel();
            o.OrderID = num; 
            o.PizzaName = d.PizzaName;
            o.Quantity = 1;
            o.Amount = o.Quantity * d.Price;
            return View(o);
        }
        [HttpPost]
        public ActionResult CheckoutPage(OrderModel o)
        {
            or.Add(o);
            return RedirectToAction("ConfirmPage");   
        }
 
        public IActionResult ConfirmPage()
        {
            return View(or);
        }

    }
}
