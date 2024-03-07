using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Windows.Forms;
using Microsoft.Win32;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.HomeCare;
using HospitalAnaCosta.SGS.GestaoMateriais.Cadastro;
using HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Gerencial;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.ComponenteMatMed;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Forms;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using HospitalAnaCosta.SGS.Seguranca.View;
using System.Diagnostics;

namespace HospitalAnaCosta.SGS.GestaoMateriais
{ 
    public partial class FrmPrincipal : FrmBase
    { 
        public static SegurancaDTO dtoSeguranca = new SegurancaDTO();
        private string Servidor = string.Empty;
        private int nContadorAcesso = 0;

        #region Cria instancia de todos os Forms do sistema

        private FrmAnaliseEstoqueCustos frmAnaliseEstoqueCustos;
        private FrmPedidoPadrao frmPedidoPadrao;
        private FrmSolicitacaoMaterial frmSolicitacaoMaterial;
        private FrmPersonalizado frmPersonalizado;
        private FrmPedidoEstoqueLocal frmPedidoEstoqueLocal;
        private FrmPrincipioAtivo frmPrincipioAtivo;
        private FrmLogin frmLogin;
        private FrmGrupoMatMed frmGrupoMatMed;
        private FrmConsumoPaciente frmConsumoPaciente;
        private FrmConsumoPacUTI frmConsumoPacienteUTI;        
        private FrmEstoqueOnLine frmEstoqueOnLine;
        private FrmEstoqueOnlineLote frmEstoqueOnLineLote;
        private FrmRegistroPerda frmRegistroPerda;        
        private FrmTransfMatMed frmTransfMatMed;
        private FrmCodBarraMatMed frmCodBarraMatMed;
        private FrmImpressaoPedido frmImpressaoPedido;
        private FrmReqPedidoPad frmReqPedidoPad;
        private FrmRecebUnidade frmRecebUnidade;
        private FrmBaixaProdFrac frmBaixaProdFrac;
        private FrmAcertoEstoque frmAcertoEstoque;
        private FrmConfigUnidade frmConfigUnidade;
        private FrmManutProd frmManutProd;
        private FrmTiposCCusto frmTiposCCusto;
        private FrmImpCodBarra frmImpCodBarra;
        private FrmLancamentoOutraUnidade frmLancamentoOutraUnidade;
        private FrmCfgImpressora frmCfgImpressora;
        private FrmPedidoCarrinhoEmerg frmPedidoCarrinhoEmerg;
        private FrmReqPendente frmReqPendente;
        private FrmDispensacao frmDispensacao;
        private FrmPedidosConsulta frmPedidosConsulta;
        private FrmDivergenciasEstoque frmDivergenciasEstoque;
        private FrmConsultaMovimento frmConsultaMovimento;
        private FrmAtendimentoDomiciliar frmAtendDomiciliar;
        private FrmHomeCare frmHomeCare;
        private FrmConsumoCCirurgico frmConsumoCCirurgico;
        private FrmCfgSeguranca frmCfgSeguranca;
        private FrmRelatorios frmRelatorios;
        private FrmRelatoriosInventario frmRelatoriosInventario;
        private FrmSaldoSetor frmSaldoSetor;
        private FrmRelConsumoPac frmRelConsumoPac;
        private FrmPermissaoMatMedFunc frmPermissaoMatMedFunc;
        private FrmDispKitCirurgico frmDispKitCirurgico;
        private FrmGeraArquivoContabil frmGeraArquivoContabil;
        private FrmInventarioDigitacao frmInventarioDigitacao;
        private FrmInventarioDigitaMed frmInventarioDigitaMed;
        private FrmInventarioRotativo frmInventarioRotativo;
        private FrmCContabilGrupo frmCContabilGrupo;
        private FrmTransfAtd frmTransfAtd;
        private FrmInfMatMed frmInfMatMed;
        private FrmLiberaAtendimento frmLiberaAtendimento;
        private FrmCadKit frmCadKit;
        private FrmPrescricao frmPrescricao;
        private FrmLivroRegistro frmLivroRegistro;
        private FrmRelPrescricaoImp frmRelPrescricao;
        private FrmCancelarItemPedido frmCancelarItemPedido;
        private FrmEstornoItemPedido frmEstornoItemPedido;
        private FrmBookAmil frmBookAmil;
        private FrmVencimentoMed frmVencimentoMed;
        private FrmRastreioLote frmRastreioLote;
        private FrmRelBaixaCCusto frmRelBaixaCCusto;
        private FrmReprocessarAtd frmReprocessarAtd;
        private FrmEmprestimo frmEmprestimo;
        private FrmSetorPedidoAutoParam frmSetorPedidoAutoParam;
        private FrmPedidoAutomaticoSetor frmPedidoAutomaticoSetor;
        private FrmSeparacaoKit frmSeparacaoKit;
        private FrmPrescricaoInt frmPrescricaoInt;
        private FrmKardex frmKardex;
        private FrmConferenciaPedido frmConferenciaPedido;
        private FrmPedidoReplicar frmPedidoReplicar;
        private FrmEstornoItem frmEstornoItem;
        private FrmDevolucaoConsig frmDevolucaoConsig;

        #endregion

