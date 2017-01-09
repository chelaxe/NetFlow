using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Collections;

namespace netflow {
    public struct netflow_header {
        public ushort Version;
        public ushort Count;
    };

    public struct V1Header {
        public netflow_header header;
        public uint sysUptime;
        public uint unix_secs;
        public uint unix_nsecs;
    };


    public struct V1Entry {
        public uint srcAddr;	/* source IP address */
        public uint dstAddr;	/* destination IP address */
        public uint nextHop;	/* next hop router's IP address */
        public ushort input;		/* input interface index */
        public ushort output;		/* Output interface index */
        public uint pkts;		/* packets sent in duration */
        public uint octets;		/* octets sent in duration */
        public uint first;		/* SysUptime at start of flow */
        public uint last;		/* and of Last packet of flow */
        public ushort srcPort;	/* TCP/UDP source port number or equivalent */
        public ushort dstPort;	/* TCP/UDP destination port number or equivalent */
        public ushort pad1;
        public byte protocol;		/* IP Protocol, e.g., 6=TCP, 17=UDP, ... */
        public byte tos;		/* IP Type-of-Service */
        public byte tcp_flags;
        public byte pad2;
        public ushort pad3;
        public uint reserved;	// AS number, either origin or destination.
    };


    public struct V5Header {
        public netflow_header header;
        public uint sysUptime;
        public uint unix_secs;
        public uint unix_nsecs;
        public uint flow_sequence;
        public byte engine_type;
        public byte engine_id;
        public ushort reserved;
    };


    public struct V5Entry {
        public uint srcAddr;	/* source IP address */
        public uint dstAddr;	/* destination IP address */
        public uint nextHop;	/* next hop router's IP address */
        public ushort input;		/* Input interface index */
        public ushort output;		/* Output interface index */
        public uint pkts;		/* packets sent in duration */
        public uint octets;		/* octets sent in duration */
        public uint first;		/* SysUptime at start of flow */
        public uint last;		/* and of Last packet of flow */
        public ushort srcPort;	/* TCP/UDP source port number or equivalent */
        public ushort dstPort;	/* TCP/UDP dest port number or equivalent */
        public byte pad;
        public byte tcp_flags;	/* bitwise OR of all TCP flags in flow; 0x10 */
        /*	for non-TCP flows */
        public byte prot;		/* IP Protocol, e.g., 6=TCP, 17=UDP, ... */
        public byte tos;		/* IP Type-of-Service */
        public ushort dst_as;		/* originating AS of destination address */
        public ushort src_as;		/* originating AS of source address */
        public byte dst_mask;	/* destination address prefix mask bits */
        public byte src_mask;	/* source address prefix mask bits */
        public ushort reserved;
    };

    public struct V7Header {
        public netflow_header header;
        public uint sysUptime;
        public uint unix_secs;
        public uint unix_nsecs;
        public uint flow_sequence;
        public uint reserved;
    };


    public struct V7Entry {
        public uint srcAddr;		/* source IP address */
        public uint dstAddr;		/* destination IP address */
        public uint nexthop;		/* next hop router's IP address */
        public ushort input;			/* Input interface index */
        public ushort output;			/* Output interface index */
        public uint pkts;			/* packets sent in duration */
        public uint octets;		 	/* octets sent in duration */
        public uint first;		 	/* SysUptime at start of flow */
        public uint last;			/* and of Last packet of flow */
        public ushort srcPort;		/* TCP/UDP source port number or equivalent */
        public ushort dstPort;		/* TCP/UDP dest port number or equivalent */
        public byte flags;
        public byte tcp_flags;	 	/* bitwise OR of all TCP flags seen in flow */
        public byte prot;			/* IP Protocol, e.g., 6=TCP, 17=UDP, ... */
        public byte tos;			/* IP Type-of-Service */
        public ushort src_as;			/* originating AS of source address */
        public ushort dst_as;			/* originating AS of destination address */
        public byte src_mask;		/* source address prefix mask bits */
        public byte dst_mask;		/* destination address prefix mask bits */
        public ushort flags2;
        public uint peer_nextHop;	/* IPaddr of the Nexthop w/in the peer (FIB) */
    };


    public struct V8Header {
        public netflow_header header;
        public uint sysUptime;
        public uint unix_secs;
        public uint unix_nsecs;
        public uint flow_sequence;
        public byte engine_type;
        public byte engine_id;
        public byte aggregation;
        public uint reserved;
    };


    public enum V8Aggregation {
        AS = 1,
        ProtocolPort = 2,
        SrcPrefix = 3,
        DstPrefix = 4,
        Prefix = 5,
        DstPrefixToS,
        PrefixToS,
        PrefixPort,
        ASToS = 9,
        ProtocolPortToS = 10,
        SrcPrefixToS = 11
    };

    /*
    * V8 Entry AS aggregation
    */
    public struct V8Entry_AS {
        public uint flows;			/* Number of flows */
        public uint dPkts;			/* Packets sent in Duration */
        public uint dOctets;		/* Octets sent in Duration */
        public uint first;		 	/* SysUptime at start of flow */
        public uint last;			/* and of Last packet of flow */
        public ushort src_as;			/* originating AS of source address */
        public ushort dst_as;			/* originating AS of destination address */
        public ushort input;
        public ushort output;
    };

    /*
    * V8 Entry Destination Prefix aggregation
    */
    public struct V8Entry_DstPrefix {
        public uint flows;			/* Number of flows */
        public uint dPkts;			/* Packets sent in Duration */
        public uint dOctets;		/* Octets sent in Duration */
        public uint first;		 	/* SysUptime at start of flow */
        public uint last;			/* and of Last packet of flow */
        public uint dst_prefix;		/* Destination IP address */
        public byte dst_mask;		/* destination address prefix mask bits */
        public byte pad;
        public ushort dst_as;			/* originating AS of destination address */
        public ushort output;			/* Output interface index */
        public ushort reserved;
    };

