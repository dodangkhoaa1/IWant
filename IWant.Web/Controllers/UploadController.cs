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
            IHubContext<ChatHub> hubContext)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
            _hubContext = hubContext;
        }

        // Allow to upload a file and send a message to the chat room
        public async Task<IActionResult> Upload([FromForm] UploadViewModel uploadViewModel)
        {
            if (uploadViewModel.File == null || uploadViewModel.File.Length == 0)
            {
                ViewBag.ErrorMessage = "Invalid file!";
                return View("Index");
            }

            if (!Validate(uploadViewModel.File))
            {
                ViewBag.ErrorMessage = "File validation failed! File must be PNG, SVG, JPG, or GIF and <= 5MB.";
                return View("Index");
            }

            var fileName = $"{DateTime.Now:yyyyMMddHHmmss}_{Path.GetFileName(uploadViewModel.File.FileName)}";
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

            string htmlImage = $@"
        <a href=""/uploads/{fileName}"" target=""_blank"">
            <img src=""/uploads/{fileName}"" class=""post-image"">
        </a>";

            var message = new Message
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
            return Ok(new { message = "File uploaded successfully!", fileName });
        }


        // Allow to validate the uploaded file
        private bool Validate(IFormFile file)
        {
            const int MaxFileSize = 5 * 1024 * 1024; // 5MB
            string[] AllowedExtensions = { ".png", ".svg", ".jpg", ".gif" };

            if (file.Length > MaxFileSize)
                return false;

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            return !string.IsNullOrEmpty(extension) && AllowedExtensions.Contains(extension);
        }

    }

}
