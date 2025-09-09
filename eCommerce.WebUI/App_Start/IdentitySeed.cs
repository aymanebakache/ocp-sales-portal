using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using eCommerce.WebUI.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace eCommerce.WebUI.App_Start
{
    public static class IdentitySeed
    {
        public static void EnsureAdmin()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    // S'assurer que la base/tables Identity sont initialisées
                    context.Database.Initialize(false);

                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);
                    var userStore = new UserStore<ApplicationUser>(context);
                    var userManager = new UserManager<ApplicationUser>(userStore);

                    const string adminRole = "Admin";
                    const string adminEmail = "admin@ocp.com";
                    const string adminPassword = "Ocp@12345"; // À changer en prod

                    // Rôle Admin
                    if (!roleManager.RoleExists(adminRole))
                    {
                        roleManager.Create(new IdentityRole(adminRole));
                    }

                    // Utilisateur Admin par défaut
                    var adminUser = userManager.FindByEmail(adminEmail);
                    if (adminUser == null)
                    {
                        adminUser = new ApplicationUser { UserName = adminEmail, Email = adminEmail };
                        var createResult = userManager.Create(adminUser, adminPassword);
                        if (createResult.Succeeded)
                        {
                            userManager.AddToRole(adminUser.Id, adminRole);
                        }
                    }
                    else
                    {
                        // S’assurer que l’utilisateur a le rôle Admin
                        if (!userManager.IsInRole(adminUser.Id, adminRole))
                        {
                            userManager.AddToRole(adminUser.Id, adminRole);
                        }
                    }

                    context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                // Éviter de bloquer le démarrage de l’application en dev
                Debug.WriteLine("IdentitySeed.EnsureAdmin error: " + ex);
            }
        }
    }
} 