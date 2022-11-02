using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CVGS.Models;
using Microsoft.AspNet.Identity;

namespace CVGS.Controllers
{
    public class MemberController : Controller
    {
        cvgsEntities _context = new cvgsEntities();
        GameModel game = new GameModel();

        // GET: Member
        [Authorize]
        [HttpGet]
        public ActionResult Index(string Search)
        {
            return View(_context.Games.Where(x => x.GameName.Contains(Search) ||Search==null).ToList());

        }
        [HttpPost]
        public ActionResult SaveList(string ItemList)
        {
            Game game= new Game();
            string[] arr = ItemList.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
               int j = int.Parse(arr[i]);
               game = _context.Games.Find(j);
              
            }
            //Details(game);
            //foreach (var item in arr)
            //{
            //    var currentId = item;
            //}
            
           return View();
        }
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game gameDetail = _context.Games.Find(id);
            if (gameDetail == null)
            {
                return HttpNotFound();
            }
            return View(gameDetail);
        }

      

        [HttpGet, Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (cvgsEntities db = new cvgsEntities())
                {
                    var userId = db.Users.FirstOrDefault(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name).UserID;
                    //var user = db.Users.Where(a => a.UserID == changePasswordModel.UserID).FirstOrDefault();
                    var user = db.Users.Where(a => a.UserID == userId && a.UserPassword == changePasswordModel.CurrentPassword).FirstOrDefault();
                    if (user != null)
                    {
                        user.UserPassword = changePasswordModel.NewPassword;
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.SaveChanges();
                        message = "New password updated successfully.";

                    }
                    else
                    {
                        message = "Password not Updated!";
                    }
                }
            }

            ViewBag.Message = message;
            return View();
        }
        //public ActionResult MemberProfile() { 
        //    return View();
        //}
    }
}