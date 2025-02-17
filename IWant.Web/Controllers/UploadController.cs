using AutoMapper;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Hubs;
using IWant.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace IWant.Web.Controllers
{
    public class UploadController : Controller
    {
        private readonly int FileSizeLimit;
        private readonly string[] AllowedExtensions;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly IHubContext<ChatHub> _hubContext;

        public UploadController(
            ApplicationDbContext context,
            IMapper mapper,
            IWebHostEnvironment environment,
            IHubContext<ChatHub> hubContext,
            IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
            _hubContext = hubContext;

            FileSizeLimit = configuration.GetSection("FileUpload").GetValue<int>("FileSizeLimit");
            AllowedExtensions = configuration.GetSection("FileUpload").GetValue<string>("AllowedExtensions").Split(",");
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upload([FromForm] UploadViewModel uploadViewModel)
        {
            /*if (!ModelState.IsValid || !Validate(uploadViewModel.File))
            {
                ViewBag.ErrorMessage = "Validation failed!";
                return View("Index");
            }*/

            var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Path.GetFileName(uploadViewModel.File.FileName);
            var folderPath = Path.Combine(_environment.WebRootPath, "uploads");
            var filePath = Path.Combine(folderPath, fileName);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await uploadViewModel.File.CopyToAsync(fileStream);
            }

            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var room = _context.ChatRooms.FirstOrDefault(r => r.Id == uploadViewModel.RoomId);

            if (user == null || room == null)
            {
                ViewBag.ErrorMessage = "User or Room not found!";
                return View("Index");
            }

            string htmlImage = string.Format(
                "<a href=\"/uploads/{0}\" target=\"_blank\">" +
                "<img src=\"/uploads/{0}\" class=\"post-image\">" +
                "</a>", fileName);

            var message = new Message()
            {
                Content = Regex.Replace(htmlImage, @"(?i)<(?!img|a|/a|/img).*?>", string.Empty),
                TimeStamp = DateTime.Now,
                FromUser = user,
                ToRoom = room
            };

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            var messageViewModel = _mapper.Map<Message, MessageViewModel>(message);
            await _hubContext.Clients.Group(room.Name).SendAsync("newMessage", messageViewModel);

            ViewBag.SuccessMessage = "File uploaded successfully!";
            return View("Index");
        }

        private bool Validate(IFormFile file)
        {
            if (file.Length > FileSizeLimit)
                return false;

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(extension) || !AllowedExtensions.Any(s => s.Contains(extension)))
                return false;

            return true;
        }
    }

}
