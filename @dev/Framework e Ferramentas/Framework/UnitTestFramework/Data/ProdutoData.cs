using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework;

public class ProdutoData
{
    public ProdutoVO Obter(int idt, BaseTree tree)
    {
        ProdutoVO enProdutoVO = new ProdutoVO();
        //Acessa o banco de dados
        enProdutoVO.Idt = 1;
        enProdutoVO.Descricao = "Produto Teste";
        enProdutoVO.Fornecedor = new FornecedorVO();
        enProdutoVO.Fornecedor.Idt = 1;

        //Somente entra no if, se o idt <> null e foi enviado tree como parâmetro
        if ( enProdutoVO.Fornecedor.Idt != null && tree.Has(typeof(FornecedorVO.Tree)))
        {
            FornecedorVO.Tree treeFornecedor = (FornecedorVO.Tree)tree.Get(typeof(FornecedorVO.Tree));
            FornecedorData daoFornecedor = new FornecedorData();
            enProdutoVO.Fornecedor = daoFornecedor.Obter((int)enProdutoVO.Fornecedor.Idt, treeFornecedor);
        }
        return enProdutoVO;
    }
}
