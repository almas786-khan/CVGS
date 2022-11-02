using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CVGS.Models;
using Microsoft.AspNet.Identity;
using static System.Net.Mime.MediaTypeNames;

namespace CVGS.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friend
        cvgsEntities _context = new cvgsEntities();
        public ActionResult Index()
        {
            List<friendViewModel> list = new List<friendViewModel>();
            string name = User.Identity.GetUserName();
            User user1 = _context.Users.FirstOrDefault(x => x.UserName == name);
            var listofData = _context.Friends.Where(x => x.Member1ID == user1.UserID).ToList();

            var result = from friend in _context.Friends
                         join use in _context.Users on friend.Member2ID equals use.UserID
                         where friend.Member1ID == user1.UserID
                         select new friendViewModel
                         {
                             Member1ID = friend.Member1ID,
                             Member1Name = use.UserName,
                             Member2ID = friend.Member2ID,
                             Member2Name = use.UserName
                         };
            list = result.ToList();

            return View(list);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
            [HttpGet]
        public ActionResult AddFriend(string Search) {
            string name = User.Identity.GetUserName();
            var result = from user in _context.Users
                  
                         where  user.UserType == "Member"
                         select user.UserName;
            return View(_context.Users.Where(x => (x.UserName.Contains(Search) && x.UserType=="Member" && x.UserName!=name)|| Search == null).ToList());
        }
        [HttpPost]
        public ActionResult AddFriend(int? id) {
            return View();
        }

    }
}