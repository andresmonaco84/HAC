  --PRC_INT_ATD_GUI_GUIAATEND_SID
  create or replace procedure PRC_INT_ATD_GUI_GUIAATEND_SID 
  (
     pATD_ATE_ID IN TB_ATD_GUI_GUIAATEND.ATD_ATE_ID%type,
     pATD_GUI_CD_CODIGO IN TB_ATD_GUI_GUIAATEND.ATD_GUI_CD_CODIGO%type,
     pATD_GUI_DT_VALIDADE IN TB_ATD_GUI_GUIAATEND.ATD_GUI_DT_VALIDADE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_GUI_GUIAATEND_SID
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
       ATD_GUI_CD_CODIGO,
       ATD_GUI_DT_ULTIMA_ATUALIZACAO,
       ATD_GUI_FL_GUIAPRINC_OK,
       ATD_ATE_ID,
       ATD_GUI_DT_EMISSAOGUIA,
       SEG_USU_ID_USUARIO,
       ATD_GUI_DT_AUTORIZGUIA,
       ATD_GUI_FL_ATIVO_OK,
       ATD_GUI_CD_SENHA,
       ATD_GUI_DT_VALIDADE,
       ATD_GUI_DT_VALIDADE_FIM,
       ATD_GUI_DIAS_VALIDADE,
       ATD_GUI_DS_OBSERVACAO,
       ATD_GUI_FL_GUIA_ENTREGUE,
       ATD_GUI_FL_DT_GUIA_ENTREGUE,
       CAD_PAC_ID_PACIENTE
    FROM TB_ATD_GUI_GUIAATEND
    WHERE
        ATD_ATE_ID = pATD_ATE_ID
    AND ATD_GUI_CD_CODIGO = pATD_GUI_CD_CODIGO
    AND ATD_GUI_DT_VALIDADE = pATD_GUI_DT_VALIDADE;          
    io_cursor := v_cursor;
  end PRC_INT_ATD_GUI_GUIAATEND_SID;
