using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Rubenhak.NetflowExporter
{
    public class PacketGenerator
    {
        private byte[] _data = new byte[0];

        public byte[] Data
        {
            get
            {
                return _data;
            }
        }

        public PacketGenerator()
        {

        }

        public void AddInt32(UInt32 val)
        {
            var data = BitConverter.GetBytes(val);
            Array.Reverse(data);
            Add(data);
        }

        public void AddInt16(UInt16 val)
        {
            var data = BitConverter.GetBytes(val);
            Array.Reverse(data);
            Add(data);
        }

        public void AddIPv4(string ipStr)
        {
            var ip = IPAddress.Parse(ipStr);
            var data = ip.GetAddressBytes();
            Add(data);
        }

        public void Add(byte[] data)
        {
            int index = _data.Length;
            Array.Resize(ref _data, _data.Length + data.Length);
            Array.Copy(data, 0, _data, index, data.Length);
        }
    }
}
