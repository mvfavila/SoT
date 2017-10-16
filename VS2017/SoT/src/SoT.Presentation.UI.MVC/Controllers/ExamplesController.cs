using SoT.Application.Interfaces;
using SoT.Application.ViewModels;
using System;
using System.Net;
using System.Web.Mvc;

namespace SoT.Presentation.UI.MVC.Controllers
{
    public class ExamplesController : Controller
    {
        private readonly IExampleAppService exampleAppService;

        public ExamplesController(IExampleAppService exampleAppService)
        {
            this.exampleAppService = exampleAppService;
        }

        // GET: Examples
        public ActionResult Index()
        {
            return View(exampleAppService.GetAll());
        }

        // GET: Examples/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var example = exampleAppService.GetById(id.Value);
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
            ExampleSubExampleViewModel exampleSubExampleViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = exampleAppService.Add(exampleSubExampleViewModel);
                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return View(exampleSubExampleViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(exampleSubExampleViewModel);
        }

        // GET: Examples/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var example = exampleAppService.GetById(id.Value);
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
        public ActionResult Edit([Bind(Include = "ExampleId,Name,DatePropertyName,Active,RegisterDate")] ExampleViewModel example)
        {
            if (ModelState.IsValid)
            {
                exampleAppService.Update(example);
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
            var example = exampleAppService.GetById(id.Value);
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
            exampleAppService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                exampleAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
