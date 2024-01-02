using Microsoft.AspNetCore.Mvc;
using ContactsManager.Core.DTO;
using Microsoft.AspNetCore.Identity;
using ContactsManager.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Authorization;

namespace ContactsManager.UI.Controllers
{
    [Controller]

    [AllowAnonymous]
    public class Account : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public Account(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;  
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model, string? ReturnURL)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors)
                    .Select(temp => temp.ErrorMessage);
                return View(model);
            }

            ApplicationUser user = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                
                PhoneNumber = model.PhoneNumber,

            };
            IdentityResult result= await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
              return RedirectToAction(nameof(PersonController.Index), "Person");
            }
            else
            {
                foreach (var i in result.Errors) {
                    ModelState.AddModelError("Register", i.Description);
                        }
                return View(model);
            }
            

        }

        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
       
        
        public async Task<IActionResult> Login(LoginDTO model,string? ReturnURL)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).ToList().Select(temp => temp.ErrorMessage);
                return View(model);
            }
          var result= await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false,lockoutOnFailure:false);

            if (result.Succeeded){

                if(!string.IsNullOrEmpty(ReturnURL) && Url.IsLocalUrl(ReturnURL))
                {
                    return LocalRedirect(ReturnURL);
                }
                return RedirectToAction(nameof(PersonController.Index), "Person");
            }

            ModelState.AddModelError("Login", "Invalid user name or password");
            return View(model);
           
        }


        
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(PersonController.Index), "Person");
        }


        public async Task<IActionResult> IsDuplicateEmail(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
