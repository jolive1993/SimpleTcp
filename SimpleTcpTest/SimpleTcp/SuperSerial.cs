using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;

namespace SimpleTcp
{
    public class SuperSerial
    {
        public byte[] serializeTcpHeader(TcpHeader header)
        {
            byte[] fullTcp;
            byte[] flagsAndStuff = new byte[2] { 160, 0 };
            fullTcp = BitConverter.GetBytes(header.sourcePort);
            fullTcp = BytesBits.combineBytes(fullTcp, BitConverter.GetBytes(header.destinationPort));
            fullTcp = BytesBits.combineBytes(fullTcp, BitConverter.GetBytes(header.sequenceNumber));
            fullTcp = BytesBits.combineBytes(fullTcp, BitConverter.GetBytes(header.ackNumber));
            BitArray offsetReservedFlags = header.offset;
            offsetReservedFlags = BytesBits.combineBits(offsetReservedFlags, header.reserved);
            offsetReservedFlags = BytesBits.combineBits(offsetReservedFlags, header.NS);
            offsetReservedFlags = BytesBits.combineBits(offsetReservedFlags, header.CWR);
            offsetReservedFlags = BytesBits.combineBits(offsetReservedFlags, header.ECE);
            offsetReservedFlags = BytesBits.combineBits(offsetReservedFlags, header.URG);
            offsetReservedFlags = BytesBits.combineBits(offsetReservedFlags, header.ACK);
            offsetReservedFlags = BytesBits.combineBits(offsetReservedFlags, header.PSH);
            offsetReservedFlags = BytesBits.combineBits(offsetReservedFlags, header.RST);
            offsetReservedFlags = BytesBits.combineBits(offsetReservedFlags, header.SYN);
            offsetReservedFlags = BytesBits.combineBits(offsetReservedFlags, header.FIN);
            //offsetReservedFlags.CopyTo(flagsAndStuff, 0);
            fullTcp = BytesBits.combineBytes(fullTcp, flagsAndStuff);
            fullTcp = BytesBits.combineBytes(fullTcp, BitConverter.GetBytes(header.windowSize));
            fullTcp = BytesBits.combineBytes(fullTcp, BitConverter.GetBytes(header.checkSum));
            fullTcp = BytesBits.combineBytes(fullTcp, BitConverter.GetBytes(header.urgentPointer));
            if (header.data != null)
            {
                fullTcp = BytesBits.combineBytes(fullTcp, header.data);
            }
            return fullTcp;
        }
        public byte[] serializeIpHeader(IpHeader header)
        {
            byte[] fullIp;
            byte[] versionIhl = new byte[1] { 69 };
            byte[] flagsAndOffset = new byte[2];
            BitArray versionIhlbit = header.version;
            versionIhlbit = BytesBits.combineBits(versionIhlbit, header.ihl);
            //versionIhlbit.CopyTo(versionIhl, 0)
            fullIp = versionIhl;
            byte[] typeOfService = new byte[1] { header.typeOfService };
            fullIp = BytesBits.combineBytes(fullIp, typeOfService);
            fullIp = BytesBits.combineBytes(fullIp, BitConverter.GetBytes(header.totalLength));
            fullIp = BytesBits.combineBytes(fullIp, BitConverter.GetBytes(header.identification));
            BitArray flagsOffset = header.reservedFlag;
            flagsOffset = BytesBits.combineBits(flagsOffset, header.dontFragFlag);
            flagsOffset = BytesBits.combineBits(flagsOffset, header.moreFragFlag);
            flagsOffset = BytesBits.combineBits(flagsOffset, header.fragmentOffset);
            flagsOffset.CopyTo(flagsAndOffset, 0);
            fullIp = BytesBits.combineBytes(fullIp, flagsAndOffset);
            byte[] timeToLive = new byte[1] { header.timeToLive };
            fullIp = BytesBits.combineBytes(fullIp, timeToLive);
            byte[] protocol = new byte[1] { header.protocol };
            fullIp = BytesBits.combineBytes(fullIp, protocol);
            fullIp = BytesBits.combineBytes(fullIp, BitConverter.GetBytes(header.checksum));
            fullIp = BytesBits.combineBytes(fullIp, BitConverter.GetBytes(header.sourceAdress));
            fullIp = BytesBits.combineBytes(fullIp, BitConverter.GetBytes(header.destinationAdress));
            fullIp = BytesBits.combineBytes(fullIp, header.data);
            return fullIp;
        }
    }
}
