using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Model
{
    public class Form
    {
        public int FormId { get; set; }
        public string FormName { get; set; }
        public string FormDescription { get; set; }
        public DateTime FormCreateAt { get; set; }
        public string UserId { get; set; }
    }
}
