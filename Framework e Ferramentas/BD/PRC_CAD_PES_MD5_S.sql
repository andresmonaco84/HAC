CREATE OR REPLACE PROCEDURE "PRC_CAD_PES_MD5_S"
  (
     pASS_PMD_CD_MD5_ATUAL IN TB_ASS_PMD_PESSOA_MD5.ASS_PMD_CD_MD5%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_PAC_CNV_PLA_MD5_S
  *
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       PES.CAD_PES_ID_PESSOA,
       PES.CAD_PES_NR_CNPJ_CPF,
       PES.CAD_PES_FL_JURIDICA_OK,
       PES.CAD_PES_NM_PESSOA,
       PES.CAD_PES_DT_ULTIMA_ATUALIZACAO,
       PES.SEG_USU_ID_USUARIO,
       PES.CAD_PES_DT_NASCIMENTO,
       PES.CAD_PES_NR_RG,
       PES.CAD_PES_NM_RAZAOSOCIAL,
       PES.CAD_PES_CD_INSCR_ESTAD,
       PES.CAD_PES_CD_INSCR_MUNIC,
       PES.CAD_PES_TP_SEXO,
       PES.CAD_PES_CD_ESTADOCIVIL,
       PES.CAD_PES_NM_NOMEMAE,
       PES.CAD_PES_CD_ORGAOEMISSORRG,
       PES.CAD_PES_DT_EXPEDICAORG,
       PES.CAD_PES_FL_ATIVO_OK
  FROM TB_ASS_PMD_PESSOA_MD5 MD5
  INNER JOIN TB_CAD_PES_PESSOA PES
  ON PES.CAD_PES_ID_PESSOA = MD5.CAD_PES_ID_PESSOA
   AND MD5.ASS_PMD_CD_MD5 = pASS_PMD_CD_MD5_ATUAL
   and md5.ass_pmd_dt_desativacao is null;

    io_cursor := v_cursor;
  end PRC_CAD_PES_MD5_S;




Marcus Relva 
Tecnologia da Informação
Hospital Ana Costa S. A. 
(13) 3285-2022 (ramal 2038)

