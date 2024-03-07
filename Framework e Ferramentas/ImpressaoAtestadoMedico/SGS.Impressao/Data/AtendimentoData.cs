using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HospitalAnaCosta.SGS.tools;

namespace HospitalAnaCosta.SGS.Impressao
{
    class AtendimentoData : ClassBase
    {
        public AtendimentoEntity Consultar(AtendimentoEntity Atendimento)
        {
            string sqlString = string.Empty;
            DataTable dtb = new DataTable();

            if (Atendimento.Origem == "0") // ATENDIMENTO
            {
                sqlString = "SELECT ATD.ATD_ATE_FL_STATUS FROM TB_ATD_ATE_ATENDIMENTO ATD WHERE ATD.ATD_ATE_ID = " + Atendimento.Atendimento;
                dtb = remoto.executeQuery(sqlString);
                sqlString = string.Empty;

                if (dtb.Rows.Count == 0)
                    throw new Exception("0"); //Atendimento inexistente.

                if (dtb.Rows[0][0].ToString() != "A")
                    throw new Exception("1"); //Atendimento cancelado.

                sqlString = string.Format("SELECT\n" +
                "              \n" +
                "              0 ORIGEM , \n" +
                "              ATD.ATD_ATE_ID ,\n" +
                "              ATD.CAD_UNI_ID_UNIDADE,\n" +
                "              ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                "              to_char(ATD.ATD_ATE_DT_ATENDIMENTO,'dd/MM/yyyy') ATD_ATE_DT_ATENDIMENTO,\n" +
                "              lpad(TO_char(ATD.ATD_ATE_HR_ATENDIMENTO),'4','0')ATD_ATE_HR_ATENDIMENTO,\n" +
                "              NULL ASS_PAP_DT_SOLIC,\n" +
                "              ATD.CODPAD,\n" +
                "              ATD.ATD_ATE_TP_PACIENTE,\n" +
                "              DECODE(ATD.ATD_ATE_TP_PACIENTE,'A','AMBULATORIO','U','URGENCIA') TP_PACIENTE,\n" +
                "              TAT.TIS_TAT_DS_TPATENDIMENTO,\n" +
                "\n" +
                "              PRO.CAD_PRO_NR_CONSELHO,\n" +
                "              PRO.CAD_PRO_NM_NOME,\n" +
                "              CNV.CAD_CNV_CD_HAC_PRESTADOR ,\n" +
                "              CNV.CAD_CNV_NM_FANTASIA,\n" +
                "              CNV.CAD_CNV_DT_FIM_VIGENCIA,\n" +
                "              CNV.CAD_TPE_CD_CODIGO, \n" +
                "              PLA.CAD_PLA_CD_PLANO_HAC,\n" +
                "              PLA.CAD_PLA_NM_NOME_PLANO,\n" +
                "              PLA.CAD_PLA_DT_FIM_VIGENCIA,\n" +
                "\n" +
                "              UNI.CAD_UNI_DS_UNIDADE,\n" +
                "              LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,\n" +
                "              SETA.CAD_SET_DS_SETOR,\n" +
                "\n" +
                "              to_char(PAC.CAD_PAC_DT_VALIDADECREDENCIAL,'dd/MM/yyyy') CAD_PAC_DT_VALIDADECREDENCIAL,\n" +
                "              PAC.CAD_PAC_CD_CREDENCIAL,\n" +
                "              PAC.CAD_PAC_NR_PRONTUARIO,\n" +
                "              PES.CAD_PES_NR_RG,\n" +
                "              PES.CAD_PES_NM_PESSOA,\n" +
                "              to_char(PES.CAD_PES_DT_NASCIMENTO,'dd/MM/yyyy') CAD_PES_DT_NASCIMENTO,\n" +
                "              PES.CAD_PES_TP_SEXO,\n" +
                "              FNC_RETORNA_TEL_PAC(PES.CAD_PES_ID_PESSOA) CAD_TEL_NR_NUM_TEL,\n" +
                "              FLOOR(FLOOR(MONTHS_BETWEEN(SYSDATE, PES.CAD_PES_DT_NASCIMENTO)) / 12) IDADE,\n" +
                "              NULL STATUS_LIBERACAO, \n" +
                "              TRUNC(SYSDATE) DATA_ATUAL \n" +
                "\n" +
                "       FROM          TB_ATD_ATE_ATENDIMENTO      ATD\n" +
                "       JOIN          TB_CAD_PAC_PACIENTE         PAC  ON            PAC.CAD_PAC_ID_PACIENTE  = FNC_BUSCAR_PACIENTE_ATUAL(ATD.ATD_ATE_ID)\n" +
                "       JOIN          TB_CAD_PES_PESSOA           PES  ON            PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA\n" +
                "       JOIN          TB_CAD_CNV_CONVENIO         CNV  ON            CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO\n" +
                "       JOIN          TB_CAD_PLA_PLANO            PLA  ON            PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO\n" +
                "       JOIN          TB_CAD_UNI_UNIDADE          UNI  ON            UNI.CAD_UNI_ID_UNIDADE  = ATD.CAD_UNI_ID_UNIDADE\n" +
                "       JOIN          TB_CAD_LAT_LOCAL_ATENDIMENTO LAT ON            LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO\n" +
                "       JOIN          TB_CAD_SET_SETOR            SETA  ON            SETA.CAD_SET_ID          = ATD.CAD_SET_ID\n" +
                "       JOIN          TB_TIS_TAT_TP_ATENDIMENTO   TAT  ON            TAT.TIS_TAT_CD_TPATENDIMENTO = ATD.TIS_TAT_CD_TPATENDIMENTO\n" +
                "       LEFT JOIN     TB_CAD_PRO_PROFISSIONAL     PRO  ON            PRO.CAD_PRO_ID_PROFISSIONAL = ATD.CAD_PRO_ID_PROF_EXEC\n" +
                "\n" +
                "        WHERE     ATD.ATD_ATE_ID = {1}", Atendimento.Origem, Atendimento.Atendimento);
                dtb = remoto.executeQuery(sqlString);
                if (dtb.Rows.Count == 0)
                    throw new Exception("3"); //Atendimento inexistente.
            }
            
            if (Atendimento.Origem == "1") // LIBERACAO
            {
                sqlString = "SELECT\n" +
                "              1 ORIGEM ,\n" +
                "              PAP.ATD_ATE_ID ,\n" +
                "              PAP.CAD_UNI_ID_UNIDADE,\n" +
                "              PAP.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                "              to_char(PAP.ASS_PAP_DT_AUTOR,'dd/MM/yyyy') ATD_ATE_DT_ATENDIMENTO,\n" +
                "              lpad(TO_char(PAP.ASS_PAP_HR_AUTOR),'4','0') ATD_ATE_HR_ATENDIMENTO,\n" +
                "              to_char(PAP.ASS_PAP_DT_SOLIC,'dd/MM/yyyy') ASS_PAP_DT_SOLIC,\n" +
                "\n" +
                "              PAP.CODPAD,\n" +
                "              NULL ATD_ATE_TP_PACIENTE,\n" +
                "              NULL TP_PACIENTE,\n" +
                "              NULL TIS_TAT_DS_TPATENDIMENTO,\n" +
                "              PSO.CAD_PSO_CD_CONSELHO CAD_PRO_NR_CONSELHO,\n" +
                "              PSO.CAD_PSO_NM_PROFISSIONAL CAD_PRO_NM_NOME,\n" +
                "\n" +
                "              CNV.CAD_CNV_CD_HAC_PRESTADOR ,\n" +
                "              CNV.CAD_CNV_NM_FANTASIA,\n" +
                "              CNV.CAD_TPE_CD_CODIGO,\n" +
                "              CNV.CAD_CNV_DT_FIM_VIGENCIA,\n" +
                "              PLA.CAD_PLA_CD_PLANO_HAC,\n" +
                "              PLA.CAD_PLA_NM_NOME_PLANO,\n" +
                "              PLA.CAD_PLA_DT_FIM_VIGENCIA,\n" +
                "\n" +
                "              UNI.CAD_UNI_DS_UNIDADE,\n" +
                "              LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,\n" +
                "              --SETA.CAD_SET_DS_SETOR,\n" +
                "              UNIL.CAD_UNI_DS_UNIDADE CAD_SET_DS_SETOR,\n" +
                "\n" +
                "              to_char(PAC.CAD_PAC_DT_VALIDADECREDENCIAL,'dd/MM/yyyy') CAD_PAC_DT_VALIDADECREDENCIAL,\n" +
                "              PAC.CAD_PAC_CD_CREDENCIAL,\n" +
                "              PAC.CAD_PAC_NR_PRONTUARIO,\n" +
                "              PES.CAD_PES_NR_RG,\n" +
                "              PES.CAD_PES_NM_PESSOA,\n" +
                "              to_char(PES.CAD_PES_DT_NASCIMENTO,'dd/MM/yyyy') CAD_PES_DT_NASCIMENTO,\n" +
                "              PES.CAD_PES_TP_SEXO,\n" +
                "\n" +
                "              FNC_RETORNA_TEL_PAC(PES.CAD_PES_ID_PESSOA) CAD_TEL_NR_NUM_TEL,\n" +
                "              FLOOR(FLOOR(MONTHS_BETWEEN(SYSDATE, PES.CAD_PES_DT_NASCIMENTO)) / 12) IDADE,\n" +
                "              CASE\n" +
                "                   WHEN PAP.ASS_PAP_FL_STATUS_AUTOR = 'A' THEN 'AUTORIZADO'\n" +
                "                   WHEN PAP.ASS_PAP_FL_STATUS_AUTOR = 'N' THEN 'NAO AUTORIZADO'\n" +
                "                   ELSE 'PENDENTE'\n" +
                "              END STATUS_LIBERACAO,\n" +
                "              TRUNC(SYSDATE) DATA_ATUAL \n" +
                "\n" +
                "       FROM          TB_ASS_PAP_PAC_ATEN_PROC    PAP\n" +
                "       JOIN          TB_CAD_PAC_PACIENTE         PAC  ON   PAC.CAD_PAC_ID_PACIENTE = PAP.CAD_PAC_ID_PACIENTE\n" +
                "       JOIN          TB_CAD_PES_PESSOA           PES  ON   PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA\n" +
                "       JOIN          TB_CAD_CNV_CONVENIO         CNV  ON   CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO\n" +
                "       JOIN          TB_CAD_PLA_PLANO            PLA  ON   PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO\n" +
                "       JOIN          TB_CAD_UNI_UNIDADE          UNI  ON   UNI.CAD_UNI_ID_UNIDADE  = PAP.CAD_UNI_ID_UNIDADE\n" +
                "       JOIN          TB_CAD_LAT_LOCAL_ATENDIMENTO LAT ON   LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = PAP.CAD_LAT_ID_LOCAL_ATENDIMENTO\n" +
                "       JOIN          TB_CAD_SET_SETOR            SETL ON   SETL.CAD_SET_ID = PAP.CAD_SET_ID_SETOR_LIBERACAO\n" +
                "       JOIN          TB_CAD_UNI_UNIDADE           UNIL ON   UNI.CAD_UNI_ID_UNIDADE = SETL.CAD_UNI_ID_UNIDADE\n" +
                "\n" +
                "       LEFT JOIN     TB_CAD_PSO_PROF_SOLICITANTE   PSO  ON   PSO.TIS_CPR_CD_CONSELHOPROF = PAP.TIS_CPR_CD_CONSELHOPROF_SOLIC\n" +
                "                                                        AND PSO.CAD_PSO_CD_CONSELHO      = PAP.ATD_ATE_NR_CONSELHO_SOLIC\n" +
                "                                                        AND PSO.CAD_PSO_SG_UF_CONSELHO   = PAP.ATD_ATE_CD_UFCONSELHO_SOLIC\n" +
                "\n" +
                "        WHERE     PAP.ATD_ATE_ID = " + Atendimento.Atendimento;

                dtb = remoto.executeQuery(sqlString);
                if (dtb.Rows.Count == 0)
                    throw new Exception("2"); //Atendimento inexistente.
            }
            
            sqlString = string.Empty;
            if(dtb.Rows.Count == 0)
                throw new Exception(); //problema na query.

            dtb.Rows[0]["ORIGEM"] = Atendimento.Origem.ToString();

            return MontarEntity(dtb);
        }

