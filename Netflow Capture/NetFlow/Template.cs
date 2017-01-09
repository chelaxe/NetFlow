using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace System.Net.NetFlow
{
    [Serializable]
	public class Template
	{
		private UInt16 _id;
		private UInt16 _count;
		private List<Field> _field;

        private Byte[] _bytes;

		public UInt16 ID
		{
			get
			{
                return this._id;
			}
		}
		public UInt16 Count
		{
			get
			{
                return this._count;
			}
		}
		public List<Field> Field
		{
			get
			{
                return this._field;
			}
		}

        public UInt16 FieldLength
        {
            get
            {
                UInt16 len = 0;
                foreach (Field fields in this._field)
                {
                    len += fields.Length;
                }
                return len;
            }
        }

        public Template(Byte[] bytes)
        {
            this._bytes = bytes;
            this.Parse();
        }

        private void Parse()
        {
            byte[] reverse = this._bytes.Reverse().ToArray();
            this._field = new List<Field>();

            this._id = BitConverter.ToUInt16(reverse, this._bytes.Length - sizeof(Int16) - 0);
            this._count = BitConverter.ToUInt16(reverse, this._bytes.Length - sizeof(Int16) - 2);

            if (this._bytes.Length == ((this._count*4)+4))
            {
                for (int i = 0, j=4; i < this._count; i++, j+=4 )
                {                    
                    Byte[] bfield = new Byte[4];
                    Array.Copy(this._bytes, j, bfield, 0, 4);
                    Field field = new Field(bfield);
                    this._field.Add(field);
                }
            }
        }
    }
}
