using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace System.Net.NetFlow
{
    [Serializable]
	public class Field
	{
        private UInt16 _type;
		private UInt16 _length;
		private List<Byte> _value;

        private Byte[] _bytes;

		public String Type
		{
			get
			{
                return Field.FieldTypes(this._type);
			}
		}

        public UInt16 GetTypes()
        {
            return this._type;
        }

		public UInt16 Length
		{
			get
			{
                return this._length;
			}
		}

		public List<Byte> Value
		{
			get
			{
                return this._value;
			}
			set
			{
                this._value = value;
			}
		}

        public Field(Byte[] bytes)
        {
            this._bytes = bytes;
            this.Parse();
        }

        private void Parse()
        {
            this._value = new List<byte>();
            if (this._bytes.Length == 4)
            {
                byte[] reverse = this._bytes.Reverse().ToArray();

                this._type = BitConverter.ToUInt16(reverse, this._bytes.Length - sizeof(Int16) - 0);
                this._length = BitConverter.ToUInt16(reverse, this._bytes.Length - sizeof(Int16) - 2);
            }
        }

        public static String FieldTypes(UInt16 Types)
        {
            String ret = String.Empty;
            switch (Types)
            {
                case (UInt16)FieldType.IN_BYTES: { ret = "IN_BYTES"; break; }
                case (UInt16)FieldType.IN_PKTS: { ret = "IN_PKTS"; break; }
                case (UInt16)FieldType.FLOWS: { ret = "FLOWS"; break; }
                case (UInt16)FieldType.PROTOCOL: { ret = "PROTOCOL"; break; }
                case (UInt16)FieldType.TOS: { ret = "TOS"; break; }
                case (UInt16)FieldType.TCP_FLAGS: { ret = "TCP_FLAGS"; break; }
                case (UInt16)FieldType.L4_SRC_PORT: { ret = "L4_SRC_PORT"; break; }
                case (UInt16)FieldType.IPV4_SRC_ADDR: { ret = "IPV4_SRC_ADDR"; break; }
                case (UInt16)FieldType.SRC_MASK: { ret = "SRC_MASK"; break; }
                case (UInt16)FieldType.INPUT_SNMP: { ret = "INPUT_SNMP"; break; }
                case (UInt16)FieldType.L4_DST_PORT: { ret = "L4_DST_PORT"; break; }
                case (UInt16)FieldType.IPV4_DST_ADDR: { ret = "IPV4_DST_ADDR"; break; }
                case (UInt16)FieldType.DST_MASK: { ret = "DST_MASK"; break; }
                case (UInt16)FieldType.OUTPUT_SNMP: { ret = "OUTPUT_SNMP"; break; }
                case (UInt16)FieldType.IPV4_NEXT_HOP: { ret = "IPV4_NEXT_HOP"; break; }
                case (UInt16)FieldType.SRC_AS: { ret = "SRC_AS"; break; }
                case (UInt16)FieldType.DST_AS: { ret = "DST_AS"; break; }
                case (UInt16)FieldType.BGP_IPV4_NEXT_HOP: { ret = "BGP_IPV4_NEXT_HOP"; break; }
                case (UInt16)FieldType.MUL_DST_PKTS: { ret = "MUL_DST_PKTS"; break; }
                case (UInt16)FieldType.MUL_DST_BYTES: { ret = "MUL_DST_BYTES"; break; }
                case (UInt16)FieldType.LAST_SWITCHED: { ret = "LAST_SWITCHED"; break; }
                case (UInt16)FieldType.FIRST_SWITCHED: { ret = "FIRST_SWITCHED"; break; }
                case (UInt16)FieldType.OUT_BYTES: { ret = "OUT_BYTES"; break; }
                case (UInt16)FieldType.OUT_PKTS: { ret = "OUT_PKTS"; break; }
                case (UInt16)FieldType.IPV6_SRC_ADDR: { ret = "IPV6_SRC_ADDR"; break; }
                case (UInt16)FieldType.IPV6_DST_ADDR: { ret = "IPV6_DST_ADDR"; break; }
                case (UInt16)FieldType.IPV6_SRC_MASK: { ret = "IPV6_SRC_MASK"; break; }
                case (UInt16)FieldType.IPV6_DST_MASK: { ret = "IPV6_DST_MASK"; break; }
                case (UInt16)FieldType.IPV6_FLOW_LABEL: { ret = "IPV6_FLOW_LABEL"; break; }
                case (UInt16)FieldType.ICMP_TYPE: { ret = "ICMP_TYPE"; break; }
                case (UInt16)FieldType.MUL_IGMP_TYPE: { ret = "MUL_IGMP_TYPE"; break; }
                case (UInt16)FieldType.SAMPLING_INTERVAL: { ret = "SAMPLING_INTERVAL"; break; }
                case (UInt16)FieldType.SAMPLING_ALGORITHM: { ret = "SAMPLING_ALGORITHM"; break; }
                case (UInt16)FieldType.FLOW_ACTIVE_TIMEOUT: { ret = "FLOW_ACTIVE_TIMEOUT"; break; }
                case (UInt16)FieldType.FLOW_INACTIVE_TIMEOUT: { ret = "FLOW_INACTIVE_TIMEOUT"; break; }
                case (UInt16)FieldType.ENGINE_TYPE: { ret = "ENGINE_TYPE"; break; }
                case (UInt16)FieldType.ENGINE_ID: { ret = "ENGINE_ID"; break; }
                case (UInt16)FieldType.TOTAL_BYTES_EXP: { ret = "TOTAL_BYTES_EXP"; break; }
                case (UInt16)FieldType.TOTAL_PKTS_EXP: { ret = "TOTAL_PKTS_EXP"; break; }
                case (UInt16)FieldType.TOTAL_FLOWS_EXP: { ret = "TOTAL_FLOWS_EXP"; break; }
                case (UInt16)FieldType.MPLS_TOP_LABEL_TYPE: { ret = "MPLS_TOP_LABEL_TYPE"; break; }
                case (UInt16)FieldType.MPLS_TOP_LABEL_IP_ADDR: { ret = "MPLS_TOP_LABEL_IP_ADDR"; break; }
                case (UInt16)FieldType.FLOW_SAMPLER_ID: { ret = "FLOW_SAMPLER_ID"; break; }
                case (UInt16)FieldType.FLOW_SAMPLER_MODE: { ret = "FLOW_SAMPLER_MODE"; break; }
                case (UInt16)FieldType.FLOW_SAMPLER_RANDOM_INTERVAL: { ret = "FLOW_SAMPLER_RANDOM_INTERVAL"; break; }
                case (UInt16)FieldType.DST_TOS: { ret = "DST_TOS"; break; }
                case (UInt16)FieldType.SRC_MAC: { ret = "SRC_MAC"; break; }
                case (UInt16)FieldType.DST_MAC: { ret = "DST_MAC"; break; }
                case (UInt16)FieldType.SRC_VLAN: { ret = "SRC_VLAN"; break; }
                case (UInt16)FieldType.DST_VLAN: { ret = "DST_VLAN"; break; }
                case (UInt16)FieldType.IP_PROTOCOL_VERSION: { ret = "IP_PROTOCOL_VERSION"; break; }
                case (UInt16)FieldType.DIRECTION: { ret = "DIRECTION"; break; }
                case (UInt16)FieldType.IPV6_NEXT_HOP: { ret = "IPV6_NEXT_HOP"; break; }
                case (UInt16)FieldType.BGP_IPV6_NEXT_HOP: { ret = "BGP_IPV6_NEXT_HOP"; break; }
                case (UInt16)FieldType.IPV6_OPTION_HEADERS: { ret = "IPV6_OPTION_HEADERS"; break; }
                case (UInt16)FieldType.MPLS_LABEL_1: { ret = "MPLS_LABEL_1"; break; }
                case (UInt16)FieldType.MPLS_LABEL_2: { ret = "MPLS_LABEL_2"; break; }
                case (UInt16)FieldType.MPLS_LABEL_3: { ret = "MPLS_LABEL_3"; break; }
                case (UInt16)FieldType.MPLS_LABEL_4: { ret = "MPLS_LABEL_4"; break; }
                case (UInt16)FieldType.MPLS_LABEL_5: { ret = "MPLS_LABEL_5"; break; }
                case (UInt16)FieldType.MPLS_LABEL_6: { ret = "MPLS_LABEL_6"; break; }
                case (UInt16)FieldType.MPLS_LABEL_7: { ret = "MPLS_LABEL_7"; break; }
                case (UInt16)FieldType.MPLS_LABEL_8: { ret = "MPLS_LABEL_8"; break; }
                case (UInt16)FieldType.MPLS_LABEL_9: { ret = "MPLS_LABEL_9"; break; }
                case (UInt16)FieldType.MPLS_LABEL_10: { ret = "MPLS_LABEL_10"; break; }
                default: { ret = Types.ToString(); break; }
            }

            return ret;
        }
	}
}
