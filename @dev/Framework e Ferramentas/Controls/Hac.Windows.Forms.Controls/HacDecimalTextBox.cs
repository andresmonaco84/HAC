using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;

namespace Hac.Windows.Forms.Controls
{
    /// <summary>
    /// The numeric texbox takes numeric(decimal) values as input.
    /// It has the following extra properties:
    ///		NumericPrecision: Precision
    ///		NumericScaleOnFocus: The scale to display when the textbox has got the focus.
    ///		NumericScaleOnLostFocus: The scale to display when the textbox hasn't got the focus.
    ///		NumericValue: The current numeric value displayed in the textbox (decimal)
    ///		ZeroIsValid: Zero is a valid as input
    ///		AllowNegative: Allow input of negative decimal numbers
    ///	It has the following extra events:
    ///		NumericValueChanged: The event fires when the numeric value changes 
    ///							 by user input or programmaticly.(Like TextChanged)
    ///	Use NumericValueChanged event instead of the TextChanged event!!!!
    ///	The NumericValue property is also capable of databinding.
    ///	The decimal number is displayed with grouping char.
    /// </summary>
    [System.ComponentModel.DefaultEvent("NumericValueChanged"),
    System.ComponentModel.DefaultProperty("NumericValue"),
    ToolboxBitmap(typeof(System.Windows.Forms.TextBox))]

    public partial class HacDecimalTextBox : TextBox, IHacRequiredControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public HacDecimalTextBox()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            this.TextAlign = HorizontalAlignment.Right;

            if (this.naoAjustarEdicao == false)
            {
                this.naoAjustarEdicao = true;
                this.Text = "0";
                this.naoAjustarEdicao = false;
            }
            else
                this.Text = "0";

