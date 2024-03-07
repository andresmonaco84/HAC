using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Impressao
{
    public class ImpressaoPedido
    {
        public ImpressaoPedido()
        {

        }

        public bool Imprimir(RequisicaoDTO dtoRequisicao, bool origemDispensacao)
        {
            string impressoraPedido = Utilitario.ObterRegistroWindows(Utilitario.ModeloImpressoraPedidosNomeRegistro());

            if (!string.IsNullOrEmpty(impressoraPedido))
            {
                if (impressoraPedido == Utilitario.ModeloImpressoraPedidos.BEMATECH.ToString())
                    new ImpBematech().Imprimir(dtoRequisicao, origemDispensacao);
                else if (impressoraPedido == Utilitario.ModeloImpressoraPedidos.BIXOLON.ToString())
                    new ImpBixolon().Imprimir(dtoRequisicao, origemDispensacao);
                else
                {
                    throw new Exception("Nenhuma Impressora Configurada");
                    //return false;
                }
            }
            else
            {
                //Por enquanto a padrão vai continuar sendo a BEMATECH
                //Lembrar depois se for alter isso, no Load da FrmCfgImpressora
                new ImpBematech().Imprimir(dtoRequisicao, origemDispensacao);
            }
            return true;
        }

        //public static void ObterModeloImpressoraConfigurada()
        //{

        //}
    }
}