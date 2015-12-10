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
            TcpHeader header = new TcpHeader();
            header.sourcePort = 0;
            header.destinationPort = 0;
            header.sequenceNumber = 0;
            header.ackNumber = 0;
            //header.offset
            //header.reserved
            header.windowSize = 0;
            header.checkSum = 0;
            header.urgentPointer = 0;
            SuperSerial superserial = new SuperSerial();
            byte[] whatever = superserial.serializeTcpHeader(header);
            Console.WriteLine(whatever.Length);
            Console.ReadLine();
        }
    }
}
