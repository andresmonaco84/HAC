create or replace function FNC_CAD_PES_ENDERECO_S
(
 PCAD_PES_ID_PESSOA in TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%type,
 PCD_TIPO_ENDERECO in TB_CAD_TEL_TELEFONE.AUX_TTE_CD_TP_TEL_END%type
)
return varchar2 is Result varchar2(200);

/********************************************************************
*    Procedure: FNC_CAD_PES_ENDERECO_S
*
*    Data Criacao:  17/09/2007   Por: Carlos ARaujo
*    Data de Alteração: 14/04/2009 por: Pedro
*       Alteração: add NM_BAIRRO
*
*    Funcao: Retornar o primeiro endereço da pessoa
*            por um determinado tipo (1=Residencial,2=Comercial, etc.. (tb_aux_tte_tp_tel_endereco)
*
*******************************************************************/

begin

  SELECT  ENDE.CAD_END_NM_BAIRRO || ', ' || ENDE.CAD_END_NM_LOGRADOURO || ', ' || ENDE.CAD_END_DS_NUMERO ||
          ' ' || ENDE.CAD_END_DS_COMPLEMENTO INTO Result

  FROM    TB_CAD_END_ENDERECO ENDE,
          TB_CAD_PES_PESSOA PES--,
--          TB_ASS_PEE_PESSOA_ENDERECO PEE
  WHERE
--          PEE.CAD_END_ID_ENDERECO = ENDE.CAD_END_ID_ENDERECO
  -- AND  
     ENDE.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
  AND     PES.CAD_PES_ID_PESSOA = PCAD_PES_ID_PESSOA
  AND     ENDE.AUX_TTE_CD_TP_TEL_END = PCD_TIPO_ENDERECO
  AND     rownum = 1;

  return(Result);
end FNC_CAD_PES_ENDERECO_S;
