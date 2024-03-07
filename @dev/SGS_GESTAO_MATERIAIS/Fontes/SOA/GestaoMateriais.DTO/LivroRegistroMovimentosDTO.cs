
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using MVC = HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.GestaoMateriais.DTO
{
	/// <summary>
	/// Classe Entidade DataTable
	/// </summary>
	[Serializable()]
	public class LivroRegistroMovimentosDataTable : DataTable
	{
		
	    public LivroRegistroMovimentosDataTable()
            : base()
        {        
			this.TableName = "DADOS";

			this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.IdtLivro, typeof(Decimal));
		    this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.IdtUnidade, typeof(Decimal));
		    this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.IdtProduto, typeof(Decimal));
		    this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.DataRegistro, typeof(DateTime));
		    this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.Historico, typeof(String));
		    this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.HistoricoManual, typeof(String));
		    this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.QtdEntrada, typeof(Decimal));
		    this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.QtdSaida, typeof(Decimal));
		    this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.QtdPerda, typeof(Decimal));
		    this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.QtdEstoque, typeof(Decimal));
		    this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.Observacao, typeof(String));
		    this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.DataCriacao, typeof(DateTime));
		    this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.UsuarioCriacao, typeof(Decimal));
		    this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.DataAlteracao, typeof(DateTime));
		    this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.UsuarioAlteracao, typeof(Decimal));
		    this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.Auditado, typeof(String));
            this.Columns.Add(LivroRegistroMovimentosDTO.FieldNames.IdtFilial, typeof(Decimal));			

            //DataColumn[] primaryKey = { this.Columns[LivroRegistroMovimentosDTO.FieldNames.IdtLivro] };

            //this.PrimaryKey = primaryKey;
        }
		
        protected LivroRegistroMovimentosDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public LivroRegistroMovimentosDTO TypedRow(int index)
        {
            return (LivroRegistroMovimentosDTO)this.Rows[index];
        }
		
        public string GetXml()
        {
            string ret;
            UTF8Encoding utf8 = new UTF8Encoding();

            MemoryStream stream = new MemoryStream();
            this.WriteXml(stream);
            ret = utf8.GetString(stream.ToArray());
            stream.Close();
            return ret;
        }
		
        public XmlDocument WriteXml()
        {
            XmlDocument ret = new XmlDocument();
            ret.LoadXml(this.GetXml());
            return ret;
        }

        public void Add(LivroRegistroMovimentosDTO dto)
        {
            DataRow dtr = this.NewRow();

			if (!dto.IdtLivro.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.IdtLivro] = (Decimal)dto.IdtLivro.Value;
		    if (!dto.IdtUnidade.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;
		    if (!dto.IdtProduto.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.IdtProduto] = (Decimal)dto.IdtProduto.Value;
		    if (!dto.DataRegistro.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.DataRegistro] = (DateTime)dto.DataRegistro.Value;
		    if (!dto.Historico.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.Historico] = (String)dto.Historico.Value;
		    if (!dto.HistoricoManual.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.HistoricoManual] = (String)dto.HistoricoManual.Value;
		    if (!dto.QtdEntrada.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.QtdEntrada] = (Decimal)dto.QtdEntrada.Value;
		    if (!dto.QtdSaida.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.QtdSaida] = (Decimal)dto.QtdSaida.Value;
		    if (!dto.QtdPerda.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.QtdPerda] = (Decimal)dto.QtdPerda.Value;
		    if (!dto.QtdEstoque.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.QtdEstoque] = (Decimal)dto.QtdEstoque.Value;
		    if (!dto.Observacao.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.Observacao] = (String)dto.Observacao.Value;
		    if (!dto.DataCriacao.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.DataCriacao] = (DateTime)dto.DataCriacao.Value;
		    if (!dto.UsuarioCriacao.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.UsuarioCriacao] = (Decimal)dto.UsuarioCriacao.Value;
		    if (!dto.DataAlteracao.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.DataAlteracao] = (DateTime)dto.DataAlteracao.Value;
		    if (!dto.UsuarioAlteracao.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.UsuarioAlteracao] = (Decimal)dto.UsuarioAlteracao.Value;
		    if (!dto.Auditado.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.Auditado] = (String)dto.Auditado.Value;
            if (!dto.IdtFilial.Value.IsNull) dtr[LivroRegistroMovimentosDTO.FieldNames.IdtFilial] = (Decimal)dto.IdtFilial.Value;
			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class LivroRegistroMovimentosDTO : MVC.DTO.DTOBase
    {	
		private MVC.DTO.FieldDecimal mtmd_lir_id;
		private MVC.DTO.FieldDecimal cad_uni_id_unidade;
		private MVC.DTO.FieldDecimal cad_mtmd_id;
		private MVC.DTO.FieldDateTime mtmd_lir_dt_registro;
		private MVC.DTO.FieldString mtmd_lir_ds_historico;
		private MVC.DTO.FieldString mtmd_lir_ds_historico_manual;
		private MVC.DTO.FieldDecimal mtmd_lir_qt_entrada;
		private MVC.DTO.FieldDecimal mtmd_lir_qt_saida;
		private MVC.DTO.FieldDecimal mtmd_lir_qt_perda;
		private MVC.DTO.FieldDecimal mtmd_lir_qt_estoque;
		private MVC.DTO.FieldString mtmd_lir_ds_observacao;
		private MVC.DTO.FieldDateTime mtmd_lir_dt_criacao;
		private MVC.DTO.FieldDecimal seg_usu_id_usuario_criacao;
		private MVC.DTO.FieldDateTime mtmd_lir_dt_atualizacao;
		private MVC.DTO.FieldDecimal seg_usu_id_usuario_atualizacao;
		private MVC.DTO.FieldString mtmd_lir_fl_auditado;        
        private MVC.DTO.FieldDecimal cad_mtmd_filial_id;

        public LivroRegistroMovimentosDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
            this.mtmd_lir_id = new MVC.DTO.FieldDecimal(FieldNames.IdtLivro, Captions.IdtLivro, DbType.Decimal);
            this.cad_uni_id_unidade = new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade, Captions.IdtUnidade, DbType.Decimal);
            this.cad_mtmd_id = new MVC.DTO.FieldDecimal(FieldNames.IdtProduto, Captions.IdtProduto, DbType.Decimal);
            this.mtmd_lir_dt_registro = new MVC.DTO.FieldDateTime(FieldNames.DataRegistro, Captions.DataRegistro);
            this.mtmd_lir_ds_historico = new MVC.DTO.FieldString(FieldNames.Historico, Captions.Historico, 250);
            this.mtmd_lir_ds_historico_manual = new MVC.DTO.FieldString(FieldNames.HistoricoManual, Captions.HistoricoManual, 250);
            this.mtmd_lir_qt_entrada = new MVC.DTO.FieldDecimal(FieldNames.QtdEntrada, Captions.QtdEntrada, DbType.Decimal);
            this.mtmd_lir_qt_saida = new MVC.DTO.FieldDecimal(FieldNames.QtdSaida, Captions.QtdSaida, DbType.Decimal);
            this.mtmd_lir_qt_perda = new MVC.DTO.FieldDecimal(FieldNames.QtdPerda, Captions.QtdPerda, DbType.Decimal);
            this.mtmd_lir_qt_estoque = new MVC.DTO.FieldDecimal(FieldNames.QtdEstoque, Captions.QtdEstoque, DbType.Decimal);
            this.mtmd_lir_ds_observacao = new MVC.DTO.FieldString(FieldNames.Observacao, Captions.Observacao, 250);
            this.mtmd_lir_dt_criacao = new MVC.DTO.FieldDateTime(FieldNames.DataCriacao, Captions.DataCriacao);
            this.seg_usu_id_usuario_criacao = new MVC.DTO.FieldDecimal(FieldNames.UsuarioCriacao, Captions.UsuarioCriacao, DbType.Decimal);
            this.mtmd_lir_dt_atualizacao = new MVC.DTO.FieldDateTime(FieldNames.DataAlteracao, Captions.DataAlteracao);
            this.seg_usu_id_usuario_atualizacao = new MVC.DTO.FieldDecimal(FieldNames.UsuarioAlteracao, Captions.UsuarioAlteracao, DbType.Decimal);
            this.mtmd_lir_fl_auditado = new MVC.DTO.FieldString(FieldNames.Auditado, Captions.Auditado, 1);
            this.cad_mtmd_filial_id = new MVC.DTO.FieldDecimal(FieldNames.IdtFilial, Captions.IdtFilial, DbType.Decimal);
        }
 
        #region FieldNames

        public struct FieldNames
        {
		    public const string IdtLivro="MTMD_LIR_ID";
		    public const string IdtUnidade="CAD_UNI_ID_UNIDADE";
		    public const string IdtProduto="CAD_MTMD_ID";
		    public const string DataRegistro="MTMD_LIR_DT_REGISTRO";
		    public const string Historico="MTMD_LIR_DS_HISTORICO";
		    public const string HistoricoManual="MTMD_LIR_DS_HISTORICO_MANUAL";
		    public const string QtdEntrada="MTMD_LIR_QT_ENTRADA";
		    public const string QtdSaida="MTMD_LIR_QT_SAIDA";
		    public const string QtdPerda="MTMD_LIR_QT_PERDA";
		    public const string QtdEstoque="MTMD_LIR_QT_ESTOQUE";
		    public const string Observacao="MTMD_LIR_DS_OBSERVACAO";
		    public const string DataCriacao="MTMD_LIR_DT_CRIACAO";
		    public const string UsuarioCriacao="SEG_USU_ID_USUARIO_CRIACAO";
		    public const string DataAlteracao="MTMD_LIR_DT_ATUALIZACAO";
		    public const string UsuarioAlteracao="SEG_USU_ID_USUARIO_ATUALIZACAO";
		    public const string Auditado="MTMD_LIR_FL_AUDITADO";
            public const string IdtFilial = "CAD_MTMD_FILIAL_ID";
        }		

        #endregion

        #region Captions
        public struct Captions
        {
			public const string IdtLivro="IDTLIVRO";
		    public const string IdtUnidade="IDTUNIDADE";
		    public const string IdtProduto="IDTPRODUTO";
		    public const string DataRegistro="DATAREGISTRO";
		    public const string Historico="HISTORICO";
		    public const string HistoricoManual="HISTORICOMANUAL";
		    public const string QtdEntrada="QTDENTRADA";
		    public const string QtdSaida="QTDSAIDA";
		    public const string QtdPerda="QTDPERDA";
		    public const string QtdEstoque="QTDESTOQUE";
		    public const string Observacao="OBSERVACAO";
		    public const string DataCriacao="DATACRIACAO";
		    public const string UsuarioCriacao="USUARIOCRIACAO";
		    public const string DataAlteracao="DATAALTERACAO";
		    public const string UsuarioAlteracao="USUARIOALTERACAO";
		    public const string Auditado="AUDITADO";
            public const string IdtFilial = "FILIALID";
        }		

        #endregion
		
        #region Atributos Publicos		
			 
		public MVC.DTO.FieldDecimal IdtLivro
		{
			get { return mtmd_lir_id; }
			set { mtmd_lir_id = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtUnidade
		{
			get { return cad_uni_id_unidade; }
			set { cad_uni_id_unidade = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtProduto
		{
			get { return cad_mtmd_id; }
			set { cad_mtmd_id = value; }
		}
		
			 
		public MVC.DTO.FieldDateTime DataRegistro
		{
			get { return mtmd_lir_dt_registro; }
			set { mtmd_lir_dt_registro = value; }
		}
		
			 
		public MVC.DTO.FieldString Historico
		{
			get { return mtmd_lir_ds_historico; }
			set { mtmd_lir_ds_historico = value; }
		}
		
			 
		public MVC.DTO.FieldString HistoricoManual
		{
			get { return mtmd_lir_ds_historico_manual; }
			set { mtmd_lir_ds_historico_manual = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal QtdEntrada
		{
			get { return mtmd_lir_qt_entrada; }
			set { mtmd_lir_qt_entrada = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal QtdSaida
		{
			get { return mtmd_lir_qt_saida; }
			set { mtmd_lir_qt_saida = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal QtdPerda
		{
			get { return mtmd_lir_qt_perda; }
			set { mtmd_lir_qt_perda = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal QtdEstoque
		{
			get { return mtmd_lir_qt_estoque; }
			set { mtmd_lir_qt_estoque = value; }
		}
		
			 
		public MVC.DTO.FieldString Observacao
		{
			get { return mtmd_lir_ds_observacao; }
			set { mtmd_lir_ds_observacao = value; }
		}
		
			 
		public MVC.DTO.FieldDateTime DataCriacao
		{
			get { return mtmd_lir_dt_criacao; }
			set { mtmd_lir_dt_criacao = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal UsuarioCriacao
		{
			get { return seg_usu_id_usuario_criacao; }
			set { seg_usu_id_usuario_criacao = value; }
		}
		
			 
		public MVC.DTO.FieldDateTime DataAlteracao
		{
			get { return mtmd_lir_dt_atualizacao; }
			set { mtmd_lir_dt_atualizacao = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal UsuarioAlteracao
		{
			get { return seg_usu_id_usuario_atualizacao; }
			set { seg_usu_id_usuario_atualizacao = value; }
		}
		
			 
		public MVC.DTO.FieldString Auditado
		{
			get { return mtmd_lir_fl_auditado; }
			set { mtmd_lir_fl_auditado = value; }
		}

        public MVC.DTO.FieldDecimal IdtFilial
        {
            get { return cad_mtmd_filial_id; }
            set { cad_mtmd_filial_id = value; }
        }	

		#endregion

        #region Operators

        public static explicit operator LivroRegistroMovimentosDTO(DataRow row)
        {
            LivroRegistroMovimentosDTO  dto = new LivroRegistroMovimentosDTO();
			dto.IdtLivro.Value = row[FieldNames.IdtLivro].ToString();
			dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();
			dto.IdtProduto.Value = row[FieldNames.IdtProduto].ToString();
			dto.DataRegistro.Value = row[FieldNames.DataRegistro].ToString();
			dto.Historico.Value = row[FieldNames.Historico].ToString();
			dto.HistoricoManual.Value = row[FieldNames.HistoricoManual].ToString();
			dto.QtdEntrada.Value = row[FieldNames.QtdEntrada].ToString();
			dto.QtdSaida.Value = row[FieldNames.QtdSaida].ToString();
			dto.QtdPerda.Value = row[FieldNames.QtdPerda].ToString();
			dto.QtdEstoque.Value = row[FieldNames.QtdEstoque].ToString();
			dto.Observacao.Value = row[FieldNames.Observacao].ToString();
			dto.DataCriacao.Value = row[FieldNames.DataCriacao].ToString();
			dto.UsuarioCriacao.Value = row[FieldNames.UsuarioCriacao].ToString();
			dto.DataAlteracao.Value = row[FieldNames.DataAlteracao].ToString();
			dto.UsuarioAlteracao.Value = row[FieldNames.UsuarioAlteracao].ToString();
			dto.Auditado.Value = row[FieldNames.Auditado].ToString();
            dto.IdtFilial.Value = row[FieldNames.IdtFilial].ToString();			
			
            return dto;
        }        

        public static explicit operator DataRow(LivroRegistroMovimentosDTO dto)
        {
            DataTable dtb = new DataTable();
            DataRow dtr = dtb.NewRow();
			dtr[FieldNames.IdtLivro] = dto.IdtLivro.Value;
			dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;
			dtr[FieldNames.IdtProduto] = dto.IdtProduto.Value;
			dtr[FieldNames.DataRegistro] = dto.DataRegistro.Value;
			dtr[FieldNames.Historico] = dto.Historico.Value;
			dtr[FieldNames.HistoricoManual] = dto.HistoricoManual.Value;
			dtr[FieldNames.QtdEntrada] = dto.QtdEntrada.Value;
			dtr[FieldNames.QtdSaida] = dto.QtdSaida.Value;
			dtr[FieldNames.QtdPerda] = dto.QtdPerda.Value;
			dtr[FieldNames.QtdEstoque] = dto.QtdEstoque.Value;
			dtr[FieldNames.Observacao] = dto.Observacao.Value;
			dtr[FieldNames.DataCriacao] = dto.DataCriacao.Value;
			dtr[FieldNames.UsuarioCriacao] = dto.UsuarioCriacao.Value;
			dtr[FieldNames.DataAlteracao] = dto.DataAlteracao.Value;
			dtr[FieldNames.UsuarioAlteracao] = dto.UsuarioAlteracao.Value;
			dtr[FieldNames.Auditado] = dto.Auditado.Value;
            dtr[FieldNames.IdtFilial] = dto.IdtFilial.Value;
			
            return dtr;
        }        

        #endregion
    }
}