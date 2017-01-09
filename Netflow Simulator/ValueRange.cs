using System;

namespace flowsimulator {
    /// <summary>
    /// Range specified by user for limited random generation
    /// </summary>
    public class ValueRange {
        public enum ValueMode {
            Range = 0,
            Values,
        }
        protected readonly ValueMode mode;
        protected readonly uint minValue;
        protected readonly uint maxValue;
        protected readonly uint[] vlist;
        protected static System.Random rand = new Random();

        // each value range is specified by number of bytes it contains
        protected ValueRange(int bytes, string values) {
            System.Diagnostics.Debug.Assert(bytes <= 4 && bytes >= 1);
            if (values.Trim() == "") {
                mode = ValueMode.Range;
                switch (bytes) {
                    case 1:
                        minValue = 0x0;
                        maxValue = 0xff;
                        break;
                    case 2:
                        minValue = 0x0;
                        maxValue = 0xffff;
                        break;
                    case 4:
                        minValue = 0x0;
                        maxValue = 0xffffffff;
                        break;
                }
            } else if (values.IndexOf(',') != -1 && values.IndexOf('-') == -1) {
                mode = ValueMode.Values;
                string[] tokens = values.Split(',');
                if (tokens.Length == 0) {
                    throw new InvalidValueSpecificationException(values);
                }
                vlist = new uint[tokens.Length];
                try {
                    for (int i = 0; i < tokens.Length; ++i) {
                        vlist[i] = Convert.ToUInt32(tokens[i]);
                    }
                } catch (FormatException fe) {
                    throw new InvalidValueSpecificationException(fe.Message);
                }
            } else if (values.IndexOf(',') == -1 && values.IndexOf('-') != -1) {
                mode = ValueMode.Range;
                string[] tokens = values.Split('-');

                if (tokens.Length != 2) {
                    throw new InvalidValueSpecificationException(values);
                }
                try {
                    minValue = Convert.ToUInt32(tokens[0]);
                    maxValue = Convert.ToUInt32(tokens[1]);
                } catch (FormatException fe) {
                    throw new InvalidValueSpecificationException(fe.Message);
                }
                if (maxValue < minValue) {
                    throw new InvalidValueSpecificationException(values);
                }
                vlist = null;
            } else if (values.IndexOf(',') == -1 && values.IndexOf('-') == -1) {// single value
                mode = ValueMode.Values;
                vlist = new uint[1];
                try {
                    vlist[0] = Convert.ToUInt32(values);
                } catch (FormatException fe) {
                    throw new InvalidValueSpecificationException(fe.Message);
                }
            } else if (values.IndexOf(',') != -1 && values.IndexOf('-') != -1) {
                throw new InvalidValueSpecificationException("Cannot specify both value and range: " + values);
            }
        }

        public uint NextValue() {
            switch (mode) {
                case ValueMode.Range:
                    return (uint)minValue + (uint)rand.Next() % (maxValue - minValue);
                default:
                    return vlist[rand.Next() % vlist.Length];
            }
        }
        public static uint NextInteger {
            get {
                return (uint)rand.Next();
            }
        }
        public static byte NextByte {
            get {
                return (byte)rand.Next();
            }
        }
    }

    public class ValueRange1 : ValueRange {
        public ValueRange1(string values)
            : base(1, values) {
            if (minValue < 0 || maxValue > 0xff) {
                throw new InvalidValueSpecificationException("Value out of range: " + values);
            }
        }

        public new byte NextValue() {
            return (byte)base.NextValue();
        }
    }
    public class ValueRange2 : ValueRange {
        public ValueRange2(string values)
            : base(2, values) {
            if (minValue < 0 || maxValue > 0xffff) {
                throw new InvalidValueSpecificationException("Value out of range: " + values);
            }
        }

