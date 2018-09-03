using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StCore21.Models
{
    public class MessagesListVievModel
    {
        public IList<Message> Messages {get; set;}
        public IdentityUser CurrentUser {get; set;}
        public IdentityUser ChatOwner {get; set;}
    }
}