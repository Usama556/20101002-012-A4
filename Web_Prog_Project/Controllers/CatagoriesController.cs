﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Prog_Project.Models;

namespace Web_Prog_Project.Controllers
{
    public class CatagoriesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Catagories
        public ActionResult Index()
        {
            return View(db.Catagories.ToList());
        }

        // GET: Catagories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catagory catagory = db.Catagories.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        // GET: Catagories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catagories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Catagory_ID,Catagory_Name")] Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                db.Catagories.Add(catagory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catagory);
        }

        // GET: Catagories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catagory catagory = db.Catagories.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        // POST: Catagories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Catagory_ID,Catagory_Name")] Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catagory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catagory);
        }

        // GET: Catagories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catagory catagory = db.Catagories.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        // POST: Catagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catagory catagory = db.Catagories.Find(id);
            db.Catagories.Remove(catagory);
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
