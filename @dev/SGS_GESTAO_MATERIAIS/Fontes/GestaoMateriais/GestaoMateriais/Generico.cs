using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.Seguranca.View;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using HacFramework.Windows.Helpers;
using System.IO;
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;

namespace HospitalAnaCosta.SGS.GestaoMateriais
{
    public class Generico
    {
        #region Objetos Serviço

        private const decimal UTI_GERAL = 201;
        private const decimal UTI_CARDIO = 200;
        private const decimal UTI_TERREO = 2652;

        private CommonSeguranca _commonSeguranca;
        protected CommonSeguranca CommonSeguranca
        {
            get { return _commonSeguranca != null ? _commonSeguranca : _commonSeguranca = new CommonSeguranca(null); }
        }

        // Atendimento
        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }

        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        // Estoque
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject(typeof(IEstoqueLocal)); }
        }

        // Setor
        private ISetor _isetor;
        private ISetor Setor
        {
            get { return _isetor != null ? _isetor : _isetor = (ISetor)Global.Common.GetObject(typeof(ISetor)); }
        }

        // Funcionalidade
        private IUsuarioFuncionalidade _usuFuncionalidade;
        private IUsuarioFuncionalidade UsuarioFuncionalidade
        {
            get { return _usuFuncionalidade != null ? _usuFuncionalidade : _usuFuncionalidade = (IUsuarioFuncionalidade)CommonSeguranca.GetObject(typeof(IUsuarioFuncionalidade)); }
        }

        // MatMedSetorConfig
        private SetorEstoqueConsumoDataTable dtbEstoqueConsumo;

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }

        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
        }        

        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        private IFuncionalidade _funcionalidade;
        private IFuncionalidade Funcionalidade
        {
            get
            {
                return _funcionalidade != null ? _funcionalidade : _funcionalidade =
                    (IFuncionalidade)CommonSeguranca.GetObject(typeof(IFuncionalidade));
            }
        }

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        // private MatMedSetorConfigDataTable dtbMatMedSetorConfig;
        // private MatMedSetorConfigDTO dtoMatMedSetorConfig;
        // private MatMedSetorConfigDTO dtoSetorCfg;

        #endregion

        public static string FormataNumero(decimal? n)
        {
            return (n==null?"0":n.Value.ToString("N0"));
        }

        public static string FormataNumero(decimal? n,int d)
        {
            string formato = "N" + d.ToString();
            return (n == null ? "0" : n.Value.ToString(formato)); 
        }

        public bool ConsultaPacienteTodosOsSetores(PacienteDTO dto)
        {
            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
            bool ret = false;
            // cfg
            dtoCfg.IdtUnidade.Value = dto.IdtUnidade.Value;
            dtoCfg.IdtLocal.Value = dto.IdtLocalAtendimento.Value;
            dtoCfg.Idtsetor.Value = dto.IdtSetor.Value;
            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
            if (dtoCfg.AtendeTodosSetores.Value == 1)
            {
                ret = true;
            }

            return ret;
        }

        public PacienteDTO ObterPaciente(PacienteDTO dto)
        {
            PacienteDataTable dtbAtendimento = new PacienteDataTable();
            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();

            ////// cfg
            dtoCfg.IdtUnidade.Value = dto.IdtUnidade.Value;
            dtoCfg.IdtLocal.Value = dto.IdtLocalAtendimento.Value;
            dtoCfg.Idtsetor.Value = dto.IdtSetor.Value;
            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
            //if (ConsultaPacienteTodosOsSetores(dto))
            //{
            //    if (dto.IdtLocalAtendimento.Value == (int)PacienteDTO.LocalAtendimento.CENTRO_CIRURGICO)
            //        dto.IdtLocalAtendimento.Value = (int)PacienteDTO.LocalAtendimento.INTERNADO;
            //    dto.IdtSetor.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
            //}

            if (!dto.Idt.Value.IsNull )
            {
                try
                {
                    dto = Atendimento.SelChave(dto);

                    if (dto == null)
                    {
                        MessageBox.Show("Não foi encontrado paciente com esta sequência para consumir agora neste setor", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        // txtNroInternacao.Focus();
                        dto = new PacienteDTO();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            //else if (!dto.Idt.Value.IsNull && dtoCfg.IgnoraAlta.Value != 1)
            //{
            //    -- dtbAtendimento = Atendimento.Sel(dto);
            //    dto = Atendimento.SelChave(dto);
            //    //if (dtbAtendimento.Rows.Count > 0)
            //    //{
            //    //    dto = Atendimento.SelChave(dto);
            //    //}
            //    //else
            //    //{
            //    //    dto = new PacienteDTO();
            //    //    MessageBox.Show("Não foi encontrado Paciente Internado com a Informação Digitada", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);                    
            //    //}
            //}
            else
            {
                dto = FrmPacienteSetor.BuscaAtendimento(dto);
            }

            if (dto == null)
            {
                dto = new PacienteDTO();
            }
            else
            {
                if (!dto.DtTransf.Value.IsNull  && dtoCfg.IgnoraAlta.Value != 1)
                {
                    if (Movimento.AtendimentosLiberados().Select("ATD_FL_ABERTO = 1 AND ATD_ATE_ID = " + dto.Idt.Value.ToString(), string.Empty).Length == 0)
                    {
                        MessageBox.Show("Paciente com Alta ou Tranferido deste Setor", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        // txtNroInternacao.Focus();
                        dto = new PacienteDTO();
                    }
                }
                if (!dto.Idt.Value.IsNull)
                {
                    MovimentacaoDTO dtoMovimentacao = new MovimentacaoDTO();
                    dtoMovimentacao.IdtAtendimento.Value = dto.Idt.Value;
                    dtoMovimentacao.IdtUnidade.Value = dto.IdtUnidade.Value;
                    dtoMovimentacao.IdtLocal.Value = dto.IdtLocalAtendimento.Value;
                    dtoMovimentacao.IdtSetor.Value = dto.IdtSetor.Value;
                    //if (!Movimento.PermiteConsumo(dtoMovimentacao))
                    //{
                    //    // MessageBox.Show("Paciente não está mais internado neste Setor, Conta Faturada", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    // dto = new PacienteDTO();
                    //    dto.ContaFaturada.Value = (int)PacienteDTO.Faturada.SIM;
                    //}
                    //else
                    //{
                    //    dto.ContaFaturada.Value = (int)PacienteDTO.Faturada.NAO;
                    //}
                    dto.ContaFaturada.Value = (int)PacienteDTO.Faturada.NAO;
                }
            }
            return dto;
        }

        /// <summary>
        /// controle de combos controlando acesso se usuário pode ou não trocar Unidade/Local/Setor de estoques
        /// </summary>
        /// <param name="cmbUnidade"></param>
        /// <param name="cmbLocal"></param>
        /// <param name="cmbSetor"></param>
        /// <param name="dto"></param>
        public static void ConfiguraCombos(HacCmbUnidade cmbUnidade, HacCmbLocal cmbLocal, HacCmbSetor cmbSetor, SegurancaDTO dto)
        {
            // FrmPrincipal Acesso = new FrmPrincipal();
            Generico generico = new Generico();
            
            Generico.ConfiguraCombos(cmbUnidade, dto);

            if (!generico.VerificaAcessoFuncionalidade("cmbLocal"))
            {
                cmbLocal.Enabled = false;
                cmbLocal.Editavel = ControleEdicao.Nunca;
            }
            if (!generico.VerificaAcessoFuncionalidade("cmbSetor"))
            {
                cmbSetor.Enabled = false;
                cmbSetor.Editavel = ControleEdicao.Nunca;
            }
            
            cmbLocal.SelectedValue = FrmPrincipal.dtoSeguranca.IdtLocal.Value;
            cmbSetor.SelectedValue = FrmPrincipal.dtoSeguranca.IdtSetor.Value;
        }

        public static void ConfiguraCombos(HacCmbUnidade cmbUnidade, SegurancaDTO dto)
        {
            // FrmPrincipal Acesso = new FrmPrincipal();
            Generico generico = new Generico();
            if (!generico.VerificaAcessoFuncionalidade("cmbUnidade"))
            {
                cmbUnidade.Enabled = false;
                cmbUnidade.Editavel = ControleEdicao.Nunca;
            }
            
            cmbUnidade.SelectedValue = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;            
        }

        public bool VerificaAcessoFuncionalidade(string pFuncionalidade)
        {            
            return this.VerificaAcessoFuncionalidade(pFuncionalidade, FrmPrincipal.dtoSeguranca);
        }

        public bool VerificaAcessoFuncionalidade(string pFuncionalidade, SegurancaDTO dtoSeguranca)
        {
            UsuarioFuncionalidadeDTO dtoUsuarioFuncionalidade = new UsuarioFuncionalidadeDTO();
            UsuarioFuncionalidadeDTO dtoRetorno = new UsuarioFuncionalidadeDTO();
            bool retorno = false;

            dtoUsuarioFuncionalidade.IdtUsuario.Value = dtoSeguranca.Idt.Value;
            dtoUsuarioFuncionalidade.IdtUnidade.Value = dtoSeguranca.IdtUnidade.Value;
            dtoUsuarioFuncionalidade.IdtModulo.Value = (decimal)SegurancaDTO.Modulo.GestaoMateriais;
            dtoUsuarioFuncionalidade.NmPagina.Value = pFuncionalidade;

            dtoRetorno = UsuarioFuncionalidade.Obter(dtoUsuarioFuncionalidade);

            if (dtoRetorno != null)
            {
                // USUARIO tem ACESSO
                retorno = true;
            }
            return retorno;
        }

        public UsuarioFuncionalidadeDTO ObterFuncionalidade(string pFuncionalidade)
        {
            UsuarioFuncionalidadeDTO dtoUsuarioFuncionalidade = new UsuarioFuncionalidadeDTO();
            UsuarioFuncionalidadeDTO dtoRetorno = new UsuarioFuncionalidadeDTO();
            
            dtoUsuarioFuncionalidade.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            dtoUsuarioFuncionalidade.IdtUnidade.Value = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;
            dtoUsuarioFuncionalidade.IdtModulo.Value = (decimal)SegurancaDTO.Modulo.GestaoMateriais;
            dtoUsuarioFuncionalidade.NmPagina.Value = pFuncionalidade;

            dtoRetorno = UsuarioFuncionalidade.Obter(dtoUsuarioFuncionalidade);
            return dtoRetorno;
        }

        /// <summary>
        /// Verifica se produto é de uso exclusivo do estoque HAC
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool ProdutoUsoExclusivoHAC(MaterialMedicamentoDTO dto)
        {
            bool retorno = false;
            if (dto.FlFracionado.Value == (decimal)MaterialMedicamentoDTO.Fracionado.SIM )
                retorno = true;
            if (dto.Tabelamedica.Value == ((decimal)MaterialMedicamentoDTO.TipoMatMed.MATERIAL).ToString())
                retorno = true;
            return retorno;
        }


        /// <summary>
        /// Verifica se a unidade passada consome de outro estoque
        /// </summary>
        public SetorEstoqueConsumoDataTable CarregaEstoqueConsumo(SetorEstoqueConsumoDTO dtoConsumo)
        {
            dtbEstoqueConsumo = new SetorEstoqueConsumoDataTable();
            dtbEstoqueConsumo = MatMedSetorConfig.SetorEstoqueConsumoObter(dtoConsumo);
            return dtbEstoqueConsumo;
        }

        /// <summary>
        /// Verifica se alguma outra unidade consome do estoque desta undiade
        /// </summary>
        public SetorEstoqueConsumoDataTable VerificaEstoqueCompartilhado(SetorEstoqueConsumoDTO dtoConsumo)
        {

            dtbEstoqueConsumo = MatMedSetorConfig.SetorEstoqueUnidadesQueConsomemObter(dtoConsumo);
            return dtbEstoqueConsumo;

        }

        /// <summary>
        /// Verifica qual Checkbox está selecionado e retorna filial
        /// </summary>
        /// <param name="Hac">ChkHac</param>
        /// <param name="Acs">ChkAcs</param>
        /// <returns>ID da Filial</returns>
        public decimal RetornaFilial(RadioButton Hac, RadioButton Acs)
        {
            // existem telas que não utilizam o Carrinho
            RadioButton Ce = new RadioButton();
            return this.RetornaFilial(Hac, Acs, Ce);
        }

        /// <summary>
        /// Verifica qual Checkbox está selecionado e retorna filial
        /// </summary>
        /// <param name="Hac">rbHac</param>
        /// <param name="Acs">rbAcs</param>
        /// <param name="Ce">rbCe</param>
        /// <returns>ID da Filial</returns>
        public decimal RetornaFilial(RadioButton Hac, RadioButton Acs, RadioButton Ce)
        {
            return this.RetornaFilial(Hac, Acs, Ce, new RadioButton());
        }

        /// <summary>
        /// Verifica qual Checkbox está selecionado e retorna filial
        /// </summary>
        /// <param name="Hac">rbHac</param>
        /// <param name="Acs">rbAcs</param>
        /// <param name="Ce">rbCe</param>
        /// /// <param name="Ce">rbConsig</param>
        /// <returns>ID da Filial</returns>
        public decimal RetornaFilial(RadioButton Hac, RadioButton Acs, RadioButton Ce, RadioButton Consignado)
        {
            decimal retorna = 0;

            if (Ce.Checked)
            {
                retorna = (decimal)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
            }
            else if (Hac.Checked)
            {
                retorna = (decimal)FilialMatMedDTO.Filial.HAC;
            }
            else if (Acs.Checked)
            {
                retorna = (decimal)FilialMatMedDTO.Filial.ACS;
            }
            else if (Consignado.Checked)
            {
                retorna = (decimal)FilialMatMedDTO.Filial.CONSIGNADO;
            }

            return retorna;
        }

        public static string ObterTipoRequisicaoDescricao(byte idtTipoRequisicao)
        {
            string tipoReq = string.Empty;
            switch (idtTipoRequisicao)
            {
                case (byte)RequisicaoDTO.TipoRequisicao.ESTOQUE_LOCAL_MAT_MED:
                    tipoReq = "ESTOQUE LOCAL MAT/MED";
                    break;
                case (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO:
                    tipoReq = "PERSONALIZADO";
                    break;
                case (byte)RequisicaoDTO.TipoRequisicao.PADRAO:
                    tipoReq = "PADRÃO";
                    break;
                case (byte)RequisicaoDTO.TipoRequisicao.IMPRESSOS_MAT_EXPEDIENTE:
                    tipoReq = "IMPRESSOS E MAT. DE EXPEDIENTE";
                    break;
                case (byte)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA:
                    tipoReq = "CARRINHO DE EMERGÊNCIA";
                    break;
                case (byte)RequisicaoDTO.TipoRequisicao.INTERNACAO_DOMICILIAR:
                    tipoReq = "INTERNAÇÃO DOMICILIAR";
                    break;
                case (byte)RequisicaoDTO.TipoRequisicao.CENTRO_CIRURGICO:
                    tipoReq = "CENTRO CIRÚRGICO";
                    break;
                case (byte)RequisicaoDTO.TipoRequisicao.OUTROS:
                    tipoReq = "OUTROS (AVULSO)";
                    break;
                case (byte)RequisicaoDTO.TipoRequisicao.HIGIENIZACAO:
                    tipoReq = "HIGIENIZAÇÃO";
                    break;
            }
            return tipoReq;
        }

        public static void CarregarComboTipoPedido(ref HacComboBox cmbTipoRequisicao)
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Todos>"));
            list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.INTERNACAO_DOMICILIAR).ToString(), "ATENDIMENTO DOMICILIAR"));
            list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA).ToString(), "CARRINHO DE EMERGÊNCIA"));
            list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.ESTOQUE_LOCAL_MAT_MED).ToString(), "ESTOQUE LOCAL MAT/MED"));
            list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.HIGIENIZACAO).ToString(), "HIGIENIZAÇÃO"));
            list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.IMPRESSOS_MAT_EXPEDIENTE).ToString(), "IMPRESSOS E MATERIAIS DE EXPEDIENTE"));
            list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.MANUTENCAO).ToString(), "MANUTENÇÃO"));
            list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.PADRAO).ToString(), "PADRÃO"));
            list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO).ToString(), "PERSONALIZADO"));
            list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.OUTROS).ToString(), "OUTROS"));            

            cmbTipoRequisicao.ValueMember = ListItem.FieldNames.Key;
            cmbTipoRequisicao.DisplayMember = ListItem.FieldNames.Value;
            cmbTipoRequisicao.DataSource = list;
            cmbTipoRequisicao.IniciaLista();
        }

        public bool ValidarContaFaturadaComNF(decimal idtAtendimento, decimal idtSetor)
        {
            //A priori, validar apenas quando for Centro Cirúrgico e Atendimento Domiciliar
            if (idtSetor == 61 || idtSetor == 2252)
            {
                if (Atendimento.ObterQtdeRegistrosContaFaturadaComNF(idtAtendimento) > 0) return false;
            }
            return true;
        }

        public static string ObterMesAno(byte mes, int ano)
        {
            return string.Format("{0}/{1}", ObterMes(mes, true), ObterAnoAbreviado(ano));
        }

        public static string ObterMesAno(byte mes, int ano, bool abreviar)
        {
            return string.Format("{0}/{1}", ObterMes(mes, abreviar), ObterAnoAbreviado(ano));
        }

        public static string ObterAnoAbreviado(int ano)
        {
            return ano.ToString().Substring(2, 2);
        }

        public static string ObterMes(byte mes, bool abreviar)
        {
            string retorno = null;
            switch (mes)
            {
                case 1: { retorno = abreviar ? "JAN" : "JANEIRO"; break; }
                case 2: { retorno = abreviar ? "FEV" : "FEVEREIRO"; break; }
                case 3: { retorno = abreviar ? "MAR" : "MARÇO"; break; }
                case 4: { retorno = abreviar ? "ABR" : "ABRIL"; break; }
                case 5: { retorno = abreviar ? "MAI" : "MAIO"; break; }
                case 6: { retorno = abreviar ? "JUN" : "JUNHO"; break; }
                case 7: { retorno = abreviar ? "JUL" : "JULHO"; break; }
                case 8: { retorno = abreviar ? "AGO" : "AGOSTO"; break; }
                case 9: { retorno = abreviar ? "SET" : "SETEMBRO"; break; }
                case 10: { retorno = abreviar ? "OUT" : "OUTUBRO"; break; }
                case 11: { retorno = abreviar ? "NOV" : "NOVEMBRO"; break; }
                case 12: { retorno = abreviar ? "DEZ" : "DEZEMBRO"; break; }
            }
            return retorno;
        }

        public static string RemoverAcentos(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";
            else
            {
                byte[] bytes = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(input);
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
        }

        /// <summary>
        /// Exportar de um DataTable para um CSV
        /// </summary>
        /// <param name="dt">DataTable</param>
        public static void ExportarExcel(DataTable dt)
        {
            try
            {
                SaveFileDialog Salvar = new SaveFileDialog();
                Salvar.Filter = "CSV|*.csv";

                DialogResult result = Salvar.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string file = Salvar.FileName;

                    StreamWriter sw = new StreamWriter(file, false);
                    int iColCount = dt.Columns.Count;

                    for (int i = 0; i < iColCount; i++)
                    {
                        sw.Write(dt.Columns[i]);
                        if (i < iColCount - 1)
                        {
                            sw.Write(";");
                        }
                    }
                    sw.Write(sw.NewLine);

                    foreach (DataRow dr in dt.Rows)
                    {
                        for (int i = 0; i < iColCount; i++)
                        {
                            if (!Convert.IsDBNull(dr[i]))
                            {
                                sw.Write(RemoverAcentos(dr[i].ToString()));
                            }
                            if (i < iColCount - 1)
                            {
                                sw.Write(";");
                            }
                        }

                        sw.Write(sw.NewLine);
                    }
                    sw.Close();

                    MessageBox.Show("Arquivo gerado com sucesso.", "Arquivo Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImprimirProtocolo(decimal numProtocolo,
                                      decimal numAtendimento, 
                                      string nomePaciente,
                                      decimal idSetor,
                                      DateTime dataProtocolo)
        {
            string nomeRelatorio = "GM_17_HOMECARE_PROTOCOLO";
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[8];
            DataTable dtPaciente = Atendimento.ObterPaciente(numAtendimento);

            #region Monta Parâmetros

            byte x = 0;

            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_PROTOCOLO_ID", numProtocolo.ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PMTMD_MOV_PROTOCOLO_DATA", dataProtocolo.ToString("dd/MM/yyyy"));
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_SET_ID", idSetor.ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PATD_ATE_ID", numAtendimento.ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PPACIENTE", nomePaciente);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PENDERECO", Atendimento.ObterPacienteEndereco(numAtendimento));
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("USUARIO", FrmPrincipal.dtoSeguranca.Login.Value);
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("DT_NASC", DateTime.Parse(dtPaciente.Rows[0][PacienteDTO.FieldNames.DtNascimento].ToString()).ToString("dd/MM/yyyy"));

            #endregion

            Microsoft.Reporting.WinForms.ReportParameter[] reportParamTemp = new Microsoft.Reporting.WinForms.ReportParameter[x];

            for (int i = 0; i < reportParam.Length; i++)
            {
                if (reportParam[i] == null) break;
                reportParamTemp[i] = reportParam[i];
            }
            reportParam = reportParamTemp;
            reportParamTemp = null;

            FrmReportViewer frmRelatorio = new FrmReportViewer();
            frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);            
        }

        public bool PermitirMovimentacaoItemNaoPadrao(EstoqueLocalDTO dtoEstoque, MaterialMedicamentoDTO dtoMatMed)
        {
            return true; //Liberar sempre (transf./perda) pelo fato do novo processo de baixa direta de personalizado

            //if ((decimal)dtoEstoque.IdtSetor.Value == 61) return true; //Sempre liberar p/ o Centro Cir. a principio (pois não há costume de Pedido Personalizado)
            if ((decimal)dtoMatMed.IdtSubGrupo.Value == 981) return true; //Sempre liberar Antimicrobianos Restritos
            if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM) return true;
            if (dtoEstoque.IdtFilial.Value == (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA) return true;            

            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
            dtoCfg.IdtUnidade.Value = dtoEstoque.IdtUnidade.Value;
            dtoCfg.IdtLocal.Value = dtoEstoque.IdtLocal.Value;
            dtoCfg.Idtsetor.Value = dtoEstoque.IdtSetor.Value;
            DateTime? dtControle = null;

            if (MatMedSetorConfig.ControlaConsumoPacienteSetor(dtoCfg, out dtControle) && //(decimal)dtoEstoque.IdtLocal.Value == 29 &&
                ((decimal)dtoMatMed.IdtGrupo.Value == 6 || (decimal)dtoMatMed.IdtGrupo.Value == 1)) //Barrar apenas MAT/MED HOSPITALAR
            {
                if (dtControle.Value.AddDays(8).Date > DateTime.Now.Date) //Liberar por 1 semana pelo menos após a parametrização
                    return true;

                dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);

                if (dtoEstoque.QtdePadrao.Value.IsNull) dtoEstoque.QtdePadrao.Value = 0;

                if ((decimal)dtoEstoque.QtdePadrao.Value == 0)
                    return false;
            }
            return true;
        }

        public bool ItemBaixaAutomaticaDispensa(MaterialMedicamentoDTO dtoMatMed)
        {
            return true; //Tudo liberado (task 5129)

            if (dtoMatMed.FlReutilizavel.Value.IsNull) dtoMatMed.FlReutilizavel.Value = (byte)MaterialMedicamentoDTO.Fracionado.NAO;
            if (dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.NAO &&
                dtoMatMed.FlReutilizavel.Value == (decimal)MaterialMedicamentoDTO.Reutilizavel.NAO) //APENAS INTEIROS
                return true;

            return false;
        }

        public void AlertarAutorizacaoKitGastro(MaterialMedicamentoDTO dtoMatMed)
        {
            if ((decimal)dtoMatMed.IdtGrupo.Value == 6) //Pesquisar apenas se for material
            {
                MaterialMedicamentoDTO dtoMatMedAux = new MaterialMedicamentoDTO();
                dtoMatMedAux.Idt.Value = dtoMatMed.Idt.Value;
                dtoMatMedAux.FlAtivo.Value = (byte)MaterialMedicamentoDTO.Status.SIM;
                dtoMatMedAux.NomeFantasia.Value = "%GASTR%MIC%";
                MaterialMedicamentoDataTable dtbMatMed = MatMed.Sel(dtoMatMedAux);
                if (dtbMatMed.Rows.Count > 0)
                    MessageBox.Show("ATENÇÃO: Esse material precisa de autorização prévia do convênio. Avisar Recepção da Unidade!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool LogadoManutencao()
        {
            if ((int)FrmPrincipal.dtoSeguranca.IdtSetor.Value == 532) return true;

            return false;
        }

        public bool LogadoSetorFarmacia()
        {
            return SetorFarmacia((int)FrmPrincipal.dtoSeguranca.IdtSetor.Value);
        }

        /// <summary>
        /// Retorna se setor é ou não farmácia
        /// </summary>        
        public bool SetorFarmacia(int idSetor)
        {
            SetorDTO dtoSet = new SetorDTO();
            dtoSet.SetorFarmacia.Value = idSetor;
            if (Setor.Sel(dtoSet).Rows.Count > 0)
                return true;

            return false;
        }

        public bool SetorAlmoxCentral(int idSetor)
        {
            SetorDTO dtoSetor = new SetorDTO();
            dtoSetor.Idt.Value = idSetor;
            dtoSetor = Setor.SelChave(dtoSetor);
            if (dtoSetor.FlAlmoxCentral.Value == (byte)SetorDTO.AlmoxarifadoCentral.SIM) return true;
            return false;
        }

        /// <summary>
        /// Retorna a farmácia que abastece o setor, se houver
        /// </summary>        
        public int? ObterFarmaciaSetor(int idSetorAbastecido)
        {
            SetorDTO dtoSet = new SetorDTO();
            dtoSet.Idt.Value = idSetorAbastecido;
            dtoSet = Setor.SelChave(dtoSet);
            if (!dtoSet.SetorFarmacia.Value.IsNull)
                return (int)dtoSet.SetorFarmacia.Value;

            return null;
        }

        public RequisicaoItensDataTable PedidoOrdenadoKit(RequisicaoItensDTO dtoRI)
        {
            if (RequisicaoItens.ExisteKitAssociadoPedidoAla((int)dtoRI.Idt.Value))
                return RequisicaoItens.SelOrdenadoKit(dtoRI);
            else
                return RequisicaoItens.Sel(dtoRI, false, true);
        }

        /// <summary>
        /// Retorna se UtiGeralCardio está compartilhado com o ALMOXARIFADO UTI (satélite)
        /// </summary>        
        public bool UtiCompartilhada(int idtSetor)
        {
            if (UtiGeralCardio(idtSetor))
            {
                EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();
                dtoEstoque.IdtUnidade.Value = 244; //SANTOS
                dtoEstoque.IdtLocal.Value = 29; //INTERNADO
                dtoEstoque.IdtSetor.Value = idtSetor;
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;

                int idSetorEstoque = Estoque.EstoqueDeConsumo(dtoEstoque);

                if (idSetorEstoque != idtSetor)
                    return true;
                else
                    return false;
            }
            else
                return false;            
        }

        public bool UtiGeralCardio(int idtSetor)
        {
            if (idtSetor != UTI_GERAL && idtSetor != UTI_CARDIO && idtSetor != UTI_TERREO)
                return false;
            else
                return true;
        }

        public bool SetorPediatria(int idtSetor)
        {
            if (idtSetor != 202 && idtSetor != 150 && idtSetor != 2472) //UTI PEDIATRICA MISTA / PEDIATRIA 9. CD / PEDIATRIA (HOSP. DIA)
                return false;
            else
                return true;
        }

        public int? SetorCarrinhoEmergencia(int idtSetor)
        {
            SetorDTO dtoSet = new SetorDTO();
            dtoSet.Idt.Value = idtSetor;
            dtoSet = Setor.SelChave(dtoSet);
            if (!dtoSet.CarrinhoEmergSetorPai.Value.IsNull)
                return (int)dtoSet.CarrinhoEmergSetorPai.Value;

            return null;
        }

        public string SetoresCE_MessageBox(int idtSetorPai)
        {
            SetorDTO dtoSetor = new SetorDTO();
            dtoSetor.CarrinhoEmergSetorPai.Value = idtSetorPai;
            SetorDataTable dtbSetor = Setor.Sel(dtoSetor);
            if (dtbSetor.Rows.Count > 0)
            {
                StringBuilder sbSetor = new StringBuilder();
                sbSetor.Append("Este Setor também é composto pelos seguintes Carrinhos de Emergência na estrutura de Setores:\n\n");

                foreach (DataRow row in dtbSetor.Rows)
                    sbSetor.Append(string.Format("->  {0}\n", ((SetorDTO)row).Descricao.Value));

                return sbSetor.ToString();
            }
            return null;
        }

        public DataTable ListarTipoPedidoFuncionalidade(bool carregaOutros)
        {
            FuncionalidadeDTO dtoFuncionalidade = new FuncionalidadeDTO();
            dtoFuncionalidade.IdtModulo.Value = 43; //Gestao Mat/Med
            dtoFuncionalidade.FlItemMenu.Value = "N";
            dtoFuncionalidade.FiltraAssociados.Value = (int)FuncionalidadeDTO.FiltraFuncionalidade.TODAS_FUNCIONALIDADES;

            FuncionalidadeDataTable dtbFunc = Funcionalidade.Sel(dtoFuncionalidade);
            string strFiltro = "'EstoqueLocalAlasInternacao', 'EstoqueLocalUtiNeo', 'EstoqueLocalTodosProdutos', 'EstoqueLocalAmbulatorio', 'EstoqueLocalHemodinamica', " +
                               "'EstoqueLocalAmbSV', 'EstoqueLocalAmbPG', 'EstoqueLocalAmbCUBATAO', 'EstoqueLocalAmbGUARUJA'";
            if (carregaOutros)
            {
                if (new Generico().VerificaAcessoFuncionalidade("OutrosProdutosAvulsos"))
                    strFiltro += ", 'OutrosProdutosAvulsos'";
            }
            strFiltro = string.Format("{0} IN ({1})", FuncionalidadeDTO.FieldNames.NmPagina, strFiltro);

            return new DataView(dtbFunc, strFiltro, null, DataViewRowState.CurrentRows).ToTable();
        }

        public bool TipoPedidoEntradaAuto(RequisicaoDTO dtoRequisicao)
        {
            if (dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.ESTOQUE_LOCAL_MAT_MED ||
                dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.MANUTENCAO ||
                dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.IMPRESSOS_MAT_EXPEDIENTE ||
                dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.HIGIENIZACAO ||
                dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.OUTROS ||
                dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO)
                return true;

            return false;
        }

        public RequisicaoDTO ObterSetorPedidoAutomaticoVigencia(RequisicaoDTO dtoRequisicao)
        {
            RequisicaoDataTable dtbReq = Requisicao.ListarParamPedidoAuto(dtoRequisicao);
            dtbReq = (RequisicaoDataTable)this.ValidarVigencia(Utilitario.ObterDataHoraServidor(),
                                                               RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraIniVigencia,
                                                               RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraFimVigencia,
                                                               dtbReq);
            if (dtbReq.Rows.Count > 0)
                return dtbReq.TypedRow(0);
            else
                return null;
        }

        public bool SetorPedidoAutomaticoVigencia(int setor)
        {
            RequisicaoDTO dtoReq = new RequisicaoDTO();
            dtoReq.IdtSetor.Value = setor;
            dtoReq = this.ObterSetorPedidoAutomaticoVigencia(dtoReq);
            if (dtoReq != null)
                return true;
            else
                return false;
        }

        public bool TransferirItemParaAlmoxCentral(RequisicaoDTO dtoRequisicao, RequisicaoItensDTO dtoReqItem)
        {
            MovimentacaoDTO dtoMov = new MovimentacaoDTO();

            // unidade de baixa
            dtoMov.IdtUnidadeBaixa.Value = dtoRequisicao.IdtUnidade.Value;
            dtoMov.IdtLocalBaixa.Value = dtoRequisicao.IdtLocal.Value;
            dtoMov.IdtSetorBaixa.Value = dtoRequisicao.IdtSetor.Value;
            dtoMov.IdtFilial.Value = dtoRequisicao.IdtFilial.Value;
            if (!dtoRequisicao.Idt.Value.IsNull) dtoMov.IdtRequisicao.Value = dtoRequisicao.Idt.Value;
            if (!dtoRequisicao.IdtAtendimento.Value.IsNull) dtoMov.IdtAtendimento.Value = dtoRequisicao.IdtAtendimento.Value;

            // unidade de entrada
            dtoMov.IdtUnidade.Value = 244; //SANTOS
            dtoMov.IdtLocal.Value = 33; //ADM
            dtoMov.IdtSetor.Value = 29; //ALMOX. CENTRAL            

            dtoMov.IdtProduto.Value = dtoReqItem.IdtProduto.Value;
            if (!dtoReqItem.IdtLote.Value.IsNull && (decimal)dtoReqItem.IdtLote.Value != 0)
                dtoMov.IdtLote.Value = dtoReqItem.IdtLote.Value;
            dtoMov.Qtde.Value = dtoReqItem.QtdFornecida.Value;

            dtoMov.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.ENTRADA;
            dtoMov.IdtTipoBaixa.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
            dtoMov.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_ENTRADA;
            dtoMov.IdtSubTipoBaixa.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_SAIDA;
            dtoMov.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

            try
            {
                Movimento.TransfereEstoqueProduto(dtoMov);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool TransferirItemDeAlmoxCentralPara(MovimentacaoDTO dtoMovPara)
        {
            MovimentacaoDTO dtoMov = new MovimentacaoDTO();

            // unidade de baixa
            dtoMov.IdtUnidadeBaixa.Value = 244; //SANTOS
            dtoMov.IdtLocalBaixa.Value = 33; //ADM
            dtoMov.IdtSetorBaixa.Value = 29; //ALMOX. CENTRAL
            dtoMov.IdtFilial.Value = dtoMovPara.IdtFilial.Value;
            if (!dtoMovPara.IdtRequisicao.Value.IsNull) dtoMov.IdtRequisicao.Value = dtoMovPara.IdtRequisicao.Value;
            if (!dtoMovPara.IdtAtendimento.Value.IsNull) dtoMov.IdtAtendimento.Value = dtoMovPara.IdtAtendimento.Value;

            // unidade de entrada
            dtoMov.IdtUnidade.Value = dtoMovPara.IdtUnidade.Value;
            dtoMov.IdtLocal.Value = dtoMovPara.IdtLocal.Value;
            dtoMov.IdtSetor.Value = dtoMovPara.IdtSetor.Value;

            dtoMov.IdtProduto.Value = dtoMovPara.IdtProduto.Value;
            if (!dtoMovPara.IdtLote.Value.IsNull && (decimal)dtoMovPara.IdtLote.Value != 0)
                dtoMov.IdtLote.Value = dtoMovPara.IdtLote.Value;

            if (dtoMovPara.Qtde.Value.IsNull) dtoMovPara.Qtde.Value = 1;
                dtoMov.Qtde.Value = dtoMovPara.Qtde.Value;

            dtoMov.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.ENTRADA;
            dtoMov.IdtTipoBaixa.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
            dtoMov.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_ENTRADA;
            dtoMov.IdtSubTipoBaixa.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_SAIDA;
            dtoMov.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

            try
            {
                Movimento.TransfereEstoqueProduto(dtoMov);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public object ValidarVigencia(DateTime _dataValidar, string _dataInicioField, string _dataFimField, object _dtb)
        {
            return Utilitario.ValidarVigencia(_dataValidar, _dataInicioField, _dataFimField, _dtb);
        }

        public string ObterTextoLimitado(string texto, int limite)
        {
            if (texto.Length > limite)
                texto = texto.Remove(limite - 1);            

            return texto;
        }      

        //public string ObterTextoObsComUsuario(string texto, int limite)
        //{
        //    string strRegistroDeInicio = " (REGISTRO DE: ";

        //    if (texto.Length > limite && texto.IndexOf(strRegistroDeInicio) == -1)
        //        texto = texto.Remove(449);
        //    else if (texto.IndexOf(strRegistroDeInicio) > -1)
        //        texto = texto.Remove(texto.IndexOf(strRegistroDeInicio) - 1);

        //    if (texto.Length > 0)
        //    {
        //        if (texto.IndexOf(strRegistroDeInicio) == -1)
        //        {
        //            string usuario = FrmPrincipal.dtoSeguranca.NmUsuario.Value;
        //            texto += strRegistroDeInicio + usuario.Trim() + ")";
        //        }
        //    }

        //    return texto;
        //}        
    }
}