  create or replace procedure PRC_BNF_BENEFICIARIO_S 
  (
     pCODCON IN BNF_BENEFICIARIO.CODCON%type DEFAULT NULL,  
     pCD_EMPRESA IN BNF_BENEFICIARIO.CD_EMPRESA%type DEFAULT NULL,
     pCODEST IN BNF_BENEFICIARIO.CODEST%type DEFAULT NULL,
     pCODBEN IN BNF_BENEFICIARIO.CODBEN%type DEFAULT NULL,
     pCODSEQBEN IN BNF_BENEFICIARIO.CODSEQBEN%type DEFAULT NULL,
     pSEXBEN IN BNF_BENEFICIARIO.SEXBEN%type DEFAULT NULL,
     pNOMBEN IN BNF_BENEFICIARIO.NOMBEN%type DEFAULT NULL,
     pDATNASBEN IN BNF_BENEFICIARIO.DATNASBEN%type DEFAULT NULL,
     pCODPAC IN BNF_BENEFICIARIO.CODPAC%type DEFAULT NULL,
     pCODINDBEN IN BNF_BENEFICIARIO.CODINDBEN%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor 
     
  ) 
  is
    
  /*********************************************************************
  *    Procedure: PRC_BNF_BENEFICIARIO_S
  *    Owner Tabela: Beneficiario
  * 
  *    Data Criacao:  	13/07/2007   Por: Carlos Eduardo
  *    Funcao: Lista beneficiários do Legado
  *  
  *    Data Alteracao:  08/08/2007   Por: Carlos Eduardo
  *    Alteração: Inclusão de campos cpf, rg, estado civil e situação
  *
  *    Data Alteracao:  06/11/2007   Por: Guilherme
  *    Alteração: Alteração da forma como se pesquisa o beneficiário. 
  *               Se o CodSeqBen não for informado, retornar o titular,
  *               onde codindben = 'S'
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
  *
  *    Data Alteracao: 21/01/2008  Por: Andrea Cazuca
  *    Alteração: Inclusão do campo CODPADATEBEN (Padrão)
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CODCON,
       CD_EMPRESA,
       CODEST,
       CODBEN,
       CODSEQBEN,
       CODINDBEN,
       NOMBEN,
       DATNASBEN,
       SEXBEN,
       CODPAC,
       MAEBEN,
       CPFBEN,
       RGBEN,
       ESTCIVBEN,
       CODSITBEN,
       CODPADATEBEN
    FROM BNF_BENEFICIARIO
    WHERE
        (pCODCON is null OR CODCON = upper(pCODCON)) AND     
        (pCD_EMPRESA is null OR CD_EMPRESA = pCD_EMPRESA) AND 
        (pCODEST is null OR CODEST = pCODEST) AND         
        (pCODBEN is null OR CODBEN = pCODBEN) AND 
        ((pCODSEQBEN is null AND codindben='S') OR CODSEQBEN = pCODSEQBEN)
        AND (pNOMBEN is null or NOMBEN like upper(pNOMBEN))
        AND (pSEXBEN is null OR SEXBEN = upper(pSEXBEN))
        AND (pDATNASBEN is null OR DATNASBEN = pDATNASBEN)
        AND (pCODPAC is null or CODPAC = pCODPAC)
        AND (pCODINDBEN is null or CODINDBEN = pCODINDBEN)
    ORDER BY NOMBEN;
    io_cursor := v_cursor;
  end PRC_BNF_BENEFICIARIO_S;
/
