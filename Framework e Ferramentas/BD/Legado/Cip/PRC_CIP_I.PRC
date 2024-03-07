create or replace procedure sgs.PRC_CIP_I
  (
     pNewIdt OUT integer,
     pCIP IN CIP.CIP%type,
     pCODCON IN CIP.CODCON%type,
     pCODEST IN CIP.CODEST%type default NULL,
     pCODBEN IN CIP.CODBEN%type default NULL,
     pCODSEQDEP IN CIP.CODSEQDEP%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CIP_I
  * 
  *    Data Criacao: 	28/01/2008   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteracao  Por: Nome do Analista
  *
  *    Data Alteracao: 	16/04/2009   Por: Davi Silvestre M. dos Reis
  *    Alteracao:	verificacao da existencia de numero gerado para 
  *               evitar duplicacao do prontuario
  *               
  *    Funcao: Insere dados da Cip
  *
  *******************************************************************/  
  
  lIdtRetorno integer;
  iTemp integer;
	  
  begin
  
  -- gera novo numero sequencial para prontuario
  SELECT NR_SEQRG.NextVal INTO lIdtRetorno FROM DUAL;
  
  -- verifica se o numero ja existe na paciente_atendimento_amb ou
  -- na tb_internado; em caso afirmativo, gera novo numero
  LOOP
     iTemp := 0;
     SELECT 1 INTO iTemp FROM DUAL
      WHERE EXISTS ( SELECT *
                       FROM paciente_atendimento_amb PAA 
                      WHERE PAA.codpac = lIdtRetorno)
         OR EXISTS ( SELECT *
                       FROM tb_internado inter 
                      WHERE inter.codpac = lIdtRetorno);
     EXIT WHEN iTemp != 1;
     
     SELECT NR_SEQRG.NextVal INTO lIdtRetorno FROM DUAL;
  END LOOP;

    INSERT INTO CIP
    (
       CIP,
       RG,
       CODCON,
       CODEST,
       CODBEN,
       CODSEQDEP
    )
    VALUES
    (
	     pCIP,
	     lIdtRetorno,
	     pCODCON,
	     pCODEST,
	     pCODBEN,
	     pCODSEQDEP
    );
    pNewIdt := lIdtRetorno;
	
  end PRC_CIP_I;
/
