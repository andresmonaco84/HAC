using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Data.SqlTypes;

namespace HospitalAnaCosta.Framework.DTO
{
    [Serializable()]
    [DefaultProperty("Value")]
    public abstract class FieldBase
    {
        protected string caption;
        protected string fieldName;

        protected DbType dbType;

        public DbType DbType
        {
            get { return dbType; }
        }

        public string FieldName { get { return fieldName; } }
        public string Caption { get { return caption; } }

        public FieldBase(string fieldName, string caption)
        {
            this.fieldName = fieldName;
            this.caption = caption;
        }

        public abstract object DBValue
        {
            get;
        }

        public FieldBase()
        {

        }
    }
}
