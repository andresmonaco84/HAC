CREATE OR REPLACE PROCEDURE PRC_ATS_RETORNA_CLI_ASS_S
(
--       pCAD_CLC_CD_CLINICA      IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_CD_CLINICA%TYPE DEFAULT NULL,
       pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PCL_PROF_CLINICA.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
       pCAD_PES_NM_PESSOA       IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%TYPE DEFAULT NULL,
       pCAD_CLC_DS_RESUMIDA     IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_DS_RESUMIDA%TYPE DEFAULT NULL,
       IO_CURSOR                OUT PKG_CURSOR.T_CURSOR
) 
IS
  /********************************************************************
  *    Procedure: PRC_ATS_RETORNA_CLI_ASS_S
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
    SELECT DISTINCT CLC.CAD_CLC_ID,
                    CLC.CAD_CLC_DT_INI_VIGENCIA,
                    CLC.CAD_CLC_DT_FIM_VIGENCIA,
                    CLC.CAD_PES_ID_PESSOA,
                    CLC.CAD_CLC_CD_CLINICA,
                    CLC.CAD_CLC_FL_STATUS,
                    CLC.CAD_CLC_DT_ULTIMA_ATUALIZACAO,
                    CLC.SEG_USU_ID_USUARIO,
                    CLC.CAD_CLC_DS_RESUMIDA,
                    
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
    
      FROM TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
           TB_ASS_PCL_PROF_CLINICA        PCL,
           TB_CAD_PES_PESSOA              PES
    
     WHERE CLC.CAD_CLC_ID = PCL.CAD_CLC_ID
--       AND (pCAD_CLC_CD_CLINICA IS NULL OR CLC.CAD_CLC_CD_CLINICA = pCAD_CLC_CD_CLINICA)
       AND (pCAD_PRO_ID_PROFISSIONAL IS NULL OR PCL.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL)
       AND (pCAD_PES_NM_PESSOA IS NULL OR CAD_PES_NM_PESSOA LIKE pCAD_PES_NM_PESSOA)
       AND (pCAD_CLC_DS_RESUMIDA IS NULL OR CAD_CLC_DS_RESUMIDA = pCAD_CLC_DS_RESUMIDA)
       AND CLC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA;

  IO_CURSOR := V_CURSOR;
END PRC_ATS_RETORNA_CLI_ASS_S;
