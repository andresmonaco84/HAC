  --PRC_ASS_PCB_PROF_CBOS_U
  create or replace procedure PRC_ASS_PCB_PROF_CBOS_U
  (
     pTIS_CBO_CD_CBOS IN TB_ASS_PCB_PROFISSIONAL_CBOS.TIS_CBO_CD_CBOS%type,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PCB_PROFISSIONAL_CBOS.CAD_PRO_ID_PROFISSIONAL%type, 
     pASS_PCB_DS_OBS IN TB_ASS_PCB_PROFISSIONAL_CBOS.ASS_PCB_DS_OBS%type default NULL,
     pASS_PCB_FL_STATUS IN TB_ASS_PCB_PROFISSIONAL_CBOS.ASS_PCB_FL_STATUS%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_PCB_PROFISSIONAL_CBOS.SEG_USU_ID_USUARIO%type
     
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PCB_PROF_CBOS_U
  * 
  *    Data Criacao: 	29/06/2007           Por: Guilherme Holdack
  *    Data Alteracao:	                    Por:                 
  *
  *    Funcao: Atualização de registros na tabela TB_ASS_PCB_PROFISSIONAL_CBOS
  *
  *    Data Alteração: 19/11/2007          Por: Guilherme Holdack
  *    Alteração: Inclusão de upper em campos
  *******************************************************************/  
  begin
    UPDATE TB_ASS_PCB_PROFISSIONAL_CBOS
    SET	   
        ASS_PCB_DS_OBS = Upper(pASS_PCB_DS_OBS),
        ASS_PCB_FL_STATUS = pASS_PCB_FL_STATUS,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ASS_PCB_DT_ULTIMA_ATUALIZACAO = SYSDATE 
    WHERE
        TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS
    AND CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL;
            
  end PRC_ASS_PCB_PROF_CBOS_U;