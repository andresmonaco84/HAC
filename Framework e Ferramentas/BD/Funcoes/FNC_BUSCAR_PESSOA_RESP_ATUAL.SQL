create or replace function FNC_BUSCAR_PESSOA_RESP_ATUAL(pATD_ATE_ID in Tb_Atd_Ate_Atendimento.atd_ate_id%type)
/*
Buscar o RESPONSAVEL atual
*/
 return NUMBER is
 Result NUMBER;
begin

if (pATD_ATE_ID is not null) THEN

  SELECT ARE.CAD_PES_ID_PESSOA INTO RESULT
  FROM
(SELECT ARE.CAD_PES_ID_PESSOA
        FROM TB_ASS_ARE_ATD_RESPONSAVEL ARE
        WHERE ARE.ATD_ATE_ID = pATD_ATE_ID
        ORDER BY ARE.FAT_CCP_ID DESC
 ) ARE
 WHERE ROWNUM = 1
;

END if;

  return(Result);
end FNC_BUSCAR_PESSOA_RESP_ATUAL;
