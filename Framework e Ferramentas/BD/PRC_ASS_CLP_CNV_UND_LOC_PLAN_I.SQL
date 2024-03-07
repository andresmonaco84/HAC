create or replace procedure PRC_ASS_CLP_CNV_UND_LOC_PLAN_I
  (
     pNewIdt OUT integer,
     pASS_CUL_ID IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CUL_ID%type,
     pASS_CLP_DT_INI_VIGENCIA IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_DT_INI_VIGENCIA%type,
     pASS_CLP_DT_FIM_VIGENCIA IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_DT_FIM_VIGENCIA%type DEFAULT NULL,
     pASS_CLP_FL_BLOQUEIA_UNID_OK IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_FL_BLOQUEIA_UNIDADE_OK%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_CLP_CNV_UND_LOC_PLANO.CAD_PLA_ID_PLANO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CLP_CNV_UND_LOC_PLANO.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CLP_CNV_UND_LOC_PLAN_I
  *
  *    Data Criacao: 	26/06/2007   Por: Andrea Cazuca
  *    Data Alteracao:				 Por:
  *
  *    Funcao: Insere Local de Atendimento para Convenio X Plano
  *
  *    Data Alteracao:	16/07/07     Por: Fabiola Lopes
  *    Alterac?o:		Acerto do raise_application de -30000 para -20000
  *
  *    Data Alterac?o:  29/09/2007   Por: Carlos Araujo
  *    Alterac?o: Inclus?o de campo ASS_CLP_FL_BLOQUEIA_UNIDADE_OK
  *******************************************************************/
    lIdtRetorno integer;
    nCount integer;

  begin

    SELECT COUNT(*)
    INTO   nCount
    FROM   TB_ASS_CLP_CNV_UND_LOC_PLANO
    WHERE  (
           ((pASS_CLP_DT_INI_VIGENCIA >= ASS_CLP_DT_INI_VIGENCIA AND ASS_CLP_DT_FIM_VIGENCIA IS NULL)
    OR     (pASS_CLP_DT_INI_VIGENCIA BETWEEN ASS_CLP_DT_INI_VIGENCIA AND ASS_CLP_DT_FIM_VIGENCIA))
           OR (ASS_CLP_DT_FIM_VIGENCIA IS NULL)
           )
    AND    ASS_CUL_ID = pASS_CUL_ID
    AND    CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO;

    IF nCount > 0 then
       raise_application_error (-20000, 'Ja existe Associac?o neste periodo');
    END IF;

    SELECT SEQ_ASS_CLP_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_ASS_CLP_CNV_UND_LOC_PLANO
    (
       ASS_CLP_ID,
       ASS_CUL_ID,
       ASS_CLP_DT_INI_VIGENCIA,
       ASS_CLP_DT_FIM_VIGENCIA,
       CAD_PLA_ID_PLANO,
       ASS_CLP_FL_BLOQUEIA_UNIDADE_OK,
       ASS_CLP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
	     lIdtRetorno,
	     pASS_CUL_ID,
	     pASS_CLP_DT_INI_VIGENCIA,
	     pASS_CLP_DT_FIM_VIGENCIA,
	     pCAD_PLA_ID_PLANO,
       pASS_CLP_FL_BLOQUEIA_UNID_OK,
       SYSDATE,
       pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;
  end PRC_ASS_CLP_CNV_UND_LOC_PLAN_I;
 