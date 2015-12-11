using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTcp;
using System.Collections;
using System.Reflection;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace SimpleTcpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Guy guy = new Guy();
            PacketGroup<Guy> pguy = new PacketGroup<Guy>(guy, 1699856, 1699856, 674, 675);
            foreach (Packet p in pguy.packets)
            {
                Console.WriteLine(p.packetBytes.Length);
            }
            Console.ReadLine();
            SocketType socketType = SocketType.Raw;
            ProtocolType protocol = ProtocolType.IPv4;
            Socket sock = new Socket(socketType, protocol);
            System.Net.IPAddress ip = new System.Net.IPAddress(1699856);
            sock.Connect(ip, 675);
            foreach (Packet p in pguy.packets)
            {
            sock.Send(p.packetBytes);
            }
;
        }
    }
}
