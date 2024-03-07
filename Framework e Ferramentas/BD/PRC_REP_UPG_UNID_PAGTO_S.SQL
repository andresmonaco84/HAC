

--PRC_REP_UPG_UNID_PAGTO_S
create or replace procedure PRC_REP_UPG_UNID_PAGTO_S 
(
     pCAD_CLC_ID IN TB_REP_UPG_UNID_PAGTO.CAD_CLC_ID%type,
     pCAD_UNI_ID_UNIDADE IN TB_REP_UPG_UNID_PAGTO.CAD_UNI_ID_UNIDADE%type,
     pCAD_UNI_ID_UNIDADE_PAGAMENTO IN TB_REP_UPG_UNID_PAGTO.CAD_UNI_ID_UNIDADE_PAGAMENTO%type,
     pREP_PGM_TP_CREDENCIA_PROF IN TB_REP_UPG_UNID_PAGTO.REP_PGM_TP_CREDENCIA_PROF%type,
     pREP_UPG_DT_INICIO_VIGENCIA IN TB_REP_UPG_UNID_PAGTO.REP_UPG_DT_INICIO_VIGENCIA%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_REP_UPG_UNID_PAGTO_S
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
       CAD_CLC_ID,
       CAD_UNI_ID_UNIDADE,
       CAD_UNI_ID_UNIDADE_PAGAMENTO,
       REP_PGM_TP_CREDENCIA_PROF,
       REP_UPG_DT_INICIO_VIGENCIA,
       REP_UPG_DT_FIM_VIGENVCIA,
       SEG_USU_ID_USUARIO,
       REP_UPG_DT_CRIACAO,
       SEG_USU_ID_USUARIO_ALTERACAO,
       REP_UPG_DT_ALTERACAO
FROM TB_REP_UPG_UNID_PAGTO
WHERE
        CAD_CLC_ID = pCAD_CLC_ID
    AND CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND CAD_UNI_ID_UNIDADE_PAGAMENTO = pCAD_UNI_ID_UNIDADE_PAGAMENTO
    AND REP_PGM_TP_CREDENCIA_PROF = pREP_PGM_TP_CREDENCIA_PROF
    AND REP_UPG_DT_INICIO_VIGENCIA = pREP_UPG_DT_INICIO_VIGENCIA;          
io_cursor := v_cursor;
end PRC_REP_UPG_UNID_PAGTO_S;
