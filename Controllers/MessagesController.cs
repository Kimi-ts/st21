using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StCore21.Models;

namespace StCore21.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMessageManager _messageManager;
        private readonly ILogger _logger;

        public MessagesController(
            UserManager<IdentityUser> userManager,
            IMessageManager messageManager,
            ILogger<MessagesController> logger)
        {
            _userManager = userManager;
            _messageManager = messageManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var messages = _messageManager.GetMessagesByUserId(id);

            IdentityUser chatOwner;

            if (await _userManager.IsInRoleAsync(user, "Administrator"))
            {
                chatOwner = await _userManager.FindByIdAsync(id);
            }
            else
            {
                chatOwner = user;
            }

            var model = new MessagesListVievModel
            {
                Messages = messages,
                CurrentUser = user,
                ChatOwner = chatOwner
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostMessage(AddNewMessageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Message message = new Message
            {
                Date = DateTime.Now,
                OwnerId = model.ChatOwnerId,
                AuthorId = model.AuthorId,
                Text = model.MessageText
            };

            await _messageManager.AddMessageAsync(message);

            return RedirectToAction(nameof(Index), new { id = model.ChatOwnerId });
        }

        public async Task<IActionResult> DialogList()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var model = new List<MessagesListVievModel>();

            var chatUsers = _messageManager.GetMessageOwnersList();

            foreach (var chatOwner in chatUsers)
            {
                var messages = _messageManager.GetMessagesByUserId(chatOwner);

                var chatUser = await _userManager.FindByIdAsync(chatOwner);

                var message = new MessagesListVievModel
                {
                    Messages = messages,
                    CurrentUser = user,
                    ChatOwner = chatUser
                };

                model.Add(message);
            }

            model = model.OrderByDescending( c => c.Messages.Last().Date).ToList();

            return View(model);
        }
    }
}