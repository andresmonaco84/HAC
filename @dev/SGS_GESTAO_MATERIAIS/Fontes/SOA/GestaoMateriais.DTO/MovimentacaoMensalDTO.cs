
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
	/// Classe Entidade MovimentacaoMensalDataTable
	/// </summary>
	[Serializable()]
	public class MovimentacaoMensalDataTable : DataTable
	{
		
	    public MovimentacaoMensalDataTable()
            : base()
        {
            this.TableName = "DADOS";

			this.Columns.Add(MovimentacaoMensalDTO.FieldNames.IdtProduto, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.IdtLocal, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.IdtUnidade, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.IdtSetor, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.Mes, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.Ano, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.QtdeEntrada, typeof(Decimal));
            this.Columns.Add(MovimentacaoMensalDTO.FieldNames.QtdeSaida, typeof(Decimal));

            this.Columns.Add(MovimentacaoMensalDTO.FieldNames.VlrEntrada, typeof(Decimal));
            this.Columns.Add(MovimentacaoMensalDTO.FieldNames.VlrSaida, typeof(Decimal));
                
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.TipoMovimento, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.CustoMedio, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.SaldoAtual, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.SaldoAnterior, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.IdtUsuario, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.DataAtualizacao, typeof(DateTime));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.IdtFilial, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.IdtGrupo, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.IdtSubGrupo, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.CustoMedioAnterior, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.VlrTotalMes, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.SubTipoMovimento, typeof(Decimal));
		    this.Columns.Add(MovimentacaoMensalDTO.FieldNames.VlrTotalAnterior, typeof(Decimal));
            this.Columns.Add(MovimentacaoMensalDTO.FieldNames.IndiceRotatividade, typeof(Decimal));

            


			

            // DataColumn[] primaryKey = { this.Columns[MovimentacaoMensalDTO.FieldNames.IdtLocal], this.Columns[MovimentacaoMensalDTO.FieldNames.IdtFilial], this.Columns[MovimentacaoMensalDTO.FieldNames.IdtGrupo], this.Columns[MovimentacaoMensalDTO.FieldNames.IdtProduto], this.Columns[MovimentacaoMensalDTO.FieldNames.IdtSubGrupo], this.Columns[MovimentacaoMensalDTO.FieldNames.SubTipoMovimento], this.Columns[MovimentacaoMensalDTO.FieldNames.IdtSetor], this.Columns[MovimentacaoMensalDTO.FieldNames.IdtUnidade], this.Columns[MovimentacaoMensalDTO.FieldNames.Ano], this.Columns[MovimentacaoMensalDTO.FieldNames.Mes], this.Columns[MovimentacaoMensalDTO.FieldNames.TipoMovimento] };

            // this.PrimaryKey = primaryKey;
        }
		
        protected MovimentacaoMensalDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public MovimentacaoMensalDTO TypedRow(int index)
        {
            return (MovimentacaoMensalDTO)this.Rows[index];
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

        public void Add(MovimentacaoMensalDTO dto)
        {
            DataRow dtr = this.NewRow();


			if (!dto.IdtProduto.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.IdtProduto] = (Decimal)dto.IdtProduto.Value;
		    if (!dto.IdtLocal.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.IdtLocal] = (Decimal)dto.IdtLocal.Value;
		    if (!dto.IdtUnidade.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;
		    if (!dto.IdtSetor.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.IdtSetor] = (Decimal)dto.IdtSetor.Value;
		    if (!dto.Mes.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.Mes] = (Decimal)dto.Mes.Value;
		    if (!dto.Ano.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.Ano] = (Decimal)dto.Ano.Value;
		    if (!dto.QtdeEntrada.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.QtdeEntrada] = (Decimal)dto.QtdeEntrada.Value;
            if (!dto.QtdeSaida.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.QtdeSaida] = (Decimal)dto.QtdeSaida.Value;

            if (!dto.VlrEntrada.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.VlrEntrada] = (Decimal)dto.VlrEntrada.Value;
            if (!dto.VlrSaida.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.VlrSaida] = (Decimal)dto.VlrSaida.Value;
                
		    if (!dto.TipoMovimento.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.TipoMovimento] = (Decimal)dto.TipoMovimento.Value;
		    if (!dto.CustoMedio.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.CustoMedio] = (Decimal)dto.CustoMedio.Value;
		    if (!dto.SaldoAtual.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.SaldoAtual] = (Decimal)dto.SaldoAtual.Value;
		    if (!dto.SaldoAnterior.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.SaldoAnterior] = (Decimal)dto.SaldoAnterior.Value;
		    if (!dto.IdtUsuario.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;
		    if (!dto.DataAtualizacao.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.DataAtualizacao] = (DateTime)dto.DataAtualizacao.Value;
		    if (!dto.IdtFilial.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.IdtFilial] = (Decimal)dto.IdtFilial.Value;
		    if (!dto.IdtGrupo.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.IdtGrupo] = (Decimal)dto.IdtGrupo.Value;
		    if (!dto.IdtSubGrupo.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.IdtSubGrupo] = (Decimal)dto.IdtSubGrupo.Value;
		    if (!dto.CustoMedioAnterior.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.CustoMedioAnterior] = (Decimal)dto.CustoMedioAnterior.Value;
		    if (!dto.VlrTotalMes.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.VlrTotalMes] = (Decimal)dto.VlrTotalMes.Value;
		    if (!dto.SubTipoMovimento.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.SubTipoMovimento] = (Decimal)dto.SubTipoMovimento.Value;
		    if (!dto.VlrTotalAnterior.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.VlrTotalAnterior] = (Decimal)dto.VlrTotalAnterior.Value;

            if (!dto.IndiceRotatividade.Value.IsNull) dtr[MovimentacaoMensalDTO.FieldNames.IndiceRotatividade] = (Decimal)dto.IndiceRotatividade.Value;


        
			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class MovimentacaoMensalDTO : MVC.DTO.DTOBase
    {	
			private MVC.DTO.FieldDecimal cad_mtmd_id;
		private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
		private MVC.DTO.FieldDecimal cad_uni_id_unidade;
		private MVC.DTO.FieldDecimal cad_set_id;
		private MVC.DTO.FieldDecimal mtmd_mov_mes;
		private MVC.DTO.FieldDecimal mtmd_mov_ano;
		private MVC.DTO.FieldDecimal mtmd_qtde_entrada;
        private MVC.DTO.FieldDecimal mtmd_qtde_saida; 


        private MVC.DTO.FieldDecimal mtmd_valor_entrada;
        private MVC.DTO.FieldDecimal mtmd_valor_saida;

		private MVC.DTO.FieldDecimal mtmd_mov_tipo;
        private MVC.DTO.FieldDecimal mtmd_custo_medio_atual;
		private MVC.DTO.FieldDecimal mtmd_saldo_atual;  // mtmd_mov_estoque_atual
        private MVC.DTO.FieldDecimal mtmd_saldo_anterior; // mtmd_mov_estoque_anterior;
		private MVC.DTO.FieldDecimal seg_usu_id_usuario;
		private MVC.DTO.FieldDateTime seg_dt_atualizacao;
		private MVC.DTO.FieldDecimal cad_mtmd_filial_id;
		private MVC.DTO.FieldDecimal cad_mtmd_grupo_id;
		private MVC.DTO.FieldDecimal cad_mtmd_subgrupo_id;
		private MVC.DTO.FieldDecimal mtmd_custo_medio_anterior; // ok
		private MVC.DTO.FieldDecimal mtmd_valor_total_mes;
		private MVC.DTO.FieldDecimal cad_mtmd_subtp_id;
		private MVC.DTO.FieldDecimal mtmd_valor_anterior; //mtmd_valor_total_anterior

        private MVC.DTO.FieldDecimal indice_rotatividade;


        public MovimentacaoMensalDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
				this.cad_mtmd_id= new MVC.DTO.FieldDecimal(FieldNames.IdtProduto,Captions.IdtProduto, DbType.Decimal);
		this.cad_lat_id_local_atendimento= new MVC.DTO.FieldDecimal(FieldNames.IdtLocal,Captions.IdtLocal, DbType.Decimal);
		this.cad_uni_id_unidade= new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade,Captions.IdtUnidade, DbType.Decimal);
		this.cad_set_id= new MVC.DTO.FieldDecimal(FieldNames.IdtSetor,Captions.IdtSetor, DbType.Decimal);
		this.mtmd_mov_mes= new MVC.DTO.FieldDecimal(FieldNames.Mes,Captions.Mes, DbType.Decimal);
		this.mtmd_mov_ano= new MVC.DTO.FieldDecimal(FieldNames.Ano,Captions.Ano, DbType.Decimal);
		this.mtmd_qtde_entrada= new MVC.DTO.FieldDecimal(FieldNames.QtdeEntrada,Captions.QtdeEntrada, DbType.Decimal);
        this.mtmd_qtde_saida = new MVC.DTO.FieldDecimal(FieldNames.QtdeSaida, Captions.QtdeSaida, DbType.Decimal);

        this.mtmd_valor_entrada = new MVC.DTO.FieldDecimal(FieldNames.VlrEntrada, Captions.VlrEntrada, DbType.Decimal);
        this.mtmd_valor_saida = new MVC.DTO.FieldDecimal(FieldNames.VlrSaida, Captions.VlrSaida, DbType.Decimal);

		this.mtmd_mov_tipo= new MVC.DTO.FieldDecimal(FieldNames.TipoMovimento,Captions.TipoMovimento, DbType.Decimal);
        this.mtmd_custo_medio_atual = new MVC.DTO.FieldDecimal(FieldNames.CustoMedio, Captions.CustoMedio, DbType.Decimal);
		this.mtmd_saldo_atual= new MVC.DTO.FieldDecimal(FieldNames.SaldoAtual,Captions.SaldoAtual, DbType.Decimal);
		this.mtmd_saldo_anterior= new MVC.DTO.FieldDecimal(FieldNames.SaldoAnterior,Captions.SaldoAnterior, DbType.Decimal);
		this.seg_usu_id_usuario= new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario,Captions.IdtUsuario, DbType.Decimal);
		this.seg_dt_atualizacao= new MVC.DTO.FieldDateTime(FieldNames.DataAtualizacao,Captions.DataAtualizacao);
		this.cad_mtmd_filial_id= new MVC.DTO.FieldDecimal(FieldNames.IdtFilial,Captions.IdtFilial, DbType.Decimal);
		this.cad_mtmd_grupo_id= new MVC.DTO.FieldDecimal(FieldNames.IdtGrupo,Captions.IdtGrupo, DbType.Decimal);
		this.cad_mtmd_subgrupo_id= new MVC.DTO.FieldDecimal(FieldNames.IdtSubGrupo,Captions.IdtSubGrupo, DbType.Decimal);
		this.mtmd_custo_medio_anterior= new MVC.DTO.FieldDecimal(FieldNames.CustoMedioAnterior,Captions.CustoMedioAnterior, DbType.Decimal);
		this.mtmd_valor_total_mes= new MVC.DTO.FieldDecimal(FieldNames.VlrTotalMes,Captions.VlrTotalMes, DbType.Decimal);
		this.cad_mtmd_subtp_id= new MVC.DTO.FieldDecimal(FieldNames.SubTipoMovimento,Captions.SubTipoMovimento, DbType.Decimal);
		this.mtmd_valor_anterior= new MVC.DTO.FieldDecimal(FieldNames.VlrTotalAnterior,Captions.VlrTotalAnterior, DbType.Decimal);

        this.indice_rotatividade = new MVC.DTO.FieldDecimal(FieldNames.IndiceRotatividade, Captions.IndiceRotatividade, DbType.Decimal);
            
        
        }
 
        #region FieldNames

        public struct FieldNames
        {
				public const string IdtProduto="CAD_MTMD_ID";
		public const string IdtLocal="CAD_LAT_ID_LOCAL_ATENDIMENTO";
		public const string IdtUnidade="CAD_UNI_ID_UNIDADE";
		public const string IdtSetor="CAD_SET_ID";
		public const string Mes="MTMD_MOV_MES";
		public const string Ano="MTMD_MOV_ANO";
		public const string QtdeEntrada="MTMD_QTDE_ENTRADA";
            public const string QtdeSaida = "MTMD_QTDE_SAIDA";


            public const string VlrEntrada = "MTMD_VALOR_ENTRADA";
            public const string VlrSaida = "MTMD_VALOR_SAIDA";
        
		public const string TipoMovimento="MTMD_MOV_TIPO";
		public const string CustoMedio="MTMD_CUSTO_MEDIO";
		public const string SaldoAtual="MTMD_SALDO_ATUAL";
		public const string SaldoAnterior="MTMD_SALDO_ANTERIOR";
		public const string IdtUsuario="SEG_USU_ID_USUARIO";
		public const string DataAtualizacao="SEG_DT_ATUALIZACAO";
		public const string IdtFilial="CAD_MTMD_FILIAL_ID";
		public const string IdtGrupo="CAD_MTMD_GRUPO_ID";
		public const string IdtSubGrupo="CAD_MTMD_SUBGRUPO_ID";
		public const string CustoMedioAnterior="MTMD_CUSTO_MEDIO_ANTERIOR";
		public const string VlrTotalMes="MTMD_VALOR_TOTAL_MES";
		public const string SubTipoMovimento="CAD_MTMD_SUBTP_ID";
            public const string VlrTotalAnterior = "MTMD_VALOR_ANTERIOR";
            public const string IndiceRotatividade = "INDICE_ROTATIVIDADE";

            
		
        }		

        #endregion

        #region Captions
        public struct Captions
        {
				public const string IdtProduto="IDTPRODUTO";
		public const string IdtLocal="IDTLOCAL";
		public const string IdtUnidade="IDTUNIDADE";
		public const string IdtSetor="IDTSETOR";
		public const string Mes="MES";
		public const string Ano="ANO";
		public const string QtdeEntrada="QTDEENTRADA";
            public const string QtdeSaida = "QTDESAIDA";


            public const string VlrEntrada = "VLRENTRADA";
            public const string VlrSaida = "VLRSAIDA";
        
		public const string TipoMovimento="TIPOMOVIMENTO";
		public const string CustoMedio="CUSTOMEDIO";
		public const string SaldoAtual="SALDOATUAL";
		public const string SaldoAnterior="SALDOANTERIOR";
		public const string IdtUsuario="IDTUSUARIO";
		public const string DataAtualizacao="DATAATUALIZACAO";
		public const string IdtFilial="IDTFILIAL";
		public const string IdtGrupo="IDTGRUPO";
		public const string IdtSubGrupo="IDTSUBGRUPO";
		public const string CustoMedioAnterior="CUSTOMEDIOANTERIOR";
		public const string VlrTotalMes="VLRTOTALMES";
		public const string SubTipoMovimento="SUBTIPOMOVIMENTO";
		public const string VlrTotalAnterior="VLRTOTALANTERIOR";

            public const string IndiceRotatividade = "INDICEROTATIVIDADE";


        
		
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal IdtProduto
		{
			get { return cad_mtmd_id; }
			set { cad_mtmd_id = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtLocal
		{
			get { return cad_lat_id_local_atendimento; }
			set { cad_lat_id_local_atendimento = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtUnidade
		{
			get { return cad_uni_id_unidade; }
			set { cad_uni_id_unidade = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtSetor
		{
			get { return cad_set_id; }
			set { cad_set_id = value; }
		}
		
		public MVC.DTO.FieldDecimal Mes
		{
			get { return mtmd_mov_mes; }
			set { mtmd_mov_mes = value; }
		}
		
		public MVC.DTO.FieldDecimal Ano
		{
			get { return mtmd_mov_ano; }
			set { mtmd_mov_ano = value; }
		}
		
		public MVC.DTO.FieldDecimal QtdeEntrada
		{
			get { return mtmd_qtde_entrada; } 
            set { mtmd_qtde_entrada = value; }
		}


        public MVC.DTO.FieldDecimal QtdeSaida
        {
            get { return mtmd_qtde_saida; }
            set { mtmd_qtde_saida = value; }
        }


        public MVC.DTO.FieldDecimal VlrEntrada
        {
            get { return mtmd_valor_entrada; }
            set { mtmd_valor_entrada = value; }
        }


        public MVC.DTO.FieldDecimal VlrSaida
        {
            get { return mtmd_valor_saida; }
            set { mtmd_valor_saida = value; }
        }

      
		public MVC.DTO.FieldDecimal TipoMovimento
		{
			get { return mtmd_mov_tipo; }
			set { mtmd_mov_tipo = value; }
		}
		
		public MVC.DTO.FieldDecimal CustoMedio
		{
            get { return mtmd_custo_medio_atual; }
            set { mtmd_custo_medio_atual = value; }
		}
		
		public MVC.DTO.FieldDecimal SaldoAtual
		{
			get { return mtmd_saldo_atual; }
			set { mtmd_saldo_atual = value; }
		}
		
		public MVC.DTO.FieldDecimal SaldoAnterior
		{
			get { return mtmd_saldo_anterior; }
			set { mtmd_saldo_anterior = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtUsuario
		{
			get { return seg_usu_id_usuario; }
			set { seg_usu_id_usuario = value; }
		}
		
		public MVC.DTO.FieldDateTime DataAtualizacao
		{
			get { return seg_dt_atualizacao; }
			set { seg_dt_atualizacao = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtFilial
		{
			get { return cad_mtmd_filial_id; }
			set { cad_mtmd_filial_id = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtGrupo
		{
			get { return cad_mtmd_grupo_id; }
			set { cad_mtmd_grupo_id = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtSubGrupo
		{
			get { return cad_mtmd_subgrupo_id; }
			set { cad_mtmd_subgrupo_id = value; }
		}
		
		public MVC.DTO.FieldDecimal CustoMedioAnterior
		{
			get { return mtmd_custo_medio_anterior; }
			set { mtmd_custo_medio_anterior = value; }
		}
		
		public MVC.DTO.FieldDecimal VlrTotalMes
		{
			get { return mtmd_valor_total_mes; }
			set { mtmd_valor_total_mes = value; }
		}
		
		public MVC.DTO.FieldDecimal SubTipoMovimento
		{
			get { return cad_mtmd_subtp_id; }
			set { cad_mtmd_subtp_id = value; }
		}
		
		public MVC.DTO.FieldDecimal VlrTotalAnterior
		{
			get { return mtmd_valor_anterior; }
			set { mtmd_valor_anterior = value; }
		}


        public MVC.DTO.FieldDecimal IndiceRotatividade
        {
            get { return indice_rotatividade; }
            set { indice_rotatividade = value; }
        }


        
			
		#endregion


        #region Operators

        public static explicit operator MovimentacaoMensalDTO(DataRow row)
        {
            MovimentacaoMensalDTO  dto = new MovimentacaoMensalDTO();
			
				dto.IdtProduto.Value = row[FieldNames.IdtProduto].ToString();
			
				dto.IdtLocal.Value = row[FieldNames.IdtLocal].ToString();
			
				dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();
			
				dto.IdtSetor.Value = row[FieldNames.IdtSetor].ToString();
			
				dto.Mes.Value = row[FieldNames.Mes].ToString();
			
				dto.Ano.Value = row[FieldNames.Ano].ToString();
			
				dto.QtdeEntrada.Value = row[FieldNames.QtdeEntrada].ToString();

                dto.QtdeSaida.Value = row[FieldNames.QtdeSaida].ToString();

                dto.VlrEntrada.Value = row[FieldNames.VlrEntrada].ToString();

                dto.VlrSaida.Value = row[FieldNames.VlrSaida].ToString();

				dto.TipoMovimento.Value = row[FieldNames.TipoMovimento].ToString();
			
				dto.CustoMedio.Value = row[FieldNames.CustoMedio].ToString();
			
				dto.SaldoAtual.Value = row[FieldNames.SaldoAtual].ToString();
			
				dto.SaldoAnterior.Value = row[FieldNames.SaldoAnterior].ToString();
			
				dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();
			
				dto.DataAtualizacao.Value = row[FieldNames.DataAtualizacao].ToString();
			
				dto.IdtFilial.Value = row[FieldNames.IdtFilial].ToString();
			
				dto.IdtGrupo.Value = row[FieldNames.IdtGrupo].ToString();
			
				dto.IdtSubGrupo.Value = row[FieldNames.IdtSubGrupo].ToString();
			
				dto.CustoMedioAnterior.Value = row[FieldNames.CustoMedioAnterior].ToString();
			
				dto.VlrTotalMes.Value = row[FieldNames.VlrTotalMes].ToString();
			
				dto.SubTipoMovimento.Value = row[FieldNames.SubTipoMovimento].ToString();
			
				dto.VlrTotalAnterior.Value = row[FieldNames.VlrTotalAnterior].ToString();

                dto.IndiceRotatividade.Value = row[FieldNames.IndiceRotatividade].ToString();
                            
			
            return dto;
        }

        public static explicit operator MovimentacaoMensalDTO(XmlDocument xml)
        {
            MovimentacaoMensalDTO dto = new MovimentacaoMensalDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto) != null) dto.IdtProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal) != null) dto.IdtLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor) != null) dto.IdtSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Mes) != null) dto.Mes.Value = xml.FirstChild.SelectSingleNode(FieldNames.Mes).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Ano) != null) dto.Ano.Value = xml.FirstChild.SelectSingleNode(FieldNames.Ano).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeEntrada) != null) dto.QtdeEntrada.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeEntrada).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeSaida) != null) dto.QtdeSaida.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeSaida).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.VlrEntrada) != null) dto.VlrEntrada.Value = xml.FirstChild.SelectSingleNode(FieldNames.VlrEntrada).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.VlrSaida) != null) dto.VlrSaida.Value = xml.FirstChild.SelectSingleNode(FieldNames.VlrSaida).InnerText;


				if (xml.FirstChild.SelectSingleNode(FieldNames.TipoMovimento) != null) dto.TipoMovimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.TipoMovimento).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.CustoMedio) != null) dto.CustoMedio.Value = xml.FirstChild.SelectSingleNode(FieldNames.CustoMedio).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.SaldoAtual) != null) dto.SaldoAtual.Value = xml.FirstChild.SelectSingleNode(FieldNames.SaldoAtual).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.SaldoAnterior) != null) dto.SaldoAnterior.Value = xml.FirstChild.SelectSingleNode(FieldNames.SaldoAnterior).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizacao) != null) dto.DataAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizacao).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial) != null) dto.IdtFilial.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtGrupo) != null) dto.IdtGrupo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtGrupo).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSubGrupo) != null) dto.IdtSubGrupo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSubGrupo).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.CustoMedioAnterior) != null) dto.CustoMedioAnterior.Value = xml.FirstChild.SelectSingleNode(FieldNames.CustoMedioAnterior).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.VlrTotalMes) != null) dto.VlrTotalMes.Value = xml.FirstChild.SelectSingleNode(FieldNames.VlrTotalMes).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.SubTipoMovimento) != null) dto.SubTipoMovimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.SubTipoMovimento).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.VlrTotalAnterior) != null) dto.VlrTotalAnterior.Value = xml.FirstChild.SelectSingleNode(FieldNames.VlrTotalAnterior).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.IndiceRotatividade) != null) dto.IndiceRotatividade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IndiceRotatividade).InnerText;
            
                
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdtProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtProduto, null);
			
            XmlNode nodeIdtLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocal, null);
			
            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);
			
            XmlNode nodeIdtSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSetor, null);
			
            XmlNode nodeMes = xml.CreateNode(XmlNodeType.Element, FieldNames.Mes, null);
			
            XmlNode nodeAno = xml.CreateNode(XmlNodeType.Element, FieldNames.Ano, null);
			
            XmlNode nodeQtdeEntrada = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeEntrada, null);

            XmlNode nodeQtdeSaida = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeSaida, null);


            XmlNode nodeVlrEntrada = xml.CreateNode(XmlNodeType.Element, FieldNames.VlrEntrada, null);

            XmlNode nodeVlrSaida = xml.CreateNode(XmlNodeType.Element, FieldNames.VlrSaida, null);


			
            XmlNode nodeTipoMovimento = xml.CreateNode(XmlNodeType.Element, FieldNames.TipoMovimento, null);
			
            XmlNode nodeCustoMedio = xml.CreateNode(XmlNodeType.Element, FieldNames.CustoMedio, null);
			
            XmlNode nodeSaldoAtual = xml.CreateNode(XmlNodeType.Element, FieldNames.SaldoAtual, null);
			
            XmlNode nodeSaldoAnterior = xml.CreateNode(XmlNodeType.Element, FieldNames.SaldoAnterior, null);
			
            XmlNode nodeIdtUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);
			
            XmlNode nodeDataAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DataAtualizacao, null);
			
            XmlNode nodeIdtFilial = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtFilial, null);
			
            XmlNode nodeIdtGrupo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtGrupo, null);
			
            XmlNode nodeIdtSubGrupo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSubGrupo, null);
			
            XmlNode nodeCustoMedioAnterior = xml.CreateNode(XmlNodeType.Element, FieldNames.CustoMedioAnterior, null);
			
            XmlNode nodeVlrTotalMes = xml.CreateNode(XmlNodeType.Element, FieldNames.VlrTotalMes, null);
			
            XmlNode nodeSubTipoMovimento = xml.CreateNode(XmlNodeType.Element, FieldNames.SubTipoMovimento, null);
			
            XmlNode nodeVlrTotalAnterior = xml.CreateNode(XmlNodeType.Element, FieldNames.VlrTotalAnterior, null);

            XmlNode nodeIndiceRotatividade = xml.CreateNode(XmlNodeType.Element, FieldNames.IndiceRotatividade, null);
                        

			if (!this.IdtProduto.Value.IsNull) nodeIdtProduto.InnerText = this.IdtProduto.Value;
			
			if (!this.IdtLocal.Value.IsNull) nodeIdtLocal.InnerText = this.IdtLocal.Value;
			
			if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;
			
			if (!this.IdtSetor.Value.IsNull) nodeIdtSetor.InnerText = this.IdtSetor.Value;
			
			if (!this.Mes.Value.IsNull) nodeMes.InnerText = this.Mes.Value;
			
			if (!this.Ano.Value.IsNull) nodeAno.InnerText = this.Ano.Value;
			
			if (!this.QtdeEntrada.Value.IsNull) nodeQtdeEntrada.InnerText = this.QtdeEntrada.Value;

            if (!this.QtdeSaida.Value.IsNull) nodeQtdeSaida.InnerText = this.QtdeSaida.Value;

            if (!this.VlrEntrada.Value.IsNull) nodeVlrEntrada.InnerText = this.VlrEntrada.Value;

            if (!this.VlrSaida.Value.IsNull) nodeVlrSaida.InnerText = this.VlrSaida.Value;

		
			if (!this.TipoMovimento.Value.IsNull) nodeTipoMovimento.InnerText = this.TipoMovimento.Value;
			
			if (!this.CustoMedio.Value.IsNull) nodeCustoMedio.InnerText = this.CustoMedio.Value;
			
			if (!this.SaldoAtual.Value.IsNull) nodeSaldoAtual.InnerText = this.SaldoAtual.Value;
			
			if (!this.SaldoAnterior.Value.IsNull) nodeSaldoAnterior.InnerText = this.SaldoAnterior.Value;
			
			if (!this.IdtUsuario.Value.IsNull) nodeIdtUsuario.InnerText = this.IdtUsuario.Value;
			
			if (!this.DataAtualizacao.Value.IsNull) nodeDataAtualizacao.InnerText = this.DataAtualizacao.Value;
			
			if (!this.IdtFilial.Value.IsNull) nodeIdtFilial.InnerText = this.IdtFilial.Value;
			
			if (!this.IdtGrupo.Value.IsNull) nodeIdtGrupo.InnerText = this.IdtGrupo.Value;
			
			if (!this.IdtSubGrupo.Value.IsNull) nodeIdtSubGrupo.InnerText = this.IdtSubGrupo.Value;
			
			if (!this.CustoMedioAnterior.Value.IsNull) nodeCustoMedioAnterior.InnerText = this.CustoMedioAnterior.Value;
			
			if (!this.VlrTotalMes.Value.IsNull) nodeVlrTotalMes.InnerText = this.VlrTotalMes.Value;
			
			if (!this.SubTipoMovimento.Value.IsNull) nodeSubTipoMovimento.InnerText = this.SubTipoMovimento.Value;
			
			if (!this.VlrTotalAnterior.Value.IsNull) nodeVlrTotalAnterior.InnerText = this.VlrTotalAnterior.Value;

            if (!this.IndiceRotatividade.Value.IsNull) nodeIndiceRotatividade.InnerText = this.IndiceRotatividade.Value;
                        

            nodeData.AppendChild(nodeIdtProduto);
			
            nodeData.AppendChild(nodeIdtLocal);
			
            nodeData.AppendChild(nodeIdtUnidade);
			
            nodeData.AppendChild(nodeIdtSetor);
			
            nodeData.AppendChild(nodeMes);
			
            nodeData.AppendChild(nodeAno);
			
            nodeData.AppendChild(nodeQtdeEntrada);

            nodeData.AppendChild(nodeQtdeSaida);

            nodeData.AppendChild(nodeVlrEntrada);

            nodeData.AppendChild(nodeVlrSaida);

            nodeData.AppendChild(nodeTipoMovimento);
			
            nodeData.AppendChild(nodeCustoMedio);
			
            nodeData.AppendChild(nodeSaldoAtual);
			
            nodeData.AppendChild(nodeSaldoAnterior);
			
            nodeData.AppendChild(nodeIdtUsuario);
			
            nodeData.AppendChild(nodeDataAtualizacao);
			
            nodeData.AppendChild(nodeIdtFilial);
			
            nodeData.AppendChild(nodeIdtGrupo);
			
            nodeData.AppendChild(nodeIdtSubGrupo);
			
            nodeData.AppendChild(nodeCustoMedioAnterior);
			
            nodeData.AppendChild(nodeVlrTotalMes);
			
            nodeData.AppendChild(nodeSubTipoMovimento);
			
            nodeData.AppendChild(nodeVlrTotalAnterior);

            nodeData.AppendChild(nodeIndiceRotatividade);
            
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(MovimentacaoMensalDTO dto)
        {
            MovimentacaoMensalDataTable dtb = new MovimentacaoMensalDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.IdtProduto] = dto.IdtProduto.Value;
			
            dtr[FieldNames.IdtLocal] = dto.IdtLocal.Value;
			
            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;
			
            dtr[FieldNames.IdtSetor] = dto.IdtSetor.Value;
			
            dtr[FieldNames.Mes] = dto.Mes.Value;
			
            dtr[FieldNames.Ano] = dto.Ano.Value;
			
            dtr[FieldNames.QtdeEntrada] = dto.QtdeEntrada.Value;

            dtr[FieldNames.QtdeSaida] = dto.QtdeSaida.Value;

            dtr[FieldNames.VlrEntrada] = dto.VlrEntrada.Value;

            dtr[FieldNames.VlrSaida] = dto.VlrSaida.Value;
			
            dtr[FieldNames.TipoMovimento] = dto.TipoMovimento.Value;
			
            dtr[FieldNames.CustoMedio] = dto.CustoMedio.Value;
			
            dtr[FieldNames.SaldoAtual] = dto.SaldoAtual.Value;
			
            dtr[FieldNames.SaldoAnterior] = dto.SaldoAnterior.Value;
			
            dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;
			
            dtr[FieldNames.DataAtualizacao] = dto.DataAtualizacao.Value;
			
            dtr[FieldNames.IdtFilial] = dto.IdtFilial.Value;
			
            dtr[FieldNames.IdtGrupo] = dto.IdtGrupo.Value;
			
            dtr[FieldNames.IdtSubGrupo] = dto.IdtSubGrupo.Value;
			
            dtr[FieldNames.CustoMedioAnterior] = dto.CustoMedioAnterior.Value;
			
            dtr[FieldNames.VlrTotalMes] = dto.VlrTotalMes.Value;
			
            dtr[FieldNames.SubTipoMovimento] = dto.SubTipoMovimento.Value;
			
            dtr[FieldNames.VlrTotalAnterior] = dto.VlrTotalAnterior.Value;

            dtr[FieldNames.IndiceRotatividade] = dto.IndiceRotatividade.Value;


            // IndiceRotatividade indice_rotatividade INDICE_ROTATIVIDADE nodeIndiceRotatividade
            return dtr;
        }

        public static explicit operator XmlDocument(MovimentacaoMensalDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


