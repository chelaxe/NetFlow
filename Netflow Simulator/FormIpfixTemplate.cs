using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace flowsimulator {
    public partial class FormIpfixTemplate : Form {
        private FormIpfixTemplateList parent = null;

        public FormIpfixTemplate(FormIpfixTemplateList p) {
            InitializeComponent();
            for (int i = 1; i < TemplateItem.Length; ++i) {
                if (TemplateItem[i] != "RESERVED") {
                    listBoxAll.Items.Add(TemplateItem[i]);
                }
            }
            this.parent = p;
            ushort nextId = 256;
            foreach (netflow.IpfixTemplate t in parent.TemplateList) {
                if (t.TemplateId >= nextId) {
                    ++nextId;
                }
            }
            textBoxTemplateId.Text = nextId.ToString();
            btnAdd.Enabled = false;
        }
        public static string[] TemplateItem = {
				"UNKNOWN",              // 0
				"octetDeltaCount",      // 1
				"packetDeltaCount",     
				"RESERVED",             
				"protocolIdentifier",   
				"ipClassOfService",	    // 5
				"tcpControlBits",       
				"sourceTransportPort",  
				"sourceIPv4Address",
				"sourceIPv4PrefixLength",
				"ingressInterface",         // 10
				"destinationTransportPort",
				"destinationIPv4Address",
				"destinationIPv4PrefixLength",
				"egressInterface",
				"ipNextHopIPv4Address",     // 15
				"bgpSourceAsNumber",
				"bgpDestinationAsNumber",
				"bgpNexthopIPv4Address",
				"postMCastPacketDeltaCount",
				"postMCastOctetDeltaCount", //20
				"flowEndSysUpTime",
				"flowStartSysUpTime",
				"postOctetDeltaCount",
				"postPacketDeltaCount",
				"minimumIpTotalLength",     // 25
				"maximumIpTotalLength",
				"sourceIPv6Address",
				"destinationIPv6Address",
				"sourceIPv6PrefixLength",
				"destinationIPv6PrefixLength",  // 30
				"flowLabelIPv6",
				"icmpTypeCodeIPv4",
				"igmpType",
				"RESERVED",
				"RESERVED",     // 35
				"flowActiveTimeout",
				"flowIdleTimeout",
				"RESERVED",
				"RESERVED",
				"exportedOctetTotalCount",  // 40
				"exportedMessageTotalCount",
				"exportedFlowRecordTotalCount",
				"RESERVED",
				"sourceIPv4Prefix",
				"destinationIPv4Prefix",    // 45
				"mplsTopLabelType",
				"mplsTopLabelIPv4Address",
				"RESERVED",
                "RESERVED",
                "RESERVED",         // 50
                "RESERVED",
				"minimumTTL",
				"maximumTTL",
				"fragmentIdentification",
				"postIpClassOfService", //55
				"sourceMacAddress",
				"postDestinationMacAddress",
				"vlanId",
				"postVlanId",
				"ipVersion",        // 60
				"flowDirection",
				"ipNextHopIPv6Address",
				"bgpNexthopIPv6Address",
				"ipv6ExtensionHeaders",
				"RESERVED",         // 65
				"RESERVED",
				"RESERVED",
				"RESERVED",
				"RESERVED",
				"mplsTopLabelStackSection", // 70
				"mplsLabelStackSection2",
				"mplsLabelStackSection3",
				"mplsLabelStackSection4",
				"mplsLabelStackSection5",
				"mplsLabelStackSection6",   // 75
				"mplsLabelStackSection7",
				"mplsLabelStackSection8",
				"mplsLabelStackSection9",
				"mplsLabelStackSection10",
				"destinationMacAddress",    // 80
				"postSourceMacAddress",
				"RESERVED",
				"RESERVED",
				"RESERVED",
				"octetTotalCount",      // 85
				"packetTotalCount",
				"RESERVED",
				"fragmentOffset",
				"RESERVED",
                "mplsVpnRouteDistinguisher", // 90
                "RESERVED",
                "RESERVED",
                "RESERVED",
                "RESERVED",
                "RESERVED",     // 95
                "RESERVED",
                "RESERVED",
                "RESERVED",
                "RESERVED",
                "RESERVED",     // 100
                "RESERVED",
                "RESERVED",
                "RESERVED",
                "RESERVED",
                "RESERVED",     // 105
                "RESERVED",
                "RESERVED",
                "RESERVED",
                "RESERVED",
                "RESERVED",     // 110
                "RESERVED",
                "RESERVED",
                "RESERVED",
                "RESERVED",
                "RESERVED",     // 115
                "RESERVED",
                "RESERVED",
                "RESERVED",
                "RESERVED",
                "RESERVED",     // 120
                "RESERVED",
                "RESERVED",
                "RESERVED",
                "RESERVED",
                "RESERVED",     // 125
                "RESERVED",
                "RESERVED",
                "bgpNextAdjacentAsNumber",  // 128
                "bgpPrevAdjacentAsNumber",
                "exporterIPv4Address",      // 130
                "exporterIPv6Address",
                "droppedOctetDeltaCount",
                "droppedPacketDeltaCount",
                "droppedOctetTotalCount",
                "droppedPacketTotalCount",  // 135
                "flowEndReason",
                "commonPropertiesId",
                "observationPointId",
                "icmpTypeCodeIPv6",
                "mplsTopLabelIPv6Address",  // 140
                "lineCardId",
                "portId",
                "meteringProcessId",
                "exportingProcessId",
                "templateId",           // 145
                "wlanChannelId",
                "wlanSSID",
                "flowId",
                "observationDomainId",
                "flowStartSeconds",     // 150
                "flowEndSeconds",
                "flowStartMilliseconds",
                "flowEndMilliseconds",
                "flowStartMicroseconds",
                "flowEndMicroseconds",      // 155
                "flowStartNanoseconds",
                "flowEndNanoseconds",
                "flowStartDeltaMicroseconds",
                "flowEndDeltaMicroseconds",
                "systemInitTimeMilliseconds",   // 160
                "flowDurationMilliseconds",
                "flowDurationMicroseconds",
                "observedFlowTotalCount",
                "ignoredPacketTotalCount",
                "ignoredOctetTotalCount",       // 165
                "notSentFlowTotalCount",
                "notSentPacketTotalCount",
                "notSentOctetTotalCount",
                "destinationIPv6Prefix",
                "sourceIPv6Prefix",             // 170
                "postOctetTotalCount",
                "postPacketTotalCount",
                "flowKeyIndicator",
                "postMCastPacketTotalCount",
                "postMCastOctetTotalCount",     // 175
                "icmpTypeIPv4",
                "icmpCodeIPv4",
                "icmpTypeIPv6",
                "icmpCodeIPv6",
                "udpSourcePort",                // 180
                "udpDestinationPort",
                "tcpSourcePort",
                "tcpDestinationPort",
                "tcpSequenceNumber",
                "tcpAcknowledgementNumber",     // 185
                "tcpWindowSize",
                "tcpUrgentPointer",
                "tcpHeaderLength",
                "ipHeaderLength",
                "totalLengthIPv4",          //190
                "payloadLengthIPv6",
                "ipTTL",
                "nextHeaderIPv6",
                "mplsPayloadLength",
                "ipDiffServCodePoint",      //195
                "ipPrecedence",
                "fragmentFlags",
                "octetDeltaSumOfSquares",
                "octetTotalSumOfSquares",
                "mplsTopLabelTTL",          //200
                "mplsLabelStackLength",
                "mplsLabelStackDepth",
                "mplsTopLabelExp",
                "ipPayloadLength",
                "udpMessageLength",         // 205
                "isMulticast",
                "ipv4IHL",
                "ipv4Options",
                "tcpOptions",
                "paddingOctets",            // 210
                "collectorIPv4Address",
                "collectorIPv6Address",
                "exportInterface",
                "exportProtocolVersion",
                "exportTransportProtocol",  // 215
                "collectorTransportPort",
                "exporterTransportPort",
                "tcpSynTotalCount",
                "tcpFinTotalCount",
                "tcpRstTotalCount",         // 220
                "tcpPshTotalCount",
                "tcpAckTotalCount",
                "tcpUrgTotalCount",
                "ipTotalLength",            // 224
                "postMplsTopLabelExp",      // 237
                "tcpWindowScale"       // 238
			};

        public enum TemplateType : ushort {
            UNKNOWN,              // 0
            octetDeltaCount,      // 1
            packetDeltaCount,
            RESERVED3,
            protocolIdentifier,
            ipClassOfService,	    // 5
            tcpControlBits,
            sourceTransportPort,
            sourceIPv4Address,
            sourceIPv4PrefixLength,
            ingressInterface,         // 10
            destinationTransportPort,
            destinationIPv4Address,
            destinationIPv4PrefixLength,
            egressInterface,
            ipNextHopIPv4Address,     // 15
            bgpSourceAsNumber,
            bgpDestinationAsNumber,
            bgpNexthopIPv4Address,
            postMCastPacketDeltaCount,
            postMCastOctetDeltaCount, //20
            flowEndSysUpTime,
            flowStartSysUpTime,
            postOctetDeltaCount,
            postPacketDeltaCount,
            minimumIpTotalLength,     // 25
            maximumIpTotalLength,
            sourceIPv6Address,
            destinationIPv6Address,
            sourceIPv6PrefixLength,
            destinationIPv6PrefixLength,  // 30
            flowLabelIPv6,
            icmpTypeCodeIPv4,
            igmpType,
            RESERVED34,
            RESERVED35,     // 35
            flowActiveTimeout,
            flowIdleTimeout,
            RESERVED38,
            RESERVED39,
            exportedOctetTotalCount,  // 40
            exportedMessageTotalCount,
            exportedFlowRecordTotalCount,
            RESERVED43,
            sourceIPv4Prefix,
            destinationIPv4Prefix,    // 45
            mplsTopLabelType,
            mplsTopLabelIPv4Address,
            RESERVED48,
            RESERVED49,
            RESERVED50,         // 50
            RESERVED51,
            minimumTTL,
            maximumTTL,
            fragmentIdentification,
            postIpClassOfService, //55
            sourceMacAddress,
            postDestinationMacAddress,
            vlanId,
            postVlanId,
            ipVersion,        // 60
            flowDirection,
            ipNextHopIPv6Address,
            bgpNexthopIPv6Address,
            ipv6ExtensionHeaders,
            RESERVED65,         // 65
            RESERVED66,
            RESERVED67,
            RESERVED68,
            RESERVED69,
            mplsTopLabelStackSection, // 70
            mplsLabelStackSection2,
            mplsLabelStackSection3,
            mplsLabelStackSection4,
            mplsLabelStackSection5,
            mplsLabelStackSection6,   // 75
            mplsLabelStackSection7,
            mplsLabelStackSection8,
            mplsLabelStackSection9,
            mplsLabelStackSection10,
            destinationMacAddress,    // 80
            postSourceMacAddress,
            RESERVED82,
            RESERVED83,
            RESERVED84,
            octetTotalCount,      // 85
            packetTotalCount,
            RESERVED87,
            fragmentOffset,
            RESERVED89,
            mplsVpnRouteDistinguisher, // 90
            RESERVED91,
            RESERVED92,
            RESERVED93,
            RESERVED94,
            RESERVED95,     // 95
            RESERVED96,
            RESERVED97,
            RESERVED98,
            RESERVED99,
            RESERVED100,     // 100
            RESERVED101,
            RESERVED102,
            RESERVED103,
            RESERVED104,
            RESERVED105,     // 105
            RESERVED106,
            RESERVED107,
            RESERVED108,
            RESERVED109,
            RESERVED110,     // 110
            RESERVED111,
            RESERVED112,
            RESERVED113,
            RESERVED114,
            RESERVED115,     // 115
            RESERVED116,
            RESERVED117,
            RESERVED118,
            RESERVED119,
            RESERVED120,     // 120
            RESERVED121,
            RESERVED122,
            RESERVED123,
            RESERVED124,
            RESERVED125,     // 125
            RESERVED126,
            RESERVED127,
            bgpNextAdjacentAsNumber,  // 128
            bgpPrevAdjacentAsNumber,
            exporterIPv4Address,      // 130
            exporterIPv6Address,
            droppedOctetDeltaCount,
            droppedPacketDeltaCount,
            droppedOctetTotalCount,
            droppedPacketTotalCount,  // 135
            flowEndReason,
            commonPropertiesId,
            observationPointId,
            icmpTypeCodeIPv6,
            mplsTopLabelIPv6Address,  // 140
            lineCardId,
            portId,
            meteringProcessId,
            exportingProcessId,
            templateId,           // 145
            wlanChannelId,
            wlanSSID,
            flowId,
            observationDomainId,
            flowStartSeconds,     // 150
            flowEndSeconds,
            flowStartMilliseconds,
            flowEndMilliseconds,
            flowStartMicroseconds,
            flowEndMicroseconds,      // 155
            flowStartNanoseconds,
            flowEndNanoseconds,
            flowStartDeltaMicroseconds,
            flowEndDeltaMicroseconds,
            systemInitTimeMilliseconds,   // 160
            flowDurationMilliseconds,
            flowDurationMicroseconds,
            observedFlowTotalCount,
            ignoredPacketTotalCount,
            ignoredOctetTotalCount,       // 165
            notSentFlowTotalCount,
            notSentPacketTotalCount,
            notSentOctetTotalCount,
            destinationIPv6Prefix,
            sourceIPv6Prefix,             // 170
            postOctetTotalCount,
            postPacketTotalCount,
            flowKeyIndicator,
            postMCastPacketTotalCount,
            postMCastOctetTotalCount,     // 175
            icmpTypeIPv4,
            icmpCodeIPv4,
            icmpTypeIPv6,
            icmpCodeIPv6,
            udpSourcePort,                // 180
            udpDestinationPort,
            tcpSourcePort,
            tcpDestinationPort,
            tcpSequenceNumber,
            tcpAcknowledgementNumber,     // 185
            tcpWindowSize,
            tcpUrgentPointer,
            tcpHeaderLength,
            ipHeaderLength,
            totalLengthIPv4,          //190
            payloadLengthIPv6,
            ipTTL,
            nextHeaderIPv6,
            mplsPayloadLength,
            ipDiffServCodePoint,      //195
            ipPrecedence,
            fragmentFlags,
            octetDeltaSumOfSquares,
            octetTotalSumOfSquares,
            mplsTopLabelTTL,          //200
            mplsLabelStackLength,
            mplsLabelStackDepth,
            mplsTopLabelExp,
            ipPayloadLength,
            udpMessageLength,         // 205
            isMulticast,
            ipv4IHL,
            ipv4Options,
            tcpOptions,
            paddingOctets,            // 210
            collectorIPv4Address,
            collectorIPv6Address,
            exportInterface,
            exportProtocolVersion,
            exportTransportProtocol,  // 215
            collectorTransportPort,
            exporterTransportPort,
            tcpSynTotalCount,
            tcpFinTotalCount,
            tcpRstTotalCount,         // 220
            tcpPshTotalCount,
            tcpAckTotalCount,
            tcpUrgTotalCount,
            ipTotalLength,            // 224
            postMplsTopLabelExp,      // 237
            tcpWindowScale       // 238
        }

        static ushort[,] TemplateItemSize = 
		{
			{(ushort)TemplateType.UNKNOWN, 0},
			{(ushort)TemplateType.octetDeltaCount, 4},
			{(ushort)TemplateType.packetDeltaCount, 4},
			{(ushort)TemplateType.RESERVED3, 0},
			{(ushort)TemplateType.protocolIdentifier, 1},
			{(ushort)TemplateType.ipClassOfService, 1},	
			{(ushort)TemplateType.tcpControlBits, 1},
			{(ushort)TemplateType.sourceTransportPort, 2},
			{(ushort)TemplateType.sourceIPv4Address, 4},
			{(ushort)TemplateType.sourceIPv4PrefixLength, 1},
			{(ushort)TemplateType.ingressInterface, 2},
			{(ushort)TemplateType.destinationTransportPort, 2},
			{(ushort)TemplateType.destinationIPv4Address, 4},
			{(ushort)TemplateType.destinationIPv4PrefixLength, 1},
			{(ushort)TemplateType.egressInterface, 2},
			{(ushort)TemplateType.ipNextHopIPv4Address, 4},
			{(ushort)TemplateType.bgpSourceAsNumber, 2},
			{(ushort)TemplateType.bgpDestinationAsNumber, 2},
			{(ushort)TemplateType.bgpNexthopIPv4Address, 4},
			{(ushort)TemplateType.postMCastPacketDeltaCount, 4},
			{(ushort)TemplateType.postMCastOctetDeltaCount, 4},
			{(ushort)TemplateType.flowEndSysUpTime, 4},
			{(ushort)TemplateType.flowStartSysUpTime, 4},
			{(ushort)TemplateType.postOctetDeltaCount, 4},
			{(ushort)TemplateType.postPacketDeltaCount, 4},
			{(ushort)TemplateType.minimumIpTotalLength, 2},
			{(ushort)TemplateType.maximumIpTotalLength, 2},
			{(ushort)TemplateType.sourceIPv6Address, 16},
			{(ushort)TemplateType.destinationIPv6Address, 16},
			{(ushort)TemplateType.sourceIPv6PrefixLength, 1},
			{(ushort)TemplateType.destinationIPv6PrefixLength, 1},
			{(ushort)TemplateType.flowLabelIPv6, 3},
			{(ushort)TemplateType.icmpTypeCodeIPv4, 2},
			{(ushort)TemplateType.igmpType, 1},
			{(ushort)TemplateType.RESERVED34, 0},
			{(ushort)TemplateType.RESERVED35, 0},
			{(ushort)TemplateType.flowActiveTimeout, 2},
			{(ushort)TemplateType.flowIdleTimeout, 2},
			{(ushort)TemplateType.RESERVED38, 0},
			{(ushort)TemplateType.RESERVED39, 0},
			{(ushort)TemplateType.exportedOctetTotalCount, 4},
			{(ushort)TemplateType.exportedMessageTotalCount, 4},
			{(ushort)TemplateType.exportedFlowRecordTotalCount, 4},
			{(ushort)TemplateType.RESERVED43, 0},
			{(ushort)TemplateType.sourceIPv4Prefix, 4},
			{(ushort)TemplateType.destinationIPv4Prefix, 4},
			{(ushort)TemplateType.mplsTopLabelType, 1},
			{(ushort)TemplateType.mplsTopLabelIPv4Address, 4},
			{(ushort)TemplateType.RESERVED48, 0},
			{(ushort)TemplateType.RESERVED49, 0},
			{(ushort)TemplateType.RESERVED50, 0},
			{(ushort)TemplateType.RESERVED51, 0},
			{(ushort)TemplateType.minimumTTL, 1},
			{(ushort)TemplateType.maximumTTL, 1},
			{(ushort)TemplateType.fragmentIdentification, 2},
			{(ushort)TemplateType.postIpClassOfService, 1},
			{(ushort)TemplateType.sourceMacAddress, 6},
			{(ushort)TemplateType.postDestinationMacAddress, 6},
			{(ushort)TemplateType.vlanId, 2},
			{(ushort)TemplateType.postVlanId, 2},
			{(ushort)TemplateType.ipVersion, 1},
			{(ushort)TemplateType.flowDirection, 1},
			{(ushort)TemplateType.ipNextHopIPv6Address, 16},
			{(ushort)TemplateType.bgpNexthopIPv6Address, 16},
			{(ushort)TemplateType.ipv6ExtensionHeaders, 4},
			{(ushort)TemplateType.RESERVED65, 0},
			{(ushort)TemplateType.RESERVED65, 0},
			{(ushort)TemplateType.RESERVED65, 0},
			{(ushort)TemplateType.RESERVED65, 0},
			{(ushort)TemplateType.RESERVED65, 0},
			{(ushort)TemplateType.mplsTopLabelStackSection, 3},
			{(ushort)TemplateType.mplsLabelStackSection2, 3},
			{(ushort)TemplateType.mplsLabelStackSection3, 3},
			{(ushort)TemplateType.mplsLabelStackSection4, 3},
			{(ushort)TemplateType.mplsLabelStackSection5, 3},
			{(ushort)TemplateType.mplsLabelStackSection6, 3},
			{(ushort)TemplateType.mplsLabelStackSection7, 3},
			{(ushort)TemplateType.mplsLabelStackSection8, 3},
			{(ushort)TemplateType.mplsLabelStackSection9, 3},
			{(ushort)TemplateType.mplsLabelStackSection10, 3},
			{(ushort)TemplateType.destinationMacAddress, 6},
			{(ushort)TemplateType.postSourceMacAddress, 6},
			{(ushort)TemplateType.RESERVED82, 0},
			{(ushort)TemplateType.RESERVED83, 0},
			{(ushort)TemplateType.RESERVED84, 0},
			{(ushort)TemplateType.octetTotalCount, 4},
			{(ushort)TemplateType.packetTotalCount, 4},
			{(ushort)TemplateType.RESERVED87, 0},
			{(ushort)TemplateType.fragmentOffset, 2},
			{(ushort)TemplateType.RESERVED89, 0},
			{(ushort)TemplateType.mplsVpnRouteDistinguisher, 8},
			{(ushort)TemplateType.RESERVED91, 0},
			{(ushort)TemplateType.RESERVED92, 0},
			{(ushort)TemplateType.RESERVED93, 0},
			{(ushort)TemplateType.RESERVED94, 0},
			{(ushort)TemplateType.RESERVED95, 0},
			{(ushort)TemplateType.RESERVED96, 0},
			{(ushort)TemplateType.RESERVED97, 0},
			{(ushort)TemplateType.RESERVED98, 0},
			{(ushort)TemplateType.RESERVED99, 0},
			{(ushort)TemplateType.RESERVED100, 0},
			{(ushort)TemplateType.RESERVED101, 0},
			{(ushort)TemplateType.RESERVED102, 0},
			{(ushort)TemplateType.RESERVED103, 0},
			{(ushort)TemplateType.RESERVED104, 0},
			{(ushort)TemplateType.RESERVED105, 0},
			{(ushort)TemplateType.RESERVED106, 0},
			{(ushort)TemplateType.RESERVED107, 0},
			{(ushort)TemplateType.RESERVED108, 0},
			{(ushort)TemplateType.RESERVED109, 0},
			{(ushort)TemplateType.RESERVED110, 0},
			{(ushort)TemplateType.RESERVED111, 0},
			{(ushort)TemplateType.RESERVED112, 0},
			{(ushort)TemplateType.RESERVED113, 0},
			{(ushort)TemplateType.RESERVED114, 0},
			{(ushort)TemplateType.RESERVED115, 0},
			{(ushort)TemplateType.RESERVED116, 0},
			{(ushort)TemplateType.RESERVED117, 0},
			{(ushort)TemplateType.RESERVED118, 0},
			{(ushort)TemplateType.RESERVED119, 0},
			{(ushort)TemplateType.RESERVED120, 0},
			{(ushort)TemplateType.RESERVED121, 0},
			{(ushort)TemplateType.RESERVED122, 0},
			{(ushort)TemplateType.RESERVED123, 0},
			{(ushort)TemplateType.RESERVED124, 0},
			{(ushort)TemplateType.RESERVED125, 0},
			{(ushort)TemplateType.RESERVED126, 0},
			{(ushort)TemplateType.RESERVED127, 0},
			{(ushort)TemplateType.bgpNextAdjacentAsNumber, 4},
			{(ushort)TemplateType.bgpPrevAdjacentAsNumber, 4},
			{(ushort)TemplateType.exporterIPv4Address, 4},
			{(ushort)TemplateType.exporterIPv6Address, 16},
			{(ushort)TemplateType.droppedOctetDeltaCount, 8},
			{(ushort)TemplateType.droppedPacketDeltaCount, 8},
			{(ushort)TemplateType.droppedOctetTotalCount, 8},
			{(ushort)TemplateType.droppedPacketTotalCount, 8},
			{(ushort)TemplateType.flowEndReason, 1},
			{(ushort)TemplateType.commonPropertiesId, 8},
			{(ushort)TemplateType.observationPointId, 4},
			{(ushort)TemplateType.icmpTypeCodeIPv6, 2},
			{(ushort)TemplateType.mplsTopLabelIPv6Address, 16},
			{(ushort)TemplateType.lineCardId, 4},
			{(ushort)TemplateType.portId, 4},
			{(ushort)TemplateType.meteringProcessId, 4},
			{(ushort)TemplateType.exportingProcessId, 4},
			{(ushort)TemplateType.templateId, 2},
			{(ushort)TemplateType.wlanChannelId, 1},
			{(ushort)TemplateType.wlanSSID, 32},
			{(ushort)TemplateType.flowId, 8},
			{(ushort)TemplateType.observationDomainId, 4},
			{(ushort)TemplateType.flowStartSeconds, 4},
			{(ushort)TemplateType.flowEndSeconds, 4},
			{(ushort)TemplateType.flowStartMilliseconds, 8},
			{(ushort)TemplateType.flowEndMilliseconds, 8},
			{(ushort)TemplateType.flowStartMicroseconds, 8},
			{(ushort)TemplateType.flowEndMicroseconds, 8},
			{(ushort)TemplateType.flowStartNanoseconds, 8},
			{(ushort)TemplateType.flowEndNanoseconds, 8},
			{(ushort)TemplateType.flowStartDeltaMicroseconds, 8},
			{(ushort)TemplateType.flowEndDeltaMicroseconds, 8},
			{(ushort)TemplateType.systemInitTimeMilliseconds, 8},
			{(ushort)TemplateType.flowDurationMilliseconds, 8},
			{(ushort)TemplateType.flowDurationMicroseconds, 8},
			{(ushort)TemplateType.observedFlowTotalCount, 8},
			{(ushort)TemplateType.ignoredPacketTotalCount, 8},
			{(ushort)TemplateType.ignoredOctetTotalCount, 8},
			{(ushort)TemplateType.notSentFlowTotalCount, 8},
			{(ushort)TemplateType.notSentPacketTotalCount, 8},
			{(ushort)TemplateType.notSentOctetTotalCount, 8},
			{(ushort)TemplateType.destinationIPv6Prefix, 16},
			{(ushort)TemplateType.sourceIPv6Prefix, 16},
			{(ushort)TemplateType.postOctetTotalCount, 8},
			{(ushort)TemplateType.postPacketTotalCount, 8},
			{(ushort)TemplateType.flowKeyIndicator, 8},
			{(ushort)TemplateType.postMCastPacketTotalCount, 8},
			{(ushort)TemplateType.postMCastOctetTotalCount, 8},
			{(ushort)TemplateType.icmpTypeIPv4, 2},
			{(ushort)TemplateType.icmpCodeIPv4, 2},
			{(ushort)TemplateType.icmpTypeIPv6, 2},
			{(ushort)TemplateType.icmpCodeIPv6, 2},
			{(ushort)TemplateType.udpSourcePort, 2},
			{(ushort)TemplateType.udpDestinationPort, 2},
			{(ushort)TemplateType.tcpSourcePort, 2},
			{(ushort)TemplateType.tcpDestinationPort, 2},
			{(ushort)TemplateType.tcpSequenceNumber, 4},
			{(ushort)TemplateType.tcpAcknowledgementNumber, 4},
			{(ushort)TemplateType.tcpWindowSize, 2},
			{(ushort)TemplateType.tcpUrgentPointer, 2},
			{(ushort)TemplateType.tcpHeaderLength, 1},
			{(ushort)TemplateType.ipHeaderLength, 1},
			{(ushort)TemplateType.totalLengthIPv4, 2},
			{(ushort)TemplateType.payloadLengthIPv6, 2},
			{(ushort)TemplateType.ipTTL, 1},
			{(ushort)TemplateType.nextHeaderIPv6, 1},
			{(ushort)TemplateType.mplsPayloadLength, 4},
			{(ushort)TemplateType.ipDiffServCodePoint, 1},
			{(ushort)TemplateType.ipPrecedence, 1},
			{(ushort)TemplateType.fragmentFlags, 1},
			{(ushort)TemplateType.octetDeltaSumOfSquares, 8},
			{(ushort)TemplateType.octetTotalSumOfSquares, 8},
			{(ushort)TemplateType.mplsTopLabelTTL, 1},
			{(ushort)TemplateType.mplsLabelStackLength, 4},
			{(ushort)TemplateType.mplsLabelStackDepth, 4},
			{(ushort)TemplateType.mplsTopLabelExp, 1},
			{(ushort)TemplateType.ipPayloadLength, 4},
			{(ushort)TemplateType.udpMessageLength, 2},
			{(ushort)TemplateType.isMulticast, 1},
			{(ushort)TemplateType.ipv4IHL, 1},
			{(ushort)TemplateType.ipv4Options, 4},
			{(ushort)TemplateType.tcpOptions, 8},
			{(ushort)TemplateType.paddingOctets, 0},
			{(ushort)TemplateType.collectorIPv4Address, 4},
			{(ushort)TemplateType.collectorIPv6Address, 16},
			{(ushort)TemplateType.exportInterface, 4},
			{(ushort)TemplateType.exportProtocolVersion, 1},
			{(ushort)TemplateType.exportTransportProtocol, 1},
			{(ushort)TemplateType.collectorTransportPort, 2},
			{(ushort)TemplateType.exporterTransportPort, 2},
			{(ushort)TemplateType.tcpSynTotalCount, 8},
			{(ushort)TemplateType.tcpFinTotalCount, 8},
			{(ushort)TemplateType.tcpRstTotalCount, 8},
			{(ushort)TemplateType.tcpPshTotalCount, 8},
			{(ushort)TemplateType.tcpAckTotalCount, 8},
			{(ushort)TemplateType.tcpUrgTotalCount, 8},
			{(ushort)TemplateType.ipTotalLength, 8},
			{(ushort)TemplateType.postMplsTopLabelExp, 1},
			{(ushort)TemplateType.tcpWindowScale, 2}
		};
        public static ushort ElementSize(ushort elementId) {
            return TemplateItemSize[elementId, 1];
        }

        private void btnMove_Click(object sender, System.EventArgs e) {
            if (listBoxAll.SelectedIndex == -1)
                return;
            String selected = (String)listBoxAll.SelectedItem;
            if (selected == "RESERVED") {
                return;
            }
            if (listBoxSelected.Items.IndexOf(listBoxAll.SelectedItem) == -1) {
                listBoxSelected.Items.Add(listBoxAll.SelectedItem);
                btnAdd.Enabled = true;
            }
        }

        private void btnRemove_Click(object sender, System.EventArgs e) {
            if (listBoxSelected.SelectedIndex == -1)
                return;
            listBoxSelected.Items.RemoveAt(listBoxSelected.SelectedIndex);
            if (listBoxSelected.Items.Count == 0) {
                btnAdd.Enabled = false;
            }
        }

        private void btnRemoveAll_Click(object sender, System.EventArgs e) {
            listBoxSelected.Items.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            ushort id;
            ushort frequency;
            try {
                id = Convert.ToUInt16(textBoxTemplateId.Text);
                frequency = Convert.ToUInt16(textBoxFrequency.Text);
                if (id < 256) {
                    MessageBox.Show(this, "Invalid Template Id");
                    textBoxTemplateId.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                foreach (netflow.IpfixTemplate t in parent.TemplateList) {
                    if (id == t.TemplateId) {
                        MessageBox.Show(this, "The specified template id is already used.");
                        textBoxTemplateId.Focus();
                        DialogResult = DialogResult.None;
                        return;
                    }
                }
                if (frequency <= 10) {
                    if (MessageBox.Show(this, "The template send frequency is too high. Are you sure you want to do this?",
                        "Confirm", MessageBoxButtons.YesNo) == DialogResult.No) {
                        textBoxFrequency.Focus();
                        return;
                    }
                }

            } catch (FormatException fe) {
                MessageBox.Show(this, fe.Message);
                textBoxTemplateId.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            netflow.IpfixTemplate template = new netflow.IpfixTemplate(id);
            template.SendFrequency = frequency;
            foreach (string item in listBoxSelected.Items) {
                ushort type = 0;
                ushort length;
                for (int i = 0; i < TemplateItem.Length; ++i) {
                    if (item == TemplateItem[i]) {
                        type = (ushort)(i);
                    }
                }
                System.Diagnostics.Debug.Assert(type > 0);

                length = TemplateItemSize[type, 1];
                template.AddField(type, length);
            }
            parent.TemplateList.Add(template);
            DialogResult = DialogResult.OK;
        }

        private void listBoxAll_DoubleClick(object sender, EventArgs e) {
            btnMove_Click(sender, e);
        }

        private void listBoxSelected_DoubleClick(object sender, EventArgs e) {
            btnRemove_Click(sender, e);
        }

    }
}
