create or replace procedure PRC_ASS_ULO_UNID_LOCAL_S
  (
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULO_UNID_LOCAL.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_ULO_UNID_LOCAL.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default null,
     pASS_ULO_FL_STATUS IN TB_ASS_ULO_UNID_LOCAL.ASS_ULO_FL_STATUS%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_ULO_UNID_LOCAL_S
  *
  *    Data Criacao:  27/06/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao: 28/06/2007  Por: Cristiane Gomes da Silva
  *    Data Alteracao: 06/07/2007  Por: Ricardo costa
  *    Alterac?o: 1)Inclus?o do parametro pCAD_UNI_ID_UNIDADE
  *               2)Inclus?o do ORDER BY
  *    Alterac?o: Adicionado descric?o e ID da Unidade e Local para retorno
  *
  *    Data Alteracao: 20/08/2007   Por: Andrea Cazuca
  *    Alteracao: Inclus?o do parametro pASS_ULO_FL_STATUS
  *
  *    Funcao: Obtem Associac?o(?es) de Unidades com Locais de Atendimentos
  *
  *
  *    Data Alteracao: 02/10/2007  Por: Guilherme Holdack
  *    Alterac?o:      Inclus?o de campo ASS_ULO_FL_LIBERA_AGENDA_OK
  *
  *    Data Alteracao: 24/03/2010  Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusao dos campos ASS_ULO_HR_INICIAL_ATEND e ASS_ULO_HR_FINAL_ATEND (tarefa 8107)
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
   SELECT
       ULO.CAD_UNI_ID_UNIDADE,
       ULO.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       ULO.SEG_USU_ID_USUARIO,
       ULO.ASS_ULO_DT_ULTIMA_ATUALIZACAO,
       ULO.ASS_ULO_FL_STATUS,
       ulo.ass_ulo_fl_libera_agenda_ok,
       LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
       PES.CAD_PES_NM_PESSOA,
       ULO.ASS_ULO_HR_INICIAL_ATEND,
       ULO.ASS_ULO_HR_FINAL_ATEND
    FROM TB_ASS_ULO_UNID_LOCAL ULO,
         TB_CAD_LAT_LOCAL_ATENDIMENTO LAT,
         TB_CAD_UNI_UNIDADE UNI,
         TB_CAD_PES_PESSOA PES
    WHERE ULO.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
    AND  (ULO.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE)
    AND  (PES.CAD_PES_ID_PESSOA  = UNI.CAD_PES_ID_PESSOA)
    AND  (pCAD_UNI_ID_UNIDADE is null OR ULO.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
    AND  (pCAD_LAT_ID_LOCAL_ATENDIMENTO is null OR ULO.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
    AND  (pASS_ULO_FL_STATUS is null OR ULO.ASS_ULO_FL_STATUS = pASS_ULO_FL_STATUS)
    ORDER BY PES.CAD_PES_NM_PESSOA;

    io_cursor := v_cursor;
  end PRC_ASS_ULO_UNID_LOCAL_S;
/
