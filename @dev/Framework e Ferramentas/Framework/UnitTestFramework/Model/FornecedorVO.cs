using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework;

public class FornecedorVO
{
    [Serializable()]
    public class Tree : BaseTree
    {
        public bool RecuperarEndereco;

        public Tree(bool filled)
            : base(filled)
        {
            RecuperarEndereco = filled;
        }
    }

    private int? _idt;
    private string _nomeFornecedor;
    private EnderecoVO _endereco;

    public int? Idt
    {
        get { return _idt; }
        set { _idt = value; }
    }

    public string Nome
    {
        get { return _nomeFornecedor; }
        set { _nomeFornecedor = value; }
    }

    public EnderecoVO Endereco
    {
        get { return _endereco; }
        set { _endereco = value; }
    }

}

