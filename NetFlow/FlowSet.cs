using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace System.Net.NetFlow
{
	public class FlowSet
	{
		private UInt16 _id;
		private UInt16 _length;
		private List<Template> _template;
        private List<Byte> _valuebyte;
        
        private Byte[] _bytes;

		public UInt16 ID
		{
			get
			{
                return this._id;
			}
		}
		public UInt16 Length
		{
			get
			{
                return this._length;
			}
		}
		public List<Template> Template
		{
			get
			{
                return this._template;
			}
		}

        public List<Byte> ValueByte
        {
            get
            {
                return this._valuebyte;
            }
        }

        public FlowSet(Byte[] bytes, Templates templates)
        {
            this._bytes = bytes;
            this.Parse(templates);
        }

        private void Parse(Templates templates)
        {
            byte[] reverse = this._bytes.Reverse().ToArray();
            this._template = new List<Template>();
            this._valuebyte = new List<byte>();
            
            this._id = BitConverter.ToUInt16(reverse, this._bytes.Length - sizeof(Int16) - 0);
            this._length = BitConverter.ToUInt16(reverse, this._bytes.Length - sizeof(Int16) - 2);

            if ((this._id == 0) || (this._id == 1))
            {
                if (this._id == 0)
                {
                    int cout, pastaddress, address = 6;

                    while (address < this._bytes.Length)
                    {
                        cout = BitConverter.ToUInt16(reverse, this._bytes.Length - sizeof(Int16) - address);                        

                        int length = cout * 4 + 4;
                        Byte[] btemplate = new Byte[length];
                        Array.Copy(this._bytes, address - 2, btemplate, 0, length);

                        Template template = new Template(btemplate);

                        this._template.Add(template);

                        Boolean flag = false;
                        Template[] templs = templates.Templats.ToArray();

                        for (int i = 0; i < templs.Length; i++ )
                        {
                            if (template.ID == templs[i].ID)
                            {
                                flag = true;
                                templs[i] = template;
                            }
                        }

                        if (flag)
                        {
                            templates.Templats = templs.ToList();
                        }
                        else
                        {
                            templates.Templats.Add(template);
                        }
                        
                        pastaddress = address;
                        address = cout * 4 + pastaddress + 4;
                    }
                }
            }
            else if (this._id > 255)
            {
                Boolean flag = false;
                Template templs = null;   
                    
                foreach(Template templ in templates.Templats)
                {
                    if (templ.ID == this._id) 
                    {
                        templs = DeepClone(templ) as Template;
                        flag = true;
                    }
                }

                int j = 4, z;

                if (flag)
                {

                    z = (this._length - 4) / templs.FieldLength;

                    for (int y = 0; y < z; y++)
                    {
                        foreach (Field fields in templs.Field)
                        {
                            for (int i = 0; i < fields.Length; i++, j++)
                            {
                                fields.Value.Add(this._bytes[j]);
                            }
                        }

                        this._template.Add(DeepClone(templs) as Template);

                        foreach (Field filds in templs.Field)
                        {
                            filds.Value.Clear();
                        }
                    }
                }

                if (!flag)
                {
                    for (int i = 4; i < this._bytes.Length; i++)
                    {
                        this._valuebyte.Add(this._bytes[i]);
                    }
                }            
            }
        }

        public static object DeepClone(object obj)
        {
            object objResult = null;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }
            return objResult;
        }
    }
}
