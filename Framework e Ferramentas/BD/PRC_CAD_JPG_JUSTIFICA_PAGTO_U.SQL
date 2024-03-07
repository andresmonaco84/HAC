--PRC_CAD_JPG_JUSTIFICA_PAGTO_U
create or replace procedure PRC_CAD_JPG_JUSTIFICA_PAGTO_U
(
     pID_CAD_JPG IN TB_CAD_JPG_JUSTIFICA_PAGTO.ID_CAD_JPG%type,
     pCAD_JPG_DS_JUSTIFICATIVA IN TB_CAD_JPG_JUSTIFICA_PAGTO.CAD_JPG_DS_JUSTIFICATIVA%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_JPG_JUSTIFICA_PAGTO.SEG_USU_ID_USUARIO%type,
     pCAD_JPG_DT_ULTIMA_ATUALIZACAO IN TB_CAD_JPG_JUSTIFICA_PAGTO.CAD_JPG_DT_ULTIMA_ATUALIZACAO%type
) 
is
/********************************************************************
*    Procedure: PRC_CAD_JPG_JUSTIFICA_PAGTO_U
* 
*    Data Criacao: 	  28/02/2012         Por: Fabíola Lopes
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Altera as Justificativas de Pagamento
*
*******************************************************************/  
begin
UPDATE TB_CAD_JPG_JUSTIFICA_PAGTO
SET	   
        CAD_JPG_DS_JUSTIFICATIVA = pCAD_JPG_DS_JUSTIFICATIVA,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        CAD_JPG_DT_ULTIMA_ATUALIZACAO = pCAD_JPG_DT_ULTIMA_ATUALIZACAO 
WHERE
        ID_CAD_JPG = pID_CAD_JPG;	
end PRC_CAD_JPG_JUSTIFICA_PAGTO_U;