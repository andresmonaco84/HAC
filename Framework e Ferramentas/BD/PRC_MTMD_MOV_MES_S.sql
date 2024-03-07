 create or replace procedure PRC_MTMD_MOV_MES_S
(
   pCAD_MTMD_FILIAL_ID IN TB_MTMD_MOV_MES.CAD_MTMD_FILIAL_ID%type,
   pCAD_MTMD_ID IN TB_MTMD_MOV_MES.CAD_MTMD_ID%type,
   pMTMD_MOV_MES IN TB_MTMD_MOV_MES.MTMD_MOV_MES%type,
   pMTMD_MOV_ANO IN TB_MTMD_MOV_MES.MTMD_MOV_ANO%type,
   io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_MTMD_MOV_MES_S
*
*    Data Criacao: 	17/03/2011   Por: André Souza Monaco
*
*    Funcao: Seleciona registros da TB_MTMD_MOV_MES
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin        
 OPEN v_cursor FOR
 
 SELECT CAD_MTMD_ID,   
        MTMD_QTDE_ENTRADA,
        MTMD_QTDE_SAIDA
 FROM TB_MTMD_MOV_MES
 WHERE
      CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
  AND CAD_MTMD_ID        = pCAD_MTMD_ID
  AND MTMD_MOV_ANO       = pMTMD_MOV_ANO
  AND MTMD_MOV_MES       = pMTMD_MOV_MES;

 io_cursor := v_cursor;
end PRC_MTMD_MOV_MES_S;
