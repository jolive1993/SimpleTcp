using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace SimpleTcp
{
    public class IpHeader
    {
        public BitArray version = new BitArray(4);
        public BitArray ihl = new BitArray(4);
        public byte typeOfService { get; set; }
        public ushort totalLength { get; set; }
        public ushort identification { get; set; }
        public BitArray reservedFlag = new BitArray(1);
        public BitArray dontFragFlag = new BitArray(1);
        public BitArray moreFragFlag = new BitArray(1);
        public BitArray fragmentOffset = new BitArray(13);
        public byte timeToLive { get; set; }
        public byte protocol { get; set; }
        public ushort checksum { get; set; }
        public int sourceAdress { get; set; }
        public int destinationAdress { get; set; }
        public int optionsPadding { get; set; }
        public byte[] data { get; set; }
    }
}
