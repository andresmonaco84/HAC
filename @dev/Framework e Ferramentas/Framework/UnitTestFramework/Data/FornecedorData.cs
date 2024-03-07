using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework;

public class FornecedorData
{
    public FornecedorVO Obter(int idt, BaseTree tree)
    {
        FornecedorVO enFornecedorVO = new FornecedorVO();
        //Acessa banco de dados
        enFornecedorVO.Idt = 1;
        enFornecedorVO.Nome = "Fornecedor XPTO";
        enFornecedorVO.Endereco = new EnderecoVO();
        enFornecedorVO.Endereco.Idt = 1;

        //Faz o cast para o tipo de �rvore correta
        //Este exemplo � "APENAS" utilizado quando a �rvore chamada n�o possui filhos 
        FornecedorVO.Tree treeFornecedor = (FornecedorVO.Tree)tree.Get(typeof(FornecedorVO.Tree));
        if (treeFornecedor.RecuperarEndereco)
        {
            EnderecoData daoEndereco = new EnderecoData();
            enFornecedorVO.Endereco = daoEndereco.Obter(enFornecedorVO.Endereco.Idt);
        }
        return enFornecedorVO;
    }
}
