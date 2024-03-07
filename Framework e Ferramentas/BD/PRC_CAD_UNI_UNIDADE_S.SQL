create or replace procedure PRC_CAD_UNI_UNIDADE_S
  (
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pCAD_UNI_FL_STATUS in TB_CAD_UNI_UNIDADE.CAD_UNI_FL_STATUS%type DEFAULT NULL,
     pCAD_PES_NR_CNPJ_CPF IN TB_CAD_PES_PESSOA.CAD_PES_NR_CNPJ_CPF%type DEFAULT NULL,          
     pCAD_PES_NM_RAZAOSOCIAL IN TB_CAD_PES_PESSOA.CAD_PES_NM_RAZAOSOCIAL%type DEFAULT NULL,
     pCAD_PES_NM_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%type DEFAULT NULL,
     pCAD_UNI_FL_CRONICO_OK IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_CRONICO_OK%type DEFAULT NULL,
     pCAD_UNI_FL_PRIORIDADE_OK IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_PRIORIDADE_OK%type DEFAULT NULL,
     pCAD_UNI_FL_LIBERA_AGENDA_OK IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_LIBERA_AGENDA_OK%type DEFAULT NULL,
     pCAD_UNI_FL_GRAVA_ATEND_OK IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_GRAVA_ATEND_OK%type DEFAULT NULL,
     pCAD_UNI_FL_FATURA_UNID_OK IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_FATURA_UNID_OK%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_UNI_UNIDADE_S
  * 
  *    Data Criacao: 	03/03/2007             Por: Carlos Eduardo
  *    Funcao: Recupera as Unidades por filtros específicos
  *
  *    Data Alteracao:  30/05/2007             Por: Carlos Eduardo
  *    Alteração: Foram retirados alguns campos que foram migrados para a 
  *               a tabela de Pessoa e Endereços    
  *
  *    Data Alteração:  02/08/2007           Por: Guilherme Holdack
  *    Alteração: Foram incluídos alguns campos na tabela de Unidade
  *
  *    Data Alteração:  24/08/2007           Por: Andrea Cazuca
  *    Alteração: Incluído o parametro CAD_UNI_FL_PRIORIDADE_OK
  *
  *    Data Alteração:  01/10/2007           Por: Andrea Cazuca
  *    Alteração: Incluído o parâmetro CAD_UNI_FL_LIBERA_AGENDA_OK
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
  *
  *    Data Alteração:  21/10/2008  Por: Andréa Cazuca
  *    Alterção: Incluindo o parâmetro CAD_UNI_FL_GRAVA_ATEND_OK
  *
  *    Data Alteração:  04/03/2009  Por: Andréa Cazuca
  *    Alteração: Incluindo o campo CAD_UNI_FL_LIB_LOC_SETOR_OK
  *
  *    Data Alteração:  04/08/2010  Por: Rafael Coimbra
  *    Alteração: Incluindo o campo CAD_UNI_FL_FATURA_UNID_OK
  *******************************************************************/        
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       UNI.CAD_UNI_ID_UNIDADE,
       UNI.CAD_UNI_DS_IMAGEM_ASSOCIADA,
       UNI.CAD_UNI_ID_UNIDADE_MASTER,
       UNI.CAD_UNI_FL_STATUS,
       UNI.CAD_UNI_DT_ULTIMO_STATUS,
       UNI.CAD_UNI_FL_GRAVA_ATEND_OK,
       UNI.CAD_UNI_FL_LIBERA_AGENDA_OK,
       UNI.CAD_UNI_FL_GRAVA_CD_PAC_OK,
       UNI.CAD_PES_ID_PESSOA,
       UNI.CAD_UNI_FL_CRONICO_OK,
       UNI.CAD_UNI_FL_PRIORIDADE_OK,
       UNI.CAD_UNI_CD_UNID_HOSPITALAR,
       UNI.CAD_UNI_NR_CNES,
       UNI.CAD_UNI_FL_LIB_LOC_SETOR_OK,
       UNI.CAD_UNI_FL_FATURA_UNID_OK,
       PES.*
    FROM TB_CAD_UNI_UNIDADE UNI,
         TB_CAD_PES_PESSOA PES
    WHERE
        UNI.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
    AND (pCAD_UNI_ID_UNIDADE is null OR UNI.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
    AND (pCAD_UNI_FL_STATUS  is null OR UNI.CAD_UNI_FL_STATUS  = pCAD_UNI_FL_STATUS)        
    AND (pCAD_PES_NM_PESSOA is null OR PES.CAD_PES_NM_PESSOA LIKE UPPER(pCAD_PES_NM_PESSOA))
    AND (pCAD_PES_NM_RAZAOSOCIAL is null OR PES.CAD_PES_NM_RAZAOSOCIAL LIKE UPPER(pCAD_PES_NM_RAZAOSOCIAL))
    AND (pCAD_PES_NR_CNPJ_CPF is null OR PES.CAD_PES_NR_CNPJ_CPF = pCAD_PES_NR_CNPJ_CPF)    
    AND (pCAD_UNI_FL_CRONICO_OK is null OR UNI.CAD_UNI_FL_CRONICO_OK = pCAD_UNI_FL_CRONICO_OK)
    AND (pCAD_UNI_FL_PRIORIDADE_OK is null OR UNI.CAD_UNI_FL_PRIORIDADE_OK = pCAD_UNI_FL_PRIORIDADE_OK)
    AND (pCAD_UNI_FL_LIBERA_AGENDA_OK is null OR UNI.CAD_UNI_FL_LIBERA_AGENDA_OK = pCAD_UNI_FL_LIBERA_AGENDA_OK)
    AND (pCAD_UNI_FL_GRAVA_ATEND_OK is null OR UNI.CAD_UNI_FL_GRAVA_ATEND_OK = pCAD_UNI_FL_GRAVA_ATEND_OK)
    AND (pCAD_UNI_FL_FATURA_UNID_OK is null OR UNI.CAD_UNI_FL_FATURA_UNID_OK = pCAD_UNI_FL_FATURA_UNID_OK)
   ORDER BY PES.CAD_PES_NM_PESSOA;
    io_cursor := v_cursor;
  end PRC_CAD_UNI_UNIDADE_S;