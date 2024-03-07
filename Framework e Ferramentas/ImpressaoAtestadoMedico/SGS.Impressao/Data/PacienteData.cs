using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HospitalAnaCosta.SGS.tools;

namespace HospitalAnaCosta.SGS.Impressao
{
    class PacienteData : ClassBase
    {
        public PacienteEntity Consultar(PacienteEntity Paciente)
        {
            DataTable dtbResultado = new DataTable();

            string sqlString = string.Format("SELECT PAC.CAD_PAC_CD_CREDENCIAL,\n" +
            "       PAC.CAD_PAC_NR_PRONTUARIO,\n" +
            "       PAC.CAD_PAC_DT_VALIDADECREDENCIAL,\n" +
            "       PES.CAD_PES_ID_PESSOA,\n" +
            "       PES.CAD_PES_NR_RG,\n" +
            "       PES.CAD_PES_NR_CNPJ_CPF,\n" +
            "       PES.CAD_PES_NM_PESSOA,\n" +
            "       TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'dd/MM/yyyy') CAD_PES_DT_NASCIMENTO,\n" +
            "       PES.CAD_PES_TP_SEXO,\n" +
            "       FLOOR(FLOOR(MONTHS_BETWEEN(SYSDATE, PES.CAD_PES_DT_NASCIMENTO)) / 12) IDADE,\n" +
            "       CNV.CAD_CNV_CD_HAC_PRESTADOR,\n" +
            "       CNV.CAD_CNV_NM_FANTASIA,\n" +
            "       CNV.CAD_TPE_CD_CODIGO,\n" +
            "\n" +
            "       PLA.CAD_PLA_CD_PLANO_HAC,\n" +
            "       PLA.CAD_PLA_CD_TIPOPLANO,\n" +
            "       PLA.CAD_PLA_NM_NOME_PLANO,\n" +
            "\n" +
            "       A.CODPADATEBEN,\n" +
            "       NULL STATUS_LIBERACAO,\n" +
            "       NULL ATD_ATE_ID,\n" +
            "       {1} ORIGEM\n" +
            "\n" +
            "FROM   TB_CAD_PAC_PACIENTE       PAC\n" +
            "JOIN   TB_CAD_PES_PESSOA         PES  ON  PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA\n" +
            "JOIN   TB_CAD_CNV_CONVENIO       CNV  ON  CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO\n" +
            "JOIN   TB_CAD_PLA_PLANO          PLA  ON  PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO\n" +
            "LEFT JOIN (SELECT PAC.CAD_PAC_ID_PACIENTE, BNF.CODPADATEBEN\n" +
            "                   FROM TB_CAD_PAC_PACIENTE PAC\n" +
            "                   JOIN TB_CAD_PLA_PLANO    PLA ON PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO\n" +
            "                   JOIN BNF_BENEFICIARIO    BNF ON TO_CHAR(BNF.CODCON)  = TO_CHAR(PLA.CAD_PLA_CD_PLANO_HAC)\n" +
            "                                                AND BNF.CODEST          = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3))\n" +
            "                                                AND BNF.CODBEN          = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7))\n" +
            "                                                AND BNF.CODSEQBEN       = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2))\n" +
            "                  WHERE PAC.CAD_CNV_ID_CONVENIO IN (281,283) AND length(PAC.CAD_PAC_CD_CREDENCIAL) = 12\n" +
            "                    AND PAC.CAD_PAC_ID_PACIENTE = {0} \n" +
            "                  ) A    ON 1=1\n" +
            "\n" +
            "WHERE  PAC.CAD_PAC_ID_PACIENTE = {0} ", Paciente.IdtPaciente, Paciente.Origem != string.Empty ? Paciente.Origem : "NULL");

            
            dtbResultado = remoto.executeQuery(sqlString);
            sqlString = string.Empty;
            if(dtbResultado.Rows.Count == 0)
                throw new Exception("0"); //problema na query.

            #region Telefone
            sqlString = "SELECT TEL.CAD_TEL_NR_NUM_TEL, TEL.CAD_TEL_NR_RAMAL_TEL, TEL.CAD_TEL_NM_CONTATO,TEL.AUX_TTE_CD_TP_TEL_END\n" +
            "FROM TB_CAD_TEL_TELEFONE TEL WHERE TEL.AUX_TTE_CD_TP_TEL_END = 1 AND TEL.CAD_PES_ID_PESSOA = " + dtbResultado.Rows[0]["CAD_PES_ID_PESSOA"];

            DataTable dtbTelefone = remoto.executeQuery(sqlString);
            sqlString = string.Empty;
            if (dtbTelefone.Rows.Count == 0)
            {
                sqlString = "SELECT TEL.CAD_TEL_NR_NUM_TEL, TEL.CAD_TEL_NR_RAMAL_TEL, TEL.CAD_TEL_NM_CONTATO,TEL.AUX_TTE_CD_TP_TEL_END\n" +
                "FROM TB_CAD_TEL_TELEFONE TEL WHERE ROWNUM = 1 AND TEL.CAD_PES_ID_PESSOA = " + dtbResultado.Rows[0]["CAD_PES_ID_PESSOA"]; 
                dtbTelefone = remoto.executeQuery(sqlString);
                sqlString = string.Empty;
            }
            #endregion

            //dtbResultado.Rows[0]["ORIGEM"] = Paciente.Origem;
            dtbResultado.Rows[0]["ATD_ATE_ID"] = Paciente.Atendimento;
            dtbResultado.Rows[0]["STATUS_LIBERACAO"] = Paciente.StatusLiberacao;

            return MontarEntity(dtbResultado, dtbTelefone);
        }

