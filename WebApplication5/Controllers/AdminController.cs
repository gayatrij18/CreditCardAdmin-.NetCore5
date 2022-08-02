using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class AdminController : Controller
    {
        private UserReg1Entities db = new UserReg1Entities();

        // GET: Admin
        public ActionResult Index()
        {
            
            List<tbl_WebsiteUsers> customernames = db.tbl_WebsiteUsers.ToList();
            List<tbl_CreditCardRequests> requestornames = db.tbl_CreditCardRequests.ToList();
            var userList = from c in customernames
                           join r in requestornames on c.UserId equals r.UserID
                           select new RequestInfo { customers = c, requestors = r };


            
            return View(userList);
            
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_WebsiteUsers tbl_WebsiteUsers = db.tbl_WebsiteUsers.Find(id);
            if (tbl_WebsiteUsers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_WebsiteUsers);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,Gender,PhoneNumber,Email,Password")] tbl_WebsiteUsers tbl_WebsiteUsers)
        {
            if (ModelState.IsValid)
            {
                db.tbl_WebsiteUsers.Add(tbl_WebsiteUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_WebsiteUsers);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_WebsiteUsers tbl_WebsiteUsers = db.tbl_WebsiteUsers.Find(id);
            if (tbl_WebsiteUsers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_WebsiteUsers);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,Gender,PhoneNumber,Email,Password")] tbl_WebsiteUsers tbl_WebsiteUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_WebsiteUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_WebsiteUsers);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_WebsiteUsers tbl_WebsiteUsers = db.tbl_WebsiteUsers.Find(id);
            if (tbl_WebsiteUsers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_WebsiteUsers);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_WebsiteUsers tbl_WebsiteUsers = db.tbl_WebsiteUsers.Find(id);
            tbl_CreditCardRequests tbl_CreditCardRequests = db.tbl_CreditCardRequests.Find(id);
            db.tbl_CreditCardRequests.Remove(tbl_CreditCardRequests);
            db.tbl_WebsiteUsers.Remove(tbl_WebsiteUsers);
           
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
