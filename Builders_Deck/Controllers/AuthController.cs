using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Builders_Deck.Models;
using Builders_Deck.Utility;
using Microsoft.AspNetCore.Authentication;

namespace Builders_Deck.Controllers
{
    public class AuthController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager, IHttpContextAccessor httpContextAccessor) : Controller
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;
        private readonly SignInManager<IdentityUser> _signInManager = signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                    return View(model);
                }
                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, lockoutOnFailure: false);

                if (_userManager == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                    return View(model);
                }

                if (result.Succeeded)
                {
                    var userDetails = await Helper.GetCurrentUserIdAsync(_httpContextAccessor, _userManager);
                    return RedirectToAction("Index", "Page");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.Users
                .SingleOrDefaultAsync(u => u.UserName == model.Username || u.Email == model.Email);

                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "Username or email is already taken.");
                    return View(model);
                }

                var user = new IdentityUser
                {
                    UserName = model.Username,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    var message = string.Join(", ", result.Errors.Select(x => "Code " + x.Code + " Description" + x.Description));
                    return View();
                }

                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("SignIn", "Auth");

            }

            return View(model); // Pass the model back to show error messages.
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public new async  Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(); // Signs out the user
            return RedirectToAction("Index", "Home"); // Redirect to the home page after sign-out
        }
    }
}
