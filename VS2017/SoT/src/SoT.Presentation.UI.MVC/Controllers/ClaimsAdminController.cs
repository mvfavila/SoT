using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SoT.Infra.CrossCutting.Identity;
using SoT.Infra.CrossCutting.Identity.Configuration;
using SoT.Infra.CrossCutting.Identity.Context;
using SoT.Infra.CrossCutting.MvcFilters;
using SoT.Presentation.UI.MVC.ViewModels.Claims;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SoT.Presentation.UI.MVC.Controllers
{
    [ClaimsAuthorize("AdmClaims", "True")]
    public class ClaimsAdminController : Controller
    {
        private readonly ApplicationUserManager userManager;
        private readonly IdentityContext dbContext;

        public ClaimsAdminController(ApplicationUserManager userManager, IdentityContext dbContext)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        // GET: ClaimsAdmin
        public ActionResult Index()
        {
            return View(dbContext.Claims.ToList());
        }

        // GET: ClaimsAdmin/SetUserClaim
        public ActionResult SetUserClaim(string id)
        {
            ViewBag.Type = new SelectList
                (
                    dbContext.Claims.ToList(),
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
                    dbContext.Claims.Add(claim);
                    dbContext.SaveChanges();
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