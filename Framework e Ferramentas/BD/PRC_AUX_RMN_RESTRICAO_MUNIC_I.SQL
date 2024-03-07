create or replace procedure PRC_AUX_RMN_RESTRICAO_MUNIC_I
  (
     pAUX_RMN_SG_UF IN TB_AUX_RMN_RESTRICAO_MUNICIPIO.AUX_RMN_SG_UF%type,
     pAUX_RMN_NM_MUNICIPIO IN TB_AUX_RMN_RESTRICAO_MUNICIPIO.AUX_RMN_NM_MUNICIPIO%type,
     pSEG_USU_ID_USUARIO IN TB_AUX_RMN_RESTRICAO_MUNICIPIO.SEG_USU_ID_USUARIO%type,
     pAUX_RMN_CD_IBGE IN TB_AUX_RMN_RESTRICAO_MUNICIPIO.AUX_RMN_CD_IBGE%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUX_RMN_RESTRICAO_MUNIC_I
  *
  *    Data Criacao: 	31/07/2007         Por: Fabiola R. Lopes
  *    Data Alteracao:	data da alteraÃƒÂ§ÃƒÂ£o  Por: Nome do Analista
  *
  *    Funcao: Cadastrar os MunicÃƒÂ­pios restritos
  *
  *    Data Alteraçao: 19/11/2007            Por: Guilherme
  *    Alteração: Inclusão de upper em parametros
  *******************************************************************/

  begin

    INSERT INTO TB_AUX_RMN_RESTRICAO_MUNICIPIO
    (
       AUX_RMN_SG_UF,
       AUX_RMN_NM_MUNICIPIO,
       AUX_RMN_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       AUX_RMN_CD_IBGE
    )
    VALUES
    (
	     upper(pAUX_RMN_SG_UF),
	     Upper(pAUX_RMN_NM_MUNICIPIO),
	     SYSDATE,
	     pSEG_USU_ID_USUARIO,
	     pAUX_RMN_CD_IBGE
    );

  end PRC_AUX_RMN_RESTRICAO_MUNIC_I;
/
