CREATE OR REPLACE PROCEDURE PRC_ATS_APE_ATEN_S_VALCALC
(
     pATS_ATE_CD_INTLIB IN TB_ATS_APE_ATEN_PROCED_ECOCAR.ATS_ATE_CD_INTLIB%type,
     pATS_ATE_IN_INTLIB IN TB_ATS_APE_ATEN_PROCED_ECOCAR.ATS_ATE_IN_INTLIB%type,
     pAUX_EPP_CDESPECPROC IN TB_ATS_APE_ATEN_PROCED_ECOCAR.AUX_EPP_CDESPECPROC%type,
     pATS_ATE_ID IN TB_ATS_APE_ATEN_PROCED_ECOCAR.ATS_ATE_ID%type,
     pCAD_PRD_ID IN TB_ATS_APE_ATEN_PROCED_ECOCAR.CAD_PRD_ID%type,
     pATS_UME_CD_ECOCARDIO IN TB_ATS_UME_UNI_MEDIDA_ECOCAR.ATS_UME_CD_ECOCARDIO%TYPE,
     pTIS_MED_CD_TABELAMEDICA IN TB_ATS_APS_ATEN_PROC_SEGMENTO.TIS_MED_CD_TABELAMEDICA%type	,
     io_cursor OUT PKG_CURSOR.t_cursor
)
IS
 /********************************************************************
  *    Procedure: PRC_ATS_APE_ATEN_S_VALCALC
  * 
  *    Data Criacao: 			   Por:
  *    Data Alteracao:	27/03/2010  Por: Pedro
  *    Altera��o: pTIS_MED_CD_TABELAMEDICA
  *
  *    Funcao:
  *
  *******************************************************************/  
    v_cursor PKG_CURSOR.t_cursor;
    CD_MEDIDA VARCHAR2(5);
    pPESO NUMBER;
BEGIN

  SELECT ATS_ATE_QT_PESO INTO pPESO
  FROM   TB_ATS_ATE_ATENDIMENTO_SADT ATE
  WHERE ATE.ATS_ATE_CD_INTLIB = pATS_ATE_CD_INTLIB
     AND  ATE.ATS_ATE_IN_INTLIB = pATS_ATE_IN_INTLIB
    AND  ATE.ATS_ATE_ID = pATS_ATE_ID
   AND  ATE.CAD_PRD_ID = pCAD_PRD_ID
   AND  ATE.AUX_EPP_CD_ESPECPROC = pAUX_EPP_CDESPECPROC
   AND  ATE.TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA;


    SELECT ATS_UME_CD_UNID_MEDIDA INTO CD_MEDIDA
    FROM TB_ATS_UME_UNI_MEDIDA_ECOCAR
    WHERE ATS_UME_CD_ECOCARDIO = pATS_UME_CD_ECOCARDIO
    AND   pPESO BETWEEN ATS_UME_QT_UNID_MEDIDA_INI AND ATS_UME_QT_UNID_MEDIDA_FIM
    AND   ATS_UME_TP_UNID_MEDIDA = 'PESO';

  OPEN v_cursor FOR
   SELECT UME.ATS_UME_QT_UNID_MEDIDA_ECO_INI, UME.ATS_UME_QT_UNID_MEDIDA_ECO_FIM
   FROM TB_ATS_UME_UNI_MEDIDA_ECOCAR UME
   WHERE
       UME.ATS_UME_TP_UNID_MEDIDA = 'PESO'
   AND UME.ATS_UME_CD_ECOCARDIO = pATS_UME_CD_ECOCARDIO
   AND UME.ATS_UME_CD_UNID_MEDIDA = CD_MEDIDA;

 io_cursor := v_cursor;

END PRC_ATS_APE_ATEN_S_VALCALC;
/
