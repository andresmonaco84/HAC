create or replace procedure PRC_ATD_IAE_PRE_CADASTRO
(
     pCAD_PAC_ID_PACIENTE IN Tb_Atd_Iae_Int_Age_Eletiva.CAD_PAC_ID_PACIENTE%type,

     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  
  v_cursor PKG_CURSOR.t_cursor;
  begin
     OPEN v_cursor FOR
      SELECT * FROM Tb_Atd_Iae_Int_Age_Eletiva
      WHERE 
      CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
      AND ATD_IAE_DT_ATENDIMENTO >= TRUNC(SYSDATE);
     
  io_cursor := v_cursor;
END PRC_ATD_IAE_PRE_CADASTRO; 