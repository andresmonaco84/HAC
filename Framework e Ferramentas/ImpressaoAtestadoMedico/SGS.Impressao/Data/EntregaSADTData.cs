using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HospitalAnaCosta.SGS.tools;

namespace HospitalAnaCosta.SGS.Impressao
{
    class EntregaSADTData : ClassBase
    {
        public EntregaSADTEntity Consultar(EntregaSADTEntity AtendimentoSADT)
        {
            string sqlString = string.Empty;
            DataTable dtb = new DataTable();

            
            //sqlString = string.Format("SELECT ATS.ATS_ATE_FL_STATUS FROM TB_ATS_ATE_ATENDIMENTO_SADT   ATS \n" + 
            //" WHERE (ATS.ATS_ATE_CD_INTLIB = {0}) AND\n" + 
            //                            "          (ATS.ATS_ATE_IN_INTLIB = {1}) AND\n" + 
            //                            "          (ATS.ATS_ATE_ID = {2}) AND\n" + 
            //                            "          (ATS.CAD_PRD_ID = {3}) AND\n" + 
            //                            "          (ATS.AUX_EPP_CD_ESPECPROC = {4}) AND\n" + 
            //                            "          (ATS.TIS_MED_CD_TABELAMEDICA = {5})",AtendimentoSADT.Atendimento,
            //                            AtendimentoSADT.TipoIntLib,
            //                            AtendimentoSADT.CodigoExame,
            //                            AtendimentoSADT.CodigoProduto,
            //                            AtendimentoSADT.CodigoEspecialidade,
            //                            AtendimentoSADT.CodigoTabelaMedica);
            //dtb = remoto.executeQuery(sqlString);
            //sqlString = string.Empty;

              
            //Seleciona todos os exames da requisição
            sqlString = string.Format("   SELECT\n" +
                                        "          ATS.ATS_ATE_CD_INTLIB,\n" + 
                                        "          ATS.ATS_ATE_IN_INTLIB,\n" + 
                                        "          ATS.ATS_ATE_ID,\n" + 
                                        "          ATS.CAD_PRD_ID,\n" + 
                                        "          ATS.ATS_ATE_SG_UF_CONSELHO_SOLIC,\n" + 
                                        "          ATS.ATS_ATE_TP_CONSELHO_SOLIC,\n" + 
                                        "          ATS.ATS_ATE_NR_CONSELHO_SOLIC,\n" +
                                        "          TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED,'dd/MM/yyyy') ATS_ATE_DT_REALIZ_PROCED,\n" + 
                                        "          ATS.ATS_ATE_HR_REALIZ_PROCED,\n" + 
                                        "          ATS.ATS_ATE_FL_STATUS,\n" + 
                                        "          ATS.CAD_PAC_ID_PACIENTE_INT,\n" + 
                                        "          ATS.CAD_UNI_ID_UNIDADE_LIBERACAO,\n" + 
                                        "          ATS.CAD_UNI_ID_LOCAL_LIBERACAO,\n" + 
                                        "          ATS.TIS_MED_CD_TABELAMEDICA,\n" + 
                                        "          PRD.CAD_PRD_CD_CODIGO,\n" +
                                        "          PRD.CAD_PRD_NM_MNEMONICO,\n" + 
                                        "\n" +
                                        "          TO_CHAR(ARP.ATS_ARP_DT_RESULTADO,'dd/MM/yyyy') ATS_ARP_DT_RESULTADO,\n" + 
                                        "          ARP.ATS_APR_NR_SEQ_LOTE,\n" + 
                                        "\n" +
                //produto filtra somente na data de realizacao do que foi selecionado na tela
                                        "          TO_CHAR((SELECT ATS.ATS_ATE_DT_REALIZ_PROCED FROM TB_ATS_ATE_ATENDIMENTO_SADT ATS\n" +
                                        "            WHERE ATS.ATS_ATE_FL_STATUS = 'A' AND\n" + 
                                        "                  (ATS.ATS_ATE_CD_INTLIB = {0}) AND\n" + 
                                        "                  (ATS.ATS_ATE_IN_INTLIB = '{1}') AND\n" + 
                                        "                  (ATS.ATS_ATE_ID = {2}) AND\n" + 
                                        "                  (ATS.AUX_EPP_CD_ESPECPROC = {3}) AND\n" + 
                                        "                  (ATS.TIS_MED_CD_TABELAMEDICA = {4}) AND\n" + 
                                        "                  (ATS.CAD_PRD_ID = {5})\n" +
                                        "         ),'dd/MM/yyyy') ATS_ATE_DT_REALIZ_SELECIONADO,\n" +
                                        "\n" + 
                                        "          PRO.CAD_PRO_NR_CONSELHO,\n" + 
                                        "          PRO.CAD_PRO_NM_NOME,\n" + 
                                        "          CNV.CAD_CNV_CD_HAC_PRESTADOR ,\n" + 
                                        "          CNV.CAD_CNV_NM_FANTASIA,\n" + 
                                        "          CNV.CAD_TPE_CD_CODIGO,\n" + 
                                        "          PLA.CAD_PLA_CD_TIPOPLANO,\n" + 
                                        "          PLA.CAD_PLA_CD_PLANO_HAC,\n" + 
                                        "          PLA.CAD_PLA_NM_NOME_PLANO,\n" + 
                                        "\n" + 
                                        "          UNI.CAD_UNI_DS_UNIDADE,\n" + 
                                        "          LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,\n" + 
                                        "          S.CAD_SET_CD_SETOR, S.CAD_SET_DS_SETOR, S.CAD_SET_DS_PROCEDENCIA,\n" +
                                        "          UNIE.CAD_UNI_ID_UNIDADE CAD_UNI_ID_UNIDADE_E,\n" + 
                                        "          UNIE.CAD_UNI_DS_UNIDADE CAD_UNI_DS_UNIDADE_E,\n" + 
                                        "\n" + 
                                        "          ATS.ATS_ATE_FL_RN,\n" + 
                                        "          TO_CHAR(PAC.CAD_PAC_DT_VALIDADECREDENCIAL,'dd/MM/yyyy') CAD_PAC_DT_VALIDADECREDENCIAL,\n" + 
                                        "          PAC.CAD_PAC_CD_CREDENCIAL,\n" + 
                                        "          PAC.CAD_PAC_NR_PRONTUARIO,\n" + 
                                        "          PES.CAD_PES_NR_RG,\n" + 
                                        "          PES.CAD_PES_NM_PESSOA,\n" + 
                                        "          TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'dd/MM/yyyy') CAD_PES_DT_NASCIMENTO,\n" + 
                                        "          PES.CAD_PES_TP_SEXO,\n" + 
                                        "          --FNC_RETORNA_TEL_PAC(PES.CAD_PES_ID_PESSOA) CAD_TEL_NR_NUM_TEL,\n" + 
                                        "          FLOOR(FLOOR(MONTHS_BETWEEN(SYSDATE, PES.CAD_PES_DT_NASCIMENTO)) / 12) IDADE,\n" +
                                        "          TO_CHAR(TRUNC(SYSDATE),'dd/MM/yyyy') DATA_ATUAL\n" + 
                                        "\n" + 
                                        "     FROM TB_ATS_ATE_ATENDIMENTO_SADT   ATS\n" + 
                                        "\n" + 
                                        "     JOIN TB_ATS_ARP_ATEN_RESULT_PROCED ARP ON ARP.ATS_ATE_CD_INTLIB    = ATS.ATS_ATE_CD_INTLIB\n" + 
                                        "                                           AND ARP.ATS_ATE_IN_INTLIB    = ATS.ATS_ATE_IN_INTLIB\n" + 
                                        "                                           AND ARP.ATS_EPP_CD_ESPECPROC = ATS.AUX_EPP_CD_ESPECPROC\n" + 
                                        "                                           AND ARP.TIS_MED_CD_TABELAMEDICA = ATS.TIS_MED_CD_TABELAMEDICA\n" + 
                                        "                                           AND ARP.CAD_PRD_ID              = ATS.CAD_PRD_ID\n" + 
                                        "                                           AND ARP.ATS_ATE_ID              = ATS.ATS_ATE_ID\n" + 
                                        "     JOIN TB_CAD_PAC_PACIENTE         PAC  ON  PAC.CAD_PAC_ID_PACIENTE  = ATS.CAD_PAC_ID_PACIENTE_INT\n" + 
                                        "     JOIN TB_CAD_PES_PESSOA           PES  ON  PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA\n" + 
                                        "     JOIN TB_CAD_CNV_CONVENIO         CNV  ON  CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO\n" + 
                                        "     JOIN TB_CAD_PLA_PLANO            PLA  ON  PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO\n" +
                                        "     JOIN TB_CAD_PRD_PRODUTO          PRD  ON  PRD.CAD_PRD_ID          = ATS.CAD_PRD_ID\n" +      
                                        
                                        "     JOIN TB_CAD_SET_SETOR              S   ON S.CAD_SET_ID            = ATS.CAD_SET_ID_ATEN\n" +      
                                        "LEFT JOIN TB_CAD_UNI_UNIDADE          UNI  ON  UNI.CAD_UNI_ID_UNIDADE  = S.CAD_UNI_ID_UNIDADE\n" +      
                                        "LEFT JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT ON  LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = S.CAD_LAT_ID_LOCAL_ATENDIMENTO\n" +      

                                        "--LEFT JOIN TB_CAD_SET_SETOR             SE   ON SE.CAD_SET_ID = ARP.CAD_SET_ID_SETOR\n" +      
                                        "LEFT JOIN TB_CAD_UNI_UNIDADE          UNIE  ON  UNIE.CAD_UNI_ID_UNIDADE  = ARP.CAD_UNI_ID_UNIDADE\n" + 
                                        
                                        "LEFT JOIN TB_CAD_PRO_PROFISSIONAL     PRO  ON  PRO.CAD_PRO_ID_PROFISSIONAL = ATS.CAD_PRO_ID_PROF_EXECUTANTE\n" + 
                                        "\n" +
                                        "    WHERE (ATS.ATS_ATE_FL_STATUS = 'A') AND\n" + 
                                        "          (ATS.ATS_ATE_CD_INTLIB = {0}) AND\n" + 
                                        "          (ATS.ATS_ATE_IN_INTLIB = '{1}') AND\n" + 
                                        "          (ATS.ATS_ATE_ID = {2}) AND\n" + 
                                        "          (ATS.AUX_EPP_CD_ESPECPROC = {3}) AND\n" + 
                                        "          (ATS.TIS_MED_CD_TABELAMEDICA = {4})",AtendimentoSADT.Atendimento,
                                        AtendimentoSADT.TipoIntLib,
                                        AtendimentoSADT.CodigoExame,
                                        AtendimentoSADT.CodigoEspecialidade,
                                        AtendimentoSADT.CodigoTabelaMedica,
                                        AtendimentoSADT.IdtProduto); //produto filtra somente na data de realizacao do que foi selecionado na tela
            
                dtb = remoto.executeQuery(sqlString);
                sqlString = string.Empty;
                if (dtb.Rows.Count == 0)
                    throw new Exception("0"); //Atendimento inexistente.

                #region Pesquisa Endereço de entrega da Unidade
                DataTable dtbEnderecoEntrega = new DataTable();
                sqlString = " SELECT END.CAD_END_ID_ENDERECO, " +
                              "        END.CAD_END_NM_LOGRADOURO, " +
                              "        END.CAD_END_NM_BAIRRO, " +
                              "        END.CAD_END_SG_UF, " +
                              "        END.CAD_END_CD_CEP, " +
                              "        END.CAD_END_DS_NUMERO, " +
                              "        END.TIS_TLG_CD_TPLOGRADOURO, " +
                              "        END.CAD_END_DT_ULTIMA_ATUALIZACAO, " +
                              "        END.AUX_MUN_CD_IBGE, " +
                              "        END.CAD_END_DS_COMPLEMENTO, " +
                              "        END.SEG_USU_ID_USUARIO, " +
                              "        END.AUX_TTE_CD_TP_TEL_END, " +
                              "        END.CAD_PES_ID_PESSOA, " +
                              "        END.CAD_END_NM_ENDERECO_NF " +
                              " FROM TB_CAD_END_ENDERECO        END, " +
                    //"      TB_ASS_PEE_PESSOA_ENDERECO PEE, "+
                              "      TB_CAD_UNI_UNIDADE         UNI  " +
                    // " WHERE END.CAD_END_ID_ENDERECO = PEE.CAD_END_ID_ENDERECO " +
                              " WHERE END.CAD_PES_ID_PESSOA   = UNI.CAD_PES_ID_PESSOA " +
                          //    "   AND END.AUX_TTE_CD_TP_TEL_END = 2 " +
                string.Format(" AND   UNI.CAD_UNI_ID_UNIDADE  = {0} ", dtb.Rows[0]["CAD_UNI_ID_UNIDADE_E"].ToString())
                    //" AND   PEE.CAD_PES_ID_PESSOA   = UNI.CAD_PES_ID_PESSOA "
                              ;
                dtbEnderecoEntrega = remoto.executeQuery(sqlString);
                sqlString = string.Empty;
                #endregion

                return MontarEntity(dtb, dtbEnderecoEntrega);
        }

