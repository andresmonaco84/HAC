--PRC_CAD_JPG_JUSTIFICA_PAGTO_I
create or replace procedure PRC_CAD_JPG_JUSTIFICA_PAGTO_I
(
     pNewIdt OUT integer,
     pID_CAD_JPG IN TB_CAD_JPG_JUSTIFICA_PAGTO.ID_CAD_JPG%type default NULL,
     pCAD_JPG_DS_JUSTIFICATIVA IN TB_CAD_JPG_JUSTIFICA_PAGTO.CAD_JPG_DS_JUSTIFICATIVA%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_JPG_JUSTIFICA_PAGTO.SEG_USU_ID_USUARIO%type,
     pCAD_JPG_DT_ULTIMA_ATUALIZACAO IN TB_CAD_JPG_JUSTIFICA_PAGTO.CAD_JPG_DT_ULTIMA_ATUALIZACAO%type	
) 
is
/********************************************************************
*    Procedure: PRC_CAD_JPG_JUSTIFICA_PAGTO_I
* 
*    Data Criacao: 	  28/02/2012         Por: Fabíola Lopes
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Inclusão das Justificativas de Pagamento
*
*******************************************************************/  
    lIdtRetorno integer;
	  
begin
    SELECT SEQ_CAD_JPG_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
INSERT INTO TB_CAD_JPG_JUSTIFICA_PAGTO
(
       ID_CAD_JPG,
       CAD_JPG_DS_JUSTIFICATIVA,
       SEG_USU_ID_USUARIO,
       CAD_JPG_DT_ULTIMA_ATUALIZACAO
)
VALUES
(
      lIdtRetorno,
	     pCAD_JPG_DS_JUSTIFICATIVA,
	     pSEG_USU_ID_USUARIO,
	     pCAD_JPG_DT_ULTIMA_ATUALIZACAO
);
    pNewIdt := lIdtRetorno;	
end PRC_CAD_JPG_JUSTIFICA_PAGTO_I;