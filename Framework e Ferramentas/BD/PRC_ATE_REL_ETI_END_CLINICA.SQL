create or replace procedure PRC_ATE_REL_ETI_END_CLINICA
(
  pCAD_CLC_ID IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%TYPE,
  io_cursor   OUT PKG_CURSOR.t_cursor) IS
  /********************************************************************
  *    Procedure: PRC_ATE_REL_ETI_END_CLINICA
  *
  *    Data Criacao:  06/05/2008   Por: Fabiola Lopes
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Fornecer informacoes para impressao de etiquetas de atendimento
  *    do enderego da clinica
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;

BEGIN

  OPEN v_cursor FOR

    select CLC.CAD_CLC_CD_CLINICA,
           PES.CAD_PES_NM_PESSOA,
           ENDE.CAD_END_NM_LOGRADOURO,
           ENDE.CAD_END_NM_BAIRRO,
           ENDE.CAD_END_SG_UF,
           ENDE.CAD_END_CD_CEP,
           ENDE.CAD_END_DS_NUMERO,
           ENDE.CAD_END_DS_COMPLEMENTO,
           ENDE.TIS_TLG_CD_TPLOGRADOURO,
           MUN.AUX_MUN_NM_MUNICIPIO
      from TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
           TB_CAD_END_ENDERECO            ENDE,
           TB_CAD_PES_PESSOA              PES,
--           TB_ASS_PEE_PESSOA_ENDERECO     PEE,
           TB_AUX_MUN_MUNICIPIO           MUN
     where clc.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
       and pes.cad_pes_id_pessoa = ende.cad_pes_id_pessoa
--       and pee.cad_end_id_endereco = ende.cad_end_id_endereco
       and clc.cad_clc_id = pCAD_CLC_ID
       and mun.aux_mun_cd_ibge = ende.aux_mun_cd_ibge;
  io_cursor := v_cursor;

END PRC_ATE_REL_ETI_END_CLINICA;
