  --PRC_ASS_PAP_PAC_ATEN_PROC_S
create or replace procedure PRC_ASS_PAP_PAC_ATEN_PROC_S(pASS_PAP_ID              IN TB_ASS_PAP_PAC_ATEN_PROC.ASS_PAP_ID%type DEFAULT NULL,
                                                        pATD_ATE_ID              IN TB_ASS_PAP_PAC_ATEN_PROC.ATD_ATE_ID%type DEFAULT NULL,
                                                        pCAD_PAC_ID_PACIENTE     IN TB_ASS_PAP_PAC_ATEN_PROC.CAD_PAC_ID_PACIENTE%type DEFAULT NULL,
                                                        pCAD_PRD_ID              IN TB_ASS_PAP_PAC_ATEN_PROC.CAD_PRD_ID%type DEFAULT NULL,
                                                        pASS_PAP_FL_STATUS_SOLIC IN TB_ASS_PAP_PAC_ATEN_PROC.ASS_PAP_FL_STATUS_SOLIC%type DEFAULT NULL,
                                                        pASS_PAP_FL_ORIGEM       IN TB_ASS_PAP_PAC_ATEN_PROC.ASS_PAP_FL_ORIGEM%type DEFAULT NULL,
                                                        io_cursor                OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_ASS_PAP_PAC_ATEN_PROC_S
  * 
  *    Data Criacao:  22/02/2008   Por: Andrea Cazuca
  *    Data Alteracao:  29/04/2008  Por: Andrea Cazuca
  *    Alteração: Foi incluído o id da Clínica
  *
  *    Funcao: Obtem/Lista os Procedimento do Paciente
  *
  *    Data Alteracao: 05/12/2008   Por: Fabíola Lopes
  *    Alteracao: Incluído o campo CAD_SET_ID_SETOR_LIBERACAO
  *
  *    Data Alteracao:  28/01/2009  Por: Andrea Cazuca
  *
  *    Data Alteracao:  12/02/2009  Por: Andrea Cazuca
  *    Alteracao: Foi incluido o campo ASS_PAP_FL_SEM_GUIA
  *
  *    Data Alteração: 04/08/2010  Por:Cristiane Gomes
  *    Alteracao: Não utilizar mais OR para tratar parametros nulos
  *
  *    Alteracao: Foi incluido os campos ASS_PAP_FL_CARATER_SOLIC, 
  *               ASS_PAP_FL_AUTORIZ_MANUAL_OK, ASS_PAP_FL_ACIDENTE_TRAB_OK
  *
  *    Data Alteracao:  17/10/2014   Por: Andrea Cazuca
  *    Alteracao: Incluido o campo TIS_CBO_CD_CBOS_SOLIC
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
      V_WHERE := V_WHERE || ' ATD_ATE_ID = ' || pATD_ATE_ID;
    END IF;
  END IF;
  IF pCAD_PAC_ID_PACIENTE IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND CAD_PAC_ID_PACIENTE = ' ||
                 pCAD_PAC_ID_PACIENTE;
    ELSE
      V_WHERE := V_WHERE || ' CAD_PAC_ID_PACIENTE = ' ||
                 pCAD_PAC_ID_PACIENTE;
    END IF;
  END IF;
  IF pCAD_PRD_ID IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND CAD_PRD_ID = ' || pCAD_PRD_ID;
    ELSE
      V_WHERE := V_WHERE || ' CAD_PRD_ID = ' || pCAD_PRD_ID;
    END IF;
  END IF;
  IF pASS_PAP_FL_STATUS_SOLIC IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ASS_PAP_FL_STATUS_SOLIC = ' || CHR(39) ||
                 pASS_PAP_FL_STATUS_SOLIC || CHR(39);
    ELSE
     V_WHERE := V_WHERE || ' ASS_PAP_FL_STATUS_SOLIC = ' || CHR(39) || pASS_PAP_FL_STATUS_SOLIC || CHR(39); 
    END IF;
  END IF;
  IF pASS_PAP_ID IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ASS_PAP_ID = ' || pASS_PAP_ID;
    ELSE
     V_WHERE := V_WHERE || ' ASS_PAP_ID = ' || pASS_PAP_ID; 
    END IF;
  END IF;
  IF pASS_PAP_FL_ORIGEM IS NOT NULL THEN
    IF V_WHERE IS NOT NULL THEN
      V_WHERE := V_WHERE || ' AND ASS_PAP_FL_ORIGEM = ' || CHR(39) ||
                 pASS_PAP_FL_ORIGEM || CHR(39);
    ELSE
     V_WHERE := V_WHERE || ' ASS_PAP_FL_ORIGEM = ' || CHR(39) || pASS_PAP_FL_ORIGEM || CHR(39); 
    END IF;
  END IF;
V_SELECT := 'SELECT ATD_ATE_ID,
           CAD_PRD_ID,
           CAD_PAC_ID_PACIENTE,
           ASS_PAP_QT_SOLIC,
           ASS_PAP_DT_SOLIC,
           ASS_PAP_FL_STATUS_SOLIC,
           ASS_PAP_HR_SOLIC,
           ASS_PAP_QT_AUTOR,
           ASS_PAP_DT_AUTOR,
           ASS_PAP_HR_AUTOR,
           ASS_PAP_FL_STATUS_AUTOR,
           ASS_PAP_QT_REALIZ,
           ASS_PAP_DT_REALIZ,
           ASS_PAP_HR_INI_REALIZ,
           ASS_PAP_HR_FIM_REALIZ,
           ASS_PAP_FL_STATUS_REALIZ,
           SEG_USU_ID_USUARIO,
           ASS_PAP_NR_CONTA,
           ASS_PAP_DT_ULTIMA_ATUALIZACAO,
           ASS_PAP_ID,
           ASS_PAP_FL_ORIGEM,
           CAD_UNI_ID_UNIDADE,
           CODPAD,
           ATD_ATE_NR_CONSELHO_SOLIC,
           ATD_ATE_CD_UFCONSELHO_SOLIC,
           TIS_CPR_CD_CONSELHOPROF_SOLIC,
           CAD_LAT_ID_LOCAL_ATENDIMENTO,
           ASS_PAP_NM_ATENDENTE_PLANO,
           CAD_CLC_ID,
           ASS_PAP_DS_OBSERVACAO,
           CAD_SET_ID_SETOR_LIBERACAO,
           ASS_PAP_DS_RET_AUTORIZADOR,
           ASS_PAP_FL_CARATER_SOLIC,
           ASS_PAP_FL_AUTORIZ_MANUAL_OK,
           ASS_PAP_FL_ACIDENTE_TRAB_OK,
           ASS_PAP_FL_SEM_GUIA_OK,
           TIS_CBO_CD_CBOS_SOLIC,
		   CAD_CID_CD_CID10,
		   ASS_PAP_DS_INDCLINICA,
		   TIS_MGL_ID,
		   TIS_STS_CD_CODIGO 
      FROM TB_ASS_PAP_PAC_ATEN_PROC pap
     WHERE '|| V_WHERE;
  OPEN v_cursor FOR
    V_SELECT;
  io_cursor := v_cursor;
end PRC_ASS_PAP_PAC_ATEN_PROC_S;