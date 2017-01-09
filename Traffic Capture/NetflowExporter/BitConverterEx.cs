using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Rubenhak.NetflowExporter
{
    internal static class BitConverterEx
    {
        internal static byte[] ToBytes(FieldDefinition field, object value)
        {
            switch (Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.UInt32:
                    {
                        var data = BitConverter.GetBytes((UInt32)value);
                        Array.Reverse(data);
                        return data;
                    }
                case TypeCode.UInt16:
                    {
                        var data = BitConverter.GetBytes((UInt16)value);
                        Array.Reverse(data);
                        return data;
                    }
                case TypeCode.Byte:
                    {
                        var data = new byte[1];
                        data[0] = (byte)value;
                        return data;
                    }

                case TypeCode.String:
                    {
                        if (((string)value).Length > field.Size)
                        {
                            throw new ArgumentException("Provided string is too long.");
                        }
                        byte[] data = new byte[field.Size];
                        var charData = ((string)value).ToCharArray();
                        Buffer.BlockCopy(charData, 0, data, 0, Math.Min(charData.Length, data.Length));
                        return data;
                    }

                case TypeCode.Object:
                    {
                        if (value is IPAddress)
                        {
                            var data = ((IPAddress)value).GetAddressBytes();
                            return data;
                        }
                    }
                    break;
            }

            throw new ArgumentException("Invalid value provided.");
        }

    }

}
