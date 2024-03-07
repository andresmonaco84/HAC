using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HospitalAnaCosta.Framework.DTO
{
    [Serializable()]
    public sealed class FieldDecimal : FieldBase
    {
        public FieldDecimal(string fieldName, string caption) : base(fieldName, caption) { base.dbType = System.Data.DbType.VarNumeric; }

        public FieldDecimal(string fieldName, string caption, System.Data.DbType dbType) : base(fieldName, caption) { base.dbType = dbType; }

        private TypeDecimal value = new TypeDecimal();

        public TypeDecimal Value
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


