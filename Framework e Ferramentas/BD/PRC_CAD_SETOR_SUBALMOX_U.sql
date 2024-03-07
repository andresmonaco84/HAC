CREATE OR REPLACE PROCEDURE PRC_CAD_SETOR_SUBALMOX_U(
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%type,
     pCAD_SET_FL_SUBSTALMOX_OK IN TB_CAD_SET_SETOR.CAD_SET_FL_SUBSTALMOX_OK%type,
     pCAD_SET_FL_ESTQPROPRIO_OK IN TB_CAD_SET_SETOR.CAD_SET_FL_ESTQPROPRIO_OK%type DEFAULT 'S'
     --pSEG_USU_ID_USUARIO  IN TB_CAD_SET_SETOR.SEG_USU_ID_USUARIO%type
  )
  is
-- Atualiza o centro de dispensac?o do setor
begin

    UPDATE TB_CAD_SET_SETOR
    SET
        CAD_SET_FL_SUBSTALMOX_OK = pCAD_SET_FL_SUBSTALMOX_OK,
        CAD_SET_FL_ESTQPROPRIO_OK = NVL(pCAD_SET_FL_ESTQPROPRIO_OK,'S')
        --SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    WHERE
        CAD_SET_ID = pCAD_SET_ID;

end PRC_CAD_SETOR_SUBALMOX_U;