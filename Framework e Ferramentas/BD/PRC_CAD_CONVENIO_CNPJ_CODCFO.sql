CREATE OR REPLACE PROCEDURE PRC_CAD_CONVENIO_CNPJ_CODCFO
  (
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_UNIDADE_REGIONAIS
  *
  *    Data Criacao:  19/03/2012   Por: André
  *
  *    Funcao: Query para retornar o cod. fornecedor do RM
  *            relacionando o convênio com o CNPJ
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

    SELECT TRIM(leading '0' FROM P.CAD_PES_NR_CNPJ_CPF) CONVENIO_CNPJ,
           (SELECT TRIM(leading '0' FROM REPLACE(REPLACE(REPLACE(CGCCFO, '/', ''), '.',''),'-','')) CGCCFO
            FROM FCFO@RM
            WHERE CODCOLIGADA = 1 AND  TRIM(leading '0' FROM REPLACE(REPLACE(REPLACE(CGCCFO, '/', ''), '.',''),'-','')) =
                  TRIM(leading '0' FROM P.CAD_PES_NR_CNPJ_CPF) AND ROWNUM = 1) FCFO_CNPJ,
           (SELECT TRIM(leading '0' FROM CODCFO) CGCCFO
            FROM FCFO@RM
            WHERE CODCOLIGADA = 1 AND  TRIM(leading '0' FROM REPLACE(REPLACE(REPLACE(CGCCFO, '/', ''), '.',''),'-','')) =
                  TRIM(leading '0' FROM P.CAD_PES_NR_CNPJ_CPF) AND ROWNUM = 1) CODCFO,
            C.CAD_CNV_ID_CONVENIO
    FROM TB_CAD_CNV_CONVENIO C,
         TB_CAD_PES_PESSOA P
    WHERE P.CAD_PES_ID_PESSOA = C.CAD_PES_ID_PESSOA
      AND ROWNUM = 1
      AND C.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO;

    io_cursor := v_cursor;
  end PRC_CAD_CONVENIO_CNPJ_CODCFO;
