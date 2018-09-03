using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StCore21.Models
{
    public class Message
    {
        public string MessageId { get; set; }
        public string OwnerId {get; set;}
        public string AuthorId {get; set;}
        public IdentityUser Owner { get; set; }
        public IdentityUser Author { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}