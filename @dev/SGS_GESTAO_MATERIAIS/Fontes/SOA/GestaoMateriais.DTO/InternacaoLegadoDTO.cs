
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
	/// Classe Entidade InternacaoLegadoDataTable
	/// </summary>
	[Serializable()]
	public class InternacaoLegadoDataTable : DataTable
	{
		
	    public InternacaoLegadoDataTable()
            : base()
        {
            this.TableName = "DADOS";

		    this.Columns.Add(InternacaoLegadoDTO.FieldNames.Idt, typeof(Decimal));
		    this.Columns.Add(InternacaoLegadoDTO.FieldNames.NomePaciente, typeof(String));
		    this.Columns.Add(InternacaoLegadoDTO.FieldNames.DescricaoEmpresa, typeof(String));
		    this.Columns.Add(InternacaoLegadoDTO.FieldNames.CodigoConvenio, typeof(String));
		    this.Columns.Add(InternacaoLegadoDTO.FieldNames.SetorInternacao, typeof(String));
		    this.Columns.Add(InternacaoLegadoDTO.FieldNames.CodQuarto, typeof(Decimal));
		    this.Columns.Add(InternacaoLegadoDTO.FieldNames.CodLeito, typeof(Decimal));
            this.Columns.Add(InternacaoLegadoDTO.FieldNames.DtInternacao, typeof(DateTime));
            this.Columns.Add(InternacaoLegadoDTO.FieldNames.DtNascimento, typeof(DateTime));
            this.Columns.Add(InternacaoLegadoDTO.FieldNames.TipoPlano, typeof(String));

            // Setores
            this.Columns.Add(InternacaoLegadoDTO.FieldNames.IdtSetor, typeof(Decimal));
            this.Columns.Add(InternacaoLegadoDTO.FieldNames.IdtLocalAtendimento, typeof(Decimal));
            this.Columns.Add(InternacaoLegadoDTO.FieldNames.IdtUnidade, typeof(Decimal));


            // DataColumn[] primaryKey = { this.Columns[InternacaoLegadoDTO.FieldNames.Idt] };

            // this.PrimaryKey = primaryKey;
        }
		
        protected InternacaoLegadoDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}

		public InternacaoLegadoDTO TypedRow(int index)
        {
            return (InternacaoLegadoDTO)this.Rows[index];
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

        public void Add(InternacaoLegadoDTO dto)
        {
            DataRow dtr = this.NewRow();

		    if (!dto.Idt.Value.IsNull) dtr[InternacaoLegadoDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		    if (!dto.NomePaciente.Value.IsNull) dtr[InternacaoLegadoDTO.FieldNames.NomePaciente] = (String)dto.NomePaciente.Value;
		    if (!dto.DescricaoEmpresa.Value.IsNull) dtr[InternacaoLegadoDTO.FieldNames.DescricaoEmpresa] = (String)dto.DescricaoEmpresa.Value;
		    if (!dto.CodigoConvenio.Value.IsNull) dtr[InternacaoLegadoDTO.FieldNames.CodigoConvenio] = (String)dto.CodigoConvenio.Value;
		    if (!dto.SetorInternacao.Value.IsNull) dtr[InternacaoLegadoDTO.FieldNames.SetorInternacao] = (String)dto.SetorInternacao.Value;
		    if (!dto.CodQuarto.Value.IsNull) dtr[InternacaoLegadoDTO.FieldNames.CodQuarto] = (Decimal)dto.CodQuarto.Value;
            if (!dto.DtInternacao.Value.IsNull) dtr[InternacaoLegadoDTO.FieldNames.DtInternacao] = (DateTime)dto.DtInternacao.Value;
            if (!dto.DtNascimento.Value.IsNull) dtr[InternacaoLegadoDTO.FieldNames.DtNascimento] = (DateTime)dto.DtNascimento.Value;
            if (!dto.TipoPlano.Value.IsNull) dtr[InternacaoLegadoDTO.FieldNames.TipoPlano] = (String)dto.TipoPlano.Value;

            // Setores
            if (!dto.IdtSetor.Value.IsNull) dtr[InternacaoLegadoDTO.FieldNames.IdtSetor] = (Decimal)dto.IdtSetor.Value;
            if (!dto.IdtLocalAtendimento.Value.IsNull) dtr[InternacaoLegadoDTO.FieldNames.IdtLocalAtendimento] = (Decimal)dto.IdtLocalAtendimento.Value;
            if (!dto.IdtUnidade.Value.IsNull) dtr[InternacaoLegadoDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;

            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class InternacaoLegadoDTO : MVC.DTO.DTOBase
    {	
		private MVC.DTO.FieldDecimal nr_seqinter;
		private MVC.DTO.FieldString nompac;
		private MVC.DTO.FieldString nomemp;
		private MVC.DTO.FieldString codcon;
		private MVC.DTO.FieldString ds_setor;
		private MVC.DTO.FieldDecimal cod_quarto;
		private MVC.DTO.FieldDecimal cod_leito;
        private MVC.DTO.FieldDateTime dt_internacao;
        private MVC.DTO.FieldDateTime dt_nascimento;
        private MVC.DTO.FieldString tipoPlano;
        // Setores
        private MVC.DTO.FieldDecimal cad_set_id;
        private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
        private MVC.DTO.FieldDecimal cad_uni_id_unidade;


        public InternacaoLegadoDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
		    this.nr_seqinter= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		    this.nompac= new MVC.DTO.FieldString(FieldNames.NomePaciente,Captions.NomePaciente, 52);
		    this.nomemp= new MVC.DTO.FieldString(FieldNames.DescricaoEmpresa,Captions.DescricaoEmpresa, 53);
		    this.codcon= new MVC.DTO.FieldString(FieldNames.CodigoConvenio,Captions.CodigoConvenio, 4);
		    this.ds_setor= new MVC.DTO.FieldString(FieldNames.SetorInternacao,Captions.SetorInternacao, 30);
		    this.cod_quarto= new MVC.DTO.FieldDecimal(FieldNames.CodQuarto,Captions.CodQuarto, DbType.Decimal);
		    this.cod_leito= new MVC.DTO.FieldDecimal(FieldNames.CodLeito,Captions.CodLeito, DbType.Decimal);
            this.dt_internacao = new MVC.DTO.FieldDateTime(FieldNames.DtInternacao, Captions.DtInternacao);
            this.dt_nascimento = new MVC.DTO.FieldDateTime(FieldNames.DtNascimento, Captions.DtNascimento);
            this.tipoPlano = new MVC.DTO.FieldString(FieldNames.TipoPlano, Captions.TipoPlano, 4);
            // Setores
            this.cad_set_id = new MVC.DTO.FieldDecimal(FieldNames.IdtSetor, Captions.IdtSetor, DbType.Decimal);
            this.cad_lat_id_local_atendimento = new MVC.DTO.FieldDecimal(FieldNames.IdtLocalAtendimento, Captions.IdtLocalAtendimento, DbType.Decimal);
            this.cad_uni_id_unidade = new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade, Captions.IdtUnidade, DbType.Decimal);

        }
 
        #region FieldNames

        public struct FieldNames
        {
		    public const string Idt="NR_SEQINTER";
		    public const string NomePaciente="NOMPAC";
		    public const string DescricaoEmpresa="NOMEMP";
		    public const string CodigoConvenio="CODCON";
		    public const string SetorInternacao="DS_SETOR";
		    public const string CodQuarto="COD_QUARTO";
		    public const string CodLeito="COD_LEITO";
            public const string DtInternacao = "DT_INT";
            public const string DtNascimento = "DATNASPAC";
            public const string TipoPlano = "CAD_PLA_CD_TIPOPLANO";
            //Setores
            public const string IdtSetor = "CAD_SET_ID";
            public const string IdtLocalAtendimento = "CAD_LAT_ID_LOCAL_ATENDIMENTO";
            public const string IdtUnidade = "CAD_UNI_ID_UNIDADE";

        }		

        #endregion

        #region Captions
        public struct Captions
        {
		    public const string Idt="IDT";
		    public const string NomePaciente="NOMEPACIENTE";
		    public const string DescricaoEmpresa="DESCRICAOEMPRESA";
		    public const string CodigoConvenio="CODIGOCONVENIO";
		    public const string SetorInternacao="SETORINTERNACAO";
		    public const string CodQuarto="CODQUARTO";
		    public const string CodLeito="CODLEITO";
            public const string DtInternacao = "DATAINTERNACAO";
            public const string DtNascimento = "DATANASCIMENTO";
            public const string TipoPlano = "CADPLACDTIPOPLANO";
            //Setores
            public const string IdtSetor = "IdtSetor";
            public const string IdtLocalAtendimento = "IdtLocalAtendimento";
            public const string IdtUnidade = "IdtUnidade";

        }		

        #endregion
		
        #region Atributos Publicos
		
		public MVC.DTO.FieldDecimal Idt
		{
			get { return nr_seqinter; }
			set { nr_seqinter = value; }
		}
		
		public MVC.DTO.FieldString NomePaciente
		{
			get { return nompac; }
			set { nompac = value; }
		}
		
		public MVC.DTO.FieldString DescricaoEmpresa
		{
			get { return nomemp; }
			set { nomemp = value; }
		}
		
		public MVC.DTO.FieldString CodigoConvenio
		{
			get { return codcon; }
			set { codcon = value; }
		}
		
		public MVC.DTO.FieldString SetorInternacao
		{
			get { return ds_setor; }
			set { ds_setor = value; }
		}
		
		public MVC.DTO.FieldDecimal CodQuarto
		{
			get { return cod_quarto; }
			set { cod_quarto = value; }
		}
		
		public MVC.DTO.FieldDecimal CodLeito
		{
			get { return cod_leito; }
			set { cod_leito = value; }
		}

        public MVC.DTO.FieldDateTime DtInternacao
        {
            get { return dt_internacao; }
            set { dt_internacao = value; }
        }

        public MVC.DTO.FieldDateTime DtNascimento
        {
            get { return dt_nascimento; }
            set { dt_nascimento = value; }
        }

        public MVC.DTO.FieldString TipoPlano
        {
            get { return tipoPlano; }
            set { tipoPlano = value; }
        }

        //SETORES
        /// <summary>
        /// Id do Setor de Atendimento
        /// </summary>
        public MVC.DTO.FieldDecimal IdtSetor
        {
            get { return cad_set_id; }
            set { cad_set_id = value; }
        }

        /// <summary>
        /// Id do Local de Atendimento
        /// </summary>
        public MVC.DTO.FieldDecimal IdtLocalAtendimento
        {
            get { return cad_lat_id_local_atendimento; }
            set { cad_lat_id_local_atendimento = value; }
        }

        /// <summary>
        /// Id da Unidade de Atendimento
        /// </summary>
        public MVC.DTO.FieldDecimal IdtUnidade
        {
            get { return cad_uni_id_unidade; }
            set { cad_uni_id_unidade = value; }
        }


		#endregion

        #region Operators

        public static explicit operator InternacaoLegadoDTO(DataRow row)
        {
                InternacaoLegadoDTO  dto = new InternacaoLegadoDTO();
			
				dto.Idt.Value = row[FieldNames.Idt].ToString();
			
				dto.NomePaciente.Value = row[FieldNames.NomePaciente].ToString();
			
				dto.DescricaoEmpresa.Value = row[FieldNames.DescricaoEmpresa].ToString();
			
				dto.CodigoConvenio.Value = row[FieldNames.CodigoConvenio].ToString();
			
				dto.SetorInternacao.Value = row[FieldNames.SetorInternacao].ToString();
			
				dto.CodQuarto.Value = row[FieldNames.CodQuarto].ToString();
			
				dto.CodLeito.Value = row[FieldNames.CodLeito].ToString();

                dto.DtInternacao.Value = row[FieldNames.DtInternacao].ToString();

                dto.DtNascimento.Value = row[FieldNames.DtNascimento].ToString();

                dto.TipoPlano.Value = row[FieldNames.TipoPlano].ToString();
                //Setores
                dto.IdtSetor.Value = row[FieldNames.IdtSetor].ToString();

                dto.IdtLocalAtendimento.Value = row[FieldNames.IdtLocalAtendimento].ToString();

                dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();

			
            return dto;
        }

        public static explicit operator InternacaoLegadoDTO(XmlDocument xml)
        {
            InternacaoLegadoDTO dto = new InternacaoLegadoDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.NomePaciente) != null) dto.NomePaciente.Value = xml.FirstChild.SelectSingleNode(FieldNames.NomePaciente).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DescricaoEmpresa) != null) dto.DescricaoEmpresa.Value = xml.FirstChild.SelectSingleNode(FieldNames.DescricaoEmpresa).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.CodigoConvenio) != null) dto.CodigoConvenio.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodigoConvenio).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.SetorInternacao) != null) dto.SetorInternacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.SetorInternacao).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.CodQuarto) != null) dto.CodQuarto.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodQuarto).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.CodLeito) != null) dto.CodLeito.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodLeito).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.DtInternacao) != null) dto.DtInternacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtInternacao).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.DtNascimento) != null) dto.DtNascimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtNascimento).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.TipoPlano) != null) dto.TipoPlano.Value = xml.FirstChild.SelectSingleNode(FieldNames.TipoPlano).InnerText;
                // SETORES
                if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor) != null) dto.IdtSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalAtendimento) != null) dto.IdtLocalAtendimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalAtendimento).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;


            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodeNomePaciente = xml.CreateNode(XmlNodeType.Element, FieldNames.NomePaciente, null);
			
            XmlNode nodeDescricaoEmpresa = xml.CreateNode(XmlNodeType.Element, FieldNames.DescricaoEmpresa, null);
			
            XmlNode nodeCodigoConvenio = xml.CreateNode(XmlNodeType.Element, FieldNames.CodigoConvenio, null);
			
            XmlNode nodeSetorInternacao = xml.CreateNode(XmlNodeType.Element, FieldNames.SetorInternacao, null);
			
            XmlNode nodeCodQuarto = xml.CreateNode(XmlNodeType.Element, FieldNames.CodQuarto, null);
			
            XmlNode nodeCodLeito = xml.CreateNode(XmlNodeType.Element, FieldNames.CodLeito, null);

            XmlNode nodeDtInternacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DtInternacao, null);

            XmlNode nodeDtNascimento = xml.CreateNode(XmlNodeType.Element, FieldNames.DtNascimento, null);

            XmlNode nodeTipoPlano = xml.CreateNode(XmlNodeType.Element, FieldNames.TipoPlano, null);
            //Setores
            XmlNode nodeIdtSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSetor, null);

            XmlNode nodeIdtLocalAtendimento = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocalAtendimento, null);

            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);

			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			
			if (!this.NomePaciente.Value.IsNull) nodeNomePaciente.InnerText = this.NomePaciente.Value;
			
			if (!this.DescricaoEmpresa.Value.IsNull) nodeDescricaoEmpresa.InnerText = this.DescricaoEmpresa.Value;
			
			if (!this.CodigoConvenio.Value.IsNull) nodeCodigoConvenio.InnerText = this.CodigoConvenio.Value;
			
			if (!this.SetorInternacao.Value.IsNull) nodeSetorInternacao.InnerText = this.SetorInternacao.Value;
			
			if (!this.CodQuarto.Value.IsNull) nodeCodQuarto.InnerText = this.CodQuarto.Value;
			
			if (!this.CodLeito.Value.IsNull) nodeCodLeito.InnerText = this.CodLeito.Value;

            if (!this.DtInternacao.Value.IsNull) nodeDtInternacao.InnerText = this.DtInternacao.Value;

            if (!this.DtNascimento.Value.IsNull) nodeDtNascimento.InnerText = this.DtNascimento.Value;

            if (!this.TipoPlano.Value.IsNull) nodeTipoPlano.InnerText = this.TipoPlano.Value;
            //Setores
            if (!this.IdtSetor.Value.IsNull) nodeIdtSetor.InnerText = this.IdtSetor.Value;

            if (!this.IdtLocalAtendimento.Value.IsNull) nodeIdtLocalAtendimento.InnerText = this.IdtLocalAtendimento.Value;

            if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;


            nodeData.AppendChild(nodeIdt);
			
            nodeData.AppendChild(nodeNomePaciente);
			
            nodeData.AppendChild(nodeDescricaoEmpresa);
			
            nodeData.AppendChild(nodeCodigoConvenio);
			
            nodeData.AppendChild(nodeSetorInternacao);
			
            nodeData.AppendChild(nodeCodQuarto);
			
            nodeData.AppendChild(nodeCodLeito);

            nodeData.AppendChild(nodeDtInternacao);

            nodeData.AppendChild(nodeDtNascimento);

            nodeData.AppendChild(nodeTipoPlano);
            //Setores
            nodeData.AppendChild(nodeIdtSetor);

            nodeData.AppendChild(nodeIdtLocalAtendimento);

            nodeData.AppendChild(nodeIdtUnidade);

						
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(InternacaoLegadoDTO dto)
        {
            InternacaoLegadoDataTable dtb = new InternacaoLegadoDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
			
            dtr[FieldNames.NomePaciente] = dto.NomePaciente.Value;
			
            dtr[FieldNames.DescricaoEmpresa] = dto.DescricaoEmpresa.Value;
			
            dtr[FieldNames.CodigoConvenio] = dto.CodigoConvenio.Value;
			
            dtr[FieldNames.SetorInternacao] = dto.SetorInternacao.Value;
			
            dtr[FieldNames.CodQuarto] = dto.CodQuarto.Value;
			
            dtr[FieldNames.CodLeito] = dto.CodLeito.Value;

            dtr[FieldNames.DtInternacao] = dto.DtInternacao.Value;

            dtr[FieldNames.DtNascimento] = dto.DtNascimento.Value;

            dtr[FieldNames.TipoPlano] = dto.TipoPlano.Value;
            //Setores
            dtr[FieldNames.IdtSetor] = dto.IdtSetor.Value;

            dtr[FieldNames.IdtLocalAtendimento] = dto.IdtLocalAtendimento.Value;

            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;

			
            return dtr;
        }

        public static explicit operator XmlDocument(InternacaoLegadoDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}