CREATE OR REPLACE PROCEDURE "PRC_AGE_ESF_ESCALA_FALTAS_I"(pNewIdt                        OUT integer,
                                                          pAGE_ESF_ID                    IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_ID%type DEFAULT NULL,
                                                          pAGE_ESF_DT_INI_FALTA          IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_DT_INI_FALTA%type,
                                                          pAGE_ESF_DS_OBSERVACAO         IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_DS_OBSERVACAO%type default NULL,
                                                          pAGE_ESM_ID                    IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESM_ID%type,
                                                          pSEG_USU_ID_USUARIO            IN TB_AGE_ESF_ESCALA_FALTAS.SEG_USU_ID_USUARIO%type,
                                                          pAGE_ESF_DT_FIM_FALTA          IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_DT_FIM_FALTA%type,
                                                          pAGE_ESF_HR_INI_FALTA          IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_HR_INI_FALTA%type default NULL,
                                                          pAGE_ESF_HR_FIM_FALTA          IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_HR_FIM_FALTA%type default NULL,
                                                          pAGE_ESF_FL_SUBSTITUTO_OK      IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_FL_SUBSTITUTO_OK%type,
                                                          pTIS_CBO_CD_CBOS_SUBST         IN TB_AGE_ESF_ESCALA_FALTAS.TIS_CBO_CD_CBOS_SUBST%type default NULL,
                                                          pCAD_PRO_ID_PROFISSIONAL_SUBST IN TB_AGE_ESF_ESCALA_FALTAS.CAD_PRO_ID_PROFISSIONAL_SUBST%type default NULL) is
  /********************************************************************
  *    Procedure: PRC_AGE_ESF_ESCALA_FALTAS_I
  *
  *    Data Criacao:    30/06/2007  Por: Silmara
  *    Funcao: Inclui uma falta em uma determinada escala medica
  *
  *    Data Alteracao: 14/10/2014  Por: Cristiane Gomes
  *    Alteracao: Considerar a hora inicial e final da falta na verificação 
  *               de falta existente no periodo
  *
  *******************************************************************/
  lIdtRetorno integer;
  nCount      integer;

begin

  --Garantir que n?o seja permitida a inclus?o de faltas para periodos ja cadastrados
  SELECT COUNT(*)
    INTO nCount
    FROM TB_AGE_ESF_ESCALA_FALTAS ESF
   WHERE ESF.AGE_ESM_ID = pAGE_ESM_ID
     AND (((pAGE_ESF_DT_INI_FALTA BETWEEN ESF.AGE_ESF_DT_INI_FALTA AND
         ESF.AGE_ESF_DT_FIM_FALTA) OR
         (pAGE_ESF_DT_FIM_FALTA BETWEEN ESF.AGE_ESF_DT_INI_FALTA AND
         ESF.AGE_ESF_DT_FIM_FALTA)) AND
         ((ESF.AGE_ESF_HR_INI_FALTA IS NULL AND
         ESF.AGE_ESF_HR_FIM_FALTA IS NULL) OR
         ((pAGE_ESF_HR_INI_FALTA IS NULL AND
         pAGE_ESF_HR_FIM_FALTA IS NULL) AND
         (ESF.AGE_ESF_HR_INI_FALTA IS NOT NULL AND
         ESF.AGE_ESF_HR_FIM_FALTA IS NOT NULL)) OR
         ((pAGE_ESF_HR_INI_FALTA IS NOT NULL AND
         pAGE_ESF_HR_FIM_FALTA IS NOT NULL) AND
         ((pAGE_ESF_HR_INI_FALTA BETWEEN ESF.AGE_ESF_HR_INI_FALTA AND
         ESF.AGE_ESF_HR_FIM_FALTA) OR
         (pAGE_ESF_HR_FIM_FALTA BETWEEN ESF.AGE_ESF_HR_INI_FALTA AND
         ESF.AGE_ESF_HR_FIM_FALTA)))));
  IF nCount > 0 then
    raise_application_error(-20000,
                            'Ja existe Falta para esta Escala Medica neste periodo');
  END IF;

  SELECT SEQ_AGE_ESF_01.NextVal INTO lIdtRetorno FROM DUAL;

  INSERT INTO TB_AGE_ESF_ESCALA_FALTAS
    (AGE_ESF_ID,
     AGE_ESF_DT_INI_FALTA,
     AGE_ESF_DS_OBSERVACAO,
     AGE_ESM_ID,
     SEG_USU_ID_USUARIO,
     AGE_ESF_DT_ULTIMA_ATUALIZACAO,
     AGE_ESF_DT_FIM_FALTA,
     AGE_ESF_HR_INI_FALTA,
     AGE_ESF_HR_FIM_FALTA,
     AGE_ESF_FL_SUBSTITUTO_OK,
     TIS_CBO_CD_CBOS_SUBST,
     CAD_PRO_ID_PROFISSIONAL_SUBST)
  VALUES
    (lIdtRetorno,
     pAGE_ESF_DT_INI_FALTA,
     upper(pAGE_ESF_DS_OBSERVACAO),
     pAGE_ESM_ID,
     pSEG_USU_ID_USUARIO,
     SYSDATE(),
     pAGE_ESF_DT_FIM_FALTA,
     pAGE_ESF_HR_INI_FALTA,
     pAGE_ESF_HR_FIM_FALTA,
     pAGE_ESF_FL_SUBSTITUTO_OK,
     pTIS_CBO_CD_CBOS_SUBST,
     pCAD_PRO_ID_PROFISSIONAL_SUBST);
  pNewIdt := lIdtRetorno;
end PRC_AGE_ESF_ESCALA_FALTAS_I;
/
