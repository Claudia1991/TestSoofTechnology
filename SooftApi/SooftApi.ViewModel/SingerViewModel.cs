using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SooftApi.ViewModel
{
    public class SingerViewModel
    {
        public string Name { get; set; }
        public string KindOfMusic { get; set; }
        public List<string> Songs { get; set; }
    }
}
