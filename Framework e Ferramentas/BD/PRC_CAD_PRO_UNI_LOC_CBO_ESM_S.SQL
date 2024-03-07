create or replace procedure PRC_CAD_PRO_UNI_LOC_CBO_ESM_S
  (
    pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_AGE_ESM_ESCALA_MEDICA.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
    pCAD_UNI_ID_UNIDADE IN TB_AGE_ESM_ESCALA_MEDICA.CAD_UNI_ID_UNIDADE%type,
    pTIS_CBO_CD_CBOS IN TB_AGE_ESM_ESCALA_MEDICA.TIS_CBO_CD_CBOS%type,
    pAGE_ESM_FL_SITUACAO IN Tb_Age_Esm_Escala_Medica.Age_Esm_Fl_Situacao%type,
    io_cursor OUT PKG_CURSOR.t_cursor
  )
is
 /********************************************************************
  *    Procedure: PRC_CAD_PRO_UNI_LOC_CBO_ESM_S
  *
  *    Data Criacao: 	01/08/2007         Por: Guilherme Holdack
  *    Data Alteracao:	                   Por:
  *
  *    Funcao: Recupera profissionais de acordo com Unidade x Local de Atendimento x Especialidade
  *            e status da escala médica, e que essa exista na tabela de Agenda Gerada.
  *
  *    Data Alteracao: 15/02/2008           Por Bruno Costa
  *    Alteracao: Desconsiderar data final da escala
  *
  *    Data Alteracao: 12/02/2009  Por: pEDRO
  *    Alteração: Incluindo parametro PRO.CAD_PRO_FL_PERM_EXAME_OK,
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
       OPEN v_cursor FOR
       select distinct
       PRO.CAD_PRO_ID_PROFISSIONAL,
       PRO.CAD_PRO_CD_CODCOOMED,
       PRO.CAD_PRO_CD_COD_PRO,
       PRO.CAD_PRO_NR_CONSELHO,
       PRO.CAD_PRO_SG_UF_CONSELHO,
       PRO.CAD_PRO_FL_ATIVO_OK,
       PRO.CAD_PRO_NM_APELIDO,
       PRO.CAD_PRO_DS_BIP_PAGER,
       PRO.CAD_PRO_FL_IMPR_RECIBO_OK,
       PRO.CAD_PRO_FL_STAFF_OK,
       PRO.CAD_PRO_CD_BANCO,
       PRO.CAD_PRO_CD_AGENCIA,
       PRO.CAD_PRO_CD_CONTA,
       PRO.CAD_PRO_FL_PERM_INTERN_OK,
       PRO.CAD_PRO_FL_PERM_ASS_LAUDO_OK,
       PRO.CAD_PRO_CD_MATRICULA,
       PRO.SEG_USU_ID_USUARIO,
       PRO.CAD_PES_ID_PESSOA,
       PRO.TIS_CPR_CD_CONSELHOPROF,
       PRO.CAD_PRO_FL_RESIDENTE_OK,
       PRO.CAD_PRO_NR_ANO_INI_RESIDENCIA,
       PRO.CAD_PRO_DT_INI_RESIDENCIA,
       PRO.CAD_PRO_DT_FIM_RESIDENCIA,
       PRO.CAD_PRO_FL_PERM_EXAME_OK,
       PES.*
      from   tb_age_esm_escala_medica esm,
             tb_cad_pro_profissional pro,
             tb_cad_pes_pessoa pes
       where
              pro.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
       and    esm.cad_pro_id_profissional = pro.cad_pro_id_profissional
       AND    esm.age_esm_fl_agendagerada_ok = 'S'
       AND    (ESM.AGE_ESM_DT_FIM_ESCALA IS NULL OR ESM.AGE_ESM_DT_FIM_ESCALA >= TRUNC(SYSDATE))
       and    esm.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO
       and    esm.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE
       and    esm.tis_cbo_cd_cbos = pTIS_CBO_CD_CBOS
       and    esm.age_esm_fl_situacao = pAGE_ESM_FL_SITUACAO;

       io_cursor := v_cursor;
end PRC_CAD_PRO_UNI_LOC_CBO_ESM_S;
/
