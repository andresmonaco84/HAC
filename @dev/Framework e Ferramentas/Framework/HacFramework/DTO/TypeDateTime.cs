using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlTypes;


namespace HospitalAnaCosta.Framework.DTO
{
    [Serializable()]
    public class TypeDateTime : IConvertible, INullable
    {
        internal DateTime? value = null;

        public static implicit operator TypeDateTime(DateTime? dateTimeValue)
        {
            TypeDateTime typeDateTime = new TypeDateTime();
            typeDateTime.value = dateTimeValue;
            return typeDateTime;
        }

        public static implicit operator DateTime?(TypeDateTime typeDateTime)
        {
            return typeDateTime.value;
        }

        public static implicit operator string(TypeDateTime typeDateTime)
        {
            if (typeDateTime.value == null)
                return "";
            else
                return typeDateTime.value.ToString();
        }

        public static implicit operator TypeDateTime(string stringValue)
        {
            TypeDateTime typeDateTime = new TypeDateTime();
            try
            {
                typeDateTime.value = ConvertFromText.ToDateTime(stringValue);
            }
            catch { }

            return typeDateTime;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        #region IConvertible Members

        public TypeCode GetTypeCode()
        {
            return TypeCode.String;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(value, provider);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(value, provider);
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(value, provider);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(value, provider);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(value, provider);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(value, provider);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(value, provider);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(value, provider);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(value, provider);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(value, provider);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(value, provider);
        }

        public string ToString(IFormatProvider provider)
        {
            return Convert.ToString(value, provider);
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return this.GetType();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(value, provider);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(value, provider);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(value, provider);
        }

        #endregion

        #region INullable Members

        public bool IsNull
        {
            get { return value == null; }
        }

        #endregion
    }
}
