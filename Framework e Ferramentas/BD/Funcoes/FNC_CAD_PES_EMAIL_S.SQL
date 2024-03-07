/********************************************************************
*    Procedure: FNC_CAD_PES_EMAIL_S
* 
*    Data Criacao:  17/09/2007   Por: Carlos ARaujo
*    Data Alteracao:             Por: 
*
*    Funcao: Retornar o primeiro email de uma determinada pessoa 
*
*******************************************************************/
create or replace function FNC_CAD_PES_EMAIL_S
(
 PCAD_PES_ID_PESSOA in TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%type
) 
return TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_NM_EMAIL%type is Result TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_NM_EMAIL%type;
begin
     SELECT PEM.ASS_PEM_NM_EMAIL into Result
     FROM   TB_ASS_PEM_PESSOA_EMAIL PEM
     WHERE  PEM.CAD_PES_ID_PESSOA = PCAD_PES_ID_PESSOA
     AND    rownum = 1;            
  return(Result);
end FNC_CAD_PES_EMAIL_S;
/