        private AtendimentoEntity MontarEntity(DataTable dtb)
        {
            AtendimentoEntity atendimentoEntity = new AtendimentoEntity();
            atendimentoEntity.Origem = dtb.Rows[0]["ORIGEM"].ToString();
            atendimentoEntity.Atendimento = dtb.Rows[0]["ATD_ATE_ID"].ToString();
            atendimentoEntity.TipoPaciente = dtb.Rows[0]["TP_PACIENTE"].ToString();
            atendimentoEntity.DataAtendimento = dtb.Rows[0]["ATD_ATE_DT_ATENDIMENTO"].ToString();
            atendimentoEntity.HoraAtendimento = dtb.Rows[0]["ATD_ATE_HR_ATENDIMENTO"].ToString();
            atendimentoEntity.DataSolicitacao = dtb.Rows[0]["ASS_PAP_DT_SOLIC"].ToString();
            atendimentoEntity.DataAtual = dtb.Rows[0]["DATA_ATUAL"].ToString();
            atendimentoEntity.Padrao = dtb.Rows[0]["CODPAD"].ToString();
            
            atendimentoEntity.CodigoConvenio = dtb.Rows[0]["CAD_CNV_CD_HAC_PRESTADOR"].ToString();
            atendimentoEntity.Convenio = dtb.Rows[0]["CAD_CNV_NM_FANTASIA"].ToString();
            atendimentoEntity.DataFimConvenio = dtb.Rows[0]["CAD_CNV_DT_FIM_VIGENCIA"].ToString();
            atendimentoEntity.TipoPlano = dtb.Rows[0]["CAD_TPE_CD_CODIGO"].ToString();
            atendimentoEntity.TipoAtendimento = dtb.Rows[0]["TIS_TAT_DS_TPATENDIMENTO"].ToString();
            atendimentoEntity.CodigoPlano = dtb.Rows[0]["CAD_PLA_CD_PLANO_HAC"].ToString();
            atendimentoEntity.Plano = dtb.Rows[0]["CAD_PLA_NM_NOME_PLANO"].ToString();
            atendimentoEntity.DataFimPlano = dtb.Rows[0]["CAD_PLA_DT_FIM_VIGENCIA"].ToString();
            atendimentoEntity.IDUnidade = dtb.Rows[0]["CAD_UNI_ID_UNIDADE"].ToString();
            atendimentoEntity.Unidade = dtb.Rows[0]["CAD_UNI_DS_UNIDADE"].ToString();
            atendimentoEntity.IDLocal = dtb.Rows[0]["CAD_LAT_ID_LOCAL_ATENDIMENTO"].ToString();
            atendimentoEntity.Local = dtb.Rows[0]["CAD_LAT_DS_LOCAL_ATENDIMENTO"].ToString();
            atendimentoEntity.Setor = dtb.Rows[0]["CAD_SET_DS_SETOR"].ToString();
            //atendimentoEntity.SetorLiberacao = dtb.Rows[0]["CAD_SET_DS_SETOR_LIBERACAO"].ToString();
            atendimentoEntity.RG = dtb.Rows[0]["CAD_PES_NR_RG"].ToString();
            atendimentoEntity.Validade = dtb.Rows[0]["CAD_PAC_DT_VALIDADECREDENCIAL"].ToString();
            
            atendimentoEntity.Credencial = dtb.Rows[0]["CAD_PAC_CD_CREDENCIAL"].ToString();
            atendimentoEntity.Prontuario = dtb.Rows[0]["CAD_PAC_NR_PRONTUARIO"].ToString();
            atendimentoEntity.Paciente = dtb.Rows[0]["CAD_PES_NM_PESSOA"].ToString();
            atendimentoEntity.DataNascimento = dtb.Rows[0]["CAD_PES_DT_NASCIMENTO"].ToString();
            atendimentoEntity.Sexo = dtb.Rows[0]["CAD_PES_TP_SEXO"].ToString();

            //atendimentoEntity.Endereco = string.Format("{0} {1} {2}", dtb.Rows[0]["CAD_END_NM_LOGRADOURO"].ToString(),
            //    dtb.Rows[0]["CAD_END_DS_NUMERO"].ToString(),
            //    dtb.Rows[0]["CAD_END_DS_COMPLEMENTO"].ToString());

            //atendimentoEntity.Logradouro = dtb.Rows[0]["CAD_END_NM_LOGRADOURO"].ToString();
            //atendimentoEntity.NumeroEndereco = dtb.Rows[0]["CAD_END_DS_NUMERO"].ToString(); //dtb.Rows[0]["CAD_END_DS_NUMERO"].ToString();
            //atendimentoEntity.Complemento = dtb.Rows[0]["CAD_END_DS_COMPLEMENTO"].ToString();
            //atendimentoEntity.Bairro = dtb.Rows[0]["CAD_END_NM_BAIRRO"].ToString();
            //atendimentoEntity.UF = dtb.Rows[0]["CAD_END_SG_UF"].ToString();
            //atendimentoEntity.Cidade = dtb.Rows[0]["AUX_MUN_NM_MUNICIPIO"].ToString();
            atendimentoEntity.Telefone = dtb.Rows[0]["CAD_TEL_NR_NUM_TEL"].ToString();
            atendimentoEntity.Idade = dtb.Rows[0]["IDADE"].ToString();
            atendimentoEntity.StatusLiberacao = dtb.Rows[0]["STATUS_LIBERACAO"].ToString();
            //atendimentoEntity.InstitutoGeriatria = dtb.Rows[0]["GER"].ToString();

            return atendimentoEntity;
        }
    }
}
