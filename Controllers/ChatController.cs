using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StCore21.Models;
using StCore21.Utils;

namespace StCore21.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ISiteConfigManager _siteConfigManager;

        public ChatController(IHostingEnvironment hostingEnvironment, ISiteConfigManager siteConfigManager, UserManager<IdentityUser> userManager)
        {
            _hostingEnvironment = hostingEnvironment;
            _siteConfigManager = siteConfigManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var model = _siteConfigManager.GetSiteConfig();
            return View(model);
        }
    }
}