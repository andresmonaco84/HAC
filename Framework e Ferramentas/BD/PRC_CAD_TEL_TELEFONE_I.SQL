create or replace procedure PRC_CAD_TEL_TELEFONE_I
  (
     pNewIdt OUT integer,
     pCAD_TEL_NR_NUM_TEL IN TB_CAD_TEL_TELEFONE.CAD_TEL_NR_NUM_TEL%type,
     pCAD_TEL_NR_RAMAL_TEL IN TB_CAD_TEL_TELEFONE.CAD_TEL_NR_RAMAL_TEL%type default NULL,
     pCAD_TEL_NM_CONTATO IN TB_CAD_TEL_TELEFONE.CAD_TEL_NM_CONTATO%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_TEL_TELEFONE.SEG_USU_ID_USUARIO%type,
     pAUX_TTE_CD_TP_TEL_END IN TB_AUX_TTE_TP_TEL_ENDERECO.AUX_TTE_CD_TP_TEL_END%type,
     pCAD_PES_ID_PESSOA IN TB_CAD_TEL_TELEFONE.CAD_PES_ID_PESSOA%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TEL_TELEFONE_I
  *
  *    Data Alteracao:  13/06/2007  Por: Silmara
  *    Alteracao: inclusao do CAD_PES_ID_PESSOA
  *
  *    Funcao: Alteracao do raise_application_erro de -30000 para -20000
  *
  *******************************************************************/
    lIdtRetorno integer;
    nCount     integer;
  begin

     nCount := 0;

    SELECT COUNT(*)
    INTO   nCount
    FROM   TB_CAD_TEL_TELEFONE TEL
    WHERE  TEL.CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA
    AND    TEL.AUX_TTE_CD_TP_TEL_END = pAUX_TTE_CD_TP_TEL_END
    AND    CAD_TEL_NR_NUM_TEL =  pCAD_TEL_NR_NUM_TEL;

    IF nCount > 0 then
       raise_application_error (-20000, 'Ja existe telefone cadastrado');
    END IF;


    SELECT SEQ_CAD_TEL_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_CAD_TEL_TELEFONE
    (
       CAD_TEL_ID_TELEFONE,
       CAD_TEL_NR_NUM_TEL,
       CAD_TEL_NR_RAMAL_TEL,
       CAD_TEL_NM_CONTATO,
       CAD_TEL_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       AUX_TTE_CD_TP_TEL_END,
       CAD_PES_ID_PESSOA
    )
    VALUES
    (
       lIdtRetorno,
       pCAD_TEL_NR_NUM_TEL,
       pCAD_TEL_NR_RAMAL_TEL,
       UPPER(pCAD_TEL_NM_CONTATO),
       SYSDATE,
       pSEG_USU_ID_USUARIO,
       pAUX_TTE_CD_TP_TEL_END,
       pCAD_PES_ID_PESSOA
    );
    pNewIdt := lIdtRetorno;
  end PRC_CAD_TEL_TELEFONE_I;
