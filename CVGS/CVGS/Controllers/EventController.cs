using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CVGS.Models;

namespace CVGS.Controllers
{
    public class EventController : Controller
    {
        cvgsEntities _context = new cvgsEntities();
        
        // GET: Event
      
        public ActionResult Index()
        {
            var listodData = _context.Events.ToList();
            return View(listodData);

        }
        [HttpGet]
        public ActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEvent([Bind(Include = " EventName, EventDescription,EventDate, ImageURL, ImageFile")] Event model, HttpPostedFileBase ImageFile)
        {
            try
            {
                if (model.EventDate < DateTime.Now)
                {
                    ModelState.AddModelError("EventDate", "Please provide future event date");
                }
                if (ImageFile == null)
                {
                    ViewBag.result = "Image is required, so upload an image";
                }
                else if (ImageFile != null && ((ImageFile.ContentLength / 1024) < 10 || (ImageFile.ContentLength / 1024 > 300)))
                {
                    ViewBag.result = "file size should be in range of 10kb and 300kb";
                }

               
                else
                {
                    if (ModelState.IsValid)
                    {

                        string filename = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                        string extension = Path.GetExtension(model.ImageFile.FileName);
                        filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                        model.ImageURL = "~/Image/" + filename;
                        filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                        model.ImageFile.SaveAs(filename);
                        _context.Events.Add(model);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View();
        }


        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            var data = _context.Events.Where(x => x.EventID == id).FirstOrDefault();
            return View(data);
        }

       
        [HttpPost, ActionName("EditEvent")]
        public ActionResult EditEvent(Event model, int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var eventToUpdate = _context.Events.Find(id);
            if (TryUpdateModel(eventToUpdate, "",
               new string[] { "EventName", "EventDescription","EventDate", "ImageURL" }))
            {
                try
                {
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(eventToUpdate);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event eventToUpdate = _context.Events.Find(id);
            if (eventToUpdate == null)
            {
                return HttpNotFound();
            }
            return View(eventToUpdate);
        }

        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Event event1 = _context.Events.Find(id);
            if (event1 == null)
            {
                return HttpNotFound();
            }
            return View(event1);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Event eventToUpdate = _context.Events.Find(id);
                _context.Events.Remove(eventToUpdate);
                _context.SaveChanges();

            }
            catch (DataException/* dex */)
            { 
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
                            }
            return RedirectToAction("Index");
        }
      
        public ActionResult Report()
        {
            ViewBag.Message = "Reports can be viewed and downloaded from here.";

            return View();
        }
    }
}
    
