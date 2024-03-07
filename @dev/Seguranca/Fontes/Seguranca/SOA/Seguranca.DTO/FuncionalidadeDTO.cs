
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using MVC = HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.Seguranca.DTO
{
	/// <summary>
	/// Classe Entidade FuncionalidadeDataTable
	/// </summary>
	[Serializable()]
	public class FuncionalidadeDataTable : DataTable
	{
		
	    public FuncionalidadeDataTable()
            : base()
        {
            this.TableName = "DADOS";

			this.Columns.Add(FuncionalidadeDTO.FieldNames.Idt, typeof(Decimal));
		    this.Columns.Add(FuncionalidadeDTO.FieldNames.DsFuncionalidade, typeof(String));
		    this.Columns.Add(FuncionalidadeDTO.FieldNames.FlItemMenu, typeof(String));
		    this.Columns.Add(FuncionalidadeDTO.FieldNames.IdtFuncionalidadePai, typeof(Decimal));
		    this.Columns.Add(FuncionalidadeDTO.FieldNames.NmPagina, typeof(String));
		    this.Columns.Add(FuncionalidadeDTO.FieldNames.NmFuncionalidade, typeof(String));
		    this.Columns.Add(FuncionalidadeDTO.FieldNames.IdtModulo, typeof(Decimal));
            this.Columns.Add(FuncionalidadeDTO.FieldNames.IdtSistema, typeof(Decimal));
            this.Columns.Add(FuncionalidadeDTO.FieldNames.FiltraAssociados, typeof(Decimal));
            this.Columns.Add(FuncionalidadeDTO.FieldNames.IdtPerfil, typeof(Decimal));

            
            DataColumn[] primaryKey = { this.Columns[FuncionalidadeDTO.FieldNames.Idt] };

            this.PrimaryKey = primaryKey;
        }
		
        protected FuncionalidadeDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public FuncionalidadeDTO TypedRow(int index)
        {
            return (FuncionalidadeDTO)this.Rows[index];
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

        public void Add(FuncionalidadeDTO dto)
        {
            DataRow dtr = this.NewRow();


		    if (!dto.Idt.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		    if (!dto.DsFuncionalidade.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.DsFuncionalidade] = (String)dto.DsFuncionalidade.Value;
		    if (!dto.FlItemMenu.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.FlItemMenu] = (String)dto.FlItemMenu.Value;
		    if (!dto.IdtFuncionalidadePai.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.IdtFuncionalidadePai] = (Decimal)dto.IdtFuncionalidadePai.Value;
		    if (!dto.NmPagina.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.NmPagina] = (String)dto.NmPagina.Value;
		    if (!dto.NmFuncionalidade.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.NmFuncionalidade] = (String)dto.NmFuncionalidade.Value;
		    if (!dto.IdtModulo.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.IdtModulo] = (Decimal)dto.IdtModulo.Value;

            if (!dto.IdtSistema.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.IdtSistema] = (Decimal)dto.IdtSistema.Value;

            if (!dto.FiltraAssociados.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.FiltraAssociados] = (Decimal)dto.FiltraAssociados.Value;

            if (!dto.IdtPerfil.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.IdtPerfil] = (Decimal)dto.IdtPerfil.Value;


            
            
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class FuncionalidadeDTO : MVC.DTO.DTOBase
    {

        public enum Funcionalidades
        {
            ACERTO_DE_ESTOQUE = 350,
            ANALISE_DE_ESTOQUE = 361,
            BAIXA_FRACIONADO_MATERIAL = 337,
            BAIXA_MATERIAL_UNIDADE = 347,
            CADASTROS = 335,
            CODIGO_DE_BARRA = 354,
            CONFIGURACAO_DE_IMPRESSORAS = 355,
            CONFIGURACAO_DE_UNIDADES = 356,
            CONSUMO_PACIENTE = 338,
            DISPENSACAO = 339,
            ESTOQUE = 334,
            ESTOQUE_ONLINE = 351,
            GERACAO_PEDIDO_PADRAO = 340,
            GERENCIAL = 336,
            GRUPOS_E_SUB_GRUPOS = 357,
            IMPRESSAO_DE_PEDIDO_REQUISICAO = 341,
            IMPRESSAO_ETIQUETAS_CD_BARRA = 353,
            IMPRESSOS_E_MATERIAIS_DE_EXPEDIENTE = 345,
            INDICE_DE_ROTATIVIDADE = 362,
            LIBERACAO_PEDIDOS_PENDENTES = 349,
            MANUTENCAO_DE_PRODUTOS = 358,
            MOVIMENTACAO = 333,
            ORIGENS_DE_MOVIMENTACAO = 359,
            PEDIDO_AO_PACIENTE = 342,
            PEDIDO_CARRINHO_EMERGENCIA = 348,
            CADASTRO_PEDIDO_PADRAO = 352,
            PRINCIPIO_ATIVO = 360,
            RECEBIMENTO_PEDIDO_SETOR = 343,
            REGISTRO_DE_PERDAS = 344,
            TRANSFERENCIA_MATMED = 346,
            PESQUISA_PEDIDOS = 397,
            INFORMATICA = 373,
            DISPENSACAO_TESTE = 374,
            DIVERGENCIA_ESTOQUE = 375,
            PESQUISA_MOVIMENTOS = 376,
            HOME_CARE =  392,
            CONSUMO_CENTRO_CURURGICO = 399
        }
        
        public enum FiltraFuncionalidade
        {
            FUNCIONALIDADE_NAO_ASSOCIADA = 0,
            FUNCIONALIDADE_ASSOCIADA = 1,
            TODAS_FUNCIONALIDADES =2
        }

		private MVC.DTO.FieldDecimal seg_fun_id_funcionalidade; 
		private MVC.DTO.FieldString seg_fun_ds_descricao;
		private MVC.DTO.FieldString seg_fun_fl_item_menu_ok;
		private MVC.DTO.FieldDecimal seg_fun_id_funcionalidade_pai;
		private MVC.DTO.FieldString seg_fun_ds_nome_pagina;
		private MVC.DTO.FieldString seg_fun_nm_nome;
		private MVC.DTO.FieldDecimal seg_mod_id_modulo;
        private MVC.DTO.FieldDecimal seg_id_sistema;

        private MVC.DTO.FieldDecimal fl_associados;
        private MVC.DTO.FieldDecimal seg_per_id_perfil;

        

        public FuncionalidadeDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
		    this.seg_fun_id_funcionalidade= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		    this.seg_fun_ds_descricao= new MVC.DTO.FieldString(FieldNames.DsFuncionalidade,Captions.DsFuncionalidade, 100);
		    this.seg_fun_fl_item_menu_ok= new MVC.DTO.FieldString(FieldNames.FlItemMenu,Captions.FlItemMenu, 1);
		    this.seg_fun_id_funcionalidade_pai= new MVC.DTO.FieldDecimal(FieldNames.IdtFuncionalidadePai,Captions.IdtFuncionalidadePai, DbType.Decimal);
		    this.seg_fun_ds_nome_pagina= new MVC.DTO.FieldString(FieldNames.NmPagina,Captions.NmPagina, 100);
		    this.seg_fun_nm_nome= new MVC.DTO.FieldString(FieldNames.NmFuncionalidade,Captions.NmFuncionalidade, 50);
		    this.seg_mod_id_modulo= new MVC.DTO.FieldDecimal(FieldNames.IdtModulo,Captions.IdtModulo, DbType.Decimal);
            this.seg_id_sistema = new MVC.DTO.FieldDecimal(FieldNames.IdtSistema, Captions.IdtSistema, DbType.Decimal);
            this.fl_associados = new MVC.DTO.FieldDecimal(FieldNames.FiltraAssociados, Captions.FiltraAssociados, DbType.Decimal);
            this.seg_per_id_perfil = new MVC.DTO.FieldDecimal(FieldNames.IdtPerfil, Captions.IdtPerfil, DbType.Decimal);
            
            
            
        }
 
        #region FieldNames

        public struct FieldNames
        {
		    public const string Idt="SEG_FUN_ID_FUNCIONALIDADE";
		    public const string DsFuncionalidade="SEG_FUN_DS_DESCRICAO";
		    public const string FlItemMenu="SEG_FUN_FL_ITEM_MENU_OK";
		    public const string IdtFuncionalidadePai="SEG_FUN_ID_FUNCIONALIDADE_PAI";
		    public const string NmPagina="SEG_FUN_DS_NOME_PAGINA";
		    public const string NmFuncionalidade="SEG_FUN_NM_NOME";
		    public const string IdtModulo="SEG_MOD_ID_MODULO";
            public const string IdtSistema = "SEG_ID_SISTEMA";

            public const string FiltraAssociados = "FL_ASSOCIADOS";

            public const string IdtPerfil = "SEG_PER_ID_PERFIL";

                        
            
		
        }		

        #endregion

        #region Captions
        public struct Captions
        {
		    public const string Idt="IDT";
		    public const string DsFuncionalidade="DSFUNCIONALIDADE";
		    public const string FlItemMenu="FLITEMMENU";
		    public const string IdtFuncionalidadePai="IDTFUNCIONALIDADEPAI";
		    public const string NmPagina="NMPAGINA";
		    public const string NmFuncionalidade="NMFUNCIONALIDADE";
		    public const string IdtModulo="IDTMODULO";
            public const string IdtSistema = "IDTSISTEMA";

            public const string FiltraAssociados = "FLASSOCIADOS";

            public const string IdtPerfil = "IDTPERFIL";

            
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal Idt
		{
			get { return seg_fun_id_funcionalidade; }
			set { seg_fun_id_funcionalidade = value; }
		}
		
		public MVC.DTO.FieldString DsFuncionalidade
		{
			get { return seg_fun_ds_descricao; }
			set { seg_fun_ds_descricao = value; }
		}
		
		public MVC.DTO.FieldString FlItemMenu
		{
			get { return seg_fun_fl_item_menu_ok; }
			set { seg_fun_fl_item_menu_ok = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtFuncionalidadePai
		{
			get { return seg_fun_id_funcionalidade_pai; }
			set { seg_fun_id_funcionalidade_pai = value; }
		}
		
		public MVC.DTO.FieldString NmPagina
		{
			get { return seg_fun_ds_nome_pagina; }
			set { seg_fun_ds_nome_pagina = value; }
		}
		
		public MVC.DTO.FieldString NmFuncionalidade
		{
			get { return seg_fun_nm_nome; }
			set { seg_fun_nm_nome = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtModulo
		{
			get { return seg_mod_id_modulo; }
			set { seg_mod_id_modulo = value; }
		}

        public MVC.DTO.FieldDecimal IdtSistema
        {
            get { return seg_id_sistema; }
            set { seg_id_sistema = value; }
        }
        
        public MVC.DTO.FieldDecimal FiltraAssociados
        {
            get { return fl_associados; }
            set { fl_associados = value; }
        }

        public MVC.DTO.FieldDecimal IdtPerfil
        {
            get { return seg_per_id_perfil; }
            set { seg_per_id_perfil = value; }
        }

       
		#endregion


        #region Operators

        public static explicit operator FuncionalidadeDTO(DataRow row)
        {
            FuncionalidadeDTO  dto = new FuncionalidadeDTO();
			
				dto.Idt.Value = row[FieldNames.Idt].ToString();
			
				dto.DsFuncionalidade.Value = row[FieldNames.DsFuncionalidade].ToString();
			
				dto.FlItemMenu.Value = row[FieldNames.FlItemMenu].ToString();
			
				dto.IdtFuncionalidadePai.Value = row[FieldNames.IdtFuncionalidadePai].ToString();
			
				dto.NmPagina.Value = row[FieldNames.NmPagina].ToString();
			
				dto.NmFuncionalidade.Value = row[FieldNames.NmFuncionalidade].ToString();
			
				dto.IdtModulo.Value = row[FieldNames.IdtModulo].ToString();

                dto.IdtSistema.Value = row[FieldNames.IdtSistema].ToString();

                dto.FiltraAssociados.Value = row[FieldNames.FiltraAssociados].ToString();

                dto.IdtPerfil.Value = row[FieldNames.IdtPerfil].ToString();

                           
                
            return dto;
        }

        public static explicit operator FuncionalidadeDTO(XmlDocument xml)
        {
            FuncionalidadeDTO dto = new FuncionalidadeDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DsFuncionalidade) != null) dto.DsFuncionalidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsFuncionalidade).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.FlItemMenu) != null) dto.FlItemMenu.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlItemMenu).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtFuncionalidadePai) != null) dto.IdtFuncionalidadePai.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtFuncionalidadePai).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.NmPagina) != null) dto.NmPagina.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmPagina).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.NmFuncionalidade) != null) dto.NmFuncionalidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmFuncionalidade).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo) != null) dto.IdtModulo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSistema) != null) dto.IdtSistema.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSistema).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.FiltraAssociados) != null) dto.FiltraAssociados.Value = xml.FirstChild.SelectSingleNode(FieldNames.FiltraAssociados).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.IdtPerfil) != null) dto.IdtPerfil.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtPerfil).InnerText;

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodeDsFuncionalidade = xml.CreateNode(XmlNodeType.Element, FieldNames.DsFuncionalidade, null);
			
            XmlNode nodeFlItemMenu = xml.CreateNode(XmlNodeType.Element, FieldNames.FlItemMenu, null);
			
            XmlNode nodeIdtFuncionalidadePai = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtFuncionalidadePai, null);
			
            XmlNode nodeNmPagina = xml.CreateNode(XmlNodeType.Element, FieldNames.NmPagina, null);
			
            XmlNode nodeNmFuncionalidade = xml.CreateNode(XmlNodeType.Element, FieldNames.NmFuncionalidade, null);
			
            XmlNode nodeIdtModulo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtModulo, null);

            XmlNode nodeIdtSistema = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSistema, null);

            XmlNode nodeFiltraAssociados = xml.CreateNode(XmlNodeType.Element, FieldNames.FiltraAssociados, null);

            XmlNode nodeIdtPerfil = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtPerfil, null);

                       

			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			
			if (!this.DsFuncionalidade.Value.IsNull) nodeDsFuncionalidade.InnerText = this.DsFuncionalidade.Value;
			
			if (!this.FlItemMenu.Value.IsNull) nodeFlItemMenu.InnerText = this.FlItemMenu.Value;
			
			if (!this.IdtFuncionalidadePai.Value.IsNull) nodeIdtFuncionalidadePai.InnerText = this.IdtFuncionalidadePai.Value;
			
			if (!this.NmPagina.Value.IsNull) nodeNmPagina.InnerText = this.NmPagina.Value;
			
			if (!this.NmFuncionalidade.Value.IsNull) nodeNmFuncionalidade.InnerText = this.NmFuncionalidade.Value;
			
			if (!this.IdtModulo.Value.IsNull) nodeIdtModulo.InnerText = this.IdtModulo.Value;

            if (!this.IdtSistema.Value.IsNull) nodeIdtSistema.InnerText = this.IdtSistema.Value;

            if (!this.FiltraAssociados.Value.IsNull) nodeFiltraAssociados.InnerText = this.FiltraAssociados.Value;

            if (!this.IdtPerfil.Value.IsNull) nodeIdtPerfil.InnerText = this.IdtPerfil.Value;
                        
            
			
            nodeData.AppendChild(nodeIdt);
			
            nodeData.AppendChild(nodeDsFuncionalidade);
			
            nodeData.AppendChild(nodeFlItemMenu);
			
            nodeData.AppendChild(nodeIdtFuncionalidadePai);
			
            nodeData.AppendChild(nodeNmPagina);
			
            nodeData.AppendChild(nodeNmFuncionalidade);
			
            nodeData.AppendChild(nodeIdtModulo);

            nodeData.AppendChild(nodeIdtSistema);

            nodeData.AppendChild(nodeFiltraAssociados);

            nodeData.AppendChild(nodeIdtPerfil);
                        
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(FuncionalidadeDTO dto)
        {
            FuncionalidadeDataTable dtb = new FuncionalidadeDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
			
            dtr[FieldNames.DsFuncionalidade] = dto.DsFuncionalidade.Value;
			
            dtr[FieldNames.FlItemMenu] = dto.FlItemMenu.Value;
			
            dtr[FieldNames.IdtFuncionalidadePai] = dto.IdtFuncionalidadePai.Value;
			
            dtr[FieldNames.NmPagina] = dto.NmPagina.Value;
			
            dtr[FieldNames.NmFuncionalidade] = dto.NmFuncionalidade.Value;
			
            dtr[FieldNames.IdtModulo] = dto.IdtModulo.Value;

            dtr[FieldNames.IdtSistema] = dto.IdtSistema.Value;

            dtr[FieldNames.FiltraAssociados] = dto.FiltraAssociados.Value;

            dtr[FieldNames.IdtPerfil] = dto.IdtPerfil.Value;


            // IdtPerfil seg_per_id_perfil nodeIdtPerfil
            
            return dtr;
        }

        public static explicit operator XmlDocument(FuncionalidadeDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


