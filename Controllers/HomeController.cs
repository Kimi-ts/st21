using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StCore21.Models;

namespace StCore21.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISiteConfigManager _siteConfigManager;
        private readonly ISliderItemManager _sliderManager;

        public HomeController(ISliderItemManager sliderManamger, ISiteConfigManager siteConfigManager)
        {
            _sliderManager = sliderManamger;
            _siteConfigManager = siteConfigManager;
        }
        public async Task<IActionResult> Index()
        {
            var pageData = await _siteConfigManager.GetPageDataByNameAsync("Home");
            ViewData["Title"] = pageData.Title;

            ViewData["MetaDescription"] = BuildMetaTag("description", pageData.MetaDescription);
            ViewData["MetaTitle"] = BuildMetaTag("title", pageData.Title);

            var slides = _sliderManager.GetFilteredSliderItems(false, true);
            return View(slides);
        }

        public async Task<IActionResult> About()
        {
            var pageData = await _siteConfigManager.GetPageDataByNameAsync("About");
            ViewData["Title"] = pageData.Title;

            ViewData["MetaDescription"] = BuildMetaTag("description", pageData.MetaDescription);
            ViewData["MetaTitle"] = BuildMetaTag("title", pageData.Title);
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Page404()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
