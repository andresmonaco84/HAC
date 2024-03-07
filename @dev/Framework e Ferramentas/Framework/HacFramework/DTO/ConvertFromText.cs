using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAnaCosta.Framework.DTO
{
    public static class ConvertFromText
    {
        public static string ToString(string value)
        {
            string ret = null;
            if (value.Length !=0)
            {
                ret = value;
            }
            return ret;
        }

        public static decimal? ToDecimal(string value)
        {
            decimal? ret = null;
            if (value.Length !=0)
            {
                ret = decimal.Parse(value);
            }
            return ret;
        }

        public static DateTime? ToDateTime(string value)
        {
            DateTime? ret = null;
            if (value.Length !=0)
            {
                ret = DateTime.Parse(value);
            }
            return ret;
        }

        public static Int16? ToInt16(string value)
        {
            Int16? ret = null;
            if (value.Length !=0)
            {
                ret = Int16.Parse(value);
            }
            return ret;
        }
        public static Int32? ToInt32(string value)
        {
            Int32? ret = null;
            if (value.Length !=0)
            {
                ret = Int32.Parse(value);
            }
            return ret;
        }
        public static Int64? ToInt64(string value)
        {
            Int64? ret = null;
            if (value.Length !=0)
            {
                ret = Int64.Parse(value);
            }
            return ret;
        }
        public static SByte? ToSByte(string value)
        {
            SByte? ret = null;
            if (value.Length !=0)
            {
                ret = SByte.Parse(value);
            }
            return ret;
        }
        public static TimeSpan? ToTimeSpan(string value)
        {
            TimeSpan? ret = null;
            if (value.Length !=0)
            {
                ret = TimeSpan.Parse(value);
            }
            return ret;
        }
        public static UInt16? ToUInt16(string value)
        {
            UInt16? ret = null;
            if (value.Length !=0)
            {
                ret = UInt16.Parse(value);
            }
            return ret;
        }
        public static UInt32? ToUInt32(string value)
        {
            UInt32? ret = null;
            if (value.Length !=0)
            {
                ret = UInt32.Parse(value);
            }
            return ret;
        }
        public static UInt64? ToUInt64(string value)
        {
            UInt64? ret = null;
            if (value.Length !=0)
            {
                ret = UInt64.Parse(value);
            }
            return ret;
        }
        public static byte? ToByte(string value)
        {
            byte? ret = null;
            if (value.Length !=0)
            {
                ret = byte.Parse(value);
            }
            return ret;
        }
        public static double? ToDouble(string value)
        {
            double? ret = null;
            if (value.Length !=0)
            {
                ret = double.Parse(value);
            }
            return ret;
        }


    }
}
