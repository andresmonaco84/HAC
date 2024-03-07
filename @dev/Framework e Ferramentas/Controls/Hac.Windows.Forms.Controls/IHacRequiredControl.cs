using System;
using System.Collections.Generic;
using System.Text;

namespace Hac.Windows.Forms.Controls
{
    interface IHacRequiredControl
    {
        /// <summary>
        /// Indica que campo pode ter a propriedade required
        /// </summary>
        /// <summary>
        /// Messagem de Retorno caso o controle seja necess�rio mas n�o tenha sido preenchido
        /// </summary>
        string ObrigatorioMensagem { get;}

        /// <summary>
        /// Indica se o controle � de preenchiemento Obrigat�rio
        /// </summary>
        bool Obrigatorio { get;}


        bool Limpar { get; }

        EstadoObjeto EstadoInicial     { get ; }

        ControleEdicao Editavel { get; }

        bool PreValidado  { get; }

        string PreValidacaoMensagem  { get ; }

        /// <summary>
        /// Faz a valida��o 
        /// </summary>
        /// <returns></returns>
        bool ValidateRequired();

        void Controla(Evento e);

        bool ValidaObjeto(Evento e, ref String Mensagem );
    }
}

