using Microsoft.AspNetCore.Mvc;
using PB.OMS.OrderingService.Api.Models;

namespace PB.OMS.OrderingService.Api.Controllers
{
    public class MenuController : BaseController
    {
        [HttpGet(Name = "GetMenuItems")]
        public IEnumerable<MenuItem> Get()
        {
            List<MenuItem> items = new List<MenuItem>();
            items.Add(new MenuItem() { Name = "Pizza Margarita", Description = "Tomato, cheese", Price = 8.90 });
            items.Add(new MenuItem() { Name = "Mexican", Description = "Καλαμπόκι, μπέικον, φρέσκια ντομάτα, τυρί γκούντα, σάλτσα ντοµάτας", Price = 9.90 });
            items.Add(new MenuItem() { Name = "Ham Bacon Mushroom", Description = "Zαμπόν σνακ, μπέικον, φρέσκα μανιτάρια, τυρί γκούντα, σάλτσα ντοµάτας", Price = 10.90 });
            items.Add(new MenuItem() { Name = "Vegeterian", Description = "Φρέσκα μανιτάρια, πράσινη πιπεριά, τυρί γκούντα, σάλτσα ντοµάτας\r\n", Price = 11 });
            items.Add(new MenuItem() { Name = "Pepperoni", Description = "Πεπερόνι, τυρί γκούντα, σάλτσα ντοµάτας\r\n", Price = 10.4 });

            return items.ToArray();
        }
    }
}
