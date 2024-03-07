create or replace procedure PRC_CAD_SETOR_ALMOX_CENTRAL_U(
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%type,
     pCAD_SET_ALMOX_CENTRAL IN TB_CAD_SET_SETOR.CAD_SET_ALMOX_CENTRAL%type
     --pSEG_USU_ID_USUARIO  IN TB_CAD_SET_SETOR.SEG_USU_ID_USUARIO%type
  )
  is
-- Atualiza o Almoxarifado Central
begin

    IF (pCAD_SET_ALMOX_CENTRAL = 1) THEN
      -- Remove o Almoxarifado Central, caso já esteja cadastrado
      UPDATE TB_CAD_SET_SETOR SET CAD_SET_ALMOX_CENTRAL = 0;
    END IF;
    
    BEGIN
      -- Grava o Novo Almoxarifado Central
      UPDATE TB_CAD_SET_SETOR
      SET
          CAD_SET_ALMOX_CENTRAL = pCAD_SET_ALMOX_CENTRAL
          --SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
      WHERE
          CAD_SET_ID = pCAD_SET_ID;
    END;
        
    COMMIT;    
      
end PRC_CAD_SETOR_ALMOX_CENTRAL_U;
