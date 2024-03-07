  --PRC_CAD_PHS_PLA_HISTO_STATUS_U
  create or replace procedure PRC_CAD_PHS_PLA_HISTO_STATUS_U
  (
     pCAD_PHS_ID IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PHS_ID%type,
     pCAD_PLA_ID_PLANO IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PLA_ID_PLANO%type,
     pCAD_PHS_DT_INI_VIGENCIA IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PHS_DT_INI_VIGENCIA%type,
     pCAD_PHS_DT_FIM_VIGENCIA IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PHS_DT_FIM_VIGENCIA%type default NULL,
     pCAD_PHS_FL_STATUS IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PHS_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_PHS_PLA_HISTO_STATUS.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PHS_PLA_HISTO_STATUS_U
  * 
  *    Data Criacao: 10/08/2007   Por: Guilherme Holdack
  *    Data Alteracao:	           Por: 
  *
  *    Funcao: Atualizar registros na tabela TB_CAD_PHS_PLA_HISTO_STATUS
  *
  *******************************************************************/  
  begin
   
    UPDATE TB_CAD_PHS_PLA_HISTO_STATUS
    SET	   
        CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO,
        CAD_PHS_DT_INI_VIGENCIA = pCAD_PHS_DT_INI_VIGENCIA,
        CAD_PHS_DT_FIM_VIGENCIA = pCAD_PHS_DT_FIM_VIGENCIA,
        CAD_PHS_FL_STATUS = pCAD_PHS_FL_STATUS,
        CAD_PHS_DT_ULTIMA_ATUALIZACAO = sysdate,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
    WHERE
        (pCAD_PHS_ID is null OR CAD_PHS_ID = pCAD_PHS_ID)
    AND (pCAD_PLA_ID_PLANO is null OR CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
    AND  CAD_PHS_DT_FIM_VIGENCIA IS NULL;	
  end PRC_CAD_PHS_PLA_HISTO_STATUS_U;
/
