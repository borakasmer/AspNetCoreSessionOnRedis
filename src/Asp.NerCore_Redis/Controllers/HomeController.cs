using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Asp.NetCore_Redis.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {           
            return View();
        }

        [HttpPost]
        public IActionResult Index(string UserName, string UserID)
        {
            var bytes = Encoding.UTF8.GetBytes(UserName);
            HttpContext.Session.Set("UserName", bytes);

            var bytes2 = Encoding.UTF8.GetBytes(UserID);
            HttpContext.Session.Set("UserID", bytes2);

            return RedirectToAction("About");
        }

        public IActionResult About()
        {
            var bytes = default(byte[]);
            HttpContext.Session.TryGetValue("UserName", out bytes);
            var content = Encoding.UTF8.GetString(bytes);

            var bytes2 = default(byte[]);
            HttpContext.Session.TryGetValue("UserID", out bytes2);
            var content2 = Encoding.UTF8.GetString(bytes2);
            ViewData["Message"] = content +" User ID:"+content2;

            return View();
        }      
    }
}
