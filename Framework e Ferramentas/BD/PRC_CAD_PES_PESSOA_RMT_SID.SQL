create or replace procedure PRC_CAD_PES_PESSOA_RMT_SID
  (
     pCAD_PES_ID_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PES_PESSOA_RMT_SID
  *
  *    Data Criacao:   Por:
  *    Data Alteracao:   05/01/2012       Por: Pedro
  *    Alteracao:        Adic?o do campo CODCFO pCAD_PES_CD_CNS_SUS
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       CAD_PES_ID_PESSOA,
       CAD_PES_NR_CNPJ_CPF,
       CAD_PES_FL_JURIDICA_OK,
       CAD_PES_NM_PESSOA,
       CAD_PES_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PES_DT_NASCIMENTO,
       CAD_PES_NR_RG,
       CAD_PES_NM_RAZAOSOCIAL,
       CAD_PES_CD_INSCR_ESTAD,
       CAD_PES_CD_INSCR_MUNIC,
       CAD_PES_TP_SEXO,
       CAD_PES_CD_ESTADOCIVIL,
       CAD_PES_NM_NOMEMAE,
       CAD_PES_CD_ORGAOEMISSORRG,
       CAD_PES_DT_EXPEDICAORG,
       CAD_PES_TP_SANGUINEO,
       CAD_PES_FL_SANGPOSITIVO_OK,
       AUX_PRF_CD_CODIGO,
       AUX_NAC_CD_CODIGO,
       CAD_PES_FL_DOADORORGAOS_OK,
       CAD_PES_NM_NATURALIDADE,
       AUX_ESC_CD_CODIGO,
       CAD_PES_NM_NOMEPAI,
       CAD_PES_NM_CONJUGE,
       AUX_UFE_SG_UF,
       CODCFO,
       CAD_PES_CD_CNS_SUS,
       CAD_PES_NOME_SOUNDEX,
       CAD_PES_FL_ATIVO_OK,
       CAD_PES_NM_RN,
       CAD_PES_DT_NASC_RN,
       CAD_PES_TP_SEXO_RN,
       CAD_PES_FL_PRE_ATENDIMENTO,
       CAD_PES_FL_EMAIL_INFORMADO,
       CAD_PES_DT_DESBLOQUEIO_CPF,
       SEG_USU_ID_USUARIO_DESB_CPF,
       CAD_PES_FL_CUIDADOINTEGRAL,
       CAD_PES_FL_ISOLAMENTO

    FROM TB_CAD_PES_PESSOA
    WHERE
        CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA;
    io_cursor := v_cursor;
  end PRC_CAD_PES_PESSOA_RMT_SID;
