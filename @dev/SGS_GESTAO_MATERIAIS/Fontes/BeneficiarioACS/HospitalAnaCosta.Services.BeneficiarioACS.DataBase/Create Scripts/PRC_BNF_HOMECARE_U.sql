create or replace procedure PRC_BNF_HOMECARE_U
  (
     pBNF_HOMECARE_ID IN TB_BNF_HOMECARE.BNF_HOMECARE_ID%type,
     /*pBNF_COD_PLANO IN TB_BNF_HOMECARE.BNF_COD_PLANO%type,
     pBNF_LOJA_ID IN TB_BNF_HOMECARE.BNF_LOJA_ID%type,
     pBNF_BEN_ID IN TB_BNF_HOMECARE.BNF_BEN_ID%type,
     pBNF_COD_SEQ IN TB_BNF_HOMECARE.BNF_COD_SEQ%type,
     pBNF_COD_NUM_PLANO IN TB_BNF_HOMECARE.BNF_COD_NUM_PLANO%type,*/
     pBNF_PLA_ID_PLANO IN TB_BNF_HOMECARE.BNF_PLA_ID_PLANO%type,
     pBNF_FL_ATIVO IN TB_BNF_HOMECARE.BNF_FL_ATIVO%type,
     pBNF_ENDERECO IN TB_BNF_HOMECARE.BNF_ENDERECO%type,
     pBNF_BAIRRO IN TB_BNF_HOMECARE.BNF_BAIRRO%type,
     pBNF_UF IN TB_BNF_HOMECARE.BNF_UF%type,
     pBNF_NUMERO IN TB_BNF_HOMECARE.BNF_NUMERO%type default NULL,
     pBNF_CEP IN TB_BNF_HOMECARE.BNF_CEP%type default NULL,
     pBNF_DDD IN TB_BNF_HOMECARE.BNF_DDD%type default NULL,
     pBNF_TELEFONE IN TB_BNF_HOMECARE.BNF_TELEFONE%type default NULL,
     pBNF_DDD2 IN TB_BNF_HOMECARE.BNF_DDD2%type default NULL,
     pBNF_TELEFONE2 IN TB_BNF_HOMECARE.BNF_TELEFONE2%type default NULL,
     pBNF_DDD3 IN TB_BNF_HOMECARE.BNF_DDD3%type default NULL,
     pBNF_TELEFONE3 IN TB_BNF_HOMECARE.BNF_TELEFONE3%type default NULL,
     pBNF_COMP IN TB_BNF_HOMECARE.BNF_COMP%type default NULL,
     pBNF_TIPO_LOGRADOURO IN TB_BNF_HOMECARE.BNF_TIPO_LOGRADOURO%type default NULL,
     pBNF_OBS IN TB_BNF_HOMECARE.BNF_OBS%type default NULL,
     pBNF_MUN_CD_IBGE IN TB_BNF_HOMECARE.BNF_MUN_CD_IBGE%type default NULL,
     pBNF_EMAIL IN TB_BNF_HOMECARE.BNF_EMAIL%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_BNF_HOMECARE_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_BNF_HOMECARE
    SET	   
        /*BNF_COD_PLANO = pBNF_COD_PLANO,
        BNF_LOJA_ID = pBNF_LOJA_ID,
        BNF_BEN_ID = pBNF_BEN_ID,
        BNF_COD_SEQ = pBNF_COD_SEQ,
        BNF_COD_NUM_PLANO = pBNF_COD_NUM_PLANO,*/
        BNF_PLA_ID_PLANO = pBNF_PLA_ID_PLANO,
        BNF_FL_ATIVO = pBNF_FL_ATIVO,
        BNF_ENDERECO = pBNF_ENDERECO,
        BNF_BAIRRO = pBNF_BAIRRO,
        BNF_UF = pBNF_UF,
        BNF_NUMERO = pBNF_NUMERO,
        BNF_CEP = pBNF_CEP,
        BNF_DDD = pBNF_DDD,
        BNF_TELEFONE = pBNF_TELEFONE,
        BNF_DDD2 = pBNF_DDD2,
        BNF_TELEFONE2 = pBNF_TELEFONE2,
        BNF_DDD3 = pBNF_DDD3,
        BNF_TELEFONE3 = pBNF_TELEFONE3,
        BNF_COMP = pBNF_COMP,
        BNF_TIPO_LOGRADOURO = pBNF_TIPO_LOGRADOURO,
        BNF_OBS = pBNF_OBS,
        BNF_EMAIL = pBNF_EMAIL ,
        BNF_MUN_CD_IBGE = pBNF_MUN_CD_IBGE
    WHERE
        BNF_HOMECARE_ID = pBNF_HOMECARE_ID;	
  end PRC_BNF_HOMECARE_U;
