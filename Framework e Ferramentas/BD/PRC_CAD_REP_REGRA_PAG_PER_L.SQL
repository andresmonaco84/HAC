create or replace procedure PRC_CAD_REP_REGRA_PAG_PER_L
(
     pCAD_REP_ID IN TB_CAD_REP_REGRA_PAGAMENTO.CAD_REP_ID%type,
     pCAD_REP_TP_BASE_CALCULO TB_CAD_REP_REGRA_PAGAMENTO.CAD_REP_TP_BASE_CALCULO%TYPE,
     pFLAG_VIGENTE STRING,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_CAD_REP_REGRA_PAG_PER_L
*
*    Data Criacao:   data da  criação   Por: Nome do Analista
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
V_CURSOR     PKG_CURSOR.t_cursor;
V_WHERE      VARCHAR2(6000);
V_SELECT     VARCHAR2(8000);

BEGIN

IF pFLAG_VIGENTE = 'S' THEN
   V_WHERE := V_WHERE || ' AND (REP.CAD_REP_DT_FIM_VIGENCIA IS NULL 
                            OR TO_DATE(REP.CAD_REP_DT_FIM_VIGENCIA, '|| CHR(39) ||'dd/mm/yyyy'|| CHR(39) ||') >= 
                               TO_DATE(SYSDATE, '|| CHR(39) ||'dd/mm/yyyy'|| CHR(39) ||')) ';
END IF;

IF pCAD_REP_ID IS NOT NULL THEN
  V_WHERE := V_WHERE || ' AND REP.CAD_REP_ID = ' || pCAD_REP_ID;
END IF;

IF pCAD_REP_TP_BASE_CALCULO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND REP.CAD_REP_TP_BASE_CALCULO = '||CHR(39)||pCAD_REP_TP_BASE_CALCULO||CHR(39);
END IF;  