    /*
    * V8 Entry Prefix aggregation
    */
    public struct V8Entry_Prefix {
        public uint flows;			/* Number of flows */
        public uint dPkts;			/* Packets sent in Duration */
        public uint dOctets;		/* Octets sent in Duration */
        public uint first;		 	/* SysUptime at start of flow */
        public uint last;			/* and of Last packet of flow */
        public uint src_prefix;		/* source IP address */
        public uint dst_prefix;		/* Destination IP address */
        public byte dst_mask;		/* destination address prefix mask bits */
        public byte src_mask;		/* source address prefix mask bits */
        public ushort reserved;
        public ushort src_as;			/* originating AS of source address */
        public ushort dst_as;			/* originating AS of destination address */
        public ushort input;			/* input interface index */
        public ushort output;			/* Output interface index */
    };

    /*
    * V8 Entry Protocol Port aggregation
    */
    public struct V8Entry_ProtocolPort {
        public uint flows;			/* Number of flows */
        public uint dPkts;			/* Packets sent in Duration */
        public uint dOctets;		/* Octets sent in Duration */
        public uint first;		 	/* SysUptime at start of flow */
        public uint last;			/* and of Last packet of flow */
        public byte prot;			/* IP Protocol, e.g., 6=TCP, 17=UDP, ... */
        public byte pad;
        public ushort reserved;
        public ushort src_port;		/* TCP/UDP source port number or equivalent */
        public ushort dst_port;		/* TCP/UDP dest port number or equivalent */
    };


    /*
    * V8 Entry SourcePrefix aggregation
    */
    public struct V8Entry_SrcPrefix {
        public uint flows;			/* Number of flows */
        public uint dPkts;			/* Packets sent in Duration */
        public uint dOctets;		/* Octets sent in Duration */
        public uint first;		 	/* SysUptime at start of flow */
        public uint last;			/* and of Last packet of flow */
        public uint src_prefix;		/* source IP address */
        public byte src_mask;		/* source address prefix mask bits */
        public byte pad;
        public ushort src_as;			/* originating AS of source address */
        public ushort input;			/* input interface index */
        public ushort reserved;
    };


    // AS ToS aggregation
    public struct V8Entry_ASToS {
        public uint flows;
        public uint dPkts;
        public uint dOctets;
        public uint first;
        public uint last;
        public ushort src_as;
        public ushort dst_as;
        public ushort input;
        public ushort output;
        public byte tos;
        public byte pad;
        public ushort reserved;
    };

    // dest prefix ToS aggregation
    public struct V8Entry_DstPrefixToS {
        public uint destAddr;
        public uint dPkts;
        public uint dOctets;
        public uint first;
        public uint last;
        public ushort output;
        public byte tos;
        public byte dst_masks;
        public uint reserved;
        public uint dst_prefix;
    };

    // prefix TOS aggregation
    struct V8Entry_PrefixToS {
        public uint destAddr;
        public uint srcAddr;
        public uint dPkts;
        public uint dOctets;
        public uint first;
        public uint last;
        public ushort output;
        public ushort input;
        public byte tos;
        public byte pad;
        public ushort reserved;
        public uint extra_packets;
        public uint dest_prefix;
    };

    // prefix port aggregation
    struct V8Entry_PrefixPort {
        public uint srcAddr;
        public uint destAddr;
        public ushort src_port;
        public ushort dst_port;
        public uint dPkts;
        public uint dOctets;
        public uint first;
        public uint last;
        public ushort input;
        public ushort output;
        public byte tos;
        public byte prot;
        public ushort reserved;
        public uint extra_packets;
        public uint dest_prefix;
    };

    // Source prefix ToS aggregation
    public struct V8Entry_SrcPrefixToS {
        public uint flows;
        public uint dPkts;
        public uint dOctets;
        public uint first;
        public uint last;
        public uint src_prefix;
        public byte src_masks;
        public byte tos;
        public ushort src_as;
        public ushort input;
        public ushort reserved;
    };

    // protocol tos aggregation
    public struct V8Entry_ProtocolPortToS {
        public uint flows;
        public uint dPkts;
        public uint dOctets;
        public uint first;
        public uint last;
        public byte prot;
        public byte tos;
        public ushort reserved;
        public ushort src_port;
        public ushort dst_port;
        public ushort input;
        public ushort output;
    };

    public struct V9Header {
        public netflow_header header;
        public uint sysUptime;
        public uint unix_secs;
        public uint flow_sequence;
        public uint src_id;
    };

    public struct V9TemplateField {
        public ushort Type;
        public ushort Length;
    };

    /*
    flowset header for v9 template, option and data flow
    */
    public struct V9FlowsetHeader {
        public ushort flowsetType;
        public ushort flowsetLength;
    };

    public struct V9TemplateHeader {
        public V9FlowsetHeader flowsetHeader;
        public ushort templateId;
        public ushort fieldCount;
    };

    public class V9Template {
        V9TemplateHeader header;
        ArrayList fields;
        ushort dataSize = 0;
        ushort sendFrequency;

        public V9Template(ushort id) {
            header.templateId = id;
            fields = new ArrayList();
        }
        public void AddField(ushort type, ushort length) {
            V9TemplateField field = new V9TemplateField();
            field.Type = type;
            field.Length = length;
            fields.Add(field);
            dataSize += length;
            header.fieldCount += 1;
        }

        public ArrayList GetFields() {
            return fields;
        }

        public ushort TemplateId {
            get {
                return header.templateId;
            }
        }

        public ushort FieldCount {
            get {
                return header.fieldCount;
            }
        }
        // template flowset length
        public ushort FlowsetLength {
            get {
                return (ushort)((FieldCount + 2) * 4);
            }
        }
        // data packet length using this template
        public ushort PduSize {
            get {
                return (ushort)(dataSize);
            }
        }

        public ushort SendFrequency {
            set {
                sendFrequency = value;
            }
            get {
                return sendFrequency;
            }
        }
    }

    //////////////////////////////////////////////////
    // define IPFIX flow
    public struct IpfixMessageHeader {
        public UInt16 versionNumber;
        public UInt16 length;
        public uint exportTime;
        public uint sequenceNumber;
        public uint domainId;
    };

    public struct IpfixTemplateField {
        public ushort elementId;
        public ushort Length;
        public uint enterpriseNumber; // optional field
        public bool IsEnterpriseField {
            get {
                return (elementId & 0xA000) == 1;
            }
        }
    };

    // Set Header: data set, template or template option
    public struct IpfixFlowsetHeader {
        public ushort setId;
        public ushort setLength;
    };

