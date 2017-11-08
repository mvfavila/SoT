using Microsoft.AspNet.Identity;
using SoT.Infra.CrossCutting.Identity;
using SoT.Infra.CrossCutting.Identity.Configuration;
using SoT.Infra.CrossCutting.Identity.Context;
using SoT.Infra.CrossCutting.MvcFilters;
using SoT.Presentation.UI.MVC.ViewModels.Claims;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace SoT.Presentation.UI.MVC.Controllers
{
    [ClaimsAuthorize("AdmClaims", "True")]
    public class ClaimsAdminController : Controller
    {
        private readonly AppDbContext appDbContext;

        private readonly ApplicationUserManager userManager;

        public ClaimsAdminController(ApplicationUserManager userManager, AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
        }

        // GET: ClaimsAdmin
        public ActionResult Index()
        {
            return View(appDbContext.Claims.ToList());
        }

        // GET: ClaimsAdmin/SetUserClaim
        public ActionResult SetUserClaim(string id)
        {
            ViewBag.Type = new SelectList
                (
                    appDbContext.Claims.ToList(),
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
                userManager.AddClaimAsync(id, new Claim(claim.Type, claim.Value));

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
        public ActionResult CreateClaim(Claims claim)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    appDbContext.Claims.Add(claim);
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