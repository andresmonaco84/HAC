create or replace procedure sgs.PRC_CAD_PHS_FINALIZAR_VIGENCIA
  (
     pCAD_CNV_ID_CONVENIO IN TB_CAD_PLA_PLANO.CAD_CNV_ID_CONVENIO%type,
     pCAD_PLA_ID_PLANO IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PLA_ID_PLANO%type default NULL,
     pCAD_PHS_DT_FIM_VIGENCIA IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PHS_DT_FIM_VIGENCIA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_PHS_PLA_HISTO_STATUS.SEG_USU_ID_USUARIO%type,
     pCAD_PHS_FL_STATUS IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PHS_FL_STATUS%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PHS_FINALIZAR_VIGENCIA
  *
  *    Data Criacao: 27/08/2009   Por: Alexandre M. Muniz
  *    Funcao: Finalizar a vig¨ncia de um ou todos planos com status
  *            ativo e data de fim de vig¨ncia em aberto.
  *
  *    Data Alteracao: -          Por: -
  *
  *
  *******************************************************************/

  lIdtRetorno integer;
  vStatusRegistroAlterar TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PHS_FL_STATUS%type;

  begin

   /* IF (pCAD_PHS_FL_STATUS = 'I') THEN
       vStatusRegistroAlterar := 'A';
    ELSE
       vStatusRegistroAlterar := 'I';
    END IF;*/

    --Atualiza o registro existente
    UPDATE TB_CAD_PHS_PLA_HISTO_STATUS
    SET
        CAD_PHS_DT_FIM_VIGENCIA = decode(pCAD_PHS_DT_FIM_VIGENCIA,null,trunc(sysdate),pCAD_PHS_DT_FIM_VIGENCIA),
        CAD_PHS_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    WHERE
         CAD_PHS_DT_FIM_VIGENCIA IS NULL
   -- AND  UPPER(CAD_PHS_FL_STATUS) = UPPER(vStatusRegistroAlterar)
    AND  CAD_PLA_ID_PLANO IN (SELECT PLA.CAD_PLA_ID_PLANO
                                FROM TB_CAD_PLA_PLANO PLA
                               WHERE PLA.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
                                 AND (pCAD_PLA_ID_PLANO IS NULL OR PLA.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO));


    FOR vREC_PLANOS IN (SELECT PLA.CAD_PLA_ID_PLANO, PLA.CAD_PLA_FL_SITUACAO_PLANO, PLA.CAD_PLA_DT_FIM_VIGENCIA
                          FROM TB_CAD_PLA_PLANO PLA
                         WHERE PLA.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
                           AND (pCAD_PLA_ID_PLANO IS NULL OR PLA.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO))
    LOOP

        SELECT SEQ_CAD_PHS_01.NextVal INTO lIdtRetorno FROM DUAL;

        --Inclui um novo registro
        INSERT INTO TB_CAD_PHS_PLA_HISTO_STATUS
        (
           CAD_PHS_ID,
           CAD_PLA_ID_PLANO,
           CAD_PHS_DT_INI_VIGENCIA,
           CAD_PHS_FL_STATUS,
           CAD_PHS_DT_ULTIMA_ATUALIZACAO,
           SEG_USU_ID_USUARIO,
           CAD_PHS_DT_FIM_VIGENCIA,
           CAD_PHS_DT_INCLUSAO
        )
        VALUES
        (
          lIdtRetorno,
          vREC_PLANOS.CAD_PLA_ID_PLANO,
          case when pCAD_PHS_DT_FIM_VIGENCIA is null or pCAD_PHS_DT_FIM_VIGENCIA > trunc(sysdate) then trunc(sysdate)
            else pCAD_PHS_DT_FIM_VIGENCIA end,
--          decode(pCAD_PHS_DT_FIM_VIGENCIA, null, trunc(sysdate), pCAD_PHS_DT_FIM_VIGENCIA),
          DECODE(pCAD_PHS_FL_STATUS, NULL, vREC_PLANOS.CAD_PLA_FL_SITUACAO_PLANO, pCAD_PHS_FL_STATUS),
          SYSDATE,
          pSEG_USU_ID_USUARIO,
          CASE WHEN vREC_PLANOS.CAD_PLA_DT_FIM_VIGENCIA IS NOT NULL THEN vREC_PLANOS.CAD_PLA_DT_FIM_VIGENCIA
            ELSE NULL END,
              SYSDATE
        );

    END LOOP;

  end PRC_CAD_PHS_FINALIZAR_VIGENCIA;
