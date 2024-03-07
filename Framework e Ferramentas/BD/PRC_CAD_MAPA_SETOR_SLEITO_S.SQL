CREATE OR REPLACE PROCEDURE "PRC_CAD_MAPA_SETOR_SLEITO_S"
(
 pCAD_UNI_ID_UNIDADE            IN TB_CAD_SET_SETOR.CAD_UNI_ID_UNIDADE%TYPE,
 io_cursor                     OUT PKG_CURSOR.t_cursor
)
is
  /********************************************************************
  *    Procedure: PRC_CAD_MAPA_SETOR_SLEITO_S
  *
  *    Data Criacao:   data da  criac?o   Por: Nome do Analista
  *    Data Alteracao:  data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;

BEGIN
  OPEN v_cursor FOR

       SELECT DISTINCT PES.CAD_PES_NM_PESSOA ||' - ' || SETOR.CAD_SET_DS_SETOR CAD_SET_DS_SETOR, SETOR.CAD_SET_ID,
              PES.CAD_PES_NM_PESSOA, SETOR.CAD_SET_DS_SETOR, SETOR.CAD_SET_CD_SETOR
                FROM TB_CAD_SET_SETOR SETOR, TB_CAD_UNI_UNIDADE UNI, TB_CAD_PES_PESSOA PES
               WHERE UNI.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
                 AND UNI.CAD_UNI_ID_UNIDADE = SETOR.CAD_UNI_ID_UNIDADE
                 AND NOT EXISTS ( SELECT *
                                    FROM TB_CAD_QLE_QUARTO_LEITO QLE
                                   WHERE SETOR.CAD_SET_ID = QLE.CAD_SET_ID)
                 AND ((SETOR.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE  AND SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = 27
                        AND SETOR.CAD_SET_FL_MOVIMENTAPACINT_OK = 'S')
                  OR   (SETOR.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE AND SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = 29
                        AND (SETOR.CAD_SET_FL_PERMITEINTERN_OK = 'S' OR SETOR.CAD_SET_FL_MOVIMENTAPACINT_OK = 'S'))
                  OR   (SETOR.CAD_UNI_ID_UNIDADE != pCAD_UNI_ID_UNIDADE AND SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = 27
                        AND SETOR.CAD_SET_FL_MOVIMENTAPACINT_OK = 'S'))
                 AND SETOR.CAD_SET_FL_ATIVO_OK = 'S'
                 ORDER BY SETOR.CAD_SET_DS_SETOR, PES.CAD_PES_NM_PESSOA;

  io_cursor := v_cursor;

end PRC_CAD_MAPA_SETOR_SLEITO_S;
 