    public struct IpfixTemplateHeader {
        public IpfixFlowsetHeader flowsetHeader;
        public ushort templateId;
        public ushort fieldCount;
    };

    public class IpfixTemplate {
        IpfixTemplateHeader header;
        ArrayList fields;
        ushort dataSize = 0;
        ushort sendFrequency;

        public IpfixTemplate(ushort id) {
            header.templateId = id;
            fields = new ArrayList();
        }
        public void AddField(ushort type, ushort length) {
            IpfixTemplateField field = new IpfixTemplateField();
            field.elementId = type;
            field.Length = length;
            fields.Add(field);
            dataSize += length;
            header.fieldCount += 1;
        }

        public ArrayList GetFields() {
            return fields;
        }

        public ushort TemplateId {
            get {
                return header.templateId;
            }
        }

        public ushort FieldCount {
            get {
                return header.fieldCount;
            }
        }
        // template flowset length
        public ushort FlowsetLength {
            get {
                ushort length = 2 * 4; // message header + template header;
                foreach (IpfixTemplateField field in fields) {
                    if (field.IsEnterpriseField) {
                        length += 2 * 4;
                    } else {
                        length += 4;
                    }
                }
                return length;
            }
        }
        // data packet length using this template
        public ushort PduSize {
            get {
                return (ushort)(dataSize);
            }
        }

        public ushort SendFrequency {
            set {
                sendFrequency = value;
            }
            get {
                return sendFrequency;
            }
        }
    }


    public abstract class Netflow : flowsimulator.FlowGenerator {
        [StructLayout(LayoutKind.Explicit)]
        struct FourBytesUnion {
            [FieldOffset(0)]
            public uint u;
            [FieldOffset(0)]
            public byte b0;
            [FieldOffset(1)]
            public byte b1;
            [FieldOffset(2)]
            public byte b2;
            [FieldOffset(3)]
            public byte b3;
        } ;

        [StructLayout(LayoutKind.Explicit)]
        struct TwoBytesUnion {
            [FieldOffset(0)]
            public ushort s;
            [FieldOffset(0)]
            public byte b0;
            [FieldOffset(1)]
            public byte b1;
        } ;

        public static ushort reverseByteOrder(ushort u) {
            TwoBytesUnion v;
            v.b0 = v.b1 = 0;
            v.s = u;
            return (ushort)((v.b0 << 8) + v.b1);
        }
        public static uint reverseByteOrder(uint u) {
            FourBytesUnion v;
            v.b0 = v.b1 = v.b2 = v.b3 = 0;
            v.u = u;
            return (uint)((v.b0 << 24) + (v.b1 << 16) + (v.b2 << 8) + v.b3);
        }


        protected static int MAX_PACKET_SIZE = 2048;
        protected static int MAX_FLOWS = 30;
        protected ushort packet_size = 0;
        protected netflow_header header;
        protected uint unix_nsecs;
        protected uint sequence;
        protected readonly uint eng_src_id;
        protected readonly uint sysUpTime;

        public Netflow(ushort version
            , uint sysuptime
            , uint id
            , uint initial_sequence) {
            header.Version = reverseByteOrder(version);
            eng_src_id = reverseByteOrder(id);
            sysUpTime = reverseByteOrder(sysuptime);
            sequence = initial_sequence;
            packet = new byte[MAX_PACKET_SIZE];
            random = new System.Random();
        }

       public override void sendPacket() {
            System.Random r = new Random();
            ushort flows = (ushort)(r.Next() % MAX_FLOWS);
            if (flows == 0) {
                flows = (ushort)MAX_FLOWS;
            }
            if (header.Version == 0x0700 && flows >= 27) {// more than 27 flows cause fragmentation error
                flows = (ushort)(r.Next() % 25 + 1);
            }
            ShowStatusDelegate showStatus = new ShowStatusDelegate(ShowStatus);

            if (statusLine != null) {
                msg.Append("Sending packet - version: ").Append(reverseByteOrder(header.Version));
                msg.Append(", flows: ").Append(flows);
                //invoke(showStatus, msg.ToString());
                if (!statusLine.InvokeRequired) {
                    statusLine.Text = msg.ToString();
                } else {
                    statusLine.Invoke(showStatus, new object[] { msg.ToString() });
                }
                msg.Remove(0, msg.Length);
            }
            if (this.header.Version == 0x0500 || this.header.Version == 0x0800) {
                sequence += flows;
            } else {
                ++sequence;
            }
            createPacket(flows);
            udpServer.sendPacket(ref packet, packet_size);
        }
    }

    public class V1Netflow : Netflow {
        private V1Header v1header;

        public V1Netflow(ushort version
            , uint sysuptime
            , uint id
            , uint initial_sequence)
            :
            base(version, sysuptime, id, initial_sequence) {
            v1header.header = header;
            v1header.sysUptime = sysuptime;
        }

        public override ushort createPacket(ushort flows) {
            TimeSpan ts = DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            v1header.unix_secs = v1header.unix_nsecs
                = reverseByteOrder((uint)ts.TotalSeconds);
            v1header.header.Count = reverseByteOrder(flows);

            System.Random rand = new System.Random();

            unsafe {

                rand.NextBytes(packet);

                packet_size = (ushort)(sizeof(V1Header) + flows * sizeof(V1Entry));

                fixed (byte* pb = packet) {
                    // set the header
                    V1Header* pheader = (V1Header*)pb;
                    *pheader = v1header;

                    if (options.Mode == flowsimulator.OptionsForm.RandomMode.LimitedRandom) {
                        for (int i = 0; i < flows; ++i) {
                            V1Entry* pE = (V1Entry*)(pb + sizeof(V1Header) + sizeof(V1Entry) * i);
                            pE->first = flowsimulator.ValueRange.NextInteger;
                            pE->last = pE->first + flowsimulator.ValueRange.NextByte;
                            pE->srcAddr = options.NextSrcAddress;
                            pE->dstAddr = options.NextDstAddress;
                            pE->nextHop = options.NextSrcAddress;
                            pE->octets = options.NextBytes;
                            pE->pkts = options.NextPackets;
                            pE->input = options.NextInterface;
                            pE->output = options.NextInterface;
                            pE->srcPort = options.NextPort;
                            pE->dstPort = options.NextPort;
                            pE->protocol = options.NextProtocol;
                            pE->tcp_flags = options.NextTcpFlag;
                            pE->tos = options.NextTOS;
                        }
                    }
                }
            }// end of unsafe
            return packet_size;
        }
    }

