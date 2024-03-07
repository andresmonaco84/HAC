

--PRC_CAD_END_ENDERECO_R_S
create or replace procedure PRC_CAD_END_ENDERECO_R_S 
(
     pCAD_END_ID_ENDERECO IN TB_CAD_END_ENDERECO.CAD_END_ID_ENDERECO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_END_ENDERECO_R_S
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
       CAD_END_ID_ENDERECO,
       CAD_END_NM_LOGRADOURO,
       CAD_END_NM_BAIRRO,
       CAD_END_SG_UF,
       CAD_END_CD_CEP,
       CAD_END_DS_NUMERO,
       CAD_END_DT_ULTIMA_ATUALIZACAO,
       CAD_END_DS_COMPLEMENTO,
       AUX_MUN_CD_IBGE,
       SEG_USU_ID_USUARIO,
       AUX_TTE_CD_TP_TEL_END,
       TIS_TLG_CD_TPLOGRADOURO,
       CAD_PES_ID_PESSOA,
       CAD_END_NM_ENDERECO_NF
FROM TB_CAD_END_ENDERECO
WHERE
        CAD_END_ID_ENDERECO = pCAD_END_ID_ENDERECO;          
io_cursor := v_cursor;
end PRC_CAD_END_ENDERECO_R_S;
