using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAnaCosta.Framework.DTO
{
    [Serializable()]
    public sealed class FieldDateTime : FieldBase
    {
        public FieldDateTime(string fieldName, string caption)
            : base(fieldName, caption)
        {
            base.dbType = System.Data.DbType.DateTime;
        }

        private TypeDateTime value = new TypeDateTime();

        public TypeDateTime Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
            return Convert.ToString(Value.value);
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