    public class V5Netflow : Netflow {
        private V5Header v5header;

        public V5Netflow(ushort version
            , uint sysuptime
            , uint id
            , uint initial_sequence)
            :
            base(version, sysuptime, id, initial_sequence) {
            v5header.header = header;
            v5header.sysUptime = sysuptime;
        }

        public override ushort createPacket(ushort flows) {
            TimeSpan ts = DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            v5header.unix_secs = v5header.unix_nsecs
                = reverseByteOrder((uint)ts.TotalSeconds);
            v5header.header.Count = reverseByteOrder(flows);
            v5header.flow_sequence = reverseByteOrder(sequence);

            System.Random rand = new System.Random();

            unsafe {

                rand.NextBytes(packet);

                packet_size = (ushort)(sizeof(V5Header) + flows * sizeof(V5Entry));

                fixed (byte* pb = packet) {
                    // set the header
                    V5Header* pheader = (V5Header*)pb;
                    *pheader = v5header;
                    if (options.Mode == flowsimulator.OptionsForm.RandomMode.LimitedRandom) {
                        for (int i = 0; i < flows; ++i) {
                            V5Entry* pE = (V5Entry*)(pb + sizeof(V5Header) + sizeof(V5Entry) * i);
                            pE->first = flowsimulator.ValueRange.NextInteger;
                            pE->last = pE->first + flowsimulator.ValueRange.NextByte;
                            pE->srcAddr = options.NextSrcAddress;
                            pE->dstAddr = options.NextDstAddress;
                            pE->nextHop = options.NextSrcAddress;
                            pE->octets = options.NextBytes;
                            pE->pkts = options.NextPackets;
                            pE->input = options.NextInterface;
                            pE->output = options.NextInterface;
                            pE->srcPort = options.NextPort;
                            pE->dstPort = options.NextPort;
                            pE->prot = options.NextProtocol;
                            pE->tcp_flags = options.NextTcpFlag;
                            pE->tos = options.NextTOS;
                            pE->src_as = options.NextAS;
                            pE->dst_as = options.NextAS;
                            pE->src_mask = options.NextMask;
                            pE->dst_mask = options.NextMask;
                        }
                    }

                } // end of fixed
            }// end of unsafe
            return packet_size;
        }
    }

    public class V7Netflow : Netflow {
        private V7Header v7header;

        public V7Netflow(ushort version
            , uint sysuptime
            , uint id
            , uint initial_sequence)
            :
            base(version, sysuptime, id, initial_sequence) {
            v7header.header = header;
            v7header.sysUptime = reverseByteOrder(sysuptime);
        }

        public override ushort createPacket(ushort flows) {
            TimeSpan ts = DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            v7header.unix_secs = v7header.unix_nsecs
                = reverseByteOrder((uint)ts.TotalSeconds);
            v7header.header.Count = reverseByteOrder(flows);
            v7header.flow_sequence = reverseByteOrder(sequence);

            System.Random rand = new System.Random();

            unsafe {

                rand.NextBytes(packet);

                packet_size = (ushort)(sizeof(V7Header) + flows * sizeof(V7Entry));

                fixed (byte* pb = packet) {
                    // set the header
                    V7Header* pheader = (V7Header*)pb;
                    *pheader = v7header;
                    if (options.Mode == flowsimulator.OptionsForm.RandomMode.LimitedRandom) {
                        for (int i = 0; i < flows; ++i) {
                            V7Entry* pE = (V7Entry*)(pb + sizeof(V7Header) + sizeof(V7Entry) * i);
                            pE->first = reverseByteOrder(flowsimulator.ValueRange.NextInteger);
                            pE->last = reverseByteOrder(
                                reverseByteOrder(pE->first) + flowsimulator.ValueRange.NextByte);
                            pE->srcAddr = options.NextSrcAddress;
                            pE->dstAddr = options.NextDstAddress;
                            pE->nexthop = options.NextSrcAddress;
                            pE->octets = options.NextBytes;
                            pE->pkts = options.NextPackets;
                            pE->input = options.NextInterface;
                            pE->output = options.NextInterface;
                            pE->srcPort = options.NextPort;
                            pE->dstPort = options.NextPort;
                            pE->prot = options.NextProtocol;
                            pE->tcp_flags = options.NextTcpFlag;
                            pE->tos = options.NextTOS;
                            pE->src_as = options.NextAS;
                            pE->dst_as = options.NextAS;
                            pE->src_mask = options.NextMask;
                            pE->dst_mask = options.NextMask;
                            pE->peer_nextHop = options.NextDstAddress;
                            pE->flags2 = options.NextTcpFlag;
                            pE->flags = options.NextTcpFlag;
                        }
                    }

                } // end of fixed
            }// end of unsafe
            return packet_size;
        }

    }
    public class V8Netflow : Netflow {
        private V8Header v8header;
        private V8Aggregation aggregation = V8Aggregation.AS;

        public V8Netflow(ushort version
            , uint sysuptime
            , uint id
            , uint initial_sequence)
            :
            base(version, sysuptime, id, initial_sequence) {
            v8header.header = header;
            v8header.sysUptime = reverseByteOrder(sysuptime);
        }

        public V8Aggregation Aggregation {
            set {
                aggregation = value;
            }
        }

