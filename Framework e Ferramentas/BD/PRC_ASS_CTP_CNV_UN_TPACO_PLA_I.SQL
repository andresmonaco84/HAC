create or replace procedure PRC_ASS_CTP_CNV_UN_TPACO_PLA_I
  (
     pNewIdt OUT integer,
     pASS_CUT_ID IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CUT_ID%type,
     pASS_CTP_DT_INI_VIGENCIA IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_DT_INI_VIGENCIA%type,
     pASS_CTP_DT_FIM_VIGENCIA IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_DT_FIM_VIGENCIA%type DEFAULT NULL,
     pCAD_PLA_ID_PLANO IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.CAD_PLA_ID_PLANO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pASS_CTP_PC_HM_ACOMODACAO IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_PC_HM_ACOMODACAO%type DEFAULT NULL,
     pASS_CTP_PC_HM_ARTROSCOPIA IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_PC_HM_ARTROSCOPIA%type DEFAULT NULL,
     pASS_CTP_PC_HM_LAPAROSCOPIA IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_PC_HM_LAPAROSCOPIA%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CTP_CNV_UN_TPACO_PLA_I
  *
  *    Data Criacao: 	28/06/2007   Por: Andrea Cazuca
  *    Funcao: Insere a Associacao de Convenio X Plano X Tipo Acomodacao
  *
  *	   Data Alteracao: 16/07/07      Por: Fabiola Lopes
  *    Funcao: Alteracao do raise_application_erro de -30000 para -20000
  *
  *    Data Alteracao: 16/08/2010    Por: Rafael Coimbra
  *    Funcao: Incluidos os campos ASS_CTP_PC_HM_ACOMODACAO, 
  *    ASS_CTP_PC_HM_ARTROSCOPIA e ASS_CTP_PC_HM_LAPAROSCOPIA
  *
  *******************************************************************/
    lIdtRetorno integer;
    nCount integer;

  begin

    SELECT COUNT(*)
    INTO   nCount
    FROM   TB_ASS_CTP_CNV_UN_TPACOM_PLA
    WHERE  ((pASS_CTP_DT_INI_VIGENCIA >= ASS_CTP_DT_INI_VIGENCIA
             AND ASS_CTP_DT_FIM_VIGENCIA IS NULL)
    OR     (pASS_CTP_DT_INI_VIGENCIA BETWEEN ASS_CTP_DT_INI_VIGENCIA AND ASS_CTP_DT_FIM_VIGENCIA))
    AND    ASS_CUT_ID = pASS_CUT_ID
    AND    CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO;

    IF nCount > 0 then
       raise_application_error (-20000, 'Ja existe Associac?o neste periodo');
    END IF;

    SELECT SEQ_ASS_CTP_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_ASS_CTP_CNV_UN_TPACOM_PLA
    (
       ASS_CTP_ID,
       ASS_CUT_ID,
       ASS_CTP_DT_INI_VIGENCIA,
       ASS_CTP_DT_FIM_VIGENCIA,
       CAD_PLA_ID_PLANO,
       ASS_CTP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ASS_CTP_PC_HM_ACOMODACAO,
       ASS_CTP_PC_HM_ARTROSCOPIA,
       ASS_CTP_PC_HM_LAPAROSCOPIA
    )
    VALUES
    (
	     lIdtRetorno,
	     pASS_CUT_ID,
	     pASS_CTP_DT_INI_VIGENCIA,
	     pASS_CTP_DT_FIM_VIGENCIA,
	     pCAD_PLA_ID_PLANO,
	     sysdate,
	     pSEG_USU_ID_USUARIO,
       pASS_CTP_PC_HM_ACOMODACAO,
       pASS_CTP_PC_HM_ARTROSCOPIA,
       pASS_CTP_PC_HM_LAPAROSCOPIA
    );
    pNewIdt := lIdtRetorno;
  end PRC_ASS_CTP_CNV_UN_TPACO_PLA_I;
