using AutoMapper;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Hubs;
using IWant.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IWant.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHubContext<ChatHub> _hubContext;
        public RoomController(ApplicationDbContext context, IMapper mapper, IHubContext<ChatHub> hubContext)
        {
            _context = context;
            _mapper = mapper;
            _hubContext = hubContext;  
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _context.ChatRooms.ToListAsync();
            var roomsViewModel = _mapper.Map<IEnumerable<ChatRoom>, IEnumerable<ChatRoomViewModel>>(rooms);

            return Ok(roomsViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var rooms = await _context.ChatRooms.FindAsync(id);
            if (rooms == null) return NotFound();

            var roomsViewModel = _mapper.Map<ChatRoom, ChatRoomViewModel>(rooms);

            return Ok(roomsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChatRoomViewModel chatRoomViewModel)
        {
            if (_context.ChatRooms.Any(r => r.Name == chatRoomViewModel.Name))
                return BadRequest("Invalid room name or room already exists");

            var user = _context.Users.FirstOrDefault(u=>u.UserName == User.Identity.Name);
            var chatRoom = new ChatRoom()
            {
                Name = chatRoomViewModel.Name,
                Admin = user,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
            };

            _context.ChatRooms.Add(chatRoom);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("addChatRoom", new { id = chatRoom.Id, name = chatRoom.Name });

            return CreatedAtAction(nameof(Get), new { id = chatRoom.Id }, new { id = chatRoom.Id, name = chatRoom.Name });
        }

        [HttpPut]
        public async Task<IActionResult> Edit ([FromRoute] int id, [FromBody] ChatRoomViewModel chatRoomViewModel)
        {
            if (_context.ChatRooms.Any(r => r.Name == chatRoomViewModel.Name))
                return BadRequest("Invalid room name or room already exists");
            
            var room = await _context.ChatRooms.Include(r=>r.Admin).Where(r=>r.Id == id && r.Admin.UserName == User.Identity.Name).FirstOrDefaultAsync();

            if (room == null)
                return NotFound();

            room.Name = chatRoomViewModel.Name;
            room.UpdateAt = DateTime.Now;
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("updateChatRoom", new { id = room.Id, room.Name });

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var room = await _context.ChatRooms.Include(r => r.Admin).Where(r => r.Id == id && r.Admin.UserName == User.Identity.Name).FirstOrDefaultAsync();

            if (room == null)
                return NotFound();

            _context.ChatRooms.Remove(room);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("removeChatRoom", room.Id );
            await _hubContext.Clients.Group(room.Name).SendAsync("onRoomDeleted", string.Format("Room {0} has been deleted.\nYou are moved to the first available room!", room.Name));

            return NoContent();
        }
    }
}