        public override ushort createPacket(ushort flows) {
            TimeSpan ts = DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            v8header.unix_secs = v8header.unix_nsecs
                = reverseByteOrder((uint)ts.TotalSeconds);
            v8header.header.Count = reverseByteOrder(flows);
            v8header.flow_sequence = reverseByteOrder(sequence);
            v8header.aggregation = (byte)aggregation;

            System.Random rand = new System.Random();

            unsafe {

                rand.NextBytes(packet);

                switch (aggregation) {
                    case V8Aggregation.AS:
                        packet_size = (ushort)(sizeof(V8Header) + flows * sizeof(V8Entry_AS));
                        break;
                    case V8Aggregation.DstPrefix:
                        packet_size = (ushort)(sizeof(V8Header) + flows * sizeof(V8Entry_DstPrefix));
                        break;
                    case V8Aggregation.Prefix:
                        packet_size = (ushort)(sizeof(V8Header) + flows * sizeof(V8Entry_Prefix));
                        break;
                    case V8Aggregation.ProtocolPort:
                        packet_size = (ushort)(sizeof(V8Header) + flows * sizeof(V8Entry_ProtocolPort));
                        break;
                    case V8Aggregation.SrcPrefix:
                        packet_size = (ushort)(sizeof(V8Header) + flows * sizeof(V8Entry_SrcPrefix));
                        break;
                    case V8Aggregation.ASToS:
                        packet_size = (ushort)(sizeof(V8Header) + flows * sizeof(V8Entry_ASToS));
                        break;
                    case V8Aggregation.DstPrefixToS:
                        packet_size = (ushort)(sizeof(V8Header) + flows * sizeof(V8Entry_DstPrefixToS));
                        break;
                    case V8Aggregation.PrefixToS:
                        packet_size = (ushort)(sizeof(V8Header) + flows * sizeof(V8Entry_PrefixToS));
                        break;
                    case V8Aggregation.ProtocolPortToS:
                        packet_size = (ushort)(sizeof(V8Header) + flows * sizeof(V8Entry_ProtocolPortToS));
                        break;
                    case V8Aggregation.SrcPrefixToS:
                        packet_size = (ushort)(sizeof(V8Header) + flows * sizeof(V8Entry_SrcPrefixToS));
                        break;
                    case V8Aggregation.PrefixPort:
                        packet_size = (ushort)(sizeof(V8Header) + flows * sizeof(V8Entry_PrefixPort));
                        break;
                }

                fixed (byte* pb = packet) {
                    // set the header
                    V8Header* pheader = (V8Header*)pb;
                    *pheader = v8header;
                    if (options.Mode == flowsimulator.OptionsForm.RandomMode.LimitedRandom) {
                        for (int i = 0; i < flows; ++i) {
                            switch (aggregation) {
                                case V8Aggregation.AS: {
                                        V8Entry_AS* pE = (V8Entry_AS*)(pb + sizeof(V8Header) + sizeof(V8Entry_AS) * i);

                                        pE->first = reverseByteOrder(flowsimulator.ValueRange.NextInteger);
                                        pE->last = reverseByteOrder(
                                            reverseByteOrder(pE->first) + flowsimulator.ValueRange.NextByte);
                                        pE->flows = options.NextFlows;
                                        pE->dPkts = options.NextPackets;
                                        pE->dOctets = options.NextBytes;
                                        pE->src_as = options.NextAS;
                                        pE->dst_as = options.NextAS;
                                        pE->input = options.NextInterface;
                                        pE->output = options.NextInterface;
                                    }
                                    break;
                                case V8Aggregation.DstPrefix: {
                                        V8Entry_DstPrefix* pE = (V8Entry_DstPrefix*)(pb + sizeof(V8Header) + sizeof(V8Entry_DstPrefix) * i);

                                        pE->first = reverseByteOrder(flowsimulator.ValueRange.NextInteger);
                                        pE->last = reverseByteOrder(
                                            reverseByteOrder(pE->first) + flowsimulator.ValueRange.NextByte);
                                        pE->flows = options.NextFlows;
                                        pE->dPkts = options.NextPackets;
                                        pE->dOctets = options.NextBytes;
                                        pE->dst_prefix = options.NextDstAddress;
                                        pE->output = options.NextInterface;
                                        pE->dst_mask = options.NextMask;
                                        pE->dst_as = options.NextAS;
                                    }
                                    break;
                                case V8Aggregation.Prefix: {
                                        V8Entry_Prefix* pE = (V8Entry_Prefix*)(pb + sizeof(V8Header) + sizeof(V8Entry_Prefix) * i);

                                        pE->first = reverseByteOrder(flowsimulator.ValueRange.NextInteger);
                                        pE->last = reverseByteOrder(
                                            reverseByteOrder(pE->first) + flowsimulator.ValueRange.NextByte);
                                        pE->flows = options.NextFlows;
                                        pE->dPkts = options.NextPackets;
                                        pE->dOctets = options.NextBytes;
                                        pE->input = options.NextInterface;
                                        pE->output = options.NextInterface;
                                        pE->src_as = options.NextAS;
                                        pE->dst_as = options.NextAS;
                                        pE->src_prefix = options.NextSrcAddress;
                                        pE->dst_prefix = options.NextDstAddress;
                                        pE->src_mask = options.NextMask;
                                        pE->dst_mask = options.NextMask;

                                    }
                                    break;
                                case V8Aggregation.ProtocolPort: {
                                        V8Entry_ProtocolPort* pE = (V8Entry_ProtocolPort*)(pb + sizeof(V8Header) + sizeof(V8Entry_ProtocolPort) * i);

                                        pE->first = reverseByteOrder(flowsimulator.ValueRange.NextInteger);
                                        pE->last = reverseByteOrder(
                                            reverseByteOrder(pE->first) + flowsimulator.ValueRange.NextByte);
                                        pE->flows = options.NextFlows;
                                        pE->dPkts = options.NextPackets;
                                        pE->dOctets = options.NextBytes;
                                        pE->prot = options.NextProtocol;
                                        pE->src_port = options.NextPort;
                                        pE->dst_port = options.NextPort;
                                    }
                                    break;
                                case V8Aggregation.SrcPrefix: {
                                        V8Entry_SrcPrefix* pE = (V8Entry_SrcPrefix*)(pb + sizeof(V8Header) + sizeof(V8Entry_SrcPrefix) * i);

                                        pE->first = reverseByteOrder(flowsimulator.ValueRange.NextInteger);
                                        pE->last = reverseByteOrder(
                                            reverseByteOrder(pE->first) + flowsimulator.ValueRange.NextByte);
                                        pE->flows = options.NextFlows;
                                        pE->dPkts = options.NextPackets;
                                        pE->dOctets = options.NextBytes;
                                        pE->input = options.NextInterface;
                                        pE->src_prefix = options.NextSrcAddress;
                                        pE->src_as = options.NextAS;
                                        pE->src_mask = options.NextMask;
                                    }
                                    break;
                                case V8Aggregation.ASToS: {
                                        V8Entry_ASToS* pE = (V8Entry_ASToS*)(pb + sizeof(V8Header) + sizeof(V8Entry_ASToS) * i);

                                        pE->first = reverseByteOrder(flowsimulator.ValueRange.NextInteger);
                                        pE->last = reverseByteOrder(
                                            reverseByteOrder(pE->first) + flowsimulator.ValueRange.NextByte);
                                        pE->flows = options.NextFlows;
                                        pE->dPkts = options.NextPackets;
                                        pE->dOctets = options.NextBytes;
                                        pE->input = options.NextInterface;
                                        pE->output = options.NextInterface;
                                        pE->src_as = options.NextAS;
                                        pE->dst_as = options.NextAS;
                                        pE->tos = options.NextTOS;
                                    }
                                    break;
                                case V8Aggregation.DstPrefixToS: {
                                        V8Entry_DstPrefixToS* pE = (V8Entry_DstPrefixToS*)(pb + sizeof(V8Header) + sizeof(V8Entry_DstPrefixToS) * i);

                                        pE->destAddr = options.NextDstAddress;
                                        pE->first = reverseByteOrder(flowsimulator.ValueRange.NextInteger);
                                        pE->last = reverseByteOrder(
                                            reverseByteOrder(pE->first) + flowsimulator.ValueRange.NextByte);
                                        pE->dPkts = options.NextPackets;
                                        pE->dOctets = options.NextBytes;
                                        pE->dst_prefix = options.NextDstAddress;
                                        pE->output = options.NextInterface;
                                        pE->dst_masks = options.NextMask;
                                        pE->tos = options.NextTOS;
                                    }
                                    break;
                                case V8Aggregation.PrefixToS: {
                                        V8Entry_PrefixToS* pE = (V8Entry_PrefixToS*)(pb + sizeof(V8Header) + sizeof(V8Entry_PrefixToS) * i);

                                        pE->first = reverseByteOrder(flowsimulator.ValueRange.NextInteger);
                                        pE->last = reverseByteOrder(
                                            reverseByteOrder(pE->first) + flowsimulator.ValueRange.NextByte);
                                        pE->destAddr = options.NextDstAddress;
                                        pE->srcAddr = options.NextSrcAddress;
                                        pE->dPkts = options.NextPackets;
                                        pE->dOctets = options.NextBytes;
                                        pE->input = options.NextInterface;
                                        pE->output = options.NextInterface;
                                        pE->dest_prefix = options.NextDstAddress;
                                        pE->tos = options.NextTOS;
                                        pE->pad = 0;
                                        pE->reserved = 0;
                                        pE->extra_packets = 0;
                                    }
                                    break;
                                case V8Aggregation.ProtocolPortToS: {
                                        V8Entry_ProtocolPortToS* pE = (V8Entry_ProtocolPortToS*)(pb + sizeof(V8Header) + sizeof(V8Entry_ProtocolPortToS) * i);

                                        pE->first = reverseByteOrder(flowsimulator.ValueRange.NextInteger);
                                        pE->last = reverseByteOrder(
                                            reverseByteOrder(pE->first) + flowsimulator.ValueRange.NextByte);
                                        pE->dPkts = options.NextPackets;
                                        pE->dOctets = options.NextBytes;
                                        pE->input = options.NextInterface;
                                        pE->output = options.NextInterface;
                                        pE->src_port = options.NextPort;
                                        pE->dst_port = options.NextPort;
                                        pE->tos = options.NextTOS;
                                        pE->prot = options.NextProtocol;
                                        pE->flows = options.NextFlows;
                                    }
                                    break;
                                case V8Aggregation.SrcPrefixToS: {
                                        V8Entry_SrcPrefixToS* pE = (V8Entry_SrcPrefixToS*)(pb + sizeof(V8Header) + sizeof(V8Entry_SrcPrefixToS) * i);

                                        pE->first = reverseByteOrder(flowsimulator.ValueRange.NextInteger);
                                        pE->last = reverseByteOrder(
                                            reverseByteOrder(pE->first) + flowsimulator.ValueRange.NextByte);
                                        pE->flows = options.NextFlows;
                                        pE->dPkts = options.NextPackets;
                                        pE->dOctets = options.NextBytes;
                                        pE->input = options.NextInterface;
                                        pE->src_prefix = options.NextSrcAddress;
                                        pE->src_as = options.NextAS;
                                        pE->src_masks = options.NextMask;
                                        pE->tos = options.NextTOS;
                                    }
                                    break;
                                case V8Aggregation.PrefixPort: {
                                        V8Entry_PrefixPort* pE = (V8Entry_PrefixPort*)(pb + sizeof(V8Header) + sizeof(V8Entry_PrefixPort) * i);

                                        pE->first = reverseByteOrder(flowsimulator.ValueRange.NextInteger);
                                        pE->last = reverseByteOrder(
                                            reverseByteOrder(pE->first) + flowsimulator.ValueRange.NextByte);
                                        pE->dPkts = options.NextPackets;
                                        pE->dOctets = options.NextBytes;
                                        pE->input = options.NextInterface;
                                        pE->output = options.NextInterface;
                                        pE->srcAddr = options.NextSrcAddress;
                                        pE->destAddr = options.NextDstAddress;
                                        pE->src_port = options.NextPort;
                                        pE->dst_port = options.NextPort;
                                        pE->prot = options.NextProtocol;
                                        pE->tos = options.NextTOS;
                                        pE->dest_prefix = options.NextDstAddress;
                                        pE->extra_packets = 0;
                                        pE->reserved = 0;
                                    }
                                    break;
                            }
                        }
                    }
                } // end of fixed
            }// end of unsafe
            return packet_size;
        }

    }