        #region DESUSO
        // public event EventHandler eMenuClick;
        /*
        
  /// <summary>
        /// Verifica se existe ENUM com a descrição do item de acesso
        /// </summary>
        /// <param name="itemMenu"></param>
        /// <returns></returns>
        private int ObterIdFuncionalidade(ref ToolStripMenuItem itemMenu)
        {
            int retorno;

            //Verifica se um dos valores do enum FuncionalidadeDTO.Funcionalidades não
            //está associado a este item de menú.
            if (string.IsNullOrEmpty(itemMenu.AccessibleName))
            {
                retorno = -1; //item de menú não associado a nenhum valor do enum.
            }
            else
            {
                //Verifica se o valor, deste item de menu, associado a um dos itens do 
                //enum FuncionalidadeDTO.Funcionalidades existe neste.                
                if (Enum.IsDefined(typeof(FuncionalidadeDTO.Funcionalidades), itemMenu.AccessibleName))
                {
                    retorno = (int)((FuncionalidadeDTO.Funcionalidades)Enum.Parse(typeof(FuncionalidadeDTO.Funcionalidades), itemMenu.AccessibleName));
                }
                else
                {
                    retorno = -1; //item de menú associado a um valor inválido do enum.   
                }                
            }

            return retorno;
        }
        
        /// <summary>
        /// Faz verificação a uma funcionalidade passada como parametro
        /// </summary>
        /// <param name="sFuncionalidade"></param>
        /// <returns></returns>
        //public bool VerificaAcessoFuncionalidade(string sFuncionalidade)
        //{
        //    bool retorno = false;
        //    FuncionalidadeDataTable dtbFuncionalidadesUsuario;
        //    AssPerfilUsuarioDTO dtoAssPerfilUsuario = new AssPerfilUsuarioDTO();
        //    AssPerfilUsuarioDTO dtoPerfilUsuario = new AssPerfilUsuarioDTO();

        //    dtoAssPerfilUsuario.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
        //    dtoAssPerfilUsuario.IdtUnidade.Value = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;
        //    dtoAssPerfilUsuario.IdtModulo.Value = (decimal)SegurancaDTO.Modulo.GestaoMateriais;

        //    //dtbFuncionalidadesUsuario = Funcionalidade.Obter(dtoAssPerfilUsuario);

        //    System.Data.DataRow[] temAcesso;
        //    string sBusca = string.Format("{0} = '{1}'", FuncionalidadeDTO.FieldNames.NmPagina, sFuncionalidade);
        //    //temAcesso = dtbFuncionalidadesUsuario.Select(sBusca);
        //    //if (temAcesso != null)
        //    //{
        //    //    retorno = temAcesso.Length > 0;
        //    //}
        //    return retorno;

        //}
        
        //private void MontarAcesso(MenuStrip menu)
        //{
        //    FuncionalidadeDataTable dtbFuncionalidadesUsuario;
        //    AssPerfilUsuarioDTO dtoAssPerfilUsuario = new AssPerfilUsuarioDTO();            
        //    AssPerfilUsuarioDTO dtoPerfilUsuario = new AssPerfilUsuarioDTO();

        //    dtoAssPerfilUsuario.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
        //    dtoAssPerfilUsuario.IdtUnidade.Value = dtoSeguranca.IdtUnidade.Value;
        //    dtoAssPerfilUsuario.IdtModulo.Value = (decimal)SegurancaDTO.Modulo.GestaoMateriais;

        //    AssPerfilUsuarioDataTable dtbPerfilUsu = AssPerfilUsuario.Sel(dtoAssPerfilUsuario);
          
        //    // dtbFuncionalidadesUsuario = Funcionalidade.Obter(dtoAssPerfilUsuario);

        //    //foreach (ToolStripMenuItem menuItem in menuStrip1.Items)
        //    //{
        //    //    this.AplicarPermissoes(ref dtbFuncionalidadesUsuario, menuItem);
        //    //}
        //}
        
        //private bool ValidarAcesso(FuncionalidadeDataTable dtbFuncionalidadeDataTable, FuncionalidadeDTO dto)
        //{
        //    System.Data.DataRow[] funcionalidades;
        //    bool retorno = false;
        //    // MANTIVE PARA COMPATIBILIDADE COM A BUSCA PELO DTO
        //    funcionalidades = dtbFuncionalidadeDataTable.Select(string.Format("{0} = {1}", FuncionalidadeDTO.FieldNames.Idt, dto.Idt.Value));

        //    if (funcionalidades != null)
        //    {
        //        retorno = funcionalidades.Length > 0;
        //    }
        //    if (!retorno)
        //    {
        //        System.Data.DataRow[] temAcesso;
        //        string sBusca = string.Format("{0} = '{1}'", FuncionalidadeDTO.FieldNames.NmPagina, dto.NmPagina.Value);
        //        temAcesso = dtbFuncionalidadeDataTable.Select(sBusca);
        //        if (temAcesso != null)
        //        {
        //            retorno = temAcesso.Length > 0;
        //        }                
        //    }

        //    return retorno;
        //}
        
        //private void AplicarPermissoes(ref FuncionalidadeDataTable funcionalidadesUsuario, ToolStripMenuItem menuItem)
        //{
        //    if (menuItem.AccessibleName != "SEMPRE_VISIVEL")
        //    {
        //        FuncionalidadeDTO dtoFuncionalidade = new FuncionalidadeDTO();

        //        dtoFuncionalidade.Idt.Value = ObterIdFuncionalidade(ref menuItem);
        //        dtoFuncionalidade.NmPagina.Value = menuItem.AccessibleName;

        //        menuItem.Visible = ValidarAcesso(funcionalidadesUsuario, dtoFuncionalidade);
        //    }

        //    foreach (ToolStripMenuItem menuSubItem in menuItem.DropDownItems)
        //    {
        //        this.AplicarPermissoes(ref funcionalidadesUsuario, menuSubItem);
        //    }
        //}

        
         * 
         * private FrmLiberacaoAlmox_old frmLiberacaoAlmox;          
        private FrmAnalCVProduto frmAnalCVProduto;
        private FrmAnalCVPacote frmAnalCVPacote;
        private FrmIndiceRotatividade frmIndiceRotatividade;          
        private FrmAnaliseConsumo frmAnaliseConsumo;      
        private FrmPrescricaoMedica frmPrescricaoMedica;

         
        public EventHandler eMenuClickHandler
        {
            get { return eMenuClick; }
        }

        
                private void analiseDeConsumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmAnaliseConsumo == null || frmAnaliseConsumo.IsDisposed)
                {
                    frmAnaliseConsumo = new FrmAnaliseConsumo();
                    frmAnaliseConsumo.MdiParent = this;
                }

                frmAnaliseConsumo.Show();
                frmAnaliseConsumo.WindowState = FormWindowState.Normal;
                frmAnaliseConsumo.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 
        
        
         
        private void análiseDeCustoXVendaDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmAnalCVProduto == null || frmAnalCVProduto.IsDisposed)
                {
                    frmAnalCVProduto = new FrmAnalCVProduto();
                    frmAnalCVProduto.MdiParent = this;
                }

                frmAnalCVProduto.Show();
                frmAnalCVProduto.WindowState = FormWindowState.Normal;
                frmAnalCVProduto.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void análiseDeCustoXVendaDePacotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmAnalCVPacote == null || frmAnalCVPacote.IsDisposed)
                {
                    frmAnalCVPacote = new FrmAnalCVPacote();
                    frmAnalCVPacote.MdiParent = this;
                }

                frmAnalCVPacote.Show();
                frmAnalCVPacote.WindowState = FormWindowState.Normal;
                frmAnalCVPacote.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         
         
            private void movimentaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void solicitaçãoMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void dispensaçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmEstoque == null || frmEstoque.IsDisposed)
                {
                    frmEstoque = new FrmEstoque();
                    frmEstoque.MdiParent = this;
                }

                frmEstoque.Show();
                frmEstoque.WindowState = FormWindowState.Normal;
                frmEstoque.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
         
         */

        //public void VerificaLogin(SegurancaDTO dto)
        //{
        //    dtoSeguranca.Idt.Value = dto.Idt.Value;
        //    dtoSeguranca.IdtLocal.Value = dto.IdtLocal.Value;
        //    dtoSeguranca.IdtSetor.Value = dto.IdtSetor.Value;
        //    dtoSeguranca.IdtUnidade.Value = dto.IdtUnidade.Value;
        //    dtoSeguranca.NmUsuario.Value = dto.NmUsuario.Value;
        //    dtoSeguranca.IdtNivelSeguranca.Value = dto.IdtNivelSeguranca.Value;

        //}

        //public static SegurancaDTO InformacaoUsuario()
        //{
        //    return base.dtoSeguranca;
        //}

        #endregion

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇO



        
        private CommonSeguranca _commonSeguranca;
        protected CommonSeguranca CommonSeguranca
        {
            get { return _commonSeguranca != null ? _commonSeguranca : _commonSeguranca = new CommonSeguranca(null); }
        }

        // Funcionalidade
        private IFuncionalidade _funcionalidade;
        private IFuncionalidade Funcionalidade
        {
            get { return _funcionalidade != null ? _funcionalidade : _funcionalidade = (IFuncionalidade)CommonSeguranca.GetObject( typeof(IFuncionalidade)); }
        }

        // UsuarioFuncionalidade
        private IUsuarioFuncionalidade _usuariofuncionalidade;
        private IUsuarioFuncionalidade UsuarioFuncionalidade
        {
            get { return _usuariofuncionalidade != null ? _usuariofuncionalidade : _usuariofuncionalidade = (IUsuarioFuncionalidade)CommonSeguranca.GetObject(typeof(IUsuarioFuncionalidade)); }
        }