        private PacienteEntity MontarEntity(DataTable dtbPaciente, DataTable dtbTelefone)
        {
            PacienteEntity pacienteEntity = new PacienteEntity();
            pacienteEntity.Origem = dtbPaciente.Rows[0]["ORIGEM"].ToString();
            pacienteEntity.Atendimento = dtbPaciente.Rows[0]["ATD_ATE_ID"].ToString();
            pacienteEntity.Padrao = dtbPaciente.Rows[0]["CODPADATEBEN"].ToString();
            
            pacienteEntity.CodigoConvenio = dtbPaciente.Rows[0]["CAD_CNV_CD_HAC_PRESTADOR"].ToString();
            pacienteEntity.Convenio = dtbPaciente.Rows[0]["CAD_CNV_NM_FANTASIA"].ToString();
            pacienteEntity.TipoPlano = dtbPaciente.Rows[0]["CAD_TPE_CD_CODIGO"].ToString();
            pacienteEntity.CodigoPlano = dtbPaciente.Rows[0]["CAD_PLA_CD_PLANO_HAC"].ToString();
            pacienteEntity.Plano = dtbPaciente.Rows[0]["CAD_PLA_NM_NOME_PLANO"].ToString();
            
            pacienteEntity.RG = dtbPaciente.Rows[0]["CAD_PES_NR_RG"].ToString();
            pacienteEntity.Validade = dtbPaciente.Rows[0]["CAD_PAC_DT_VALIDADECREDENCIAL"].ToString();
            
            pacienteEntity.Credencial = dtbPaciente.Rows[0]["CAD_PAC_CD_CREDENCIAL"].ToString();
            pacienteEntity.Prontuario = dtbPaciente.Rows[0]["CAD_PAC_NR_PRONTUARIO"].ToString();
            pacienteEntity.Paciente = dtbPaciente.Rows[0]["CAD_PES_NM_PESSOA"].ToString();
            pacienteEntity.DataNascimento = dtbPaciente.Rows[0]["CAD_PES_DT_NASCIMENTO"].ToString();
            pacienteEntity.Sexo = dtbPaciente.Rows[0]["CAD_PES_TP_SEXO"].ToString();
            pacienteEntity.Idade = dtbPaciente.Rows[0]["IDADE"].ToString();

            pacienteEntity.StatusLiberacao = dtbPaciente.Rows[0]["STATUS_LIBERACAO"].ToString();

            if (dtbTelefone.Rows.Count > 0)
                pacienteEntity.Telefone = dtbTelefone.Rows[0]["CAD_TEL_NR_NUM_TEL"].ToString();

            return pacienteEntity;
        }
    }
}
