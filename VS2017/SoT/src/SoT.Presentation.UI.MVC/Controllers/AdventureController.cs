using Microsoft.AspNet.Identity;
using SoT.Application.Interfaces;
using SoT.Application.ViewModels;
using SoT.Infra.CrossCutting.MvcFilters;
using System;
using System.Collections.Generic;
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
        private readonly IProviderAppService providerAppService;

        public AdventureController(IAdventureAppService adventureAppService, ICountryAppService countryAppService,
            ICityAppService cityAppService, ICategoryAppService categoryAppService,
            IProviderAppService providerAppService)
        {
            this.adventureAppService = adventureAppService;
            this.countryAppService = countryAppService;
            this.cityAppService = cityAppService;
            this.categoryAppService = categoryAppService;
            this.providerAppService = providerAppService;
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

        // GET: Adventure/List
        [ClaimsAuthorize("ManageAdventure", "True")]
        public ActionResult List()
        {
            var loggedId = User.Identity.GetUserId();

            if (loggedId == null || !Guid.TryParse(loggedId, out Guid userId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adventureAddressViewModels = adventureAppService.GetAllByUser(userId);
            if (adventureAddressViewModels == null)
            {
                return HttpNotFound();
            }
            return View(adventureAddressViewModels);
        }

        // GET: Adventure/Create
        [ClaimsAuthorize("ManageAdventure", "True")]
        public ActionResult Create()
        {
            PopulateDropDownLists();
            return View();
        }

        // POST: Adventure/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("ManageAdventure", "True")]
        public ActionResult Create(
            [Bind(Include = @"AdventureId,Name,CategoryId,CityId,AddressId,InsurenceMinimalAmount,ProviderId,Active,
            Street01,Complement,Postcode")]
            AdventureAddressViewModel adventureAddressViewModel)
        {
            if (ModelState.IsValid)
            {
                var loggedId = User.Identity.GetUserId();

                if (loggedId == null || !Guid.TryParse(loggedId, out Guid userId))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var provider = providerAppService.GetByUserId(userId);
                if(provider == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                adventureAddressViewModel.ProviderId = provider.ProviderId;

                var result = adventureAppService.Add(adventureAddressViewModel);
                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return View(adventureAddressViewModel);
                }

                return RedirectToAction($"List", "Adventure");
            }

            PopulateDropDownLists();
            return View(adventureAddressViewModel);
        }

        private void PopulateDropDownLists()
        {
            var categories = categoryAppService.GetAllActive();
            var countries = countryAppService.GetAllActive();
            var cities = new List<CityViewModel>();

            ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");
            ViewBag.Countries = new SelectList(countries, "CountryId", "Name");
            ViewBag.Cities = new SelectList(cities, "CityId", "Name");
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
