create or replace procedure PRC_CAD_PHS_PLA_HISTO_STATUS_I
  (
     pNewIdt OUT integer,
     pCAD_PHS_ID IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PHS_ID%type default NULL,
     pCAD_PLA_ID_PLANO IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PLA_ID_PLANO%type,
     pCAD_PHS_DT_INI_VIGENCIA IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PHS_DT_INI_VIGENCIA%type,
     pCAD_PHS_DT_FIM_VIGENCIA IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PHS_DT_FIM_VIGENCIA%type default NULL,
     pCAD_PHS_FL_STATUS IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PHS_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_PHS_PLA_HISTO_STATUS.SEG_USU_ID_USUARIO%type
  )
  is
   /********************************************************************
  *    Procedure: PRC_CAD_PHS_PLA_HISTO_STATUS_I
  *
  *    Data Criacao: 10/08/2007   Por: Guilherme Holdack
  *    Data Alteracao:            Por:
  *
  *    Funcao: Inserir registros na tabela TB_CAD_PHS_PLA_HISTO_STATUS
  *
  *******************************************************************/
     lIdtRetorno integer;
     nCount integer;

  begin

    SELECT COUNT(*)
    INTO   nCount
    FROM   TB_CAD_PHS_PLA_HISTO_STATUS
    WHERE  ((pCAD_PHS_DT_INI_VIGENCIA < CAD_PHS_DT_INI_VIGENCIA
             AND CAD_PHS_DT_FIM_VIGENCIA IS NULL)
    OR     (pCAD_PHS_DT_INI_VIGENCIA  < CAD_PHS_DT_FIM_VIGENCIA))
    AND    CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO;

    IF nCount > 0 then
        raise_application_error (-20000, 'Existe status em aberto ou esta entre uma vigencia existente');
    END IF;

    SELECT SEQ_CAD_PHS_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_CAD_PHS_PLA_HISTO_STATUS
    (
       CAD_PHS_ID,
       CAD_PLA_ID_PLANO,
       CAD_PHS_DT_INI_VIGENCIA,
       CAD_PHS_DT_FIM_VIGENCIA,
       CAD_PHS_FL_STATUS,
       CAD_PHS_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PHS_DT_INCLUSAO
    )
    VALUES
    (
      lIdtRetorno,
      pCAD_PLA_ID_PLANO,
      pCAD_PHS_DT_INI_VIGENCIA,
      pCAD_PHS_DT_FIM_VIGENCIA,
      pCAD_PHS_FL_STATUS,
      SYSDATE,
      pSEG_USU_ID_USUARIO,
      SYSDATE
    );
    pNewIdt := lIdtRetorno;
  end PRC_CAD_PHS_PLA_HISTO_STATUS_I;
 