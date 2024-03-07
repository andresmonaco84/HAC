

--PRC_FAT_TCO_TIPO_COMANDA_I
create or replace procedure PRC_FAT_TCO_TIPO_COMANDA_I
(
     pNewIdt OUT integer,
     pFAT_TCO_ID IN TB_FAT_TCO_TIPO_COMANDA.FAT_TCO_ID%type,
     pFAT_TCO_DS_COMANDA IN TB_FAT_TCO_TIPO_COMANDA.FAT_TCO_DS_COMANDA%type,
     pFAT_TCO_FL_STATUS IN TB_FAT_TCO_TIPO_COMANDA.FAT_TCO_FL_STATUS%type,
     pFAT_TCO_FL_VERIFICA_ITENS IN TB_FAT_TCO_TIPO_COMANDA.FAT_TCO_FL_VERIFICA_ITENS%type,
     pFAT_TCO_QT_MAX_LANCAMENTO IN TB_FAT_TCO_TIPO_COMANDA.FAT_TCO_QT_MAX_LANCAMENTO%type default NULL,
     pFAT_TCO_DT_ULTIMA_ATUALIZACAO IN TB_FAT_TCO_TIPO_COMANDA.FAT_TCO_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_FAT_TCO_TIPO_COMANDA.SEG_USU_ID_USUARIO%type,
     pCAD_PRO_ID_PROFISSIONAL IN TB_FAT_TCO_TIPO_COMANDA.CAD_PRO_ID_PROFISSIONAL%type default NULL	
) 
is
/********************************************************************
*    Procedure: PRC_FAT_TCO_TIPO_COMANDA_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  

    lIdtRetorno integer;
	  
begin

SELECT SEQ_FAT_TCO_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
INSERT INTO TB_FAT_TCO_TIPO_COMANDA
(
       FAT_TCO_ID,
       FAT_TCO_DS_COMANDA,
       FAT_TCO_FL_STATUS,
       FAT_TCO_FL_VERIFICA_ITENS,
       FAT_TCO_QT_MAX_LANCAMENTO,
       FAT_TCO_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PRO_ID_PROFISSIONAL
)
VALUES
(
	      lIdtRetorno,
	     pFAT_TCO_DS_COMANDA,
	     pFAT_TCO_FL_STATUS,
	     pFAT_TCO_FL_VERIFICA_ITENS,
	     pFAT_TCO_QT_MAX_LANCAMENTO,
	     pFAT_TCO_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO,
	     pCAD_PRO_ID_PROFISSIONAL
);

 pNewIdt := lIdtRetorno;	
	
end PRC_FAT_TCO_TIPO_COMANDA_I;

