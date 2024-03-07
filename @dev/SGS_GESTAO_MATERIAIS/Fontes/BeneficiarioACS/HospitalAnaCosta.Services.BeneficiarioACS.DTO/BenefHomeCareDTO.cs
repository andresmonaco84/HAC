using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using MVC = HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.Services.BeneficiarioACS.DTO
{
    /// <summary>
    /// Classe Entidade BenefHomeCareDataTable
    /// </summary>
    [Serializable()]
    public class BenefHomeCareDataTable : DataTable
    {

        public BenefHomeCareDataTable()
            : base()
        {
            this.TableName = "DADOS";

            this.Columns.Add(BenefHomeCareDTO.FieldNames.CodigoHomeCare, typeof(decimal));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.CodigoPlano, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.CodigoLoja, typeof(decimal));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.CodigoMatriculaBenef, typeof(decimal));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.CodigoSeqMatriculaBenef, typeof(decimal));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.CodigoNumericoPlano, typeof(decimal));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.IdtPlanoSGS, typeof(decimal));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.FlAtivo, typeof(decimal));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.Endereco, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.Bairro, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.UF, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.NumeroEndereco, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.CEP, typeof(decimal));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.DDD, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.Telefone, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.DDD2, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.Telefone2, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.DDD3, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.Telefone3, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.Complemento, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.TipoLogradouro, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.Observacao, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.Email, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.CodigoIBGEMunicipio, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.NomeBeneficiario, typeof(string));
            this.Columns.Add(BenefHomeCareDTO.FieldNames.DescricaoConvenio, typeof(string));

            this.Columns.Add(BenefHomeCareDTO.FieldNames.Cidade, typeof(string));

            //DataColumn[] primaryKey = { this.Columns[BenefHomeCareDTO.FieldNames.CodigoHomeCare] };
            //this.PrimaryKey = primaryKey;

            
        }

        protected BenefHomeCareDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) { }


        public BenefHomeCareDTO TypedRow(int index)
        {
            return (BenefHomeCareDTO)this.Rows[index];
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

        public void Add(BenefHomeCareDTO dto)
        {
            DataRow dtr = this.NewRow();


            if (!dto.CodigoHomeCare.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.CodigoHomeCare] = (decimal)dto.CodigoHomeCare.Value;
            if (!dto.CodigoPlano.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.CodigoPlano] = (string)dto.CodigoPlano.Value;
            if (!dto.CodigoLoja.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.CodigoLoja] = (decimal)dto.CodigoLoja.Value;
            if (!dto.CodigoMatriculaBenef.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.CodigoMatriculaBenef] = (decimal)dto.CodigoMatriculaBenef.Value;
            if (!dto.CodigoSeqMatriculaBenef.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.CodigoSeqMatriculaBenef] = (decimal)dto.CodigoSeqMatriculaBenef.Value;
            if (!dto.CodigoNumericoPlano.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.CodigoNumericoPlano] = (decimal)dto.CodigoNumericoPlano.Value;
            if (!dto.IdtPlanoSGS.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.IdtPlanoSGS] = (decimal)dto.IdtPlanoSGS.Value;
            if (!dto.FlAtivo.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.FlAtivo] = (decimal)dto.FlAtivo.Value;
            if (!dto.Endereco.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.Endereco] = (string)dto.Endereco.Value;
            if (!dto.Bairro.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.Bairro] = (string)dto.Bairro.Value;
            if (!dto.UF.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.UF] = (string)dto.UF.Value;
            if (!dto.NumeroEndereco.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.NumeroEndereco] = (string)dto.NumeroEndereco.Value;
            if (!dto.CEP.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.CEP] = (decimal)dto.CEP.Value;
            if (!dto.DDD.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.DDD] = (string)dto.DDD.Value;
            if (!dto.Telefone.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.Telefone] = (string)dto.Telefone.Value;
            if (!dto.DDD2.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.DDD2] = (string)dto.DDD2.Value;
            if (!dto.Telefone2.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.Telefone2] = (string)dto.Telefone2.Value;
            if (!dto.DDD3.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.DDD3] = (string)dto.DDD3.Value;
            if (!dto.Telefone3.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.Telefone3] = (string)dto.Telefone3.Value;
            if (!dto.ComplementoEndereco.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.Complemento] = (string)dto.ComplementoEndereco.Value;
            if (!dto.TipoLogradouro.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.TipoLogradouro] = (string)dto.TipoLogradouro.Value;
            if (!dto.Observacao.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.Observacao] = (string)dto.Observacao.Value;
            if (!dto.Email.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.Email] = (string)dto.Email.Value;
            if (!dto.CodigoIBGEMunicipio.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.CodigoIBGEMunicipio] = (string)dto.CodigoIBGEMunicipio.Value;
            if (!dto.NomeBeneficiario.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.NomeBeneficiario] = (string)dto.NomeBeneficiario.Value;

            if (!dto.DescricaoConvenio.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.DescricaoConvenio] = (string)dto.DescricaoConvenio.Value;

            if (!dto.Cidade.Value.IsNull) dtr[BenefHomeCareDTO.FieldNames.Cidade] = (string)dto.Cidade.Value;

            

            this.Rows.Add(dtr);
        }
    }

    [Serializable()]
    public class BenefHomeCareDTO : MVC.DTO.DTOBase
    {
        private MVC.DTO.FieldDecimal bnf_homecare_id;
        private MVC.DTO.FieldString bnf_cod_plano;
        private MVC.DTO.FieldDecimal bnf_loja_id;
        private MVC.DTO.FieldDecimal bnf_ben_id;
        private MVC.DTO.FieldDecimal bnf_cod_seq;
        private MVC.DTO.FieldDecimal bnf_cod_num_plano;
        private MVC.DTO.FieldDecimal bnf_pla_id_plano;
        private MVC.DTO.FieldDecimal bnf_fl_ativo;
        private MVC.DTO.FieldString bnf_endereco;
        private MVC.DTO.FieldString bnf_bairro;
        private MVC.DTO.FieldString bnf_uf;
        private MVC.DTO.FieldString bnf_numero;
        private MVC.DTO.FieldDecimal bnf_cep;
        private MVC.DTO.FieldString bnf_ddd;
        private MVC.DTO.FieldString bnf_telefone;
        private MVC.DTO.FieldString bnf_ddd2;
        private MVC.DTO.FieldString bnf_telefone2;
        private MVC.DTO.FieldString bnf_ddd3;
        private MVC.DTO.FieldString bnf_telefone3;
        private MVC.DTO.FieldString bnf_comp;
        private MVC.DTO.FieldString bnf_tipo_logradouro;
        private MVC.DTO.FieldString bnf_obs;
        private MVC.DTO.FieldString bnf_email;
        private MVC.DTO.FieldString bnf_mun_cd_ibge;
        private MVC.DTO.FieldString nomben;
        private MVC.DTO.FieldString cad_pla_nm_nome_plano;
        private MVC.DTO.FieldString aux_mun_nm_municipio;


        

        public BenefHomeCareDTO()
        {
            InitializeComponent();
        }

        public enum Ativo
        {            
            NAO = 0,
            SIM = 1
        }

        internal void InitializeComponent()
        {
            this.bnf_homecare_id = new MVC.DTO.FieldDecimal(FieldNames.CodigoHomeCare, Captions.CodigoHomeCare, DbType.Decimal);
            this.bnf_cod_plano = new MVC.DTO.FieldString(FieldNames.CodigoPlano, Captions.CodigoPlano, 4);
            this.bnf_loja_id = new MVC.DTO.FieldDecimal(FieldNames.CodigoLoja, Captions.CodigoLoja, DbType.Decimal);
            this.bnf_ben_id = new MVC.DTO.FieldDecimal(FieldNames.CodigoMatriculaBenef, Captions.CodigoMatriculaBenef, DbType.Decimal);
            this.bnf_cod_seq = new MVC.DTO.FieldDecimal(FieldNames.CodigoSeqMatriculaBenef, Captions.CodigoSeqMatriculaBenef, DbType.Decimal);
            this.bnf_cod_num_plano = new MVC.DTO.FieldDecimal(FieldNames.CodigoNumericoPlano, Captions.CodigoNumericoPlano, DbType.Decimal);
            this.bnf_pla_id_plano = new MVC.DTO.FieldDecimal(FieldNames.IdtPlanoSGS, Captions.IdtPlanoSGS, DbType.Decimal);
            this.bnf_fl_ativo = new MVC.DTO.FieldDecimal(FieldNames.FlAtivo, Captions.FlAtivo, DbType.Decimal);
            this.bnf_endereco = new MVC.DTO.FieldString(FieldNames.Endereco, Captions.Endereco, 80);
            this.bnf_bairro = new MVC.DTO.FieldString(FieldNames.Bairro, Captions.Bairro, 30);
            this.bnf_uf = new MVC.DTO.FieldString(FieldNames.UF, Captions.UF, 2);
            this.bnf_numero = new MVC.DTO.FieldString(FieldNames.NumeroEndereco, Captions.NumeroEndereco, 7);
            this.bnf_cep = new MVC.DTO.FieldDecimal(FieldNames.CEP, Captions.CEP, DbType.Decimal);
            this.bnf_ddd = new MVC.DTO.FieldString(FieldNames.DDD, Captions.DDD, 4);
            this.bnf_telefone = new MVC.DTO.FieldString(FieldNames.Telefone, Captions.Telefone, 20);
            this.bnf_ddd2 = new MVC.DTO.FieldString(FieldNames.DDD2, Captions.DDD2, 4);
            this.bnf_telefone2 = new MVC.DTO.FieldString(FieldNames.Telefone2, Captions.Telefone2, 20);
            this.bnf_ddd3 = new MVC.DTO.FieldString(FieldNames.DDD3, Captions.DDD3, 4);
            this.bnf_telefone3 = new MVC.DTO.FieldString(FieldNames.Telefone3, Captions.Telefone3, 20);
            this.bnf_comp = new MVC.DTO.FieldString(FieldNames.Complemento, Captions.Complemento, 20);
            this.bnf_tipo_logradouro = new MVC.DTO.FieldString(FieldNames.TipoLogradouro, Captions.TipoLogradouro, 20);
            this.bnf_obs = new MVC.DTO.FieldString(FieldNames.Observacao, Captions.Observacao, 30);
            this.bnf_email = new MVC.DTO.FieldString(FieldNames.Email, Captions.Email, 50);
            this.bnf_mun_cd_ibge = new MVC.DTO.FieldString(FieldNames.CodigoIBGEMunicipio, Captions.CodigoIBGEMunicipio, 7);
            this.nomben = new MVC.DTO.FieldString(FieldNames.NomeBeneficiario, Captions.NomeBeneficiario, 7);
            this.cad_pla_nm_nome_plano = new MVC.DTO.FieldString(FieldNames.DescricaoConvenio, Captions.DescricaoConvenio, 7);
            this.aux_mun_nm_municipio = new MVC.DTO.FieldString(FieldNames.Cidade, Captions.Cidade, 7);
                       

        }

        #region FieldNames

        public struct FieldNames
        {
            public const string CodigoHomeCare = "BNF_HOMECARE_ID";
            public const string CodigoPlano = "BNF_COD_PLANO";
            public const string CodigoLoja = "BNF_LOJA_ID";
            public const string CodigoMatriculaBenef = "BNF_BEN_ID";
            public const string CodigoSeqMatriculaBenef = "BNF_COD_SEQ";
            public const string CodigoNumericoPlano = "BNF_COD_NUM_PLANO";
            public const string IdtPlanoSGS = "BNF_PLA_ID_PLANO";
            public const string FlAtivo = "BNF_FL_ATIVO";
            public const string Endereco = "BNF_ENDERECO";
            public const string Bairro = "BNF_BAIRRO";
            public const string UF = "BNF_UF";
            public const string NumeroEndereco = "BNF_NUMERO";
            public const string CEP = "BNF_CEP";
            public const string DDD = "BNF_DDD";
            public const string Telefone = "BNF_TELEFONE";
            public const string DDD2 = "BNF_DDD2";
            public const string Telefone2 = "BNF_TELEFONE2";
            public const string DDD3 = "BNF_DDD3";
            public const string Telefone3 = "BNF_TELEFONE3";
            public const string Complemento = "BNF_COMP";
            public const string TipoLogradouro = "BNF_TIPO_LOGRADOURO";
            public const string Observacao = "BNF_OBS";
            public const string Email = "BNF_EMAIL";
            public const string CodigoIBGEMunicipio = "BNF_MUN_CD_IBGE";
            public const string NomeBeneficiario = "NOMBEN";
            public const string DescricaoConvenio = "CAD_PLA_NM_NOME_PLANO";
            public const string Cidade = "AUX_MUN_NM_MUNICIPIO";


            
        }

        #endregion

        #region Captions
        public struct Captions
        {
            public const string CodigoHomeCare = "CODIGOHOMECARE";
            public const string CodigoPlano = "CODIGOPLANO";
            public const string CodigoLoja = "CODIGOLOJA";
            public const string CodigoMatriculaBenef = "CODIGOMATRICULABENEF";
            public const string CodigoSeqMatriculaBenef = "CODIGOSEQMATRICULABENEF";
            public const string CodigoNumericoPlano = "CODIGONUMERICOPLANO";
            public const string IdtPlanoSGS = "IDTPLANOSGS";
            public const string FlAtivo = "FLATIVO";
            public const string Endereco = "ENDERECO";
            public const string Bairro = "BAIRRO";
            public const string UF = "UF";
            public const string NumeroEndereco = "NUMEROENDERECO";
            public const string CEP = "CEP";
            public const string DDD = "DDD";
            public const string Telefone = "TELEFONE";
            public const string DDD2 = "DDD2";
            public const string Telefone2 = "TELEFONE2";
            public const string DDD3 = "DDD3";
            public const string Telefone3 = "TELEFONE3";
            public const string Complemento = "COMPLEMENTO";
            public const string TipoLogradouro = "TIPOLOGRADOURO";
            public const string Observacao = "OBSERVACAO";
            public const string Email = "EMAIL";
            public const string CodigoIBGEMunicipio = "CODIGOIBGEMUNICIPIO";
            public const string NomeBeneficiario = "NOMEBENEFICIARIO";
            public const string DescricaoConvenio = "DESCRICAOCONVENIO";
            public const string Cidade = "CIDADE";
                        
        }

        #endregion

        #region Atributos Publicos


        public MVC.DTO.FieldDecimal CodigoHomeCare
        {
            get { return bnf_homecare_id; }
            set { bnf_homecare_id = value; }
        }

        public MVC.DTO.FieldString CodigoPlano
        {
            get { return bnf_cod_plano; }
            set { bnf_cod_plano = value; }
        }

        public MVC.DTO.FieldDecimal CodigoLoja
        {
            get { return bnf_loja_id; }
            set { bnf_loja_id = value; }
        }

        public MVC.DTO.FieldDecimal CodigoMatriculaBenef
        {
            get { return bnf_ben_id; }
            set { bnf_ben_id = value; }
        }

        public MVC.DTO.FieldDecimal CodigoSeqMatriculaBenef
        {
            get { return bnf_cod_seq; }
            set { bnf_cod_seq = value; }
        }

        public MVC.DTO.FieldDecimal CodigoNumericoPlano
        {
            get { return bnf_cod_num_plano; }
            set { bnf_cod_num_plano = value; }
        }

        public MVC.DTO.FieldDecimal IdtPlanoSGS
        {
            get { return bnf_pla_id_plano; }
            set { bnf_pla_id_plano = value; }
        }

        public MVC.DTO.FieldDecimal FlAtivo
        {
            get { return bnf_fl_ativo; }
            set { bnf_fl_ativo = value; }
        }

        public MVC.DTO.FieldString Endereco
        {
            get { return bnf_endereco; }
            set { bnf_endereco = value; }
        }

        public MVC.DTO.FieldString Bairro
        {
            get { return bnf_bairro; }
            set { bnf_bairro = value; }
        }

        public MVC.DTO.FieldString UF
        {
            get { return bnf_uf; }
            set { bnf_uf = value; }
        }

        public MVC.DTO.FieldString NumeroEndereco
        {
            get { return bnf_numero; }
            set { bnf_numero = value; }
        }

        public MVC.DTO.FieldDecimal CEP
        {
            get { return bnf_cep; }
            set { bnf_cep = value; }
        }

        public MVC.DTO.FieldString DDD
        {
            get { return bnf_ddd; }
            set { bnf_ddd = value; }
        }

        public MVC.DTO.FieldString Telefone
        {
            get { return bnf_telefone; }
            set { bnf_telefone = value; }
        }

        public MVC.DTO.FieldString DDD2
        {
            get { return bnf_ddd2; }
            set { bnf_ddd2 = value; }
        }

        public MVC.DTO.FieldString Telefone2
        {
            get { return bnf_telefone2; }
            set { bnf_telefone2 = value; }
        }

        public MVC.DTO.FieldString DDD3
        {
            get { return bnf_ddd3; }
            set { bnf_ddd3 = value; }
        }

        public MVC.DTO.FieldString Telefone3
        {
            get { return bnf_telefone3; }
            set { bnf_telefone3 = value; }
        }

        public MVC.DTO.FieldString ComplementoEndereco
        {
            get { return bnf_comp; }
            set { bnf_comp = value; }
        }

        public MVC.DTO.FieldString TipoLogradouro
        {
            get { return bnf_tipo_logradouro; }
            set { bnf_tipo_logradouro = value; }
        }

        public MVC.DTO.FieldString Observacao
        {
            get { return bnf_obs; }
            set { bnf_obs = value; }
        }

        public MVC.DTO.FieldString Email
        {
            get { return bnf_email; }
            set { bnf_email = value; }
        }

        public MVC.DTO.FieldString CodigoIBGEMunicipio
        {
            get { return bnf_mun_cd_ibge; }
            set { bnf_mun_cd_ibge = value; }
        }

        public MVC.DTO.FieldString NomeBeneficiario
        {
            get { return nomben; }
            set { nomben = value; }
        }

        public MVC.DTO.FieldString DescricaoConvenio
        {
            get { return cad_pla_nm_nome_plano; }
            set { cad_pla_nm_nome_plano = value; }
        }

        public MVC.DTO.FieldString Cidade
        {
            get { return aux_mun_nm_municipio; }
            set { aux_mun_nm_municipio = value; }
        }
        


        #endregion


        #region Operators

        public static explicit operator BenefHomeCareDTO(DataRow row)
        {
            BenefHomeCareDTO dto = new BenefHomeCareDTO();

            dto.CodigoHomeCare.Value = row[FieldNames.CodigoHomeCare].ToString();

            dto.CodigoPlano.Value = row[FieldNames.CodigoPlano].ToString();

            dto.CodigoLoja.Value = row[FieldNames.CodigoLoja].ToString();

            dto.CodigoMatriculaBenef.Value = row[FieldNames.CodigoMatriculaBenef].ToString();

            dto.CodigoSeqMatriculaBenef.Value = row[FieldNames.CodigoSeqMatriculaBenef].ToString();

            dto.CodigoNumericoPlano.Value = row[FieldNames.CodigoNumericoPlano].ToString();

            dto.IdtPlanoSGS.Value = row[FieldNames.IdtPlanoSGS].ToString();

            dto.FlAtivo.Value = row[FieldNames.FlAtivo].ToString();

            dto.Endereco.Value = row[FieldNames.Endereco].ToString();

            dto.Bairro.Value = row[FieldNames.Bairro].ToString();

            dto.UF.Value = row[FieldNames.UF].ToString();

            dto.NumeroEndereco.Value = row[FieldNames.NumeroEndereco].ToString();

            dto.CEP.Value = row[FieldNames.CEP].ToString();

            dto.DDD.Value = row[FieldNames.DDD].ToString();

            dto.Telefone.Value = row[FieldNames.Telefone].ToString();

            dto.DDD2.Value = row[FieldNames.DDD2].ToString();

            dto.Telefone2.Value = row[FieldNames.Telefone2].ToString();

            dto.DDD3.Value = row[FieldNames.DDD3].ToString();

            dto.Telefone3.Value = row[FieldNames.Telefone3].ToString();

            dto.ComplementoEndereco.Value = row[FieldNames.Complemento].ToString();

            dto.TipoLogradouro.Value = row[FieldNames.TipoLogradouro].ToString();

            dto.Observacao.Value = row[FieldNames.Observacao].ToString();

            dto.Email.Value = row[FieldNames.Email].ToString();

            dto.CodigoIBGEMunicipio.Value = row[FieldNames.CodigoIBGEMunicipio].ToString();

            dto.NomeBeneficiario.Value = row[FieldNames.NomeBeneficiario].ToString();

            dto.DescricaoConvenio.Value = row[FieldNames.DescricaoConvenio].ToString();

            dto.Cidade.Value = row[FieldNames.Cidade].ToString();

            

            return dto;
        }

        public static explicit operator BenefHomeCareDTO(XmlDocument xml)
        {
            BenefHomeCareDTO dto = new BenefHomeCareDTO();

            if (xml.FirstChild.SelectSingleNode(FieldNames.CodigoHomeCare) != null) dto.CodigoHomeCare.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodigoHomeCare).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.CodigoPlano) != null) dto.CodigoPlano.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodigoPlano).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.CodigoLoja) != null) dto.CodigoLoja.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodigoLoja).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.CodigoMatriculaBenef) != null) dto.CodigoMatriculaBenef.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodigoMatriculaBenef).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.CodigoSeqMatriculaBenef) != null) dto.CodigoSeqMatriculaBenef.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodigoSeqMatriculaBenef).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.CodigoNumericoPlano) != null) dto.CodigoNumericoPlano.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodigoNumericoPlano).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtPlanoSGS) != null) dto.IdtPlanoSGS.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtPlanoSGS).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.FlAtivo) != null) dto.FlAtivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlAtivo).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Endereco) != null) dto.Endereco.Value = xml.FirstChild.SelectSingleNode(FieldNames.Endereco).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Bairro) != null) dto.Bairro.Value = xml.FirstChild.SelectSingleNode(FieldNames.Bairro).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.UF) != null) dto.UF.Value = xml.FirstChild.SelectSingleNode(FieldNames.UF).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.NumeroEndereco) != null) dto.NumeroEndereco.Value = xml.FirstChild.SelectSingleNode(FieldNames.NumeroEndereco).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.CEP) != null) dto.CEP.Value = xml.FirstChild.SelectSingleNode(FieldNames.CEP).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DDD) != null) dto.DDD.Value = xml.FirstChild.SelectSingleNode(FieldNames.DDD).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Telefone) != null) dto.Telefone.Value = xml.FirstChild.SelectSingleNode(FieldNames.Telefone).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DDD2) != null) dto.DDD2.Value = xml.FirstChild.SelectSingleNode(FieldNames.DDD2).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Telefone2) != null) dto.Telefone2.Value = xml.FirstChild.SelectSingleNode(FieldNames.Telefone2).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DDD3) != null) dto.DDD3.Value = xml.FirstChild.SelectSingleNode(FieldNames.DDD3).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Telefone3) != null) dto.Telefone3.Value = xml.FirstChild.SelectSingleNode(FieldNames.Telefone3).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Complemento) != null) dto.ComplementoEndereco.Value = xml.FirstChild.SelectSingleNode(FieldNames.Complemento).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.TipoLogradouro) != null) dto.TipoLogradouro.Value = xml.FirstChild.SelectSingleNode(FieldNames.TipoLogradouro).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Observacao) != null) dto.Observacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.Observacao).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Email) != null) dto.Email.Value = xml.FirstChild.SelectSingleNode(FieldNames.Email).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.CodigoIBGEMunicipio) != null) dto.CodigoIBGEMunicipio.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodigoIBGEMunicipio).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.NomeBeneficiario) != null) dto.NomeBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.NomeBeneficiario).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DescricaoConvenio) != null) dto.DescricaoConvenio.Value = xml.FirstChild.SelectSingleNode(FieldNames.DescricaoConvenio).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Cidade) != null) dto.Cidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.Cidade).InnerText;
                       

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);

            XmlNode nodeCodigoHomeCare = xml.CreateNode(XmlNodeType.Element, FieldNames.CodigoHomeCare, null);

            XmlNode nodeCodigoPlano = xml.CreateNode(XmlNodeType.Element, FieldNames.CodigoPlano, null);

            XmlNode nodeCodigoLoja = xml.CreateNode(XmlNodeType.Element, FieldNames.CodigoLoja, null);

            XmlNode nodeCodigoMatriculaBenef = xml.CreateNode(XmlNodeType.Element, FieldNames.CodigoMatriculaBenef, null);

            XmlNode nodeCodigoSeqMatriculaBenef = xml.CreateNode(XmlNodeType.Element, FieldNames.CodigoSeqMatriculaBenef, null);

            XmlNode nodeCodigoNumericoPlano = xml.CreateNode(XmlNodeType.Element, FieldNames.CodigoNumericoPlano, null);

            XmlNode nodeIdtPlanoSGS = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtPlanoSGS, null);

            XmlNode nodeFlAtivo = xml.CreateNode(XmlNodeType.Element, FieldNames.FlAtivo, null);

            XmlNode nodeEndereco = xml.CreateNode(XmlNodeType.Element, FieldNames.Endereco, null);

            XmlNode nodeBairro = xml.CreateNode(XmlNodeType.Element, FieldNames.Bairro, null);

            XmlNode nodeUF = xml.CreateNode(XmlNodeType.Element, FieldNames.UF, null);

            XmlNode nodeNumeroEndereco = xml.CreateNode(XmlNodeType.Element, FieldNames.NumeroEndereco, null);

            XmlNode nodeCEP = xml.CreateNode(XmlNodeType.Element, FieldNames.CEP, null);

            XmlNode nodeDDD = xml.CreateNode(XmlNodeType.Element, FieldNames.DDD, null);

            XmlNode nodeTelefone = xml.CreateNode(XmlNodeType.Element, FieldNames.Telefone, null);

            XmlNode nodeDDD2 = xml.CreateNode(XmlNodeType.Element, FieldNames.DDD2, null);

            XmlNode nodeTelefone2 = xml.CreateNode(XmlNodeType.Element, FieldNames.Telefone2, null);

            XmlNode nodeDDD3 = xml.CreateNode(XmlNodeType.Element, FieldNames.DDD3, null);

            XmlNode nodeTelefone3 = xml.CreateNode(XmlNodeType.Element, FieldNames.Telefone3, null);

            XmlNode nodeComplemento = xml.CreateNode(XmlNodeType.Element, FieldNames.Complemento, null);

            XmlNode nodeTipoLogradouro = xml.CreateNode(XmlNodeType.Element, FieldNames.TipoLogradouro, null);

            XmlNode nodeObservacao = xml.CreateNode(XmlNodeType.Element, FieldNames.Observacao, null);

            XmlNode nodeEmail = xml.CreateNode(XmlNodeType.Element, FieldNames.Email, null);

            XmlNode nodeCodigoIBGEMunicipio = xml.CreateNode(XmlNodeType.Element, FieldNames.CodigoIBGEMunicipio, null);

            XmlNode nodeNomeBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.NomeBeneficiario, null);

            XmlNode nodeDescricaoConvenio = xml.CreateNode(XmlNodeType.Element, FieldNames.DescricaoConvenio, null);

            XmlNode nodeCidade = xml.CreateNode(XmlNodeType.Element, FieldNames.Cidade, null);

            
            

            if (!this.CodigoHomeCare.Value.IsNull) nodeCodigoHomeCare.InnerText = this.CodigoHomeCare.Value;

            if (!this.CodigoPlano.Value.IsNull) nodeCodigoPlano.InnerText = this.CodigoPlano.Value;

            if (!this.CodigoLoja.Value.IsNull) nodeCodigoLoja.InnerText = this.CodigoLoja.Value;

            if (!this.CodigoMatriculaBenef.Value.IsNull) nodeCodigoMatriculaBenef.InnerText = this.CodigoMatriculaBenef.Value;

            if (!this.CodigoSeqMatriculaBenef.Value.IsNull) nodeCodigoSeqMatriculaBenef.InnerText = this.CodigoSeqMatriculaBenef.Value;

            if (!this.CodigoNumericoPlano.Value.IsNull) nodeCodigoNumericoPlano.InnerText = this.CodigoNumericoPlano.Value;

            if (!this.IdtPlanoSGS.Value.IsNull) nodeIdtPlanoSGS.InnerText = this.IdtPlanoSGS.Value;

            if (!this.FlAtivo.Value.IsNull) nodeFlAtivo.InnerText = this.FlAtivo.Value;

            if (!this.Endereco.Value.IsNull) nodeEndereco.InnerText = this.Endereco.Value;

            if (!this.Bairro.Value.IsNull) nodeBairro.InnerText = this.Bairro.Value;

            if (!this.UF.Value.IsNull) nodeUF.InnerText = this.UF.Value;

            if (!this.NumeroEndereco.Value.IsNull) nodeNumeroEndereco.InnerText = this.NumeroEndereco.Value;

            if (!this.CEP.Value.IsNull) nodeCEP.InnerText = this.CEP.Value;

            if (!this.DDD.Value.IsNull) nodeDDD.InnerText = this.DDD.Value;

            if (!this.Telefone.Value.IsNull) nodeTelefone.InnerText = this.Telefone.Value;

            if (!this.DDD2.Value.IsNull) nodeDDD2.InnerText = this.DDD2.Value;

            if (!this.Telefone2.Value.IsNull) nodeTelefone2.InnerText = this.Telefone2.Value;

            if (!this.DDD3.Value.IsNull) nodeDDD3.InnerText = this.DDD3.Value;

            if (!this.Telefone3.Value.IsNull) nodeTelefone3.InnerText = this.Telefone3.Value;

            if (!this.ComplementoEndereco.Value.IsNull) nodeComplemento.InnerText = this.ComplementoEndereco.Value;

            if (!this.TipoLogradouro.Value.IsNull) nodeTipoLogradouro.InnerText = this.TipoLogradouro.Value;

            if (!this.Observacao.Value.IsNull) nodeObservacao.InnerText = this.Observacao.Value;

            if (!this.Email.Value.IsNull) nodeEmail.InnerText = this.Email.Value;

            if (!this.CodigoIBGEMunicipio.Value.IsNull) nodeCodigoIBGEMunicipio.InnerText = this.CodigoIBGEMunicipio.Value;

            if (!this.NomeBeneficiario.Value.IsNull) nodeNomeBeneficiario.InnerText = this.NomeBeneficiario.Value;

            if (!this.DescricaoConvenio.Value.IsNull) nodeDescricaoConvenio.InnerText = this.DescricaoConvenio.Value;

            if (!this.Cidade.Value.IsNull) nodeCidade.InnerText = this.Cidade.Value;

                       

            nodeData.AppendChild(nodeCodigoHomeCare);

            nodeData.AppendChild(nodeCodigoPlano);

            nodeData.AppendChild(nodeCodigoLoja);

            nodeData.AppendChild(nodeCodigoMatriculaBenef);

            nodeData.AppendChild(nodeCodigoSeqMatriculaBenef);

            nodeData.AppendChild(nodeCodigoNumericoPlano);

            nodeData.AppendChild(nodeIdtPlanoSGS);

            nodeData.AppendChild(nodeFlAtivo);

            nodeData.AppendChild(nodeEndereco);

            nodeData.AppendChild(nodeBairro);

            nodeData.AppendChild(nodeUF);

            nodeData.AppendChild(nodeNumeroEndereco);

            nodeData.AppendChild(nodeCEP);

            nodeData.AppendChild(nodeDDD);

            nodeData.AppendChild(nodeTelefone);

            nodeData.AppendChild(nodeDDD2);

            nodeData.AppendChild(nodeTelefone2);

            nodeData.AppendChild(nodeDDD3);

            nodeData.AppendChild(nodeTelefone3);

            nodeData.AppendChild(nodeComplemento);

            nodeData.AppendChild(nodeTipoLogradouro);

            nodeData.AppendChild(nodeObservacao);

            nodeData.AppendChild(nodeEmail);

            nodeData.AppendChild(nodeCodigoIBGEMunicipio);

            nodeData.AppendChild(nodeNomeBeneficiario);

            nodeData.AppendChild(nodeDescricaoConvenio);

            nodeData.AppendChild(nodeCidade);
                       

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(BenefHomeCareDTO dto)
        {
            BenefHomeCareDataTable dtb = new BenefHomeCareDataTable();
            DataRow dtr = dtb.NewRow();

            dtr[FieldNames.CodigoHomeCare] = dto.CodigoHomeCare.Value;

            dtr[FieldNames.CodigoPlano] = dto.CodigoPlano.Value;

            dtr[FieldNames.CodigoLoja] = dto.CodigoLoja.Value;

            dtr[FieldNames.CodigoMatriculaBenef] = dto.CodigoMatriculaBenef.Value;

            dtr[FieldNames.CodigoSeqMatriculaBenef] = dto.CodigoSeqMatriculaBenef.Value;

            dtr[FieldNames.CodigoNumericoPlano] = dto.CodigoNumericoPlano.Value;

            dtr[FieldNames.IdtPlanoSGS] = dto.IdtPlanoSGS.Value;

            dtr[FieldNames.FlAtivo] = dto.FlAtivo.Value;

            dtr[FieldNames.Endereco] = dto.Endereco.Value;

            dtr[FieldNames.Bairro] = dto.Bairro.Value;

            dtr[FieldNames.UF] = dto.UF.Value;

            dtr[FieldNames.NumeroEndereco] = dto.NumeroEndereco.Value;

            dtr[FieldNames.CEP] = dto.CEP.Value;

            dtr[FieldNames.DDD] = dto.DDD.Value;

            dtr[FieldNames.Telefone] = dto.Telefone.Value;

            dtr[FieldNames.DDD2] = dto.DDD2.Value;

            dtr[FieldNames.Telefone2] = dto.Telefone2.Value;

            dtr[FieldNames.DDD3] = dto.DDD3.Value;

            dtr[FieldNames.Telefone3] = dto.Telefone3.Value;

            dtr[FieldNames.Complemento] = dto.ComplementoEndereco.Value;

            dtr[FieldNames.TipoLogradouro] = dto.TipoLogradouro.Value;

            dtr[FieldNames.Observacao] = dto.Observacao.Value;

            dtr[FieldNames.Email] = dto.Email.Value;

            dtr[FieldNames.CodigoIBGEMunicipio] = dto.CodigoIBGEMunicipio.Value;

            dtr[FieldNames.NomeBeneficiario] = dto.NomeBeneficiario.Value;

            dtr[FieldNames.DescricaoConvenio] = dto.DescricaoConvenio.Value;

            dtr[FieldNames.Cidade] = dto.Cidade.Value;



            // Cidade aux_mun_nm_municipio AUX_MUN_NM_MUNICIPIO nodeCidade

            return dtr;
        }

        public static explicit operator XmlDocument(BenefHomeCareDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


