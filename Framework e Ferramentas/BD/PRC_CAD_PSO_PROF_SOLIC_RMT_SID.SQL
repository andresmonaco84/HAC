

---bozo

  --PRC_CAD_PSO_PROF_SOLIC_RMT_SID
  create or replace procedure PRC_CAD_PSO_PROF_SOLIC_RMT_SID 
  (
     pCAD_PSO_CD_CONSELHO IN TB_CAD_PSO_PROF_SOLICITANTE.CAD_PSO_CD_CONSELHO%type,
     pCAD_PSO_SG_UF_CONSELHO IN TB_CAD_PSO_PROF_SOLICITANTE.CAD_PSO_SG_UF_CONSELHO%type,
     pTIS_CPR_CD_CONSELHOPROF IN TB_CAD_PSO_PROF_SOLICITANTE.TIS_CPR_CD_CONSELHOPROF%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PSO_PROF_SOLIC_RMT_SID
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
       TIS_CPR_CD_CONSELHOPROF,
       CAD_PSO_CD_CONSELHO,
       CAD_PSO_SG_UF_CONSELHO,
       CAD_PSO_FL_ATIVO_OK,
       CAD_PSO_NM_PROFISSIONAL,
       CAD_PSO_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_CAD_PSO_PROF_SOLICITANTE
    WHERE
        CAD_PSO_CD_CONSELHO = pCAD_PSO_CD_CONSELHO
    AND CAD_PSO_SG_UF_CONSELHO = pCAD_PSO_SG_UF_CONSELHO
    AND TIS_CPR_CD_CONSELHOPROF = pTIS_CPR_CD_CONSELHOPROF;          
    io_cursor := v_cursor;
  end PRC_CAD_PSO_PROF_SOLIC_RMT_SID;
