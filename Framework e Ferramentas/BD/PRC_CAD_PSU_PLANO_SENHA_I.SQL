  --PRC_CAD_PSU_PLANO_SENHA_UTIL_I                              
  create or replace procedure PRC_CAD_PSU_PLANO_SENHA_I
  (
     pNewIdt OUT integer,
     pCAD_PSU_ID IN TB_CAD_PSU_PLANO_SENHA_UTIL.CAD_PSU_ID%type default NULL,
     pCAD_PSU_NR_SENHA_UTILIZADA IN TB_CAD_PSU_PLANO_SENHA_UTIL.CAD_PSU_NR_SENHA_UTILIZADA%type default NULL,
     pCAD_PSU_FL_STATUS IN TB_CAD_PSU_PLANO_SENHA_UTIL.CAD_PSU_FL_STATUS%type,
     pCAD_PSU_DT_ULTIMA_ATUALIZACAO IN TB_CAD_PSU_PLANO_SENHA_UTIL.CAD_PSU_DT_ULTIMA_ATUALIZACAO%type,
     pCAD_PLA_CD_PLANO IN TB_CAD_PSU_PLANO_SENHA_UTIL.CAD_PLA_CD_PLANO%type default NULL,
     pAGE_AGD_ID IN TB_CAD_PSU_PLANO_SENHA_UTIL.AGE_AGD_ID%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_PSU_PLANO_SENHA_UTIL.SEG_USU_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PSU_PLANO_SENHA_UTIL_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_CAD_PSU_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_CAD_PSU_PLANO_SENHA_UTIL
    (
       CAD_PSU_ID,
       CAD_PSU_NR_SENHA_UTILIZADA,
       CAD_PSU_FL_STATUS,
       CAD_PSU_DT_ULTIMA_ATUALIZACAO,
       CAD_PLA_CD_PLANO,
       AGE_AGD_ID,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
	     lIdtRetorno,
       pCAD_PSU_NR_SENHA_UTILIZADA,                  
	     pCAD_PSU_FL_STATUS,
	     pCAD_PSU_DT_ULTIMA_ATUALIZACAO,
	     pCAD_PLA_CD_PLANO,
	     pAGE_AGD_ID,
	     pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_CAD_PSU_PLANO_SENHA_I;



 
/
