using System;
using System.Collections.Generic;
using System.Text;

namespace HacFramework.Windows.Helpers
{
    /// <summary>
    /// Esta classe é utilizada para carregar combos
    /// </summary>
    public class ListItem
    {
        public struct FieldNames
        {
            public const string Key = "Key";
            public const string Value = "Value";
        }	

        public ListItem(string _key, string _value)
        {
            this.key = _key;
            this.value = _value;
        }

        private string key;
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private string value;
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
            return this.value;
        }
    }
}
