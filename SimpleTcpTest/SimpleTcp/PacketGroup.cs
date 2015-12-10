using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTcp
{
    public class PacketGroup<T>
    {
        public byte[] payload;
        public int length = 0;
        public List<Packet> packets = new List<Packet>();
        public PacketGroup(T thing)
        {
            TcpOrWhat<T> tcpOrWhat = new TcpOrWhat<T>();
            payload = tcpOrWhat.byteSerial(thing);
            length = payload.Length;
            while (length > 0)
            {
                if (length > 1452)
                {
                    byte[] splitPayload = new byte[1452];
                    Array.Copy(payload, 0, splitPayload, 0, 1452);
                    Packet p = new Packet(splitPayload);
                    packets.Add(p);
                    byte [] trimmedPayLoad = new byte[payload.Length - 1452];
                    Array.Copy(payload, 1451, trimmedPayLoad, 0, payload.Length - 1452);
                    payload = trimmedPayLoad;
                    length -= 1452;
                }
                else
                {
                    Packet p = new Packet(payload);
                    packets.Add(p);
                    length -= payload.Length;
                }
            } 
        }
    }
}
