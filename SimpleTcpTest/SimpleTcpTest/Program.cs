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
            SuperSerial superserial = new SuperSerial();
            TcpHeader header = new TcpHeader();
            header.sourcePort = 0;
            header.destinationPort = 0;
            header.sequenceNumber = 0;
            header.ackNumber = 0;
            header.windowSize = 0;
            header.checkSum = 0;
            header.urgentPointer = 0;
            Guy guy = new Guy();
            TcpOrWhat<Guy> tcpguy = new TcpOrWhat<Guy>();
            header.data = tcpguy.byteSerial(guy);
            byte[] whatever = superserial.serializeTcpHeader(header);
            Console.WriteLine(whatever.Length);
            IpHeader iheader = new IpHeader();
            iheader.typeOfService = 0;
            iheader.totalLength = 0;
            iheader.identification = 0;
            iheader.timeToLive = 0;
            iheader.protocol = 0;
            iheader.checksum = 0;
            iheader.sourceAdress = 0;
            iheader.destinationAdress = 0;
            iheader.optionsPadding = 0;
            iheader.data = whatever;
            byte[] sowhat = superserial.serializeIpHeader(iheader);
            Console.WriteLine(sowhat.Length);
            Console.ReadLine();
        }
    }
}
