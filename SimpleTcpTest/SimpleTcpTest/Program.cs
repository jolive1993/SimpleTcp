using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTcp;

namespace SimpleTcpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Guy me = new Guy();
            me.name = "cool";
            me.coolness = 7000;
            TcpOrWhat byteMan = new TcpOrWhat(me);
            Console.WriteLine(byteMan.myBytes);
            var awesome = byteMan.ByteArrayToObject(byteMan.myBytes);
            var cool = (Guy)awesome;
            Console.WriteLine(cool.name);
            Console.ReadLine();
        }
    }
}
