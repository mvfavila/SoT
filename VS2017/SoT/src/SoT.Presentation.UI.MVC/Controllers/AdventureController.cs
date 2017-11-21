using Microsoft.AspNet.Identity;
using SoT.Application.Interfaces;
using SoT.Application.ViewModels;
using System;
using System.Net;
using System.Web.Mvc;

namespace SoT.Presentation.UI.MVC.Controllers
{
    public class AdventureController : Controller
    {
        private readonly IAdventureAppService adventureAppService;
        private readonly ICountryAppService countryAppService;
        private readonly ICityAppService cityAppService;
        private readonly ICategoryAppService categoryAppService;

        public AdventureController(IAdventureAppService adventureAppService, ICountryAppService countryAppService,
            ICityAppService cityAppService, ICategoryAppService categoryAppService)
        {
            this.adventureAppService = adventureAppService;
            this.countryAppService = countryAppService;
            this.cityAppService = cityAppService;
            this.categoryAppService = categoryAppService;
        }

        // GET: Adventure/Details/5
        public ActionResult Details(Guid? id)
        {
            var loggedId = User.Identity.GetUserId();

            if (id == null || loggedId == null || !Guid.TryParse(loggedId, out Guid userId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adventureAddressViewModel = adventureAppService.GetById((Guid)id, userId);
            if (adventureAddressViewModel == null)
            {
                return HttpNotFound();
            }
            return View(adventureAddressViewModel);
        }

        // GET: Adventure/Create
        public ActionResult Create()
        {
            var categories = categoryAppService.GetAll();
            var countries = countryAppService.GetAll();
            var cities = cityAppService.GetAll();

            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");
            ViewBag.CityId = new SelectList(countries, "CountryId", "Name");
            ViewBag.CityId = new SelectList(cities, "CityId", "Name");
            return View();
        }

        // POST: Adventure/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "AdventureId,Name,CategoryId,CityId,AddressId,InsurenceMinimalAmount,ProviderId,Active")]
            AdventureAddressViewModel adventureAddressViewModel)
        {
            //if (ModelState.IsValid)
            //{
            //    adventureAddressViewModel.AdventureId = Guid.NewGuid();
            //    db.Adventures.Add(adventureAddressViewModel);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "Street01", adventureAddressViewModel.AddressId);
            //ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", adventureAddressViewModel.CategoryId);
            //ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", adventureAddressViewModel.CityId);
            //ViewBag.ProviderId = new SelectList(db.Providers, "ProviderId", "CompanyName", adventureAddressViewModel.ProviderId);
            return View(adventureAddressViewModel);
        }

        // GET: Adventure/Edit/5
        public ActionResult Edit(Guid? id)
        {
            var loggedId = User.Identity.GetUserId();

            if (id == null || loggedId == null || !Guid.TryParse(loggedId, out Guid userId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adventureAddressViewModel = adventureAppService.GetById((Guid)id, userId);
            if (adventureAddressViewModel == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "Street01", adventureAddressViewModel.AddressId);
            //ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", adventureAddressViewModel.CategoryId);
            //ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", adventureAddressViewModel.CityId);
            //ViewBag.ProviderId = new SelectList(db.Providers, "ProviderId", "CompanyName", adventureAddressViewModel.ProviderId);
            return View(adventureAddressViewModel);
        }

        // POST: Adventure/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "AdventureId,Name,CategoryId,CityId,AddressId,InsurenceMinimalAmount,ProviderId,Active")]
            AdventureAddressViewModel adventureAddressViewModel)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(adventure).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "Street01", adventure.AddressId);
            //ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", adventure.CategoryId);
            //ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", adventure.CityId);
            //ViewBag.ProviderId = new SelectList(db.Providers, "ProviderId", "CompanyName", adventure.ProviderId);
            return View(adventureAddressViewModel);
        }

        // GET: Adventure/Delete/5
        public ActionResult Delete(Guid? id)
        {
            var loggedId = User.Identity.GetUserId();

            if (id == null || loggedId == null || !Guid.TryParse(loggedId, out Guid userId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adventureAddressViewModel = adventureAppService.GetById((Guid)id, userId);
            if (adventureAddressViewModel == null)
            {
                return HttpNotFound();
            }
            return View(adventureAddressViewModel);
        }

        // POST: Adventure/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            //var adventure = db.Adventures.Find(id);
            //db.Adventures.Remove(adventure);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                adventureAppService.Dispose();
                countryAppService.Dispose();
                cityAppService.Dispose();
                categoryAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
