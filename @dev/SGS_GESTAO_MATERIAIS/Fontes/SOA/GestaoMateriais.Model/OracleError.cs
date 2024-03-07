using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class OracleError : Entity
    {

        private string chr(int dec)
        {
            return Convert.ToChar(dec).ToString();
        }


        public string RetornaMsg(OracleException ora, MovimentacaoDTO dto, string procedure)
        {
            string oraMsg = null;
            int OraCode = 0;

            OraCode = ora.Code;
            switch (OraCode)
            {
                case 20001:
                    oraMsg = oraMsg + "N�O EXISTE ESTOQUE PARA REALIZAR ESTA BAIXA" + chr(13);
                    // oraMsg = oraMsg + "ESTOQUE: "+dto.EstoqueLocal.Value.ToString();
                    break;
                case 20002:
                    oraMsg = "ERRO TENTANDO ATUALIZAR MOVIMENTAC�O DO ESTOQUE" + chr(13);
                    break;
                case 20003:
                    oraMsg = "N�O EXISTE ESTOQUE PARA FRACIONAR ESTE PRODUTO" + chr(13);
                    break;
                case 20004:
                    oraMsg = "N�O EXISTE ESTOQUE FRACIONADO DESTE PRODUTO PARA DAR BAIXA" + chr(13);
                    break;
                case 20005:
                    oraMsg = "ERRO TENTANDO CRIAR MOVIMENTO DO ESTOQUE" + chr(13);
                    break;
                case 20006:
                    oraMsg = "QTDE FORNECIDA N�O PODE SER MAIOR QUE A QUANTIDADE PADR�O NA UNIDADE" + chr(13);
                    break;
                case 20100:
                    oraMsg = "ERRO TENTANDO FATURAR ITEM" + chr(13);
                    break;
                case 20101:
                    oraMsg = "SETOR DE DESTINO N�O TEM ACESSO AO MATERIAL OU MEDICAMENTO" + chr(13);
                    break;
                case 20102:
                    oraMsg = "ESTE PEDIDO J� FOI DISPENSADO POR OUTRO PROCESSO" + chr(13);
                    break;
                case 20010:
                    oraMsg = "N�O � PERMITIDO REALIZAR MOVIMENTA��O, POIS A CONTAGEM PARA INVENT�RIO DO ESTOQUE DO SETOR N�O PODE ESTAR EM ANDAMENTO.\n\nEM D�VIDA, CONTATE O GESTOR DE ALMOXARIFADO.\n\n" + chr(13);
                    break;
                case 20020:
                    oraMsg = "SALDO DO LOTE INSUFICIENTE PARA BAIXA, VERIFIQUE O CODIGO DE BARRA." + chr(13);
                    break;
                case 20220:
                    oraMsg = "MEDICAMENTO VENCIDO, PERMITIDO APENAS REGISTRO DE PERDA !!!";
                    break;
                case 20030:
                    oraMsg = "PRODUTO COM CONTROLE DE LOTE SEM SALDO DISPONIVEL PARA CONSUMIR LOTE SEM CONTROLE" + chr(13);
                    break;
                case 20040:
                    oraMsg = "N�O � PERMITIDO REALIZAR TRANSFER�NCIA PARA ESTE SETOR !!! NECESS�RIO FAZER PEDIDO.";
                    break;
                case 20090:
                    oraMsg = "PRODUTO EXCEDEU O PRAZO DE ESTORNO." + chr(13);
                    break;
                default:
                    oraMsg = ora.Message;
                    break;
            }
            
            //oraMsg = oraMsg + "PRODUTO: " + dto.DsProduto.Value.ToString() + chr(13);
#if DEBUG
            oraMsg = oraMsg + "CHAMADA: " + ora.Message;
#endif
            //
            return oraMsg;

        }
    }
}
