using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework;

public class EnderecoData
{
    public EnderecoVO Obter(int idt)
    {
        EnderecoVO enEnderecoVO = new EnderecoVO();
        //Acessa o banco de dados
        enEnderecoVO.Idt = 1;
        enEnderecoVO.EnderecoCompleto = "Rua Pará, 60";
        enEnderecoVO.DataAtualizacao = new DateTime(2007, 1, 2);
        return enEnderecoVO;
    }
}
