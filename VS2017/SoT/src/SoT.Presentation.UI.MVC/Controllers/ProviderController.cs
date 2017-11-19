using Microsoft.AspNet.Identity;
using SoT.Application.Interfaces;
using SoT.Application.ViewModels;
using SoT.Infra.CrossCutting.MvcFilters;
using System;
using System.Net;
using System.Web.Mvc;

namespace SoT.Presentation.UI.MVC.Controllers
{
    [Authorize]
    public class ProviderController : Controller
    {
        private readonly IProviderAppService providerAppService;

        public ProviderController(IProviderAppService providerAppService)
        {
            this.providerAppService = providerAppService;
        }

        [ClaimsAuthorize("ManageProvider", "True")]
        // GET: Provider/Details
        public ActionResult Details()
        {
            var loggedId = User.Identity.GetUserId();

            if (loggedId == null || !Guid.TryParse(loggedId, out Guid userId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeProviderViewModel = providerAppService.GetByUserId(userId);
            if (employeeProviderViewModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeProviderViewModel);
        }

        // GET: Provider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provider/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "EmployeeId,BirthDate,ProviderId,CompanyName,RegisterDate")]
            EmployeeProviderViewModel employeeProviderViewModel)
        {
            if (ModelState.IsValid)
            {
                employeeProviderViewModel.UserId = Guid.Parse(User.Identity.GetUserId());

                var result = providerAppService.Add(employeeProviderViewModel);
                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return View(employeeProviderViewModel);
                }

                // TODO: check if this should be the action to redirect to
                return RedirectToAction("Index", "Home");
            }

            return View(employeeProviderViewModel);
        }

        [ClaimsAuthorize("ManageProvider", "True")]
        // GET: Provider/Edit
        public ActionResult Edit()
        {
            var loggedId = User.Identity.GetUserId();

            if (loggedId == null || !Guid.TryParse(loggedId, out Guid userId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeProviderViewModel = providerAppService.GetByUserId(userId);
            if (employeeProviderViewModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeProviderViewModel);
        }

        [ClaimsAuthorize("ManageProvider", "True")]
        // POST: Provider/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Email,Name,Surname,BirthDate,ProviderId,CompanyName,Active,RegisterDate")]
            EmployeeProviderViewModel employeeProviderViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = providerAppService.Update(employeeProviderViewModel);
                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return View(employeeProviderViewModel);
                }

                // TODO: check if this should be the action to redirect to
                return RedirectToAction("Index", "Home");
            }

            return View(employeeProviderViewModel);
        }

        [ClaimsAuthorize("ManageProvider", "True")]
        // GET: Provider/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeProviderViewModel = providerAppService.GetByUserId(Guid.Parse(id));
            if (employeeProviderViewModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeProviderViewModel);
        }

        [ClaimsAuthorize("ManageProvider", "True")]
        // POST: Provider/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            providerAppService.Delete(Guid.Parse(id));
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                providerAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
