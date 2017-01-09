using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubenhak.NetflowExporter
{

    public class ExportPacket
    {
        private ushort _sequence;
        private ushort _sourceId;
        private List<TemplateData> _dataFlows = new List<TemplateData>();

        public ExportPacket(ushort sequence, ushort sourceId)
        {
            _sequence = sequence;
            _sourceId = sourceId;
        }

        public ExportPacket Template(TemplateData dataFlow)
        {
            Add(dataFlow);
            return this;
        }

        public void Add(TemplateData dataFlow)
        {
            _dataFlows.Add(dataFlow);
        }

        public void Generate(PacketGenerator packet)
        {
            var count = (ushort)_dataFlows.Sum(x => 1 + x.DataCount);
            packet.AddInt16(9); //Version
            packet.AddInt16(count); //Number of Flowsets
            packet.AddInt32(DateHelpers.GetUpTimeMS()); //sysUpTime
            packet.AddInt32(DateHelpers.GetEpoch()); // UNIX Secs
            packet.AddInt32(_sequence); // sequence number
            packet.AddInt32(_sourceId); // source id

            foreach (var dataFlow in _dataFlows)
            {
                dataFlow.Generate(packet);
            }
        }

        public byte[] GetData()
        {
            var packet = new PacketGenerator();
            Generate(packet);
            return packet.Data;
        }
    }

}
