using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace SimpleTcp
{
    public static class BytesBits
    {
        public static byte[] combineBytes(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }
        public static BitArray combineBits(BitArray first, BitArray second)
        {
            BitArray newBitArray = new BitArray(first.Cast<bool>().Concat(second.Cast<bool>()).ToArray());
            return newBitArray;
        }
    }
}
