 create or replace procedure PRC_INT_QLE_CORRECAO
(
     pCAD_QLE_ID IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_ID%TYPE DEFAULT NULL
)
is
/********************************************************************
*    Procedure: PRC_INT_QLE_CORRECAO
*
*    Data Criacao:    12/1/2012   Por: Pedro
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Existem pontos no sistema n�o identificados em que o leito fica com status != de ocupado estando ocupado
*
*******************************************************************/
BEGIN
DECLARE

  CURSOR NAOOCUPADO IS

      SELECT QLE.CAD_QLE_ID
      FROM   TB_CAD_QLE_QUARTO_LEITO QLE, TB_CAD_SET_SETOR SETOR, TB_CAD_UNI_UNIDADE UNI
      WHERE  QLE.CAD_SQL_CD_SIT_QUARTO_LEITO != 2
      AND    QLE.CAD_SET_ID                   = SETOR.CAD_SET_ID
      AND    SETOR.CAD_UNI_ID_UNIDADE         = UNI.CAD_UNI_ID_UNIDADE
      AND    pCAD_QLE_ID IS NULL OR QLE.CAD_QLE_ID = pCAD_QLE_ID

      AND EXISTS (SELECT *
                  FROM   TB_ATD_IML_INT_MOV_LEITO IML
                  WHERE  IML.CAD_CAD_QLE_ID    = QLE.CAD_QLE_ID
                  AND    IML.ATD_IML_DT_SAIDA IS NULL
                  AND    IML.ATD_IML_FL_STATUS = 'A')
      ;
/*
  CURSOR NAOLIBERADO IS

        SELECT QLE.CAD_QLE_ID
        FROM   TB_CAD_QLE_QUARTO_LEITO QLE, TB_CAD_SET_SETOR SETOR, TB_CAD_UNI_UNIDADE UNI
        WHERE  QLE.CAD_SQL_CD_SIT_QUARTO_LEITO = 2
        AND    QLE.CAD_SET_ID                  = SETOR.CAD_SET_ID
        AND    SETOR.CAD_UNI_ID_UNIDADE        = UNI.CAD_UNI_ID_UNIDADE
        AND    pCAD_QLE_ID IS NULL OR QLE.CAD_QLE_ID = pCAD_QLE_ID

        AND NOT EXISTS (SELECT *
                        FROM TB_ATD_IML_INT_MOV_LEITO IML
                        WHERE IML.CAD_CAD_QLE_ID  = QLE.CAD_QLE_ID
                        AND IML.ATD_IML_DT_SAIDA IS NULL
                        AND IML.ATD_IML_FL_STATUS = 'A')
        ;*/

BEGIN

    FOR I IN NAOOCUPADO LOOP
    UPDATE TB_CAD_QLE_QUARTO_LEITO QLE
    SET    QLE.CAD_SQL_CD_SIT_QUARTO_LEITO = 2
    WHERE  QLE.CAD_QLE_ID                  = I.CAD_QLE_ID;
    END LOOP;

   /* FOR J IN NAOLIBERADO LOOP
    UPDATE TB_CAD_QLE_QUARTO_LEITO QLE
    SET    QLE.CAD_SQL_CD_SIT_QUARTO_LEITO = 1
    WHERE  QLE.CAD_QLE_ID                  = J.CAD_QLE_ID;
    END LOOP;*/

END;
  -- ;

end PRC_INT_QLE_CORRECAO;
