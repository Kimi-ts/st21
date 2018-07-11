using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StCore21.Models;

namespace StCore21.Controllers
{
    public class BaseController : Controller
    {
        protected string BuildMetaTag(string tagTitle, string tagValue)
        {
            System.Text.StringBuilder strDynamicMetaTag = new System.Text.StringBuilder();
            strDynamicMetaTag.AppendFormat(@"<meta name='{0}' content='{1}'/>", tagTitle, tagValue);
            return strDynamicMetaTag.ToString();
        }
    }
}