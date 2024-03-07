create or replace procedure PRC_ASS_CCP_CONV_CLIN_PROCED_I
  (
     pNewIdt OUT integer,
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CCP_CONV_CLINICA_PROCED.CAD_CNV_ID_CONVENIO%type,
     pAUX_EEP_CD_ESPECPROCED IN TB_ASS_CCP_CONV_CLINICA_PROCED.AUX_EEP_CD_ESPECPROCED%type,
     pAUX_GPC_CD_GRUPOPROCED IN TB_ASS_CCP_CONV_CLINICA_PROCED.AUX_GPC_CD_GRUPOPROCED%type default NULL,
     pCAD_PRD_CD_CODIGO IN TB_ASS_CCP_CONV_CLINICA_PROCED.CAD_PRD_CD_CODIGO%type default NULL,
     pCAD_CLC_ID IN TB_ASS_CCP_CONV_CLINICA_PROCED.CAD_CLC_ID%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CCP_CONV_CLINICA_PROCED.SEG_USU_ID_USUARIO%type,
     pASS_CCP_FL_STATUS IN TB_ASS_CCP_CONV_CLINICA_PROCED.ASS_CCP_FL_STATUS%type,
     pTIS_MED_CD_TABELAMEDICA IN TB_TIS_MED_TABELAMEDICA.TIS_MED_CD_TABELAMEDICA%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CCP_CONV_CLIN_PROCED_I
  *
  *    Data Criacao: 	25/01/2008   Por: Fabiola Lopes
  *    Data Alteracao:  04/02/2009  Por Andrea Cazuca
  *    Alteracao:  Incluido o campo TIS_MED_CD_TABELAMEDICA
  *
  *    Funcao: Incluir as associacoes de convenio x clinica x procedimento
  *
  *******************************************************************/

  lIdtRetorno integer;
  BEGIN

    SELECT SEQ_ASS_CCP_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_ASS_CCP_CONV_CLINICA_PROCED
    (
       ASS_CCP_ID,
       CAD_CNV_ID_CONVENIO,
       AUX_EEP_CD_ESPECPROCED,
       AUX_GPC_CD_GRUPOPROCED,
       CAD_PRD_CD_CODIGO,
       CAD_CLC_ID,
       ASS_CCP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ASS_CCP_FL_STATUS,
       TIS_MED_CD_TABELAMEDICA
    )
    VALUES
    (
	     lIdtRetorno,
	     pCAD_CNV_ID_CONVENIO,
	     pAUX_EEP_CD_ESPECPROCED,
	     pAUX_GPC_CD_GRUPOPROCED,
	     pCAD_PRD_CD_CODIGO,
	     pCAD_CLC_ID,
	     SYSDATE,
	     pSEG_USU_ID_USUARIO,
	     pASS_CCP_FL_STATUS,
       pTIS_MED_CD_TABELAMEDICA
    );
  pNewIdt := lIdtRetorno;
  end PRC_ASS_CCP_CONV_CLIN_PROCED_I;
/
