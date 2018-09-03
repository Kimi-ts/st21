using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StCore21.Models
{
    public interface IMessageManager
    {
        IList<Message> GetMessagesByUserId(string userId);
        Task AddMessageAsync(Message message);
        IList<string> GetMessageOwnersList();
    }
}