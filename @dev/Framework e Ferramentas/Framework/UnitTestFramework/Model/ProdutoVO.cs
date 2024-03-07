using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework;

public class ProdutoVO
{

    [Serializable()]
    public class Tree : BaseTree
    {
        //Declara a Arvore Fornecedor
        public FornecedorVO.Tree FornecedorTree;

        public Tree(bool filled)
            : base(filled)
        {
            this.FornecedorTree = filled == false ? null : new FornecedorVO.Tree(filled);
        }
    }

    private int? _idt;
    private string _descricaoProduto;
    private FornecedorVO _fornecedor;

    public int? Idt
    {
        get { return _idt; }
        set { _idt = value; }
    }

    public string Descricao
    {
        get { return _descricaoProduto; }
        set { _descricaoProduto = value; }
    }

    public FornecedorVO Fornecedor
    {
        get { return _fornecedor; }
        set { _fornecedor = value; }
    }

}
