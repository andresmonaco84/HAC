using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HospitalAnaCosta.SGS.tools;

namespace HospitalAnaCosta.SGS.Impressao
{
    class ClinicaData : ClassBase
    {
        public ClinicaEntity Consultar(ClinicaEntity Clinica)
        {
            string sqlString = string.Empty;

            #region Clinica
            DataTable dtbClinica = new DataTable();
            sqlString = "SELECT CLC.CAD_CLC_FL_STATUS, CLC.CAD_CLC_DT_INI_VIGENCIA, CLC.CAD_CLC_DT_FIM_VIGENCIA,NULL ORIGEM, CLC.CAD_CLC_CD_CLINICA, CLC.CAD_CLC_DS_RESUMIDA, CLC.CAD_CLC_DS_DESCRICAO, CLC.CAD_CLC_ID \n" +
                        "FROM  TB_CAD_CLC_CLINICA_CREDENCIADA CLC WHERE CLC.CAD_CLC_ID = " + Clinica.IdtClinica;
            dtbClinica = remoto.executeQuery(sqlString);
            sqlString = string.Empty;

            if (dtbClinica.Rows.Count == 0)
                throw new Exception("0"); //Clinica inexistente.

            if (dtbClinica.Rows[0]["CAD_CLC_FL_STATUS"].ToString() != "A")
                throw new Exception("1"); //Clinica inativa.

            //if (Convert.ToDateTime(dtbExisteClinica.Rows[0][2]) < DateTime.Now) // Verificar Vigencia?
            //    throw new Exception("1"); //Clinica inativa.

            dtbClinica.Rows[0]["ORIGEM"] = Clinica.Origem;
            #endregion

            #region Endereco
            sqlString = "SELECT END.CAD_END_NM_LOGRADOURO,\n" +
            "       END.CAD_END_DS_NUMERO,\n" +
            "       END.CAD_END_DS_COMPLEMENTO,\n" +
            "       END.CAD_END_CD_CEP,\n" +
            "       END.CAD_END_NM_BAIRRO,\n" +
            "       END.CAD_END_SG_UF,\n" +
            "       TLG.TIS_TLG_DS_TPLOGRADOURO,\n" +
            "       END.AUX_TTE_CD_TP_TEL_END, TTE.AUX_TTE_NM_TIPO,\n" +
            "       TTE.AUX_TTE_CD_TIPO,\n" +
            "       MUN.AUX_MUN_NM_MUNICIPIO\n" +
            "FROM   TB_CAD_CLC_CLINICA_CREDENCIADA CLC\n" +
            "JOIN   TB_CAD_END_ENDERECO            END ON END.CAD_PES_ID_PESSOA       = CLC.CAD_PES_ID_PESSOA         AND END.AUX_TTE_CD_TP_TEL_END = 2\n" +
            "JOIN   TB_AUX_MUN_MUNICIPIO           MUN ON MUN.AUX_MUN_CD_IBGE         = END.AUX_MUN_CD_IBGE\n" +
            "JOIN   TB_TIS_TLG_TP_LOGRADOURO       TLG ON TLG.TIS_TLG_CD_TPLOGRADOURO = END.TIS_TLG_CD_TPLOGRADOURO\n" +
            "JOIN   TB_AUX_TTE_TP_TEL_ENDERECO     TTE ON TTE.AUX_TTE_CD_TP_TEL_END   = END.AUX_TTE_CD_TP_TEL_END\n" +
            "WHERE  CLC.CAD_CLC_ID = " + Clinica.IdtClinica;

            DataTable dtbEnderecoClinica = remoto.executeQuery(sqlString);
            sqlString = string.Empty;
            if (dtbEnderecoClinica.Rows.Count == 0) {  // Se não achar endereço tipo EMPRESA pega qualquer hum.
                sqlString = "SELECT END.CAD_END_NM_LOGRADOURO,\n" +
                "       END.CAD_END_DS_NUMERO,\n" +
                "       END.CAD_END_DS_COMPLEMENTO,\n" +
                "       END.CAD_END_CD_CEP,\n" +
                "       END.CAD_END_NM_BAIRRO,\n" +
                "       END.CAD_END_SG_UF,\n" +
                "       TLG.TIS_TLG_DS_TPLOGRADOURO,\n" +
                "       END.AUX_TTE_CD_TP_TEL_END, TTE.AUX_TTE_NM_TIPO,\n" +
                "       TTE.AUX_TTE_CD_TIPO,\n" +
                "       MUN.AUX_MUN_NM_MUNICIPIO\n" +
                "FROM   TB_CAD_CLC_CLINICA_CREDENCIADA CLC\n" +
                "JOIN   TB_CAD_END_ENDERECO            END ON END.CAD_PES_ID_PESSOA       = CLC.CAD_PES_ID_PESSOA     \n" +
                "JOIN   TB_AUX_MUN_MUNICIPIO           MUN ON MUN.AUX_MUN_CD_IBGE         = END.AUX_MUN_CD_IBGE\n" +
                "JOIN   TB_TIS_TLG_TP_LOGRADOURO       TLG ON TLG.TIS_TLG_CD_TPLOGRADOURO = END.TIS_TLG_CD_TPLOGRADOURO\n" +
                "JOIN   TB_AUX_TTE_TP_TEL_ENDERECO     TTE ON TTE.AUX_TTE_CD_TP_TEL_END   = END.AUX_TTE_CD_TP_TEL_END\n" +
                "WHERE  CLC.CAD_CLC_ID = " + Clinica.IdtClinica + " AND ROWNUM = 1" ;
                dtbEnderecoClinica = remoto.executeQuery(sqlString);
                sqlString = string.Empty;
            }
            #endregion

            #region Telefone
            sqlString = "SELECT TEL.CAD_TEL_NR_NUM_TEL, TEL.CAD_TEL_NR_RAMAL_TEL, TEL.CAD_TEL_NM_CONTATO, TEL.AUX_TTE_CD_TP_TEL_END\n" +
            "FROM   TB_CAD_CLC_CLINICA_CREDENCIADA CLC\n" +
            "JOIN   TB_CAD_TEL_TELEFONE            TEL ON TEL.CAD_PES_ID_PESSOA       = CLC.CAD_PES_ID_PESSOA          AND TEL.AUX_TTE_CD_TP_TEL_END = 2\n" +
            "WHERE  CLC.CAD_CLC_ID = " + Clinica.IdtClinica;

            DataTable dtbTelefoneClinica = remoto.executeQuery(sqlString);
            sqlString = string.Empty;
            if (dtbTelefoneClinica.Rows.Count == 0){
                sqlString = "SELECT TEL.CAD_TEL_NR_NUM_TEL, TEL.CAD_TEL_NR_RAMAL_TEL, TEL.CAD_TEL_NM_CONTATO, TEL.AUX_TTE_CD_TP_TEL_END\n" +
                    "FROM   TB_CAD_CLC_CLINICA_CREDENCIADA CLC\n" +
                    "JOIN   TB_CAD_TEL_TELEFONE            TEL ON TEL.CAD_PES_ID_PESSOA    = CLC.CAD_PES_ID_PESSOA \n" +
                    "WHERE  CLC.CAD_CLC_ID = " + Clinica.IdtClinica + " AND ROWNUM = 1";
                dtbTelefoneClinica = remoto.executeQuery(sqlString);
                sqlString = string.Empty;
            }
            #endregion

            return MontarEntity(dtbClinica, dtbEnderecoClinica, dtbTelefoneClinica);
        }

