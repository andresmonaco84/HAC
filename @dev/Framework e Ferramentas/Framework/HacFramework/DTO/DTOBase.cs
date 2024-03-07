using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Xml;

namespace HospitalAnaCosta.Framework.DTO
{
    [Serializable()]
    public abstract class DTOBase
    {
        public virtual XmlDocument GetXML()
        {
            return null;
        }
    }
}
