  create or replace procedure PRC_ASS_PPG_PAC_ATE_PRO_GUIA_S 
  (
     pATD_ATE_ID IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ATD_ATE_ID%type DEFAULT NULL,
     pATE_GUI_CD_CODIGO IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ATE_GUI_CD_CODIGO%type DEFAULT NULL,
     pATE_GUI_DT_VALIDADE IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ATE_GUI_DT_VALIDADE%type DEFAULT NULL,
     pCAD_PAC_ID_PACIENTE IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.CAD_PAC_ID_PACIENTE%type DEFAULT NULL,
     pCAD_PRD_ID IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.CAD_PRD_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PPG_PAC_ATE_PRO_GUIA_S
  * 
  *    Data Criacao: 	24/03/2008   Por: Andrea Cazuca
  *    Funcao: Obtém/Lista as Guias por Procedimento
  *
  *    Data Alteracao:	09/08/2010  Por: Cristiane Gomes
  *    Alteracao:       Nao utilizar OR para tratar parametros nulos
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(2000);
  V_SELECT varchar2(4000);
begin
  V_WHERE := NULL;
  IF pATD_ATE_ID IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ATD_ATE_ID = ' || pATD_ATE_ID;
    ELSE
      V_WHERE := V_WHERE || ' ATD_ATE_ID =  ' || pATD_ATE_ID;
    END IF;
  END IF;
  IF pATE_GUI_CD_CODIGO IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ATE_GUI_CD_CODIGO = '|| CHR(39) || pATE_GUI_CD_CODIGO || CHR(39);
    ELSE
      V_WHERE := V_WHERE || ' ATE_GUI_CD_CODIGO =  ' || CHR(39) || pATE_GUI_CD_CODIGO || CHR(39);
    END IF;
  END IF;
  IF pATE_GUI_DT_VALIDADE IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ATE_GUI_DT_VALIDADE = ' || pATE_GUI_DT_VALIDADE;
    ELSE
      V_WHERE := V_WHERE || ' ATE_GUI_DT_VALIDADE =  ' || pATE_GUI_DT_VALIDADE;
    END IF;
  END IF;
  IF pCAD_PAC_ID_PACIENTE IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND CAD_PAC_ID_PACIENTE = ' || pCAD_PAC_ID_PACIENTE;
    ELSE
      V_WHERE := V_WHERE || ' CAD_PAC_ID_PACIENTE =  ' || pCAD_PAC_ID_PACIENTE;
    END IF;
  END IF;
  IF pCAD_PRD_ID IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND CAD_PRD_ID = ' || pCAD_PRD_ID;
    ELSE
      V_WHERE := V_WHERE || ' CAD_PRD_ID =  ' || pCAD_PRD_ID;
    END IF;
  END IF;
  V_SELECT := '    SELECT	
       SEG_USU_ID_USUARIO,
       ASS_PPG_DT_ULTIMA_ATUALIZACAO,
       ATE_GUI_CD_CODIGO,
       ATE_GUI_DT_VALIDADE,
       ATD_ATE_ID,
       CAD_PRD_ID,
       CAD_PAC_ID_PACIENTE,
       ASS_PPG_CD_SENHA,
       ASS_PPG_CD_SENHA_AUTORIZADOR
    FROM TB_ASS_PPG_PAC_ATE_PROC_GUIA
    WHERE ' || V_WHERE;
    OPEN v_cursor FOR
V_SELECT;
    io_cursor := v_cursor;
  end PRC_ASS_PPG_PAC_ATE_PRO_GUIA_S;
/
