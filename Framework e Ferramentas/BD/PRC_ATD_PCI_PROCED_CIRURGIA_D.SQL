--PRC_ATD_PCI_PROCED_CIRURGIA_D
create or replace procedure PRC_ATD_PCI_PROCED_CIRURGIA_D 
(
     pATD_PCI_ID IN TB_ATD_PCI_PROCED_CIRURGIA.ATD_PCI_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ATD_PCI_PROCED_CIRURGIA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ATD_PCI_PROCED_CIRURGIA
WHERE  
        ATD_PCI_ID = pATD_PCI_ID;	   
end PRC_ATD_PCI_PROCED_CIRURGIA_D;
