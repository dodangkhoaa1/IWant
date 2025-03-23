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

        [Required(ErrorMessage = "Title is required.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        [Display(Name = "Content")]
        public string Content { get; set; }


        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Image")]
        public IFormFile Image { get; set; }

        [Display(Name = "Image Local Path")]
        public string? ImageLocalPath { get; set; }

        [Required(ErrorMessage = "Cited Image is required.")]
        [Display(Name = "Cited Image")]
        public string CitedImage { get; set; }

        [Display(Name = "Status")]
        public bool? Status { get; set; }

        [Display(Name = "View Count")]
        public int ViewCount { get; set; } = 0;

        [Display(Name = "User Rate")]
        public int UserRating { get; set; } = 0;

        [Display(Name = "Average Rate")]
        public double AverageRating { get; set; } = 0;

        [Display(Name = "Rate Count")]
        public int CountRate { get; set; } = 0;

        [Display(Name = "User Id")]
        public string? UserId { get; set; }

        public User? User { get; set; }

        public FeedbackViewModel? Feedback { get; set; } = new FeedbackViewModel();

        public List<FeedbackViewModel>? Feedbacks { get; set; } = new List<FeedbackViewModel>();

        public List<RateViewModel>? Rates { get; set; } = new List<RateViewModel>();

    }
}
