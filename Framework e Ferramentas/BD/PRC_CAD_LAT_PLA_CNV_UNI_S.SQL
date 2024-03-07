create or replace procedure PRC_CAD_LAT_PLA_CNV_UNI_S
  (
     pCAD_PLA_CD_PLANO_HAC IN TB_CAD_PLA_PLANO.CAD_PLA_CD_PLANO_HAC%type,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pDATA_BASE date default null,
     pTELA string default null,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_LAT_PLA_CNV_UNI_S
  *
  *    Data Criacao: 	07/08/2007   Por: Guilherme Holdack
  *    Função: Lista os Locais de Atendimentos de acordo com Plano x Convenio x Unidade
  *            que estejam configurado para o agendamento
  *
  *    Data Alteração: 03/10/2007  Por: Carlos Araujo
  *    Alteração: Inclusão de associação com tabela ULO que restringe os locais
  *               que possui flag libera agenda = S
  *
  *    Data de Alteração: 07/11/2007         Por: Carlos Araujo
  *    Alteração: Inclusão de verificação de vigência.
  *
  *    Data de Alteração: 17/09/2008         Por: Andrea Cazuca
  *    Alteração: Incluído o parametro tela para verificar a query a ser executada
  *
  *    Data Alteracao: 25/03/2010  Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusao do campo CAD_LAT_FL_PERMITE_ATEND (tarefa 8107).
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    IF pTELA = 'A' OR pTELA = 'L' THEN
       OPEN v_cursor FOR
       SELECT
            LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO,
            LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
            LAT.CAD_LAT_FL_ATIVO_OK,
            LAT.CAD_LAT_DT_ULTIMA_ATUALIZACAO,
            LAT.SEG_USU_ID_USUARIO,
            LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO,
            LAT.CAD_LAT_FL_PERMITE_ATEND
       FROM
            TB_CAD_UNI_UNIDADE UNI,
            TB_CAD_CNV_CONVENIO CNV,
            TB_CAD_PLA_PLANO PLA,
            TB_CAD_LAT_LOCAL_ATENDIMENTO LAT,
            TB_ASS_CLP_CNV_UND_LOC_PLANO CLP,
            TB_ASS_CUL_CONV_UNI_LOCATEND CUL,
            TB_ASS_CNU_CONVENIO_UNIDADE CNU,
            TB_ASS_ULO_UNID_LOCAL ULO
       WHERE
           (PLA.CAD_PLA_CD_PLANO_HAC     = UPPER(PCAD_PLA_CD_PLANO_HAC))
       AND (CNV.CAD_CNV_ID_CONVENIO      = PCAD_CNV_ID_CONVENIO)
       AND (UNI.CAD_UNI_ID_UNIDADE       = PCAD_UNI_ID_UNIDADE)
       AND PLA.CAD_CNV_ID_CONVENIO       = CNV.CAD_CNV_ID_CONVENIO
       AND CLP.CAD_PLA_ID_PLANO          = PLA.CAD_PLA_ID_PLANO
       AND CLP.ASS_CUL_ID                = CUL.ASS_CUL_ID
       AND CUL.ASS_CNU_ID                = CNU.ASS_CNU_ID
       AND CNU.CAD_CNV_ID_CONVENIO       = CNV.CAD_CNV_ID_CONVENIO
       AND CNU.CAD_UNI_ID_UNIDADE        = UNI.CAD_UNI_ID_UNIDADE
       AND ULO.CAD_UNI_ID_UNIDADE        = CNU.CAD_UNI_ID_UNIDADE
       AND ULO.CAD_LAT_ID_LOCAL_ATENDIMENTO = CUL.CAD_LAT_ID_LOCAL_ATENDIMENTO
       AND CUL.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
       AND (pDATA_BASE is null OR pDATA_BASE BETWEEN clp.ass_clp_dt_ini_vigencia AND clp.ass_clp_dt_fim_vigencia OR clp.ass_clp_dt_fim_vigencia is null)
       AND (pDATA_BASE is null OR pDATA_BASE BETWEEN cul.ass_cul_dt_ini_vigencia AND cul.ass_cul_dt_fim_vigencia OR cul.ass_cul_dt_fim_vigencia is null)
       AND (pDATA_BASE is null OR pDATA_BASE BETWEEN cnu.ass_cnu_dt_ini_vigencia AND cnu.ass_cnu_dt_fim_vigencia OR cnu.ass_cnu_dt_fim_vigencia is null)
       AND (pDATA_BASE is null OR ulo.ass_ulo_fl_status = 'A')

       ORDER BY LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO;

       io_cursor := v_cursor;
    ELSE
       OPEN v_cursor FOR
       SELECT
            LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO,
            LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
            LAT.CAD_LAT_FL_ATIVO_OK,
            LAT.CAD_LAT_DT_ULTIMA_ATUALIZACAO,
            LAT.SEG_USU_ID_USUARIO,
            LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO,
            LAT.CAD_LAT_FL_PERMITE_ATEND
       FROM
            TB_CAD_UNI_UNIDADE UNI,
            TB_CAD_CNV_CONVENIO CNV,
            TB_CAD_PLA_PLANO PLA,
            TB_CAD_LAT_LOCAL_ATENDIMENTO LAT,
            TB_ASS_CLP_CNV_UND_LOC_PLANO CLP,
            TB_ASS_CUL_CONV_UNI_LOCATEND CUL,
            TB_ASS_CNU_CONVENIO_UNIDADE CNU,
            TB_ASS_ULO_UNID_LOCAL ULO
       WHERE
           (PLA.CAD_PLA_CD_PLANO_HAC     = UPPER(PCAD_PLA_CD_PLANO_HAC))
       AND (CNV.CAD_CNV_ID_CONVENIO      = PCAD_CNV_ID_CONVENIO)
       AND (UNI.CAD_UNI_ID_UNIDADE       = PCAD_UNI_ID_UNIDADE)
       AND ULO.ASS_ULO_FL_LIBERA_AGENDA_OK = 'S'
       AND PLA.CAD_CNV_ID_CONVENIO       = CNV.CAD_CNV_ID_CONVENIO
       AND CLP.CAD_PLA_ID_PLANO          = PLA.CAD_PLA_ID_PLANO
       AND CLP.ASS_CUL_ID                = CUL.ASS_CUL_ID
       AND CUL.ASS_CNU_ID                = CNU.ASS_CNU_ID
       AND CNU.CAD_CNV_ID_CONVENIO       = CNV.CAD_CNV_ID_CONVENIO
       AND CNU.CAD_UNI_ID_UNIDADE        = UNI.CAD_UNI_ID_UNIDADE
       AND ULO.CAD_UNI_ID_UNIDADE        = CNU.CAD_UNI_ID_UNIDADE
       AND ULO.CAD_LAT_ID_LOCAL_ATENDIMENTO = CUL.CAD_LAT_ID_LOCAL_ATENDIMENTO
       AND CUL.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
       AND (pDATA_BASE is null OR pDATA_BASE BETWEEN clp.ass_clp_dt_ini_vigencia AND clp.ass_clp_dt_fim_vigencia OR clp.ass_clp_dt_fim_vigencia is null)
       AND (pDATA_BASE is null OR pDATA_BASE BETWEEN cul.ass_cul_dt_ini_vigencia AND cul.ass_cul_dt_fim_vigencia OR cul.ass_cul_dt_fim_vigencia is null)
       AND (pDATA_BASE is null OR pDATA_BASE BETWEEN cnu.ass_cnu_dt_ini_vigencia AND cnu.ass_cnu_dt_fim_vigencia OR cnu.ass_cnu_dt_fim_vigencia is null)
       AND (pDATA_BASE is null OR ulo.ass_ulo_fl_status = 'A')

       ORDER BY LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO;

       io_cursor := v_cursor;
    END IF;

  end PRC_CAD_LAT_PLA_CNV_UNI_S;
/
