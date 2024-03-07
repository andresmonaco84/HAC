--PRC_CTS_RES_RESUMO_GERAL_D
create or replace procedure PRC_CTS_RES_RESUMO_GERAL_D 
(
     pCTS_RES_RESU_MES IN TB_CTS_RES_RESUMO_GERAL.CTS_RES_RESU_MES%type,
     pCTS_RES_RESU_ANO IN TB_CTS_RES_RESUMO_GERAL.CTS_RES_RESU_ANO%type
)
is
/********************************************************************
*    Procedure: PRC_CTS_RES_RESUMO_GERAL_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CTS_RES_RESUMO_GERAL a
WHERE  
          CTS_RES_RESU_MES = pCTS_RES_RESU_MES
      AND CTS_RES_RESU_ANO = pCTS_RES_RESU_ANO;
end PRC_CTS_RES_RESUMO_GERAL_D;
