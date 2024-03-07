create or replace procedure PRC_ASS_PAT_PACIEATEND_S
  (
     pATD_ATE_ID IN TB_ASS_PAT_PACIEATEND.ATD_ATE_ID%type DEFAULT NULL,
     pCAD_PAC_ID_PACIENTE IN TB_ASS_PAT_PACIEATEND.CAD_PAC_ID_PACIENTE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PAT_PACIEATEND_S
  *
  *    Data Criacao:  17/01/2008   Por: Andrea Cazuca
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Seleciona Paciente Atendimento
  *
  *    Data Alteracao: 06/12/2010          Por: Davi Silvestre M. dos Reis
  *    Alteracao: Troca da clausula 'where', substituindo todos 'is null'
  *               por 'if' e concatenacao da String de consulta
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  
  V_WHERE  varchar2(5000);
  V_SELECT  varchar2(5000);
  
  begin
    V_WHERE := NULL;

    IF pATD_ATE_ID IS NOT NULL THEN 
       V_WHERE := V_WHERE || ' AND ATD_ATE_ID = ' || pATD_ATE_ID; END IF;
    IF pCAD_PAC_ID_PACIENTE IS NOT NULL THEN 
       V_WHERE := V_WHERE || ' AND CAD_PAC_ID_PACIENTE = ' || pCAD_PAC_ID_PACIENTE; END IF;

    V_SELECT := 'SELECT
                   ATD_ATE_ID,
                   CAD_PAC_ID_PACIENTE,
                   ASS_PAT_DT_ENTRADA,
                   ASS_PAT_HR_ENTRADA,
                   ASS_PAT_DT_SAIDA,
                   ASS_PAT_HR_SAIDA,
                   ASS_PAT_FL_STATUS,
                   SEG_USU_ID_USUARIO,
                   ASS_PAT_DT_ULTIMA_ATUALIZACAO,
                   ASS_PAT_NR_CONTA
                FROM TB_ASS_PAT_PACIEATEND
                WHERE 1 = 1 ';
    
    V_SELECT := V_SELECT || V_WHERE;   
    OPEN v_cursor FOR
      V_SELECT;
      io_cursor := v_cursor;

  end PRC_ASS_PAT_PACIEATEND_S;
/
