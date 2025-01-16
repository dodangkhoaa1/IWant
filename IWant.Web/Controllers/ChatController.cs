using AutoMapper;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Hubs;
using IWant.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace IWant.Web.Controllers
{
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHubContext<ChatHub> _hubContext;
        public ChatController(ApplicationDbContext context, IMapper mapper, IHubContext<ChatHub> hubContext)
        {
            _context = context;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Get(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if(message == null) return NotFound();

            var messageViewModel = _mapper.Map<Message,MessageViewModel>(message);
            return View(messageViewModel);
        }

        [HttpGet("Chat/Messages/{roomName}")]
        public IActionResult Messages([FromRoute] string roomName)
        {
            var room = _context.ChatRooms.FirstOrDefault(r => r.Name == roomName);
            if (room == null)
                return BadRequest("Room not found.");

            var messages = _context.Messages.Where(m => m.ToRoomId == room.Id)
                .Include(m => m.FromUser)
                .Include(m => m.ToRoom)
                .OrderByDescending(m => m.TimeStamp)
                .Take(20)
                .AsEnumerable()
                .Reverse()
                .ToList();

            var messagesViewModel = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageViewModel>>(messages);
            return Ok(messagesViewModel); 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MessageViewModel messageViewModel)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var room = _context.ChatRooms.FirstOrDefault(r => r.Name == messageViewModel.Room);
            if (room == null)
                return BadRequest();

            var msg = new Message()
            {
                Content = Regex.Replace(messageViewModel.Content, @"<.*?>", string.Empty),
                FromUser = user,
                ToRoom = room,
                TimeStamp = DateTime.Now
            };

            _context.Messages.Add(msg);
            await _context.SaveChangesAsync();

            var createdMessage = _mapper.Map<Message, MessageViewModel>(msg);
            await _hubContext.Clients.Group(room.Name).SendAsync("newMessage", createdMessage);

            return CreatedAtAction(nameof(Get), new { id = msg.Id }, createdMessage);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _context.Messages.Include(u=>u.FromUser).Where(m=>m.Id == id && m.FromUser.UserName == User.Identity.Name).FirstOrDefaultAsync();

            if(message == null) return NotFound();

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