        // PerfilUsuario
        private IAssPerfilUsuario _assPerfilUsuario;
        private IAssPerfilUsuario AssPerfilUsuario
        {
            get { return _assPerfilUsuario != null ? _assPerfilUsuario : _assPerfilUsuario = (IAssPerfilUsuario)CommonSeguranca.GetObject(typeof(IAssPerfilUsuario)); }
        }

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        #endregion

        #region Propriedades

        private string DataAtual
        {
            // get { return string.Format("[{0}] {1} {2} ", Servidor, Utilitario.ObterDataHoraServidor().ToLongDateString(), Utilitario.ObterDataHoraServidor().ToLongTimeString()); }
            get { return string.Format("[{0}] {1} {2} ", Servidor, Utilitario.ObterDataHoraServidor().ToLongDateString(), ""); }
        }

        #endregion        

        #region Eventos

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                #region Verifica outras instâncias rodando
                string processo = Process.GetCurrentProcess().ProcessName;
                Process[] localByName = Process.GetProcessesByName("GestaoMateriais");
                //verifica se tem mais de uma instância do sistema na memória
                if (localByName.Length > 1)
                {
                    MessageBox.Show("Já existe uma Versão sendo executada, está janela será fechada");
                    Application.Exit();

                }
                #endregion

            #if !DEBUG

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                if (System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CheckForUpdate())
                {
                    System.Deployment.Application.ApplicationDeployment.CurrentDeployment.Update();
                    MessageBox.Show("A aplicação foi atualizada e será encerrada. Por favor, entre novamente no sistema", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);        
                    Application.Exit();
                }                
            }
            if (ConfigurationManager.AppSettings["HAC.REMOTING.SGS.ACS.GESTAOMATERIAIS.PATH"] == "svchac01.anacosta.com.br")
            {
                Servidor = "Produção"; 
            }
            else
            {
                Servidor = "Homolog";
            }                    
            #else
                Servidor = processo + " - " + ConfigurationManager.AppSettings["HAC.REMOTING.SGS.ACS.GESTAOMATERIAIS.PATH"];
            #endif