    public class V9Netflow : Netflow {
        private V9Header v9header;
        private ArrayList templates;
        private int currentTemplateIndex = 0;

        private bool sendTemplate = false;

        public V9Netflow(ushort version
            , uint sysuptime
            , uint id
            , uint initial_sequence)
            :
        base(version, sysuptime, id, initial_sequence) {
            v9header.header = header;
            v9header.sysUptime = reverseByteOrder(sysuptime);
        }
        public ArrayList Templates {
            set {
                templates = value;
            }
        }

        public override ushort createPacket(ushort flows) {
            TimeSpan ts = DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            v9header.unix_secs = reverseByteOrder((uint)ts.TotalSeconds);
            v9header.header.Count = reverseByteOrder(flows);
            v9header.flow_sequence = reverseByteOrder(sequence);
            v9header.src_id = 0;

            if (currentTemplateIndex >= templates.Count) {
                currentTemplateIndex = 0;
            }
            V9Template template = (V9Template)templates[currentTemplateIndex];
            ++currentTemplateIndex;

            if (sequence % (template.SendFrequency / 2) == 0) {
                sendTemplate = true;
                // make sure all templates have change to be sent
                int index = random.Next(templates.Count);
                template = (V9Template)templates[index];
            } else {
                sendTemplate = false;
            }

            if (sendTemplate) {
                v9header.header.Count = reverseByteOrder((ushort)(flows + 1));
                unsafe {
                    packet_size = (ushort)(sizeof(V9FlowsetHeader) + (template.PduSize * flows) + template.FlowsetLength);
                    packet_size += (ushort)sizeof(V9Header);
                }
            } else {
                unsafe {
                    packet_size = (ushort)(sizeof(V9FlowsetHeader) + (template.PduSize * flows));
                    packet_size += (ushort)sizeof(V9Header);
                }
            }
            random.NextBytes(packet);

            unsafe {
                fixed (byte* pB = packet) {
                    V9Header* pheader = (V9Header*)pB;
                    *pheader = v9header;

                    ushort* pU = (ushort*)(pB + sizeof(V9Header));
                    if (sendTemplate) {
                        // set header first
                        *pU = 0; // template type id, template is 0
                        pU++;
                        *pU = reverseByteOrder(template.FlowsetLength);
                        pU++;
                        *pU = reverseByteOrder(template.TemplateId);
                        pU++;
                        *pU = reverseByteOrder(template.FieldCount);
                        pU++;
                        // set the template set
                        ArrayList tFields = template.GetFields();
                        for (int i = 0; i < tFields.Count; ++i) {
                            V9TemplateField field = (V9TemplateField)tFields[i];
                            *pU = reverseByteOrder(field.Type);
                            pU++;
                            *pU = reverseByteOrder(field.Length);
                            pU++;
                        }
                    }
                    // set data flow type id
                    *pU = reverseByteOrder(template.TemplateId);
                    pU++;
                    // set flowset length
                    *pU = reverseByteOrder((ushort)(sizeof(V9FlowsetHeader) + (template.PduSize * flows)));
                    pU++;

                    byte* pb = (byte*)pU;
                    uint* pUI = (uint*)pU;

                    if (options.Mode != flowsimulator.OptionsForm.RandomMode.LimitedRandom) {
                        return packet_size;
                    }

                    for (int i = 0; i < flows; ++i) {
                        foreach (V9TemplateField field in template.GetFields()) {
                            pU = (ushort*)pb;
                            pUI = (uint*)pb;
                            switch (field.Type) {
                                case (ushort)flowsimulator.FormV9Template.TemplateType.IN_BYTES:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.OUT_BYTES:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.MUL_DST_BYTES:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.TOTAL_BYTES_EXP:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.IN_PERMANENT_BYTES:
                                    *pUI = options.NextBytes;
                                    pb += 4;
                                    break;
                                case (ushort)flowsimulator.FormV9Template.TemplateType.OUT_PKTS:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.IN_PKTS:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.MUL_DST_PKTS:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.TOTAL_PKTS_EXP:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.IN_PERMANENT_PKTS:
                                    *pUI = options.NextPackets;
                                    pb += 4;
                                    break;
                                case (ushort)flowsimulator.FormV9Template.TemplateType.IPV4_SRC_ADDR:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.IPV4_SRC_PREFIX:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.BGP_IPV4_NEXT_HOP:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.IPV4_NEXT_HOP:
                                    *pUI = options.NextSrcAddress;
                                    pb += 4;
                                    break;
                                case (ushort)flowsimulator.FormV9Template.TemplateType.IPV4_DST_ADDR:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.IPV4_DST_PREFIX:
                                    *pUI = options.NextDstAddress;
                                    pb += 4;
                                    break;
                                case (ushort)flowsimulator.FormV9Template.TemplateType.INPUT_SNMP:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.OUTPUT_SNMP:
                                    *pU = options.NextInterface;
                                    pb += 2;
                                    break;
                                case (ushort)flowsimulator.FormV9Template.TemplateType.L4_SRC_PORT:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.L4_DST_PORT:
                                    *pU = options.NextPort;
                                    pb += 2;
                                    break;
                                case (ushort)flowsimulator.FormV9Template.TemplateType.SRC_AS:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.DST_AS:
                                    *pUI = options.NextAS;
                                    pb += 2;
                                    break;
                                case (ushort)flowsimulator.FormV9Template.TemplateType.PROTOCOL:
                                    *pb = options.NextProtocol;
                                    pb++;
                                    break;
                                case (ushort)flowsimulator.FormV9Template.TemplateType.DST_TOS:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.SRC_TOS:
                                    *pb = options.NextTOS;
                                    pb++;
                                    break;
                                case (ushort)flowsimulator.FormV9Template.TemplateType.DST_MASK:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.SRC_MASK:
                                    *pb = options.NextMask;
                                    pb++;
                                    break;
                                case (ushort)flowsimulator.FormV9Template.TemplateType.FLOWS:
                                case (ushort)flowsimulator.FormV9Template.TemplateType.TOTAL_FLOWS_EXP:
                                    *pUI = options.NextFlows;
                                    pb += 4;
                                    break;
                                case (ushort)flowsimulator.FormV9Template.TemplateType.TCP_FLAGS:
                                    *pUI = options.NextTcpFlag;
                                    pb++;
                                    break;
                                default: // advance pointer
                                    pb += field.Length;
                                    break;

                            }
                        }
                    }
                } // end of fixed
            } // end of unsafe
            return packet_size;
        }

    }

