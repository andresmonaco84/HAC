

--PRC_CAD_HFA_HORAS_FALTA_S
create or replace procedure PRC_CAD_HFA_HORAS_FALTA_S 
(
     pCAD_HFA_ID IN TB_CAD_HFA_HORAS_FALTA.CAD_HFA_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_HFA_HORAS_FALTA_S
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       CAD_HFA_ID,
       CAD_HTR_ID,
       CAD_HFA_MES_COMPETENCIA,
       CAD_HFA_ANO_COMPETENCIA,
       CAD_HFA_MES_PAGTO,
       CAD_HFA_ANO_PAGTO,
       CAD_HFA_QT_HR_FALTA_SEMANA,
       CAD_HFA_QT_HR_FALTA_FIMSEMA,
       SEG_USU_ID_USUARIO,
       CAD_HFA_DT_ULTIMA_ATUALIZACAO
FROM TB_CAD_HFA_HORAS_FALTA
WHERE
        CAD_HFA_ID = pCAD_HFA_ID;          
io_cursor := v_cursor;
end PRC_CAD_HFA_HORAS_FALTA_S;
