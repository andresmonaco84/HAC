create or replace procedure PRC_FAT_RM_GERABOLETO (pATENDIMENTO in number,
                                                   pVALOR       in number,
                                                   pCODCFO      in varchar2,
                                                   io_cursor       out PKG_CURSOR.t_cursor) is

  v_cursor   PKG_CURSOR.t_cursor;

begin     

  OPEN v_cursor FOR
    SELECT '0' || 
           '1' || 
           RPAD('REMESSA', 7, ' ') || 
           '01' ||
           RPAD('COBRANCA', 15, ' ') || 
           RPAD('2973', 4, '0') || 
           '00' ||
           RPAD('00600', 5, '0') || 
           RPAD('6', 1, '0') || 
           RPAD(' ', 8, ' ') ||
           RPAD('HOSPITAL ANA COSTA SA', 30, ' ') || 
           '341' ||
           RPAD('BANCO ITAU SA', 15, ' ') ||
           LPAD(TO_CHAR(SYSDATE, 'DDMMYY'), 6, '0') || 
           LPAD(' ', 294, ' ') ||
           LPAD(TO_CHAR(1), 6, '0')
      FROM DUAL
    UNION
    --DETAIL
    SELECT '1' || 
           '02' || 
           RPAD('68253731000182', 14, 0) || 
           RPAD('2973', 4, '0') || '00' ||
           RPAD('00600', 5, '0') || 
           RPAD('6', 1, '0') || 
           RPAD(' ', 4, ' ') ||
           RPAD('0', 4, '0') || 
           RPAD(' ', 25, ' ') ||
           LPAD(TO_CHAR(pATENDIMENTO), 8, '0') || 
           LPAD('0', 8, '0') ||
           LPAD('0', 5, '0') || 
           RPAD('175', 3, '0') || 
           RPAD(' ', 21, ' ') ||
           RPAD('I', 1, ' ') || 
           RPAD('01', 2, '0') || 
           RPAD('51', 10, ' ') ||
           LPAD(TO_CHAR(SYSDATE + 3, 'DDMMYY'), 6, '0') ||
           LPAD(REPLACE(REPLACE(TO_CHAR(pVALOR, '999999990.000'), ',', '.'), ' ', '0'), 13, '0') || 
           '341' || 
           RPAD('0', 5, '0') || 
           '99' || 
           'N' ||
           LPAD(TO_CHAR(SYSDATE, 'DDMMYY'), 6, '0') || 
           RPAD('54', 2, '0') ||
           RPAD('0', 2, '0') || 
           LPAD('0', 11, '0') || 
           LPAD('0', 2, '0') ||
           LPAD('0', 6, '0') || 
           LPAD('0', 11, '0') || 
           LPAD('0', 2, '0') ||
           LPAD('0', 11, '0') || 
           LPAD('0', 2, '0') || 
           LPAD('0', 11, '0') ||
           LPAD('0', 2, '0') || 
           DECODE(fcfo.pagrec, 2, '02', '01') ||
           LPAD('0' || cgccfo, 14, '0') || 
           RPAD(fcfo.nomefantasia, 30, ' ') ||
           RPAD(' ', 10, ' ') ||
           RPAD(fcfo.rua || ' ' || TO_CHAR(fcfo.numero) || ' ' || fcfo.complemento, 40, ' ') ||
           RPAD(fcfo.bairro, 12, ' ') || 
           LPAD(fcfo.cep, 8, '0') ||
           RPAD(fcfo.cidade, 15, ' ') || 
           RPAD(fcfo.codetd, 2, ' ') ||
           RPAD(' ', 30, ' ') || 
           RPAD(' ', 4, ' ') || 
           LPAD('0', 6, '0') ||
           LPAD('0', 2, '0') || 
           LPAD(' ', 1, ' ') || 
           LPAD(TO_CHAR(2), 6, '0')
      FROM rm.fcfo@rm
     where fcfo.codcfo = pCODCFO
    UNION
    --TRAILER
    SELECT '9' || 
           LPAD(' ',393,' ') || 
           LPAD(TO_CHAR(3),6,'0')
    FROM DUAL;
    
      io_cursor := v_cursor;
  
end;

