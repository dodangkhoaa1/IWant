using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWant.BusinessObject.Enitities
{
    public class Rate
    {
        public int Id { get; set; }
        public int RatingStar { get; set; }
        public User User { get; set; }
        public Blog Blog { get; set; }
    }
}
