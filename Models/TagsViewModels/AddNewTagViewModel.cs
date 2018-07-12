using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StCore21.Models
{
    public class AddNewTagViewModel
    {
        public Tag Tag {get; set;}
        public IList<string> AllCategories {get; set;}
    }
}