﻿using AutoMapper;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace IWant.Web.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public readonly static List<UserViewModel> _Connections = new List<UserViewModel>();
        private readonly static Dictionary<string, string> _ConnectionsMap = new Dictionary<string, string>();

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ChatHub(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Allow to send a private message to a specific user
        public async Task SendPrivate(string receiverName, string message)
        {
            if (_ConnectionsMap.TryGetValue(receiverName, out string userId))
            {
                var sender = _Connections.Where(u => u.Username == IdentityName).First();

                if (!string.IsNullOrEmpty(message.Trim()))
                {
                    var messageViewModel = new MessageViewModel()
                    {
                        Content = Regex.Replace(message, @"<.*?>", string.Empty),
                        From = sender.FullName,
                        Avatar = sender.Avatar,
                        Room = "",
                        TimeStamp = DateTime.Now.ToLongTimeString()
                    };

                    await Clients.Client(userId).SendAsync("newMessage", messageViewModel);
                    await Clients.Caller.SendAsync("newMessage", messageViewModel);
                }
            }
        }

        // Allow to join a chat room
        public async Task Join(string roomName)
        {
            try
            {
                var user = _Connections.Where(u => u.Username == IdentityName).FirstOrDefault();
                if (user != null && user.CurrentRoom != roomName)
                {
                    if (!string.IsNullOrEmpty(user.CurrentRoom))
                        await Clients.OthersInGroup(user.CurrentRoom).SendAsync("removeUser", user);

                    await Leave(user.CurrentRoom);
                    await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
                    user.CurrentRoom = roomName;

                    await Clients.OthersInGroup(roomName).SendAsync("addUser", user);
                }
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("onError", "You failed to join the chat room!" + ex.Message);
            }
        }

        // Allow to leave a chat room
        public async Task Leave(string roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        private string IdentityName
        {
            get { return Context.User.Identity.Name; }
        }

        // Allow to handle user connection
        public override Task OnConnectedAsync()
        {
            try
            {
                var user = _context.Users.Where(u => u.UserName == IdentityName).FirstOrDefault();
                var userViewModel = _mapper.Map<User, UserViewModel>(user);
                userViewModel.Device = GetDevice();
                userViewModel.CurrentRoom = "";

                if (!_Connections.Any(u => u.Username == IdentityName))
                {
                    _Connections.Add(userViewModel);
                    _ConnectionsMap.Add(IdentityName, Context.ConnectionId);
                }

                Clients.Caller.SendAsync("getProfileInfo", user.FullName, user.ImageUrl);
            }
            catch (Exception ex)
            {
                Clients.Caller.SendAsync("onError", "OnConnected:" + ex.Message);
            }
            return base.OnConnectedAsync();
        }

        // Allow to handle user disconnection
        public override Task OnDisconnectedAsync(Exception exception)
        {
            try
            {
                var user = _Connections.Where(u => u.Username == IdentityName).First();

                _Connections.Remove(user);

                Clients.OthersInGroup(user.CurrentRoom).SendAsync("removeUser", user);

                _ConnectionsMap.Remove(user.Username);
            }
            catch (Exception ex)
            {
                Clients.Caller.SendAsync("onError", "OnDisconnected: " + ex.Message);
            }
            return base.OnDisconnectedAsync(exception);
        }

        // Allow to get users in a specific chat room
        public IEnumerable<UserViewModel> GetUsers(string roomName)
        {
            return _Connections.Where(u => u.CurrentRoom == roomName).ToList();
        }

        // Allow to get the device type of the user
        private string GetDevice()
        {
            var device = Context.GetHttpContext().Request.Headers["Device"].ToString();
            if (!string.IsNullOrEmpty(device) && (device.Equals("Desktop") || device.Equals("Mobile")))
            {
                return device;
            }
            return "Web";
        }
    }
}