  --PRC_ASS_PLANO_CBOS_RMT_I
  create or replace procedure PRC_ASS_PLANO_CBOS_RMT_I
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
  *    Procedure: PRC_ASS_PLANO_CBOS_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_ASS_PLC_PLANO_CBOS
    (
       CAD_PLA_ID_PLANO,
       TIS_CBO_CD_CBOS,
       ASS_PLC_FL_STATUS,
       SEG_USU_ID_USUARIO,
       ASS_PLC_DT_ULTIMA_ATUALIZACAO,
       ASS_PLC_FL_ENCAMINHA_OK,
       ASS_PLC_FL_EXIGE_SENHA_OK
    )
    VALUES
    (
	     pCAD_PLA_ID_PLANO,
	     pTIS_CBO_CD_CBOS,
	     pASS_PLC_FL_STATUS,
	     pSEG_USU_ID_USUARIO,
	     pASS_PLC_DT_ULTIMA_ATUALIZACAO,
	     pASS_PLC_FL_ENCAMINHA_OK,
	     pASS_PLC_FL_EXIGE_SENHA_OK
    );
	
  end PRC_ASS_PLANO_CBOS_RMT_I;

