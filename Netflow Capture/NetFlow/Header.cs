using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace System.Net.NetFlow
{
	public class Header
	{
		private UInt16 _version;
		private UInt16 _count;
		private UInt32 _uptime;
		private UInt32 _secs;
		private UInt32 _sequence;
		private UInt32 _id;

        private Byte[] _bytes;

		public UInt16 Version
		{
			get
			{
				return this._version;
			}
		}
		public UInt16 Count
		{
			get
			{
                return this._count;
			}
		}
        public TimeSpan UpTime
		{
			get
			{
                return new TimeSpan((long)this._uptime * 10000);
			}
		}
        public DateTime Secs
		{
			get
			{
                return new DateTime(1970, 1, 1).AddSeconds(this._secs);
			}
		}
		public UInt32 Sequence
		{
			get
			{
                return this._sequence;
			}
		}
		public UInt32 ID
		{
			get
			{
                return this._id;
			}
		}

        public Header(Byte[] bytes)
        {
            this._bytes = bytes;
            this.Parse();
        }

        private void Parse()
        {
            if(this._bytes.Length == 20)
            {
                byte[] reverse = this._bytes.Reverse().ToArray();

                this._version = BitConverter.ToUInt16(reverse, this._bytes.Length - sizeof(Int16) - 0);
                this._count = BitConverter.ToUInt16(reverse, this._bytes.Length - sizeof(Int16) - 2);

                this._uptime = BitConverter.ToUInt32(reverse, this._bytes.Length - sizeof(UInt32) - 4);
                this._secs = BitConverter.ToUInt32(reverse, this._bytes.Length - sizeof(Int32) - 8);
                this._sequence = BitConverter.ToUInt32(reverse, this._bytes.Length - sizeof(Int32) - 12);
                this._id = BitConverter.ToUInt32(reverse, this._bytes.Length - sizeof(Int32) - 16);
            }
        }
	}
}
