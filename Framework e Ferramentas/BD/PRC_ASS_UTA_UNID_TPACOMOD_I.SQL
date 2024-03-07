create or replace procedure PRC_ASS_UTA_UNID_TPACOMOD_I
  (
     pNewIdt OUT integer,
     pASS_UTA_ID_UNID_TPACOMOD IN TB_ASS_UTA_UNID_TPACOMOD.ASS_UTA_ID_UNID_TPACOMOD%type,
     pTIS_TAC_CD_TIPO_ACOMODACAO IN TB_ASS_UTA_UNID_TPACOMOD.TIS_TAC_CD_TIPO_ACOMODACAO%type,
     pASS_UTA_FL_ATIVO_OK IN TB_ASS_UTA_UNID_TPACOMOD.ASS_UTA_FL_ATIVO_OK%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_UTA_UNID_TPACOMOD.CAD_UNI_ID_UNIDADE%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_UTA_UNID_TPACOMOD_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
      lIdtRetorno integer;	  
  begin
  
    SELECT SEQ_ASS_UTA_28.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ASS_UTA_UNID_TPACOMOD
    (
       ASS_UTA_ID_UNID_TPACOMOD,
       TIS_TAC_CD_TIPO_ACOMODACAO,
       ASS_UTA_FL_ATIVO_OK,
       CAD_UNI_ID_UNIDADE
    )
    VALUES
    (
	     lIdtRetorno,
	     pTIS_TAC_CD_TIPO_ACOMODACAO,
	     pASS_UTA_FL_ATIVO_OK,
	     pCAD_UNI_ID_UNIDADE
    );
       pNewIdt := lIdtRetorno;
	
  end PRC_ASS_UTA_UNID_TPACOMOD_I;
/
