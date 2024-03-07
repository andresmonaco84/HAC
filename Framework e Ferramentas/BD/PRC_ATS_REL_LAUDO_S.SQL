create or replace procedure PRC_ATS_REL_LAUDO_S
  (
     pIDT  IN TB_ATS_REL_LAUDO.IDT%type DEFAULT NULL,
     io_cursor  OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_REL_LAUDO_S
  *
  *    Data Criacao:  data da  criação   Por: Nome do Analista
  *    Data Alteracao: 22/04/2009  Por: Pedro
  *    Alteracao: add pSEG_USU_ID_USUARIO, pATS_ATE_ID, pCAD_PLA_ID_PLANO
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       REL.AUX_EPP_DS_DESCRICAO Especialidade,
       REL.CAD_PES_NM_PESSOA Unidade,
       REL.ATS_ATE_CD_INTLIB Identificacao,
       REL.CAD_PAC_NR_PRONTUARIO RG,
       REL.CAD_PES_NM_PESSOA1 Nome,
       REL.CAD_CNV_CD_HAC_PRESTADOR,
       REL.CAD_PES_NM_PESSOA2 Nome_convenio,
       REL.CAD_END_NM_LOGRADOURO End_Empresa,
       REL.CAD_END_DS_NUMERO Num_Empresa,
       REL.AUX_MUN_NM_MUNICIPIO,
       REL.CAD_TEL_NR_NUM_TEL,
       REL.ATS_APL_DT_LAUDO Data_Laudo,
       REL.CAD_PRD_ID,
       REL.CAD_PRD_DS_DESCRICAO Produto,
       REL.ATS_APL_TEXTO_LAUDO Laudo,
       REL.IDADE Idade,
       REL.IDT,
       REL.CAD_PRO_NR_CONSELHO NumeroConselho,
       REL.CAD_PES_NM_PESSOA3 Medico,
       REL.SEG_USU_DS_NOME,
       REL.SEG_USU_ID_USUARIO,
       REL.ATS_ATE_ID,
       REL.CAD_PLA_ID_PLANO,
       PLA.CAD_PLA_CD_PLANO_HAC,
       USU.SEG_USU_CD_MATRICULA,
       PLA.CAD_PLA_NM_NOME_PLANO

    FROM TB_ATS_REL_LAUDO REL
    inner join TB_CAD_PLA_PLANO PLA
    ON PLA.CAD_PLA_ID_PLANO = REL.CAD_PLA_ID_PLANO
    inner join tb_seg_usu_usuario USU
    ON USU.SEG_USU_ID_USUARIO = REL.SEG_USU_ID_USUARIO
    inner join tb_cad_cnv_convenio cnv
    ON CNV.CAD_CNV_CD_HAC_PRESTADOR = REL.CAD_CNV_CD_HAC_PRESTADOR
    WHERE
       (pIDT is null OR IDT = pIDT);
    io_cursor := v_cursor;
  end PRC_ATS_REL_LAUDO_S;
/