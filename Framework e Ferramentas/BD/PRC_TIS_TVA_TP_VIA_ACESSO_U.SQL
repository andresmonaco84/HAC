create or replace procedure PRC_TIS_TVA_TP_VIA_ACESSO_U
  (
     pTIS_TVA_CD_VIAACESSO IN TB_TIS_TVA_TP_VIA_ACESSO.TIS_TVA_CD_VIAACESSO%type,
     pTIS_TVA_DS_VIAACESSO IN TB_TIS_TVA_TP_VIA_ACESSO.TIS_TVA_DS_VIAACESSO%type,
  pTIS_TVA_FL_STATUS    IN TB_TIS_TVA_TP_VIA_ACESSO.TIS_TVA_FL_STATUS%type,
     pTIS_TVA_CD_VIAACESSO_V3 IN TB_TIS_TVA_TP_VIA_ACESSO.TIS_TVA_CD_VIAACESSO_V3%type,
     
     pSEG_USU_ID_USUARIO_CRIACAO IN TB_TIS_TVA_TP_VIA_ACESSO.SEG_USU_ID_USUARIO_CRIACAO%TYPE DEFAULT NULL,
     pTIS_UTD_DT_ULT_ATUALIZACAO IN TB_TIS_TVA_TP_VIA_ACESSO.TIS_TVA_DT_ULT_ATUALIZACAO%TYPE DEFAULT NULL,
     pSEG_USU_ID_USU_ULT_ATUALIZ IN TB_TIS_TVA_TP_VIA_ACESSO.SEG_USU_ID_USU_ULT_ATUALIZ%TYPE DEFAULT NULL
 
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TVA_TP_VIA_ACESSO_U
  *
  *    Data Criacao:  11/04/2007   Por: Andrea Cazuca
  *    Data Alteracao: 28/05/2007   Por: Silmara
  *    Alterac?o:Foi alterado os parametros para gravar em maiusculo
  *    Funcao: Altera Tipo de Via de Acesso
  *
  *    Data Alterac?o:  21/03/2014  Por: Andrea Cazuca
  *    Alterac?o:  Incluido o campo TIS_TVA_CD_VIAACESSO_V3
  *
  *******************************************************************/
  begin
    UPDATE TB_TIS_TVA_TP_VIA_ACESSO
    SET
        TIS_TVA_DS_VIAACESSO = UPPER(pTIS_TVA_DS_VIAACESSO),
        TIS_TVA_FL_STATUS = pTIS_TVA_FL_STATUS,
        TIS_TVA_CD_VIAACESSO_V3 = pTIS_TVA_CD_VIAACESSO_V3,
        
          TIS_TVA_DT_ULT_ATUALIZACAO = SYSDATE,
       SEG_USU_ID_USU_ULT_ATUALIZ = pSEG_USU_ID_USU_ULT_ATUALIZ
       
    WHERE
        TIS_TVA_CD_VIAACESSO = UPPER(pTIS_TVA_CD_VIAACESSO);
  end PRC_TIS_TVA_TP_VIA_ACESSO_U;

 