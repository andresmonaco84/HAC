DECLARE
  CURSOR AGENDA IS
    SELECT AGD.AGE_AGD_ID,
           AGD.AGE_ESM_ID,
           AGD.CAD_PRO_ID_PROFISSIONALEXEC,
           ESM.CAD_PRO_ID_PROFISSIONAL
      FROM TB_AGE_AGD_AGENDA AGD, TB_AGE_ESM_ESCALA_MEDICA ESM
     WHERE AGD.AGE_AGD_DT_ATENDIMENTO >= TRUNC(SYSDATE) - 1
           AND AGD.AGE_ESM_ID = ESM.AGE_ESM_ID
     AND AGD.CAD_PRO_ID_PROFISSIONALEXEC != ESM.CAD_PRO_ID_PROFISSIONAL;
  V_CONTADOR NUMBER;
BEGIN
  V_CONTADOR := 0;
  FOR I IN AGENDA LOOP
    DBMS_OUTPUT.PUT_LINE('AGE_AGD_ID = ' || TO_CHAR(I.AGE_AGD_ID) ||
                         ' / CAD_PRO_ID_PROFISSIONALEXEC = ' ||
                         TO_CHAR(I.CAD_PRO_ID_PROFISSIONALEXEC) ||
                         ' / CAD_PRO_ID_PROFISSIONAL = ' ||
                         TO_CHAR(I.CAD_PRO_ID_PROFISSIONAL));
    V_CONTADOR := V_CONTADOR + 1;
    UPDATE TB_AGE_AGD_AGENDA AGD
       SET AGD.CAD_PRO_ID_PROFISSIONALEXEC = I.CAD_PRO_ID_PROFISSIONAL
     WHERE AGD.AGE_AGD_ID = I.AGE_AGD_ID;
  END LOOP;
  IF V_CONTADOR > 0 THEN
    DBMS_OUTPUT.PUT_LINE('TOTAL DE AGENDAMENTOS COM PROFISSIONAL EXECUTANTE DIFERENTE DO PROFISSIONAL DA ESCALA: ' ||
                         TO_CHAR(V_CONTADOR));
  ELSE
    DBMS_OUTPUT.PUT_LINE('NENHUM AGENDAMENTO COM PROFISSIONAL EXECUTANTE DIFERENTE DO PROFISSIONAL DA ESCALA.');
  END IF;
END;
