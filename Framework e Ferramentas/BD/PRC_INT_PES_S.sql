create or replace procedure PRC_INT_PES_S
  (
     pATD_ATE_ID IN tb_atd_ate_atendimento.atd_ate_id%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_PES_S
  *
  *    Data Criacao:   06/08/09   Por: Pedro
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: retorna os dados da pessoa da Internacao
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
    ATD.ATD_ATE_ID,
    PES_PAC.CAD_PES_NM_PESSOA,
    PES_PAC.CAD_PES_TP_SEXO,
    PES_PAC.CAD_PES_DT_NASCIMENTO,
    PES_PAC.CAD_PES_NR_RG,
    PAC.CAD_PAC_NR_PRONTUARIO,
    PAC.CAD_PAC_CD_CREDENCIAL,
    FNC_RETORNA_TEL_PAC(pes_pac.cad_pes_id_pessoa) CAD_TEL_NR_NUM_TEL,
    END.CAD_END_NM_LOGRADOURO,
    END.CAD_END_NM_BAIRRO,
    END.CAD_END_SG_UF,
    END.CAD_END_DS_NUMERO,
    END.CAD_END_DS_COMPLEMENTO,
    END.CAD_END_CD_CEP,
    END.AUX_MUN_CD_IBGE,
    MUN.AUX_MUN_NM_MUNICIPIO,
    PES_PAC.CAD_PES_NR_CNPJ_CPF
  
 FROM TB_ATD_ATE_ATENDIMENTO ATD
    JOIN TB_ASS_PAT_PACIEATEND PAT
    ON   PAT.ATD_ATE_ID = ATD.ATD_ATE_ID
    JOIN TB_ATD_AIC_ATE_INT_COMPL AIC
    ON AIC.ATD_ATE_ID = ATD.ATD_ATE_ID
    JOIN TB_CAD_PAC_PACIENTE PAC
    ON PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
    JOIN TB_CAD_PES_PESSOA PES_PAC
    ON PES_PAC.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
--    LEFT JOIN TB_ASS_PEE_PESSOA_ENDERECO PEE
--    ON PEE.CAD_PES_ID_PESSOA = .CAD_PES_ID_PESSOA
    LEFT JOIN TB_CAD_END_ENDERECO END
    ON END.CAD_PES_ID_PESSOA = PES_PAC.CAD_PES_ID_PESSOA
    LEFT JOIN TB_AUX_MUN_MUNICIPIO MUN
    ON MUN.AUX_MUN_CD_IBGE = END.AUX_MUN_CD_IBGE
    WHERE (ATD.ATD_ATE_ID = pATD_ATE_ID);
    io_cursor := v_cursor;
  end PRC_INT_PES_S;

