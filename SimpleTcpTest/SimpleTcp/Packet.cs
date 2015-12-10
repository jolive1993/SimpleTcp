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
        public Packet(byte[] tcpPayLoad)
        {
            SuperSerial superserial = new SuperSerial();
            header = new TcpHeader();
            iheader = new IpHeader();
            header.sourcePort = 0;
            header.destinationPort = 0;
            header.sequenceNumber = 0;
            header.ackNumber = 0;
            header.windowSize = 0;
            header.checkSum = 0;
            header.urgentPointer = 0;
            header.NS.Set(0, true);
            header.ECE.Set(0, true);
            header.data = tcpPayLoad;
            byte[] tcpHeaderBytes = superserial.serializeTcpHeader(header);
            iheader.typeOfService = 0;
            iheader.totalLength = 0;
            iheader.identification = 0;
            iheader.timeToLive = 0;
            iheader.protocol = 0;
            iheader.checksum = 0;
            iheader.sourceAdress = 0;
            iheader.destinationAdress = 0;
            iheader.optionsPadding = 0;
            iheader.data = tcpHeaderBytes;
            packetBytes = superserial.serializeIpHeader(iheader);
        }
    }
}
