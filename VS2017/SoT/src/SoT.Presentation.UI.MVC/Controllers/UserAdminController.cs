using SoT.Application.Interfaces;
using SoT.Application.ViewModels;
using SoT.Infra.CrossCutting.Identity;
using SoT.Infra.CrossCutting.Identity.Configuration;
using SoT.Infra.CrossCutting.MvcFilters;
using SoT.Presentation.UI.MVC.Mapping;
using SoT.Presentation.UI.MVC.ViewModels.Account;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SoT.Presentation.UI.MVC.Controllers
{
    [ClaimsAuthorize("AdmUsers", "True")]
    public class UsersAdminController : Controller
    {
        private readonly ApplicationUserManager userManager;
        private readonly ApplicationRoleManager roleManager;
        private readonly IProviderAppService providerAppService;
        private readonly IGenderAppService genderAppService;

        public UsersAdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager,
            IProviderAppService providerAppService, IGenderAppService genderAppService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.providerAppService = providerAppService;
            this.genderAppService = genderAppService;
        }

        // GET: /Users/
        public async Task<ActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();

            var userEmployeeProviderViewModels = UserMapper.FromIdentityToViewModel(users);

            return View(userEmployeeProviderViewModels.ToList());
        }

        // GET: /Users/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await userManager.FindByIdAsync(id);

            var userEmployeeProviderViewModel = UserMapper.FromIdentityToViewModel(user);

            userEmployeeProviderViewModel = providerAppService.LoadUserData(userEmployeeProviderViewModel);

            ViewBag.RoleNames = await userManager.GetRolesAsync(user.Id);
            ViewBag.Claims = await userManager.GetClaimsAsync(user.Id);

            return View(userEmployeeProviderViewModel);
        }

        // GET: /Users/Create
        public async Task<ActionResult> Create()
        {
            //Gets the list of Roles
            ViewBag.RoleId = new SelectList(await roleManager.Roles.ToListAsync(), "Name", "Name");
            return View();
        }

        // POST: /Users/Create
        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel userViewModel, params string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = userViewModel.Email, Email = userViewModel.Email };
                var adminresult = await userManager.CreateAsync(user, userViewModel.Password);

                //Add User to the selected Roles
                if (adminresult.Succeeded)
                {
                    if (selectedRoles != null)
                    {
                        var result = await userManager.AddToRolesAsync(user.Id, selectedRoles);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First());
                            ViewBag.RoleId = new SelectList(await roleManager.Roles.ToListAsync(), "Name", "Name");
                            return View();
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", adminresult.Errors.First());
                    ViewBag.RoleId = new SelectList(roleManager.Roles, "Name", "Name");
                    return View();

                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.RoleId = new SelectList(roleManager.Roles, "Name", "Name");
            return View();
        }

        // GET: /Users/Edit/1
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await userManager.FindByIdAsync(id);

            var userEmployeeProviderViewModel = UserMapper.FromIdentityToViewModel(user);

            userEmployeeProviderViewModel = providerAppService.LoadUserData(userEmployeeProviderViewModel);

            ViewBag.RoleNames = await userManager.GetRolesAsync(user.Id);
            ViewBag.Claims = await userManager.GetClaimsAsync(user.Id);

            var genders = genderAppService.GetAllActive();

            ViewBag.Genders = new SelectList(genders, "GenderId", "Value");

            return View(userEmployeeProviderViewModel);
        }

        // POST: /Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(
            [Bind(Include = "UserId,EmployeeId,ProviderId,UserName,CompanyName,Name,Lastname,Gender,BirthDate")]
            UserEmployeeProviderViewModel userEmployeeProviderViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(userEmployeeProviderViewModel.UserId.ToString());
                if (user == null)
                {
                    return HttpNotFound();
                }

                user = LoadUserData(user, userEmployeeProviderViewModel);

                await userManager.UpdateAsync(user);

                providerAppService.Update(userEmployeeProviderViewModel);

                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Something failed.");
            return View();
        }

        private static ApplicationUser LoadUserData(ApplicationUser user,
            UserEmployeeProviderViewModel userEmployeeProviderViewModel)
        {
            user.UserName = userEmployeeProviderViewModel.UserName;
            user.Email = userEmployeeProviderViewModel.UserName;
            user.Name = userEmployeeProviderViewModel.Name;
            user.Lastname = userEmployeeProviderViewModel.Lastname;

            return user;
        }

        // GET: /Users/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /Users/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var user = await userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                var result = await userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}