create or replace procedure PRC_CAD_ACS_BENEF_I
  (
     pCAD_PLA_CD_PLANO      IN TB_CAD_ACS_BENEF.CAD_PLA_CD_PLANO%TYPE,
     pCAD_PAC_CD_CREDENCIAL IN TB_CAD_ACS_BENEF.CAD_PAC_CD_CREDENCIAL%TYPE,
     pCAD_EMP_CD_EMPRESA    IN TB_CAD_ACS_BENEF.CAD_EMP_CD_EMPRESA%TYPE DEFAULT NULL,
     pCAD_PES_ID_PESSOA     IN TB_CAD_ACS_BENEF.CAD_PES_ID_PESSOA%TYPE,
     pSEG_USU_ID_USUARIO    IN TB_CAD_ACS_BENEF.SEG_USU_ID_USUARIO%TYPE
  )
  is
  /********************************************************************
  *    Procedure:
  *
  *    Data Criacao: 	23/07/2007           Por: Fabiola Lopes
  *    Data Alteracao:                      Por:
  *
  *    Funcao: Inserc?o de registros na tabela TB_CAD_PAC_PACIENTE
  *
  *******************************************************************/  
  begin
        INSERT INTO TB_CAD_ACS_BENEF
         (
           CAD_PLA_CD_PLANO,
           CAD_PAC_CD_CREDENCIAL,
           CAD_EMP_CD_EMPRESA,
           CAD_PES_ID_PESSOA,
           CAD_DT_ULTIMA_ATUALIZACAO,
           SEG_USU_ID_USUARIO
         )
         VALUES
         (
           pCAD_PLA_CD_PLANO,
           pCAD_PAC_CD_CREDENCIAL,
           pCAD_EMP_CD_EMPRESA,
           pCAD_PES_ID_PESSOA,
           SYSDATE,
           pSEG_USU_ID_USUARIO
         );

  end PRC_CAD_ACS_BENEF_I;
