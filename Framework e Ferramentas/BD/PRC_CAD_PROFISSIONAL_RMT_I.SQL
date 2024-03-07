create or replace procedure PRC_CAD_PROFISSIONAL_RMT_I(pNewIdt                        OUT integer,
                                                         pCAD_PRO_ID_PROFISSIONAL       IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%type default NULL,
                                                         pCAD_PRO_CD_CODCOOMED          IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_CD_CODCOOMED%type default NULL,
                                                         pCAD_PRO_CD_COD_PRO            IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_CD_COD_PRO%type,
                                                         pCAD_PRO_NR_CONSELHO           IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_NR_CONSELHO%type,
                                                         pCAD_PRO_SG_UF_CONSELHO        IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_SG_UF_CONSELHO%type,
                                                         pCAD_PRO_FL_ATIVO_OK           IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_FL_ATIVO_OK%type,
                                                         pCAD_PRO_NM_APELIDO            IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_NM_APELIDO%type default NULL,
                                                         pCAD_PRO_DS_BIP_PAGER          IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_DS_BIP_PAGER%type default NULL,
                                                         pCAD_PRO_FL_IMPR_RECIBO_OK     IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_FL_IMPR_RECIBO_OK%type,
                                                         pCAD_PRO_FL_STAFF_OK           IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_FL_STAFF_OK%type default NULL,
                                                         pCAD_PRO_CD_BANCO              IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_CD_BANCO%type default NULL,
                                                         pCAD_PRO_CD_AGENCIA            IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_CD_AGENCIA%type default NULL,
                                                         pCAD_PRO_CD_CONTA              IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_CD_CONTA%type default NULL,
                                                         pCAD_PRO_FL_PERM_INTERN_OK     IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_FL_PERM_INTERN_OK%type,
                                                         pCAD_PRO_FL_PERM_ASS_LAUDO_OK  IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_FL_PERM_ASS_LAUDO_OK%type,
                                                         pCAD_PRO_CD_MATRICULA          IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_CD_MATRICULA%type default NULL,
                                                         pCAD_PRO_DT_ULTIMA_ATUALIZACAO IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_DT_ULTIMA_ATUALIZACAO%type,
                                                         pSEG_USU_ID_USUARIO            IN TB_CAD_PRO_PROFISSIONAL.SEG_USU_ID_USUARIO%type,
                                                         pCAD_PES_ID_PESSOA             IN TB_CAD_PRO_PROFISSIONAL.CAD_PES_ID_PESSOA%type,
                                                         pTIS_CPR_CD_CONSELHOPROF       IN TB_CAD_PRO_PROFISSIONAL.TIS_CPR_CD_CONSELHOPROF%type,
                                                         pCAD_PRO_FL_RESIDENTE_OK       IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_FL_RESIDENTE_OK%type,
                                                         pCAD_PRO_NR_ANO_INI_RESIDENCIA IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_NR_ANO_INI_RESIDENCIA%type default NULL,
                                                         pCAD_PRO_DT_INI_RESIDENCIA     IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_DT_INI_RESIDENCIA%type default NULL,
                                                         pCAD_PRO_DT_FIM_RESIDENCIA     IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_DT_FIM_RESIDENCIA%type default NULL,
                                                         pCAD_PRO_FL_PERM_EXAME_OK      IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_FL_PERM_EXAME_OK%type,
                                                         pCAD_PRO_NM_NOME               IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_NM_NOME%type default NULL) is
    /********************************************************************
    *    Procedure: PRC_CAD_PROFISSIONAL_RMT_I
    * 
    *    Data Criacao:  data da  criação   Por: Nome do Analista
    *    Data Alteracao:  data da alteração  Por: Nome do Analista
    *
    *    Funcao: Descrição da funcionalidade da Stored Procedure
    *
    *******************************************************************/
    lIdtRetorno           integer;
    vCAD_PES_NM_PESSOA    VARCHAR2(100);
    vCODSITMED            CHAR(1);
    vCAD_PES_TP_SEXO      CHAR(1);
    vCAD_PRO_CD_CODCOOMED number;
  begin
    SELECT SEQ_CAD_PRO_01.NextVal INTO lIdtRetorno FROM DUAL;
    INSERT INTO TB_CAD_PRO_PROFISSIONAL
      (CAD_PRO_ID_PROFISSIONAL,
       CAD_PRO_CD_CODCOOMED,
       CAD_PRO_CD_COD_PRO,
       CAD_PRO_NR_CONSELHO,
       CAD_PRO_SG_UF_CONSELHO,
       CAD_PRO_FL_ATIVO_OK,
       CAD_PRO_NM_APELIDO,
       CAD_PRO_DS_BIP_PAGER,
       CAD_PRO_FL_IMPR_RECIBO_OK,
       CAD_PRO_FL_STAFF_OK,
       CAD_PRO_CD_BANCO,
       CAD_PRO_CD_AGENCIA,
       CAD_PRO_CD_CONTA,
       CAD_PRO_FL_PERM_INTERN_OK,
       CAD_PRO_FL_PERM_ASS_LAUDO_OK,
       CAD_PRO_CD_MATRICULA,
       CAD_PRO_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PES_ID_PESSOA,
       TIS_CPR_CD_CONSELHOPROF,
       CAD_PRO_FL_RESIDENTE_OK,
       CAD_PRO_NR_ANO_INI_RESIDENCIA,
       CAD_PRO_DT_INI_RESIDENCIA,
       CAD_PRO_DT_FIM_RESIDENCIA,
       CAD_PRO_FL_PERM_EXAME_OK,
       CAD_PRO_NM_NOME)
    VALUES
      (lIdtRetorno,
       pCAD_PRO_CD_CODCOOMED,
       pCAD_PRO_NR_CONSELHO,
       pCAD_PRO_NR_CONSELHO,
       pCAD_PRO_SG_UF_CONSELHO,
       pCAD_PRO_FL_ATIVO_OK,
       pCAD_PRO_NM_APELIDO,
       pCAD_PRO_DS_BIP_PAGER,
       pCAD_PRO_FL_IMPR_RECIBO_OK,
       pCAD_PRO_FL_STAFF_OK,
       pCAD_PRO_CD_BANCO,
       pCAD_PRO_CD_AGENCIA,
       pCAD_PRO_CD_CONTA,
       pCAD_PRO_FL_PERM_INTERN_OK,
       pCAD_PRO_FL_PERM_ASS_LAUDO_OK,
       pCAD_PRO_CD_MATRICULA,
       pCAD_PRO_DT_ULTIMA_ATUALIZACAO,
       pSEG_USU_ID_USUARIO,
       pCAD_PES_ID_PESSOA,
       pTIS_CPR_CD_CONSELHOPROF,
       pCAD_PRO_FL_RESIDENTE_OK,
       pCAD_PRO_NR_ANO_INI_RESIDENCIA,
       pCAD_PRO_DT_INI_RESIDENCIA,
       pCAD_PRO_DT_FIM_RESIDENCIA,
       pCAD_PRO_FL_PERM_EXAME_OK,
       pCAD_PRO_NM_NOME);
    pNewIdt := lIdtRetorno;
    IF pTIS_CPR_CD_CONSELHOPROF = 'CRM' THEN
      SELECT PES.CAD_PES_NM_PESSOA, PES.CAD_PES_TP_SEXO
        INTO vCAD_PES_NM_PESSOA, vCAD_PES_TP_SEXO
        FROM TB_CAD_PES_PESSOA PES
       WHERE PES.CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA;
      IF pCAD_PRO_FL_ATIVO_OK = 'S' THEN
        vCODSITMED := 'A';
      ELSE
        vCODSITMED := 'N';
      END IF;
      BEGIN
        INSERT INTO TB_MEDICO_CFM
          (CODMED, UF, NOMMED, CODSITMED)
        VALUES
          (pCAD_PRO_NR_CONSELHO,
           upper(pCAD_PRO_SG_UF_CONSELHO),
           SUBSTR(vCAD_PES_NM_PESSOA, 1, 50),
           vCODSITMED);
      EXCEPTION
        WHEN DUP_VAL_ON_INDEX THEN
          NULL;
      END;
      IF pCAD_PRO_SG_UF_CONSELHO = 'SP' THEN
        BEGIN
          INSERT INTO HOSPITAL.TB_CREMESP C
            (codigo, nome, status, UF)
          VALUES
            (pCAD_PRO_NR_CONSELHO,
             SUBSTR(vCAD_PES_NM_PESSOA, 1, 50),
             vCODSITMED,
             upper(pCAD_PRO_SG_UF_CONSELHO));
        EXCEPTION
          WHEN DUP_VAL_ON_INDEX THEN
            NULL;
        END;
      END IF;
      IF pCAD_PRO_CD_CODCOOMED NOT IN (1, 2, 3, 4, 5, 6, 7, 8, 9) or
         pCAD_PRO_CD_CODCOOMED is null THEN
        vCAD_PRO_CD_CODCOOMED := 1;
      ELSE
        vCAD_PRO_CD_CODCOOMED := pCAD_PRO_CD_CODCOOMED;
      END IF;
      BEGIN
        INSERT INTO HOSPITAL.MEDICO
          (codmed, codcoomed, nommed, sexmed, codsitmed)
        VALUES
          (pCAD_PRO_NR_CONSELHO,
           vCAD_PRO_CD_CODCOOMED,
           SUBSTR(vCAD_PES_NM_PESSOA, 1, 30),
           vCAD_PES_TP_SEXO,
           vCODSITMED);
      EXCEPTION
        WHEN DUP_VAL_ON_INDEX THEN
          NULL;
      END;
    END IF;
  end PRC_CAD_PROFISSIONAL_RMT_I;
/
