CREATE OR REPLACE PROCEDURE "PRC_REP_13_DEMONSTRATIVO_PAGTO"
  (
     pREP_RPA_ID			  IN STRING,
     pCAD_CLC_ID			  IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%TYPE,
     pREP_RPA_MES_PAGTO       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type,
     pREP_RPA_ANO_PAGTO       IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type,
     pCAD_UNI_ID_UNIDADE	  IN STRING,
     pREP_RPA_FONTE_PAGADORA  IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_FONTE_PAGADORA%TYPE,
     io_cursor				  OUT PKG_CURSOR.t_cursor
  )
  is
/********************************************************************
*    Procedure: PRC_REP_13_DEMONSTRATIVO_PAGTO
*
*    Data Criacao:    13/08/2012         Por: Fabiola Lopes
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  VARCHAR2(5000);
  V_SELECT VARCHAR2(5000);
  V_GROUP  VARCHAR2(5000);
  BEGIN
    IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN
       V_WHERE:= V_WHERE || ' AND RPA.CAD_UNI_ID_UNIDADE IN  ( ' || pCAD_UNI_ID_UNIDADE || ' )';
    END IF;
    IF pREP_RPA_FONTE_PAGADORA IS NOT NULL THEN
       V_WHERE:= V_WHERE || ' AND RPA.REP_RPA_FONTE_PAGADORA = ' || chr(39) || pREP_RPA_FONTE_PAGADORA || chr(39);
    END IF;
    IF pREP_RPA_ID IS NOT NULL THEN
       V_WHERE:= V_WHERE || ' AND RPA.REP_RPA_ID IN ( ' || pREP_RPA_ID || ')';
    END IF;
    V_SELECT := 'SELECT SUM(RPA.REP_RPA_VL_PAGTO_CLINICA) PAGAMENTO,
                        UNI.CAD_UNI_DS_UNIDADE,
                        CLC.CAD_CLC_DS_DESCRICAO,                        
                        ENDE.CAD_END_NM_LOGRADOURO                                                                 || ' || CHR(39) || ', '  || CHR(39) || ' || 
                        ENDE.CAD_END_DS_NUMERO                                                                     || ' || CHR(39) || ' - ' || CHR(39) || ' || 
                        ENDE.CAD_END_NM_BAIRRO                                                                     || ' || CHR(39) || ' - ' || CHR(39) || ' || 
                        MUN.AUX_MUN_NM_MUNICIPIO                                                                   || ' || CHR(39) || '/'   || CHR(39) || ' || 
                        MUN.AUX_MUN_SG_UF                                                                          || ' || CHR(39) || ' - ' || CHR(39) || ' || 
                        SUBSTR(LPAD(TRIM(ENDE.CAD_END_CD_CEP), 8, ' || CHR(39) || '0' || CHR(39)  || '), 1, 5)     || ' || CHR(39) ||  '-'  || CHR(39) || ' || 
                        SUBSTR(LPAD(TRIM(ENDE.CAD_END_CD_CEP), 8, ' || CHR(39) || '0' || CHR(39)  || '), 6, 3) ENDERECO,
                        FNC_FORMATAR_CPF_CNPJ(PES.CAD_PES_NR_CNPJ_CPF) CAD_PES_NR_CNPJ_CPF
                        
                   FROM TB_REP_RPA_RESUMO_PAGTO RPA,
                        TB_CAD_UNI_UNIDADE UNI,
                        TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                        TB_CAD_PES_PESSOA PES,
                        TB_CAD_END_ENDERECO ENDE,
                        TB_AUX_MUN_MUNICIPIO MUN
                 
                  WHERE RPA.REP_RPA_MES_PAGTO = ' || pREP_RPA_MES_PAGTO || '
                    AND RPA.REP_RPA_ANO_PAGTO = ' || pREP_RPA_ANO_PAGTO || '
                    AND RPA.CAD_CLC_ID = ' || pCAD_CLC_ID || '
                    AND RPA.REP_RPA_FL_STATUS = ' || CHR(39) || 'A' || CHR(39)  || '
                    AND RPA.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
                    AND RPA.CAD_CLC_ID = CLC.CAD_CLC_ID
                    AND UNI.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
                    AND PES.CAD_PES_ID_PESSOA = ENDE.CAD_PES_ID_PESSOA
                    AND ENDE.AUX_TTE_CD_TP_TEL_END = 2
                    AND ENDE.AUX_MUN_CD_IBGE = MUN.AUX_MUN_CD_IBGE ' ;

    V_GROUP := ' GROUP BY UNI.CAD_UNI_DS_UNIDADE,
                          CLC.CAD_CLC_DS_DESCRICAO,
                          ENDE.CAD_END_NM_LOGRADOURO  || ' || CHR(39) || ', '  || CHR(39) || ' || 
                          ENDE.CAD_END_DS_NUMERO      || ' || CHR(39) || ' - ' || CHR(39) || ' || 
                          ENDE.CAD_END_NM_BAIRRO      || ' || CHR(39) || ' - ' || CHR(39) || ' || 
                          MUN.AUX_MUN_NM_MUNICIPIO    || ' || CHR(39) || '/'   || CHR(39) || ' || 
                          MUN.AUX_MUN_SG_UF           || ' || CHR(39) || ' - ' || CHR(39) || ' || 
                          SUBSTR(LPAD(TRIM(ENDE.CAD_END_CD_CEP), 8, ' || CHR(39) || '0' || CHR(39)  || '), 1, 5)     || ' || CHR(39) ||  '-'  || CHR(39) || ' || 
                          SUBSTR(LPAD(TRIM(ENDE.CAD_END_CD_CEP), 8, ' || CHR(39) || '0' || CHR(39)  || '), 6, 3),
                          PES.CAD_PES_NR_CNPJ_CPF ';

 --   dbms_output.put_line(V_SELECT || V_WHERE || V_GROUP);

    OPEN v_cursor FOR
         V_SELECT || V_WHERE || V_GROUP;
    io_cursor := v_cursor;
  end PRC_REP_13_DEMONSTRATIVO_PAGTO;
