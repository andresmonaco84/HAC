create or replace procedure PRC_ASS_CPE_CONV_PROD_EQ_U
  (
     pASS_CPE_ID IN TB_ASS_CPE_CONV_PROD_EQUIVALE.ASS_CPE_ID%type,
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CPE_CONV_PROD_EQUIVALE.CAD_CNV_ID_CONVENIO%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_CPE_CONV_PROD_EQUIVALE.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_PRD_ID_ORIGEM IN TB_ASS_CPE_CONV_PROD_EQUIVALE.CAD_PRD_ID_ORIGEM%type,
     pCAD_PRD_ID_DESTINO IN TB_ASS_CPE_CONV_PROD_EQUIVALE.CAD_PRD_ID_DESTINO%type,
     pCAD_CPE_DT_INICIO_VIGENCIA IN TB_ASS_CPE_CONV_PROD_EQUIVALE.CAD_CPE_DT_INICIO_VIGENCIA%type,
     pCAD_CPE_DT_FIM_VIGENCIA IN TB_ASS_CPE_CONV_PROD_EQUIVALE.CAD_CPE_DT_FIM_VIGENCIA%type default NULL,
     pCAD_CPE_DT_ULTIMA_ATUALIZACAO IN TB_ASS_CPE_CONV_PROD_EQUIVALE.CAD_CPE_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CPE_CONV_PROD_EQUIVALE.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CPE_CONV_PROD_EQ_U
  *
  *    Data Criacao:  data da  criação   Por: Nome do Analista
  *    Data Alteracao: data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
    existe number := 1;

  begin
  
  begin  
  select count(1)
    into existe
    from tb_ass_cpe_conv_prod_equivale cpe
   where cpe.cad_prd_id_origem = pCAD_PRD_ID_ORIGEM
     and cpe.cad_prd_id_destino = pCAD_PRD_ID_DESTINO
     and (fnc_validar_vigencia_data(cpe.cad_cpe_dt_inicio_vigencia, cpe.cad_cpe_dt_fim_vigencia, pCAD_CPE_DT_INICIO_VIGENCIA) = 1
     or fnc_validar_vigencia_data(cpe.cad_cpe_dt_inicio_vigencia, cpe.cad_cpe_dt_fim_vigencia, nvl(pCAD_CPE_DT_FIM_VIGENCIA,sysdate)) = 1)
     and cpe.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
     and (pCAD_LAT_ID_LOCAL_ATENDIMENTO is null or cpe.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
   group by cpe.cad_cnv_id_convenio,
            cpe.cad_lat_id_local_atendimento,
            cpe.cad_prd_id_origem,
            cpe.cad_prd_id_destino;
  exception when others then
     existe := 1;
  end;
  
  if(existe > 1) then
          raise_application_error (-20000, 'EQUIVALENCIA JÁ EXISTE NESSE PERÍODO!');
  end if;  
  
    UPDATE TB_ASS_CPE_CONV_PROD_EQUIVALE
    SET
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO,
        CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO,
        CAD_PRD_ID_ORIGEM = pCAD_PRD_ID_ORIGEM,
        CAD_PRD_ID_DESTINO = pCAD_PRD_ID_DESTINO,
        CAD_CPE_DT_INICIO_VIGENCIA = pCAD_CPE_DT_INICIO_VIGENCIA,
        CAD_CPE_DT_FIM_VIGENCIA = pCAD_CPE_DT_FIM_VIGENCIA,
        CAD_CPE_DT_ULTIMA_ATUALIZACAO = pCAD_CPE_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    WHERE
        ASS_CPE_ID = pASS_CPE_ID;
  end PRC_ASS_CPE_CONV_PROD_EQ_U;
 