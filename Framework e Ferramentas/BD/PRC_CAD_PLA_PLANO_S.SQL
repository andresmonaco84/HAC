CREATE OR REPLACE PROCEDURE "PRC_CAD_PLA_PLANO_S"
  (
     pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO in TB_CAD_PLA_PLANO.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     pCAD_PLA_CD_PLANO_HAC IN TB_CAD_PLA_PLANO.CAD_PLA_CD_PLANO_HAC%type DEFAULT NULL,
     pCAD_PLA_FL_SITUACAO_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_FL_SITUACAO_PLANO%type DEFAULT NULL,
     pCAD_PLA_CD_PLANO in TB_CAD_PLA_PLANO.CAD_PLA_CD_PLANO%type DEFAULT NULL,
     pCAD_PLA_NM_NOME_PLANO in TB_CAD_PLA_PLANO.CAD_PLA_NM_NOME_PLANO%type DEFAULT NULL,
     pCAD_PLA_CD_TIPOPLANO IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PLA_PLANO_S
  *
  *    Data Criacao: 	26/06/2007   Por: Ricardo costa
  *    Funcao: Lista registro do plano
  *
  *    Data Alteracao: 16/08/2007  Por: Andrea Cazuca
  *    Alteracao: Incluido o Status como parametro
  *
  *    Data Alteracao: 29/08/2007   Por: Andrea Cazuca
  *    Alteracao: Incluido o campo CAD_PLA_FL_EXIGE_GUIA
  *
  *    Data Alteracao: 14/09/2007   Por: Andrea Cazuca
  *    Alteracao: Incluido o campo CAD_PLA_CD_PLANO e CAD_PLA_NM_NOME_PLANO
  *
  *	   Data Alterac?o: 24/10/2007	Por: Fabiola Lopes
  *	   Alterac?o: Incluido upper no CD_PLANO
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alterac?o: Remoc?o de Upper em campo, no where
  *
  *    Data Alterac?o:  20/11/2007 Por: Guilherme
  *    Alterac?o: Inclus?o do filtro por tipo de plano
  *
  *    Data Alterac?o:  14/02/2008 Por: Andrea Cazuca
  *    Alterac?o: Inclus?o dos campo CAD_PLA_FL_EXIGE_SENHA_LIB_OK e
  *               CAD_PLA_FL_LIBERA_EXAME_OK
  *
  *	   Data Alterac?o: 29/02/2008 Por: Bruno Alvares
  *	   Alterac?o: Inclus?o do campo CAD_PLA_DS_ORIENTACAO
  *
  *	   Data Alterac?o: 29/07/2008	Por: Fabiola Lopes
  *	   Alterac?o:	   Inclus?o do "order by" pelo nome do plano
  *
  *    Data Alteracao: 17/06/2009          Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusao do campo CAD_PLA_FL_AUTORIZA_ONLINE
  *
  *    Data Alteracao: 07/10/2009          Por: Alexandre M. Muniz
  *    Alteracao: Inclusao dos campos CAD_PLA_FL_COB_AMBULANCIA
  *                                   CAD_PLA_FL_COB_ACID_TRAB
  *                                   CAD_PLA_FL_COB_REFEI_ACOMP
  *                                   CAD_PLA_FL_COB_ACOMPANHA
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
/*
    IF pCAD_PLA_DT_FIM_VIGENCIA IS NOT NULL THEN
       V_WHERE:= V_WHERE || ' AND CAD_PLA_DT_FIM_VIGENCIA = ' || CHR(39) || pCAD_PLA_DT_FIM_VIGENCIA || CHR(39); END IF;
*/
    IF pCAD_PLA_ID_PLANO IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CAD_PLA_ID_PLANO = ' || pCAD_PLA_ID_PLANO; END IF;
    IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO; END IF;
    IF pCAD_PLA_CD_PLANO_HAC IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CAD_PLA_CD_PLANO_HAC = ' || CHR(39) || UPPER(pCAD_PLA_CD_PLANO_HAC) || CHR(39); END IF;
    IF pCAD_PLA_FL_SITUACAO_PLANO IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CAD_PLA_FL_SITUACAO_PLANO = ' || CHR(39) || pCAD_PLA_FL_SITUACAO_PLANO || CHR(39); END IF;
    IF pCAD_PLA_CD_PLANO IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CAD_PLA_CD_PLANO = ' || CHR(39) || UPPER(pCAD_PLA_CD_PLANO) || CHR(39); END IF;
    IF pCAD_PLA_CD_TIPOPLANO IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CAD_PLA_CD_TIPOPLANO = ' || CHR(39) || UPPER(pCAD_PLA_CD_TIPOPLANO) || CHR(39); END IF;
    IF pCAD_PLA_NM_NOME_PLANO IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND CAD_PLA_NM_NOME_PLANO LIKE ' || CHR(39) || UPPER(pCAD_PLA_NM_NOME_PLANO) || CHR(39); END IF;

    V_WHERE := V_WHERE || ' order by CAD_PLA_NM_NOME_PLANO';

    V_SELECT := 'SELECT
                       CAD_PLA_ID_PLANO,
                       CAD_PLA_CD_PLANO_HAC,
                       CAD_PLA_CD_PLANO,
                       CAD_PLA_CD_TIPOPLANO,
                       CAD_PLA_NM_NOME_PLANO,
                       CAD_PLA_FL_SITUACAO_PLANO,
                       CAD_CNV_ID_CONVENIO,
                       CAD_PLA_DT_ULT_ATUALIZACAO,
                       SEG_USU_ID_USUARIO,
                       CAD_PLA_DT_INICIO_VIGENCIA,
                       CAD_PLA_DT_FIM_VIGENCIA,
                       CAD_PLA_DS_OBS_FIM_VIG,
                       CAD_PLA_FL_EXIGE_GUIA,
                       CAD_PLA_FL_EXIGE_SENHA_LIB_OK,
                       CAD_PLA_FL_LIBERA_EXAME_OK,
                       CAD_PLA_DS_ORIENTACAO,
                       CAD_PLA_FL_AUTORIZA_ONLINE,
                       CAD_PLA_FL_COB_AMBULANCIA,
                       CAD_PLA_FL_COB_ACID_TRAB,
                       CAD_PLA_FL_COB_REFEI_ACOMP,
                       CAD_PLA_FL_COB_ACOMPANHA,
                       CAD_PLA_CT_CATEGORIA_PLANO
                    FROM TB_CAD_PLA_PLANO PLA
                    WHERE 1 = 1 ';

   V_SELECT := V_SELECT || V_WHERE;
    OPEN v_cursor FOR
      V_SELECT;
      io_cursor := v_cursor;

  end PRC_CAD_PLA_PLANO_S;

 