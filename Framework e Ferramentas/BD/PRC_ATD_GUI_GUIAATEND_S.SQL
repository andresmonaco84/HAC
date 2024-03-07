CREATE OR REPLACE PROCEDURE "PRC_ATD_GUI_GUIAATEND_S"
  (
     pATD_ATE_ID IN TB_ATD_GUI_GUIAATEND.ATD_ATE_ID%type DEFAULT NULL,
     pATD_GUI_CD_CODIGO IN TB_ATD_GUI_GUIAATEND.ATD_GUI_CD_CODIGO%type DEFAULT NULL,
     pATD_GUI_DT_VALIDADE IN TB_ATD_GUI_GUIAATEND.ATD_GUI_DT_VALIDADE%type DEFAULT NULL,
     pATD_GUI_CD_SENHA IN TB_ATD_GUI_GUIAATEND.ATD_GUI_CD_SENHA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATD_GUI_GUIAATEND_S
  *
  *    Data Criacao:  11/03/2008   Por: Andrea Cazuca
  *    Data Alteracao: data da altera???#o  Por: Nome do Analista
  *
  *    Funcao: Seleciona a guia de atendimento
  *
  *******************************************************************/
   v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(5000);
  V_SELECT  varchar2(5000);
begin
  V_WHERE := NULL;
  
IF pATD_GUI_CD_CODIGO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_GUI_CD_CODIGO = ' || CHR(39) || pATD_GUI_CD_CODIGO || CHR(39); END IF;
IF pATD_ATE_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_ATE_ID = ' || pATD_ATE_ID; END IF;
IF pATD_GUI_DT_VALIDADE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_GUI_DT_VALIDADE = ' || CHR(39) || pATD_GUI_DT_VALIDADE || CHR(39); END IF;
IF pATD_GUI_CD_SENHA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD_GUI_CD_SENHA = ' || CHR(39) || pATD_GUI_CD_SENHA || CHR(39); END IF;

   V_SELECT := '
SELECT
       ATD_GUI_CD_CODIGO,
       ATD_GUI_DT_ULTIMA_ATUALIZACAO,
       ATD_GUI_FL_GUIAPRINC_OK,
       ATD_ATE_ID,
       ATD_GUI_DT_EMISSAOGUIA,
       SEG_USU_ID_USUARIO,
       ATD_GUI_DT_AUTORIZGUIA,
       ATD_GUI_FL_ATIVO_OK,
       ATD_GUI_CD_SENHA,
       ATD_GUI_DT_VALIDADE
    FROM TB_ATD_GUI_GUIAATEND
    WHERE null is null  '    ;
    
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;

 end PRC_ATD_GUI_GUIAATEND_S;
 