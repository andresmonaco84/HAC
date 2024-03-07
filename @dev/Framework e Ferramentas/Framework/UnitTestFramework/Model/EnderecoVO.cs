using System;
using System.Data;
using System.Configuration;
using System.Web;

using System.Xml.Serialization;
using HospitalAnaCosta.Framework.ValueObject;

public class EnderecoVO
{
    public EnderecoVO(int intCodigo, string strEndereco)
    {
        this.Idt = intCodigo;
        this.EnderecoCompleto = strEndereco;
        this.DataAtualizacao = DateTime.Now;
    }

    public EnderecoVO()
    {
        this.DataAtualizacao = DateTime.Now;
    }

    private int intCodigo;
    private string strEndereco;
    private DateTime datAtual;

    [XmlElement(IsNullable = false)]
    public int Idt
    {
        get { return intCodigo; }
        set { intCodigo = value; }
    }

    [XmlElement(IsNullable = true)]
    public string EnderecoCompleto
    {
        get { return strEndereco; }
        set { strEndereco = value; }
    }

    public DateTime DataAtualizacao
    {
        get { return datAtual; }
        set { datAtual = value; }
    }
}
