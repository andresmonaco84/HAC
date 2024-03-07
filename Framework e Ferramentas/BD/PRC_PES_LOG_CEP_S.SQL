create or replace procedure PRC_PES_LOG_CEP_S
  (
     pNOME_LOG     IN CEP.NOME_LOG%TYPE DEFAULT NULL,
     pNOME_LOCAL   IN LOCALIDADES.NOME_LOCAL%TYPE DEFAULT NULL,
     pUF_LOCAL     IN LOCALIDADES.UF_LOCAL%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_PES_LOG_CEP_S
  *
  *    Data Criacao: 	  13/10/2007         Por: Fabiola Lopes
  *    Data Alteracao:	data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Pesquisa de Logradouro
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
			SELECT T.NOME_TIPO TIPOLOGRADOURO,
             C.NOME_LOG NOMELOGRADOURO,
             B.EXTENSO_BAI BAIRRO,
             L.NOME_LOCAL CIDADE,
             C.UF_LOG UF,
             C.CEP9_LOG CEP,
             C.COMPLE_LOG COMPLEMENTO
      FROM
             CEP C,
             BAIRROS B,
             LOCALIDADES L,
             TIPO_LOGR T

      WHERE  C.CHVLOCAL_LOG = L.CHAVE_LOCAL(+)
      AND    C.CHVTIPO_LOG = T.CHAVE_TIPO(+)
      AND    C.CHVBAI1_LOG = B.CHAVE_BAI(+)
      AND    C.CHVLOCAL_LOG = B.CHVLOC_BAI(+)
      AND    L.SIT_LOCAL = 1 
      AND    ( UPPER( '%'||pNOME_LOG||'%' ) IS NULL OR C.NOME_LOG LIKE UPPER( '%'||pNOME_LOG||'%' ) )
      AND    ( pNOME_LOCAL IS NULL OR L.NOME_LOCAL = pNOME_LOCAL )
      AND    ( pUF_LOCAL IS NULL OR L.UF_LOCAL LIKE pUF_LOCAL )
      UNION
      SELECT DECODE(L.SIT_LOCAL, 0, NULL,T.NOME_TIPO), 
             DECODE(L.SIT_LOCAL, 0, NULL, C.NOME_LOG),
             DECODE(L.SIT_LOCAL, 0, NULL, B.EXTENSO_BAI),
             L.NOME_LOCAL, 		
             L.UF_LOCAL,
             L.CEP9_LOCAL,
             DECODE(L.SIT_LOCAL, 0, NULL,C.COMPLE_LOG)
      FROM
             CEP C,
             BAIRROS B, 
             LOCALIDADES L,
             TIPO_LOGR T
             
      WHERE  L.CHAVE_LOCAL = C.CHVLOCAL_LOG (+)
      AND    C.CHVTIPO_LOG = T.CHAVE_TIPO(+)
      AND    C.CHVBAI1_LOG = B.CHAVE_BAI(+)
      AND    C.CHVLOCAL_LOG = B.CHVLOC_BAI(+)
      AND    L.SIT_LOCAL = 0
      AND    ( pNOME_LOCAL IS NULL OR L.NOME_LOCAL = pNOME_LOCAL )
      AND    ( pUF_LOCAL IS NULL OR L.UF_LOCAL LIKE pUF_LOCAL );
        
  io_cursor := v_cursor;
  
  end PRC_PES_LOG_CEP_S;
/
