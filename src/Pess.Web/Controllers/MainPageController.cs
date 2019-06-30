namespace Pess.Web
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Pess.Web.Code;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class MainPageController : Controller
    {
        private readonly ApplicationConfiguration config;

        public MainPageController(ApplicationConfiguration config)
        {
            this.config = config ?? throw new System.ArgumentNullException(nameof(config));
        }

        [Route("/")]
        public IActionResult MainPage()
        {
            if (User.Identity.IsAuthenticated)
                return this.RedirectToAction<ProjectsController>(a => a.ListProjects());
                
            return View();
        }


        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return this.RedirectToAction<MainPageController>(a => a.MainPage());
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            //rewrite all this later
            var user = config.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("sub", userName),
                    new Claim("name", userName),
                };
                claims.AddRange(user.Roles.Select(r => new Claim("role", r)));

                var cIdentity = new ClaimsIdentity(claims, "password", "name", "role");
                var cPrincipal = new ClaimsPrincipal(cIdentity);
                await HttpContext.SignInAsync(cPrincipal);
                return this.RedirectToAction<ProjectsController>(a => a.ListProjects());
            }

            ModelState.AddModelError("login", "Invalid name or password");
            return View("MainPage");
        }
    }
}
