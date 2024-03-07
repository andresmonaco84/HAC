/********************************************************************
*    Procedure: FNC_CAD_PES_TELEFONE_S
* 
*    Data Criacao:  17/09/2007   Por: Carlos ARaujo
*    Data Alteracao:             Por: 
*
*    Funcao: Retornar o primeiro telefone de uma determinada pessoa de 
*            um determinado tipo (1=Residencial,2=Comercial, etc.. (tb_aux_tte_tp_tel_endereco)
*
*******************************************************************/
create or replace function FNC_CAD_PES_TELEFONE_S
(
 PCAD_PES_ID_PESSOA in TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%type, 
 PCD_TIPO_TELEFONE in TB_CAD_TEL_TELEFONE.AUX_TTE_CD_TP_TEL_END%type
) 
return varchar2 is Result varchar2(50);
begin
     SELECT TEL.CAD_TEL_NR_NUM_TEL into Result
     FROM   TB_CAD_TEL_TELEFONE TEL
     WHERE  TEL.CAD_PES_ID_PESSOA = PCAD_PES_ID_PESSOA
     AND    TEL.AUX_TTE_CD_TP_TEL_END = PCD_TIPO_TELEFONE
     AND    rownum = 1;     
     
  return(Result);
end FNC_CAD_PES_TELEFONE_S;
