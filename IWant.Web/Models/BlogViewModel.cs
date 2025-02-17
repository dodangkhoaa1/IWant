using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWant.Web.Models;
using Microsoft.AspNetCore.Identity;
using IWant.BusinessObject.Enitities;

namespace IWant.Web.Models
{
    public class BlogViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }

     
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    
        public string? ImageUrl { get; set; }
       
        public IFormFile? Image { get; set; }
        public string? ImageLocalPath { get; set; }

        public bool Status { get; set; }
        public int UserRating { get; set; } = 0;
        public double AverageRating { get; set; } = 0;
        public int CountRate { get; set; } = 0;

        public User? User { get; set; }

        public CommentViewModel? Comment { get; set; } = new CommentViewModel();

        public List<CommentViewModel>? Comments { get; set; } = new List<CommentViewModel>();
        public List<RateViewModel>? Rates { get; set; } = new List<RateViewModel>();

    }
}
