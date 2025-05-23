﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWant.BusinessObject.Enitities
{
    [Table("Rates")]
    public class Rate
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "TINYINT")]
        public int RatingStar { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime? UpdatedAt { get; set; }
        public string UserId { get; set; }
        public int BlogId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        [ForeignKey(nameof(BlogId))]
        public Blog Blog { get; set; }
    }
}