               tmrHorario.Stop();
               Login();
               this.tssTime.Text = DataAtual;
               tmrHorario.Start();
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Mensagem Conexão Iniciando Sistema");
            }

        }

        private void tmrHorario_Tick(object sender, EventArgs e)
        {
            nContadorAcesso = nContadorAcesso + 1; // 1 minuto

            if (nContadorAcesso == 1000) // 5 minutos ?
            {
                this.tssTime.Text = DataAtual; // se der erro serviço está em manutenção
                this.tssTime.ToolTipText = string.Format("{0} {1} {2}","Último Acesso ",Utilitario.ObterDataHoraServidor().ToLongDateString(),Utilitario.ObterDataHoraServidor().ToLongTimeString());
#if !DEBUG
                // verifica se existe nova versão
                if (System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CheckForUpdate())
                {
                }
#endif
                nContadorAcesso = 0;
            }
        }

        private void pedidoAoPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmPersonalizado == null || frmPersonalizado.IsDisposed)
                {
                    frmPersonalizado = new FrmPersonalizado();
                    frmPersonalizado.MdiParent = this;
                }
                frmPersonalizado.Show();
                frmPersonalizado.WindowState = FormWindowState.Normal;
                frmPersonalizado.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ShowError(new HacException("Erro de Sistema.", ex));
                //MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pedidoAoEstoqueLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmPedidoEstoqueLocal == null || frmPedidoEstoqueLocal.IsDisposed)
                {
                    frmPedidoEstoqueLocal = new FrmPedidoEstoqueLocal();
                    frmPedidoEstoqueLocal.MdiParent = this;
                }
                frmPedidoEstoqueLocal.Show();
                frmPedidoEstoqueLocal.WindowState = FormWindowState.Normal;
                frmPedidoEstoqueLocal.Focus();
            }
            catch (HacException ex)
            {                
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ShowError(new HacException("Erro de Sistema.", ex));             
            }
        }    

        private void liberaçãoDeRequisiçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmDispensacao == null || frmDispensacao.IsDisposed)
                {
                    frmDispensacao = new FrmDispensacao();
                    frmDispensacao.MdiParent = this;
                }

                frmDispensacao.Show();
                frmDispensacao.WindowState = FormWindowState.Normal;
                frmDispensacao.Focus();
            }
            catch (HacException ex)
            {
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void estoqueOnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void princípioAtivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmPrincipioAtivo == null || frmPrincipioAtivo.IsDisposed)
                {
                    frmPrincipioAtivo = new FrmPrincipioAtivo();
                    frmPrincipioAtivo.MdiParent = this;
                }
                frmPrincipioAtivo.Show();
                frmPrincipioAtivo.WindowState = FormWindowState.Normal;
                frmPrincipioAtivo.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no Sistema : {0}", ex.Message), "Gestão de Materiais e medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ShowError(new HacException("Erro de Sistema.", ex));
            }

        }

        private void gruposSubGruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmGrupoMatMed == null || frmGrupoMatMed.IsDisposed)
                {
                    frmGrupoMatMed = new FrmGrupoMatMed();
                    frmGrupoMatMed.MdiParent = this;
                }
                frmGrupoMatMed.Show();
                frmGrupoMatMed.WindowState = FormWindowState.Normal;
                frmGrupoMatMed.Focus();
            }
            catch (HacException ex)
            {
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void consumoPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmConsumoPaciente == null || frmConsumoPaciente.IsDisposed)
                {
                    frmConsumoPaciente = new FrmConsumoPaciente();
                    frmConsumoPaciente.MdiParent = this;
                }
                frmConsumoPaciente.Show();
                frmConsumoPaciente.WindowState = FormWindowState.Normal;
                frmConsumoPaciente.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema (HAC EXCEPTION) - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void indiceDeRotatividadeEConsumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmAnaliseEstoqueCustos == null || frmAnaliseEstoqueCustos.IsDisposed)
                {
                    frmAnaliseEstoqueCustos = new FrmAnaliseEstoqueCustos();
                    frmAnaliseEstoqueCustos.MdiParent = this;
                }
                frmAnaliseEstoqueCustos.Show();
                frmAnaliseEstoqueCustos.WindowState = FormWindowState.Normal;
                frmAnaliseEstoqueCustos.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registroPerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmRegistroPerda == null || frmRegistroPerda.IsDisposed)
                {
                    frmRegistroPerda = new FrmRegistroPerda();
                    frmRegistroPerda.MdiParent = this;
                }
                frmRegistroPerda.Show();
                frmRegistroPerda.WindowState = FormWindowState.Normal;
                frmRegistroPerda.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuPedidoPadrao_Click(object sender, EventArgs e)
        {

            try
            {
                if (frmPedidoPadrao == null || frmPedidoPadrao.IsDisposed)
                {
                    frmPedidoPadrao = new FrmPedidoPadrao();
                    frmPedidoPadrao.MdiParent = this;
                }
                frmPedidoPadrao.Show();
                frmPedidoPadrao.WindowState = FormWindowState.Normal;
                frmPedidoPadrao.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuEstoqueOnLine_Click(object sender, EventArgs e)
        {
            try
            {
#if DEBUG
                //if (frmEstoqueOnLine == null || frmEstoqueOnLine.IsDisposed)
                //{
                    frmEstoqueOnLine = new FrmEstoqueOnLine();
                    frmEstoqueOnLine.MdiParent = this;
                // }

#else
                if (frmEstoqueOnLine == null || frmEstoqueOnLine.IsDisposed)
                {
                    frmEstoqueOnLine = new FrmEstoqueOnLine();
                    frmEstoqueOnLine.MdiParent = this;
                }
#endif
                frmEstoqueOnLine.Show();
                frmEstoqueOnLine.WindowState = FormWindowState.Normal;
                frmEstoqueOnLine.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuRequisiçãoDeMateriais_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmSolicitacaoMaterial == null || frmSolicitacaoMaterial.IsDisposed)
                {
                    frmSolicitacaoMaterial = new FrmSolicitacaoMaterial();
                    frmSolicitacaoMaterial.MdiParent = this;
                }
                frmSolicitacaoMaterial.Show();
                frmSolicitacaoMaterial.WindowState = FormWindowState.Normal;
                frmSolicitacaoMaterial.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void transferênciaMatMedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmTransfMatMed == null || frmTransfMatMed.IsDisposed)
                {
                    frmTransfMatMed = new FrmTransfMatMed();
                    frmTransfMatMed.MdiParent = this;
                }
                frmTransfMatMed.Show();
                frmTransfMatMed.WindowState = FormWindowState.Normal;
                frmTransfMatMed.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !this.PodeFechar;

            if (!e.Cancel) Application.Exit();
        }

        private void codigoBarraStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmCodBarraMatMed == null || frmCodBarraMatMed.IsDisposed)
                {
                    frmCodBarraMatMed = new FrmCodBarraMatMed();
                    frmCodBarraMatMed.MdiParent = this;
                }

                frmCodBarraMatMed.Show();
                frmCodBarraMatMed.WindowState = FormWindowState.Normal;
                frmCodBarraMatMed.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void impressaoDePedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmImpressaoPedido == null || frmImpressaoPedido.IsDisposed)
                {
                    frmImpressaoPedido = new FrmImpressaoPedido();
                    frmImpressaoPedido.MdiParent = this;
                }

                frmImpressaoPedido.Show();
                frmImpressaoPedido.WindowState = FormWindowState.Normal;
                frmImpressaoPedido.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void liberaçãoDePedidoPadrãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmReqPedidoPad == null || frmReqPedidoPad.IsDisposed)
                {
                    frmReqPedidoPad = new FrmReqPedidoPad();
                    frmReqPedidoPad.MdiParent = this;
                }

                this.Cursor = Cursors.WaitCursor;
                frmReqPedidoPad.Show();
                this.Cursor = Cursors.Default;
                frmReqPedidoPad.WindowState = FormWindowState.Normal;
                frmReqPedidoPad.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void recebimentoRequisiçãoSetorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmRecebUnidade == null || frmRecebUnidade.IsDisposed)
                {
                    frmRecebUnidade = new FrmRecebUnidade();
                    frmRecebUnidade.MdiParent = this;
                }

                frmRecebUnidade.Show();
                frmRecebUnidade.WindowState = FormWindowState.Normal;
                frmRecebUnidade.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void baixaProdutoFracionadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmBaixaProdFrac == null || frmBaixaProdFrac.IsDisposed)
                {
                    frmBaixaProdFrac = new FrmBaixaProdFrac();
                    frmBaixaProdFrac.MdiParent = this;
                }
                frmBaixaProdFrac.Show();
                frmBaixaProdFrac.WindowState = FormWindowState.Normal;
                frmBaixaProdFrac.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void acertoDeEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (frmAcertoEstoque == null || frmAcertoEstoque.IsDisposed)
                {
                    frmAcertoEstoque = new FrmAcertoEstoque();
                    frmAcertoEstoque.MdiParent = this;
                }
                frmAcertoEstoque.Show();
                frmAcertoEstoque.WindowState = FormWindowState.Normal;
                frmAcertoEstoque.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void configuraçãoDeUnidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmConfigUnidade == null || frmConfigUnidade.IsDisposed)
                {
                    frmConfigUnidade = new FrmConfigUnidade();
                    frmConfigUnidade.MdiParent = this;
                }
                frmConfigUnidade.Show();
                frmConfigUnidade.WindowState = FormWindowState.Normal;
                frmConfigUnidade.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void manutençãoDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmManutProd == null || frmManutProd.IsDisposed)
                {
                    frmManutProd = new FrmManutProd();
                    frmManutProd.MdiParent = this;
                }

                frmManutProd.Show();
                frmManutProd.WindowState = FormWindowState.Normal;
                frmManutProd.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tiposDeCentroDeCustoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmTiposCCusto == null || frmTiposCCusto.IsDisposed)
                {
                    frmTiposCCusto = new FrmTiposCCusto();
                    frmTiposCCusto.MdiParent = this;
                }

                frmTiposCCusto.Show();
                frmTiposCCusto.WindowState = FormWindowState.Normal;
                frmTiposCCusto.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void impressãoEtiquetasCodBarraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmImpCodBarra == null || frmImpCodBarra.IsDisposed)
                {
                    frmImpCodBarra = new FrmImpCodBarra();
                    frmImpCodBarra.MdiParent = this;
                }

                frmImpCodBarra.Show();
                frmImpCodBarra.WindowState = FormWindowState.Normal;
                frmImpCodBarra.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void baixaDeMatMedEmOutraUnidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmLancamentoOutraUnidade == null || frmLancamentoOutraUnidade.IsDisposed)
                {
                    frmLancamentoOutraUnidade = new FrmLancamentoOutraUnidade();
                    frmLancamentoOutraUnidade.MdiParent = this;
                }

                frmLancamentoOutraUnidade.Show();
                frmLancamentoOutraUnidade.WindowState = FormWindowState.Normal;
                frmLancamentoOutraUnidade.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void configuraçãoImpressorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmCfgImpressora == null || frmCfgImpressora.IsDisposed)
                {
                    frmCfgImpressora = new FrmCfgImpressora();
                    frmCfgImpressora.MdiParent = this;
                }

                frmCfgImpressora.Show();
                frmCfgImpressora.WindowState = FormWindowState.Normal;
                frmCfgImpressora.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pedidoCarrinhoDeEmergênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmPedidoCarrinhoEmerg == null || frmPedidoCarrinhoEmerg.IsDisposed)
                {
                    frmPedidoCarrinhoEmerg = new FrmPedidoCarrinhoEmerg();
                    frmPedidoCarrinhoEmerg.MdiParent = this;
                }

                frmPedidoCarrinhoEmerg.Show();
                frmPedidoCarrinhoEmerg.WindowState = FormWindowState.Normal;
                frmPedidoCarrinhoEmerg.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void versãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVersao frmversão = new FrmVersao();
            frmversão.Show();
        }

        private void geraçãoDePedidosPendentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmReqPendente == null || frmReqPendente.IsDisposed)
                {
                    frmReqPendente = new FrmReqPendente(); 
                    frmReqPendente.MdiParent = this;
                }

                frmReqPendente.Show();
                frmReqPendente.WindowState = FormWindowState.Normal;
                frmReqPendente.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pesquisaDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmPedidosConsulta == null || frmPedidosConsulta.IsDisposed)
                {
                    frmPedidosConsulta = new FrmPedidosConsulta();
                    frmPedidosConsulta.MdiParent = this;
                }

                frmPedidosConsulta.Show();
                frmPedidosConsulta.WindowState = FormWindowState.Normal;
                frmPedidosConsulta.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registrosDeDivergênciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmDivergenciasEstoque == null || frmDivergenciasEstoque.IsDisposed)
                {
                    frmDivergenciasEstoque = new FrmDivergenciasEstoque();
                    frmDivergenciasEstoque.MdiParent = this;
                }

                frmDivergenciasEstoque.Show();
                frmDivergenciasEstoque.WindowState = FormWindowState.Normal;
                frmDivergenciasEstoque.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pesquisaDeMovimentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmConsultaMovimento == null || frmConsultaMovimento.IsDisposed)
                {
                    frmConsultaMovimento = new FrmConsultaMovimento();
                    frmConsultaMovimento.MdiParent = this;
                }

                frmConsultaMovimento.Show();
                frmConsultaMovimento.WindowState = FormWindowState.Normal;
                frmConsultaMovimento.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmiAtendimentoDomiciliar_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmAtendDomiciliar == null || frmAtendDomiciliar.IsDisposed)
                {
                    frmAtendDomiciliar = new FrmAtendimentoDomiciliar();
                    frmAtendDomiciliar.MdiParent = this;
                }

                frmAtendDomiciliar.Show();
                frmAtendDomiciliar.WindowState = FormWindowState.Normal;
                frmAtendDomiciliar.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }    

        private void internaçãoDomiciliarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmHomeCare == null || frmHomeCare.IsDisposed)
                {
                    frmHomeCare = new FrmHomeCare();
                    frmHomeCare.MdiParent = this;
                }

                frmHomeCare.Show();
                frmHomeCare.WindowState = FormWindowState.Normal;
                frmHomeCare.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void desconectarUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Fecha todos os forms abertos
            this.Cursor = Cursors.WaitCursor;
            foreach (Form frm in this.MdiChildren)
                frm.FindForm().Close();
            this.Cursor = Cursors.Default;
                        
            Login();
        }

        private void mnuCalculadora_Click(object sender, EventArgs e)
        {
            Process calc = new Process();
            calc.StartInfo.FileName = "calc.exe";
            calc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            calc.Start();

        }

        private void consumoCentroCirurgicoItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmConsumoCCirurgico == null || frmConsumoCCirurgico.IsDisposed)
                {
                    frmConsumoCCirurgico = new FrmConsumoCCirurgico();
                    frmConsumoCCirurgico.MdiParent = this;
                }

                frmConsumoCCirurgico.Show();
                frmConsumoCCirurgico.WindowState = FormWindowState.Normal;
                frmConsumoCCirurgico.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relatórioFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmRelatorios == null || frmRelatorios.IsDisposed)
                {
                    frmRelatorios = new FrmRelatorios();
                    frmRelatorios.MdiParent = this;
                }
                else
                {
                    if (!frmRelatorios.Fechamento)
                    {
                        frmRelatorios.Dispose();
                        frmRelatorios.Close();
                        frmRelatorios = new FrmRelatorios();
                        frmRelatorios.MdiParent = this;
                    }
                }                
                frmRelatorios.Fechamento = true;
                frmRelatorios.Show();
                frmRelatorios.WindowState = FormWindowState.Normal;
                frmRelatorios.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmRelatorios == null || frmRelatorios.IsDisposed)
                {
                    frmRelatorios = new FrmRelatorios();
                    frmRelatorios.MdiParent = this;
                }
                else
                {
                    if (frmRelatorios.Fechamento)
                    {
                        frmRelatorios.Dispose();
                        frmRelatorios.Close();
                        frmRelatorios = new FrmRelatorios();
                        frmRelatorios.MdiParent = this;
                    }
                }
                frmRelatorios.Fechamento = false;
                frmRelatorios.Show();
                frmRelatorios.WindowState = FormWindowState.Normal;
                frmRelatorios.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relatóriosInventárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmRelatoriosInventario == null || frmRelatoriosInventario.IsDisposed)
                {
                    frmRelatoriosInventario = new FrmRelatoriosInventario();
                    frmRelatoriosInventario.MdiParent = this;
                }
                frmRelatoriosInventario.Show();
                frmRelatoriosInventario.WindowState = FormWindowState.Normal;
                frmRelatoriosInventario.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   

        private void mnuSeguranca_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmCfgSeguranca == null || frmCfgSeguranca.IsDisposed)
                {
                    frmCfgSeguranca = new FrmCfgSeguranca();
                    frmCfgSeguranca.MdiParent = this;
                }
                frmCfgSeguranca.dtoSegurancaLocal.Idt.Value = dtoSeguranca.Idt.Value;
                frmCfgSeguranca.Show();
                frmCfgSeguranca.WindowState = FormWindowState.Normal;
                frmCfgSeguranca.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void permissãoProdutoFuncionalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmPermissaoMatMedFunc == null || frmPermissaoMatMedFunc.IsDisposed)
                {
                    frmPermissaoMatMedFunc = new FrmPermissaoMatMedFunc();
                    frmPermissaoMatMedFunc.MdiParent = this;
                }

                frmPermissaoMatMedFunc.Show();
                frmPermissaoMatMedFunc.WindowState = FormWindowState.Normal;
                frmPermissaoMatMedFunc.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        #endregion

        #region EVENTOS DO MENU

        private void AjudaClick(object sender, EventArgs e)
        {
            // MessageBox.Show("Ajuda");
            //LinkLabel... lnkMsft.Links[lnkMsft.Links.IndexOf(e.Link)].Visited = true;
            //System.Diagnostics.Process.Start(lnkMsft.Text);
            //System.Diagnostics.Process.Start("\\\\APPHAC02\\Manuais\\SGS-Manual Operacional - Gestão de Materiais\\SGS - Manual Operacional - Gestão de Materiais _atualizado 15-07-2010_ - Almoxarifado.pdf");
            //System.Diagnostics.Process.Start("\\\\APPHAC02\\Manuais\\SGS-Manual Operacional - Gestão de Materiais\\index.htm");
            //System.Diagnostics.Process.Start("http://APPHAC02/Manuais/SGS-Manual Operacional - Gestão de Materiais/index.htm");
            //System.Diagnostics.Process.Start("http://iishac01/Manuais/SGS-Manual Operacional - Gestão de Materiais/index.htm");
            System.Diagnostics.Process.Start(ConfigurationSettings.AppSettings["ManualURL"]);
        }

        private void CCirurgicoClick(object sender, EventArgs e)
        {
            // MessageBox.Show("Centro Cirurgico");
            System.Diagnostics.Process.Start("\\\\iishac01\\Manuais\\SGS-Manual Operacional - Gestão de Materiais\\SGS - Manual Operacional - Gestão de Materiais (atualizado 15-07-2010)-Centro Cirurgico.pdf");
        }

        private void MsgTesteClick(object sender, EventArgs e)
        {
            FrmMensagem frmErro = new FrmMensagem();
            frmErro.MdiParent = this;
            frmErro.Show();

        }

        private void MenuTestesClick(object sender, EventArgs e)
        {
            try
            {

                if (frmGeraArquivoContabil == null || frmGeraArquivoContabil.IsDisposed)
                {
                    frmGeraArquivoContabil = new FrmGeraArquivoContabil();
                    frmGeraArquivoContabil.MdiParent = this;
                }

                frmGeraArquivoContabil.Show();
                frmGeraArquivoContabil.WindowState = FormWindowState.Normal;
                frmGeraArquivoContabil.Focus();



            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region Métodos

        protected void ConfiguraServidor()
        {

        }

        /// <summary>
        /// Propriedade para verificar se o form pode ser fechado
        /// </summary>
        public bool PodeFechar
        {
            get
            {
                // Adicionar o form instanciado neste array
                FrmBase[] arrFrm ={ 
                 frmAnaliseEstoqueCustos, frmPedidoPadrao, frmSolicitacaoMaterial, frmPersonalizado,
                 frmPrincipioAtivo,frmGrupoMatMed, frmEstoqueOnLine};

                bool vBool = true;

                foreach (FrmBase form in arrFrm)
                {
                    if (form != null && !form.IsDisposed)
                    {
                        form.Focus();
                        form.Close();
                        if ((!form.IsDisposed) & (vBool))
                        {
                            vBool = false;
                        }
                    }
                }

                return vBool;
            }
        }

        private void Login()
        {
            #region LOGIN
            try
            {
                dtoSeguranca = new SegurancaDTO();
                lblMessage.Text = string.Empty;
                if (frmLogin == null || frmLogin.IsDisposed)
                {
                    frmLogin = new FrmLogin();
                }
                menuStrip1.Enabled = false;
                menuStrip1.Visible = false;
                dtoSeguranca = FrmLogin.Logar(false);
                // dtoSeguranca.Servidor.Value = "SGSDEV";
                if (dtoSeguranca.Login.Value == null)
                {
                    MessageBox.Show(" Problema na Autenticação do Usuário ","Gestão de Materiais e Medicamentos",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    Application.Exit();
                }
                menuStrip1.Enabled = true;
                menuStrip1.Visible = true;
                lblMessage.Text = dtoSeguranca.Login.Value;
                if (!dtoSeguranca.NmUsuario.Value.IsNull)
                {
                    if (dtoSeguranca.NmUsuario.Value.ToString() != string.Empty) lblMessage.Text = dtoSeguranca.NmUsuario.Value;
                    statusSetor.Text = string.Format("{0} / {1} / {2}", dtoSeguranca.DsUnidade.Value, dtoSeguranca.DsLocal.Value, dtoSeguranca.DsSetor.Value);
                }
                CriaMenus();
                // MontarAcesso(menuStrip1);
                MontaMenuUsuario(menuStrip1);
            
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
         
            #endregion
        }

        /// <summary>
        /// Faz verificação de segurança para acesso aos itens do menu
        /// </summary>
        /// <param name="menu"></param>
        private void MontaMenuUsuario(MenuStrip menu)
        {
            UsuarioFuncionalidadeDTO dtoUsuarioFuncionalidade = new UsuarioFuncionalidadeDTO();
            UsuarioFuncionalidadeDTO dtoRetorno = new UsuarioFuncionalidadeDTO();

            dtoUsuarioFuncionalidade.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            dtoUsuarioFuncionalidade.IdtUnidade.Value = dtoSeguranca.IdtUnidade.Value;
            dtoUsuarioFuncionalidade.IdtModulo.Value = (decimal)SegurancaDTO.Modulo.GestaoMateriais;

            foreach (ToolStripMenuItem menuItem in menu.Items)
            {
                menuItem.Enabled = true;
                menuItem.Visible = true;
                if (menuItem.AccessibleName != "SEMPRE_VISIVEL")
                {
                    if (menuItem.AccessibleName == string.Empty)
                    {
                        // esta vazio deixa desabilitado para saber e poder arrumar
                        menuItem.Enabled = false;
                    }
                    else
                    {
                        dtoUsuarioFuncionalidade.NmPagina.Value = menuItem.AccessibleName;
                        // BUSCA FUNCIONALIDADE
                        dtoRetorno = UsuarioFuncionalidade.Obter(dtoUsuarioFuncionalidade);
                        if (dtoRetorno == null)
                        {
                            // USUARIO NAO TEM ACESSO
                            menuItem.Visible = false;
                        }
                    }
                }
                // SUBITENS
                foreach (ToolStripMenuItem menuSubItem in menuItem.DropDownItems)
                {
                    menuSubItem.Enabled = true;
                    menuSubItem.Visible = true;
                    if (menuSubItem.AccessibleName != "SEMPRE_VISIVEL")
                    {
                        if (menuSubItem.AccessibleName == string.Empty)
                        {
                            // esta vazio deixa desabilitado para saber e poder arrumar
                            menuSubItem.Enabled = false;
                        }
                        else
                        {
                            dtoUsuarioFuncionalidade.NmPagina.Value = menuSubItem.AccessibleName;
                            dtoRetorno = UsuarioFuncionalidade.Obter(dtoUsuarioFuncionalidade);
                            if (dtoRetorno == null)
                            {
                                menuSubItem.Visible = false;
                            }
                        }
                    }   
                }
            }
            


        }

        private void CriaMenus()
        {
            if (menuStrip1.Items[5].Text != "Manuais")
            {
                ToolStripMenuItem mnAjudaItem = new ToolStripMenuItem();
                mnAjudaItem.Text = "Manuais";
                mnAjudaItem.AccessibleName = "SEMPRE_VISIVEL";
                ToolStripMenuItem mnAjudaSub = new ToolStripMenuItem();
                //mnAjudaSub.Text = "Almoxarifado";
                mnAjudaSub.Text = "Manual Gestão de Materiais e Medicamentos";
                mnAjudaSub.AccessibleName = "SEMPRE_VISIVEL";
                mnAjudaSub.Click += AjudaClick;
                mnAjudaItem.DropDownItems.Add(mnAjudaSub);
                // OUTRO ITEM
                //mnAjudaSub = new ToolStripMenuItem();
                //mnAjudaSub.Text = "Centro Cirurgico";
                //mnAjudaSub.AccessibleName = "SEMPRE_VISIVEL";
                //mnAjudaSub.Click += CCirurgicoClick;
                //mnAjudaItem.DropDownItems.Add(mnAjudaSub);
#if DEBUG
                // ITEM
                mnAjudaSub = new ToolStripMenuItem();
                mnAjudaSub.Text = "Gera Arquivo";
                mnAjudaSub.AccessibleName = "SEMPRE_VISIVEL";
                mnAjudaSub.Click += MenuTestesClick;
                mnAjudaItem.DropDownItems.Add(mnAjudaSub);
                // ITEM
                mnAjudaSub = new ToolStripMenuItem();
                mnAjudaSub.Text = "Mensagem Erro";
                mnAjudaSub.AccessibleName = "SEMPRE_VISIVEL";
                mnAjudaSub.Click += MsgTesteClick;
                mnAjudaItem.DropDownItems.Add(mnAjudaSub);


#endif

                menuStrip1.Items.Insert(5, mnAjudaItem);
                menuStrip1.Items[5].Visible = true;
            }
        }

        #endregion                               

        private void dispensaçãoKitCentroCirurgicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // frmDispKitCirurgico
            try
            {
                if (frmDispKitCirurgico == null || frmDispKitCirurgico.IsDisposed)
                {
                    frmDispKitCirurgico = new FrmDispKitCirurgico();
                    frmDispKitCirurgico.MdiParent = this;
                }

                frmDispKitCirurgico.Show();
                frmDispKitCirurgico.WindowState = FormWindowState.Normal;
                frmDispKitCirurgico.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void inventárioDigitaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmInventarioDigitacao == null || frmInventarioDigitacao.IsDisposed)
                {
                    frmInventarioDigitacao = new FrmInventarioDigitacao();
                    frmInventarioDigitacao.MdiParent = this;
                }

                frmInventarioDigitacao.Show();
                frmInventarioDigitacao.WindowState = FormWindowState.Normal;
                frmInventarioDigitacao.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void inventárioMedicamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmInventarioDigitaMed == null || frmInventarioDigitaMed.IsDisposed)
                {
                    frmInventarioDigitaMed = new FrmInventarioDigitaMed();
                    frmInventarioDigitaMed.MdiParent = this;
                }

                frmInventarioDigitaMed.Show();
                frmInventarioDigitaMed.WindowState = FormWindowState.Normal;
                frmInventarioDigitaMed.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   
        
        private void tsmiCContabilGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmCContabilGrupo == null || frmCContabilGrupo.IsDisposed)
                {
                    frmCContabilGrupo = new FrmCContabilGrupo();
                    frmCContabilGrupo.MdiParent = this;
                }

                frmCContabilGrupo.Show();
                frmCContabilGrupo.WindowState = FormWindowState.Normal;
                frmCContabilGrupo.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void transferênciaAtendimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmTransfAtd == null || frmTransfAtd.IsDisposed)
                {
                    frmTransfAtd = new FrmTransfAtd();
                    frmTransfAtd.MdiParent = this;
                }

                frmTransfAtd.Show();
                frmTransfAtd.WindowState = FormWindowState.Normal;
                frmTransfAtd.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relatórioInfMatMedHACEACSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmInfMatMed == null || frmInfMatMed.IsDisposed)
                {
                    frmInfMatMed = new FrmInfMatMed();
                    frmInfMatMed.MdiParent = this;
                }

                frmInfMatMed.Show();
                frmInfMatMed.WindowState = FormWindowState.Normal;
                frmInfMatMed.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void liberarAjusteAtendimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmLiberaAtendimento == null || frmLiberaAtendimento.IsDisposed)
                {
                    frmLiberaAtendimento = new FrmLiberaAtendimento();
                    frmLiberaAtendimento.MdiParent = this;
                }

                frmLiberaAtendimento.Show();
                frmLiberaAtendimento.WindowState = FormWindowState.Normal;
                frmLiberaAtendimento.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relatórioAtendimentoDomiciliarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmSaldoSetor == null || frmSaldoSetor.IsDisposed)
                {
                    frmSaldoSetor = new FrmSaldoSetor();
                    frmSaldoSetor.MdiParent = this;
                }
                frmSaldoSetor.BaixasPacienteSetor = true;
                frmSaldoSetor.AtendimentoDomiciliar = true;
                frmSaldoSetor.Show();
                frmSaldoSetor.WindowState = FormWindowState.Normal;
                frmSaldoSetor.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relatórioConsumoPorPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmRelConsumoPac == null || frmRelConsumoPac.IsDisposed)
                {
                    frmRelConsumoPac = new FrmRelConsumoPac();
                    frmRelConsumoPac.MdiParent = this;
                }
                frmRelConsumoPac.Show();
                frmRelConsumoPac.WindowState = FormWindowState.Normal;
                frmRelConsumoPac.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void consumoPacienteUTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TELA INDISPONÍVEL !!!\n\nAgora deverão ser utilizadas as telas de Dispensação e Consumo Paciente p/ baixar personalizados referentes às UTIs GERAL/CARDIO/ TERREO.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //try
            //{
            //    if (frmConsumoPacienteUTI == null || frmConsumoPacienteUTI.IsDisposed)
            //    {
            //        frmConsumoPacienteUTI = new FrmConsumoPacUTI();
            //        frmConsumoPacienteUTI.MdiParent = this;
            //    }
            //    frmConsumoPacienteUTI.Show();
            //    frmConsumoPacienteUTI.WindowState = FormWindowState.Normal;
            //    frmConsumoPacienteUTI.Focus();
            //}
            //catch (HacException ex)
            //{
            //    // ShowError(ex);
            //    MessageBox.Show(string.Format("Erro no sistema (HAC EXCEPTION) - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception ex)
            //{
            //    // ShowError(new HacException("Erro de Sistema.", ex));
            //    MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void cadastroDeKitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmCadKit == null || frmCadKit.IsDisposed)
                {
                    frmCadKit = new FrmCadKit();
                    frmCadKit.MdiParent = this;
                }
                frmCadKit.Show();
                frmCadKit.WindowState = FormWindowState.Normal;
                frmCadKit.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema (HAC EXCEPTION) - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void prescriçãoAntimicrobianosToolStripMenuItem_Click(object sender, EventArgs e)
        {    
            try
            {
                if (frmPrescricao == null || frmPrescricao.IsDisposed)
                {
                    frmPrescricao = new FrmPrescricao();
                    frmPrescricao.MdiParent = this;
                }
                frmPrescricao.Show();
                frmPrescricao.WindowState = FormWindowState.Normal;
                frmPrescricao.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema (HAC EXCEPTION) - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void livrosOficiaisDeRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmLivroRegistro == null || frmLivroRegistro.IsDisposed)
                {
                    frmLivroRegistro = new FrmLivroRegistro();
                    frmLivroRegistro.MdiParent = this;
                }
                frmLivroRegistro.Show();
                frmLivroRegistro.WindowState = FormWindowState.Normal;
                frmLivroRegistro.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema (HAC EXCEPTION) - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relatóriosDePrescriçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            try
            {
                if (frmRelPrescricao == null || frmRelPrescricao.IsDisposed)
                {
                    frmRelPrescricao = new FrmRelPrescricaoImp();
                    frmRelPrescricao.MdiParent = this;
                }
                frmRelPrescricao.Show();
                frmRelPrescricao.WindowState = FormWindowState.Normal;
                frmRelPrescricao.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema (HAC EXCEPTION) - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void devoluçãoPedidosPersonalizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O PROCESSO DESTA TELA FOI INATIVADO !!!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //try
            //{
            //    if (frmCancelarItemPedido == null || frmCancelarItemPedido.IsDisposed)
            //    {
            //        frmCancelarItemPedido = new FrmCancelarItemPedido();
            //        frmCancelarItemPedido.MdiParent = this;
            //    }
            //    frmCancelarItemPedido.Show();
            //    frmCancelarItemPedido.WindowState = FormWindowState.Normal;
            //    frmCancelarItemPedido.Focus();
            //}
            //catch (HacException ex)
            //{
            //    // ShowError(ex);
            //    MessageBox.Show(string.Format("Erro no sistema (HAC EXCEPTION) - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception ex)
            //{
            //    // ShowError(new HacException("Erro de Sistema.", ex));
            //    MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void devoluçãoEstornoPedidosNOVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmEstornoItemPedido == null || frmEstornoItemPedido.IsDisposed)
                {
                    frmEstornoItemPedido = new FrmEstornoItemPedido();
                    frmEstornoItemPedido.MdiParent = this;
                }
                frmEstornoItemPedido.Show();
                frmEstornoItemPedido.WindowState = FormWindowState.Normal;
                frmEstornoItemPedido.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema (HAC EXCEPTION) - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }  

        private void bookAmilToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            try
            {
                if (frmBookAmil == null || frmBookAmil.IsDisposed)
                {
                    frmBookAmil = new FrmBookAmil();
                    frmBookAmil.MdiParent = this;
                }
                frmBookAmil.Show();
                frmBookAmil.WindowState = FormWindowState.Normal;
                frmBookAmil.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema (HAC EXCEPTION) - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void medicamentosAVencerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmVencimentoMed == null || frmVencimentoMed.IsDisposed)
                {
                    frmVencimentoMed = new FrmVencimentoMed();
                    frmVencimentoMed.MdiParent = this;
                }
                frmVencimentoMed.Show();
                frmVencimentoMed.WindowState = FormWindowState.Normal;
                frmVencimentoMed.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema (HAC EXCEPTION) - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void estoqueOnLineLOTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
#if DEBUG
                //if (frmEstoqueOnLineLote == null || frmEstoqueOnLineLote.IsDisposed)
                //{
                frmEstoqueOnLineLote = new FrmEstoqueOnlineLote();
                frmEstoqueOnLineLote.MdiParent = this;
                // }

#else
                if (frmEstoqueOnLineLote == null || frmEstoqueOnLineLote.IsDisposed)
                {
                    frmEstoqueOnLineLote = new FrmEstoqueOnlineLote();
                    frmEstoqueOnLineLote.MdiParent = this;
                }
#endif
                frmEstoqueOnLineLote.Show();
                frmEstoqueOnLineLote.WindowState = FormWindowState.Normal;
                frmEstoqueOnLineLote.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rastreabilidadeDeMedicamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmRastreioLote == null || frmRastreioLote.IsDisposed)
                {
                    frmRastreioLote = new FrmRastreioLote();
                    frmRastreioLote.MdiParent = this;
                }
                frmRastreioLote.Show();
                frmRastreioLote.WindowState = FormWindowState.Normal;
                frmRastreioLote.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema (HAC EXCEPTION) - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relatórioBaixasCentroCustoToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            try
            {
                if (frmRelBaixaCCusto == null || frmRelBaixaCCusto.IsDisposed)
                {
                    frmRelBaixaCCusto = new FrmRelBaixaCCusto();
                    frmRelBaixaCCusto.MdiParent = this;
                }
                frmRelBaixaCCusto.Show();
                frmRelBaixaCCusto.WindowState = FormWindowState.Normal;
                frmRelBaixaCCusto.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema (HAC EXCEPTION) - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reprocessamentoDeContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmReprocessarAtd == null || frmReprocessarAtd.IsDisposed)
                {
                    frmReprocessarAtd = new FrmReprocessarAtd();
                    frmReprocessarAtd.MdiParent = this;
                }

                frmReprocessarAtd.Show();
                frmReprocessarAtd.WindowState = FormWindowState.Normal;
                frmReprocessarAtd.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void empréstimoRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmEmprestimo == null || frmEmprestimo.IsDisposed)
                {
                    frmEmprestimo = new FrmEmprestimo();
                    frmEmprestimo.MdiParent = this;
                }

                frmEmprestimo.Show();
                frmEmprestimo.WindowState = FormWindowState.Normal;
                frmEmprestimo.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void configuraçãoDePedidoAutoSetorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmSetorPedidoAutoParam == null || frmSetorPedidoAutoParam.IsDisposed)
                {
                    frmSetorPedidoAutoParam = new FrmSetorPedidoAutoParam();
                    frmSetorPedidoAutoParam.MdiParent = this;
                }

                frmSetorPedidoAutoParam.Show();
                frmSetorPedidoAutoParam.WindowState = FormWindowState.Normal;
                frmSetorPedidoAutoParam.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pedidoAutomáticoSetorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmPedidoAutomaticoSetor == null || frmPedidoAutomaticoSetor.IsDisposed)
                {
                    frmPedidoAutomaticoSetor = new FrmPedidoAutomaticoSetor();
                    frmPedidoAutomaticoSetor.MdiParent = this;
                }

                frmPedidoAutomaticoSetor.Show();
                frmPedidoAutomaticoSetor.WindowState = FormWindowState.Normal;
                frmPedidoAutomaticoSetor.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void separaçãoDeKitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmSeparacaoKit == null || frmSeparacaoKit.IsDisposed)
                {
                    frmSeparacaoKit = new FrmSeparacaoKit();
                    frmSeparacaoKit.MdiParent = this;
                }

                frmSeparacaoKit.Show();
                frmSeparacaoKit.WindowState = FormWindowState.Normal;
                frmSeparacaoKit.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void prescriçãoInternaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            try
            {
                if (frmPrescricaoInt == null || frmPrescricaoInt.IsDisposed)
                {
                    frmPrescricaoInt = new FrmPrescricaoInt();
                    frmPrescricaoInt.MdiParent = this;
                }

                frmPrescricaoInt.Show();
                frmPrescricaoInt.WindowState = FormWindowState.Normal;
                frmPrescricaoInt.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kardexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmKardex == null || frmKardex.IsDisposed)
                {
                    frmKardex = new FrmKardex();
                    frmKardex.MdiParent = this;
                }

                frmKardex.Show();
                frmKardex.WindowState = FormWindowState.Normal;
                frmKardex.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void confPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmConferenciaPedido == null || frmConferenciaPedido.IsDisposed)
                {
                    frmConferenciaPedido = new FrmConferenciaPedido();
                    frmConferenciaPedido.MdiParent = this;
                }

                frmConferenciaPedido.Show();
                frmConferenciaPedido.WindowState = FormWindowState.Normal;
                frmConferenciaPedido.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void replicaçãoPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmPedidoReplicar == null || frmPedidoReplicar.IsDisposed)
                {
                    frmPedidoReplicar = new FrmPedidoReplicar();
                    frmPedidoReplicar.MdiParent = this;
                }

                frmPedidoReplicar.Show();
                frmPedidoReplicar.WindowState = FormWindowState.Normal;
                frmPedidoReplicar.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void inventárioRotativoToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            try
            {
                if (frmInventarioRotativo == null || frmInventarioRotativo.IsDisposed)
                {
                    frmInventarioRotativo = new FrmInventarioRotativo();
                    frmInventarioRotativo.MdiParent = this;
                }

                frmInventarioRotativo.Show();
                frmInventarioRotativo.WindowState = FormWindowState.Normal;
                frmInventarioRotativo.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void devoluçãoSetorToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            try
            {
                if (frmEstornoItem == null || frmEstornoItem.IsDisposed)
                {
                    frmEstornoItem = new FrmEstornoItem();
                    frmEstornoItem.MdiParent = this;
                }

                frmEstornoItem.Show();
                frmEstornoItem.WindowState = FormWindowState.Normal;
                frmEstornoItem.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format(" Erro no sistema (HAC EXCEPTION) {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format(" Erro no sistema {0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsDevolucaoConsig_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmDevolucaoConsig == null || frmDevolucaoConsig.IsDisposed)
                {
                    frmDevolucaoConsig = new FrmDevolucaoConsig();
                    frmDevolucaoConsig.MdiParent = this;
                }
                frmDevolucaoConsig.Show();
                frmDevolucaoConsig.WindowState = FormWindowState.Normal;
                frmDevolucaoConsig.Focus();
            }
            catch (HacException ex)
            {
                // ShowError(ex);
                MessageBox.Show(string.Format("Erro no sistema (HAC EXCEPTION) - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // ShowError(new HacException("Erro de Sistema.", ex));
                MessageBox.Show(string.Format("Erro no sistema - {0} ", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}