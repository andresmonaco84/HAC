CREATE OR REPLACE PROCEDURE "PRC_CAD_CLC_CLINICA_CRED_SID"
  (
     pCAD_CLC_ID IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CLC_CLINICA_CRED_SID
  *
  *    Data Criacao:   25/08/2011       Por: Fabiola Lopes
  *
  *    Funcao: Pesquisa uma clinica especifica
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       CLC.CAD_CLC_ID,
       CLC.CAD_CLC_DT_INI_VIGENCIA,
       CLC.CAD_CLC_DT_FIM_VIGENCIA,
       CLC.CAD_PES_ID_PESSOA,
       CLC.CAD_CLC_CD_CLINICA,
       CLC.CAD_CLC_FL_STATUS,
       CLC.CAD_CLC_DT_ULTIMA_ATUALIZACAO,
       CLC.SEG_USU_ID_USUARIO,
       CLC.CAD_CLC_DS_RESUMIDA,
       CLC.CAD_CLC_FL_UTILIZA_LIBERACAO,
       CLC.CAD_CLC_FL_MOVIMENTAPACINT_OK,
       CLC.CAD_CLC_DS_DESCRICAO,
       CLC.CAD_CLC_CT_EMPRESA,
       PES.*
    FROM TB_CAD_CLC_CLINICA_CREDENCIADA CLC
   INNER JOIN TB_CAD_PES_PESSOA PES
      ON PES.CAD_PES_ID_PESSOA = CLC.CAD_PES_ID_PESSOA
    WHERE
        CLC.CAD_CLC_ID = pCAD_CLC_ID;

    io_cursor := v_cursor;

  end PRC_CAD_CLC_CLINICA_CRED_SID;
 
