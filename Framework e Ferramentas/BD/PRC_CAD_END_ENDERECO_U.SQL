create or replace procedure PRC_CAD_END_ENDERECO_U
  (
     pCAD_END_ID_ENDERECO IN TB_CAD_END_ENDERECO.CAD_END_ID_ENDERECO%type,
     pCAD_END_NM_LOGRADOURO IN TB_CAD_END_ENDERECO.CAD_END_NM_LOGRADOURO%type,
     pCAD_END_NM_BAIRRO IN TB_CAD_END_ENDERECO.CAD_END_NM_BAIRRO%type,
     pCAD_END_SG_UF IN TB_CAD_END_ENDERECO.CAD_END_SG_UF%type,
     pCAD_END_CD_CEP IN TB_CAD_END_ENDERECO.CAD_END_CD_CEP%type default null,
     pCAD_END_DS_NUMERO IN TB_CAD_END_ENDERECO.CAD_END_DS_NUMERO%type,
     pTIS_TLG_CD_TPLOGRADOURO IN TB_CAD_END_ENDERECO.TIS_TLG_CD_TPLOGRADOURO%type,
     pAUX_MUN_CD_IBGE IN TB_CAD_END_ENDERECO.AUX_MUN_CD_IBGE%type,
     pCAD_END_DS_COMPLEMENTO IN TB_CAD_END_ENDERECO.CAD_END_DS_COMPLEMENTO%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_END_ENDERECO.SEG_USU_ID_USUARIO%type,
     pAUX_TTE_CD_TP_TEL_END IN TB_AUX_TTE_TP_TEL_ENDERECO.AUX_TTE_CD_TP_TEL_END% type,
     pCAD_PES_ID_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%TYPE,
     pCAD_END_NM_ENDERECO_NF IN TB_CAD_END_ENDERECO.CAD_END_NM_ENDERECO_NF%TYPE default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_END_ENDERECO_U
  *
  *    Data Alteracao: 04/06/2007   Por: Cristiane Gomes da Silva
  *    Alteração:   inclusao do CAD_PES_ID_PESSOA
  *
  *    Funcao: Altera Endereco
  *
  *     Data Alteracao: 16/07/2008  Por: Fabíola
  *     Alteração: Inclui o "default null" no campo do cd_cep (que não é obrigatório)
  *
  *     Data Alteracao: 04/01/2011  Por: Rafael Coimbra
  *     Alteração: Incluido o atributo CAD_END_NM_ENDERECO_NF
  *
  *     Data Alteracao: 18/02/2011  Por: Davi Silvestre M. dos Reis
  *     Alteração: Incluido o "default null" no atributo CAD_END_NM_ENDERECO_NF
  *
  *******************************************************************/
  begin
    UPDATE TB_CAD_END_ENDERECO
    SET
        CAD_END_NM_LOGRADOURO = UPPER(pCAD_END_NM_LOGRADOURO),
        CAD_END_NM_BAIRRO = UPPER(pCAD_END_NM_BAIRRO),
        CAD_END_SG_UF = UPPER(pCAD_END_SG_UF),
        CAD_END_CD_CEP = pCAD_END_CD_CEP,
        CAD_END_DS_NUMERO = UPPER(pCAD_END_DS_NUMERO),
        TIS_TLG_CD_TPLOGRADOURO = pTIS_TLG_CD_TPLOGRADOURO,
        CAD_END_DT_ULTIMA_ATUALIZACAO = sysdate,
        AUX_MUN_CD_IBGE = pAUX_MUN_CD_IBGE,
        CAD_END_DS_COMPLEMENTO = UPPER(pCAD_END_DS_COMPLEMENTO),
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA,
        CAD_END_NM_ENDERECO_NF = pCAD_END_NM_ENDERECO_NF
    WHERE
        CAD_END_ID_ENDERECO = pCAD_END_ID_ENDERECO;
  end PRC_CAD_END_ENDERECO_U;
