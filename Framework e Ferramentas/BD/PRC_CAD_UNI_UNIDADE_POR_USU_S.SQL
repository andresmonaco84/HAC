create or replace procedure PRC_CAD_UNI_UNIDADE_POR_USU_S
  (
     pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_UNI_UNIDADE_POR_USU_S
  *
  *    Data Criacao:  03/03/2007             Por: Carlos Eduardo
  *    Funcao: Recupera as unidades "Ativas" associadas ao usuário
  *
  *    Data Alteracao:  30/05/2007             Por: Carlos Eduardo
  *    Alteração: Foram retirados alguns campos que foram migrados para a
  *               a tabela de Pessoa e Endereços
  *
  *    Data Alteracao:  08/05/2010             Por: Rafael Coimbra
  *    Alteração: Incluido o parâmetro CAD_UNI_FL_FATURA_UNID_OK
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       UNI.CAD_UNI_ID_UNIDADE,
       UNI.CAD_UNI_DS_IMAGEM_ASSOCIADA,
       UNI.CAD_UNI_ID_UNIDADE_MASTER,
       UNI.CAD_UNI_FL_STATUS,
       UNI.CAD_UNI_DT_ULTIMO_STATUS,
       UNI.CAD_UNI_FL_GRAVA_ATEND_OK,
       UNI.CAD_UNI_FL_LIBERA_AGENDA_OK,
       UNI.CAD_UNI_FL_GRAVA_CD_PAC_OK,
       UNI.CAD_PES_ID_PESSOA,
       UNI.CAD_UNI_CD_UNID_HOSPITALAR,
       UNI.CAD_UNI_FL_CRONICO_OK,
       UNI.CAD_UNI_FL_PRIORIDADE_OK,
       UNI.CAD_UNI_NR_CNES,
       UNI.CAD_UNI_FL_LIB_LOC_SETOR_OK,
       UNI.CAD_UNI_FL_FATURA_UNID_OK,
       PES.*

    FROM TB_CAD_UNI_UNIDADE UNI,
         TB_SEG_UUN_USUARIO_UNIDADE UUN,
         TB_CAD_PES_PESSOA PES
    WHERE
        UNI.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
    AND UNI.CAD_UNI_ID_UNIDADE = UUN.CAD_UNI_ID_UNIDADE
    AND UUN.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    AND UNI.CAD_UNI_FL_STATUS  = 'A'
    ORDER BY PES.CAD_PES_NM_PESSOA;

    io_cursor := v_cursor;
  end PRC_CAD_UNI_UNIDADE_POR_USU_S;
