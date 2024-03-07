create or replace procedure PRC_CAD_TP_ACOMOD_AUTOR_ACS_S(pCAD_UNI_ID_UNIDADE            IN TB_ASS_UTA_UNID_TPACOMOD.CAD_UNI_ID_UNIDADE%TYPE,
                                                          pCAD_TAA_CD_TIPOACOMODACAO_ACS IN TB_CAD_TAA_TIPO_ACOMODACAO_ACS.CAD_TAA_CD_TIPO_ACOMODACAO_ACS%TYPE,
                                                          io_cursor                      OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_CAD_TP_ACOMOD_AUTOR_ACS_S
  *
  *    Data Criacao:   24/05/2011          Por: Fabiola Lopes
  *    Data Alteracao:                     Por:
  *
  *    Funcao: Listar os Tipo de Acomodacoes permitidas para convenio/plano do paciente
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
BEGIN
  OPEN V_CURSOR FOR
    SELECT TAA.TIS_TAC_CD_TIPO_ACOMODACAO,
           TAC.TIS_TAC_DS_TIPO_ACOMODACAO
      FROM TB_CAD_TAA_TIPO_ACOMODACAO_ACS TAA,
           TB_TIS_TAC_TIPO_ACOMODACAO     TAC
     WHERE TAA.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
       AND TAA.TIS_TAC_CD_TIPO_ACOMODACAO = TAC.TIS_TAC_CD_TIPO_ACOMODACAO
       AND TAA.CAD_TAA_CD_TIPO_ACOMODACAO_ACS =
           pCAD_TAA_CD_TIPOACOMODACAO_ACS
       AND EXISTS
     (SELECT QLE.TIS_TAC_CD_TIPO_ACOMODACAO
              FROM TB_CAD_QLE_QUARTO_LEITO QLE, TB_CAD_SET_SETOR SETOR
             WHERE QLE.CAD_SET_ID = SETOR.CAD_SET_ID
               AND SETOR.CAD_UNI_ID_UNIDADE = TAA.CAD_UNI_ID_UNIDADE
               AND QLE.TIS_TAC_CD_TIPO_ACOMODACAO =
                   TAC.TIS_TAC_CD_TIPO_ACOMODACAO);
  IO_CURSOR := V_CURSOR;
END PRC_CAD_TP_ACOMOD_AUTOR_ACS_S;