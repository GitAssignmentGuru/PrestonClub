using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrestonClub.Models;

namespace PrestonClub.Controllers
{
    public class RegistrationDetailsController : Controller
    {
        private PrestonClubDBEntities db = new PrestonClubDBEntities();

        // GET: RegistrationDetails
        public ActionResult Index()
        {
            if (Session["Role"] == null)
            {
                return RedirectToAction("/");
            }

            if (Session["Role"].ToString() == "admin")
            {
                var registartion_Form = db.RegistrationDetails.Include(r => r.ParticipantDetail).Include(r => r.Volunteer_Types).Include(r => r.AmateurSponserDetails);
                return View(registartion_Form.ToList());
            }
            else
            {
                int loginID = Convert.ToInt32(Session["UserID"].ToString());
                var registartion_Form = db.RegistrationDetails.Include(r => r.ParticipantDetail).Include(r => r.Volunteer_Types).Include(r => r.AmateurSponserDetails).Where(m => m.ID == loginID);
                return View(registartion_Form.ToList());
            }
        }

        // GET: RegistrationDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationDetail registrationDetail = db.RegistrationDetails.Find(id);
            if (registrationDetail == null)
            {
                return HttpNotFound();
            }
            return View(registrationDetail);
        }

        // GET: RegistrationDetails/Create
        public ActionResult Create()
        {
            ViewBag.ParticipantsID = new SelectList(db.ParticipantDetails, "ID", "Name");
            ViewBag.Volunteer_ID = new SelectList(db.Volunteer_Types, "ID", "Name");
            return View();
        }

        // POST: RegistrationDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,first_name,last_name,email,phone_number,address,ParticipantsID,WorldRanking,Volunteer_ID,password,UserType,costume")] RegistrationDetail registrationDetail)
        {
            if (ModelState.IsValid)
            {
                db.RegistrationDetails.Add(registrationDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParticipantsID = new SelectList(db.ParticipantDetails, "ID", "Name", registrationDetail.ParticipantsID);
            ViewBag.Volunteer_ID = new SelectList(db.Volunteer_Types, "ID", "Name", registrationDetail.Volunteer_ID);
            return View(registrationDetail);
        }

        // GET: RegistrationDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationDetail registrationDetail = db.RegistrationDetails.Find(id);
            if (registrationDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParticipantsID = new SelectList(db.ParticipantDetails, "ID", "Name", registrationDetail.ParticipantsID);
            ViewBag.Volunteer_ID = new SelectList(db.Volunteer_Types, "ID", "Name", registrationDetail.Volunteer_ID);
            return View(registrationDetail);
        }

        // POST: RegistrationDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,first_name,last_name,email,phone_number,address,ParticipantsID,WorldRanking,Volunteer_ID,password,UserType,costume")] RegistrationDetail registrationDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrationDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParticipantsID = new SelectList(db.ParticipantDetails, "ID", "Name", registrationDetail.ParticipantsID);
            ViewBag.Volunteer_ID = new SelectList(db.Volunteer_Types, "ID", "Name", registrationDetail.Volunteer_ID);
            return View(registrationDetail);
        }

        // GET: RegistrationDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationDetail registrationDetail = db.RegistrationDetails.Find(id);
            if (registrationDetail == null)
            {
                return HttpNotFound();
            }
            return View(registrationDetail);
        }

        // POST: RegistrationDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistrationDetail registrationDetail = db.RegistrationDetails.Find(id);
            db.RegistrationDetails.Remove(registrationDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
