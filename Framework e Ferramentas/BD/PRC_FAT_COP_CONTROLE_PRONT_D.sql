 create or replace procedure PRC_FAT_COP_CONTROLE_PRONT_D
(
     pFAT_COP_ID IN TB_FAT_COP_CONTROLE_PRONTUARIO.FAT_COP_ID%type
)
is
/********************************************************************
*    Procedure: PRC_FAT_COP_CONTROLE_PRONT_D
*
*    Data Criacao: 	5/12/2012   Por: Andr�
*
*    Funcao: Exclus�o de Registro de Controle de Prontu�rio
*******************************************************************/
begin
DELETE TB_FAT_COP_CONTROLE_PRONTUARIO
WHERE
        FAT_COP_ID = pFAT_COP_ID;
end PRC_FAT_COP_CONTROLE_PRONT_D;
