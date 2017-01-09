using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubenhak.NetflowExporter
{
    public class DataFlow
    {
        private TemplateFlow _template;
        private List<object> _values;
        private List<byte[]> _dataValues = new List<byte[]>();
        private ushort _dataLength = 0;
        private ushort _paddingLength = 0;

        public DataFlow(TemplateFlow template, params object[] values)
        {
            _template = template;
            _values = values.ToList();

            if (_values.Count != template.FieldCount)
                throw new ArgumentException(string.Format("Incorrect number of data values provided. Expected {0}. Provided {1}.", _template.FieldCount, _values.Count));

            for (int i = 0; i < _values.Count; i++)
            {
                var data = BitConverterEx.ToBytes(_template[i], _values[i]);
                _dataValues.Add(data);
                _dataLength = (ushort)(_dataLength + data.Length);
            }

            if (_dataLength % 4 != 0)
            {
                _paddingLength = (ushort)(4 - _dataLength % 4);
                _dataLength = (ushort)(_dataLength + _paddingLength);
            }
        }

        public void Generate(PacketGenerator packet)
        {
            packet.AddInt16(_template.ID);                  // FlowsetID
            packet.AddInt16((ushort)(2 + 2 + _dataLength)); // Length

            foreach (var data in _dataValues)
            {
                packet.Add(data);
            }

            if (_paddingLength != 0)
            {
                var padding = new byte[_paddingLength];
                packet.Add(padding);
            }
        }
    }

}
