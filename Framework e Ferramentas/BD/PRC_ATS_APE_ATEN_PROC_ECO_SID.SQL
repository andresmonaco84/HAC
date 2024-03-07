
  --PRC_ATS_APE_ATEN_PROCED_ECOCAR_SID
  create or replace procedure PRC_ATS_APE_ATEN_PROC_ECO_SID
  (
     pATS_APE_ID IN TB_ATS_APE_ATEN_PROCED_ECOCAR.ATS_APE_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATS_APE_ATEN_PROCED_ECOCAR_SID
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	27/03/2010  Por: Pedro
  *    Altera��o: pTIS_MED_CD_TABELAMEDICA
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       ATS_ATE_CD_INTLIB,
       ATS_ATE_IN_INTLIB,
       AUX_EPP_CDESPECPROC,
       ATS_ATE_ID,
       CAD_PRD_ID,
       ATS_UME_CD_ECOCAR,
       ATS_UME_TP_UNID_MEDIDA,
       ATS_UME_CD_UNID_MEDIDA,
       ATS_APE_FL_STATUS,
       ATS_APE_QT_RESULTADO,
       ATS_APE_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ATS_APE_ID,
       TIS_MED_CD_TABELAMEDICA
    FROM TB_ATS_APE_ATEN_PROCED_ECOCAR
    WHERE
        ATS_APE_ID = pATS_APE_ID;          
    io_cursor := v_cursor;
  end PRC_ATS_APE_ATEN_PROC_ECO_SID;
/
