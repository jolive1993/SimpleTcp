using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTcp
{
    [Serializable]
    public class Guy 
    {
        public string name { get; set; }
        public int age { get; set; }
        public int coolness { get; set; }
        public List<long> longs;
        public Guy()
        {
            longs = new List<long>(9000);
        }
    }
}
