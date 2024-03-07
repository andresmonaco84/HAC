

--PRC_FAT_TCP_TP_COMANDA_PROD_I
create or replace procedure PRC_FAT_TCP_TP_COMANDA_PROD_I
(
     pNewIdt OUT integer,
     pFAT_TCP_ID IN TB_FAT_TCP_TP_COMANDA_PROD.FAT_TCP_ID%type default NULL,
     pFAT_TCO_ID IN TB_FAT_TCP_TP_COMANDA_PROD.FAT_TCO_ID%type,
     pCAD_PRD_ID IN TB_FAT_TCP_TP_COMANDA_PROD.CAD_PRD_ID%type,
     pFAT_TCP_DT_ULTIMA_ATUALIZACAO IN TB_FAT_TCP_TP_COMANDA_PROD.FAT_TCP_DT_ULTIMA_ATUALIZACAO%type,
     pFAT_TCP_FL_STATUS IN TB_FAT_TCP_TP_COMANDA_PROD.FAT_TCP_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_FAT_TCP_TP_COMANDA_PROD.SEG_USU_ID_USUARIO%type	
) 
is
/********************************************************************
*    Procedure: PRC_FAT_TCP_TP_COMANDA_PROD_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
    lIdtRetorno integer;
	  
begin
    SELECT SEQ_FAT_TCP_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
INSERT INTO TB_FAT_TCP_TP_COMANDA_PROD
(
       FAT_TCP_ID,
       FAT_TCO_ID,
       CAD_PRD_ID,
       FAT_TCP_DT_ULTIMA_ATUALIZACAO,
       FAT_TCP_FL_STATUS,
       SEG_USU_ID_USUARIO
)
VALUES
(
      lIdtRetorno,
	     pFAT_TCO_ID,
	     pCAD_PRD_ID,
	     pFAT_TCP_DT_ULTIMA_ATUALIZACAO,
	     pFAT_TCP_FL_STATUS,
	     pSEG_USU_ID_USUARIO
);
    pNewIdt := lIdtRetorno;	
end PRC_FAT_TCP_TP_COMANDA_PROD_I;

