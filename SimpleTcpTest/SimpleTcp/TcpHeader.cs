using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SimpleTcp
{
    public class TcpHeader
    {
        public ushort sourcePort { get; set; }
        public ushort destinationPort { get; set; }
        public int sequenceNumber { get; set; }
        public int ackNumber { get; set; }
        public BitArray offset = new BitArray(4);
        public BitArray reserved = new BitArray(3);
        public BitArray NS = new BitArray(1);
        public BitArray CWR = new BitArray(1);
        public BitArray ECE = new BitArray(1);
        public BitArray URG = new BitArray(1);
        public BitArray ACK = new BitArray(1);
        public BitArray PSH = new BitArray(1);
        public BitArray RST = new BitArray(1);
        public BitArray SYN = new BitArray(1);
        public BitArray FIN = new BitArray(1);
        public ushort windowSize { get; set; }
        public ushort checkSum { get; set; }
        public ushort urgentPointer { get; set; }
        public byte[] data { get; set; }
        public void setOffset(int id)
        {
            switch(id)
            {
                case 5:
                    offset.Set(0, false);
                    offset.Set(1, true);
                    offset.Set(2, false);
                    offset.Set(3, true);
                    break;
                default:
                    offset.Set(0, false);
                    offset.Set(1, true);
                    offset.Set(2, false);
                    offset.Set(3, true);
                    break;
            }
        }
    }
}
