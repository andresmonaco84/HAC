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
        /// Messagem de Retorno caso o controle seja necessário mas não tenha sido preenchido
        /// </summary>
        string ObrigatorioMensagem { get;}

        /// <summary>
        /// Indica se o controle é de preenchiemento Obrigatório
        /// </summary>
        bool Obrigatorio { get;}


        bool Limpar { get; }

        EstadoObjeto EstadoInicial     { get ; }

        ControleEdicao Editavel { get; }

        bool PreValidado  { get; }

        string PreValidacaoMensagem  { get ; }

        /// <summary>
        /// Faz a validação 
        /// </summary>
        /// <returns></returns>
        bool ValidateRequired();

        void Controla(Evento e);

        bool ValidaObjeto(Evento e, ref String Mensagem );
    }
}