        private ClinicaEntity MontarEntity(DataTable dtbClinica, DataTable dtbEnderecoClinica, DataTable dtbTelefoneClinica)
        {
            ClinicaEntity clinicaEntity = new ClinicaEntity();
            clinicaEntity.Origem = dtbClinica.Rows[0]["ORIGEM"].ToString();
            clinicaEntity.IdtClinica = dtbClinica.Rows[0]["CAD_CLC_ID"].ToString();
            clinicaEntity.CodigoClinica = dtbClinica.Rows[0]["CAD_CLC_CD_CLINICA"].ToString();
            clinicaEntity.Descricao = dtbClinica.Rows[0]["CAD_CLC_DS_DESCRICAO"].ToString();
            clinicaEntity.DescricaoResumida = dtbClinica.Rows[0]["CAD_CLC_DS_RESUMIDA"].ToString();

            if (dtbEnderecoClinica.Rows.Count > 0)
                clinicaEntity.Endereco = string.Format("{0} {1} {2}", dtbEnderecoClinica.Rows[0]["CAD_END_NM_LOGRADOURO"].ToString(),
                dtbEnderecoClinica.Rows[0]["CAD_END_DS_NUMERO"].ToString(),
                dtbEnderecoClinica.Rows[0]["CAD_END_DS_COMPLEMENTO"].ToString());

            clinicaEntity.TipoLogradouro = dtbEnderecoClinica.Rows[0]["TIS_TLG_DS_TPLOGRADOURO"].ToString();
            clinicaEntity.Logradouro = dtbEnderecoClinica.Rows[0]["CAD_END_NM_LOGRADOURO"].ToString();
            clinicaEntity.NumeroEndereco = dtbEnderecoClinica.Rows[0]["CAD_END_DS_NUMERO"].ToString(); //dtb.Rows[0]["CAD_END_DS_NUMERO"].ToString();
            clinicaEntity.Complemento = dtbEnderecoClinica.Rows[0]["CAD_END_DS_COMPLEMENTO"].ToString();
            clinicaEntity.Bairro = dtbEnderecoClinica.Rows[0]["CAD_END_NM_BAIRRO"].ToString();
            clinicaEntity.UF = dtbEnderecoClinica.Rows[0]["CAD_END_SG_UF"].ToString();
            clinicaEntity.Cidade = dtbEnderecoClinica.Rows[0]["AUX_MUN_NM_MUNICIPIO"].ToString();

            if (dtbTelefoneClinica.Rows.Count > 0)
                clinicaEntity.Telefone = dtbTelefoneClinica.Rows[0]["CAD_TEL_NR_NUM_TEL"].ToString();
           

            return clinicaEntity;
        }
    }
}
