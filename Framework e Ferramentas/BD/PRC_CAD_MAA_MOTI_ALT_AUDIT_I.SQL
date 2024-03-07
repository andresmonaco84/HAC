  --PRC_CAD_MAA_MOTI_ALT_AUDIT_I
  create or replace procedure PRC_CAD_MAA_MOTI_ALT_AUDIT_I
  (
     pNewIdt OUT integer,
     pCAD_MAA_ID IN TB_CAD_MAA_MOTI_ALTERA_AUDIT.CAD_MAA_ID%type default NULL,
     pCAD_MAA_DS_DESCRICAO IN TB_CAD_MAA_MOTI_ALTERA_AUDIT.CAD_MAA_DS_DESCRICAO%type,
     pCAD_MAA_FL_STATUS IN TB_CAD_MAA_MOTI_ALTERA_AUDIT.CAD_MAA_FL_STATUS%type,
     pCAD_MAA_DT_ULTIMA_ATUALIZACAO IN TB_CAD_MAA_MOTI_ALTERA_AUDIT.CAD_MAA_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_MAA_MOTI_ALTERA_AUDIT.SEG_USU_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MAA_MOTI_ALT_AUDIT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_CAD_MAA_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_CAD_MAA_MOTI_ALTERA_AUDIT
    (
       CAD_MAA_ID,
       CAD_MAA_DS_DESCRICAO,
       CAD_MAA_FL_STATUS,
       CAD_MAA_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
      lIdtRetorno,
	     pCAD_MAA_DS_DESCRICAO,
	     pCAD_MAA_FL_STATUS,
	     pCAD_MAA_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_CAD_MAA_MOTI_ALT_AUDIT_I;