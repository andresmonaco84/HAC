create or replace procedure PRC_CAD_TEL_TELEFONE_U
  (
     pCAD_TEL_ID_TELEFONE IN TB_CAD_TEL_TELEFONE.CAD_TEL_ID_TELEFONE%type,
     pCAD_TEL_NR_NUM_TEL IN TB_CAD_TEL_TELEFONE.CAD_TEL_NR_NUM_TEL%type,
     pCAD_TEL_NR_RAMAL_TEL IN TB_CAD_TEL_TELEFONE.CAD_TEL_NR_RAMAL_TEL%type default NULL,
     pCAD_TEL_NM_CONTATO IN TB_CAD_TEL_TELEFONE.CAD_TEL_NM_CONTATO%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_TEL_TELEFONE.SEG_USU_ID_USUARIO%type,
     pAUX_TTE_CD_TP_TEL_END IN TB_AUX_TTE_TP_TEL_ENDERECO.AUX_TTE_CD_TP_TEL_END% type,
     pCAD_PES_ID_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%TYPE
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TEL_TELEFONE_U
  *
  *    Data Alteracao: 18/2/2010  Por: PEDRO
  *    Alteracao: inclusao do pCAD_PES_ID_PESSOA
  *
  *    Funcao: Altera dados do cadastro de telefone
  *
  *******************************************************************/
  begin
    UPDATE TB_CAD_TEL_TELEFONE
    SET
        CAD_TEL_NR_NUM_TEL = pCAD_TEL_NR_NUM_TEL,
        CAD_TEL_NR_RAMAL_TEL = pCAD_TEL_NR_RAMAL_TEL,
        CAD_TEL_NM_CONTATO = UPPER(pCAD_TEL_NM_CONTATO),
        CAD_TEL_DT_ULTIMA_ATUALIZACAO = sysdate,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        AUX_TTE_CD_TP_TEL_END = pAUX_TTE_CD_TP_TEL_END,
        CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA

    WHERE
        CAD_TEL_ID_TELEFONE = pCAD_TEL_ID_TELEFONE;
  end PRC_CAD_TEL_TELEFONE_U;
