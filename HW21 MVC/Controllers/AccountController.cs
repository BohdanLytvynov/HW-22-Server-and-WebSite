using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW21_MVC.ViewModel;
using System.Diagnostics;
using HW21_MVC.Services;
using HW21_MVC.Functions;

namespace HW21_MVC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //private readonly RoleManager<IdentityRole> m_identityRoleManager;

        private readonly UserManager<IdentityUser> m_usermanager;

        private readonly SignInManager<IdentityUser> m_signIn;

        private List<string> m_error_List;

        public AccountController(UserManager<IdentityUser>
            userManager, SignInManager<IdentityUser> signIn,
            RoleManager<IdentityRole> idRoleManager)
        {
            //m_identityRoleManager = idRoleManager;

            m_usermanager = userManager;

            m_signIn = signIn;

            m_error_List = new List<string>();
        }
        /// <summary>
        /// Register (button click)
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View(new UserRegistrationVM());
        }

        /// <summary>
        /// Register method
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegistrationVM regmodel)
        {
            IdentityResult addroleRes = null;

            IdentityResult addres = null;

            if (ModelState.IsValid)
            {
                Guid id = Guid.NewGuid();

                var user = new IdentityUser() { UserName = regmodel.Username,
                   NormalizedUserName = regmodel.Username.ToUpper(), 
                    PasswordHash = new PasswordHasher<IdentityUser>()
                    .HashPassword(null, regmodel.Password),
                    Email=regmodel.Email, Id=id.ToString()};

                addres = await m_usermanager.CreateAsync(user);

                if (addres.Succeeded)
                {
                    addroleRes = await m_usermanager.AddToRoleAsync(await
                        m_usermanager.FindByIdAsync(id.ToString()), "user"
                        );
                }
                else
                {                    
                    foreach (var error in addres.Errors)
                    {
                        m_error_List.Add(error.Description);
                    }

                    ViewData.Add("Elist", m_error_List);
                }

                if (addroleRes.Succeeded)
                {                    
                    return RedirectToAction("Index","Home");
                }                
            }
            else
            {
                CommonFunctions.ParseErrors(ModelState.Values.ToList(), m_error_List);

                ViewData.Add("Elist", m_error_List);
            }
            
            return View("Register");
        }


        /// <summary>
        /// Login (button click)
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {            
            return View(new LoginVM());
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM log
            )
        {            
            if (ModelState.IsValid)
            {
                IdentityUser user =
                    await m_usermanager.FindByNameAsync(log.Username);
                if (user!=null)
                {
                    await m_signIn.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult signresult =
                       await m_signIn.PasswordSignInAsync(user, log.Password,
                        log.RememberMe, false);

                    if (signresult.Succeeded)
                    {
                        bool isAdmin = await m_usermanager.
                            IsInRoleAsync(user, "admin");

                        TransferData.Username = user.UserName;

                        if (isAdmin)
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        
                        return RedirectToAction("Index", "User");                        
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(LoginVM.Username)
                            , "User with this login was not found.");

                        ModelState.AddModelError(nameof(LoginVM.Password)
                            , "User with this password was not found.");

                        CommonFunctions.ParseErrors(ModelState.Values.ToList(),
                            m_error_List);

                        ViewData.Add("Elist", m_error_List);
                    }
                }
                else
                {
                    ModelState.AddModelError(nameof(LoginVM.Username)
                           , "User with this login was not found.");

                    CommonFunctions.ParseErrors(ModelState.Values.ToList(),
                            m_error_List);

                    ViewData.Add("Elist", m_error_List);
                }
                
            }
            else
            {
                ModelState.AddModelError(nameof(LoginVM.Username)
                    , "Incorrect login or password");

                CommonFunctions.ParseErrors(ModelState.Values.ToList(),
                    m_error_List);

                ViewData.Add("Elist", m_error_List);
            }

            return View("Login");
        }


        public async Task<IActionResult> Logout()
        {
            await m_signIn.SignOutAsync();
            TransferData.Username = null;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
