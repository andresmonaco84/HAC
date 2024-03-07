CREATE OR REPLACE FUNCTION FNC_MTMD_SETOR_INVENTARIADO
(
  pCAD_SET_ID IN TB_CAD_MTMD_INVENTARIO_FECHA.CAD_SET_ID%type,
  pCAD_MTMD_FILIAL_ID IN TB_CAD_MTMD_INVENTARIO_FECHA.CAD_MTMD_FILIAL_ID%type,
  pCAD_MTMD_ANDAMENTO IN TB_CAD_MTMD_INVENTARIO_FECHA.CAD_MTMD_ANDAMENTO%type,
  pCAD_MTMD_GRUPO_ID IN TB_CAD_MTMD_INVENTARIO_FECHA.CAD_MTMD_GRUPO_ID%type := 0
)
/********************************************************************
*    Procedure: FNC_MTMD_SETOR_INVENTARIADO
*
*    Data Criacao:  23/11/2011   Por: Andre Souza Monaco
*  Data Alterac?o:  01/12/15  Por: Andre
*       Alterac?o:  Nova opcao de TB_CAD_MTMD_INVENTARIO_FECHA.CAD_MTMD_ANDAMENTO = 2
*                   (andamento terceirizado)
*
*    Funcao: Retorna (0 ou 1) se setor ja foi ou esta sendo inventariado
*            de acordo com o que se pede pelo parametro pCAD_MTMD_ANDAMENTO
*******************************************************************/
RETURN  NUMBER IS
retorno NUMBER;
begin

    --VERIFICA SE INVENTARIO DO SETOR ESTA EM ANDAMENTO
    IF (pCAD_MTMD_ANDAMENTO IN (1,2)) THEN
      BEGIN
        SELECT I.CAD_MTMD_ANDAMENTO INTO retorno
          FROM TB_CAD_MTMD_INVENTARIO_FECHA I
        WHERE I.CAD_MTMD_ANDAMENTO IN (1,2) AND
              I.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
              I.CAD_MTMD_GRUPO_ID = NVL(pCAD_MTMD_GRUPO_ID,0) AND
              I.CAD_SET_ID = pCAD_SET_ID AND ROWNUM = 1;
      EXCEPTION
         WHEN NO_DATA_FOUND THEN
              retorno := 0;
      END;
    ELSE
      --VERIFICA SE INVENTARIO DO SETOR JA FOI FEITO NO PERIODO ATUAL
      BEGIN
        SELECT 1 INTO retorno
          FROM TB_CAD_MTMD_INVENTARIO_FECHA I
        WHERE I.CAD_MTMD_ANDAMENTO = 0 AND
              I.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
              I.CAD_SET_ID = pCAD_SET_ID AND
              I.FL_MEDICAMENTO = 0 AND
              (pCAD_MTMD_GRUPO_ID IS NULL OR I.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID) AND
              (pCAD_MTMD_GRUPO_ID IS NOT NULL OR I.CAD_MTMD_GRUPO_ID = 0) AND
              TRUNC(I.CAD_MTMD_DT_INVENTARIO) BETWEEN TRUNC(SYSDATE-10) AND TRUNC(SYSDATE+10);
      EXCEPTION
         WHEN NO_DATA_FOUND THEN
              retorno := 0;
         WHEN TOO_MANY_ROWS THEN
              retorno := 1;
      END;
    END IF;

  return(retorno);
end FNC_MTMD_SETOR_INVENTARIADO;