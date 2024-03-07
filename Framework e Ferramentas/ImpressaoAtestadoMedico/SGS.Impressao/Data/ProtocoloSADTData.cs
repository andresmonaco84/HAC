using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HospitalAnaCosta.SGS.tools;

namespace HospitalAnaCosta.SGS.Impressao
{
    class ProtocoloSADTData : ClassBase
    {
        public ProtocoloSADTEntity Consultar(ProtocoloSADTEntity ProtocoloSADT)
        {
            string sqlString = string.Empty;
            DataTable dtb = new DataTable();

            sqlString = "SELECT\n" +
            "        ATS.ATS_ATE_ID,\n" +
            "        ATS.ATS_ATE_CD_INTLIB,\n" +
            "        ATS.ATS_ATE_IN_INTLIB,\n" +
            "        ARP.ATS_APR_NR_SEQ_LOTE,\n" +
            "        ARP.ATS_APR_NR_SEQ_DIGITACAO,\n" +
            "        ARP.ATS_ARP_DT_RESULTADO,\n" +
            "        ARP.CAD_UNI_ID_UNIDADE CAD_UNI_ID_UNIDADE_E,\n" +
            "        UNI.CAD_UNI_DS_UNIDADE,\n" +
            "        LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,\n" +
            "        SETOR.CAD_SET_DS_SETOR,\n" +
            "        CNV.CAD_CNV_CD_HAC_PRESTADOR,\n" +
            "        CNV.CAD_CNV_NM_FANTASIA,\n" +
            "        PLA.CAD_PLA_CD_PLANO_HAC,\n" +
            "        PLA.CAD_PLA_NM_NOME_PLANO,\n" +
            "        DECODE(ATS.ATS_ATE_FL_RN, 'S', 'RN DE ' || PES_PAC.CAD_PES_NM_PESSOA, PES_PAC.CAD_PES_NM_PESSOA) NOMEPAC,\n" +
            "        QLE.CAD_QLE_NR_QUARTO,\n" +
            "        QLE.CAD_QLE_NR_LEITO,\n" +
            "        SETT.CAD_SET_CD_SETOR--,\n" +
            "        /*TLG.TIS_TLG_DS_TPLOGRADOURO,\n" +
            "        ENDERECO.CAD_END_NM_LOGRADOURO,\n" +
            "        ENDERECO.CAD_END_DS_NUMERO,\n" +
            "        ENDERECO.CAD_END_DS_COMPLEMENTO,*/\n" +
            "      --  FNC_ATS_EXAMES_LAUDO(ARP.ATS_APR_NR_SEQ_LOTE,\n" +
            "       ---                      ARP.ATS_ATE_CD_INTLIB,\n" +
            "        --                     ENDERECO.CAD_END_ID_ENDERECO,\n" +
            "        --                     ARP.ATS_ARP_DT_RESULTADO) CODIGO_EXAME\n" +
            "   FROM TB_ATS_ARP_ATEN_RESULT_PROCED ARP\n" +
            "   JOIN TB_ATS_ATE_ATENDIMENTO_SADT ATS\n" +
            "     ON  ATS.ATS_ATE_CD_INTLIB = ARP.ATS_ATE_CD_INTLIB\n" +
            "    AND ATS.ATS_ATE_IN_INTLIB = ARP.ATS_ATE_IN_INTLIB\n" +
            "    AND ATS.ATS_ATE_ID = ARP.ATS_ATE_ID\n" +
            "    AND ATS.CAD_PRD_ID = ARP.CAD_PRD_ID\n" +
            "    AND ATS.AUX_EPP_CD_ESPECPROC = ARP.ATS_EPP_CD_ESPECPROC\n" +
            "    AND ATS.TIS_MED_CD_TABELAMEDICA = ARP.TIS_MED_CD_TABELAMEDICA\n" +
            "\n" +
            "   JOIN TB_CAD_PAC_PACIENTE         PAC     ON PAC.CAD_PAC_ID_PACIENTE = ATS.CAD_PAC_ID_PACIENTE_INT\n" +
            "   JOIN TB_CAD_PES_PESSOA           PES_PAC ON PES_PAC.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA\n" +
            "   JOIN TB_CAD_PLA_PLANO            PLA     ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO\n" +
            "   JOIN TB_CAD_CNV_CONVENIO         CNV     ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO\n" +
            "\n" +
            "   JOIN TB_CAD_SET_SETOR            SETOR   ON SETOR.CAD_SET_ID = ATS.CAD_SET_ID\n" +
            "   JOIN TB_CAD_UNI_UNIDADE          UNI     ON UNI.CAD_UNI_ID_UNIDADE = ARP.CAD_UNI_ID_UNIDADE\n" +
            "   JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT     ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO\n" +

            "\n" +
            "   LEFT JOIN TB_ATD_IML_INT_MOV_LEITO IML ON IML.ATD_ATE_ID = ARP.ATS_ATE_CD_INTLIB AND IML.ATD_IML_DT_SAIDA IS NULL\n" +
            "   LEFT JOIN TB_CAD_QLE_QUARTO_LEITO  QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID\n" +
            "   LEFT JOIN TB_CAD_SET_SETOR         SETT ON SETT.CAD_SET_ID = QLE.CAD_SET_ID\n" +
            "\n" +
            "WHERE 1=1\n";
            if(ProtocoloSADT.Lote.Length > 0)
                sqlString += "  AND ARP.ATS_APR_NR_SEQ_LOTE = {0} \n";            
            if(ProtocoloSADT.CodigoExame.Length > 0)
                sqlString +="  AND ARP.ATS_ATE_ID IN ({1}) \n";
            if(ProtocoloSADT.Atendimento.Length > 0)
                sqlString +="  AND ARP.ATS_ATE_CD_INTLIB IN ({2}) \n";
            if(ProtocoloSADT.IdtProduto.Length > 0)
                sqlString +="  AND ARP.CAD_PRD_ID IN ({3}) \n";
            
            sqlString += "\n" +
            "   GROUP BY\n" +
            "          ATS.ATS_ATE_ID,\n" +
            "          ATS.ATS_ATE_CD_INTLIB,\n" +
            "          ATS.ATS_ATE_IN_INTLIB,\n" +
            "                  ARP.ATS_APR_NR_SEQ_LOTE,\n" +
            "        ARP.ATS_APR_NR_SEQ_DIGITACAO,\n" +
            "          ARP.ATS_ARP_DT_RESULTADO,\n" +
            "          ARP.ATS_APR_NR_SEQ_DIGITACAO,\n" +
            "          UNI.CAD_UNI_DS_UNIDADE,\n" +
            "          LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,\n" +
            "          SETOR.CAD_SET_DS_SETOR,\n" +
            "          CNV.CAD_CNV_CD_HAC_PRESTADOR,\n" +
            "          CNV.CAD_CNV_NM_FANTASIA,\n" +
            "          PLA.CAD_PLA_CD_PLANO_HAC,\n" +
            "          PLA.CAD_PLA_NM_NOME_PLANO,\n" +
            "          DECODE(ATS.ATS_ATE_FL_RN, 'S', 'RN DE ' || PES_PAC.CAD_PES_NM_PESSOA, PES_PAC.CAD_PES_NM_PESSOA),\n" +
            "          QLE.CAD_QLE_NR_QUARTO,\n" +
            "          QLE.CAD_QLE_NR_LEITO,\n" +
            "          SETT.CAD_SET_CD_SETOR--,\n" +
            "         /* TLG.TIS_TLG_DS_TPLOGRADOURO,\n" +
            "          ENDERECO.CAD_END_NM_LOGRADOURO,\n" +
            "          ENDERECO.CAD_END_DS_NUMERO,\n" +
            "          ENDERECO.CAD_END_DS_COMPLEMENTO,*/\n" +
            "        --  FNC_ATS_EXAMES_LAUDO(ARP.ATS_APR_NR_SEQ_LOTE,\n" +
            "         --                      ARP.ATS_ATE_CD_INTLIB,\n" +
            "         --                      ENDERECO.CAD_END_ID_ENDERECO,\n" +
            "         --                      ARP.ATS_ARP_DT_RESULTADO)\n" +
            "  ORDER BY ARP.ATS_APR_NR_SEQ_DIGITACAO";

                dtb = remoto.executeQuery(sqlString);
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
                        "   AND END.AUX_TTE_CD_TP_TEL_END = 12 " +
                string.Format(" AND   UNI.CAD_UNI_ID_UNIDADE  = {0} ", dtb.Rows[0]["CAD_UNI_ID_UNIDADE_E"].ToString())
                    //" AND   PEE.CAD_PES_ID_PESSOA   = UNI.CAD_PES_ID_PESSOA "
                              ;
                dtbEnderecoEntrega = remoto.executeQuery(sqlString);
                sqlString = string.Empty;
                #endregion
           
           // dtb.Rows[0]["ORIGEM"] = AtendimentoSADT.Origem.ToString();

                return MontarEntity(dtb, dtbEnderecoEntrega);
        }