        public new ushort NextValue() {
            return netflow.Netflow.reverseByteOrder((ushort)base.NextValue());
        }
    }
    public class ValueRange4 : ValueRange {
        public ValueRange4(string values)
            : base(4, values) {
            if (minValue < 0 || maxValue > 0xffffffff) {
                throw new InvalidValueSpecificationException("Value out of range: " + values);
            }
        }

        public new uint NextValue() {
            return netflow.Netflow.reverseByteOrder(base.NextValue());
        }
    }

    public class AddressRange {
        protected readonly ValueRange.ValueMode mode;
        protected readonly uint minValue;
        protected readonly uint maxValue;
        protected readonly uint[] vlist;
        protected static System.Random rand = new Random();
        public AddressRange(string values) {
            if (values.Trim() == "") {
                mode = ValueRange.ValueMode.Range;
                minValue = 0x0;
                maxValue = 0xffffffff;
            } else if (values.IndexOf(',') != -1 && values.IndexOf('-') == -1) {
                mode = ValueRange.ValueMode.Values;
                string[] tokens = values.Split(',');
                if (tokens.Length == 0) {
                    throw new InvalidValueSpecificationException(values);
                }
                vlist = new uint[tokens.Length];
                try {
                    for (int i = 0; i < tokens.Length; ++i) {
                        System.Net.IPAddress addr = System.Net.IPAddress.Parse(tokens[i]);
                        byte[] bytes = addr.GetAddressBytes();
                        uint val = 0;
                        for (int j = 0; j < bytes.Length; ++j) {
                            val <<= 8;
                            val += bytes[j];
                        }

                        vlist[i] = val;
                    }
                } catch (FormatException fe) {
                    throw new InvalidValueSpecificationException(fe.Message);
                }
            } else if (values.IndexOf(',') == -1 && values.IndexOf('-') != -1) {
                mode = ValueRange.ValueMode.Range;
                string[] tokens = values.Split('-');

                if (tokens.Length != 2) {
                    throw new InvalidValueSpecificationException(values);
                }
                try {
                    for (int i = 0; i < tokens.Length; ++i) {
                        System.Net.IPAddress addr = System.Net.IPAddress.Parse(tokens[i].Trim());
                        byte[] bytes = addr.GetAddressBytes();
                        uint val = 0;
                        for (int j = 0; j < bytes.Length; ++j) {
                            val <<= 8;
                            val += bytes[j];
                        }
                        switch (i) {
                            case 0:
                                minValue = val;
                                break;
                            case 1:
                                maxValue = val;
                                break;
                        }
                    }
                } catch (FormatException fe) {
                    throw new InvalidValueSpecificationException(fe.Message);
                }
                if (maxValue < minValue) {
                    throw new InvalidValueSpecificationException(values);
                }
                vlist = null;
            } else if (values.IndexOf(',') == -1 && values.IndexOf('-') == -1) {// single value
                mode = ValueRange.ValueMode.Values;
                try {
                    System.Net.IPAddress addr = System.Net.IPAddress.Parse(values);
                    byte[] bytes = addr.GetAddressBytes();
                    uint val = 0;
                    for (int j = 0; j < bytes.Length; ++j) {
                        val <<= 8;
                        val += bytes[j];
                    }
                    vlist = new uint[1];
                    vlist[0] = val;
                } catch (FormatException fe) {
                    throw new InvalidValueSpecificationException(fe.Message);
                }
            } else if (values.IndexOf(',') != -1 && values.IndexOf('-') != -1) {
                throw new InvalidValueSpecificationException("Cannot specify both value and range: " + values);
            }

        }

        public uint NextValue() {
            uint val = 0;
            switch (mode) {
                case ValueRange.ValueMode.Range:
                    val = (uint)minValue + (uint)rand.Next() % (maxValue - minValue);
                    break;
                default:
                    val = vlist[rand.Next() % vlist.Length];
                    break;
            }
            return netflow.Netflow.reverseByteOrder(val);
        }

    }
}
