using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace SimpleTcp
{
    class IpHeader
    {
        BitArray version = new BitArray(4);
        BitArray ihl = new BitArray(4);
        byte typeOfService;
        ushort totalLength;
        ushort identification;
        bool reservedFlag;
        bool dontFragFlag;
        bool moreFragFlag;
        BitArray fragmentOffset = new BitArray(13);
        byte timeToLive;
        byte protocol;
        ushort checksum;
        int sourceAdress;
        int destinationAdress;
        int optionsPadding;




    }
}
