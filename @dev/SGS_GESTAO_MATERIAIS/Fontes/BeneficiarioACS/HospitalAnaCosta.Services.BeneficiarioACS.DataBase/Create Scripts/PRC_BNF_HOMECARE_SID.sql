create or replace procedure PRC_BNF_HOMECARE_SID
  (
     pBNF_HOMECARE_ID IN TB_BNF_HOMECARE.BNF_HOMECARE_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_BNF_HOMECARE_SID
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       BNF_HOMECARE_ID,
       BNF_COD_PLANO,
       BNF_LOJA_ID,
       BNF_BEN_ID,
       BNF_COD_SEQ,
       BNF_COD_NUM_PLANO,
       BNF_PLA_ID_PLANO,
       BNF_FL_ATIVO,
       BNF_ENDERECO,
       BNF_BAIRRO,
       BNF_UF,
       BNF_NUMERO,
       BNF_CEP,
       BNF_DDD,
       BNF_TELEFONE,
       BNF_DDD2,
       BNF_TELEFONE2,
       BNF_DDD3,
       BNF_TELEFONE3,
       BNF_COMP,
       BNF_TIPO_LOGRADOURO,
       BNF_OBS,
       BNF_EMAIL,
       BNF_MUN_CD_IBGE
    FROM TB_BNF_HOMECARE
    WHERE
        BNF_HOMECARE_ID = pBNF_HOMECARE_ID;          
    io_cursor := v_cursor;
  end PRC_BNF_HOMECARE_SID;
