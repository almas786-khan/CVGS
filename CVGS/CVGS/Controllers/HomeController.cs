using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVGS.Models;

namespace CVGS.Controllers
{
 
    public class HomeController : Controller
    {
       
        cvgsEntities _context = new cvgsEntities();

        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            var listodData = _context.Games.ToList();
            return View(listodData);
            
        }
    }
}