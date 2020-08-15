using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SooftApi.Model
{
    public class SingerModel
    {
        public string Name { get; set; }
        public string KindOfMusic { get; set; }
        public List<string> Songs { get; set; }
    }
}
