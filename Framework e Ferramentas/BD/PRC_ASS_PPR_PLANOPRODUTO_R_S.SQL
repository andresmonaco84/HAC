

--PRC_ASS_PPR_PLANOPRODUTO_R_S
create or replace procedure PRC_ASS_PPR_PLANOPRODUTO_R_S 
(
     pCAD_CNV_ID_CONVENIO IN TB_ASS_PPR_PLANOPRODUTO.CAD_CNV_ID_CONVENIO%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_PPR_PLANOPRODUTO.CAD_PLA_ID_PLANO%type,
     pCAD_PRD_ID IN TB_ASS_PPR_PLANOPRODUTO.CAD_PRD_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ASS_PPR_PLANOPRODUTO_R_S
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
       CAD_CNV_ID_CONVENIO,
       CAD_PLA_ID_PLANO,
       CAD_PRD_ID,
       ASS_PPR_FL_EXIGEGUIA_OK,
       ASS_PPR_FL_EXIGESENHA_OK,
       TIS_MED_CD_TABELAMEDICA,
       SEG_USU_ID_USUARIO,
       ASS_PPR_DT_ULTIMA_ATUALIZACAO,
       ASS_PPR_FL_EXIGEAUTOR_OK,
       ASS_PPR_FL_STATUS,
       ASS_PPR_FL_AUTORIZATEL_OK,
       ASS_PPR_FL_AUTORIZAFAX_OK,
       ASS_PPR_FL_ANTECIPASENHA_OK,
       ASS_PPR_QT_DIASAUTORIZACAO,
       ASS_PPR_FL_AUTORIZAPES_OK,
       ASS_PPR_FL_AUTORIZA_ASS_OK,
       ASS_PPR_FL_AUTORIZAWEB_OK,
       ASS_PPR_FL_EXIGEGUIAPS_OK,
       ASS_PPR_FL_EXIGESENHAPS_OK,
       ASS_PPR_FL_PROCDOPLER_OK
FROM TB_ASS_PPR_PLANOPRODUTO
WHERE
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
    AND CAD_PRD_ID = pCAD_PRD_ID;          
io_cursor := v_cursor;
end PRC_ASS_PPR_PLANOPRODUTO_R_S;
