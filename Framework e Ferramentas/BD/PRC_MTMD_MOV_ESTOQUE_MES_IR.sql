CREATE OR REPLACE PROCEDURE PRC_MTMD_MOV_ESTOQUE_MES_IR
(
pCAD_MTMD_ID IN TB_MTMD_MOV_ESTOQUE_MES.CAD_MTMD_ID%type DEFAULT NULL,
pCAD_MTMD_FILIAL_ID IN TB_MTMD_MOV_ESTOQUE_MES.CAD_MTMD_FILIAL_ID%type DEFAULT NULL,     
pMTMD_MOV_MES IN TB_MTMD_MOV_ESTOQUE_MES.MTMD_MOV_MES%type DEFAULT NULL,
pMTMD_MOV_ANO IN TB_MTMD_MOV_ESTOQUE_MES.MTMD_MOV_ANO%type DEFAULT NULL,
pNewIdt OUT NUMBER
) IS   
/********************************************************************
*    Procedure: PRC_MTMD_MOV_ESTOQUE_MES_IR
*
*    Data Criacao: 	01/2011   Por: Ricardo
*    Data Alteração:17/03/2011   Por: André Souza Monaco
*         Alteração:Chamada da função FNC_MTMD_CALCULA_ROTATIVIDADE
*
*    Funcao: Retorna indice de rotatividade
*******************************************************************/
sMes VARCHAR2(2);
dDataIni DATE;
dDatafIM DATE;
BEGIN
  IF (  LENGTH(TO_CHAR(pMTMD_MOV_MES)) = 1 ) THEN
     sMes := '0'||TO_CHAR(pMTMD_MOV_MES);  
  ELSE
     sMes := TO_CHAR(pMTMD_MOV_MES);     
  END IF;

  dDataIni := TO_DATE( '01'||TO_CHAR(sMes)||TO_CHAR(pMTMD_MOV_ANO)||' 0000','DDMMYYYY HH24MI');
  dDatafIM := TO_DATE( TO_CHAR(LAST_DAY(dDataIni),'DDMMYYYY')||' 2359','DDMMYYYY HH24MI');  
   
  pNewIdt := FNC_MTMD_CALCULA_ROTATIVIDADE(pCAD_MTMD_ID,
                                           null,
                                           null,
                                           null,
                                           pCAD_MTMD_FILIAL_ID,
                                           dDataIni,
                                           dDatafIM);
END PRC_MTMD_MOV_ESTOQUE_MES_IR;
