create or replace procedure PRC_CAD_END_ENDERECO_I
  (
     pNewIdt OUT integer,
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
     pCAD_PES_ID_PESSOA IN TB_CAD_END_ENDERECO.CAD_PES_ID_PESSOA%type,
     pCAD_END_NM_ENDERECO_NF IN TB_CAD_END_ENDERECO.CAD_END_NM_ENDERECO_NF%type default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_END_ENDERECO_I
  *
  *    Data Criacao:   24/05/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao: 04/06/2007   Por: Cristiane Gomes da Silva
  *
  *    Alterac?o: 1)Inclus?o do UPPER nos parametros
  *               2)Tratamento de erro para gravac?o de tipo de endereco
  *               repetido para a mesma pessoa
  *               3)Alterac?o da mensagem de erro
  *               4)Alterac?o nome do atributo AUX_MUN_CD_IBGE
  *               5)Retirada do parametro pCAD_END_NM_CIDADE
  *
  *    Funcao: Inclui Endereco
  *
  *     Data Alteracao: 16/07/2008  Por: Fabmola
  *     Alteragco: Inclui o "default null" no campo do cd_cep (que nco i obrigatsrio)
  *
  *     Data Alteracao: 04/01/2011  Por: Rafael Coimbra
  *     Alteração: Incluido o atributo CAD_END_NM_ENDERECO_NF
  *
  *     Data Alteracao: 18/02/2011  Por: Davi Silvestre M. dos Reis
  *     Alteração: Incluido o "default null" no atributo CAD_END_NM_ENDERECO_NF
  *
  *******************************************************************/
    lIdtRetorno integer;
    v_contador  integer;
    ex_tipoenderecorepetido exception;
  begin
    v_contador := 0;

    SELECT COUNT(*)
    INTO   v_contador
    FROM   TB_CAD_END_ENDERECO END--,
           --TB_ASS_PEE_PESSOA_ENDERECO PEE
    WHERE  END.CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA
    AND    END.AUX_TTE_CD_TP_TEL_END = pAUX_TTE_CD_TP_TEL_END;

    IF v_contador > 0 THEN
       raise ex_tipoenderecorepetido;
    END IF;

    SELECT SEQ_CAD_END_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_CAD_END_ENDERECO
    (
       CAD_END_ID_ENDERECO,
       CAD_END_NM_LOGRADOURO,
       CAD_END_NM_BAIRRO,
       CAD_END_SG_UF,
       CAD_END_CD_CEP,
       CAD_END_DS_NUMERO,
       TIS_TLG_CD_TPLOGRADOURO,
       CAD_END_DT_ULTIMA_ATUALIZACAO,
       AUX_MUN_CD_IBGE,
       CAD_END_DS_COMPLEMENTO,
       SEG_USU_ID_USUARIO,
       AUX_TTE_CD_TP_TEL_END,
       CAD_PES_ID_PESSOA,
       CAD_END_NM_ENDERECO_NF
    )
    VALUES
    (
       lIdtRetorno,
       UPPER(pCAD_END_NM_LOGRADOURO),
       UPPER(pCAD_END_NM_BAIRRO),
       UPPER(pCAD_END_SG_UF),
       pCAD_END_CD_CEP,
       UPPER(pCAD_END_DS_NUMERO),
       pTIS_TLG_CD_TPLOGRADOURO,
       sysdate,
       pAUX_MUN_CD_IBGE,
       UPPER(pCAD_END_DS_COMPLEMENTO),
       pSEG_USU_ID_USUARIO,
       pAUX_TTE_CD_TP_TEL_END,
       pCAD_PES_ID_PESSOA,
       pCAD_END_NM_ENDERECO_NF
    );
    pNewIdt := lIdtRetorno;

    EXCEPTION
    --Se ja existir o tipo de endereco para a pessoa
    WHEN ex_tipoenderecorepetido THEN
       raise_application_error (-20000, 'O Tipo de Endereco escolhido ja existe, voce pode altera-lo ou escolher um outro Tipo de Endereco');

  end PRC_CAD_END_ENDERECO_I;
