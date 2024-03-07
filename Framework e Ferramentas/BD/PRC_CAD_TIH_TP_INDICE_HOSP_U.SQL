create or replace procedure PRC_CAD_TIH_TP_INDICE_HOSP_U
  (
     pCAD_TIH_TP_INDICE_HOSP IN TB_CAD_TIH_TP_INDICE_HOSP.CAD_TIH_TP_INDICE_HOSP%type,
     pCAD_TIH_DS_INDICE_HOSP IN TB_CAD_TIH_TP_INDICE_HOSP.CAD_TIH_DS_INDICE_HOSP%type,
     pCAD_TIH_FL_STATUS IN TB_CAD_TIH_TP_INDICE_HOSP.CAD_TIH_FL_STATUS%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_TIH_TP_INDICE_HOSP.SEG_USU_ID_USUARIO%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TIH_TP_INDICE_HOSP_U
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_TIH_TP_INDICE_HOSP
    SET     
        CAD_TIH_DS_INDICE_HOSP = pCAD_TIH_DS_INDICE_HOSP,
        CAD_TIH_FL_STATUS = pCAD_TIH_FL_STATUS,
        CAD_TIH_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
    WHERE
        CAD_TIH_TP_INDICE_HOSP = pCAD_TIH_TP_INDICE_HOSP;  
  end PRC_CAD_TIH_TP_INDICE_HOSP_U;
