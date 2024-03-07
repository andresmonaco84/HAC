

--PRC_FAT_TCS_COMANDA_SET_CC_U
create or replace procedure PRC_FAT_TCS_COMANDA_SET_CC_U
(
     pFAT_TCO_ID IN TB_FAT_TCS_COMANDA_SET_CC.FAT_TCO_ID%type,
     pFAT_TCS_FL_STATUS IN TB_FAT_TCS_COMANDA_SET_CC.FAT_TCS_FL_STATUS%type,
     pFAT_TCS_DT_ULTIMA_ATUALIZACAO IN TB_FAT_TCS_COMANDA_SET_CC.FAT_TCS_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_FAT_TCS_COMANDA_SET_CC.SEG_USU_ID_USUARIO%type,
     pCAD_SET_ID IN TB_FAT_TCS_COMANDA_SET_CC.CAD_SET_ID%type
) 
is
/********************************************************************
*    Procedure: PRC_FAT_TCS_COMANDA_SET_CC_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_FAT_TCS_COMANDA_SET_CC
SET	   
        FAT_TCS_FL_STATUS = pFAT_TCS_FL_STATUS,
        FAT_TCS_DT_ULTIMA_ATUALIZACAO = pFAT_TCS_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
WHERE
        CAD_SET_ID = pCAD_SET_ID
    AND FAT_TCO_ID = pFAT_TCO_ID;	
end PRC_FAT_TCS_COMANDA_SET_CC_U;