V_SELECT := '
SELECT REP.CAD_REP_ID,
       REP.CAD_REP_NM_REGRA,

       REP.CAD_PRD_ID,
       DECODE(PRD.CAD_PRD_DS_DESCRICAO, NULL, '|| CHR(39) ||'TODOS'|| CHR(39) ||', PRD.CAD_PRD_DS_DESCRICAO) CAD_PRD_DS_DESCRICAO,
       PRD.CAD_PRD_CD_CODIGO,

       REP.TIS_MED_CD_TABELAMEDICA,
       DECODE(MED.TIS_MED_DS_TABELAMEDICA, NULL, '|| CHR(39) ||'TODAS'|| CHR(39) ||', MED.TIS_MED_DS_TABELAMEDICA) TIS_MED_DS_TABELAMEDICA,

       REP.AUX_EPP_CD_ESPECPROC,
       DECODE(EPP.AUX_EPP_DS_DESCRICAO, NULL, '|| CHR(39) ||'TODOS'|| CHR(39) ||', EPP.AUX_EPP_DS_DESCRICAO) AUX_EPP_DS_DESCRICAO,

       REP.AUX_GPC_CD_GRUPOPROC,
       DECODE(GPC.AUX_GPC_DS_DESCRICAO, NULL, '|| CHR(39) ||'TODOS'|| CHR(39) ||', GPC.AUX_GPC_DS_DESCRICAO) AUX_GPC_DS_DESCRICAO,

       REP.CAD_REP_VL_PAGTO,
       REP.CAD_REP_VL_MINIMO,
       REP.CAD_REP_QT_INDICE,
       REP.CAD_REP_PC_REPASSE,
       DECODE(REP.CAD_REP_TP_BASE_CALCULO, '|| CHR(39) ||'CHCNV'|| CHR(39) ||'     , '|| CHR(39) ||'C.H. - CONVÊNIO'|| CHR(39) ||',
                                           '|| CHR(39) ||'VLCAL'|| CHR(39) ||'     , '|| CHR(39) ||'% VALOR CALCULADO'|| CHR(39) ||',
                                           '|| CHR(39) ||'VLFIX'|| CHR(39) ||'     , '|| CHR(39) ||'VALOR FIXO'|| CHR(39) ||',
                                           '|| CHR(39) ||'VLHRPLANT'|| CHR(39) ||' , '|| CHR(39) ||'VALOR HORA PLANTAO'|| CHR(39) ||',
                                           '|| CHR(39) ||'VLHORA'|| CHR(39) ||'    , '|| CHR(39) ||'VALOR HORA'|| CHR(39) ||',
                                           '|| CHR(39) ||'CHFIX'|| CHR(39) ||'     , '|| CHR(39) ||'C.H. - FIXO'|| CHR(39) ||',
                                           '|| CHR(39) ||'VLFIA'|| CHR(39) ||'     , '|| CHR(39) ||'VALOR FIXO POR ATENDIMENTO'|| CHR(39) ||',
                                           '|| CHR(39) ||'VLFIXOPROF'|| CHR(39) ||', '|| CHR(39) ||'VALOR FIXO POR PROFISSIONAL'|| CHR(39) ||')       CAD_REP_TP_BASE_CALCULO,
       REP.CAD_REP_CD_TIPO_EXTRA,
       REP.CAD_REP_VL_PAGTO_FIXO,
       REP.CAD_REP_DT_INICIO_VIGENCIA,
       REP.CAD_REP_DT_FIM_VIGENCIA,
       REP.CAD_REP_FL_PAGO_HORA,
       REP.CAD_REP_FL_PAGO_PLANTAO,
       REP.CAD_REP_VL_PAGTO_EXTRA,
       REP.CAD_REP_VL_INDICE_HOSP,
       REP.CAD_REP_FL_MENSAL,
       REP.CAD_REP_FL_EXTRA_SAB,
       REP.CAD_REP_FL_EXTRA_DOM,
       REP.CAD_REP_FL_EXTRA_FER,
       REP.CAD_REP_PC_RETENCAO,
       REP.TIS_TAC_CD_TIPO_ACOMOD_AUT,
       TAC.TIS_TAC_DS_TIPO_ACOMODACAO,
       REP.CAD_REP_VL_MINIMO,
       REP.SEG_USU_ID_USUARIO,
       REP.CAD_REP_DT_ULTIMA_ATUALIZACAO,
       REP.CAD_REP_DT_CRIACAO,
       REP.SEG_USU_ID_USUARIO_CRIACAO,
       REP.CAD_REP_DS_COMPLEMENTAR

  FROM TB_CAD_REP_REGRA_PAGAMENTO REP,
       TB_CAD_PRD_PRODUTO         PRD,
       TB_TIS_MED_TABELAMEDICA    MED,
       TB_AUX_EPP_ESPECPROC       EPP,
       TB_AUX_GPC_GRUPOPROC       GPC,
       TB_TIS_TAC_TIPO_ACOMODACAO TAC

 WHERE REP.CAD_PRD_ID = PRD.CAD_PRD_ID(+)
   AND REP.TIS_MED_CD_TABELAMEDICA = MED.TIS_MED_CD_TABELAMEDICA(+)
   AND REP.AUX_EPP_CD_ESPECPROC = EPP.AUX_EPP_CD_ESPECPROC(+)
   AND REP.TIS_MED_CD_TABELAMEDICA = EPP.TIS_MED_CD_TABELAMEDICA(+)
   AND REP.AUX_GPC_CD_GRUPOPROC = GPC.AUX_GPC_CD_GRUPOPROC(+)
   AND REP.AUX_EPP_CD_ESPECPROC = GPC.AUX_EPP_CD_ESPECPROC(+)
   AND REP.TIS_MED_CD_TABELAMEDICA = GPC.TIS_MED_CD_TABELAMEDICA(+)
   AND REP.TIS_TAC_CD_TIPO_ACOMOD_AUT = TAC.TIS_TAC_CD_TIPO_ACOMODACAO(+) ';

  OPEN V_CURSOR FOR V_SELECT || V_WHERE;
       -- DBMS_OUTPUT.put_line(V_SELECT || V_WHERE);
  IO_CURSOR := V_CURSOR;
  
end PRC_CAD_REP_REGRA_PAG_PER_L;