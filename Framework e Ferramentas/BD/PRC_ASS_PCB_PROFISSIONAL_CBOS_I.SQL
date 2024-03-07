  --PRC_ASS_PCB_PROF_CBOS_I
  create or replace procedure PRC_ASS_PCB_PROF_CBOS_I
  (
     pTIS_CBO_CD_CBOS IN TB_ASS_PCB_PROFISSIONAL_CBOS.TIS_CBO_CD_CBOS%type,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PCB_PROFISSIONAL_CBOS.CAD_PRO_ID_PROFISSIONAL%type, 
     pASS_PCB_DS_OBS IN TB_ASS_PCB_PROFISSIONAL_CBOS.ASS_PCB_DS_OBS%type default NULL,
     pASS_PCB_FL_STATUS IN TB_ASS_PCB_PROFISSIONAL_CBOS.ASS_PCB_FL_STATUS%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_PCB_PROFISSIONAL_CBOS.SEG_USU_ID_USUARIO%type
     	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PCB_PROF_CBOS_I
  * 
  *    Data Criacao: 	29/06/2007           Por: Guilherme Holdack
  *    Data Alteracao:	                     Por:                 
  *
  *    Funcao: Inserção de registros na tabela TB_ASS_PCB_PROFISSIONAL_CBOS
  *
  *    Data Alteraçao: 19/11/2007            Por: Guilherme
  *    Alteração: Inclusão de upper em parametros
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_ASS_PCB_PROFISSIONAL_CBOS
    (
       ASS_PCB_DS_OBS,
       ASS_PCB_FL_STATUS,
       TIS_CBO_CD_CBOS,
       CAD_PRO_ID_PROFISSIONAL,
       SEG_USU_ID_USUARIO,
       ASS_PCB_DT_ULTIMA_ATUALIZACAO
    )
    VALUES
    (
	     Upper(pASS_PCB_DS_OBS),
	     pASS_PCB_FL_STATUS,
	     pTIS_CBO_CD_CBOS,
	     pCAD_PRO_ID_PROFISSIONAL,
	     pSEG_USU_ID_USUARIO,
	     SYSDATE
    );
  end PRC_ASS_PCB_PROF_CBOS_I;