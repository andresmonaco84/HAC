create or replace procedure PRC_BNF_VALIDA_REST_FINANC
(
       pCODCON    IN BNF_RESTRICAO_BENEF.CODCON%TYPE,
       pCODEST    IN BNF_RESTRICAO_BENEF.CODEST%TYPE,
       pCODBEN    IN BNF_RESTRICAO_BENEF.CODBEN%TYPE,
       pCODSEQBEN IN BNF_RESTRICAO_BENEF.CODSEQBEN%TYPE,
       io_cursor OUT PKG_CURSOR.t_cursor 
)       
is
       v_cursor PKG_CURSOR.t_cursor;       
begin
   OPEN v_cursor FOR  
     SELECT B.ID_TRAVA AS RETORNO
       FROM BNF_RESTRICAO_BENEF A, 
            BNF_RESTRICAO       B
            WHERE A.CODCON  = pCODCON
            AND A.CODEST    = pCODEST                                            				
            AND A.CODBEN    = pCODBEN
            AND A.CODSEQBEN = pCODSEQBEN
            AND ((A.DT_RESTRICAO <= TO_CHAR(SYSDATE,'DD-MON-YY')
            AND A.DT_LIBERACAO >= TO_CHAR(SYSDATE,'DD-MON-YY')
            AND A.HR_LIBERACAO > TO_CHAR(SYSDATE,'HH24:MI'))
            OR (A.DT_RESTRICAO <= TO_CHAR(SYSDATE,'DD-MON-YY')
            AND A.DT_LIBERACAO IS NULL))
            AND B.CD_RESTRICAO = A.CD_RESTRICAO;

  
   io_cursor := v_cursor;  
end PRC_BNF_VALIDA_REST_FINANC;
