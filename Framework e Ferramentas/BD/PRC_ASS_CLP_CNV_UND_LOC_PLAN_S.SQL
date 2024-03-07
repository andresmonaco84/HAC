CREATE OR REPLACE PROCEDURE "PRC_ASS_CLP_CNV_UND_LOC_PLAN_S"
  (
     pASS_CLP_ID IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_ID%type DEFAULT NULL,
     pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT null,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_CUL_CONV_UNI_LOCATEND.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CLP_CNV_UND_LOC_PLAN_S
  *
  *    Data Criacao: 	26/06/2007   Por: Andrea Cazuca
  *    Data Alteracao: 23/10/2008	 Por: Cristiane Gomes
  *    Funcao: Seleciona o Local de Atendimento por Convenio Plano
  *
  *    Alteracao: 1) Estava trazendo todas as associac?es independete do plano
  *               acrescentei ID do plano para filtrar por plano
  *               2) Inclus?o de campo ASS_CLP_FL_BLOQUEIA_UNIDADE_OK
  *               3) Considerar a vigencia da associac?o
  *               4) Desconsiderar os parametros nulos e nao usar OR
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE VARCHAR2(2000);
  V_SELECT VARCHAR2(2000);
  begin
    V_WHERE := NULL;
    IF pASS_CLP_ID IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CLP.ASS_CLP_ID = ' || pASS_CLP_ID;
    END IF;
    IF pCAD_PLA_ID_PLANO IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CLP.CAD_PLA_ID_PLANO = ' || pCAD_PLA_ID_PLANO;
    END IF;
    IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CNU.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE;
    END IF;
    IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CUL.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO;
    END IF;
    IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CNV.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO;
    END IF;
    V_SELECT := 'SELECT
         CLP.ASS_CLP_ID,
         CLP.ASS_CUL_ID,
         CLP.ASS_CLP_DT_INI_VIGENCIA,
         CLP.ASS_CLP_DT_FIM_VIGENCIA,
         CLP.CAD_PLA_ID_PLANO,
         CLP.ASS_CLP_FL_BLOQUEIA_UNIDADE_OK,
         CLP.ASS_CLP_DT_ULTIMA_ATUALIZACAO,
         CLP.SEG_USU_ID_USUARIO
    FROM TB_ASS_CLP_CNV_UND_LOC_PLANO CLP,
         TB_ASS_CUL_CONV_UNI_LOCATEND CUL,
         TB_ASS_CNU_CONVENIO_UNIDADE CNU,
         TB_CAD_CNV_CONVENIO CNV,
         TB_CAD_UNI_UNIDADE UNI
    WHERE
          CLP.ASS_CUL_ID = CUL.ASS_CUL_ID
    AND   CUL.ASS_CNU_ID = CNU.ASS_CNU_ID
    AND   CNV.CAD_CNV_ID_CONVENIO = CNU.CAD_CNV_ID_CONVENIO
    AND   UNI.CAD_UNI_ID_UNIDADE = CNU.CAD_UNI_ID_UNIDADE
    AND   (CLP.ASS_CLP_DT_FIM_VIGENCIA IS NULL OR TRUNC(CLP.ASS_CLP_DT_FIM_VIGENCIA) >= TRUNC(SYSDATE))
    '|| V_WHERE ||'
    ORDER BY UNI.CAD_UNI_DS_UNIDADE, CLP.ASS_CLP_DT_INI_VIGENCIA ASC'
    ;
    OPEN v_cursor FOR
    V_SELECT;
    io_cursor := v_cursor;
  end PRC_ASS_CLP_CNV_UND_LOC_PLAN_S;
 