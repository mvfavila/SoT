using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SoT.Infra.Data.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SoT.Infra.CrossCutting.Identity.Configuration
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<IdentityContext>()));

            // Configuring validator for username
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Password's validation and complexity
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Lockout configutation
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Two factor authentication provider
            manager.RegisterTwoFactorProvider("SMS Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your safety code is: {0}"
            });

            manager.RegisterTwoFactorProvider("E-mail Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Safety Code",
                BodyFormat = "Your safety code is: {0}"
            });

            // E-mail service class definition
            manager.EmailService = new EmailService();

            // SMS service class definition
            manager.SmsService = new SmsService();

            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }

        /// <summary>
        /// Async login method. This method stores the conected client's data.
        /// </summary>
        /// <param name="user">See <see cref="ApplicationUser"/>.</param>
        /// <param name="clientKey">Client's key.</param>
        /// <returns><see cref="IdentityResult"/> task.</returns>
        public async Task<IdentityResult> SignInClientAsync(ApplicationUser user, string clientKey)
        {
            if (string.IsNullOrEmpty(clientKey))
            {
                throw new ArgumentNullException(nameof(clientKey));
            }

            var client = user.Clients.SingleOrDefault(c => c.ClientKey == clientKey);
            if (client == null)
            {
                client = new Client { ClientKey = clientKey };
                user.Clients.Add(client);
            }

            var result = await UpdateAsync(user);
            user.CurrentClientId = client.Id.ToString();
            return result;
        }

        /// <summary>
        /// Async login method. This method removes the connected client's data.
        /// </summary>
        /// <param name="user">See <see cref="ApplicationUser"/>.</param>
        /// <param name="clientKey">Client's key.</param>
        /// <returns><see cref="IdentityResult"/> task.</returns>
        public async Task<IdentityResult> SignOutClientAsync(ApplicationUser user, string clientKey)
        {
            if (string.IsNullOrEmpty(clientKey))
            {
                throw new ArgumentNullException(nameof(clientKey));
            }

            var client = user.Clients.SingleOrDefault(c => c.ClientKey == clientKey);
            if (client != null)
            {
                user.Clients.Remove(client);
            }

            user.CurrentClientId = null;
            return await UpdateAsync(user);
        }
    }
}
