using SoT.Application.AppServices;
using SoT.Application.ViewModels;
using SoT.Domain.Entities.Example;
using System;
using System.Net;
using System.Web.Mvc;

namespace SoT.Presentation.UI.MVC.Controllers
{
    public class ExamplesController : Controller
    {
        private ExampleAppService db = new ExampleAppService();

        // GET: Examples
        public ActionResult Index()
        {
            return View(db.GetAll());
        }

        // GET: Examples/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Example example = db.GetById(id.Value);
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
        public ActionResult Create(
            [Bind(Include = "ExampleId,Name,DatePropertyName,StringPropertyName,SubExampleDatePropertyName")]
            ExampleSubExampleViewModel ExampleSubExampleViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Add(ExampleSubExampleViewModel);
                return RedirectToAction("Index");
            }

            return View(ExampleSubExampleViewModel);
        }

        // GET: Examples/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Example example = db.GetById(id.Value);
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
                db.Update(example);
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
            Example example = db.GetById(id.Value);
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
            db.Delete(id);
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