        private ProtocoloSADTEntity MontarEntity(DataTable dtb, DataTable dtbEnderecoEntrega)
        {
            ProtocoloSADTEntity atendimentoSADTEntity = new ProtocoloSADTEntity();
            atendimentoSADTEntity.Lote = dtb.Rows[0]["ATS_APR_NR_SEQ_LOTE"].ToString();
            atendimentoSADTEntity.SequenciaDigitacao = dtb.Rows[0]["ATS_APR_NR_SEQ_DIGITACAO"].ToString();

          //  atendimentoSADTEntity.Origem = dtb.Rows[0]["ORIGEM"].ToString();
            atendimentoSADTEntity.Atendimento = dtb.Rows[0]["ATS_ATE_CD_INTLIB"].ToString();
            atendimentoSADTEntity.TipoIntLib = dtb.Rows[0]["ATS_ATE_IN_INTLIB"].ToString();
            atendimentoSADTEntity.CodigoExame = dtb.Rows[0]["ATS_ATE_ID"].ToString();
            atendimentoSADTEntity.CodigoProduto = dtb.Rows[0]["CAD_PRD_ID"].ToString();
            atendimentoSADTEntity.CodigoTabelaMedica = dtb.Rows[0]["TIS_MED_CD_TABELAMEDICA"].ToString();
            
          //  atendimentoSADTEntity.Padrao = dtb.Rows[0]["CODPAD"].ToString();
            
            atendimentoSADTEntity.CodigoConvenio = dtb.Rows[0]["CAD_CNV_CD_HAC_PRESTADOR"].ToString();
            atendimentoSADTEntity.Convenio = dtb.Rows[0]["CAD_CNV_NM_FANTASIA"].ToString();
            atendimentoSADTEntity.TipoPlano = dtb.Rows[0]["CAD_TPE_CD_CODIGO"].ToString();
          //  atendimentoSADTEntity.TipoAtendimento = dtb.Rows[0]["TIS_TAT_DS_TPATENDIMENTO"].ToString();
            atendimentoSADTEntity.CodigoPlano = dtb.Rows[0]["CAD_PLA_CD_PLANO_HAC"].ToString();
            atendimentoSADTEntity.Plano = dtb.Rows[0]["CAD_PLA_NM_NOME_PLANO"].ToString();
            atendimentoSADTEntity.Unidade = dtb.Rows[0]["CAD_UNI_DS_UNIDADE"].ToString();
          //  atendimentoSADTEntity.IDLocal = dtb.Rows[0]["CAD_LAT_ID_LOCAL_ATENDIMENTO"].ToString();
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
            

            for (int iCont = 0; iCont < dtb.Rows.Count; iCont++)
            {
                atendimentoSADTEntity.DataAtendimento = dtb.Rows[0]["ATD_ATE_DT_ATENDIMENTO"].ToString() + ";";
                atendimentoSADTEntity.HoraAtendimento = dtb.Rows[0]["ATD_ATE_HR_ATENDIMENTO"].ToString() + ";";

                atendimentoSADTEntity.CodigoProduto += dtb.Rows[iCont]["CAD_PRD_CD_CODIGO"].ToString() + ";";
                atendimentoSADTEntity.DescricaoProduto += dtb.Rows[iCont]["CAD_PRD_DS_DESCRICAO"].ToString() + ";";
                atendimentoSADTEntity.DataResultado += dtb.Rows[iCont]["ATS_ARP_DT_RESULTADO"].ToString() + ";";
            }

            if (atendimentoSADTEntity.DataAtendimento.Trim().Length > 0)
                atendimentoSADTEntity.DataAtendimento = atendimentoSADTEntity.DataAtendimento.Remove(atendimentoSADTEntity.DataAtendimento.LastIndexOf(";"), 1);
            if (atendimentoSADTEntity.HoraAtendimento.Trim().Length > 0)
                atendimentoSADTEntity.HoraAtendimento = atendimentoSADTEntity.HoraAtendimento.Remove(atendimentoSADTEntity.HoraAtendimento.LastIndexOf(";"), 1);
            if (atendimentoSADTEntity.CodigoProduto.Trim().Length > 0)
                atendimentoSADTEntity.CodigoProduto = atendimentoSADTEntity.CodigoProduto.Remove(atendimentoSADTEntity.CodigoProduto.LastIndexOf(";"), 1);
            if (atendimentoSADTEntity.DescricaoProduto.Trim().Length > 0)
                atendimentoSADTEntity.DescricaoProduto = atendimentoSADTEntity.DescricaoProduto.Remove(atendimentoSADTEntity.DescricaoProduto.LastIndexOf(";"), 1);
            if (atendimentoSADTEntity.DataResultado.Trim().Length > 0)
                atendimentoSADTEntity.DataResultado = atendimentoSADTEntity.DataResultado.Remove(atendimentoSADTEntity.DataResultado.LastIndexOf(";"), 1);
            

            return atendimentoSADTEntity;
        }
    }
}
