CREATE OR REPLACE PROCEDURE PRC_SEG_TROCA_SENHA
   ( 
      pSEG_USU_DS_LOGIN    IN  TB_SEG_USU_USUARIO.SEG_USU_DS_LOGIN%TYPE,
      pSEG_USU_CD_PASSWORD IN  TB_SEG_USU_USUARIO.SEG_USU_CD_PASSWORD%TYPE,
      pNOVA_SENHA          IN  TB_SEG_USU_USUARIO.SEG_USU_CD_PASSWORD%TYPE,      
      io_cursor            OUT PKG_CURSOR.t_cursor
   )
   IS
  v_cursor PKG_CURSOR.t_cursor;   
  id       TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%TYPE;
  /*
  0 FLAG STATUS ESTA SENDO CONVERTIDO PARA NUMBER PARA MANTER COMPATIBILIDADE COM ENUM DENTRO DO SISTEMA
  0 = INATIVO
  1 = ATIVO
  2 = BLOQUEADO
  */
BEGIN
   -- OPEN v_cursor FOR
   -- VERIFICA SE É UM USUÁRIO VÁLIDO
   BEGIN
      
      FOR vrecUSUARIO in (SELECT SEG_USU_ID_USUARIO
                            FROM TB_SEG_USU_USUARIO USUARIO
                           WHERE SEG_USU_DS_LOGIN    = UPPER(pSEG_USU_DS_LOGIN)
                             AND SEG_USU_CD_PASSWORD = SGS.MD5(pSEG_USU_CD_PASSWORD)) LOOP
                             
          -- VALIDOU, ATUALIZA SENHA
          UPDATE TB_SEG_USU_USUARIO SET
          SEG_USU_CD_PASSWORD = SGS.MD5(pNOVA_SENHA)
          WHERE SEG_USU_ID_USUARIO = vrecUSUARIO.Seg_Usu_Id_Usuario;
          
          id := vrecUSUARIO.Seg_Usu_Id_Usuario;
      
      END LOOP;                            
      
      OPEN v_cursor FOR
      SELECT SEG_USU_ID_USUARIO, 
             SEG_USU_DS_NOME, 
             DECODE(SEG_USU_FL_STATUS, 'I', 0,  
                                       'A', 1, 
                                       'B', 2) SEG_USU_FL_STATUS
      FROM TB_SEG_USU_USUARIO USUARIO
      WHERE SEG_USU_DS_LOGIN    = UPPER(pSEG_USU_DS_LOGIN)
      AND   SEG_USU_CD_PASSWORD = SGS.MD5(pNOVA_SENHA);
      
   EXCEPTION
      WHEN NO_DATA_FOUND THEN
         NULL;       
   END;
   io_cursor := v_cursor;

END; -- Procedure
