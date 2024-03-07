create or replace procedure PRC_CAD_PRD_PROD_UTILIZA_NF_L
(
       pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
       io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_CAD_PRD_PROD_UTILIZA_NF_L
* 
*    Data Criacao:   22/11/2010   Por: Rafael Coimbra
*
*    Funcao: Descric?o da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
BEGIN
OPEN v_cursor FOR
         
         SELECT
             PRD.CAD_PRD_ID,
             PRD.CAD_PRD_CD_CODIGO,
             PRD.CAD_PRD_DS_DESCRICAO,
             DECODE(PRD.CAD_PRD_FL_STATUS, 'A', 'ATIVO', 'I', 'INATIVO') AS Status,
             PRD.CAD_PRD_VL_PRODUTO
         FROM 
             TB_CAD_VCM_VAL_COBR_MAT_MED VCM, 
             TB_CAD_PRD_PRODUTO PRD
         WHERE 
             VCM.CAD_VCM_FL_UTILIZA_VL_NF = 'S' 
             AND VCM.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO 
             AND VCM.CAD_PRD_ID IS NOT NULL
             AND PRD.CAD_PRD_ID = VCM.CAD_PRD_ID;
             
io_cursor := v_cursor;
end PRC_CAD_PRD_PROD_UTILIZA_NF_L;



 
  
