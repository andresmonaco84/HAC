 CREATE OR REPLACE PROCEDURE PRC_CAD_FEX_L
  (
    pCAD_FEX_ID IN TB_CAD_FEX_FORMULARIO_EXPED.CAD_FEX_ID%TYPE DEFAULT NULL,
   
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_FEX_L
  *
  *    Data Cria��o: 04/12/2012  Por: PEDRO
  *    Alteracao:
  *
  * 
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  
  begin
    OPEN v_cursor FOR

SELECT FEX.CAD_FEX_ID,
       FEX.CAD_FEX_NOME_FANTASIA,
       FEX.CAD_FEX_RAZAO_SOCIAL,
       FEX.CAD_FEX_PESSOA_CONTATO,
       FEX.CAD_FEX_TELEFONE,
       FEX.CAD_FEX_EMAIL,
       FEX.CAD_FEX_NUMERO_FORMULARIO,
       FEX.SEG_USU_ID_USUARIO_CRIACAO,
       FEX.CAD_FEX_DT_CRIACAO,
       FEX.SEG_USU_ID_USUARIO_ATUALIZ,
       FEX.CAD_FEX_DT_ULTIMA_ATUALIZ,
       FEX.CAD_FEX_DS_OBSERVACAO,
       FEX.CAD_FEX_INICIO_VIGENCIA,
       FEX.CAD_FEX_FIM_VIGENCIA,
       USU_CRI.SEG_USU_DS_NOME SEG_USU_DS_NOME_CRIACAO,
       USU_ATU.SEG_USU_DS_NOME SEG_USU_DS_NOME_ATUALIZ
       
FROM   TB_CAD_FEX_FORMULARIO_EXPED FEX
JOIN   TB_SEG_USU_USUARIO          USU_CRI ON USU_CRI.SEG_USU_ID_USUARIO   = FEX.SEG_USU_ID_USUARIO_CRIACAO
JOIN   TB_SEG_USU_USUARIO          USU_ATU ON USU_ATU.SEG_USU_ID_USUARIO   = FEX.SEG_USU_ID_USUARIO_ATUALIZ
WHERE  (pCAD_FEX_ID IS NULL OR FEX.CAD_FEX_ID = pCAD_FEX_ID)
;
io_cursor := v_cursor;

end PRC_CAD_FEX_L;