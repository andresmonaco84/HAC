 create or replace procedure PRC_MTMD_HISTORICO_NF_ESTOR_L
(
     pCAD_MTMD_ID IN TB_MTMD_HISTORICO_NF_ESTORNO.CAD_MTMD_ID%type DEFAULT NULL,
     pCAD_MTMD_ID_ACERTO IN TB_MTMD_HISTORICO_NF_ESTORNO.CAD_MTMD_ID_ACERTO%type DEFAULT NULL,
     pCAD_MTMD_FILIAL_ID IN TB_MTMD_HISTORICO_NF_ESTORNO.CAD_MTMD_FILIAL_ID%type DEFAULT NULL,
     pMTMD_NR_NOTA IN TB_MTMD_HISTORICO_NF_ESTORNO.MTMD_NR_NOTA%type DEFAULT NULL,
     pIDMOV IN TB_MTMD_HISTORICO_NF_ESTORNO.IDMOV%type DEFAULT NULL,
     pMTMD_QTDE IN TB_MTMD_HISTORICO_NF_ESTORNO.MTMD_QTDE%type DEFAULT NULL,
     pDS_FORNECEDOR IN TB_MTMD_HISTORICO_NF_ESTORNO.DS_FORNECEDOR%type DEFAULT NULL,
     pTP_MOVIMENTO IN TB_MTMD_HISTORICO_NF_ESTORNO.TP_MOVIMENTO%type DEFAULT NULL,
     pNF_MOTIVO_ESTORNO IN TB_MTMD_HISTORICO_NF_ESTORNO.NF_MOTIVO_ESTORNO%type DEFAULT NULL,
     pMTMD_MOV_ID IN TB_MTMD_HISTORICO_NF_ESTORNO.MTMD_MOV_ID%type DEFAULT NULL,
     pMTMD_MOV_DATA IN TB_MTMD_HISTORICO_NF_ESTORNO.MTMD_MOV_DATA%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_MTMD_HISTORICO_NF_ESTORNO.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pSTATUS IN TB_MTMD_HISTORICO_NF_ESTORNO.STATUS%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_MTMD_HISTORICO_NF_ESTOR_L
*
*    Data Criacao: 	14/05/2012   Por: Andr�
*
*    Funcao: Lista log de estorno de NF
*******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(5000);
  V_SELECT  varchar2(5000);
begin
  V_WHERE := NULL;
  IF pCAD_MTMD_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND NF.CAD_MTMD_ID = ' || pCAD_MTMD_ID; END IF;
IF pCAD_MTMD_ID_ACERTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_MTMD_ID_ACERTO = ' || pCAD_MTMD_ID_ACERTO; END IF;
IF pCAD_MTMD_FILIAL_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND NF.CAD_MTMD_FILIAL_ID = ' || pCAD_MTMD_FILIAL_ID; END IF;
IF pMTMD_NR_NOTA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND MTMD_NR_NOTA = ' || CHR(39) || pMTMD_NR_NOTA || CHR(39); END IF;
IF pIDMOV IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND IDMOV = ' || pIDMOV; END IF;
IF pMTMD_QTDE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND MTMD_QTDE = ' || pMTMD_QTDE; END IF;
IF pDS_FORNECEDOR IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND DS_FORNECEDOR = ' || CHR(39) || pDS_FORNECEDOR || CHR(39); END IF;
IF pTP_MOVIMENTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND TP_MOVIMENTO = ' || CHR(39) || pTP_MOVIMENTO || CHR(39); END IF;
IF pNF_MOTIVO_ESTORNO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND NF_MOTIVO_ESTORNO = ' || CHR(39) || pNF_MOTIVO_ESTORNO || CHR(39); END IF;
IF pMTMD_MOV_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND MTMD_MOV_ID = ' || pMTMD_MOV_ID; END IF;
IF pMTMD_MOV_DATA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND NF.MTMD_MOV_DATA = ' || CHR(39) || pMTMD_MOV_DATA || CHR(39); END IF;
IF pSEG_USU_ID_USUARIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND NF.SEG_USU_ID_USUARIO = ' || pSEG_USU_ID_USUARIO; END IF;
IF pSTATUS IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND STATUS = ' || pSTATUS; END IF;
V_WHERE:= V_WHERE || ' ORDER BY NF.MTMD_MOV_DATA ';

   V_SELECT := 'SELECT
                       NF.CAD_MTMD_ID,
                       CAD_MTMD_ID_ACERTO,
                       NF.CAD_MTMD_FILIAL_ID,
                       MTMD_NR_NOTA,
                       IDMOV,
                       MTMD_QTDE,
                       DS_FORNECEDOR,
                       TP_MOVIMENTO,
                       NF_MOTIVO_ESTORNO,
                       MTMD_MOV_ID,
                       NF.MTMD_MOV_DATA,
                       NF.SEG_USU_ID_USUARIO,
                       STATUS,
                       DECODE(STATUS, 0, ''PENDENTE DE ACERTO'', ''FINALIZADO'') STATUS_DESCRICAO,
                       MTMD_MOV_DATA_ACERTO,
                       PRODUTO_ACERTO.CAD_MTMD_NOMEFANTASIA PRODUTO_ACERTO
                FROM TB_MTMD_HISTORICO_NF_ESTORNO NF,
                     TB_CAD_MTMD_MAT_MED PRODUTO_ACERTO
                WHERE PRODUTO_ACERTO.CAD_MTMD_ID(+) = NF.CAD_MTMD_ID_ACERTO ';

OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_MTMD_HISTORICO_NF_ESTOR_L;