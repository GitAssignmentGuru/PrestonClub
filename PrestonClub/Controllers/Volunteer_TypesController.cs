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
    public class Volunteer_TypesController : Controller
    {
        private PrestonClubDBEntities db = new PrestonClubDBEntities();

        // GET: Volunteer_Types
        public ActionResult Index()
        {
            return View(db.Volunteer_Types.ToList());
        }

        // GET: Volunteer_Types/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer_Types volunteer_Types = db.Volunteer_Types.Find(id);
            if (volunteer_Types == null)
            {
                return HttpNotFound();
            }
            return View(volunteer_Types);
        }

        // GET: Volunteer_Types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Volunteer_Types/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Volunteer_Types volunteer_Types)
        {
            if (ModelState.IsValid)
            {
                db.Volunteer_Types.Add(volunteer_Types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volunteer_Types);
        }

        // GET: Volunteer_Types/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer_Types volunteer_Types = db.Volunteer_Types.Find(id);
            if (volunteer_Types == null)
            {
                return HttpNotFound();
            }
            return View(volunteer_Types);
        }

        // POST: Volunteer_Types/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Volunteer_Types volunteer_Types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteer_Types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volunteer_Types);
        }

        // GET: Volunteer_Types/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer_Types volunteer_Types = db.Volunteer_Types.Find(id);
            if (volunteer_Types == null)
            {
                return HttpNotFound();
            }
            return View(volunteer_Types);
        }

        // POST: Volunteer_Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volunteer_Types volunteer_Types = db.Volunteer_Types.Find(id);
            db.Volunteer_Types.Remove(volunteer_Types);
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
