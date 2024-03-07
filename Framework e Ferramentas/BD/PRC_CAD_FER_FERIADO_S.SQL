create or replace procedure PRC_CAD_FER_FERIADO_S
  (
     pCAD_FER_ID_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_ID_FERIADO%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_FER_FERIADO.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pCAD_FER_DT_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_DT_FERIADO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_FER_FERIADO_S
  *
  *    Data Criacao: 	26/06/2007   Por: Guilherme Holdack
  *    Data Alteracao:	data da altera???#o  Por: Nome do Analista
  *
  *    Data Alteracao:  23/12/2009  Por: Davi Silvestre M. dos Reis
  *    Alteracao: Considerar apenas os feriados futuros (e não os passados)
  *
  *    Data Alteracao:  09/05/2010  Por: Davi Silvestre M. dos Reis
  *    Alteracao: Formatacao da data para poder pegar a data atual (desconsiderando a hora)
  *
  *    Data Alteracao:  25/04/2011  Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusao do paramentro pCAD_FER_DT_FERIADO: caso ele
  *               seja nulo, pega SYSDATE; do contrario, trabalha com ele
  *               para listar os feriados futuros
  *
  *    Data Alteracao:  31/10/2011  Por: Davi Silvestre M. dos Reis / Ricardo Costa
  *    Alteracao: Alteracao no formato da data, de 'DD-MON-YYYY' para 'DD-MM-YYYY'
  *
  *    Funcao: Seleciona registros da tabela TB_CAD_FER_FERIADO
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_DATAINICIO_LISTA TB_CAD_FER_FERIADO.CAD_FER_DT_FERIADO%type;
  
  begin
  
    IF pCAD_FER_DT_FERIADO IS NULL THEN
       V_DATAINICIO_LISTA := SYSDATE;
    ELSE
       V_DATAINICIO_LISTA := pCAD_FER_DT_FERIADO;
    END IF; 
  
    OPEN v_cursor FOR
    SELECT
       CAD_FER_ID_FERIADO,
       CAD_UNI_ID_UNIDADE,
       CAD_FER_DT_FERIADO,
       CAD_FER_TP_FERIADO,
       CAD_FER_DS_FERIADO,
       CAD_FER_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_CAD_FER_FERIADO
    WHERE
        ((pCAD_FER_ID_FERIADO is null OR CAD_FER_ID_FERIADO = pCAD_FER_ID_FERIADO)
    AND (pCAD_UNI_ID_UNIDADE is null OR CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
    OR (CAD_FER_TP_FERIADO = 'F'))
    AND TO_DATE(CAD_FER_DT_FERIADO, 'DD-MM-YYYY') >= TO_DATE(V_DATAINICIO_LISTA, 'DD-MM-YYYY')
    ORDER BY CAD_FER_DT_FERIADO;
    io_cursor := v_cursor;
  end PRC_CAD_FER_FERIADO_S;
/
