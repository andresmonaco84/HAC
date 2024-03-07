create or replace procedure PRC_ASS_PTA_PLA_TPATEND_I
  (
     pNewIdt OUT integer,
     pASS_CTA_ID IN TB_ASS_PTA_PLA_TPATEND.ASS_CTA_ID%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_PTA_PLA_TPATEND.CAD_PLA_ID_PLANO%type,
     pASS_PTA_DS_MOTIVO_FIM_VIGEN IN TB_ASS_PTA_PLA_TPATEND.ASS_PTA_DS_MOTIVO_FIM_VIGENCIA%type default NULL,
     pASS_PTA_DT_INI_VIGENCIA IN TB_ASS_PTA_PLA_TPATEND.ASS_PTA_DT_INI_VIGENCIA%type,
     pASS_PTA_DT_FIM_VIGENCIA IN TB_ASS_PTA_PLA_TPATEND.ASS_PTA_DT_FIM_VIGENCIA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_PTA_PLA_TPATEND.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PTA_PLA_TPATEND_I
  *
  *    Data Criacao:   14/09/2009   Por: Alexandre M. Muniz
  *    Funcao: Inclui a Associac?o do Plano X Tipo de Atendimento
  *
  *******************************************************************/
    lIdtRetorno integer;
    nCount integer;

  begin

    SELECT COUNT(*)
    INTO   nCount
    FROM   TB_ASS_PTA_PLA_TPATEND
    WHERE  ((pASS_PTA_DT_INI_VIGENCIA >= ASS_PTA_DT_INI_VIGENCIA
             AND ASS_PTA_DT_FIM_VIGENCIA IS NULL)
    OR     (pASS_PTA_DT_INI_VIGENCIA BETWEEN ASS_PTA_DT_INI_VIGENCIA AND ASS_PTA_DT_FIM_VIGENCIA))
    AND    CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
    AND    ASS_CTA_ID = pASS_CTA_ID;

    IF nCount > 0 then
       raise_application_error (-20000, 'Ja existe Associação neste período');
    END IF;

    SELECT SEQ_ASS_PTA_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_ASS_PTA_PLA_TPATEND
    (
       ASS_PTA_ID,                    
       ASS_CTA_ID,                    
       CAD_PLA_ID_PLANO,
       ASS_PTA_DS_MOTIVO_FIM_VIGENCIA,
       ASS_PTA_DT_ULTIMA_ATUALIZACAO, 
       ASS_PTA_DT_INI_VIGENCIA,       
       ASS_PTA_DT_FIM_VIGENCIA,       
       SEG_USU_ID_USUARIO            
    )
    VALUES
    (
       lIdtRetorno,
       pASS_CTA_ID,
       pCAD_PLA_ID_PLANO,
       UPPER(pASS_PTA_DS_MOTIVO_FIM_VIGEN),
       sysdate,
       pASS_PTA_DT_INI_VIGENCIA,
       pASS_PTA_DT_FIM_VIGENCIA,
       pSEG_USU_ID_USUARIO
    );
    
    pNewIdt := lIdtRetorno;
    
  end PRC_ASS_PTA_PLA_TPATEND_I;
