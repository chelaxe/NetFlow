using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubenhak.NetflowExporter
{
    public class TemplateData
    {
        private TemplateFlow _template;
        private List<DataFlow> _data = new List<DataFlow>();

        public TemplateData(TemplateFlow template)
        {
            _template = template;
        }


        public ushort DataCount
        {
            get
            {
                return (ushort)_data.Count;
            }
        }

        public void AddData(params object[] values)
        {
            _data.Add(new DataFlow(_template, values));
        }

        public TemplateData Data(params object[] values)
        {
            this.AddData(values);
            return this;
        }

        public void Generate(PacketGenerator packet)
        {
            _template.Generate(packet);
            foreach (var data in _data)
            {
                data.Generate(packet);
            }
        }
    }

}
