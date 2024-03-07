create or replace procedure PRC_CAD_UNI_UNIDADE_I
  (
     pNewIdt OUT integer,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type default NULL,
     pCAD_UNI_DS_IMAGEM_ASSOCIADA IN TB_CAD_UNI_UNIDADE.CAD_UNI_DS_IMAGEM_ASSOCIADA%type default NULL,
     pCAD_UNI_ID_UNIDADE_MASTER IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE_MASTER%type default NULL,
     pCAD_UNI_FL_STATUS IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_STATUS%type,
     pCAD_UNI_FL_GRAVA_ATEND_OK IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_GRAVA_ATEND_OK%type,
     pCAD_UNI_FL_LIBERA_AGENDA_OK IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_LIBERA_AGENDA_OK%type,
     pCAD_UNI_FL_GRAVA_CD_PAC_OK IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_GRAVA_CD_PAC_OK%type,
     pCAD_PES_ID_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%type,
     pCAD_UNI_FL_CRONICO_OK IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_CRONICO_OK%type,
     pCAD_UNI_FL_PRIORIDADE_OK IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_PRIORIDADE_OK%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_UNI_UNIDADE.SEG_USU_ID_USUARIO%type,
     pCAD_UNI_CD_UNID_HOSPITALAR IN TB_CAD_UNI_UNIDADE.CAD_UNI_CD_UNID_HOSPITALAR%type default null,
     pCAD_UNI_NR_CNES in TB_CAD_UNI_UNIDADE.CAD_UNI_NR_CNES%type default null,
     pCAD_UNI_FL_LIB_LOC_SETOR_OK IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_LIB_LOC_SETOR_OK%TYPE DEFAULT NULL,
     pCAD_UNI_DS_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_DS_UNIDADE%TYPE DEFAULT NULL, 
     pCAD_UNI_FL_FATURA_UNID_OK IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_FATURA_UNID_OK%type DEFAULT NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_UNI_UNIDADE_I
  * 
  *    Data Criacao:   03/03/2007             Por: Carlos Eduardo
  *    Funcao: Inclui uma Unidade e realiza a associação dela com 
  *            o usuário ADMIN
  * 
  *    Data Alteracao:  25/05/2007  Por: Silmara
  *    Alteracao: Foi alterado os parâmetros para gravar em maiúsculo  
  *
  *    Data Alteracao : 28/05/2007 Por:Silmara
  *    Alteracao: Foi alterado o parametro do e-mail para gravar em minusculo.
  *
  *    Data Alteracao:  30/05/2007             Por: Carlos Eduardo
  *    Alteração: Foram retirados alguns campos que foram migrados para a 
  *               a tabela de Pessoa e Endereços  
  *
  *    Data Alteracao:  02/08/2007             Por: Guilherme Holdack
  *    Alteração: Foram incluídos alguns campos na tabela de Unidade
  *
  *    Data Alteraçao: 19/11/2007            Por: Guilherme
  *    Alteração: Inclusão de upper em parametros
  *
  *    Data Alteração:  04/03/2009  Por: Andréa Cazuca
  *    Alteração: Incluindo o campo CAD_UNI_FL_LIB_LOC_SETOR_OK
  *
  *    Data Alteração:  06/10/2009  Por: Alexandre M. Muniz
  *    Alteração: Incluindo o campo CAD_UNI_DS_UNIDADE
  *
  *    Data Alteração:  05/08/2010  Por: Rafael Coimbra
  *    Alteração: Incluido o campo CAD_UNI_FL_FATURA_UNID_OK
  *******************************************************************/          
  lIdtRetorno integer;
  lIdtUsuarioAdmin integer;
  begin

    --Recupera a sequence
    SELECT SEQ_CAD_UNI_01.NextVal INTO lIdtRetorno FROM DUAL;

    --Recupera o Id do Admin do SGS    
    SELECT SEG_USU_ID_USUARIO INTO lIdtUsuarioAdmin
    FROM   TB_SEG_USU_USUARIO
    WHERE  SEG_USU_DS_LOGIN = 'ADMIN';
            
    INSERT INTO TB_CAD_UNI_UNIDADE
    (
       CAD_UNI_ID_UNIDADE,
       CAD_UNI_DS_IMAGEM_ASSOCIADA,
       CAD_UNI_ID_UNIDADE_MASTER,
       CAD_UNI_FL_STATUS,
       CAD_UNI_DT_ULTIMO_STATUS,
       CAD_UNI_FL_GRAVA_ATEND_OK,
       CAD_UNI_FL_LIBERA_AGENDA_OK,
       CAD_UNI_FL_GRAVA_CD_PAC_OK,
       CAD_PES_ID_PESSOA,
       CAD_UNI_FL_PRIORIDADE_OK,
       CAD_UNI_FL_CRONICO_OK,
       CAD_UNI_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_UNI_CD_UNID_HOSPITALAR,
       CAD_UNI_NR_CNES,
       CAD_UNI_CD_HOSPITALAR,
       CAD_UNI_FL_LIB_LOC_SETOR_OK,
       CAD_UNI_DS_UNIDADE,
       CAD_UNI_FL_FATURA_UNID_OK
    )
    VALUES
    (
       lIdtRetorno,
       upper(pCAD_UNI_DS_IMAGEM_ASSOCIADA),
       pCAD_UNI_ID_UNIDADE_MASTER,
       pCAD_UNI_FL_STATUS,
       sysdate(),
       pCAD_UNI_FL_GRAVA_ATEND_OK,
       pCAD_UNI_FL_LIBERA_AGENDA_OK,
       pCAD_UNI_FL_GRAVA_CD_PAC_OK,
       pCAD_PES_ID_PESSOA,
       pCAD_UNI_FL_PRIORIDADE_OK,
       pCAD_UNI_FL_CRONICO_OK,
       SYSDATE,
       pSEG_USU_ID_USUARIO,
       pCAD_UNI_CD_UNID_HOSPITALAR,
       pCAD_UNI_NR_CNES,
       1,
       pCAD_UNI_FL_LIB_LOC_SETOR_OK,
       pCAD_UNI_DS_UNIDADE,
       pCAD_UNI_FL_FATURA_UNID_OK
    );
    
    --Se Unidade Master = null, então a unidade master é Própria
    if (pCAD_UNI_ID_UNIDADE_MASTER is null) then    
        UPDATE TB_CAD_UNI_UNIDADE SET
               CAD_UNI_ID_UNIDADE_MASTER = lIdtRetorno
        WHERE  CAD_UNI_ID_UNIDADE = lIdtRetorno;
    end if;

    --Se unidade for crônica, mantém a regra de apenas uma crônica, 
    --e todas as outras: não crõnicas
    if (Upper(pCAD_UNI_FL_CRONICO_OK)='S') then
        UPDATE TB_CAD_UNI_UNIDADE SET
               CAD_UNI_FL_CRONICO_OK = 'N';
        UPDATE TB_CAD_UNI_UNIDADE SET
               CAD_UNI_FL_CRONICO_OK = 'S' 
        WHERE  CAD_UNI_ID_UNIDADE = pNewIdt;
    end if;
    --Grava a associação da unidade com o usuário admin    
    INSERT INTO TB_SEG_UUN_USUARIO_UNIDADE UUN
    ( SEG_USU_ID_USUARIO, CAD_UNI_ID_UNIDADE )
    VALUES
    ( lIdtUsuarioAdmin, lIdtRetorno);    
    
    pNewIdt := lIdtRetorno;  
  
  exception
     --SE não encontrou o usuário Admin
     WHEN NO_DATA_FOUND THEN
       raise_application_error (-20000, 'Usuário Admin não cadastrado');    
  end PRC_CAD_UNI_UNIDADE_I;

