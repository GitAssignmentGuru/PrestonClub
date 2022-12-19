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
    public class RunnerStatusController : Controller
    {
        private PrestonClubDBEntities db = new PrestonClubDBEntities();

        // GET: RunnerStatus
        public ActionResult Index()
        {
            if (Session["Role"] == null)
            {
                return RedirectToAction("/");
            }
            if (Session["Role"].ToString() == "admin")
            {
                var runnerStatus = db.RunnerStatus.Include(r => r.RegistrationDetail);
                return View(runnerStatus.ToList());
            }
            else
            {
                int loginID = Convert.ToInt32(Session["UserID"].ToString());
                var runnerStatus = db.RunnerStatus.Include(r => r.RegistrationDetail).Where(m => m.Runner_ID == loginID);
                return View(runnerStatus.ToList());
            }
        }

        // GET: RunnerStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RunnerStatu runnerStatu = db.RunnerStatus.Find(id);
            if (runnerStatu == null)
            {
                return HttpNotFound();
            }
            return View(runnerStatu);
        }

        // GET: RunnerStatus/Create
        public ActionResult Create()
        {
            ViewBag.Runner_ID = new SelectList(db.RegistrationDetails, "ID", "first_name");
            return View();
        }

        // POST: RunnerStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Runner_ID,RunningStatus,FinishedTime")] RunnerStatu runnerStatu)
        {
            if (ModelState.IsValid)
            {
                db.RunnerStatus.Add(runnerStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Runner_ID = new SelectList(db.RegistrationDetails, "ID", "first_name", runnerStatu.Runner_ID);
            return View(runnerStatu);
        }

        // GET: RunnerStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RunnerStatu runnerStatu = db.RunnerStatus.Find(id);
            if (runnerStatu == null)
            {
                return HttpNotFound();
            }
            ViewBag.Runner_ID = new SelectList(db.RegistrationDetails, "ID", "first_name", runnerStatu.Runner_ID);
            return View(runnerStatu);
        }

        // POST: RunnerStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Runner_ID,RunningStatus,FinishedTime")] RunnerStatu runnerStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(runnerStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Runner_ID = new SelectList(db.RegistrationDetails, "ID", "first_name", runnerStatu.Runner_ID);
            return View(runnerStatu);
        }

        // GET: RunnerStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RunnerStatu runnerStatu = db.RunnerStatus.Find(id);
            if (runnerStatu == null)
            {
                return HttpNotFound();
            }
            return View(runnerStatu);
        }

        // POST: RunnerStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RunnerStatu runnerStatu = db.RunnerStatus.Find(id);
            db.RunnerStatus.Remove(runnerStatu);
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

        public ActionResult SponsorShipForm(int? id)
        {
            if (Session["Role"] == null)
            {
                return RedirectToAction("/");
            }
            var registartion_Form = db.RegistrationDetails.Include(r => r.ParticipantDetail).Include(r => r.Volunteer_Types).Include(r => r.AmateurSponserDetails).Where(m => m.ID == id).FirstOrDefault();
            return View(registartion_Form);
        }

        public ActionResult Certificate(int? id)
        {
            if (Session["Role"] == null)
            {
                return RedirectToAction("/");
            }
            var registartion_Form = db.RegistrationDetails.Include(r => r.ParticipantDetail).Include(r => r.Volunteer_Types).Include(r => r.AmateurSponserDetails).Where(m => m.ID == id).FirstOrDefault();
            return View(registartion_Form);
        }
    }
}
