create or replace procedure PRC_CAD_UNI_UNIDADE_U
  (
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
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
     pCAD_UNI_NR_CNES IN tb_cad_uni_unidade.cad_uni_nr_cnes%type default null,
     pCAD_UNI_FL_LIB_LOC_SETOR_OK IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_LIB_LOC_SETOR_OK%TYPE DEFAULT NULL,
     pCAD_UNI_DS_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_DS_UNIDADE%TYPE DEFAULT NULL,
     pCAD_UNI_FL_FATURA_UNID_OK IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_FATURA_UNID_OK%TYPE DEFAULT NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_UNI_UNIDADE_U
  * 
  *    Data Criacao:     03/03/2007             Por: Carlos Eduardo
  *    Funcao: Altera os dados de uma determinada Unidade
  * 
  *    Data Alteracao:  28/05/2007             Por: Silmara
  *    Alteração: Foi alterado os parâmetros para gravar em maiúsculo e o e-mail em minúsculo
  *
  *    Data Alteracao:  30/05/2007             Por: Carlos Eduardo
  *    Alteração: Foram retirados alguns campos que foram migrados para a 
  *               a tabela de Pessoa e Endereços
  *
  *    Data Alteracao: 02/08/2007              Por: Guilherme Holdack
  *    Alteração: Foram incluídos alguns campos na tabela de Unidade
  *
  *    Data Alteração: 24/08/207               Por: Andrea Cazuca
  *    Alteração: Incluído regra para quando Unidade é Prioridade
  *               as outras não serem
  *
  *    Data Alteração: 19/11/2007          Por: Guilherme Holdack
  *    Alteração: Inclusão de upper em campos
  *
  *    Data Alteração:  04/03/2009  Por: Andréa Cazuca
  *    Alteração: Incluindo o campo CAD_UNI_FL_LIB_LOC_SETOR_OK
  *
  *    Data Alteração:  06/10/2009  Por: Alexandre M. Muniz
  *    Alteração: Incluindo o campo CAD_UNI_DS_UNIDADE
  *
  *    Data Alteração:  05/08/2010  Por: Rafael Coimbra
  *    Alteração: Incluindo o campo CAD_UNI_FL_FATURA_UNID_OK
  *******************************************************************/                  
  begin
    UPDATE TB_CAD_UNI_UNIDADE
    SET     
        CAD_UNI_DS_IMAGEM_ASSOCIADA = Upper(pCAD_UNI_DS_IMAGEM_ASSOCIADA),
        CAD_UNI_ID_UNIDADE_MASTER = pCAD_UNI_ID_UNIDADE_MASTER,
        CAD_UNI_FL_STATUS = pCAD_UNI_FL_STATUS,
        CAD_UNI_DT_ULTIMO_STATUS = sysdate(),
        CAD_UNI_FL_GRAVA_ATEND_OK = pCAD_UNI_FL_GRAVA_ATEND_OK,
        CAD_UNI_FL_LIBERA_AGENDA_OK = pCAD_UNI_FL_LIBERA_AGENDA_OK,
        CAD_UNI_FL_GRAVA_CD_PAC_OK = pCAD_UNI_FL_GRAVA_CD_PAC_OK,
        CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA,
        CAD_UNI_FL_CRONICO_OK = pCAD_UNI_FL_CRONICO_OK,
        CAD_UNI_FL_PRIORIDADE_OK = pCAD_UNI_FL_PRIORIDADE_OK,
        CAD_UNI_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        CAD_UNI_CD_UNID_HOSPITALAR = pCAD_UNI_CD_UNID_HOSPITALAR,
        CAD_UNI_NR_CNES = pCAD_UNI_NR_CNES,
        CAD_UNI_FL_LIB_LOC_SETOR_OK = pCAD_UNI_FL_LIB_LOC_SETOR_OK,
        CAD_UNI_DS_UNIDADE = pCAD_UNI_DS_UNIDADE,
        CAD_UNI_FL_FATURA_UNID_OK = pCAD_UNI_FL_FATURA_UNID_OK
    WHERE
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;  
        
    --Se unidade for crônica, mantém a regra de apenas uma crônica, 
    --e todas as outras: não crõnicas
    if (Upper(pCAD_UNI_FL_CRONICO_OK)='S') then
        UPDATE TB_CAD_UNI_UNIDADE SET
               CAD_UNI_FL_CRONICO_OK = 'N';
        UPDATE TB_CAD_UNI_UNIDADE SET
               CAD_UNI_FL_CRONICO_OK = 'S' 
        WHERE  CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;
    end if;
    
    --Se unidade for prioridade, mantém a regra de apenas uma prioridade, 
    --e todas as outras: não prioridade
    if (Upper(pCAD_UNI_FL_PRIORIDADE_OK)='S') then
        UPDATE TB_CAD_UNI_UNIDADE SET
               CAD_UNI_FL_PRIORIDADE_OK = 'N';
        UPDATE TB_CAD_UNI_UNIDADE SET
               CAD_UNI_FL_PRIORIDADE_OK = 'S' 
        WHERE  CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;
    end if;
  end PRC_CAD_UNI_UNIDADE_U;
