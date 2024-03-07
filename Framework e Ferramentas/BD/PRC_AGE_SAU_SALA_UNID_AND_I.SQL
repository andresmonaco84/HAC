create or replace procedure PRC_AGE_SAU_SALA_UNID_AND_I
  (
     pNewIdt OUT integer,
     pAGE_SAU_CD_ANDAR IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_CD_ANDAR%type,
     pAGE_SAU_NR_SALA IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_NR_SALA%type default NULL,
     pCAD_UNI_ID_UNIDADE IN TB_AGE_SAU_SALA_UNID_AND.CAD_UNI_ID_UNIDADE%type,
     pAGE_SAU_FL_STATUS IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_FL_STATUS%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_AGE_SAU_SALA_UNID_AND.SEG_USU_ID_USUARIO%type default NULL,
     pAGE_SAU_DS_SALA IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_DS_SALA%type default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_SAU_SALA_UNID_AND_I
  *
  *    Data Criacao:   05/07/2007            Por: Guilherme Holdack
  *    Data Alteracao: 25/04/2008           Por: Silmara
  *    Alteracao: inclusao de campo
  *    Funcao: inserção de registros da tabela TB_AGE_SAU_SALA_UNID_AND
  *
  *******************************************************************/
  lIdtRetorno integer;
   begin
   SELECT SEQ_AGE_SAU_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_AGE_SAU_SALA_UNID_AND
    (
       AGE_SAU_ID,
       AGE_SAU_CD_ANDAR,
       AGE_SAU_NR_SALA,
       CAD_UNI_ID_UNIDADE,
       AGE_SAU_FL_STATUS,
       SEG_USU_ID_USUARIO,
       AGE_SAU_DT_ULTIMA_ATUALIZACAO,
       AGE_SAU_DS_SALA
    )
    VALUES
    (
       lIdtRetorno,
       pAGE_SAU_CD_ANDAR,
       pAGE_SAU_NR_SALA,
       pCAD_UNI_ID_UNIDADE,
       pAGE_SAU_FL_STATUS,
       pSEG_USU_ID_USUARIO,
       SYSDATE,
       pAGE_SAU_DS_SALA
    );
  pNewIdt := lIdtRetorno;
  end PRC_AGE_SAU_SALA_UNID_AND_I;
