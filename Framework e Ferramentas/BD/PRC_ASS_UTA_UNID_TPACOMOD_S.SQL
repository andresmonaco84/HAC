create or replace procedure PRC_ASS_UTA_UNID_TPACOMOD_S
  (
     pASS_UTA_ID_UNID_TPACOMOD IN TB_ASS_UTA_UNID_TPACOMOD.ASS_UTA_ID_UNID_TPACOMOD%TYPE DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_UTA_UNID_TPACOMOD.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pASS_UTA_FL_ATIVO_OK IN TB_ASS_UTA_UNID_TPACOMOD.ASS_UTA_FL_ATIVO_OK%type DEFAULT NULL,
     -- pDT_FINAL_VIGENCIA IN DATE DEFAULT NULL, 
     pASS_CUT_ID IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_UTA_UNID_TPACOMOD_S
  * 
  *    Data Criacao: 	21/06/2007   Por: Ricardo Costa
  *    Data Alteracao:	           Por: 
  *
  *    Funcao: lista todas as acomodações associadas a uma unidade e ATIVAS =  S
  *
  *******************************************************************/
  
  /********************************************************************
  * 
  *    Data Alteracao: 26/06/2007   Por: Guilherme/Fabíola
  *
  *******************************************************************/
  
  v_cursor PKG_CURSOR.t_cursor;
  begin
   IF ( pASS_CUT_ID IS NULL ) THEN
      OPEN v_cursor FOR
       SELECT	
          ASS_UTA_ID_UNID_TPACOMOD,
          TIS_TAC_CD_TIPO_ACOMODACAO,
          ASS_UTA_FL_ATIVO_OK,
          CAD_UNI_ID_UNIDADE
       FROM TB_ASS_UTA_UNID_TPACOMOD
       WHERE
           (pCAD_UNI_ID_UNIDADE is null OR CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
       AND
           (pASS_UTA_FL_ATIVO_OK IS NULL OR ASS_UTA_FL_ATIVO_OK = pASS_UTA_FL_ATIVO_OK )
       AND 
           (pASS_UTA_ID_UNID_TPACOMOD IS NULL OR ASS_UTA_ID_UNID_TPACOMOD = pASS_UTA_ID_UNID_TPACOMOD);
    ELSE
     OPEN v_cursor FOR
     SELECT	
          UNI.ASS_UTA_ID_UNID_TPACOMOD,
          UNI.TIS_TAC_CD_TIPO_ACOMODACAO,
          UNI.ASS_UTA_FL_ATIVO_OK,
          UNI.CAD_UNI_ID_UNIDADE
		  
       FROM TB_ASS_UTA_UNID_TPACOMOD UNI,
            TB_ASS_CUT_CONV_UNI_TPACOMOD CON
       WHERE
           (pCAD_UNI_ID_UNIDADE is null OR UNI.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
       AND
           (pASS_UTA_FL_ATIVO_OK  is NULL OR UNI.ASS_UTA_FL_ATIVO_OK = pASS_UTA_FL_ATIVO_OK  )
       AND 
           (pASS_UTA_ID_UNID_TPACOMOD IS NULL OR UNI.ASS_UTA_ID_UNID_TPACOMOD = pASS_UTA_ID_UNID_TPACOMOD)
       AND  CON.ASS_UTA_ID_UNID_TPACOMOD = UNI.ASS_UTA_ID_UNID_TPACOMOD
            AND (CON.ASS_CUT_DT_FIM_VIGENCIA>=SYSDATE OR CON.ASS_CUT_DT_FIM_VIGENCIA is NULL			 )
			 AND (CON.ASS_CUT_ID IS NULL  OR CON.ASS_CUT_ID = pASS_CUT_ID );
  END IF;
     io_cursor := v_cursor;    
  end PRC_ASS_UTA_UNID_TPACOMOD_S;