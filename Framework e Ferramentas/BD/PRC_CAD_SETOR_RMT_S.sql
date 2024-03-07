create or replace procedure PRC_CAD_SETOR_RMT_S
(
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%type DEFAULT NULL,
     pCAD_SET_CD_SETOR IN TB_CAD_SET_SETOR.CAD_SET_CD_SETOR%type DEFAULT NULL,
     pCAD_SET_DS_SETOR IN TB_CAD_SET_SETOR.CAD_SET_DS_SETOR%type DEFAULT NULL,
     pCAD_SET_NR_TELEFONE IN TB_CAD_SET_SETOR.CAD_SET_NR_TELEFONE%type DEFAULT NULL,
     pCAD_SET_FL_SUBSTALMOX_OK IN TB_CAD_SET_SETOR.CAD_SET_FL_SUBSTALMOX_OK%type DEFAULT NULL,
     pCAD_SET_FL_ESTQPROPRIO_OK IN TB_CAD_SET_SETOR.CAD_SET_FL_ESTQPROPRIO_OK%type DEFAULT NULL,
     pCAD_SET_FL_ATIVO_OK IN TB_CAD_SET_SETOR.CAD_SET_FL_ATIVO_OK%type DEFAULT NULL,
     pCAD_SET_FL_GRAVAATEND_OK IN TB_CAD_SET_SETOR.CAD_SET_FL_GRAVAATEND_OK%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_SET_SETOR.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pCAD_SET_NR_ANDAR IN TB_CAD_SET_SETOR.CAD_SET_NR_ANDAR%type DEFAULT NULL,
     pCAD_SET_DT_ULTIMA_ATUALIZACAO IN TB_CAD_SET_SETOR.CAD_SET_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_SET_SETOR.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_SET_SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
     pCAD_SET_NR_RAMAL IN TB_CAD_SET_SETOR.CAD_SET_NR_RAMAL%type DEFAULT NULL,
     pCAD_SET_DS_PROCEDENCIA IN TB_CAD_SET_SETOR.CAD_SET_DS_PROCEDENCIA%type DEFAULT NULL,
     pCAD_SET_FL_ATENDSERVMUL_OK IN TB_CAD_SET_SETOR.CAD_SET_FL_ATENDSERVMUL_OK%type DEFAULT NULL,
     pCAD_SET_ALMOX_CENTRAL IN TB_CAD_SET_SETOR.CAD_SET_ALMOX_CENTRAL%type DEFAULT NULL,
     pCAD_SET_FL_PERMITEINTERN_OK IN TB_CAD_SET_SETOR.CAD_SET_FL_PERMITEINTERN_OK%type DEFAULT NULL,
     pCAD_SET_FL_PREFERENC_ACS_OK IN TB_CAD_SET_SETOR.CAD_SET_FL_PREFERENC_ACS_OK%type DEFAULT NULL,
     pCAD_SET_FL_MOVIMENTAPACINT_OK IN TB_CAD_SET_SETOR.CAD_SET_FL_MOVIMENTAPACINT_OK%type DEFAULT NULL,
     pCAD_SET_FL_PERMITELIBLEITO_OK IN TB_CAD_SET_SETOR.CAD_SET_FL_PERMITELIBLEITO_OK%type DEFAULT NULL,
     pCAD_SET_FL_LANCATXAUTPORT_OK IN TB_CAD_SET_SETOR.CAD_SET_FL_LANCATXAUTPORT_OK%type DEFAULT NULL,
     pCAD_SET_FL_CONTROLE_PRONT IN TB_CAD_SET_SETOR.CAD_SET_FL_CONTROLE_PRONT%type DEFAULT NULL,
     pCAD_SET_SETOR_FARMACIA IN TB_CAD_SET_SETOR.CAD_SET_SETOR_FARMACIA%type DEFAULT NULL,
     pCAD_SET_CE_SETOR_PAI IN TB_CAD_SET_SETOR.CAD_SET_CE_SETOR_PAI%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
  /********************************************************************
  *    Procedure: PRC_CAD_SETOR_RMT_S  --CADASTRO REMOTING
  *
  *    Data Criacao:   20/07/09   Por: Pedro
  *    Data Alteracao: 07/12/2012 Por: Andre
  *         Alteracao: Adicao do campo pCAD_SET_FL_CONTROLE_PRONT e
  *                    padronizacao da query para string dinamica
  *    Data Alteracao: 25/07/2018 Por: Andre
  *         Alteracao: Adicao do campo CAD_SET_SETOR_FARMACIA
  *
  *    Funcao: Lista setor
  *******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(5000);
  V_SELECT  varchar2(5000);
begin
  V_WHERE := NULL;
IF pCAD_SET_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_ID = ' || pCAD_SET_ID; END IF;
IF pCAD_SET_CD_SETOR IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_CD_SETOR = ' || CHR(39) || pCAD_SET_CD_SETOR || CHR(39); END IF;
IF pCAD_SET_DS_SETOR IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_DS_SETOR = ' || CHR(39) || pCAD_SET_DS_SETOR || CHR(39); END IF;
IF pCAD_SET_NR_TELEFONE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_NR_TELEFONE = ' || CHR(39) || pCAD_SET_NR_TELEFONE || CHR(39); END IF;
IF pCAD_SET_FL_SUBSTALMOX_OK IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_FL_SUBSTALMOX_OK = ' || CHR(39) || pCAD_SET_FL_SUBSTALMOX_OK || CHR(39); END IF;
IF pCAD_SET_FL_ESTQPROPRIO_OK IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_FL_ESTQPROPRIO_OK = ' || CHR(39) || pCAD_SET_FL_ESTQPROPRIO_OK || CHR(39); END IF;
IF pCAD_SET_FL_ATIVO_OK IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_FL_ATIVO_OK = ' || CHR(39) || pCAD_SET_FL_ATIVO_OK || CHR(39); END IF;
IF pCAD_SET_FL_GRAVAATEND_OK IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_FL_GRAVAATEND_OK = ' || CHR(39) || pCAD_SET_FL_GRAVAATEND_OK || CHR(39); END IF;
IF pSEG_USU_ID_USUARIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND SEG_USU_ID_USUARIO = ' || pSEG_USU_ID_USUARIO; END IF;
IF pCAD_SET_NR_ANDAR IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_NR_ANDAR = ' || pCAD_SET_NR_ANDAR; END IF;
IF pCAD_SET_DT_ULTIMA_ATUALIZACAO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_DT_ULTIMA_ATUALIZACAO = ' || CHR(39) || pCAD_SET_DT_ULTIMA_ATUALIZACAO || CHR(39); END IF;
IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO; END IF;
IF pCAD_SET_NR_RAMAL IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_NR_RAMAL = ' || pCAD_SET_NR_RAMAL; END IF;
IF pCAD_SET_DS_PROCEDENCIA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_DS_PROCEDENCIA = ' || CHR(39) || pCAD_SET_DS_PROCEDENCIA || CHR(39); END IF;
IF pCAD_SET_FL_ATENDSERVMUL_OK IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_FL_ATENDSERVMUL_OK = ' || CHR(39) || pCAD_SET_FL_ATENDSERVMUL_OK || CHR(39); END IF;
IF pCAD_SET_ALMOX_CENTRAL IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_ALMOX_CENTRAL = ' || pCAD_SET_ALMOX_CENTRAL; END IF;
IF pCAD_SET_FL_PERMITEINTERN_OK IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_FL_PERMITEINTERN_OK = ' || CHR(39) || pCAD_SET_FL_PERMITEINTERN_OK || CHR(39); END IF;
IF pCAD_SET_FL_PREFERENC_ACS_OK IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_FL_PREFERENC_ACS_OK = ' || CHR(39) || pCAD_SET_FL_PREFERENC_ACS_OK || CHR(39); END IF;
IF pCAD_SET_FL_MOVIMENTAPACINT_OK IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_FL_MOVIMENTAPACINT_OK = ' || CHR(39) || pCAD_SET_FL_MOVIMENTAPACINT_OK || CHR(39); END IF;
IF pCAD_SET_FL_PERMITELIBLEITO_OK IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_FL_PERMITELIBLEITO_OK = ' || CHR(39) || pCAD_SET_FL_PERMITELIBLEITO_OK || CHR(39); END IF;
IF pCAD_SET_FL_LANCATXAUTPORT_OK IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_FL_LANCATXAUTPORT_OK = ' || CHR(39) || pCAD_SET_FL_LANCATXAUTPORT_OK || CHR(39); END IF;
IF pCAD_SET_FL_CONTROLE_PRONT IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_FL_CONTROLE_PRONT = ' || CHR(39) || pCAD_SET_FL_CONTROLE_PRONT || CHR(39); END IF;
IF pCAD_SET_SETOR_FARMACIA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_SETOR_FARMACIA = ' || CHR(39) || pCAD_SET_SETOR_FARMACIA || CHR(39); END IF;
IF pCAD_SET_CE_SETOR_PAI IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND CAD_SET_CE_SETOR_PAI = ' || CHR(39) || pCAD_SET_CE_SETOR_PAI || CHR(39); END IF;
V_WHERE:= V_WHERE || ' ORDER BY CAD_SET_DS_SETOR ';
   V_SELECT := '
SELECT CAD_SET_ID,
       CAD_SET_CD_SETOR,
       CAD_SET_DS_SETOR,
       CAD_SET_NR_TELEFONE,
       CAD_SET_FL_SUBSTALMOX_OK,
       CAD_SET_FL_ESTQPROPRIO_OK,
       CAD_SET_FL_ATIVO_OK,
       CAD_SET_FL_GRAVAATEND_OK,
       SEG_USU_ID_USUARIO,
       CAD_SET_NR_ANDAR,
       CAD_SET_DT_ULTIMA_ATUALIZACAO,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_SET_NR_RAMAL,
       CAD_SET_DS_PROCEDENCIA,
       CAD_SET_FL_ATENDSERVMUL_OK,
       CAD_SET_UNIDADE_ALMOX,
       CAD_SET_LOCAL_ALMOX,
       CAD_SET_SETOR_ALMOX,
       CAD_SET_ALMOX_CENTRAL,
       CAD_SET_FL_PERMITEINTERN_OK,
       CAD_SET_FL_PREFERENC_ACS_OK,
       CAD_SET_FL_MOVIMENTAPACINT_OK,
       CAD_SET_FL_PERMITELIBLEITO_OK,
       CAD_SET_FL_LANCATXAUTPORT_OK,
       CAD_SET_NR_IP,
       CAD_SET_NR_PORTA,
       CAD_SET_FL_CONTROLE_PRONT,
       CAD_SET_SETOR_FARMACIA,
       CAD_SET_CE_SETOR_PAI
FROM TB_CAD_SET_SETOR
WHERE null is null  ';
OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
end PRC_CAD_SETOR_RMT_S;