CREATE OR REPLACE PROCEDURE PRC_ATS_RETORNA_PRO_ASS_S
(
       pCAD_PRO_NR_CONSELHO IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_NR_CONSELHO%TYPE DEFAULT NULL,
       pCAD_PES_NM_PESSOA   IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%TYPE DEFAULT NULL,
       IO_CURSOR            OUT PKG_CURSOR.T_CURSOR
) 
IS
  /********************************************************************
  *    Procedure: PRC_ATS_RETORNA_PRO_ASS_S
  *
  *    Data Criacao:      Por:
  *    Funcao:
  *
  *    Data Alteracao: data da alteração  Por: Nome do Analista
  *
  *******************************************************************/
  V_CURSOR PKG_CURSOR.T_CURSOR;
BEGIN
  OPEN V_CURSOR FOR
    SELECT DISTINCT PRO.CAD_PRO_ID_PROFISSIONAL,
                    PRO.CAD_PRO_CD_CODCOOMED,
                    PRO.CAD_PRO_CD_COD_PRO,
                    PRO.CAD_PRO_NR_CONSELHO,
                    PRO.CAD_PRO_SG_UF_CONSELHO,
                    PRO.CAD_PRO_FL_ATIVO_OK,
                    PRO.CAD_PRO_NM_APELIDO,
                    PRO.CAD_PRO_DS_BIP_PAGER,
                    PRO.CAD_PRO_FL_IMPR_RECIBO_OK,
                    PRO.CAD_PRO_FL_STAFF_OK,
                    PRO.CAD_PRO_CD_BANCO,
                    PRO.CAD_PRO_CD_AGENCIA,
                    PRO.CAD_PRO_CD_CONTA,
                    PRO.CAD_PRO_FL_PERM_INTERN_OK,
                    PRO.CAD_PRO_FL_PERM_ASS_LAUDO_OK,
                    PRO.CAD_PRO_CD_MATRICULA,
                    PRO.CAD_PRO_DT_ULTIMA_ATUALIZACAO,
                    PRO.SEG_USU_ID_USUARIO,
                    PRO.CAD_PES_ID_PESSOA,
                    PRO.TIS_CPR_CD_CONSELHOPROF,
                    PRO.CAD_PRO_FL_RESIDENTE_OK,
                    PRO.CAD_PRO_NR_ANO_INI_RESIDENCIA,
                    PRO.CAD_PRO_DT_INI_RESIDENCIA,
                    PRO.CAD_PRO_DT_FIM_RESIDENCIA,
                    
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
                    PES.CAD_PES_DT_EXPEDICAORG
    
      FROM TB_CAD_PRO_PROFISSIONAL PRO,
           TB_CAD_PES_PESSOA       PES,
           TB_ASS_PCL_PROF_CLINICA PLC
    
     WHERE PRO.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
       AND (PLC.CAD_PRO_ID_PROFISSIONAL = PRO.CAD_PRO_ID_PROFISSIONAL)
       AND (pCAD_PRO_NR_CONSELHO IS NULL OR PRO.CAD_PRO_NR_CONSELHO = pCAD_PRO_NR_CONSELHO)
       AND (pCAD_PES_NM_PESSOA IS NULL OR PES.CAD_PES_NM_PESSOA LIKE pCAD_PES_NM_PESSOA);

  IO_CURSOR := V_CURSOR;
END PRC_ATS_RETORNA_PRO_ASS_S;