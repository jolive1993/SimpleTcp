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
            TcpOrWhat<Object> byteMan = new TcpOrWhat<object>(me);
            Console.WriteLine(byteMan.myBytes);
            var awesome = byteMan.ByteArrayDeserialize(byteMan.myBytes);
            var cool = (Guy)awesome;
            Console.WriteLine(cool.coolness);
            string manguy = "whatever";
            TcpOrWhat<String> bytemaner = new TcpOrWhat<string>(manguy);
            var shit = bytemaner.ByteArrayDeserialize(bytemaner.myBytes);
            Console.WriteLine(shit);
            Console.ReadLine();
        }
    }
}
