create or replace procedure PRC_FAT_TCS_COMANDA_SET_CC_I
(     
     pFAT_TCO_ID IN TB_FAT_TCS_COMANDA_SET_CC.FAT_TCO_ID%type default NULL,
     pFAT_TCS_FL_STATUS IN TB_FAT_TCS_COMANDA_SET_CC.FAT_TCS_FL_STATUS%type,
     pFAT_TCS_DT_ULTIMA_ATUALIZACAO IN TB_FAT_TCS_COMANDA_SET_CC.FAT_TCS_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_FAT_TCS_COMANDA_SET_CC.SEG_USU_ID_USUARIO%type,
     pCAD_SET_ID IN TB_FAT_TCS_COMANDA_SET_CC.CAD_SET_ID%type default NULL	
) 
is
/********************************************************************
*    Procedure: PRC_FAT_TCS_COMANDA_SET_CC_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
	  
begin    
	    
INSERT INTO TB_FAT_TCS_COMANDA_SET_CC
(
       FAT_TCO_ID,
       FAT_TCS_FL_STATUS,
       FAT_TCS_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_SET_ID
)
VALUES
(
		   pFAT_TCO_ID,
	     pFAT_TCS_FL_STATUS,
	     pFAT_TCS_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO,
	     pCAD_SET_ID

);
    
end PRC_FAT_TCS_COMANDA_SET_CC_I;
