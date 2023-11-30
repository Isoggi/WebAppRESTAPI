using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.VisualBasic;
using System.Numerics;
using WebAppRESTAPI.Data;
using WebAppRESTAPI.Models;
using WebAppRESTAPI.Models.ViewModels;

namespace WebAppRESTAPI.Function
{
    public interface IInitializeAppData
    {
        Task Run();
    }
    public class InitializeAppData : IInitializeAppData
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly AppIdentityDbContext _userContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public InitializeAppData(UserManager<ApplicationUser> userManager,
               RoleManager<ApplicationRole> roleManager,
               ApplicationDbContext context,
               AppIdentityDbContext userContext,
               SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _userContext = userContext;
            _signInManager = signInManager;
        }

        public async Task Run()
        {
            try
            {
                CreateLoginViewModel _userDefaultOptions = new CreateLoginViewModel
                {
                    Username = "Super Admin",
                    Email = "kristantosaptadi@gmail.com",
                    Password = "@1234Abcd"
                };
                List<Product> products = new List<Product>() {
                    new Product{Name = "Product A", Description = "Description A"},
                };

                await _context.Products.AddRangeAsync(products);
                await _context.SaveChangesAsync();

                List<Company> companies = new List<Company>() {
                    new Company{ Name = "Company A", Address = "Address A" , City = "City A", Province = "Province A" },
                };

                await _context.Companies.AddRangeAsync(companies);
                await _context.SaveChangesAsync();

                ApplicationUser user = new ApplicationUser();
                user.Email = _userDefaultOptions.Email;
                user.UserName = _userDefaultOptions.Username;
                user.EmailConfirmed = true;

                var result = await _userManager.CreateAsync(user, _userDefaultOptions.Password);

                if (result.Succeeded)
                {
                    //add to user profile
                    ApplicationUser profile = new ApplicationUser();
                    profile.UserName = user.UserName;
                    profile.Email = user.Email;
                    profile.Id = user.Id;
                    await _userContext.Users.AddAsync(profile);
                    await _userContext.SaveChangesAsync();

                    var userData = await _userManager.FindByIdAsync(user.Id);
                    if (userData != null)
                    {
                        var roles = _roleManager.Roles;
                        List<string> listRoles = new List<string>();
                        foreach (var item in roles)
                        {
                            listRoles.Add(item.Name);
                        }
                        await _userManager.AddToRolesAsync(userData, listRoles);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
