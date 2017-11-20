using SoT.Application.ViewModels;
using SoT.Infra.CrossCutting.MvcFilters;
using System.Web.Mvc;

namespace SoT.Presentation.UI.MVC.Controllers
{
    public class AdventureController : Controller
    {
        // GET: Adventure/Create
        [ClaimsAuthorize("ManageAdventure", "True")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adventure/Create
        [ClaimsAuthorize("ManageAdventure", "True")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "")]
            AdventureAddressViewModel adventureAddressViewModel)
        {
            if (ModelState.IsValid)
            {
                //adventureAddressViewModel.UserId = Guid.Parse(User.Identity.GetUserId());

                //var result = providerAppService.Add(adventureAddressViewModel);
                //if (!result.IsValid)
                //{
                //    foreach (var validationAppError in result.Errors)
                //    {
                //        ModelState.AddModelError(string.Empty, validationAppError.Message);
                //    }
                //    return View(adventureAddressViewModel);
                //}

                //// TODO: check if this should be the action to redirect to
                //return RedirectToAction("Index", "Home");
            }

            return View(adventureAddressViewModel);
        }
    }
}