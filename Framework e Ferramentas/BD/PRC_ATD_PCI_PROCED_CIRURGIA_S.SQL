--PRC_ATD_PCI_PROCED_CIRURGIA_S
create or replace procedure PRC_ATD_PCI_PROCED_CIRURGIA_S 
(
     pATD_PCI_ID IN TB_ATD_PCI_PROCED_CIRURGIA.ATD_PCI_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ATD_PCI_PROCED_CIRURGIA_S
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       ATD_PCI_ID,
       ATD_CIR_ID,
       TIS_MED_CD_TABELAMEDICA,
       AUX_EPP_CD_ESPECPROC,
       AUX_GPC_CD_GRUPOPROC,
       CAD_PRD_ID,
       SEG_USU_ID_USU_CRIACAO,
       ATD_PCI_DT_CRIACAO,
       SEG_USU_ID_USU_ULT_ATUALIZ,
       ATD_PCI_DT_ULT_ATUALIZ,
       CAD_PRD_TP_PORTE,
       ATD_PCI_FL_SITUACAO
FROM TB_ATD_PCI_PROCED_CIRURGIA
WHERE
        ATD_PCI_ID = pATD_PCI_ID;          
io_cursor := v_cursor;
end PRC_ATD_PCI_PROCED_CIRURGIA_S;