        private EntregaSADTEntity MontarEntity(DataTable dtb,DataTable dtbEnderecoEntrega)
        {
            EntregaSADTEntity atendimentoSADTEntity = new EntregaSADTEntity();
          //  atendimentoSADTEntity.Origem = dtb.Rows[0]["ORIGEM"].ToString();
            atendimentoSADTEntity.Atendimento = dtb.Rows[0]["ATS_ATE_CD_INTLIB"].ToString();
            atendimentoSADTEntity.TipoIntLib = dtb.Rows[0]["ATS_ATE_IN_INTLIB"].ToString();
            atendimentoSADTEntity.CodigoExame = dtb.Rows[0]["ATS_ATE_ID"].ToString();
            atendimentoSADTEntity.IdtProduto = dtb.Rows[0]["CAD_PRD_ID"].ToString();
            atendimentoSADTEntity.CodigoTabelaMedica = dtb.Rows[0]["TIS_MED_CD_TABELAMEDICA"].ToString();
          
            atendimentoSADTEntity.CodigoConvenio = dtb.Rows[0]["CAD_CNV_CD_HAC_PRESTADOR"].ToString();
            atendimentoSADTEntity.Convenio = dtb.Rows[0]["CAD_CNV_NM_FANTASIA"].ToString();
            atendimentoSADTEntity.TipoPlano = dtb.Rows[0]["CAD_TPE_CD_CODIGO"].ToString();
          
            atendimentoSADTEntity.CodigoPlano = dtb.Rows[0]["CAD_PLA_CD_PLANO_HAC"].ToString();
            atendimentoSADTEntity.Plano = dtb.Rows[0]["CAD_PLA_NM_NOME_PLANO"].ToString();
            atendimentoSADTEntity.Unidade = dtb.Rows[0]["CAD_UNI_DS_UNIDADE"].ToString();
          
            atendimentoSADTEntity.Local = dtb.Rows[0]["CAD_LAT_DS_LOCAL_ATENDIMENTO"].ToString();
            atendimentoSADTEntity.Setor = dtb.Rows[0]["CAD_SET_DS_SETOR"].ToString();
            atendimentoSADTEntity.UnidadeEntrega = string.Format("{0}, {1} - {2} ", dtbEnderecoEntrega.Rows[0]["CAD_END_NM_LOGRADOURO"].ToString(), dtbEnderecoEntrega.Rows[0]["CAD_END_DS_NUMERO"].ToString(), dtbEnderecoEntrega.Rows[0]["CAD_END_NM_BAIRRO"].ToString()); //dtb.Rows[0]["CAD_UNI_DS_UNIDADE_E"].ToString();

            atendimentoSADTEntity.RG = dtb.Rows[0]["CAD_PES_NR_RG"].ToString();
            atendimentoSADTEntity.Validade = dtb.Rows[0]["CAD_PAC_DT_VALIDADECREDENCIAL"].ToString();
            
            atendimentoSADTEntity.Credencial = dtb.Rows[0]["CAD_PAC_CD_CREDENCIAL"].ToString();
            atendimentoSADTEntity.Prontuario = dtb.Rows[0]["CAD_PAC_NR_PRONTUARIO"].ToString();
            atendimentoSADTEntity.Paciente = dtb.Rows[0]["CAD_PES_NM_PESSOA"].ToString();
            atendimentoSADTEntity.DataNascimento = dtb.Rows[0]["CAD_PES_DT_NASCIMENTO"].ToString();
            atendimentoSADTEntity.Sexo = dtb.Rows[0]["CAD_PES_TP_SEXO"].ToString();

          //  atendimentoSADTEntity.Telefone = dtb.Rows[0]["CAD_TEL_NR_NUM_TEL"].ToString();
            atendimentoSADTEntity.Idade = dtb.Rows[0]["IDADE"].ToString();

            atendimentoSADTEntity.DataAtual = dtb.Rows[0]["DATA_ATUAL"].ToString();
            atendimentoSADTEntity.DataAtendimentoSelecionado = dtb.Rows[0]["ATS_ATE_DT_REALIZ_SELECIONADO"].ToString();

            for (int iCont = 0; iCont < dtb.Rows.Count; iCont++)
            {
                atendimentoSADTEntity.DataAtendimento = dtb.Rows[0]["ATS_ATE_DT_REALIZ_PROCED"].ToString() + ";";
                atendimentoSADTEntity.HoraAtendimento = dtb.Rows[0]["ATS_ATE_HR_REALIZ_PROCED"].ToString() + ";";

                atendimentoSADTEntity.CodigoProduto += dtb.Rows[iCont]["CAD_PRD_CD_CODIGO"].ToString() + ";";
                atendimentoSADTEntity.MnemonicoProduto += dtb.Rows[iCont]["CAD_PRD_NM_MNEMONICO"].ToString() + ";";
                atendimentoSADTEntity.DataResultado += dtb.Rows[iCont]["ATS_ARP_DT_RESULTADO"].ToString() + ";";
            }

            if (atendimentoSADTEntity.DataAtendimento.Trim().Length > 0)
                atendimentoSADTEntity.DataAtendimento = atendimentoSADTEntity.DataAtendimento.Remove(atendimentoSADTEntity.DataAtendimento.LastIndexOf(";"), 1);
            if (atendimentoSADTEntity.HoraAtendimento.Trim().Length > 0)
                atendimentoSADTEntity.HoraAtendimento = atendimentoSADTEntity.HoraAtendimento.Remove(atendimentoSADTEntity.HoraAtendimento.LastIndexOf(";"), 1);
            if (atendimentoSADTEntity.CodigoProduto.Trim().Length > 0)
                atendimentoSADTEntity.CodigoProduto = atendimentoSADTEntity.CodigoProduto.Remove(atendimentoSADTEntity.CodigoProduto.LastIndexOf(";"), 1);
            if (atendimentoSADTEntity.MnemonicoProduto.Trim().Length > 0)
                atendimentoSADTEntity.MnemonicoProduto = atendimentoSADTEntity.MnemonicoProduto.Remove(atendimentoSADTEntity.MnemonicoProduto.LastIndexOf(";"), 1);
            if (atendimentoSADTEntity.DataResultado.Trim().Length > 0)
                atendimentoSADTEntity.DataResultado = atendimentoSADTEntity.DataResultado.Remove(atendimentoSADTEntity.DataResultado.LastIndexOf(";"), 1);
            

            return atendimentoSADTEntity;
        }
    }
}
