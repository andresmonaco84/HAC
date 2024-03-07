create or replace procedure PRC_BNF_ENDERECO_BENEF_S
  (
     pCODCON IN BNF_BENEFICIARIO.CODCON%type DEFAULT NULL,  
     pCODEST IN BNF_BENEFICIARIO.CODEST%type DEFAULT NULL,
     pCODBEN IN BNF_BENEFICIARIO.CODBEN%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor 
     
  ) 
  is
    
  /*********************************************************************
  *    Procedure: PRC_BNF_ENDERECO_BENEF_S
  *    Owner Tabela: Beneficiario
  * 
  *    Data Criacao:  	15/08/2007   Por: Guilherme Holdack
  *    Funcao: Lista os endereços dos beneficiários do Legado
  *  
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR    

    SELECT	
            codcon,
            codest,
            codben,
            codcid,
            endben,
            baiben
            ufben,
            obs,
            cepben,
            telben,
            dddben,
            telben1,
            dddben1,
            telben2,
            dddben2,
            email,
            numend,
            compend
    FROM BNF_ENDERECO_BENEF

    WHERE
        (pCODCON is null OR CODCON = upper(pCODCON)) AND     
        (pCODEST is null OR CODEST = pCODEST) AND         
        (pCODBEN is null OR CODBEN = pCODBEN);
        
    io_cursor := v_cursor;
  end PRC_BNF_ENDERECO_BENEF_S;
/
