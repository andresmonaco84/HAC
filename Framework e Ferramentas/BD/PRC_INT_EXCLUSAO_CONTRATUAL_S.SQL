create or replace procedure PRC_INT_EXCLUSAO_CONTRATUAL_S
  (
     pCODCON IN BNF_BENEFICIARIO.CODCON%type,
     pCODEST IN BNF_BENEFICIARIO.CODEST%type,
     pCODBEN IN BNF_BENEFICIARIO.CODBEN%type,
     pCODSEQBEN IN BNF_BENEFICIARIO.CODSEQBEN%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_EXCLUSAO_CONTRATUAL_S
  *
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

    Select C.CODPLA, B.CODEXC, B.DESEXC
     from  BNF_BENEFICIARIO A,
           BNF_EXCLUSAO B,
           BNF_EXCLUSAO_PLANO C
    where  A.CODCON = pCODCON
      and  A.CODEST = pCODEST
      and  A.CODBEN = pCODBEN
      and  A.CODSEQBEN = pCODSEQBEN
      and  A.CODPLA = C.CODPLA
      and  C.CODEXC = B.CODEXC
      order by 3;

    io_cursor := v_cursor;
  end PRC_INT_EXCLUSAO_CONTRATUAL_S;

