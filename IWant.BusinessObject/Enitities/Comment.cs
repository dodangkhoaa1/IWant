using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWant.BusinessObject.Enitities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public User User { get; set; }
        public Blog Blog { get; set; }
    }
}
