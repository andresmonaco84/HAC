create or replace procedure PRC_ASS_PRC_PROCED_CBOS_S
(
     pTIS_CBO_CD_CBOS_HAC IN TB_ASS_PRC_PROCED_CBOS.TIS_CBO_CD_CBOS_HAC%type DEFAULT NULL,
     pTIS_MED_CD_TABELAMEDICA IN TB_ASS_PRC_PROCED_CBOS.TIS_MED_CD_TABELAMEDICA%type DEFAULT NULL,
     pAUX_EPP_CD_ESPECPROC IN TB_ASS_PRC_PROCED_CBOS.AUX_EPP_CD_ESPECPROC%type DEFAULT NULL,
     pAUX_GPC_CD_GRUPOPROC IN TB_ASS_PRC_PROCED_CBOS.AUX_GPC_CD_GRUPOPROC%type DEFAULT NULL,
     pCAD_PRD_CD_CODIGO IN TB_ASS_PRC_PROCED_CBOS.CAD_PRD_CD_CODIGO%type DEFAULT NULL,
     pCAD_PRD_NM_MNEMONICO IN TB_ASS_PRC_PROCED_CBOS.CAD_PRD_NM_MNEMONICO%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ASS_PRC_PROCED_CBOS_S
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
       TIS_CBO_CD_CBOS_HAC,
       TIS_CBO_DS_CBOS_HAC,
       AUX_EPP_CD_ESPECPROC,
       AUX_GPC_CD_GRUPOPROC,
       TIS_MED_CD_TABELAMEDICA,
       CAD_PRD_CD_CODIGO,
       CAD_PRD_DS_DESCRICAO,
       CAD_PRD_NM_MNEMONICO,
       ASS_PRC_FL_STATUS,
       ASS_PRC_DT_INICIO_VIGENCIA,
       ASS_PRC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_DS_LOGIN
FROM TB_ASS_PRC_PROCED_CBOS
WHERE
        (pTIS_CBO_CD_CBOS_HAC is null OR TIS_CBO_CD_CBOS_HAC = pTIS_CBO_CD_CBOS_HAC) AND          
        (pAUX_EPP_CD_ESPECPROC is null OR AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC) AND 
        (pAUX_GPC_CD_GRUPOPROC is null OR AUX_GPC_CD_GRUPOPROC = pAUX_GPC_CD_GRUPOPROC) AND 
        (pTIS_MED_CD_TABELAMEDICA is null OR TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA) AND 
        (pCAD_PRD_CD_CODIGO is null OR CAD_PRD_CD_CODIGO = pCAD_PRD_CD_CODIGO) AND 
        (pCAD_PRD_NM_MNEMONICO is null OR CAD_PRD_NM_MNEMONICO = pCAD_PRD_NM_MNEMONICO)                  
        ;          
io_cursor := v_cursor;
end PRC_ASS_PRC_PROCED_CBOS_S;
