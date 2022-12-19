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
    public class SponserListsController : Controller
    {
        private PrestonClubDBEntities db = new PrestonClubDBEntities();

        // GET: SponserLists
        public ActionResult Index()
        {
            if (Session["Role"] == null && Session["Role"].ToString() != "admin")
            {
                return RedirectToAction("/");
            }

            return View(db.SponserLists.Include(r => r.AmateurSponserDetails).ToList());
        }

        // GET: SponserLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponserList sponserList = db.SponserLists.Include(r => r.AmateurSponserDetails).ToList().Where(m => m.ID == id).FirstOrDefault();
            if (sponserList == null)
            {
                return HttpNotFound();
            }
            return View(sponserList);
        }

        // GET: SponserLists/Create
        public ActionResult Create()
        {
            SponsorDetailsModel sm = new SponsorDetailsModel();
            sm.spl = new SponserList();
            sm.rgf = db.RegistrationDetails.Where(m => m.ParticipantsID == 1).ToList();
            sm.asi = new List<AmateurSponserDetail>();
            return View(sm);
        }

        // POST: SponserLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SponsorDetailsModel sponserList)
        {
            var sponseInfo = db.SponserLists.Add(sponserList.spl);
            db.SaveChanges();
            foreach (var item in sponserList.asi)
            {
                item.Sponsor_Id = sponseInfo.ID;
                db.AmateurSponserDetails.Add(item);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: SponserLists/Edit/5
        public ActionResult Edit(int? id)
        {
            SponsorDetailsModel sm = new SponsorDetailsModel();
            sm.spl = db.SponserLists.Where(m => m.ID == id).ToList().FirstOrDefault();
            sm.rgf = db.RegistrationDetails.Where(m => m.ParticipantsID == 1).ToList();
            sm.asi = db.AmateurSponserDetails.Where(m => m.Sponsor_Id == sm.spl.ID).ToList();

            return View(sm);
        }

        // POST: SponserLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SponsorDetailsModel sponserList)
        {
                var sponseInfo = db.SponserLists.Where(m => m.ID == sponserList.spl.ID).FirstOrDefault();
                sponseInfo.Name = sponserList.spl.Name;
                db.SaveChanges();
                foreach (var item in sponserList.asi)
                {
                    if (item.ID > 0)
                    {
                        var asiInfo = db.AmateurSponserDetails.Where(m => m.ID == item.ID).FirstOrDefault();
                        asiInfo.SponsorAmount = item.SponsorAmount;
                        db.SaveChanges();
                    }
                    else
                    {
                        item.Sponsor_Id = sponseInfo.ID;
                        db.AmateurSponserDetails.Add(item);
                        db.SaveChanges();
                    }
                }
            return RedirectToAction("Index");
        }

        // GET: SponserLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponserList sponserList = db.SponserLists.Find(id);
            if (sponserList == null)
            {
                return HttpNotFound();
            }
            return View(sponserList);
        }

        // POST: SponserLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SponserList sponserList = db.SponserLists.Find(id);
            db.SponserLists.Remove(sponserList);
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
