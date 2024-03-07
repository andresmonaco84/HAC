  --PRC_CAD_FER_FERIADO_U
  create or replace procedure PRC_CAD_FER_FERIADO_U
  (
     pCAD_FER_ID_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_ID_FERIADO%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_FER_FERIADO.CAD_UNI_ID_UNIDADE%type default NULL,
     pCAD_FER_DT_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_DT_FERIADO%type,
     pCAD_FER_TP_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_TP_FERIADO%type default NULL,
     pCAD_FER_DS_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_DS_FERIADO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_FER_FERIADO.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_FER_FERIADO_U
  * 
  *    Data Criacao: 	26/06/2007   Por: Guilherme Holdack
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: Alterção de registro na tabela TB_CAD_FER_FERIADO
  *
  *    Data Alteracao:	18/07/2007   Por: Fabiola Lopes
  *    Alteração:       Inclusao do UPPER na descricao do feriado
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_FER_FERIADO
    SET	   
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE,
        CAD_FER_DT_FERIADO = pCAD_FER_DT_FERIADO,
        CAD_FER_TP_FERIADO = pCAD_FER_TP_FERIADO,
        CAD_FER_DS_FERIADO = UPPER(pCAD_FER_DS_FERIADO),
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        CAD_FER_DT_ULTIMA_ATUALIZACAO = SYSDATE
    WHERE
        CAD_FER_ID_FERIADO = pCAD_FER_ID_FERIADO;	
  end PRC_CAD_FER_FERIADO_U;
/
