using SoT.Application.Interfaces;
using SoT.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SoT.Presentation.UI.MVC.Controllers
{
    [Authorize]
    public class CityController : Controller
    {
        private readonly ICityAppService cityAppService;
        private readonly ICountryAppService countryAppService;

        public CityController(ICityAppService cityAppService, ICountryAppService countryAppService)
        {
            this.cityAppService = cityAppService;
            this.countryAppService = countryAppService;
        }

        // GET: City
        public ActionResult Index()
        {
            var cities = cityAppService.GetAll();
            return View(cities.ToList());
        }

        // GET: City/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cityViewModel = cityAppService.GetById((Guid)id);
            if (cityViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cityViewModel);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            var countries = countryAppService.GetAll();
            ViewBag.CountryId = new SelectList(countries, "CountryId", "Name");
            return View();
        }

        // POST: City/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "CityId,Name,Active,CountryId")]
            CityViewModel cityViewModel)
        {
            //if (ModelState.IsValid)
            //{
            //    cityViewModel.CityId = Guid.NewGuid();
            //    db.Cities.Add(cityViewModel);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", cityViewModel.CountryId);
            return View(cityViewModel);
        }

        // GET: City/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cityViewModel = cityAppService.GetById((Guid)id);
            if (cityViewModel == null)
            {
                return HttpNotFound();
            }
            var countries = countryAppService.GetAll();
            ViewBag.CountryId = new SelectList(countries, "CountryId", "Name", cityViewModel.CountryId);
            return View(cityViewModel);
        }

        // POST: City/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "CityId,Name,Active,CountryId")]
            CityViewModel cityViewModel)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(cityViewModel).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", cityViewModel.CountryId);
            return View(cityViewModel);
        }

        // GET: City/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cityViewModel = cityAppService.GetById((Guid)id);
            if (cityViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cityViewModel);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var cityViewModel = cityAppService.GetById((Guid)id);
            //db.Cities.Remove(city);
            //db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public JsonResult GetActiveByCountry(Guid id)
        {
            var cities = cityAppService.GetActiveByCountry(id);

            var selectList = GetSelectList(cities);

            return Json(selectList);
        }

        private static IEnumerable<SelectListItem> GetSelectList(IEnumerable<CityViewModel> cities)
        {
            var selectList = new List<SelectListItem>();

            foreach (var city in cities)
            {
                selectList.Add(
                    new SelectListItem
                    {
                        Text = city.Name,
                        Value = city.CityId.ToString()
                    }
                    );
            }

            return selectList;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cityAppService.Dispose();
                countryAppService.Dispose();
                GC.SuppressFinalize(this);
            }
            base.Dispose(disposing);
        }
    }
}
