using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

namespace SimpleTcp
{
    public class TcpOrWhat<T>
    {
        public byte[] myBytes;
        private BinaryFormatter formatter = new BinaryFormatter();
        public TcpOrWhat()
        {
        }
        public byte[] byteSerial(T thing)
        {
            using (var memStream = new MemoryStream())
            {
                byte[] result;
                formatter.Serialize(memStream, thing);
                result = memStream.ToArray();
                return result;
            }
        }
        public T ByteArrayDeserialize(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var result = (T)formatter.Deserialize(memStream);
                return result;
            }
        }
    }
}
