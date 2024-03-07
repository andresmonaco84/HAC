create or replace function FNC_CAD_PES_TELEFONE_LISTA_S
(
   PCAD_PES_ID_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%TYPE
) 
return varchar2 is
  Result VARCHAR2(5000);
  
  /********************************************************************
  *    Função: FNC_CAD_PES_TELEFONE_LISTA_S
  *
  *    Data Criacao:  23/10/2007   Por: Guilherme
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Utilidade: Retornar todos os telefones de uma pessoa, 
  *               separados por ' / '
  *******************************************************************/
 
begin
  with data
   as
   (
      SELECT lista_telefone, row_number() over (order by lista_telefone) numero_linha, count(*) over () contagem_registro
         from
         (
           SELECT DISTINCT TEL.CAD_TEL_NR_NUM_TEL lista_telefone
     FROM   TB_CAD_TEL_TELEFONE TEL
     WHERE  TEL.CAD_PES_ID_PESSOA = PCAD_PES_ID_PESSOA
         )
   )
select ltrim(sys_connect_by_path(lista_telefone, ' / '),' / ') conjunto_telefones INTO RESULT
   from data
   where numero_linha = contagem_registro
   start with numero_linha = 1
   connect by prior numero_linha = numero_linha-1;

  return(Result);
end FNC_CAD_PES_TELEFONE_LISTA_S;
