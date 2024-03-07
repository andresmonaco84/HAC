
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
	/// Classe Entidade MovimentacaoComplementoDataTable
	/// </summary>
	[Serializable()]
	public class MovimentacaoComplementoDataTable : DataTable
	{
		
	    public MovimentacaoComplementoDataTable()
            : base()
        {
            this.TableName = "DADOS";

			this.Columns.Add(MovimentacaoComplementoDTO.FieldNames.Idt, typeof(Decimal));
		    this.Columns.Add(MovimentacaoComplementoDTO.FieldNames.Obs, typeof(String));
		    this.Columns.Add(MovimentacaoComplementoDTO.FieldNames.UsuarioRelatado, typeof(String));
            this.Columns.Add(MovimentacaoComplementoDTO.FieldNames.IdtLocalEstoque, typeof(Decimal));
            this.Columns.Add(MovimentacaoComplementoDTO.FieldNames.idtMotivo, typeof(Decimal));            		

            DataColumn[] primaryKey = { this.Columns[MovimentacaoComplementoDTO.FieldNames.Idt] };
                       

            this.PrimaryKey = primaryKey;
        }
		
        protected MovimentacaoComplementoDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public MovimentacaoComplementoDTO TypedRow(int index)
        {
            return (MovimentacaoComplementoDTO)this.Rows[index];
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

        public void Add(MovimentacaoComplementoDTO dto)
        {
            DataRow dtr = this.NewRow();


		    if (!dto.Idt.Value.IsNull) dtr[MovimentacaoComplementoDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		    if (!dto.Obs.Value.IsNull) dtr[MovimentacaoComplementoDTO.FieldNames.Obs] = (String)dto.Obs.Value;
		    if (!dto.UsuarioRelatado.Value.IsNull) dtr[MovimentacaoComplementoDTO.FieldNames.UsuarioRelatado] = (String)dto.UsuarioRelatado.Value;
            if (!dto.IdtLocalEstoque.Value.IsNull) dtr[MovimentacaoComplementoDTO.FieldNames.IdtLocalEstoque] = (Decimal)dto.IdtLocalEstoque.Value;
            if (!dto.idtMotivo.Value.IsNull) dtr[MovimentacaoComplementoDTO.FieldNames.idtMotivo] = (Decimal)dto.idtMotivo.Value;

			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class MovimentacaoComplementoDTO : MVC.DTO.DTOBase
    {	
		private MVC.DTO.FieldDecimal mtmd_mov_id;
		private MVC.DTO.FieldString mtmd_mov_obs;
		private MVC.DTO.FieldString mtmd_mov_usu_relatado;
        private MVC.DTO.FieldDecimal mtmd_id_tp_ccusto;
        private MVC.DTO.FieldDecimal mtmd_id_motivo;
               

        public MovimentacaoComplementoDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
			this.mtmd_mov_id= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
	        this.mtmd_mov_obs= new MVC.DTO.FieldString(FieldNames.Obs,Captions.Obs, 100);
	        this.mtmd_mov_usu_relatado= new MVC.DTO.FieldString(FieldNames.UsuarioRelatado,Captions.UsuarioRelatado, 50);
            this.mtmd_id_tp_ccusto = new MVC.DTO.FieldDecimal(FieldNames.IdtLocalEstoque, Captions.IdtLocalEstoque, DbType.Decimal);
            this.mtmd_id_motivo = new MVC.DTO.FieldDecimal(FieldNames.idtMotivo, Captions.idtMotivo, DbType.Decimal);
                        
        }
 
        #region FieldNames

        public struct FieldNames
        {
			public const string Idt="MTMD_MOV_ID";
		    public const string Obs="MTMD_MOV_OBS";
		    public const string UsuarioRelatado="MTMD_MOV_USU_RELATADO";
            public const string IdtLocalEstoque = "MTMD_ID_TP_CCUSTO";
            public const string idtMotivo = "MTMD_ID_MOTIVO";
                        
        }		

        #endregion

        #region Captions
        public struct Captions
        {
		    public const string Idt="IDT";
		    public const string Obs="OBS";
		    public const string UsuarioRelatado="USUARIORELATADO";
            public const string IdtLocalEstoque = "IDTCCUSTO";
            public const string idtMotivo = "idtMotivo";
            
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal Idt
		{
			get { return mtmd_mov_id; }
			set { mtmd_mov_id = value; }
		}

		/// <summary>
		/// Observação da Movimentação ( complemento )
		/// </summary>
		public MVC.DTO.FieldString Obs
		{
			get { return mtmd_mov_obs; }
			set { mtmd_mov_obs = value; }
		}
		
        /// <summary>
        /// Usuário relacionado com o complemento da observação, normalmente usado para registro de perda ( complemento )
        /// </summary>
		public MVC.DTO.FieldString UsuarioRelatado
		{
			get { return mtmd_mov_usu_relatado; }
			set { mtmd_mov_usu_relatado = value; }
		}

        public MVC.DTO.FieldDecimal IdtLocalEstoque
        {
            get { return mtmd_id_tp_ccusto; }
            set { mtmd_id_tp_ccusto = value; }
        }

        public MVC.DTO.FieldDecimal idtMotivo
        {
            get { return mtmd_id_motivo; }
            set { mtmd_id_motivo = value; }
        }

        
			
		#endregion


        #region Operators

        public static explicit operator MovimentacaoComplementoDTO(DataRow row)
        {
            MovimentacaoComplementoDTO  dto = new MovimentacaoComplementoDTO();
			
				dto.Idt.Value = row[FieldNames.Idt].ToString();
			
				dto.Obs.Value = row[FieldNames.Obs].ToString();
			
				dto.UsuarioRelatado.Value = row[FieldNames.UsuarioRelatado].ToString();

                dto.IdtLocalEstoque.Value = row[FieldNames.IdtLocalEstoque].ToString();

                dto.idtMotivo.Value = row[FieldNames.idtMotivo].ToString();
                            
			
            return dto;
        }

        public static explicit operator MovimentacaoComplementoDTO(XmlDocument xml)
        {
            MovimentacaoComplementoDTO dto = new MovimentacaoComplementoDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Obs) != null) dto.Obs.Value = xml.FirstChild.SelectSingleNode(FieldNames.Obs).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.UsuarioRelatado) != null) dto.UsuarioRelatado.Value = xml.FirstChild.SelectSingleNode(FieldNames.UsuarioRelatado).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalEstoque) != null) dto.IdtLocalEstoque.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalEstoque).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.idtMotivo) != null) dto.idtMotivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.idtMotivo).InnerText;

			
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodeObs = xml.CreateNode(XmlNodeType.Element, FieldNames.Obs, null);
			
            XmlNode nodeUsuarioRelatado = xml.CreateNode(XmlNodeType.Element, FieldNames.UsuarioRelatado, null);

            XmlNode nodeIdtLocalEstoque = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocalEstoque, null);

            XmlNode nodeidtMotivo = xml.CreateNode(XmlNodeType.Element, FieldNames.idtMotivo, null);

			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			
			if (!this.Obs.Value.IsNull) nodeObs.InnerText = this.Obs.Value;
			
			if (!this.UsuarioRelatado.Value.IsNull) nodeUsuarioRelatado.InnerText = this.UsuarioRelatado.Value;

            if (!this.IdtLocalEstoque.Value.IsNull) nodeIdtLocalEstoque.InnerText = this.IdtLocalEstoque.Value;

            if (!this.idtMotivo.Value.IsNull) nodeidtMotivo.InnerText = this.idtMotivo.Value;

           
            nodeData.AppendChild(nodeIdt);
			
            nodeData.AppendChild(nodeObs);
			
            nodeData.AppendChild(nodeUsuarioRelatado);

            nodeData.AppendChild(nodeIdtLocalEstoque);

            nodeData.AppendChild(nodeidtMotivo);

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(MovimentacaoComplementoDTO dto)
        {
            MovimentacaoComplementoDataTable dtb = new MovimentacaoComplementoDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
			
            dtr[FieldNames.Obs] = dto.Obs.Value;
			
            dtr[FieldNames.UsuarioRelatado] = dto.UsuarioRelatado.Value;

            dtr[FieldNames.IdtLocalEstoque] = dto.IdtLocalEstoque.Value;

            dtr[FieldNames.idtMotivo] = dto.idtMotivo.Value;
            
			
            return dtr;
        }

        public static explicit operator XmlDocument(MovimentacaoComplementoDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


