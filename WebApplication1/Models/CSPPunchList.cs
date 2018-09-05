using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CSPPunchList
    {
        public int id { get; set; }
        public string CreateDate { get; set; }
        public string PunchIn { get; set; }
        public string PunchOut { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}