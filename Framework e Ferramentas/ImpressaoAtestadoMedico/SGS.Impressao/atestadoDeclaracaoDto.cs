using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.tools;
/********************************************************************
OBS: Código gerado automaticamente, não altere nada neste arquivo
TABELA:
********************************************************************/

namespace HospitalAnaCosta.SGS.Impressao.dto
{
    [Serializable()]
    public partial class AtestadoDeclaracaoDto
    {
        public AtestadoDeclaracaoDto()
        {

        }
        private string ACOMPANHANTE;
        private string CID;
        private string CAD_PRO_NR_CONSELHO;
        private DateTime? ATD_ATE_DT_ATENDIMENTO;
        private DateTime? FIM_AFASTA;
        private DateTime? DATA_IMPRESSAO;
        private DateTime? INI_AFASTA;
        private string CONSULTA_ACOM;
        private string CONSULTA_MED;
        private string CONSULTA_TRAT;
        private decimal? QTDDIAS;
        private string CAD_SET_DS_SETOR;
        private string CAD_UNI_DS_UNIDADE;
        private decimal? FIM_PERIODO;
        private decimal? ATD_ATE_HR_ATENDIMENTO;
        private decimal? ATD_ATE_ID;
        private decimal? ID_ATESTADO;
        private decimal? SEG_USU_ID_USUARIO;
        private decimal? INI_PERIODO;
        private string CAD_PRO_NM_NOME;
        private string CAD_PES_NM_PESSOA;
        private string PROTOCOLO;
        private string DS_RELATORIO;
        private decimal? CAD_PAC_NR_PRONTUARIO;
        private decimal? CAD_SET_ID;
        private string TP_ATESTADO;
        /// <summary>
        /// Converte uma List de DTO para JSON
        /// </summary>
        public string parseJSON(List<AtestadoDeclaracaoDto> obj)
        {
            string json = string.Empty;
            if (obj.Count > 0)
            {
                json = "[";
                for (int i = 0; i < obj.Count; i++)
                {
                    AtestadoDeclaracaoDto d = obj[i];
                    json += string.Format("{0},", d.parseJSON());
                }
                json = json.Substring(0, json.Length - 1);
                json += "]";
            }
            else
            {
                json = "{}";
            }
            return json;
        }
        private string atributoJSon(string coluna, string valor)
        {
            if (!string.IsNullOrEmpty(valor))
                valor = valor.Replace("\0", "");
            return string.Format("\"{0}\":\"{1}\",", coluna, valor);
        }
        private string atributoJSon(string coluna, bool valor)
        {
            string newValor = (valor ? "S" : "N");
            return this.atributoJSon(coluna, newValor);
        }
        private string atributoJSon(string coluna, decimal? valor)
        {
            string newValor = (valor == null ? null : valor.ToString());
            return this.atributoJSon(coluna, newValor);
        }
        private string atributoJSon(string coluna, decimal valor)
        {
            string newValor = valor.ToString();
            return this.atributoJSon(coluna, newValor);
        }
        private string atributoJSonObjetoAssociado(string coluna, string valor)
        {
            return string.Format("\"{0}\":{1},", coluna, valor);
        }
        /// <summary>
        /// Converte uma DTO para JSON, com proximo nivel de DTO sempre verdadeiro
        /// </summary>
        public string parseJSON()
        {
            return this.parseJSON(true);
        }
        /// <summary>
        /// Converte uma DTO para JSON
        /// </summary>
        public string parseJSON(bool dtoProximoNivel)
        {
            string json = string.Empty;
            json = "{";
            json += this.atributoJSon("acompanhante", this.ACOMPANHANTE);
            json += this.atributoJSon("cid", this.CID);
            json += this.atributoJSon("crm", this.CAD_PRO_NR_CONSELHO);
            json += this.atributoJSon("dataAtendimento", Utilitario.dateToString(this.ATD_ATE_DT_ATENDIMENTO));
            json += this.atributoJSon("dataFimAfastamento", Utilitario.dateToString(this.FIM_AFASTA));
            json += this.atributoJSon("dataImpressao", Utilitario.dateToString(this.DATA_IMPRESSAO));
            json += this.atributoJSon("dataInicioAfastamento", Utilitario.dateToString(this.INI_AFASTA));
            json += this.atributoJSon("declaracaoDeAcompanhante", this.CONSULTA_ACOM);
            json += this.atributoJSon("declaracaoDeConsulta", this.CONSULTA_MED);
            json += this.atributoJSon("declaracaoDeTratamento", this.CONSULTA_TRAT);
            json += this.atributoJSon("diasDeAfastamento", this.QTDDIAS);
            json += this.atributoJSon("dsSetor", this.CAD_SET_DS_SETOR);
            json += this.atributoJSon("dsUnidade", this.CAD_UNI_DS_UNIDADE);
            json += this.atributoJSon("fimPeriodoDeclaracao", this.FIM_PERIODO);
            json += this.atributoJSon("horaAtendimento", this.ATD_ATE_HR_ATENDIMENTO);
            json += this.atributoJSon("idtAtendimento", this.ATD_ATE_ID);
            json += this.atributoJSon("idtAtestado", this.ID_ATESTADO);
            json += this.atributoJSon("idtUsuario", this.SEG_USU_ID_USUARIO);
            json += this.atributoJSon("inicioPeriodoDeclaracao", this.INI_PERIODO);
            json += this.atributoJSon("nomeMedico", this.CAD_PRO_NM_NOME);
            json += this.atributoJSon("nomePessoa", this.CAD_PES_NM_PESSOA);
            json += this.atributoJSon("protocolo", this.PROTOCOLO);
            json += this.atributoJSon("relatorio", this.DS_RELATORIO);
            json += this.atributoJSon("rg", this.CAD_PAC_NR_PRONTUARIO);
            json += this.atributoJSon("setorIdt", this.CAD_SET_ID);
            json += this.atributoJSon("tipo", this.TP_ATESTADO);
            json = json.Substring(0, json.Length - 1);
            json += "}";
            return json;
        }
        public DataRow dtoParaDataRow()
        {
            DataTable dtb = new DataTable();
            DataRow dtr = dtb.NewRow();
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("ACOMPANHANTE", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("CID", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("CAD_PRO_NR_CONSELHO", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("ATD_ATE_DT_ATENDIMENTO", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("FIM_AFASTA", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("DATA_IMPRESSAO", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("INI_AFASTA", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("CONSULTA_ACOM", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("CONSULTA_MED", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("CONSULTA_TRAT", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("QTDDIAS", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("CAD_SET_DS_SETOR", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("CAD_UNI_DS_UNIDADE", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("FIM_PERIODO", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("ATD_ATE_HR_ATENDIMENTO", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("ATD_ATE_ID", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("ID_ATESTADO", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("SEG_USU_ID_USUARIO", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("INI_PERIODO", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("CAD_PRO_NM_NOME", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("CAD_PES_NM_PESSOA", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("PROTOCOLO", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("DS_RELATORIO", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("CAD_PAC_NR_PRONTUARIO", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("CAD_SET_ID", typeof(string)));
            dtr.Table.Columns.Add(Utilitario.criaColunaDataRow("TP_ATESTADO", typeof(string)));
            dtb.ImportRow(dtr);
            return this.dtoParaDataRow(dtb);
        }
        public DataRow dtoParaDataRow(DataTable dtb)
        {
            DataRow dtr = dtb.NewRow();
            if (this.acompanhante != null) dtr["ACOMPANHANTE"] = this.acompanhante;
            if (this.cid != null) dtr["CID"] = this.cid;
            if (this.crm != null) dtr["CAD_PRO_NR_CONSELHO"] = this.crm;
            if (this.dataAtendimento != null) dtr["ATD_ATE_DT_ATENDIMENTO"] = this.dataAtendimento;
            if (this.dataFimAfastamento != null) dtr["FIM_AFASTA"] = this.dataFimAfastamento;
            if (this.dataImpressao != null) dtr["DATA_IMPRESSAO"] = this.dataImpressao;
            if (this.dataInicioAfastamento != null) dtr["INI_AFASTA"] = this.dataInicioAfastamento;
            if (this.declaracaoDeAcompanhante != null) dtr["CONSULTA_ACOM"] = this.declaracaoDeAcompanhante;
            if (this.declaracaoDeConsulta != null) dtr["CONSULTA_MED"] = this.declaracaoDeConsulta;
            if (this.declaracaoDeTratamento != null) dtr["CONSULTA_TRAT"] = this.declaracaoDeTratamento;
            if (this.diasDeAfastamento != null) dtr["QTDDIAS"] = this.diasDeAfastamento;
            if (this.dsSetor != null) dtr["CAD_SET_DS_SETOR"] = this.dsSetor;
            if (this.dsUnidade != null) dtr["CAD_UNI_DS_UNIDADE"] = this.dsUnidade;
            if (this.fimPeriodoDeclaracao != null) dtr["FIM_PERIODO"] = this.fimPeriodoDeclaracao;
            if (this.horaAtendimento != null) dtr["ATD_ATE_HR_ATENDIMENTO"] = this.horaAtendimento;
            if (this.idtAtendimento != null) dtr["ATD_ATE_ID"] = this.idtAtendimento;
            if (this.idtAtestado != null) dtr["ID_ATESTADO"] = this.idtAtestado;
            if (this.idtUsuario != null) dtr["SEG_USU_ID_USUARIO"] = this.idtUsuario;
            if (this.inicioPeriodoDeclaracao != null) dtr["INI_PERIODO"] = this.inicioPeriodoDeclaracao;
            if (this.nomeMedico != null) dtr["CAD_PRO_NM_NOME"] = this.nomeMedico;
            if (this.nomePessoa != null) dtr["CAD_PES_NM_PESSOA"] = this.nomePessoa;
            if (this.protocolo != null) dtr["PROTOCOLO"] = this.protocolo;
            if (this.relatorio != null) dtr["DS_RELATORIO"] = this.relatorio;
            if (this.rg != null) dtr["CAD_PAC_NR_PRONTUARIO"] = this.rg;
            if (this.setorIdt != null) dtr["CAD_SET_ID"] = this.setorIdt;
            if (this.tipo != null) dtr["TP_ATESTADO"] = this.tipo;
            return dtr;
        }
        public AtestadoDeclaracaoDto converteDataRowParaAtestadoDeclaracaoDto(DataRow dtr)
        {
            if (dtr.Table.Columns.Contains("ACOMPANHANTE")) this.setAcompanhante(dtr["ACOMPANHANTE"].ToString());
            if (dtr.Table.Columns.Contains("CID")) this.setCid(dtr["CID"].ToString());
            if (dtr.Table.Columns.Contains("CAD_PRO_NR_CONSELHO")) this.setCrm(dtr["CAD_PRO_NR_CONSELHO"].ToString());
            if (dtr.Table.Columns.Contains("ATD_ATE_DT_ATENDIMENTO")) this.setDataAtendimento(dtr["ATD_ATE_DT_ATENDIMENTO"].ToString());
            if (dtr.Table.Columns.Contains("FIM_AFASTA")) this.setDataFimAfastamento(dtr["FIM_AFASTA"].ToString());
            if (dtr.Table.Columns.Contains("DATA_IMPRESSAO")) this.setDataImpressao(dtr["DATA_IMPRESSAO"].ToString());
            if (dtr.Table.Columns.Contains("INI_AFASTA")) this.setDataInicioAfastamento(dtr["INI_AFASTA"].ToString());
            if (dtr.Table.Columns.Contains("CONSULTA_ACOM")) this.setDeclaracaoDeAcompanhante(dtr["CONSULTA_ACOM"].ToString());
            if (dtr.Table.Columns.Contains("CONSULTA_MED")) this.setDeclaracaoDeConsulta(dtr["CONSULTA_MED"].ToString());
            if (dtr.Table.Columns.Contains("CONSULTA_TRAT")) this.setDeclaracaoDeTratamento(dtr["CONSULTA_TRAT"].ToString());
            if (dtr.Table.Columns.Contains("QTDDIAS")) this.setDiasDeAfastamento(dtr["QTDDIAS"].ToString());
            if (dtr.Table.Columns.Contains("CAD_SET_DS_SETOR")) this.setDsSetor(dtr["CAD_SET_DS_SETOR"].ToString());
            if (dtr.Table.Columns.Contains("CAD_UNI_DS_UNIDADE")) this.setDsUnidade(dtr["CAD_UNI_DS_UNIDADE"].ToString());
            if (dtr.Table.Columns.Contains("FIM_PERIODO")) this.setFimPeriodoDeclaracao(dtr["FIM_PERIODO"].ToString());
            if (dtr.Table.Columns.Contains("ATD_ATE_HR_ATENDIMENTO")) this.setHoraAtendimento(dtr["ATD_ATE_HR_ATENDIMENTO"].ToString());
            if (dtr.Table.Columns.Contains("ATD_ATE_ID")) this.setIdtAtendimento(dtr["ATD_ATE_ID"].ToString());
            if (dtr.Table.Columns.Contains("ID_ATESTADO")) this.setIdtAtestado(dtr["ID_ATESTADO"].ToString());
            if (dtr.Table.Columns.Contains("SEG_USU_ID_USUARIO")) this.setIdtUsuario(dtr["SEG_USU_ID_USUARIO"].ToString());
            if (dtr.Table.Columns.Contains("INI_PERIODO")) this.setInicioPeriodoDeclaracao(dtr["INI_PERIODO"].ToString());
            if (dtr.Table.Columns.Contains("CAD_PRO_NM_NOME")) this.setNomeMedico(dtr["CAD_PRO_NM_NOME"].ToString());
            if (dtr.Table.Columns.Contains("CAD_PES_NM_PESSOA")) this.setNomePessoa(dtr["CAD_PES_NM_PESSOA"].ToString());
            if (dtr.Table.Columns.Contains("PROTOCOLO")) this.setProtocolo(dtr["PROTOCOLO"].ToString());
            if (dtr.Table.Columns.Contains("DS_RELATORIO")) this.setRelatorio(dtr["DS_RELATORIO"].ToString());
            if (dtr.Table.Columns.Contains("CAD_PAC_NR_PRONTUARIO")) this.setRg(dtr["CAD_PAC_NR_PRONTUARIO"].ToString());
            if (dtr.Table.Columns.Contains("CAD_SET_ID")) this.setSetorIdt(dtr["CAD_SET_ID"].ToString());
            if (dtr.Table.Columns.Contains("TP_ATESTADO")) this.setTipo(dtr["TP_ATESTADO"].ToString());
            return this;
        }
        #region ACOMPANHANTE
        public void setAcompanhante(string s)
        {
            this.ACOMPANHANTE = s;
        }
        public string acompanhante
        {
            get
            {
                return this.ACOMPANHANTE;
            }
        }
        #endregion ACOMPANHANTE
        #region CID
        public void setCid(string s)
        {
            this.CID = s;
        }
        public string cid
        {
            get
            {
                return this.CID;
            }
        }
        #endregion CID
        #region CAD_PRO_NR_CONSELHO
        public void setCrm(string s)
        {
            this.CAD_PRO_NR_CONSELHO = s;
        }
        public string crm
        {
            get
            {
                return this.CAD_PRO_NR_CONSELHO;
            }
        }
        #endregion CAD_PRO_NR_CONSELHO
        #region ATD_ATE_DT_ATENDIMENTO
        public void setDataAtendimento(string s)
        {
            if (string.IsNullOrEmpty(s)) return;

            setDataAtendimento(Convert.ToDateTime(s));
        }
        public void setDataAtendimento(DateTime? d)
        {
            this.ATD_ATE_DT_ATENDIMENTO = d;
        }
        public void setDataAtendimento(DateTime d)
        {
            setDataAtendimento((DateTime?)d);
        }
        public DateTime? dataAtendimento
        {
            get
            {
                return this.ATD_ATE_DT_ATENDIMENTO;
            }
        }
        #endregion ATD_ATE_DT_ATENDIMENTO
        #region FIM_AFASTA
        public void setDataFimAfastamento(string s)
        {
            if (string.IsNullOrEmpty(s)) return;

            setDataFimAfastamento(Convert.ToDateTime(s));
        }
        public void setDataFimAfastamento(DateTime? d)
        {
            this.FIM_AFASTA = d;
        }
        public void setDataFimAfastamento(DateTime d)
        {
            setDataFimAfastamento((DateTime?)d);
        }
        public DateTime? dataFimAfastamento
        {
            get
            {
                return this.FIM_AFASTA;
            }
        }
        #endregion FIM_AFASTA
        #region DATA_IMPRESSAO
        public void setDataImpressao(string s)
        {
            if (string.IsNullOrEmpty(s)) return;

            setDataImpressao(Convert.ToDateTime(s));
        }
        public void setDataImpressao(DateTime? d)
        {
            this.DATA_IMPRESSAO = d;
        }
        public void setDataImpressao(DateTime d)
        {
            setDataImpressao((DateTime?)d);
        }
        public DateTime? dataImpressao
        {
            get
            {
                return this.DATA_IMPRESSAO;
            }
        }
        #endregion DATA_IMPRESSAO
        #region INI_AFASTA
        public void setDataInicioAfastamento(string s)
        {
            if (string.IsNullOrEmpty(s)) return;

            setDataInicioAfastamento(Convert.ToDateTime(s));
        }
        public void setDataInicioAfastamento(DateTime? d)
        {
            this.INI_AFASTA = d;
        }
        public void setDataInicioAfastamento(DateTime d)
        {
            setDataInicioAfastamento((DateTime?)d);
        }
        public DateTime? dataInicioAfastamento
        {
            get
            {
                return this.INI_AFASTA;
            }
        }
        #endregion INI_AFASTA
        #region CONSULTA_ACOM
        public void setDeclaracaoDeAcompanhante(string s)
        {
            this.CONSULTA_ACOM = s;
        }
        public string declaracaoDeAcompanhante
        {
            get
            {
                return this.CONSULTA_ACOM;
            }
        }
        #endregion CONSULTA_ACOM
        #region CONSULTA_MED
        public void setDeclaracaoDeConsulta(string s)
        {
            this.CONSULTA_MED = s;
        }
        public string declaracaoDeConsulta
        {
            get
            {
                return this.CONSULTA_MED;
            }
        }
        #endregion CONSULTA_MED
        #region CONSULTA_TRAT
        public void setDeclaracaoDeTratamento(string s)
        {
            this.CONSULTA_TRAT = s;
        }
        public string declaracaoDeTratamento
        {
            get
            {
                return this.CONSULTA_TRAT;
            }
        }
        #endregion CONSULTA_TRAT
        #region QTDDIAS
        public void setDiasDeAfastamento(string s)
        {
            if (string.IsNullOrEmpty(s)) return;

            setDiasDeAfastamento(Convert.ToDecimal(s));
        }
        public void setDiasDeAfastamento(decimal? d)
        {
            this.QTDDIAS = d;
        }
        public void setDiasDeAfastamento(decimal d)
        {
            setDiasDeAfastamento((decimal?)d);
        }
        public decimal? diasDeAfastamento
        {
            get
            {
                return this.QTDDIAS;
            }
        }
        #endregion QTDDIAS
        #region CAD_SET_DS_SETOR
        public void setDsSetor(string s)
        {
            this.CAD_SET_DS_SETOR = s;
        }
        public string dsSetor
        {
            get
            {
                return this.CAD_SET_DS_SETOR;
            }
        }
        #endregion CAD_SET_DS_SETOR
        #region CAD_UNI_DS_UNIDADE
        public void setDsUnidade(string s)
        {
            this.CAD_UNI_DS_UNIDADE = s;
        }
        public string dsUnidade
        {
            get
            {
                return this.CAD_UNI_DS_UNIDADE;
            }
        }
        #endregion CAD_UNI_DS_UNIDADE
        #region FIM_PERIODO
        public void setFimPeriodoDeclaracao(string s)
        {
            if (string.IsNullOrEmpty(s)) return;

            setFimPeriodoDeclaracao(Convert.ToDecimal(s));
        }
        public void setFimPeriodoDeclaracao(decimal? d)
        {
            this.FIM_PERIODO = d;
        }
        public void setFimPeriodoDeclaracao(decimal d)
        {
            setFimPeriodoDeclaracao((decimal?)d);
        }
        public decimal? fimPeriodoDeclaracao
        {
            get
            {
                return this.FIM_PERIODO;
            }
        }
        #endregion FIM_PERIODO
        #region ATD_ATE_HR_ATENDIMENTO
        public void setHoraAtendimento(string s)
        {
            if (string.IsNullOrEmpty(s)) return;

            setHoraAtendimento(Convert.ToDecimal(s));
        }
        public void setHoraAtendimento(decimal? d)
        {
            this.ATD_ATE_HR_ATENDIMENTO = d;
        }
        public void setHoraAtendimento(decimal d)
        {
            setHoraAtendimento((decimal?)d);
        }
        public decimal? horaAtendimento
        {
            get
            {
                return this.ATD_ATE_HR_ATENDIMENTO;
            }
        }
        #endregion ATD_ATE_HR_ATENDIMENTO
        #region ATD_ATE_ID
        public void setIdtAtendimento(string s)
        {
            if (string.IsNullOrEmpty(s)) return;

            setIdtAtendimento(Convert.ToDecimal(s));
        }
        public void setIdtAtendimento(decimal? d)
        {
            this.ATD_ATE_ID = d;
        }
        public void setIdtAtendimento(decimal d)
        {
            setIdtAtendimento((decimal?)d);
        }
        public decimal? idtAtendimento
        {
            get
            {
                return this.ATD_ATE_ID;
            }
        }
        #endregion ATD_ATE_ID
        #region ID_ATESTADO
        public void setIdtAtestado(string s)
        {
            if (string.IsNullOrEmpty(s)) return;

            setIdtAtestado(Convert.ToDecimal(s));
        }
        public void setIdtAtestado(decimal? d)
        {
            this.ID_ATESTADO = d;
        }
        public void setIdtAtestado(decimal d)
        {
            setIdtAtestado((decimal?)d);
        }
        public decimal? idtAtestado
        {
            get
            {
                return this.ID_ATESTADO;
            }
        }
        #endregion ID_ATESTADO
        #region SEG_USU_ID_USUARIO
        public void setIdtUsuario(string s)
        {
            if (string.IsNullOrEmpty(s)) return;

            setIdtUsuario(Convert.ToDecimal(s));
        }
        public void setIdtUsuario(decimal? d)
        {
            this.SEG_USU_ID_USUARIO = d;
        }
        public void setIdtUsuario(decimal d)
        {
            setIdtUsuario((decimal?)d);
        }
        public decimal? idtUsuario
        {
            get
            {
                return this.SEG_USU_ID_USUARIO;
            }
        }
        #endregion SEG_USU_ID_USUARIO
        #region INI_PERIODO
        public void setInicioPeriodoDeclaracao(string s)
        {
            if (string.IsNullOrEmpty(s)) return;

            setInicioPeriodoDeclaracao(Convert.ToDecimal(s));
        }
        public void setInicioPeriodoDeclaracao(decimal? d)
        {
            this.INI_PERIODO = d;
        }
        public void setInicioPeriodoDeclaracao(decimal d)
        {
            setInicioPeriodoDeclaracao((decimal?)d);
        }
        public decimal? inicioPeriodoDeclaracao
        {
            get
            {
                return this.INI_PERIODO;
            }
        }
        #endregion INI_PERIODO
        #region CAD_PRO_NM_NOME
        public void setNomeMedico(string s)
        {
            this.CAD_PRO_NM_NOME = s;
        }
        public string nomeMedico
        {
            get
            {
                return this.CAD_PRO_NM_NOME;
            }
        }
        #endregion CAD_PRO_NM_NOME
        #region CAD_PES_NM_PESSOA
        public void setNomePessoa(string s)
        {
            this.CAD_PES_NM_PESSOA = s;
        }
        public string nomePessoa
        {
            get
            {
                return this.CAD_PES_NM_PESSOA;
            }
        }
        #endregion CAD_PES_NM_PESSOA
        #region PROTOCOLO
        public void setProtocolo(string s)
        {
            this.PROTOCOLO = s;
        }
        public string protocolo
        {
            get
            {
                return this.PROTOCOLO;
            }
        }
        #endregion PROTOCOLO
        #region DS_RELATORIO
        public void setRelatorio(string s)
        {
            this.DS_RELATORIO = s;
        }
        public string relatorio
        {
            get
            {
                return this.DS_RELATORIO;
            }
        }
        #endregion DS_RELATORIO
        #region CAD_PAC_NR_PRONTUARIO
        public void setRg(string s)
        {
            if (string.IsNullOrEmpty(s)) return;

            setRg(Convert.ToDecimal(s));
        }
        public void setRg(decimal? d)
        {
            this.CAD_PAC_NR_PRONTUARIO = d;
        }
        public void setRg(decimal d)
        {
            setRg((decimal?)d);
        }
        public decimal? rg
        {
            get
            {
                return this.CAD_PAC_NR_PRONTUARIO;
            }
        }
        #endregion CAD_PAC_NR_PRONTUARIO
        #region CAD_SET_ID
        public void setSetorIdt(string s)
        {
            if (string.IsNullOrEmpty(s)) return;

            setSetorIdt(Convert.ToDecimal(s));
        }
        public void setSetorIdt(decimal? d)
        {
            this.CAD_SET_ID = d;
        }
        public void setSetorIdt(decimal d)
        {
            setSetorIdt((decimal?)d);
        }
        public decimal? setorIdt
        {
            get
            {
                return this.CAD_SET_ID;
            }
        }
        #endregion CAD_SET_ID
        #region TP_ATESTADO
        public void setTipo(string s)
        {
            this.TP_ATESTADO = s;
        }
        public string tipo
        {
            get
            {
                return this.TP_ATESTADO;
            }
        }
        #endregion TP_ATESTADO
        /// <summary>
        /// Cria um List a partir de um DataTable
        /// </summary>
        public List<AtestadoDeclaracaoDto> DataTableToList(DataTable dtb)
        {
            List<AtestadoDeclaracaoDto> lista = new List<AtestadoDeclaracaoDto>();
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                AtestadoDeclaracaoDto dto = new AtestadoDeclaracaoDto();
                lista.Add(dto.converteDataRowParaAtestadoDeclaracaoDto(dtb.Rows[i]));
            }
            return lista;
        }
    }
}
