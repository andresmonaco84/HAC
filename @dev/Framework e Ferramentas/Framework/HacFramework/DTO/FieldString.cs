using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAnaCosta.Framework.DTO
{
    [Serializable()]
    public sealed class FieldString : FieldBase
    {
        private int size;

        public int Size
        {
            get
            {
                return size;
            }
        }

        public override string ToString()
        {
            return Convert.ToString(Value.value);
        }

        public FieldString(string fieldName, string caption) : base(fieldName, caption) { base.dbType = System.Data.DbType.String; }

        public FieldString(string fieldName, string caption, int size)
            : this(fieldName, caption)
        {
            this.size = size;
        }

        private TypeString value = new TypeString();

        public TypeString Value
        {
            get
            {
                return value;
            }
            set { this.value = value; }
        }

        public override object DBValue
        {
            get
            {
                object ret = DBNull.Value;
                if (value != null)
                    if (value.value != null)
                    {
                        ret = value;
                    }
                return ret;
            }
        }
    }
}