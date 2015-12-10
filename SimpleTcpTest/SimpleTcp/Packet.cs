using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTcp
{
    public class Packet
    {
        public int size;
        public byte[] packetBytes;
        public TcpHeader header;
        public IpHeader iheader;
        SuperSerial superserial = new SuperSerial();
        public Packet(byte[] tcpPayLoad)
        {
            header = new TcpHeader();
            iheader = new IpHeader();
            header.sourcePort = 0;
            header.destinationPort = 0;
            header.sequenceNumber = 0;
            header.ackNumber = 0;
            header.windowSize = 0;
            header.checkSum = 0;
            header.urgentPointer = 0;
            header.data = tcpPayLoad;
            iheader.setVersion("ip4");
            iheader.setIHL(5);
            iheader.typeOfService = 0;
            iheader.totalLength = 0;
            iheader.identification = 0;
            iheader.timeToLive = 20;
            iheader.protocol = 6;
            iheader.checksum = 0;
            iheader.sourceAdress = 0;
            iheader.destinationAdress = 0;
            iheader.optionsPadding = 0;
        }
        public void execute()
        {
            byte[] tcpHeaderBytes = superserial.serializeTcpHeader(header);
            iheader.data = tcpHeaderBytes;
            packetBytes = superserial.serializeIpHeader(iheader);
        }
    }
}
