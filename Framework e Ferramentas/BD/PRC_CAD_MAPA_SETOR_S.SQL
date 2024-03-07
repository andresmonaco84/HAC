CREATE OR REPLACE PROCEDURE "PRC_CAD_MAPA_SETOR_S"
(
  pCAD_UNI_ID_UNIDADE           IN TB_ASS_UTA_UNID_TPACOMOD.CAD_UNI_ID_UNIDADE%TYPE,
  pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_SET_SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
  io_cursor                     OUT PKG_CURSOR.t_cursor
)
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MAPA_SETOR_ACS_S
  *
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  18/07/2014  Por: Cristiane
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *    Alteracao: 18/07/2014 Desconsiderar quartos/leitos desativados por reestruturacao
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
  SELECT SETOR.CAD_SET_ID,
         QLE.CAD_QLE_NR_QUARTO,
         QLE.CAD_QLE_NR_LEITO,
         QLE.CAD_QLE_TP_SEXO,
         QLE.CAD_QLE_ID,
         SETOR.CAD_SET_DS_SETOR,
         QLE.CAD_SQL_CD_SIT_QUARTO_LEITO SITUACAOLEITO,
         PAC_ALOCADO.CAD_PAC_ID_PACIENTE,
         PAC_ALOCADO.CAD_PES_NM_PESSOA,
         PAC_ALOCADO.CAD_PES_TP_SEXO,
         PAC_ALOCADO.ATD_ATE_ID,
         QLE.CAD_QLE_TP_SEXO SEXOQUARTO,
         QLE.TIS_TAC_CD_TIPO_ACOMODACAO,
         QLE.TIS_TAC_CD_TIPO_ACOM_PROV
    FROM TB_CAD_QLE_QUARTO_LEITO QLE,
         TB_CAD_SET_SETOR SETOR, ( SELECT IML.CAD_CAD_QLE_ID,
                                          IML.CAD_PAC_ID_PACIENTE,
                                          PES.CAD_PES_NM_PESSOA,
                                          PES.CAD_PES_TP_SEXO,
                                          IML.ATD_ATE_ID
                                     FROM TB_ATD_IML_INT_MOV_LEITO IML,
                                          TB_CAD_QLE_QUARTO_LEITO  QLE,
                                          TB_CAD_SET_SETOR         SETOR,
                                          TB_CAD_PAC_PACIENTE      PAC,
                                          TB_CAD_PES_PESSOA        PES
                                    WHERE IML.ATD_IML_DT_SAIDA IS NULL
                                      AND IML.ATD_IML_HR_SAIDA IS NULL
                                      AND IML.CAD_CAD_QLE_ID = QLE.CAD_QLE_ID
                                      AND SETOR.CAD_SET_ID = QLE.CAD_SET_ID
                                      AND IML.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
                                      AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
--                                      AND QLE.CAD_QLE_TP_QUARTO_LEITO = 'I'
                                      AND SETOR.CAD_SET_FL_PERMITEINTERN_OK = 'S'
                                      AND SETOR.CAD_SET_FL_ATIVO_OK = 'S'
                                      AND SETOR.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
                                      AND SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
                                      AND IML.ATD_IML_FL_STATUS = 'A') PAC_ALOCADO
   WHERE SETOR.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
     AND SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
     AND QLE.CAD_SET_ID = SETOR.CAD_SET_ID
--     AND QLE.CAD_QLE_TP_QUARTO_LEITO = 'I'
     AND SETOR.CAD_SET_FL_PERMITEINTERN_OK = 'S'
     AND SETOR.CAD_SET_FL_ATIVO_OK = 'S'
     AND PAC_ALOCADO.CAD_CAD_QLE_ID(+) = QLE.CAD_QLE_ID
--     AND SETOR.CAD_SET_ID = pCAD_SET_ID
     AND QLE.CAD_SQL_CD_SIT_QUARTO_LEITO != 5 --DESCONSIDERANDO LEITOS DESATIVADOS POR REESTRUTURACAO  
 ORDER BY QLE.CAD_QLE_NR_QUARTO, QLE.CAD_QLE_NR_LEITO;
 io_cursor := v_cursor;
end PRC_CAD_MAPA_SETOR_S;
 
/
