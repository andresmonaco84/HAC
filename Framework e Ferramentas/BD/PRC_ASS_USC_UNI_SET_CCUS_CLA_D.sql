

--PRC_ASS_USC_UNI_SET_CCUS_CLA_D
create or replace procedure PRC_ASS_USC_UNI_SET_CCUS_CLA_D 
(
     pASS_USC_ID IN TB_ASS_USC_UNI_SET_CCUS_CLA.ASS_USC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_USC_UNI_SET_CCUS_CLA_D
*
*	 Data Criacao: 	 12/2009    Por: Pedro
*    Data Alteracao: 06/09/2010 Por: André Souza Monaco
*         Alteração: Adição do campo FAT_TCO_ID
*
*    Data Alteracao: 24/09/2010 Por: Rafael Coimbra
*         Alteração: Adição do campo CAD_PRD_ID
*
*******************************************************************/    
begin
DELETE TB_ASS_USC_UNI_SET_CCUS_CLA
WHERE  
        ASS_USC_ID = pASS_USC_ID;	   
end PRC_ASS_USC_UNI_SET_CCUS_CLA_D;
