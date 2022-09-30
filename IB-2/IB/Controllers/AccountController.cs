using IB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Selectors;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IB.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IWebHostEnvironment _env;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment env)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            _env = env;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            UserLoginDto model = new UserLoginDto();
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("message", "Email not confirmed yet");
                    return View(model);

                }
                if (await userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return View(model);

                }

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                    var us = await userManager.FindByEmailAsync(model.Email);
                    var role = await userManager.GetRolesAsync(us);
                    if (role[0].Equals("Teacher")|| role[0].Equals("Admin"))
                    {
                        var valid=false;
                        X509Store userCaStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                        X509Store userCa = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
                        try
                        {
                            userCaStore.Open(OpenFlags.ReadOnly);
                            userCa.Open(OpenFlags.ReadOnly);
                            X509Certificate2Collection certificatesInStore = userCaStore.Certificates;
                            X509Certificate2Collection certificatesInCAStore = userCa.Certificates;
                            X509Certificate2Collection findResult = certificatesInStore.Find(X509FindType.FindBySubjectName, model.Email, false);
                            if (findResult.Count>0)
                            {
                                if (!model.Email.Equals(findResult[0].Subject.ToString()))
                                {
                                    X509Certificate2Collection authority1 = certificatesInCAStore.Find(X509FindType.FindByIssuerName, "IB Root CA", false);
                                    X509Certificate2 authority = authority1[0];
                                    X509Chain chain = new X509Chain();
                                     chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                                     chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
                                     chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;
                                    chain.ChainPolicy.VerificationTime = DateTime.Now;
                                    chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 0);
                                    bool isChainValid = chain.Build(findResult[0]);
                                    if (!isChainValid)
                                    {
                                        string[] errors = chain.ChainStatus
                                            .Select(x => String.Format("{0} ({1})", x.StatusInformation.Trim(), x.Status))
                                            .ToArray();
                                        string certificateErrorsString = "Unknown errors.";

                                        if (errors != null && errors.Length > 0)
                                        {
                                            certificateErrorsString = String.Join(", ", errors);
                                        }

                                        throw new Exception("Trust chain did not complete to the known authority anchor. Errors: " + certificateErrorsString);
                                    }
                                        valid = chain.ChainElements
                                           .Cast<X509ChainElement>()
                                           .Any(x => x.Certificate.Thumbprint == authority.Thumbprint);

                                        if (!valid)
                                        {
                                            throw new Exception("Trust chain did not complete to the known authority anchor. Thumbprints did not match.");
                                        }
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("message", "Invalid Certificate");
                                await signInManager.SignOutAsync();
                                return View();
                            }
                        }
                        finally
                        {
                            userCaStore.Close();
                            userCa.Close();
                        }
                         if (valid)
                         {
                             return RedirectToAction("Index", "Home");
                         }
                         else
                         {
                             ModelState.AddModelError("message", "Invalid Certificate");
                            await signInManager.SignOutAsync();
                            return View(model);
                         }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else if (result.IsLockedOut)
                {
                    return View("AccountLocked");
                }
                else
                {
                    ModelState.AddModelError("message", "Invalid login attempt");
                    return View(model);
                }
            }
            
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }

}
