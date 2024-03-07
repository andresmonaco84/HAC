create or replace procedure PRC_CAD_CEP_S
  (
     pCEP9_LOG     IN CEP.CEP9_LOG%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CEP_S
  *
  *    Data Criacao: 	  13/10/2007         Por: Fabiola Lopes
  *    Data Alteracao:	data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Pesquisa de CEP
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
		     SELECT
                  B.EXTENSO_BAI BAIRRO,
                  L.NOME_LOCAL CIDADE,
                  L.UF_LOCAL UF,
         	        T.NOME_TIPO TIPO,
                  C.NOME_LOG ENDERECO

         FROM     CEP C,
                  BAIRROS B,
                  LOCALIDADES L,
                  TIPO_LOGR T

         WHERE    C.CEP9_LOG = pCEP9_LOG
         AND      C.CHVLOCAL_LOG = L.CHAVE_LOCAL(+)
         AND      C.CHVTIPO_LOG  = T.CHAVE_TIPO(+)
         AND      C.CHVBAI1_LOG = B.CHAVE_BAI(+)
         AND      C.CHVLOCAL_LOG = B.CHVLOC_BAI(+)
         UNION
         SELECT
                 B.EXTENSO_BAI,
                 L.NOME_LOCAL,
                 l.UF_LOCAL,
                 T.NOME_TIPO,
                 C.NOME_LOG

         FROM
                 CEP C,
                 BAIRROS B,
                 LOCALIDADES L,
                 TIPO_LOGR T

         WHERE   L.CEP9_LOCAL = pCEP9_LOG
         AND     L.CHAVE_LOCAL= C.CHVLOCAL_LOG(+)
         AND     C.CHVTIPO_LOG  = T.CHAVE_TIPO(+)
         AND     C.CHVBAI1_LOG = B.CHAVE_BAI(+)
         AND     C.CHVLOCAL_LOG = B.CHVLOC_BAI(+);

  io_cursor := v_cursor;

  end PRC_CAD_CEP_S;
