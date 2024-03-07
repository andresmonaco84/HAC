create or replace procedure sgs.PRC_CAD_PES_PESSOA_I
  (
     pNewIdt OUT integer,
     pCAD_PES_ID_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%type default NULL,
     pCAD_PES_NR_CNPJ_CPF IN TB_CAD_PES_PESSOA.CAD_PES_NR_CNPJ_CPF%type default NULL,
     pCAD_PES_FL_JURIDICA_OK IN TB_CAD_PES_PESSOA.CAD_PES_FL_JURIDICA_OK%type,
     pCAD_PES_NM_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%type,
     pCAD_PES_NM_RAZAOSOCIAL IN TB_CAD_PES_PESSOA.CAD_PES_NM_RAZAOSOCIAL%type DEFAULT NULL,
     pCAD_PES_DT_NASCIMENTO IN TB_CAD_PES_PESSOA.CAD_PES_DT_NASCIMENTO%type default NULL,
     pCAD_PES_NR_RG IN TB_CAD_PES_PESSOA.CAD_PES_NR_RG%type default NULL,
     pCAD_PES_CD_INSCR_MUNIC IN TB_CAD_PES_PESSOA.CAD_PES_CD_INSCR_MUNIC%type default NULL,
     pCAD_PES_CD_INSCR_ESTAD IN TB_CAD_PES_PESSOA.CAD_PES_CD_INSCR_ESTAD%type default NULL,
     pCAD_PES_TP_SEXO IN TB_CAD_PES_PESSOA.CAD_PES_TP_SEXO%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_PES_PESSOA.SEG_USU_ID_USUARIO%type,
     pCAD_PES_CD_ESTADOCIVIL IN TB_CAD_PES_PESSOA.CAD_PES_CD_ESTADOCIVIL%type default NULL,
     pCAD_PES_NM_NOMEMAE IN TB_CAD_PES_PESSOA.CAD_PES_NM_NOMEMAE%type default NULL,
     pCAD_PES_CD_ORGAOEMISSORRG IN TB_CAD_PES_PESSOA.CAD_PES_CD_ORGAOEMISSORRG%TYPE DEFAULT NULL,
     pCAD_PES_DT_EXPEDICAORG IN TB_CAD_PES_PESSOA.CAD_PES_DT_EXPEDICAORG%TYPE DEFAULT NULL,
     pCAD_PES_FL_ATIVO_OK IN TB_CAD_PES_PESSOA.CAD_PES_FL_ATIVO_OK%TYPE  DEFAULT 'S'
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PES_PESSOA_I
  *
  *    Data Criacao: 	 30/05/2007            Por: Carlos Eduardo
  *    Data Alteracao:	 25/06/2007              Por: Nome do Analista
  *    Alteragco: Inclusco de campo Sexo
  *
  *    Data Alteragco:   02/08/2007				Por: Fabiola R. Lopes
  *	   Alteracao:        Inclusao dos campos: estado civil e nome da mae
  *
  *    Data Alteragco:	 24/11/2007				Por: Fabmola Lopes
  *	   Alteragco:	     Inclusco do trim nos campos: pCAD_PES_NM_PESSOA, pCAD_PES_NM_RAZAOSOCIAL, pCAD_PES_NR_RG,
  *                                                   pCAD_PES_CD_INSCR_MUNIC, pCAD_PES_CD_INSCR_ESTAD, pCAD_PES_NM_NOMEMAE
  *
  *    Data Alteracao:   04/01/2008       Por: Fabiola Lopes
  *    Alteracao:        Inclusao de dois campos: CAD_PES_CD_ORGAOEMISSORRG e CAD_PES_DT_EXPEDICAORG
  *
  *    Data Alteracao:   13/04/2010       Por: Fabiola Lopes
  *    Alteracao:        Validacao para garantir que os dados do estado civil estao consistentes conforme nossa base
  *
  *    Data Alteracao:  12/11/2010  Por: Fabiola Lopes
  *    Alteracao: Coloquei um trunc na data de nascimento para evitar de gravar a hora
  *
  *    Funcao: Inclui uma pessoa Fmsica ou Jurmdica
  *
  *******************************************************************/
	lIdtRetorno integer;
  estadoCivil CHAR(1);
  begin
	  IF pCAD_PES_CD_ESTADOCIVIL not in ('1','2','3','4','5','6') THEN
        CASE
         WHEN pCAD_PES_CD_ESTADOCIVIL = 'S' THEN
          estadoCivil := '1';
         WHEN pCAD_PES_CD_ESTADOCIVIL = 'C' THEN
          estadoCivil := '2';
         WHEN pCAD_PES_CD_ESTADOCIVIL = 'D' THEN
          estadoCivil := '4';
         WHEN pCAD_PES_CD_ESTADOCIVIL = 'V' THEN
          estadoCivil := '5';
         WHEN pCAD_PES_CD_ESTADOCIVIL = 'U' THEN
          estadoCivil := '6';
         ELSE estadoCivil := NULL;
        END CASE;
		ELSE  estadoCivil := pCAD_PES_CD_ESTADOCIVIL;
	  END IF;
    --Recupera a sequence
    SELECT SEQ_CAD_PES_01.NextVal INTO lIdtRetorno FROM DUAL;
    INSERT INTO TB_CAD_PES_PESSOA
    (
       CAD_PES_ID_PESSOA,
       CAD_PES_NR_CNPJ_CPF,
       CAD_PES_FL_JURIDICA_OK,
       CAD_PES_NM_PESSOA,
       CAD_PES_NM_RAZAOSOCIAL,
       CAD_PES_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PES_DT_NASCIMENTO,
       CAD_PES_NR_RG,
       CAD_PES_CD_INSCR_MUNIC,
       CAD_PES_CD_INSCR_ESTAD,
	   CAD_PES_TP_SEXO,
 	   CAD_PES_CD_ESTADOCIVIL,
   	   CAD_PES_NM_NOMEMAE,
       CAD_PES_CD_ORGAOEMISSORRG,
       CAD_PES_DT_EXPEDICAORG,
	   CAD_PES_NOME_SOUNDEX
    )
    VALUES
    (
       lIdtRetorno,
       pCAD_PES_NR_CNPJ_CPF,
       pCAD_PES_FL_JURIDICA_OK,
       trim(upper(pCAD_PES_NM_PESSOA)),
       trim(upper(pCAD_PES_NM_RAZAOSOCIAL)),
       sysdate(),
       pSEG_USU_ID_USUARIO,
       TRUNC(pCAD_PES_DT_NASCIMENTO),
       trim(pCAD_PES_NR_RG),
       trim(pCAD_PES_CD_INSCR_MUNIC),
       trim(pCAD_PES_CD_INSCR_ESTAD),
       pCAD_PES_TP_SEXO,
       estadoCivil,
       trim(UPPER(pCAD_PES_NM_NOMEMAE)),
       trim(upper(pCAD_PES_CD_ORGAOEMISSORRG)),
       pCAD_PES_DT_EXPEDICAORG,
	   FNC_PES_SOUNDEX_NOME(pCAD_PES_NM_PESSOA,' ')
    );
    pNewIdt := lIdtRetorno;
  end PRC_CAD_PES_PESSOA_I;
