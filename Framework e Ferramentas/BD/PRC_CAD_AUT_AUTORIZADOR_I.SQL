create or replace procedure PRC_CAD_AUT_AUTORIZADOR_I
(
     pNewIdt OUT integer,
     pCAD_AUT_ID IN TB_CAD_AUT_AUTORIZADOR.CAD_AUT_ID%type default NULL,
     pCAD_AUT_DS_DESCRICAO IN TB_CAD_AUT_AUTORIZADOR.CAD_AUT_DS_DESCRICAO%type,
     pCAD_AUT_FL_STATUS IN TB_CAD_AUT_AUTORIZADOR.CAD_AUT_FL_STATUS%type,
     pSEG_USU_ID_USUARIO_CRIACAO IN TB_CAD_AUT_AUTORIZADOR.SEG_USU_ID_USUARIO_CRIACAO%type,
     pCAD_AUT_DT_CRIACAO IN TB_CAD_AUT_AUTORIZADOR.CAD_AUT_DT_CRIACAO%type,
     pSEG_USU_ID_USUARIO_ATUALIZA IN TB_CAD_AUT_AUTORIZADOR.SEG_USU_ID_USUARIO_ATUALIZACAO%type default NULL,
     pCAD_AUT_DT_ULTIMA_ATUALIZACAO IN TB_CAD_AUT_AUTORIZADOR.CAD_AUT_DT_ULTIMA_ATUALIZACAO%type default NULL	
) 
is
/********************************************************************
*    Procedure: PRC_CAD_AUT_AUTORIZADOR_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
    lIdtRetorno integer;
	  
begin
    SELECT SEQ_CAD_AUT_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
INSERT INTO TB_CAD_AUT_AUTORIZADOR
(
       CAD_AUT_ID,
       CAD_AUT_DS_DESCRICAO,
       CAD_AUT_FL_STATUS,
       SEG_USU_ID_USUARIO_CRIACAO,
       CAD_AUT_DT_CRIACAO,
       SEG_USU_ID_USUARIO_ATUALIZACAO,
       CAD_AUT_DT_ULTIMA_ATUALIZACAO
)
VALUES
(
      lIdtRetorno,
	  UPPER(pCAD_AUT_DS_DESCRICAO),
	  pCAD_AUT_FL_STATUS,
	  pSEG_USU_ID_USUARIO_CRIACAO,
	  pCAD_AUT_DT_CRIACAO,
	  pSEG_USU_ID_USUARIO_ATUALIZA,
	  pCAD_AUT_DT_ULTIMA_ATUALIZACAO
);
    pNewIdt := lIdtRetorno;	
end PRC_CAD_AUT_AUTORIZADOR_I;