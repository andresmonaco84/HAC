using System;
using System.Collections.Generic;
using System.Threading;
using System.Resources;
using System.Globalization;
using System.Reflection;
using HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.Framework
{
    public abstract class EnumListBuilderBase
    {
        protected Type _type;
        private string _typeName;

        public abstract List<EnumKeyText> GetList();

        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }

        public EnumListBuilderBase(Type enumType)
        {
            _typeName = enumType.Name;
            _type = enumType;
        }
    }

    [Serializable()]
    public class EnumKeyText
    {
        public string _key;
        public string _text;

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
    

    public abstract class EnumTranslateBase
    {
        public static string GetTranslateValueInt(Type type, int keyValue, ResourceManager res)
        {
            //Monta a chave para pesquisa no resources
            string resKey = type.Name + "_" + keyValue.ToString();

            return res.GetString(resKey);
        }

        public static string GetTranslateValueChar(Type type, char keyValue, ResourceManager res)
        {
            //Monta a chave para pesquisa no resources
            string resKey = type.Name + "_" + keyValue.ToString();

            return res.GetString(resKey);
        }

        public static List<EnumKeyText> GetTranslateEnumValuesInt(Type type, ResourceManager res, bool firstEmpty)
        {
            //Obtem a lista de valores do enum
            Array arrayOfValues = Enum.GetValues(type);
            List<EnumKeyText> lstOfItens = new List<EnumKeyText>();

            if (firstEmpty)
            {
                EnumKeyText emptyKeyText = new EnumKeyText();
                emptyKeyText._key = null;
                emptyKeyText._text = "";
                lstOfItens.Add(emptyKeyText);
            }

            //Percorre cada key e obtem o texto da resource
            for (int i = 0; i < arrayOfValues.Length; i++)
            {
                int keyValue = (int)arrayOfValues.GetValue(i);
                //Verifica se não é int.minvalue
                if (keyValue != int.MinValue)
                {
                    EnumKeyText enumKeyText = new EnumKeyText();
                    enumKeyText._key = keyValue.ToString();
                    enumKeyText._text = GetTranslateValueInt(type, (int) keyValue, res);

                    lstOfItens.Add(enumKeyText);
                }
            }

            return lstOfItens;
        }

        public static List<EnumKeyText> GetTranslateEnumValuesChar(Type type, ResourceManager res, bool firstEmpty)
        {
            //Obtem a lista de valores do enum
            Array arrayOfValues = Enum.GetValues(type);
            List<EnumKeyText> lstOfItens = new List<EnumKeyText>();

            if (firstEmpty)
            {
                EnumKeyText emptyKeyText = new EnumKeyText();
                emptyKeyText._key = null;
                emptyKeyText._text = "";
                lstOfItens.Add(emptyKeyText);
            }

            //Percorre cada key e obtem o texto da resource
            for (int i = 0; i < arrayOfValues.Length; i++)
            {
                char keyValue = Convert.ToChar( arrayOfValues.GetValue(i).GetHashCode());
                //Verifica se não é null
                if (keyValue != new char())
                {
                    EnumKeyText enumKeyText = new EnumKeyText();
                    enumKeyText._key = keyValue.ToString();
                    enumKeyText._text = GetTranslateValueChar(type, keyValue, res);

                    lstOfItens.Add(enumKeyText);
                }
            }

            return lstOfItens;
        }
    }
}
