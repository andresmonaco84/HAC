  --PRC_CAD_PLA_PLANO_RMT_SID
  create or replace procedure PRC_CAD_PLA_PLANO_RMT_SID 
  (
     pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PLA_PLANO_RMT_SID
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
       CAD_PLA_ID_PLANO,
       CAD_PLA_CD_PLANO_HAC,
       CAD_PLA_CD_PLANO,
       CAD_PLA_CD_TIPOPLANO,
       CAD_PLA_NM_NOME_PLANO,
       CAD_PLA_FL_SITUACAO_PLANO,
       CAD_CNV_ID_CONVENIO,
       CAD_PLA_DT_ULT_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PLA_DT_INICIO_VIGENCIA,
       CAD_PLA_DT_FIM_VIGENCIA,
       CAD_PLA_DS_OBS_FIM_VIG,
       CAD_PLA_FL_EXIGE_GUIA,
       CAD_PLA_FL_EXIGE_SENHA_LIB_OK,
       CAD_PLA_FL_LIBERA_EXAME_OK,
       CAD_PLA_DS_ORIENTACAO,
       CAD_PLA_FL_AUTORIZA_ONLINE,
       CAD_PLA_FL_COB_AMBULANCIA,
       CAD_PLA_FL_COB_ACID_TRAB,
       CAD_PLA_FL_COB_REFEI_ACOMP,
       CAD_PLA_FL_COB_ACOMPANHA,
       CAD_PLA_CT_CATEGORIA_PLANO
    FROM TB_CAD_PLA_PLANO
    WHERE
        CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO;          
    io_cursor := v_cursor;
  end PRC_CAD_PLA_PLANO_RMT_SID;

