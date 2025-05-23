using AuthAppLib.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BiblioWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManger;
        private readonly SignInManager<User> _signInManager;


        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManger = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new UserLogin()
            {
                ReturnUrl = returnUrl
            });

        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.UserName,
                                                                           model.Password,
                                                                           false,
                                                                           false);
                if (loginResult.Succeeded)
                {
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    return RedirectToAction("Account", "Login");
                }
            }

            ModelState.AddModelError("", "Пользователь не найден");
            return View(model);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new UserRegistration());
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegistration userRegistration)
        {
            if (ModelState.IsValid)
            {
                User user = new()
                {
                    UserName = userRegistration.UserName
                };
                var result = await _userManger.CreateAsync(user, userRegistration.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Books");
                }
                else
                {
                    foreach (var identityError in result.Errors)
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                }
            }
            return BadRequest(userRegistration);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {
                    await _signInManager.SignOutAsync();
                    return Redirect("/Books/Index");
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }
        }

    }
}
