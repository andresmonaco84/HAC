CREATE OR REPLACE PROCEDURE "PRC_REP_REL_SINT_PAGTO_MEDICO"
  (
     pREP_PGM_MES_PAGTO_INI         IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%type,
     pREP_PGM_ANO_PAGTO_INI         IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%type,
     pREP_PGM_MES_PAGTO_FIM                IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE DEFAULT NULL,
     pREP_PGM_ANO_PAGTO_FIM                IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE DEFAULT NULL,
     pCAD_CLC_ID                    IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%TYPE,
     PCAD_UNI_ID_UNIDADE            IN STRING DEFAULT NULL,
     pREP_PGM_TP_CREDENCIA_PROF     IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_TP_CREDENCIA_PROF%TYPE DEFAULT NULL,
     io_cursor                      OUT PKG_CURSOR.t_cursor
  )
  is
/********************************************************************
*    Procedure: PRC_REP_REL_SINT_PAGTO_MEDICO
*
*    Data Criacao:    06/08/2012           Por: Fabiola Lopes
*    Data Alteracao:  data da altera??o  Por: Nome do Analista
*    Data: 06/09/2012: Elimina??o da tabela BCP do select e
*                      substitui??o de BCP.REP_BCP_DS_BASE_CALCULO,
*                      pela linha: (select distinct BCP.REP_BCP_DS_BASE_CALCULO
*                                   from TB_CAD_REP_BCP_BASE_CALCULO BCP
*                         where bcp.cad_rep_tp_base_calculo = REP.CAD_REP_TP_BASE_CALCULO)
*
*                      Inclus?o das cl?usulas WHERE:
*                                                   AND PGM.REP_PGM_FL_PAGO IN ('F','P')
*                                                   AND PGM.REP_PGM_FL_STATUS = 'A'
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  VARCHAR2(30000);
  V_SELECT VARCHAR2(10000);
  V_GROUP  VARCHAR2(10000);
  V_REP_PGM_TP_CREDENCIA_PROF VARCHAR2(1000);
  BEGIN
    IF (PREP_PGM_TP_CREDENCIA_PROF IS NULL) THEN
     V_REP_PGM_TP_CREDENCIA_PROF := 'NULL';
    ELSE
     V_REP_PGM_TP_CREDENCIA_PROF := CHR(39) || PREP_PGM_TP_CREDENCIA_PROF || CHR(39);
    END IF;
    IF pREP_PGM_MES_PAGTO_FIM IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND ((PGM.REP_PGM_MES_PAGTO + PGM.REP_PGM_ANO_PAGTO * 100) <= ('|| TO_CHAR(pREP_PGM_MES_PAGTO_FIM + pREP_PGM_ANO_PAGTO_FIM * 100) || '))';
    ELSE
       V_WHERE := V_WHERE || ' AND ((PGM.REP_PGM_MES_PAGTO + PGM.REP_PGM_ANO_PAGTO * 100) <= ('|| TO_CHAR(pREP_PGM_MES_PAGTO_INI + pREP_PGM_ANO_PAGTO_INI * 100) || '))';
    END IF;
    IF pCAD_CLC_ID IS NOT NULL THEN
       V_WHERE:= V_WHERE || ' AND PGM.CAD_CLC_ID = ' || pCAD_CLC_ID;
    END IF;
    IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN
       V_WHERE:= V_WHERE || ' AND PGM.CAD_UNI_ID_UNIDADE IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || pCAD_UNI_ID_UNIDADE || ''' ))) ';
    END IF;
    IF pREP_PGM_TP_CREDENCIA_PROF IS NOT NULL THEN
     V_WHERE:= V_WHERE || ' AND PGM.REP_PGM_TP_CREDENCIA_PROF = ' || CHR(39) ||  pREP_PGM_TP_CREDENCIA_PROF || CHR(39);
    END IF;
    V_SELECT := 'SELECT  CLC.CAD_CLC_ID,
                         CLC.CAD_CLC_CD_CLINICA,
                         CLC.CAD_CLC_DS_DESCRICAO,
                         UNI.CAD_UNI_CD_UNID_HOSPITALAR,
                         UNI.CAD_UNI_DS_UNIDADE,
                         PES.CAD_PES_NR_CNPJ_CPF,
                         PGM.REP_PGM_MES_PAGTO,
                         PGM.REP_PGM_ANO_PAGTO,
                         PGM.REP_PGM_TP_CREDENCIA_PROF,
                         FNC_REP_REL_SUB_VLHR_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                     ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                          PGM.CAD_CLC_ID,
                                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                     ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                     ' || PREP_PGM_ANO_PAGTO_FIM || ') SEMVLHORA,
                                                     
                         FNC_REP_REL_SUB_VLHREX_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                       ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                            PGM.CAD_CLC_ID,
                                                            PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') SEMVLHORAEXTRA,


                         FNC_REP_REL_SUB_VLHR_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                     ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                          PGM.CAD_CLC_ID,
                                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                     ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                     ' || PREP_PGM_ANO_PAGTO_FIM || ') VLHORA,

                         FNC_REP_REL_SUB_VLHREX_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                       ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                            PGM.CAD_CLC_ID,
                                                            PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') VLHORAEXTRA,


                         FNC_REP_REL_SUB_VLACRES_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                        ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                             PGM.CAD_CLC_ID,
                                                             PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                        ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                        ' || PREP_PGM_ANO_PAGTO_FIM || ') VLACRESCIMO_SANTEC,

                         FNC_REP_REL_SUB_VLDESC_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                       ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                            PGM.CAD_CLC_ID,
                                                            PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') VLDESCONTO_SANTEC,


                         FNC_REP_REL_SUB_VLACRES_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                        ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                             PGM.CAD_CLC_ID,
                                                             PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                        ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                        ' || PREP_PGM_ANO_PAGTO_FIM || ') VLACRESCIMO_CANTEC,

                         FNC_REP_REL_SUB_VLDESC_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                       ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                            PGM.CAD_CLC_ID,
                                                            PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') VLDESCONTO_CANTEC,


                         FNC_REP_REL_SUB_VLHR_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                     ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                          PGM.CAD_CLC_ID,
                                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                     ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                     ' || PREP_PGM_ANO_PAGTO_FIM || ') +
                         FNC_REP_REL_SUB_VLACRES_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                        ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                             PGM.CAD_CLC_ID,
                                                             PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                        ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                        ' || PREP_PGM_ANO_PAGTO_FIM || ') -
                         FNC_REP_REL_SUB_VLDESC_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                       ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                            PGM.CAD_CLC_ID,
                                                            PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') VLPARCIAL_SANTEC,


                         FNC_REP_REL_SUB_VLHR_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                     ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                          PGM.CAD_CLC_ID,
                                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                     ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                     ' || PREP_PGM_ANO_PAGTO_FIM || ') +

                         FNC_REP_REL_SUB_VLACRES_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                        ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                             PGM.CAD_CLC_ID,
                                                             PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                        ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                        ' || PREP_PGM_ANO_PAGTO_FIM || ') -

                         FNC_REP_REL_SUB_VLDESC_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                       ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                            PGM.CAD_CLC_ID,
                                                            PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') VLPARCIAL_CANTEC,
                         SUM(NVL(PGM.REP_PGM_QT_CONSUMO, 0)) TOTAL_CONSUMO,
                         SUM(NVL(PGM.REP_PGM_VL_PAGO, 0)) TOTAL_VALOR_PAGO,
                         SUM(NVL(PGM.REP_PGM_VL_CALCULADO, 0)) TOTAL_VALOR_CALCULADO
                    FROM TB_REP_PGM_PAGTO_MEDICO PGM,
                         TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
                         TB_CAD_UNI_UNIDADE UNI,
                         TB_CAD_PES_PESSOA PES
                   WHERE PGM.CAD_CLC_ID = CLC.CAD_CLC_ID
                     AND PGM.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
                     AND UNI.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
                     AND PGM.REP_PGM_FL_STATUS =  ' || CHR(39) || 'A' || CHR(39) ||'
                     AND PGM.REP_PGM_FL_PAGO IN ( ' || CHR(39) || 'F' || CHR(39) ||' , '
                                                    || CHR(39) || 'P' || CHR(39) ||')
                     AND PGM.REP_PGM_MES_PAGTO = ' || pREP_PGM_MES_PAGTO_INI || '
                     AND PGM.REP_PGM_ANO_PAGTO = ' || pREP_PGM_ANO_PAGTO_INI ;
    V_GROUP := ' GROUP BY CLC.CAD_CLC_ID,
                          CLC.CAD_CLC_CD_CLINICA,
                          CLC.CAD_CLC_DS_DESCRICAO,
                          UNI.CAD_UNI_CD_UNID_HOSPITALAR,
                          UNI.CAD_UNI_DS_UNIDADE,
                          PES.CAD_PES_NR_CNPJ_CPF,
                          PGM.REP_PGM_MES_PAGTO,
                          PGM.REP_PGM_ANO_PAGTO,
                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                          FNC_REP_REL_SUB_VLHR_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                      ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                           PGM.CAD_CLC_ID,
                                                           PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                      ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                      ' || PREP_PGM_ANO_PAGTO_FIM || '),

                          FNC_REP_REL_SUB_VLHREX_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                        ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                             PGM.CAD_CLC_ID,
                                                             PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                        ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                        ' || PREP_PGM_ANO_PAGTO_FIM || '),


                          FNC_REP_REL_SUB_VLHR_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                      ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                           PGM.CAD_CLC_ID,
                                                           PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                     ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                     ' || PREP_PGM_ANO_PAGTO_FIM || '),

                          FNC_REP_REL_SUB_VLHREX_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                        ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                             PGM.CAD_CLC_ID,
                                                             PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || '),


                          FNC_REP_REL_SUB_VLACRES_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                              PGM.CAD_CLC_ID,
                                                              PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || '),

                          FNC_REP_REL_SUB_VLDESC_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                        ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                             PGM.CAD_CLC_ID,
                                                             PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || '),


                          FNC_REP_REL_SUB_VLACRES_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                              PGM.CAD_CLC_ID,
                                                              PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || '),

                          FNC_REP_REL_SUB_VLDESC_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                        ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                        PGM.CAD_CLC_ID,
                                                        PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || '),


                          FNC_REP_REL_SUB_VLHR_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                      ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                           PGM.CAD_CLC_ID,
                                                           PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') +
                         
     FNC_REP_REL_SUB_VLACRES_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                              PGM.CAD_CLC_ID,
                                                              PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') -

                          FNC_REP_REL_SUB_VLDESC_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                        ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                             PGM.CAD_CLC_ID,
                                                             PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || '),


                          FNC_REP_REL_SUB_VLHR_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                      ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                           PGM.CAD_CLC_ID,
                                                           PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') +

                          FNC_REP_REL_SUB_VLACRES_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                              PGM.CAD_CLC_ID,
                                                              PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') -

                          FNC_REP_REL_SUB_VLDESC_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                                        ' || PREP_PGM_ANO_PAGTO_INI || ',
                                                             PGM.CAD_CLC_ID,
                                                             PGM.REP_PGM_TP_CREDENCIA_PROF,
                                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                                       ' || PREP_PGM_ANO_PAGTO_FIM || ')';
    dbms_output.put_line(V_SELECT || V_WHERE || V_GROUP);
    OPEN v_cursor FOR
         V_SELECT || V_WHERE || V_GROUP;
    io_cursor := v_cursor;
  end PRC_REP_REL_SINT_PAGTO_MEDICO;