            this.LostFocus += new EventHandler(NumericTextBox_LostFocus);
            this.GotFocus += new EventHandler(NumericTextBox_GotFocus);
            //this.TextChanged += new EventHandler(NumericTextBox_TextChanged);
            this.KeyDown += new KeyEventHandler(NumericTextBox_KeyDown);
            this.KeyPress += new KeyPressEventHandler(NumericTextBox_KeyPress);
            this.Validating += new CancelEventHandler(NumericTextBox_Validating);
        }

        #region Variáveis Propriedades

        private bool naoAjustarEdicao = true;
        private bool obrigatorio = false;
        private bool limpar = true;
        private EstadoObjeto estadoinicial = EstadoObjeto.Habilitado;
        private string obrigatoriomensagem = string.Empty;
        private bool selectAllOnFocus = false;
        private ControleEdicao editavel = ControleEdicao.Nunca;
        private bool prevalidado = false;
        private string prevalidacaomensagem = string.Empty;

        #endregion

        #region Propriedades Públicas

        [Category("Hac")]
        [Description("Mensagem caso campo Pre Validado esteja em Branco")]
        [DisplayName("Mensagem de Pré Validação")]
        public string PreValidacaoMensagem
        {
            get { return prevalidacaomensagem; }
            set { prevalidacaomensagem = value; }
        }

        [Category("Hac")]
        [Description("Define quando o campo é obrigatório antes de entrar em modo de Inserção (Click Botão novo)")]
        public bool PreValidado
        {
            get { return prevalidado; }
            set { prevalidado = value; }
        }

        [Category("Hac")]
        [Description("Define quando campo será editavel")]
        public ControleEdicao Editavel
        {
            get { return editavel; }
            set { editavel = value; }
        }


        [Category("Hac")]
        [Description("Define se todo o texto dentro do campo será selecionado quando o objeto receber o foco")]
        public bool SelectAllOnFocus
        {
            get { return selectAllOnFocus; }
            set { selectAllOnFocus = value; }
        }

        [Category("Hac")]
        [Description("Não ajusta modo de tela para edição quando o texto é modificado")]
        public bool NaoAjustarEdicao
        {
            get { return naoAjustarEdicao; }
            set { naoAjustarEdicao = value; }
        }

        [Category("Hac")]
        [Description("Define se Campo será limpo quando o usuário clicar nos botões Novo/Cancelar")]
        public bool Limpar
        {
            get { return limpar; }
            set { limpar = value; }
        }

        [Category("Hac")]
        [Description("Define Estado Inicial do campo ( Habilitado/Desabilitado)")]
        public EstadoObjeto EstadoInicial
        {
            get { return estadoinicial; }
            set
            {
                if (value == EstadoObjeto.Habilitado)
                {
                    CommonCtrl.Habilitar(this);
                }
                else
                {
                    CommonCtrl.Desabilitar(this);
                }
                estadoinicial = value;
            }
        }

        [Category("Hac")]
        [Description("Define Mensagem de erro quando usuário deixar um campo obrigatório em branco")]
        [DisplayName("Mensagem para Campo Obrigatório")]
        public string ObrigatorioMensagem
        {
            get { return obrigatoriomensagem; }
            set { obrigatoriomensagem = value; }
        }

        [Category("Hac")]
        [Description("Indica se é campo obrigatório")]
        public bool Obrigatorio
        {
            get { return obrigatorio; }
            set { obrigatorio = value; }
        }

        #endregion

        #region Métodos Internos

        /// <summary>
        /// Habilita ou desabilita os objetos conforme parametros de configuração
        /// </summary>
        /// <param name="e"></param>
        private void ControlaEstadoObjeto(Evento e)
        {
            if (this.Editavel != ControleEdicao.Nunca)
            {
                switch (e)
                {
                    case Evento.eNovo:
                        if (this.Editavel == ControleEdicao.Sempre || this.Editavel == ControleEdicao.NovoRegistro)
                        {
                            CommonCtrl.Habilitar(this);
                        }
                        else
                        {
                            CommonCtrl.Desabilitar(this);

                        }
                        this.Modified = false;
                        break;
                    case Evento.eSalvar:
                    case Evento.eCancelar:
                    case Evento.eInicio:
                        if (this.EstadoInicial == EstadoObjeto.Habilitado && (this.Editavel == ControleEdicao.Pesquisa || this.Editavel == ControleEdicao.Sempre))
                        {
                            CommonCtrl.Habilitar(this);
                        }
                        else
                        {
                            CommonCtrl.Desabilitar(this);
                        }
                        this.Modified = false;
                        break;
                    case Evento.eExcluir:
                        break;
                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// Valida se o componente
        /// </summary>
        public void ValidateRequired(Control controlOwner)
        {
            CommonCtrl.ValidateRequired(controlOwner, false);
        }

        /// <summary>
        /// Faz a validação se o campo esta preenchido
        /// </summary>
        /// <returns></returns>
        public bool ValidateRequired()
        {
            return !string.IsNullOrEmpty(this.Text);
        }

        /// <summary>
        /// Faz as Validações necessárias para o objeto
        /// </summary>
        /// <param name="e">Evento</param>
        public bool ValidaObjeto(Evento e, ref  String Mensagem)
        {
            // Chamado de CommonCtr
            Boolean retorno = true;

            switch (e)
            {
                case Evento.eNovo:
                    // verifica se é campo Pré Validado
                    if ((this.PreValidado && this.Text == string.Empty) && this.Enabled && this.Visible)
                    {
                        Mensagem = this.PreValidacaoMensagem;
                        this.BackColor = Color.LightPink;
                        retorno = false;
                    }
                    break;
                case Evento.eSalvar:
                    //  verifica se é campo obrigatório
                    if ((this.Obrigatorio && this.Text == string.Empty) && this.Enabled && this.Visible)
                    {
                        Mensagem = this.ObrigatorioMensagem;
                        this.BackColor = Color.LightPink;
                        retorno = false;
                    }
                    break;
                case Evento.eCancelar:
                    break;
                case Evento.eExcluir:
                    break;
                case Evento.eInicio:
                    break;
                default:
                    break;
            }
            return retorno;


        }

        /// <summary>
        /// Faz as Validações necessárias para o objeto
        /// </summary>
        /// <param name="e">Evento</param>
        public void Controla(Evento e)
        {
            // Chamado de CommonCtr
            switch (e)
            {
                case Evento.eNovo:
                    this.LimparTextBox();
                    this.ControlaEstadoObjeto(e);
                    break;
                case Evento.eSalvar:
                    this.ControlaEstadoObjeto(e);
                    break;
                case Evento.eCancelar:
                    this.LimparTextBox();
                    this.ControlaEstadoObjeto(e);
                    break;
                case Evento.eExcluir:
                    break;
                case Evento.eInicio:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True
        /// </summary>
        public void LimparTextBox()
        {
            if (this.Limpar) this.Clear();
        }
        #endregion

        #region Eventos "override"

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar == 13)
            {
                e.Handled = true;
                //SendKeys.Send("{TAB}");
            }

        }


        protected override void OnLostFocus(EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Text))
            {
                if (!CommonCtrl.ValidateContentType(AcceptedFormat.Numerico, this.Text))
                {
                    // this.Clear();
                    this.Focus();
                }
            }

            base.OnLostFocus(e);
        }

        protected override void OnModifiedChanged(EventArgs e)
        {
            base.OnModifiedChanged(e);
            if (this.Modified && !this.NaoAjustarEdicao) ((FrmBase)this.FindForm()).AjustaModoTela(ModoEdicao.Edicao);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            //O evento TextChanged é executado duas vezes quando o controle é criado em modo de design
            //por isso foi feita esta verificação. Na primeira vez a propriedade Text é igual ao nome do controle.
            //Na segunda a propriedade Text igual vazio.
            if (!this.DesignMode)
            {
                Form frm = this.FindForm();
                if (frm != null)
                    if (this.Text != string.Empty && !this.NaoAjustarEdicao) ((FrmBase)frm).AjustaModoTela(ModoEdicao.Edicao);
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Honeydew;
            base.OnGotFocus(e);
            if (selectAllOnFocus)
            {
                this.SelectAll();
            }

        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (selectAllOnFocus)
            {
                this.SelectAll();
            }
            // // the current position is just before the comma
            //if (this.Text.IndexOf(DecimalSeperator) != -1)
            //{

            //    this.SelectionStart = this.Text.IndexOf(DecimalSeperator);    
            //}


            //this.ScrollToCaret();
            //this.Refresh();
            //this.Cursor = new Cursor(Cursor.Current.Handle);
            //Cursor.Position = new Point(Cursor.Position.X - 100, Cursor.Position.Y);
            // Cursor.Clip = new Rectangle(this.Location, this.Size);


        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled)
                CommonCtrl.Habilitar(this);
            else
                CommonCtrl.Desabilitar(this);

            base.OnEnabledChanged(e);
        }

        #endregion

        public void Inicializar()
        {
            this.TextChanged += new EventHandler(NumericTextBox_TextChanged);
            this.ControlaEstadoObjeto(Evento.eInicio);
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.BackColor = System.Drawing.Color.Honeydew;
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        #endregion

        #region "Variables"
        private int ii_ScaleOnLostFocus = 2;
        private Decimal idec_InternalValue = 0;
        private Decimal idec_NumericValue = 0;
        private int ii_ScaleOnFocus = 2;
        private int ii_Precision = 10;
        private bool ib_AllowNegative = false;
        private bool ib_NoChangeEvent = false;
        private bool ib_ZeroNotValid = true;
        #endregion

        public event EventHandler NumericValueChanged;

        #region "Properties"

        /// <summary>
        /// Indicates if the value zero (0) valid.
        /// </summary>
        [System.ComponentModel.Category("Numeric settings")]
        public bool ZeroIsValid
        {
            get { return ib_ZeroNotValid; }
            set { ib_ZeroNotValid = value; }
        }

        /// <summary>
        /// Maximum allowed precision
        /// </summary>
        [System.ComponentModel.Category("Numeric settings")]
        public int NumericPrecision
        {
            get { return ii_Precision; }
            set
            {
                //Precision cannot be negative
                if (value < 0)
                {
                    MessageBox.Show("Precision cannot be negative!", "Numeric TextBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (value < this.NumericScaleOnFocus)
                {
                    this.NumericScaleOnFocus = value;
                }

                ii_Precision = value;
            }
        }

        /// <summary>
        /// The maximum scale allowed
        /// </summary>
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.All),
        System.ComponentModel.Category("Numeric settings")]
        public int NumericScaleOnFocus
        {
            get { return ii_ScaleOnFocus; }
            set
            {
                //Scale cannot be negative
                if (value < 0)
                {
                    MessageBox.Show("Scale cannot be negative!", "Numeric TextBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Scale cannot be larger than precision
                if (value >= this.NumericPrecision)
                {
                    MessageBox.Show("Scale cannot be larger than precission!", "Numeric TextBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ii_ScaleOnFocus = value;

                if (ii_ScaleOnFocus > 0)
                {
                    this.Text = "0" + DecimalSeperator + new string(Convert.ToChar("0"), ii_ScaleOnFocus);
                }
                else
                {
                    this.Text = "0";
                }
            }
        }


        /// <summary>
        /// Scale displayed when the textbox has no focus 
        /// </summary>
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.All),
        System.ComponentModel.Category("Numeric settings")]
        public int NumericScaleOnLostFocus
        {
            get { return ii_ScaleOnLostFocus; }
            set
            {
                //Scale cannot be negative
                if (value < 0)
                {
                    MessageBox.Show("Scale cannot be negative!", "Numeric TextBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Scale cannot be larger than precision
                if (value >= this.NumericPrecision)
                {
                    MessageBox.Show("Scale cannot be larger than precesion!", "Numeric TextBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ii_ScaleOnLostFocus = value;
            }
        }

        private string DecimalSeperator
        {
            get
            {
                return System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            }
        }

        private string GroupSeperator
        {
            get
            {
                return System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator;
            }
        }


        /// <summary>
        /// Indicates if negative numbers are allowed?
        /// </summary>
        [System.ComponentModel.Category("Numeric settings")]
        public bool AllowNegative
        {
            get { return ib_AllowNegative; }
            set { ib_AllowNegative = value; }
        }

        /// <summary>
        /// The current numeric value displayed in the textbox
        /// </summary>
        [System.ComponentModel.Bindable(true),
        System.ComponentModel.Category("Numeric settings")]
        public object NumericValue
        {
            get { return idec_NumericValue; }
            set
            {
                if (value.Equals(DBNull.Value))
                {
                    if (value.Equals(0))
                    {
                        this.Text = Convert.ToString(0);
                        idec_NumericValue = Convert.ToDecimal(0);
                        OnNumericValueChanged(new System.EventArgs());
                        return;
                    }
                }

                if (!value.Equals(idec_NumericValue))
                {
                    this.Text = Convert.ToString(value);
                    idec_NumericValue = Convert.ToDecimal(value);
                    OnNumericValueChanged(new System.EventArgs());
                }
            }
        }
        #endregion

        #region "Subs"


        private void NumericTextBox_LostFocus(object sender, EventArgs e)
        {
            ib_NoChangeEvent = true;

            //if (!string.IsNullOrEmpty(this.Text))
            //{
            try
            {
                idec_InternalValue = Convert.ToDecimal(this.Text);

                //set { the text to the new format
                //if (! li_Precision = 0 ) {
                if (!(ii_ScaleOnLostFocus == 0))
                {
                    //this.Text = Strings.FormatNumber(this.Text, this.NumericScaleOnLostFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                    this.Text = this.FormatNumber();
                }
                else
                {
                    if (this.Text.IndexOf('-') < 0)
                    {
                        //this.Text = Strings.FormatNumber(this.Text, this.NumericScaleOnLostFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                        this.Text = this.FormatNumber();
                    }
                    else
                    {
                        if (this.Text == "-")
                        {
                            this.Text = "";
                        }
                        else
                        {
                            //this.Text = CStr(System.Math.Abs(CDbl(this.Text)));
                            //this.Text = Strings.FormatNumber(this.Text, this.NumericScaleOnLostFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                            this.Text = this.FormatNumber();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Text = string.Empty;
            }                
            //}

            ib_NoChangeEvent = false;
        }

        private void NumericTextBox_GotFocus(object sender, EventArgs e)
        {
            ib_NoChangeEvent = true;

            this.Text = Convert.ToString(idec_InternalValue);

            //set { the text to the new format
            //if (! li_Precision = 0 ) {
            if (!(ii_ScaleOnFocus == 0))
            {
                //this.Text = Strings.FormatNumber(this.Text, this.NumericScaleOnFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                this.Text = this.FormatNumber();
            }
            else
            {
                if (this.Text.IndexOf('-') < 0)
                {
                    //this.Text = Strings.FormatNumber(this.Text, this.NumericScaleOnFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                    this.Text = this.FormatNumber();
                }
                else
                {
                    if (this.Text == "-")
                    {
                        this.Text = "";
                    }
                    else
                    {
                        //this.Text = Convert.ToString(System.Math.Abs(Convert.ToDouble(this.Text)));
                        //this.Text = Strings.FormatNumber(this.Text, this.NumericScaleOnFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                        this.Text = this.FormatNumber();
                    }
                }
            }


            ib_NoChangeEvent = false;
        }

        private void NumericTextBox_TextChanged(object sender, EventArgs e)
        {
            int li_SelStart = 0;
            bool lb_PositionCursorBeforeComma = false;

            //Indicates that no change event should happen
            //Prevent event from firing on changing the text in the change
            //event
            if (ib_NoChangeEvent || (this.SelectionStart == -1))
            {
                return;
            }

            //No Change event
            ib_NoChangeEvent = true;

            if (string.Empty.Equals(this.Text.Trim()))
            {
                this.Text = "0";
            }

            if (this.Text.Substring(0, 1) == GroupSeperator)
            {
                this.Text = this.Text.Substring(1);
            }

            //if (! ii_Precision = 0 ) {
            if (!(ii_ScaleOnFocus == 0))
            {
                //if ( the current position is just before the comma
                if (this.SelectionStart == (this.Text.IndexOf(DecimalSeperator)))
                {
                    lb_PositionCursorBeforeComma = true;
                }
                else
                {
                    li_SelStart = this.SelectionStart;
                }
            }
            else
            {
                li_SelStart = this.SelectionStart;
            }

            idec_InternalValue = Convert.ToDecimal(this.Text);
            this.NumericValue = Convert.ToDecimal(this.Text);



            if (this.Focused)
            {
                //set { the text to the new format
                //if (! ii_Precision = 0 ) {
                if (!(ii_ScaleOnFocus == 0))
                {
                    //this.Text = Strings.FormatNumber(this.Text, this.NumericScaleOnFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                    this.Text = this.FormatNumber();
                }
                else
                {
                    if (this.Text.IndexOf('-') < 0)
                    {
                        //this.Text = Strings.FormatNumber(this.Text, this.NumericScaleOnFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                        this.Text = this.FormatNumber();
                    }
                    else
                    {
                        if (this.Text.Equals('-'))
                        {
                            this.Text = "";
                        }
                        else
                        {
                            //this.Text = Convert.ToString(System.Math.Abs(Convert.ToDouble(this.Text)));
                            //this.Text = Strings.FormatNumber(this.Text, this.NumericScaleOnFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                            this.Text = this.FormatNumber();
                        }
                    }
                }
            }
            else
            {
                //set { the text to the new format
                //if (! ii_Precision = 0 ) {
                if (!(ii_ScaleOnLostFocus == 0))
                {
                    //this.Text = Strings.FormatNumber(this.Text, this.NumericScaleOnLostFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                    this.Text = this.FormatNumber();
                }
                else
                {
                    if (this.Text.IndexOf('-') < 0)
                    {
                        //this.Text = Strings.FormatNumber(this.Text, this.NumericScaleOnLostFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                        this.Text = this.FormatNumber();
                    }
                    else
                    {
                        if (this.Text.Equals('-'))
                        {
                            this.Text = "";
                        }
                        else
                        {
                            //this.Text = Convert.ToString(System.Math.Abs(Convert.ToDouble(this.Text)));
                            //this.Text = Strings.FormatNumber(this.Text, this.NumericScaleOnLostFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                            this.Text = this.FormatNumber();
                        }
                    }
                }

            }

            //if ( the position was before the comma
            //then put again before the comma
            if (!(ii_ScaleOnFocus == 0))
            {
                if (lb_PositionCursorBeforeComma)
                {
                    this.SelectionStart = (this.Text.IndexOf(DecimalSeperator));
                }
                else
                {
                    this.SelectionStart = li_SelStart;
                }
            }
            else
            {
                this.SelectionStart = li_SelStart;
            }

            //Change event may fire
            ib_NoChangeEvent = false;


        }

        private void NumericTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool lb_PositionCursorJustBeforeComma = false;

            if (!(ii_ScaleOnFocus == 0))
            {
                //Is the position of the cursor just before the comma
                lb_PositionCursorJustBeforeComma = (this.SelectionStart == (this.Text.IndexOf(DecimalSeperator)));
            }

            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Delete:
                    //Otherwise strange effect
                    if (lb_PositionCursorJustBeforeComma)
                    {
                        this.SelectionStart = this.Text.IndexOf(DecimalSeperator) + 1;
                        e.Handled = true;
                        break;
                    }
                    //if ( all selected on delete pressed

                    if (this.Text.IndexOf('-') < 0)
                    {
                        if (this.SelectionLength == this.Text.Length)
                        {
                            this.Text = "0";
                            this.SelectionStart = 1;
                            e.Handled = true;
                            break;
                        }
                    }
                    else
                    {

                        if (this.SelectionLength == this.Text.Length)
                        {
                            this.Text = "0";
                            this.SelectionStart = 1;
                            e.Handled = true;
                            break;
                        }

                        if (this.SelectionLength > 0)
                        {
                            if (this.SelectedText != "-")
                            {
                                if (Convert.ToDouble(this.SelectedText) == System.Math.Abs(Convert.ToDouble(this.Text)))
                                {
                                    this.Text = "0";
                                    this.SelectionStart = 1;
                                    e.Handled = true;
                                    break;
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            return;
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool lb_PositionCursorBeforeComma = false;
            bool lb_InputBeforeCommaValid = false;
            bool lb_PositionCursorJustAfterComma = false;
            int li_SelStart = 0;

            lb_InputBeforeCommaValid = true;

            //Minus pressed
            if (e.KeyChar.Equals('-'))
            {
                if (this.AllowNegative)
                {
                    if (this.Text.IndexOf('-') < 0)
                    {

                        li_SelStart = this.SelectionStart;

                        if (!(Convert.ToDecimal(this.Text) == 0))
                        {
                            this.Text = "-" + this.Text;

                            this.SelectionStart = li_SelStart + 1;
                        }
                        e.Handled = true;
                        return;
                    }
                    else
                    {

                        switch (this.SelectionLength)
                        {

                            case 0:
                                li_SelStart = this.SelectionStart;

                                this.Text = Convert.ToString(Convert.ToDouble(this.Text) * -1);

                                this.SelectionStart = li_SelStart - 1;

                                e.Handled = true;
                                break;
                            default:
                                //Is everything selected
                                if (this.SelectionLength == this.TextLength)
                                    this.Text = "-0";
                                e.Handled = true;
                                break;
                        }
                    }
                    e.Handled = true;
                    return;
                }
            }

            //The + key
            if (e.KeyChar.Equals('+'))
            {
                if (!(this.Text.IndexOf('-') < 0))
                {
                    //Is everything selected
                    switch (this.SelectionLength)
                    {
                        case 0:
                            li_SelStart = this.SelectionStart;

                            this.Text = Convert.ToString(Convert.ToDouble(this.Text) * -1);

                            this.SelectionStart = li_SelStart - 1;

                            e.Handled = true;
                            break;
                        default:
                            if (this.TextLength == this.SelectionLength)
                            {
                                this.Text = "0";
                                e.Handled = true;
                            }
                            break;
                    }
                }
                e.Handled = true;
                return;
            }

            if (!(ii_ScaleOnFocus == 0))
            {
                //Is the position of the cursor just after the comma
                lb_PositionCursorJustAfterComma = (this.SelectionStart == this.Text.IndexOf(DecimalSeperator) + 1);
            }

            if (e.KeyChar == '\b')
            {
                //Backspace
                if (lb_PositionCursorJustAfterComma)
                {
                    this.SelectionStart = this.Text.IndexOf(DecimalSeperator);
                    e.Handled = true;
                }

                //if ( all selected on delete pressed)
                if (this.SelectionLength == this.Text.Length)
                {
                    this.Text = "0";
                    this.SelectionStart = 1;
                    e.Handled = true;

                }

                if (e.KeyChar.Equals(null))
                {
                    e.Handled = true;
                }
                return;
            }

            //Prevent other keys than numeric and ,
            string ls_AllowedKeyChars = "1234567890" + DecimalSeperator;

            if (ls_AllowedKeyChars.IndexOf(e.KeyChar) < 0)
            {
                e.Handled = true;
                return;
            }

            if (!(ii_ScaleOnFocus == 0))
            {
                //position of cursor is before comma?
                lb_PositionCursorBeforeComma = !(this.SelectionStart >= this.Text.IndexOf(DecimalSeperator) + 1);
            }

            //Comma pressed
            if (e.KeyChar.ToString() == DecimalSeperator)
            {
                if (lb_PositionCursorBeforeComma)
                {
                    this.SelectionStart = this.Text.IndexOf(DecimalSeperator) + 1;
                    this.SelectionLength = 0;
                }

                e.Handled = true;
                return;
            }

            //Prevent more than the precission numbers entered
            if (!(ii_ScaleOnFocus == 0))
            {
                if (this.SelectionStart == this.Text.Length)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (!(ii_ScaleOnFocus == 0))
            {
                //if ( the character entered would violate the numbers before the comma
                if (this.Text.IndexOf('-') < 0)
                {
                    lb_InputBeforeCommaValid = !(this.Text.Substring(0, this.Text.IndexOf(DecimalSeperator)).Length >= (ii_Precision - ii_ScaleOnFocus));
                }
                else
                {
                    lb_InputBeforeCommaValid = !(this.Text.Substring(0, this.Text.IndexOf(DecimalSeperator)).Length >= (ii_Precision - ii_ScaleOnFocus + 1));
                }
            }
            else
            {
                if (this.Text.IndexOf('-') < 0)
                {
                    lb_InputBeforeCommaValid = !((this.Text.Length) >= ii_Precision);
                }
                else
                {
                    lb_InputBeforeCommaValid = !((this.Text.Length) >= ii_Precision + 1);
                }
            }

            //if first char is 0 another may be entered
            if (!(ii_ScaleOnFocus == 0))
            {
                if ((this.Text.Substring(0, 1) == "0") && !(this.SelectionStart == 0))
                {
                    lb_InputBeforeCommaValid = true;
                }
                if (this.SelectionLength > 0)
                {
                    lb_InputBeforeCommaValid = true;
                }
            }
            else
            {
                if ((this.Text.Substring(0, 1) == "0") && ((this.SelectionStart == this.Text.Length) || (this.SelectionLength == 1)))
                {
                    lb_InputBeforeCommaValid = true;
                }
                if (this.SelectionLength > 0)
                {
                    lb_InputBeforeCommaValid = true;
                }
            }

            if (!(ii_ScaleOnFocus == 0))
            {
                if (lb_PositionCursorBeforeComma && !(lb_InputBeforeCommaValid))
                {
                    e.Handled = true;
                    return;
                }
            }
            else
            {
                if (!(lb_InputBeforeCommaValid))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// Raises the NumericValueChanged event
        /// </summary>
        /// <param name="e">The eventargs</param>
        protected void OnNumericValueChanged(System.EventArgs e)
        {
            if (NumericValueChanged != null)
            {
                NumericValueChanged(this, e);
            }
        }

        /// <summary>
        /// Formats a the text inf the textbox (which represents a number) according to
        /// the scale,precision and the enviroment settings.
        /// </summary>
        protected string FormatNumber()
        {
            //if (string.IsNullOrEmpty(this.Text)) return this.Text;

            StringBuilder lsb_Format = new StringBuilder();
            int li_Counter = 1;
            long ll_Remainder = 0;

            if (this.Focused)
            {
                while (li_Counter <= ii_Precision - ii_ScaleOnFocus)
                {
                    if (li_Counter == 1)
                    {
                        lsb_Format.Insert(0, '0');
                    }
                    else
                    {
                        lsb_Format.Insert(0, '#');
                    }

                    System.Math.DivRem(li_Counter, 3, out ll_Remainder);
                    if ((ll_Remainder == 0) && (li_Counter + 1 <= ii_Precision - ii_ScaleOnFocus))
                    {
                        lsb_Format.Insert(0, ',');
                    }

                    li_Counter++;
                }

                li_Counter = 1;

                if (ii_ScaleOnFocus > 0)
                {
                    lsb_Format.Append(".");

                    while (li_Counter <= ii_ScaleOnFocus)
                    {
                        lsb_Format.Append('0');
                        li_Counter++;
                    }
                }

            }
            else
            {
                while (li_Counter <= ii_Precision - ii_ScaleOnLostFocus)
                {
                    if (li_Counter == 1)
                    {
                        lsb_Format.Insert(0, '0');
                    }
                    else
                    {
                        lsb_Format.Insert(0, '#');
                    }
                    System.Math.DivRem(li_Counter, 3, out ll_Remainder);
                    if ((ll_Remainder == 0) && (li_Counter + 1 <= ii_Precision - ii_ScaleOnLostFocus))
                    {
                        lsb_Format.Insert(0, ',');
                    }
                    li_Counter++;
                }

                li_Counter = 1;

                if (ii_ScaleOnLostFocus > 0)
                {
                    lsb_Format.Append(".");

                    while (li_Counter <= ii_ScaleOnLostFocus)
                    {
                        lsb_Format.Append('0');
                        li_Counter++;
                    }
                }
            }
            return Convert.ToDecimal(this.Text).ToString(lsb_Format.ToString());

        }

        private void NumericTextBox_Validating(object sender, CancelEventArgs e)
        {
            if ((this.Text.Equals(string.Empty) || Convert.ToDecimal(this.NumericValue).Equals(Convert.ToDecimal(0))) && !this.ZeroIsValid)
            {
                e.Cancel = true;
            }
        }

        #endregion


    }
}