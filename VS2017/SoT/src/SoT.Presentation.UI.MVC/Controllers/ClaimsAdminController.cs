using Microsoft.AspNet.Identity;
using SoT.Application.Interfaces;
using SoT.Application.ViewModels;
using SoT.Infra.CrossCutting.Identity.Configuration;
using SoT.Infra.CrossCutting.MvcFilters;
using System;
using System.Web.Mvc;

namespace SoT.Presentation.UI.MVC.Controllers
{
    [ClaimsAuthorize("AdmClaims", "True")]
    public class ClaimsAdminController : Controller
    {
        private readonly IClaimAppService claimAppService;

        private readonly ApplicationUserManager userManager;

        public ClaimsAdminController(ApplicationUserManager userManager, IClaimAppService claimAppService)
        {
            this.claimAppService = claimAppService;
            this.userManager = userManager;
        }

        // GET: ClaimsAdmin
        public ActionResult Index()
        {
            return View(claimAppService.GetAll());
        }

        // GET: ClaimsAdmin/SetUserClaim
        public ActionResult SetUserClaim(string id)
        {
            ViewBag.Type = new SelectList
                (
                    claimAppService.GetAll(),
                    "Name",
                    "Name"
                );

            ViewBag.User = userManager.FindById(id);

            return View();
        }

        // POST: ClaimsAdmin/SetUserClaim
        [HttpPost]
        public ActionResult SetUserClaim(ClaimViewModel claim, string id)
        {
            try
            {
                // TODO: Fix this
                //userManager.AddClaimAsync(id, new Claim(claim.Type, claim.Value));

                return RedirectToAction("Details", "UsersAdmin", new { id = id });
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: ClaimsAdmin/CreateClaim
        public ActionResult CreateClaim()
        {
            return View();
        }

        // POST: ClaimsAdmin/CreateClaim
        [HttpPost]
        //TODO: changed from this: public ActionResult CreateClaim(Claims claim)
        public ActionResult CreateClaim(ClaimViewModel claim)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    claimAppService.Add(claim);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}