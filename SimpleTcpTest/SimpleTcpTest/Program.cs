using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTcp;
using System.Collections;
using System.Reflection;

namespace SimpleTcpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Guy guy = new Guy();
            PacketGroup<Guy> pguy = new PacketGroup<Guy>(guy);
            foreach (Packet p in pguy.packets)
            {
                Console.WriteLine(p.packetBytes.Length);
            }
            Console.ReadLine();
        }
    }
}