    public class Ipfix : Netflow {
        private IpfixMessageHeader ipfixheader;
        private ArrayList templates;
        private int currentTemplateIndex = 0;

        private bool sendTemplate = false;

        public Ipfix(ushort version
            , uint sysuptime
            , uint id
            , uint initial_sequence)
            :
        base(0x000a, sysuptime, id, initial_sequence) {
            ipfixheader.exportTime = reverseByteOrder(sysuptime);
        }
        public ArrayList Templates {
            set {
                templates = value;
            }
        }

        public override ushort createPacket(ushort flows) {
            TimeSpan ts = DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            ipfixheader.versionNumber = reverseByteOrder(0x000a);
            ipfixheader.exportTime = reverseByteOrder((uint)ts.TotalSeconds);
            ipfixheader.sequenceNumber = reverseByteOrder(sequence);
            ipfixheader.domainId = 0;

            IpfixTemplate template = (IpfixTemplate)templates[currentTemplateIndex];

            ++currentTemplateIndex;
            if (currentTemplateIndex >= templates.Count) {
                currentTemplateIndex = 0;
            }

            if (sequence % template.SendFrequency == 0) {
                sendTemplate = true;
            } else {
                sendTemplate = false;
            }

            if (sendTemplate) {
                unsafe {
                    packet_size = (ushort)(sizeof(IpfixFlowsetHeader) + (template.PduSize * flows) + template.FlowsetLength);
                    packet_size += (ushort)sizeof(IpfixMessageHeader);
                }
            } else {
                unsafe {
                    packet_size = (ushort)(sizeof(IpfixFlowsetHeader) + (template.PduSize * flows));
                    packet_size += (ushort)sizeof(IpfixMessageHeader);
                }
            }
            ipfixheader.length = reverseByteOrder((ushort)packet_size);

            random.NextBytes(packet);

            unsafe {
                fixed (byte* pB = packet) {
                    IpfixMessageHeader* pheader = (IpfixMessageHeader*)pB;
                    *pheader = ipfixheader;

                    ushort* pU = (ushort*)(pB + sizeof(IpfixMessageHeader));
                    if (sendTemplate) {
                        // set header first
                        ushort templateId = 2;  // template type id, template is 2
                        *pU = reverseByteOrder(templateId);
                        pU++;
                        *pU = reverseByteOrder(template.FlowsetLength);
                        pU++;
                        *pU = reverseByteOrder(template.TemplateId);
                        pU++;
                        *pU = reverseByteOrder(template.FieldCount);
                        pU++;
                        // set the template set
                        ArrayList tFields = template.GetFields();
                        for (int i = 0; i < tFields.Count; ++i) {
                            IpfixTemplateField field = (IpfixTemplateField)tFields[i];
                            *pU = reverseByteOrder(field.elementId);
                            pU++;
                            *pU = reverseByteOrder(field.Length);
                            pU++;
                        }
                    }
                    // set data flow type id
                    *pU = reverseByteOrder(template.TemplateId);
                    pU++;
                    // set flowset length
                    ushort len = (ushort)(sizeof(IpfixFlowsetHeader) + (template.PduSize * flows));
                    *pU = reverseByteOrder(len);
                    pU++;

                    byte* pb = (byte*)pU;
                    uint* pUI = (uint*)pU;

                    if (options.Mode != flowsimulator.OptionsForm.RandomMode.LimitedRandom) {
                        return packet_size;
                    }

                    for (int i = 0; i < flows; ++i) {
                        foreach (IpfixTemplateField field in template.GetFields()) {
                            pU = (ushort*)pb;
                            pUI = (uint*)pb;
                            switch (field.elementId) {
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.octetDeltaCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.octetTotalCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.postOctetDeltaCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.postOctetTotalCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.postMCastOctetDeltaCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.postMCastOctetTotalCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.ignoredOctetTotalCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.exportedOctetTotalCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.octetTotalSumOfSquares:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.octetDeltaSumOfSquares:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.droppedOctetDeltaCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.droppedOctetTotalCount:
                                    *pUI = options.NextBytes;
                                    break;
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.packetDeltaCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.packetTotalCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.postPacketDeltaCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.postPacketTotalCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.postMCastPacketDeltaCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.postMCastPacketTotalCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.ignoredPacketTotalCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.droppedPacketDeltaCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.droppedPacketTotalCount:
                                    *pUI = options.NextPackets;
                                    break;
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.sourceIPv4Address:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.sourceIPv4Prefix:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.collectorIPv4Address:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.ipNextHopIPv4Address:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.exporterIPv4Address:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.mplsTopLabelIPv4Address:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.bgpNexthopIPv4Address:
                                    *pUI = options.NextSrcAddress;
                                    break;
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.destinationIPv4Address:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.destinationIPv4Prefix:
                                    *pUI = options.NextDstAddress;
                                    break;
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.ingressInterface:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.egressInterface:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.lineCardId:
                                    *pU = options.NextInterface;
                                    break;
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.sourceTransportPort:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.destinationTransportPort:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.tcpSourcePort:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.tcpDestinationPort:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.udpSourcePort:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.udpDestinationPort:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.exporterTransportPort:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.collectorTransportPort:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.wlanChannelId:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.vlanId:
                                    *pU = options.NextPort;
                                    break;
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.bgpSourceAsNumber:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.bgpDestinationAsNumber:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.bgpPrevAdjacentAsNumber:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.bgpNextAdjacentAsNumber:
                                    *pUI = options.NextAS;
                                    break;
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.protocolIdentifier:
                                    *pb = options.NextProtocol;
                                    break;
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.ipClassOfService:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.postIpClassOfService:
                                    *pb = options.NextTOS;
                                    break;
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.sourceIPv4PrefixLength:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.destinationIPv4PrefixLength:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.sourceIPv6PrefixLength:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.destinationIPv6PrefixLength:
                                    *pb = options.NextMask;
                                    break;
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.exportedFlowRecordTotalCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.exportedMessageTotalCount:
                                case (ushort)flowsimulator.FormIpfixTemplate.TemplateType.flowId:
                                    *pUI = options.NextFlows;
                                    break;
                                default: // advance pointer
                                    break;

                            }
                            pb += field.Length;
                        }
                    }
                } // end of fixed
            } // end of unsafe
            return packet_size;
        }
    }
}
