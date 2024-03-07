
---fim


  --PRC_ASS_PPT_PESSOA_PRONTUARIO_I
  create or replace procedure PRC_ASS_PPT_PESSOA_PRONTUA_I
  (
     pNewIdt OUT integer,
     pASS_PPT_ID_PESSOA_PRONTUARIO IN TB_ASS_PPT_PESSOA_PRONTUARIO.ASS_PPT_ID_PESSOA_PRONTUARIO%type default NULL,
     pCAD_PES_ID_PESSOA IN TB_ASS_PPT_PESSOA_PRONTUARIO.CAD_PES_ID_PESSOA%type,
     pCAD_PAC_NR_PRONTUARIO IN TB_ASS_PPT_PESSOA_PRONTUARIO.CAD_PAC_NR_PRONTUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PPT_PESSOA_PRONTUA_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_ASS_PPT.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ASS_PPT_PESSOA_PRONTUARIO
    (
       ASS_PPT_ID_PESSOA_PRONTUARIO,
       CAD_PES_ID_PESSOA,
       CAD_PAC_NR_PRONTUARIO
    )
    VALUES
    (
      lIdtRetorno,
	     pCAD_PES_ID_PESSOA,
	     pCAD_PAC_NR_PRONTUARIO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_ASS_PPT_PESSOA_PRONTUA_I;

