using Microsoft.AspNet.Identity;
using SoT.Application.Interfaces;
using SoT.Application.ViewModels;
using SoT.Infra.CrossCutting.Identity.Configuration;
using SoT.Infra.CrossCutting.MvcFilters;
using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SoT.Presentation.UI.MVC.Controllers
{
    [Authorize]
    public class ProviderController : Controller
    {
        private ApplicationUserManager userManager;
        private readonly IProviderAppService providerAppService;
        private readonly IGenderAppService genderAppService;

        public ProviderController(ApplicationUserManager userManager, IProviderAppService providerAppService, IGenderAppService genderAppService)
        {
            this.userManager = userManager;
            this.providerAppService = providerAppService;
            this.genderAppService = genderAppService;
        }

        [ClaimsAuthorize("AdmProviders", "True")]
        // GET: Provider/List
        public ActionResult List()
        {
            var prodiverViewModel = providerAppService.GetAll();

            if (prodiverViewModel == null)
            {
                return HttpNotFound();
            }
            return View(prodiverViewModel);
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
            var loggedId = User.Identity.GetUserId();

            if (loggedId == null || !Guid.TryParse(loggedId, out Guid userId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employeeProviderViewModel = providerAppService.GetByUserId(userId);
            if (employeeProviderViewModel != null)
            {
                return RedirectToAction(nameof(Details), "Provider");
            }

            var genders = genderAppService.GetAllActive();

            return View(new EmployeeProviderViewModel { Genders = genders });
        }

        // POST: Provider/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "EmployeeId,BirthDate,ProviderId,CompanyName,RegisterDate,GenderId")]
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

                await ConfigureClaims(employeeProviderViewModel);

                await userManager.SendSmsAsync("f9babd79-00ca-4b97-83c7-b908f39d5585", $"This is an automatic message./nHi, the company {employeeProviderViewModel.CompanyName} wants to became a SoT Provider. Please check his registration.");

                // TODO: check if this should be the action to redirect to
                return RedirectToAction("Index", "Home");
            }

            return View(employeeProviderViewModel);
        }

        private async Task ConfigureClaims(EmployeeProviderViewModel employeeProviderViewModel)
        {
            const string CLAIM_IS_PROVIDER_TYPE = "IsProvider";
            const string CLAIM_IS_PROVIDER_OLD_VALUE = "False";
            const string CLAIM_IS_PROVIDER_NEW_VALUE = "True";

            userManager.RemoveClaim(employeeProviderViewModel.UserId.ToString(),
                new Claim(CLAIM_IS_PROVIDER_TYPE, CLAIM_IS_PROVIDER_OLD_VALUE));
            await userManager.AddClaimAsync(employeeProviderViewModel.UserId.ToString(),
                new Claim(CLAIM_IS_PROVIDER_TYPE, CLAIM_IS_PROVIDER_NEW_VALUE));
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
            [Bind(Include = "EmployeeId,Email,Name,Surname,BirthDate,ProviderId,CompanyName,Active,RegisterDate")]
            EmployeeProviderViewModel employeeProviderViewModel)
        {
            if (ModelState.IsValid)
            {
                var loggedId = User.Identity.GetUserId();

                if (loggedId == null || !Guid.TryParse(loggedId, out Guid userId))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                employeeProviderViewModel.UserId = userId;

                var result = providerAppService.Update(employeeProviderViewModel);
                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return View(employeeProviderViewModel);
                }

                return RedirectToAction(nameof(Details), "Provider");
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
