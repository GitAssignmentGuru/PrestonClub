using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrestonClub.Models;

namespace PrestonClub.Controllers
{
    public class HomeController : Controller
    {
        PrestonClubDBEntities pcdb = new PrestonClubDBEntities();
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel lm)
        {
            if (ModelState.IsValid)
            {
                var info = pcdb.RegistrationDetails.Where(l => l.email == lm.Username && l.password == lm.Password);
                if (info.Any())
                {
                    Session["UserID"] = info.FirstOrDefault().ID;
                    Session["Role"] = "user";
                    if (lm.Username.ToLower() == "admin@gmail.com")
                    {
                        Session["Role"] = "admin";
                    }
                    return RedirectToAction("../RegistrationDetails/Index");
                }
            }
            TempData["ErrroMessage"] = "Invalid Credential. Please use the correct.";
            return RedirectToAction("/");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("/");
        }

        public ActionResult Register()
        {
            ViewBag.ParticipantsID = new SelectList(pcdb.ParticipantDetails, "ID", "Name");
            ViewBag.Volunteer_ID = new SelectList(pcdb.Volunteer_Types, "ID", "Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationDetail registartion_Form)
        {
            try
            {
                ViewBag.ParticipantsID = new SelectList(pcdb.ParticipantDetails, "ID", "Name", registartion_Form.ParticipantsID);
                ViewBag.Volunteer_ID = new SelectList(pcdb.Volunteer_Types, "ID", "Name", registartion_Form.Volunteer_ID);
                if (ModelState.IsValid)
                {
                    // A array of authors  
                    string[] authors = { "Snow White", "Snow Green", "Red", "Yellow" };

                    // Create a Random object  
                    Random rand = new Random();
                    // Generate a random index less than the size of the array.  
                    int index = rand.Next(authors.Length);
                    // Display the result.  
                    registartion_Form.costume = authors[index];
                    registartion_Form.UserType = "User";
                    registartion_Form.Volunteer_ID = registartion_Form.ParticipantsID == 1 || registartion_Form.ParticipantsID == 1 ? null : registartion_Form.Volunteer_ID;
                    pcdb.RegistrationDetails.Add(registartion_Form);
                    pcdb.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(registartion_Form);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}