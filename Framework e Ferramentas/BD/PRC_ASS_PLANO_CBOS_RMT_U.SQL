  --PRC_ASS_PLANO_CBOS_RMT_U
  create or replace procedure PRC_ASS_PLANO_CBOS_RMT_U
  (
     pCAD_PLA_ID_PLANO IN TB_ASS_PLC_PLANO_CBOS.CAD_PLA_ID_PLANO%type,
     pTIS_CBO_CD_CBOS IN TB_ASS_PLC_PLANO_CBOS.TIS_CBO_CD_CBOS%type,
     pASS_PLC_FL_STATUS IN TB_ASS_PLC_PLANO_CBOS.ASS_PLC_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_PLC_PLANO_CBOS.SEG_USU_ID_USUARIO%type,
     pASS_PLC_DT_ULTIMA_ATUALIZACAO IN TB_ASS_PLC_PLANO_CBOS.ASS_PLC_DT_ULTIMA_ATUALIZACAO%type default NULL,
     pASS_PLC_FL_ENCAMINHA_OK IN TB_ASS_PLC_PLANO_CBOS.ASS_PLC_FL_ENCAMINHA_OK%type default NULL,
     pASS_PLC_FL_EXIGE_SENHA_OK IN TB_ASS_PLC_PLANO_CBOS.ASS_PLC_FL_EXIGE_SENHA_OK%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PLANO_CBOS_RMT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_ASS_PLC_PLANO_CBOS
    SET	   
        ASS_PLC_FL_STATUS = pASS_PLC_FL_STATUS,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ASS_PLC_DT_ULTIMA_ATUALIZACAO = pASS_PLC_DT_ULTIMA_ATUALIZACAO,
        ASS_PLC_FL_ENCAMINHA_OK = pASS_PLC_FL_ENCAMINHA_OK,
        ASS_PLC_FL_EXIGE_SENHA_OK = pASS_PLC_FL_EXIGE_SENHA_OK 
    WHERE
        CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
    AND TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS;	
  end PRC_ASS_PLANO_CBOS_RMT_U;

