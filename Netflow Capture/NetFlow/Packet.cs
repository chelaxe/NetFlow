using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace System.Net.NetFlow
{
	public class Packet
	{
		private Header _header;
        private List<FlowSet> _flowset;
        private Byte[] _bytes;

		public Header Header
		{
			get
			{
				return this._header;
			}
		}
		public List<FlowSet> FlowSet
		{
			get
			{
                return this._flowset;
			}
		}

        public Packet(Byte[] bytes, Templates templates)
        {
            this._bytes = bytes;
            this.Parse(templates);
        }

        private void Parse(Templates templates)
        {
            this._flowset = new List<FlowSet>();

            Int32 length = _bytes.Length - 20;

            Byte[] header = new Byte[20];
            Byte[] flowset = new Byte[length];

            Array.Copy(_bytes, 0, header, 0, 20);
            Array.Copy(_bytes, 20, flowset, 0, length);

            this._header = new Header(header);
            byte[] reverse = flowset.Reverse().ToArray();

            int templengh = 0;

            while ((templengh + 2) < flowset.Length)
            {
                UInt16 lengths = BitConverter.ToUInt16(reverse, flowset.Length - sizeof(Int16) - (templengh+2));
                Byte[] bflowsets = new Byte[lengths];
                Array.Copy(flowset, templengh, bflowsets, 0, lengths);

                FlowSet flowsets = new FlowSet(bflowsets, templates);
                this._flowset.Add(flowsets);

                templengh += lengths;
            }
        }

        public override string ToString()
        {
            String ret = "NetFlow Packet " + this._bytes.Length + "b.\r\n"
                + "Header " + "20b.:\r\n"
                + "Version: " + _header.Version + "\r\n"
                + "Count: " + _header.Count + "\r\n"
                + "UpTime: " + _header.UpTime + "\r\n"
                + "Secs: " + _header.Secs + "\r\n"
                + "Sequence: " + _header.Sequence + "\r\n"
                + "ID: " + _header.ID + "\r\n\n"
                + "FlowSet`s " + (this._bytes.Length - 20) + "b.:\r\n\n";

            

            int a = 0;

            foreach(FlowSet flows in this._flowset)
            {
                a++;

                ret += "FlowSet [" + a + "]:" + "\r\n"
                + "ID: " + flows.ID + "\r\n"
                + "Length: " + flows.Length + "\r\n";

                foreach (Byte bt in flows.ValueByte)
                {
                    ret += "0x" + bt.ToString("X") + " ";
                }

                int i = 1;
                foreach (Template templ in flows.Template)
                {
                    ret += i + "\tTemplate:" + "\r\n"
                        + "\tID: " + templ.ID + "\r\n"
                        + "\tCount: " + templ.Count + "\r\n";
                    foreach (Field fields in templ.Field)
                    {
                        ret += "\t\t" + fields.Type + ": ";

                        if (fields.Value.Count == 0) ret += "\r\n";

                        if ((fields.GetTypes() == (UInt16)FieldType.IPV4_DST_ADDR) ||
                            (fields.GetTypes() == (UInt16)FieldType.IPV4_SRC_ADDR) ||
                            (fields.GetTypes() == (UInt16)FieldType.IPV4_NEXT_HOP) ||
                            (fields.GetTypes() == (UInt16)FieldType.IPV6_DST_ADDR) ||
                            (fields.GetTypes() == (UInt16)FieldType.IPV6_SRC_ADDR) ||
                            (fields.GetTypes() == (UInt16)FieldType.IPV6_NEXT_HOP))
                        {
                            if (fields.Value.Count != 0) ret += new IPAddress(fields.Value.ToArray()).ToString();
                        }
                        else if ((fields.GetTypes() == (UInt16)FieldType.L4_DST_PORT) ||
                            (fields.GetTypes() == (UInt16)FieldType.L4_SRC_PORT))
                        {
                            if (fields.Value.Count != 0) ret += BitConverter.ToUInt16(fields.Value.ToArray().Reverse().ToArray(), 0);
                        }
                        else
                        {

                            foreach (Byte bt in fields.Value)
                            {
                                ret += "0x" + bt.ToString("X") + " ";
                            }
                        }

                        if (fields.Value.Count != 0) ret += "\r\n";
                    }

                    i++;
                }
            }
            
            return ret;
        }
	}
}
