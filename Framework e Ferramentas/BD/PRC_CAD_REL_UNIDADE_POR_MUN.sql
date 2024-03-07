create or replace procedure PRC_CAD_REL_UNIDADE_POR_MUN
  (
     paux_mun_cd_ibge           IN TB_AUX_MUN_MUNICIPIO.AUX_MUN_CD_IBGE%type,
     io_cursor                     OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_REL_UNIDADE_POR_MUN
  *
  *    Data Criacao:  03/12/2007   Por: Guilherme
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Alimentar relatorio de Unidades por municipio
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

SELECT
pes.cad_pes_nm_pessoa,
ende.cad_end_nm_logradouro,
ende.cad_end_ds_numero,
ende.cad_end_nm_bairro
FROM
tb_cad_uni_unidade uni,
tb_cad_pes_pessoa pes,
--tb_ass_pee_pessoa_endereco pee,
tb_cad_end_endereco ende
WHERE
uni.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
AND pes.cad_pes_id_pessoa = ende.cad_pes_id_pessoa
AND ende.aux_mun_cd_ibge = paux_mun_cd_ibge;
--3548500;
    io_cursor := v_cursor;
  end PRC_CAD_REL_UNIDADE_POR_MUN;
