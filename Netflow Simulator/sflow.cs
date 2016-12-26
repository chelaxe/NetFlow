using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace flowsimulator {
    /*
    struct sFlowV4Header {
        public uint agentAddress;
        public uint sequenceNumber;
        public uint sysUpTime;
    };
    */

    enum AddressType : uint {
        IP_V4 = 1,
        IP_V6 = 2
    };

    struct sFlowV5Header {
        public uint version;
        public uint addressType;
        public uint agentAddress;
        public uint subagentId;
        public uint sequenceNumber;
        public uint sysUpTime;
        public uint numSamples;
    };
    enum SampleType : byte {
        FlowSample = 1,
        CounterSample = 2,
    };

    struct V5CounterSampleHeader {
        public uint counterType;
        public uint sampleLength;
        public uint sequenceNumber;
        public uint sourceId;
        public uint numRecords;
    };
    /*
    struct V4CounterSampleHeader {
        public uint sequenceNumber;
        public uint sourceId;
        public uint samplingInterval;

    };
    */

    enum CounterVersion : ushort {
        GenericCounter = 1,
        EthernetCounter,
        TokenringCounter,
        FDDICounter,
        VGCounter,
        WANCounter,
        VlanCounter
    };
    struct Counter_Header {
        public uint sampleType;
        public uint counterLength;
    };

    struct Generic_Counter {
        public uint ifIndex;
        public uint ifType;
        public UInt64 ifSpeed;
        public uint ifDirection;    /* derived from MAU MIB (RFC 2668)
                                       0 = unknown, 1=full-duplex,
                                       2=half-duplex, 3 = in, 4=out */
        public uint ifStatus;       /* bit field with the following bits
                                       assigned
                                       bit 0 = ifAdminStatus
                                         (0 = down, 1 = up)
                                       bit 1 = ifOperStatus
                                         (0 = down, 1 = up) */
        public UInt64 ifInOctets;
        public uint ifInUcastPkts;
        public uint ifInMulticastPkts;
        public uint ifInBroadcastPkts;
        public uint ifInDiscards;
        public uint ifInErrors;
        public uint ifInUnknownProtos;
        public UInt64 ifOutOctets;
        public uint ifOutUcastPkts;
        public uint ifOutMulticastPkts;
        public uint ifOutBroadcastPkts;
        public uint ifOutDiscards;
        public uint ifOutErrors;
        public uint ifPromiscuousMode;
    };

    struct Ethernet_Counter {
        public Generic_Counter generic;
        public uint dot3StatsAlignmentErrors;
        public uint dot3StatsFCSErrors;
        public uint dot3StatsSingleCollisionFrames;
        public uint dot3StatsMultipleCollisionFrames;
        public uint dot3StatsSQETestErrors;
        public uint dot3StatsDeferredTransmissions;
        public uint dot3StatsLateCollisions;
        public uint dot3StatsExcessiveCollisions;
        public uint dot3StatsInternalMacTransmitErrors;
        public uint dot3StatsCarrierSenseErrors;
        public uint dot3StatsFrameTooLongs;
        public uint dot3StatsInternalMacReceiveErrors;
        public uint dot3StatsSymbolErrors;
    };

    struct FDDI_Counter {
        public Generic_Counter generic;
    };

    struct Tokenring_Counter {
        public Generic_Counter generic;
        public uint dot5StatsLineErrors;
        public uint dot5StatsBurstErrors;
        public uint dot5StatsACErrors;
        public uint dot5StatsAbortTransErrors;
        public uint dot5StatsInternalErrors;
        public uint dot5StatsLostFrameErrors;
        public uint dot5StatsReceiveCongestions;
        public uint dot5StatsFrameCopiedErrors;
        public uint dot5StatsTokenErrors;
        public uint dot5StatsSoftErrors;
        public uint dot5StatsHardErrors;
        public uint dot5StatsSignalLoss;
        public uint dot5StatsTransmitBeacons;
        public uint dot5StatsRecoverys;
        public uint dot5StatsLobeWires;
        public uint dot5StatsRemoves;
        public uint dot5StatsSingles;
        public uint dot5StatsFreqErrors;
    };

    struct VG_Counter {
        public Generic_Counter generic;
        public uint dot12InHighPriorityFrames;
        public UInt64 dot12InHighPriorityOctets;
        public uint dot12InNormPriorityFrames;
        public UInt64 dot12InNormPriorityOctets;
        public uint dot12InIPMErrors;
        public uint dot12InOversizeFrameErrors;
        public uint dot12InDataErrors;
        public uint dot12InNullAddressedFrames;
        public uint dot12OutHighPriorityFrames;
        public UInt64 dot12OutHighPriorityOctets;
        public uint dot12TransitionIntoTrainings;
        public UInt64 dot12HCInHighPriorityOctets;
        public UInt64 dot12HCInNormPriorityOctets;
        public UInt64 dot12HCOutHighPriorityOctets;
    };

    struct WAN_Counter {
        public Generic_Counter generic;
    };

    struct Vlan_Counter {
        public uint vlan_id;
        public UInt64 octets;
        public uint ucastPkts;
        public uint multicastPkts;
        public uint broadcastPkts;
        public uint discards;
    }


    class SFlow : FlowGenerator {
        private uint sequence;
        private readonly uint sysUpTime;
        private Generic_Counter genericCounter;
        private Ethernet_Counter ethernetCounter;
        private Tokenring_Counter tokenringCounter;
        private VG_Counter vgCounter;
        private Vlan_Counter vlanCounter;
        // note fddi and wan counters are the same as generic counter

        private sFlowV5Header v5Header;
        private V5CounterSampleHeader v5SampleHeader;


        private static uint GenericCounterSize = 0;
        private static uint EthernetCounterSize = 0;
        private static uint TokenringCounterSize = 0;
        private static uint VGCounterSize = 0;
        private static uint VlanCounterSize = 0;
        private static uint V5SampleHeaderSize = 0;

        private static readonly int MAX_ERRORS = 5;
        private static readonly int MAX_PACKET_SIZE = 2048;
        private bool[] simVersions;

        private uint sequenceNumber = 0;
        // static constructor
        static SFlow() {
            unsafe {
                GenericCounterSize = (uint)sizeof(Generic_Counter);
                EthernetCounterSize = (uint)sizeof(Ethernet_Counter);
                TokenringCounterSize = (uint)sizeof(Tokenring_Counter);
                VGCounterSize = (uint)sizeof(VG_Counter);
                VlanCounterSize = (uint)sizeof(Vlan_Counter);
                V5SampleHeaderSize = (uint)sizeof(V5CounterSampleHeader);

            }
        }

        public SFlow(uint sysUptime, bool[] versions) {
            packet = new byte[MAX_PACKET_SIZE];
            this.sysUpTime = sysUptime;
            this.simVersions = versions;
            v5Header.sequenceNumber = sequenceNumber;
            genericCounter = new Generic_Counter();
            ethernetCounter = new Ethernet_Counter();
            tokenringCounter = new Tokenring_Counter();
            vgCounter = new VG_Counter();
            vlanCounter = new Vlan_Counter();
            v5Header = new sFlowV5Header();
            v5SampleHeader = new V5CounterSampleHeader();

            // initialize a part of packet header that won't change over simulation
            v5Header.version = netflow.Netflow.reverseByteOrder((uint)5);
            v5Header.addressType = netflow.Netflow.reverseByteOrder((uint)AddressType.IP_V4);

            // initialize local agent ip address
            string hostName = Dns.GetHostName();
            IPHostEntry local = Dns.GetHostEntry(hostName);
            IPAddress ip = local.AddressList[0];
            byte[] ipaddress = ip.GetAddressBytes();

            v5Header.agentAddress = BitConverter.ToUInt32(ipaddress, 0);
            v5Header.subagentId = 0;
            v5Header.sysUpTime = netflow.Netflow.reverseByteOrder(sysUpTime);
            v5SampleHeader.counterType = netflow.Netflow.reverseByteOrder((uint)SampleType.CounterSample);
        }


        public override void sendPacket() {
            System.Random r = new Random();
            ushort packet_size = 0;
            ushort samples = 0;
            for (int index = 1; index < simVersions.Length; ++index) {
                samples += (ushort) (simVersions[index] ? 1 : 0);
            }
            ShowStatusDelegate showStatus = new ShowStatusDelegate(ShowStatus);
            if (statusLine != null) {
                msg.AppendFormat("Sending packet - sFlow {0} sample", samples);
                if (!statusLine.InvokeRequired) {
                    statusLine.Text = msg.ToString();
                } else {
                    statusLine.Invoke(showStatus, new object[] { msg.ToString() });
                }
                msg.Remove(0, msg.Length);
            }
            packet_size = createPacket(samples);
            udpServer.sendPacket(ref packet, packet_size);
            ++sequence;
        }

        public override ushort createPacket(ushort samples) {
            ushort packet_size = 0;
            ++sequenceNumber;
            v5Header.sequenceNumber = netflow.Netflow.reverseByteOrder(sequenceNumber);
            v5Header.numSamples = netflow.Netflow.reverseByteOrder((uint)samples);
            v5SampleHeader.numRecords = netflow.Netflow.reverseByteOrder((uint)1);
            v5SampleHeader.sequenceNumber = v5Header.sequenceNumber;
            v5SampleHeader.sourceId = netflow.Netflow.reverseByteOrder((uint)1);
            unsafe {
                fixed (byte* pb = packet) {
                    byte* p = pb;
                    sFlowV5Header* pheader = (sFlowV5Header*)p;
                    *pheader = v5Header;
                    p += sizeof(sFlowV5Header);
                    packet_size += (ushort)(sizeof(sFlowV5Header));

                    for (int index = 1; index < simVersions.Length; ++index) {
                        if (!simVersions[index]) {
                            continue;
                        }
                        // use generic counters for now
                        // TODO: get the counters type from GUI
                        CounterVersion version = (CounterVersion)index;
                        uint counterSize = GetCounterSize(version);
                        v5SampleHeader.sampleLength = netflow.Netflow.reverseByteOrder((uint)(V5SampleHeaderSize + counterSize));
                        V5CounterSampleHeader* pCounterSample = (V5CounterSampleHeader*)p;
                        *pCounterSample = v5SampleHeader;
                        packet_size += (ushort)(sizeof(V5CounterSampleHeader));

                        createSampleCounter(version);

                        Counter_Header header = new Counter_Header();
                        header.sampleType = netflow.Netflow.reverseByteOrder((uint)version);
                        header.counterLength = netflow.Netflow.reverseByteOrder((uint)counterSize);
                        p += sizeof(V5CounterSampleHeader);
                        Counter_Header* pHeader = (Counter_Header*)p;
                        *pHeader = header;
                        p += sizeof(Counter_Header);
                        packet_size += (ushort)sizeof(Counter_Header);

                        switch (version) {
                            case CounterVersion.GenericCounter:
                            case CounterVersion.WANCounter:
                            case CounterVersion.FDDICounter:
                                Generic_Counter* pGC = (Generic_Counter*)p;
                                *pGC = genericCounter;
                                break;
                            case CounterVersion.EthernetCounter:
                                Ethernet_Counter* pEth = (Ethernet_Counter*)p;
                                *pEth = ethernetCounter;
                                break;
                            case CounterVersion.TokenringCounter:
                                Tokenring_Counter* pToken = (Tokenring_Counter*)p;
                                *pToken = tokenringCounter;
                                break;
                            case CounterVersion.VGCounter:
                                VG_Counter* pVG = (VG_Counter*)p;
                                *pVG = vgCounter;
                                break;
                            case CounterVersion.VlanCounter:
                                Vlan_Counter* pVlan = (Vlan_Counter*)p;
                                *pVlan = vlanCounter;
                                break;
                        }
                        p += counterSize;
                        packet_size += (ushort)counterSize;
                    }
                }
            }
            return packet_size;
        }
        private void createSampleCounter(CounterVersion version) {
            System.Random rand = new System.Random();
            // generic counters are always set
            UInt64 v = 100000000; // 100 MB interface speed
            byte[] bytes = BitConverter.GetBytes(v);
            Array.Reverse(bytes);
            v = BitConverter.ToUInt64(bytes, 0);

            genericCounter.ifSpeed = v; // 100 MB 
            genericCounter.ifStatus = netflow.Netflow.reverseByteOrder((uint)3); // admin & oper status = 1
            genericCounter.ifDirection = netflow.Netflow.reverseByteOrder((uint)1); // full duplex
            genericCounter.ifType = netflow.Netflow.reverseByteOrder((uint)6);
            genericCounter.ifIndex = netflow.Netflow.reverseByteOrder((uint)1);
            
            genericCounter.ifInOctets = Add64BitValues(genericCounter.ifInOctets, options.NextBytes);
            genericCounter.ifInUcastPkts = Add32BitValues(genericCounter.ifInUcastPkts, options.NextPackets);
            genericCounter.ifInMulticastPkts = Add32BitValues(genericCounter.ifInMulticastPkts, options.NextPackets);
            genericCounter.ifInBroadcastPkts = Add32BitValues(genericCounter.ifInBroadcastPkts, options.NextPackets);
            genericCounter.ifInDiscards = Add32BitValues(genericCounter.ifInDiscards, options.NextPackets);
            genericCounter.ifInErrors = 0;
            genericCounter.ifInUnknownProtos = Add32BitValues(genericCounter.ifInUnknownProtos, options.NextPackets);
            genericCounter.ifOutOctets = Add64BitValues(genericCounter.ifOutOctets, options.NextBytes);
            genericCounter.ifOutUcastPkts = Add32BitValues(genericCounter.ifOutUcastPkts, options.NextPackets);
            genericCounter.ifOutMulticastPkts = Add32BitValues(genericCounter.ifOutMulticastPkts, options.NextPackets);
            genericCounter.ifOutBroadcastPkts = Add32BitValues(genericCounter.ifOutBroadcastPkts, options.NextPackets);
            genericCounter.ifOutDiscards = Add32BitValues(genericCounter.ifOutDiscards, options.NextPackets);
            genericCounter.ifOutErrors = 0;
            genericCounter.ifPromiscuousMode = 0;
            if (version == CounterVersion.GenericCounter
                || version == CounterVersion.WANCounter
                || version == CounterVersion.FDDICounter) {
               return;
            }
            if (version == CounterVersion.EthernetCounter) {
                ethernetCounter.generic = genericCounter;
                ethernetCounter.dot3StatsAlignmentErrors = Add32BitValues(ethernetCounter.dot3StatsAlignmentErrors,NextError(rand));
                ethernetCounter.dot3StatsCarrierSenseErrors =Add32BitValues(ethernetCounter.dot3StatsCarrierSenseErrors,NextError(rand));
                ethernetCounter.dot3StatsDeferredTransmissions =Add32BitValues(ethernetCounter.dot3StatsDeferredTransmissions,NextError(rand));
                ethernetCounter.dot3StatsExcessiveCollisions =Add32BitValues(ethernetCounter.dot3StatsExcessiveCollisions,NextError(rand));
                ethernetCounter.dot3StatsFCSErrors =Add32BitValues(ethernetCounter.dot3StatsFCSErrors,NextError(rand));
                ethernetCounter.dot3StatsFrameTooLongs = Add32BitValues(ethernetCounter.dot3StatsFrameTooLongs, NextError(rand));
                ethernetCounter.dot3StatsInternalMacReceiveErrors = Add32BitValues(ethernetCounter.dot3StatsInternalMacReceiveErrors, NextError(rand));
                ethernetCounter.dot3StatsInternalMacTransmitErrors = Add32BitValues(ethernetCounter.dot3StatsInternalMacTransmitErrors, NextError(rand));
                ethernetCounter.dot3StatsLateCollisions = Add32BitValues(ethernetCounter.dot3StatsLateCollisions, NextError(rand));
                ethernetCounter.dot3StatsMultipleCollisionFrames = Add32BitValues(ethernetCounter.dot3StatsMultipleCollisionFrames, NextError(rand));
                ethernetCounter.dot3StatsSingleCollisionFrames = Add32BitValues(ethernetCounter.dot3StatsSingleCollisionFrames, NextError(rand));
                ethernetCounter.dot3StatsSQETestErrors = Add32BitValues(ethernetCounter.dot3StatsSQETestErrors, NextError(rand));
                ethernetCounter.dot3StatsSymbolErrors = Add32BitValues(ethernetCounter.dot3StatsSymbolErrors, NextError(rand));
            } else if (version == CounterVersion.VGCounter) {
                vgCounter.generic = genericCounter;
                vgCounter.dot12HCInHighPriorityOctets = Add64BitValues(vgCounter.dot12HCInHighPriorityOctets, options.NextBytes);
                vgCounter.dot12HCInNormPriorityOctets = Add64BitValues(vgCounter.dot12HCInNormPriorityOctets, options.NextBytes);
                vgCounter.dot12HCOutHighPriorityOctets = Add64BitValues(vgCounter.dot12HCOutHighPriorityOctets, options.NextBytes);
                vgCounter.dot12InDataErrors = Add32BitValues(vgCounter.dot12InDataErrors, NextError(rand));
                vgCounter.dot12InHighPriorityFrames = Add32BitValues(vgCounter.dot12InHighPriorityFrames, options.NextPackets);
                vgCounter.dot12InHighPriorityOctets = Add64BitValues(vgCounter.dot12InHighPriorityOctets, options.NextBytes);
                vgCounter.dot12InIPMErrors = Add32BitValues(vgCounter.dot12InIPMErrors, NextError(rand));
                vgCounter.dot12InNormPriorityFrames = Add32BitValues(vgCounter.dot12InNormPriorityFrames,options.NextPackets);
                vgCounter.dot12InNormPriorityOctets = Add64BitValues(vgCounter.dot12InNormPriorityOctets, options.NextBytes);
                vgCounter.dot12InNullAddressedFrames = Add32BitValues(vgCounter.dot12InNullAddressedFrames, options.NextPackets);
                vgCounter.dot12InOversizeFrameErrors = Add32BitValues(vgCounter.dot12InOversizeFrameErrors, NextError(rand));
                vgCounter.dot12OutHighPriorityFrames = Add32BitValues(vgCounter.dot12OutHighPriorityFrames, options.NextPackets);
                vgCounter.dot12OutHighPriorityOctets = Add64BitValues(vgCounter.dot12OutHighPriorityOctets, options.NextBytes);
                vgCounter.dot12TransitionIntoTrainings = Add32BitValues(vgCounter.dot12TransitionIntoTrainings, options.NextPackets);
            } else if (version == CounterVersion.TokenringCounter) {
                tokenringCounter.generic = genericCounter;
                tokenringCounter.dot5StatsAbortTransErrors = Add32BitValues(tokenringCounter.dot5StatsAbortTransErrors, NextError(rand));
                tokenringCounter.dot5StatsACErrors = Add32BitValues(tokenringCounter.dot5StatsACErrors, NextError(rand));
                tokenringCounter.dot5StatsBurstErrors = Add32BitValues(tokenringCounter.dot5StatsBurstErrors, NextError(rand));
                tokenringCounter.dot5StatsFrameCopiedErrors = Add32BitValues(tokenringCounter.dot5StatsFrameCopiedErrors, NextError(rand));
                tokenringCounter.dot5StatsFreqErrors = Add32BitValues(tokenringCounter.dot5StatsFreqErrors, NextError(rand));
                tokenringCounter.dot5StatsHardErrors = Add32BitValues(tokenringCounter.dot5StatsHardErrors, NextError(rand));
                tokenringCounter.dot5StatsInternalErrors = Add32BitValues(tokenringCounter.dot5StatsInternalErrors, NextError(rand));
                tokenringCounter.dot5StatsLineErrors = Add32BitValues(tokenringCounter.dot5StatsLineErrors, NextError(rand));
                tokenringCounter.dot5StatsLobeWires = Add32BitValues(tokenringCounter.dot5StatsLobeWires, NextError(rand));
                tokenringCounter.dot5StatsLostFrameErrors = Add32BitValues(tokenringCounter.dot5StatsLostFrameErrors, NextError(rand));
                tokenringCounter.dot5StatsReceiveCongestions = Add32BitValues(tokenringCounter.dot5StatsReceiveCongestions, NextError(rand));
                tokenringCounter.dot5StatsRecoverys = Add32BitValues(tokenringCounter.dot5StatsRecoverys, NextError(rand));
                tokenringCounter.dot5StatsRemoves = Add32BitValues(tokenringCounter.dot5StatsRemoves, NextError(rand));
                tokenringCounter.dot5StatsSignalLoss = Add32BitValues(tokenringCounter.dot5StatsSignalLoss, NextError(rand));
                tokenringCounter.dot5StatsSingles = Add32BitValues(tokenringCounter.dot5StatsSingles, NextError(rand));
                tokenringCounter.dot5StatsSoftErrors = Add32BitValues(tokenringCounter.dot5StatsSoftErrors, NextError(rand));
                tokenringCounter.dot5StatsTokenErrors = Add32BitValues(tokenringCounter.dot5StatsTokenErrors, NextError(rand));
                tokenringCounter.dot5StatsTransmitBeacons = Add32BitValues(tokenringCounter.dot5StatsTransmitBeacons, NextError(rand));
            } else if (version == CounterVersion.VlanCounter) {
                vlanCounter.broadcastPkts = Add32BitValues(vlanCounter.broadcastPkts, options.NextPackets);
                vlanCounter.discards = Add32BitValues(vlanCounter.discards, NextError(rand));
                vlanCounter.multicastPkts = Add32BitValues(vlanCounter.multicastPkts, options.NextPackets);
                vlanCounter.octets = Add64BitValues(vlanCounter.octets, options.NextBytes);
                vlanCounter.ucastPkts = Add32BitValues(vlanCounter.ucastPkts, options.NextPackets);
                vlanCounter.vlan_id = netflow.Netflow.reverseByteOrder(1);
            }
        }
        private uint NextError(Random rand) {
            return netflow.Netflow.reverseByteOrder((uint)rand.Next(MAX_ERRORS));
        }
        private static uint GetCounterSize(CounterVersion version) {
            switch (version) {
                case CounterVersion.GenericCounter:
                case CounterVersion.FDDICounter:
                case CounterVersion.WANCounter:
                    return GenericCounterSize;
                case CounterVersion.VlanCounter:
                    return VlanCounterSize;
                case CounterVersion.EthernetCounter:
                    return EthernetCounterSize;
                case CounterVersion.TokenringCounter:
                    return TokenringCounterSize;
                case CounterVersion.VGCounter:
                    return VGCounterSize;
                default:
                    System.Diagnostics.Debug.Assert(false);
                    return 0;
            }
        }

        private static UInt64 Get64BitValue(uint value, bool reversed) {
            if (reversed) {
                byte[] bytes = BitConverter.GetBytes(value);
                Array.Reverse(bytes);
                value = BitConverter.ToUInt32(bytes, 0);
            }
            UInt64 v = value;
            byte[] bs = BitConverter.GetBytes(v);
            Array.Reverse(bs);
            v = BitConverter.ToUInt64(bs, 0);
            return v;
        }

        private static UInt64 Reverse64bitValue(UInt64 value) {
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            return BitConverter.ToUInt64(bytes, 0);
        }

        private static UInt32 Reverse32BitValue(uint value) {
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }

        private static UInt64 Add64BitValues(UInt64 existingValue, UInt32 reverseDelta) {
            UInt64 value = Reverse64bitValue(existingValue);
            uint delta = Reverse32BitValue(reverseDelta);
            value += delta;
            return Reverse64bitValue(value);
        }

        private static UInt32 Add32BitValues(UInt32 existingValue, UInt32 reverseDelta) {
            UInt32 value = Reverse32BitValue(existingValue);
            uint delta = Reverse32BitValue(reverseDelta);
            value += delta;
            return Reverse32BitValue(value);
        }
    }
}
