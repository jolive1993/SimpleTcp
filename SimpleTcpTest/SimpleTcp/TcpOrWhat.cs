using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SimpleTcp
{
    public class TcpOrWhat<T>
    {
        public byte[] myBytes;
        public TcpOrWhat(T thing)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, thing);
                myBytes = ms.ToArray();
            }
        }
        public T ByteArrayDeserialize(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var result = (T)binForm.Deserialize(memStream);
                return result;
            }
        }
    }
}
