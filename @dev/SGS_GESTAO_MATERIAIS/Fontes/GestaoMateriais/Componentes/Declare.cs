using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAnaCosta.SGS.Componentes
{
    public enum AcceptedFormat
    {
        AlfaNumerico = 0,
        Numerico = 1,
        Decimal = 2,
        Data = 3
    }

    public enum AcceptedFormatMasked
    {
        Data = 0,
        Hora = 1,
        Telefone = 2,
        CPF = 3,
        CEP = 4
    }

    public enum CharControl
    {
        ControlC = 3,
        ControlV = 22
    }

    public enum Evento
    {
        eNovo,
        eSalvar,
        eCancelar,
        eExcluir,
        eInicio,
        eEditar,
        eLimpar
    }

    public enum ModoEdicao
    {
        /// <summary>
        /// Modo da tela no Inicio, após salvar, após cancelar
        /// </summary>
        Inicio = 0,  
        /// <summary>
        /// Modo da Tela após clicar no botão Novo
        /// </summary>
        Novo = 1,
        /// <summary>
        /// Moda da tela alterando registro
        /// </summary>
        Edicao = 2
    }

    public enum ControleEdicao
    {
        Nunca =0,
        NovoRegistro = 1, // Modo: Novo
        Pesquisa = 2,     // Modo: Inicio, Edicao
        Sempre = 3
    }

    public enum EstadoObjeto
    {
        Habilitado = 1,
        Desabilitado = 0
        
    }

    public enum TipoValidacao
    {
        PreValidacao,
        PosValidacao
    }
}

