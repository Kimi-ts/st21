using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StCore21.Models;
using StCore21.Models.DiscountsViewModels;

namespace StCore21.Controllers
{
    public class DiscountController : BaseController
    {
        private readonly IDiscountManager _discountManager;
        private readonly ISiteConfigManager _siteConfigManager;

        public DiscountController(ISiteConfigManager siteConfigManager, IDiscountManager discountManager)
        {
            _discountManager = discountManager;
            _siteConfigManager = siteConfigManager;
        }
        public async Task<IActionResult> Index(int count, bool isDisplayNew, string filteredTags)
        {
            var pageData = await _siteConfigManager.GetPageDataByNameAsync("Actions");
            ViewData["Title"] = pageData.Title;

            ViewData["MetaDescription"] = BuildMetaTag("description", pageData.MetaDescription);
            ViewData["MetaTitle"] = BuildMetaTag("title", pageData.Title);

            List<string> tagsList = new List<string>();
            if (filteredTags != "all")
            {
                tagsList = filteredTags.Split(',').ToList();
            }

            DateTime start = DateTime.Now.AddYears(-1);
            if (isDisplayNew == true)
            {
                start = DateTime.Now.AddDays(-7);
            }
            var model = new DiscountsListViewModel();
            model.Sales = _discountManager.GetSales(count, start, tagsList, false);

            var allTags = _discountManager.GetAllTagsWithSales();

            model.FilteredTags = new List<DiscountsListViewModel.TagSalesCounter>();

            foreach (var tag in allTags)
            {
                DiscountsListViewModel.TagSalesCounter filteredTag = new DiscountsListViewModel.TagSalesCounter();
                filteredTag.Category = tag.Category;
                filteredTag.Title = tag.Title;

                filteredTag.SalesCount = tag.Sales.Where(s => s.CreatedDate > start && s.ExpireDate >= DateTime.Now).ToList().Count;
                model.FilteredTags.Add(filteredTag);
            }

            var categories = model.FilteredTags
                            .Where(t => t.SalesCount > 0)
                            .Select(c => c.Category)
                            .Distinct().ToList();

            model.Categories = categories;

            model.IsDisplayNew = isDisplayNew;
            return View(model);
        }
    }
}