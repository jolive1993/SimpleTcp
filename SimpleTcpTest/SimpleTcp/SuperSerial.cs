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
        public byte[] fullTcp;
        public byte[] flagsAndStuff = new byte[2];
        public byte[] serializeTcpHeader(TcpHeader header)
        {

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
            offsetReservedFlags.CopyTo(flagsAndStuff, 0);
            fullTcp = BytesBits.combineBytes(fullTcp, flagsAndStuff);
            fullTcp = BytesBits.combineBytes(fullTcp, BitConverter.GetBytes(header.windowSize));
            fullTcp = BytesBits.combineBytes(fullTcp, BitConverter.GetBytes(header.checkSum));
            fullTcp = BytesBits.combineBytes(fullTcp, BitConverter.GetBytes(header.urgentPointer));
            Console.WriteLine(fullTcp.Length);
            return fullTcp;
        }
    }
}
