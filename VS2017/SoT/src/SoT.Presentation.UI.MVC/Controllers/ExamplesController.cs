using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoT.Domain.Entities.Example;
using SoT.Infra.Data.Context;

namespace SoT.Presentation.UI.MVC.Controllers
{
    public class ExamplesController : Controller
    {
        private SoTContext db = new SoTContext();

        // GET: Examples
        public ActionResult Index()
        {
            return View(db.Examples.ToList());
        }

        // GET: Examples/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Example example = db.Examples.Find(id);
            if (example == null)
            {
                return HttpNotFound();
            }
            return View(example);
        }

        // GET: Examples/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Examples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExampleId,Name,DatePropertyName,Active,RegisterDate")] Example example)
        {
            if (ModelState.IsValid)
            {
                example.ExampleId = Guid.NewGuid();
                db.Examples.Add(example);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(example);
        }

        // GET: Examples/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Example example = db.Examples.Find(id);
            if (example == null)
            {
                return HttpNotFound();
            }
            return View(example);
        }

        // POST: Examples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExampleId,Name,DatePropertyName,Active,RegisterDate")] Example example)
        {
            if (ModelState.IsValid)
            {
                db.Entry(example).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(example);
        }

        // GET: Examples/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Example example = db.Examples.Find(id);
            if (example == null)
            {
                return HttpNotFound();
            }
            return View(example);
        }

        // POST: Examples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Example example = db.Examples.Find(id);
            db.Examples.Remove(example);
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
