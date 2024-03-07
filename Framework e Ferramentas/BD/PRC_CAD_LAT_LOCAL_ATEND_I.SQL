CREATE OR REPLACE PROCEDURE "PRC_CAD_LAT_LOCAL_ATEND_I" (
     pNewIdt OUT integer,
     pCAD_LAT_DS_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_DS_LOCAL_ATENDIMENTO%type,
     pCAD_LAT_FL_ATIVO_OK IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_FL_ATIVO_OK%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.SEG_USU_ID_USUARIO%type,
     pCAD_LAT_CD_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_CD_LOCAL_ATENDIMENTO%type,
     pCAD_LAT_FL_PERMITE_ATEND IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_FL_PERMITE_ATEND%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_LAT_LOCAL_ATENDIMENTO_I
  *
  *    Data Criacao: 	23/04/2007   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Inclui Local de Atendimento
  *
  *    Data Alteracao: 25/03/2010  Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusao do campo CAD_LAT_FL_PERMITE_ATEND (tarefa 8107)
  *
  *******************************************************************/
    lIdtRetorno integer;

  begin
    SELECT SEQ_CAD_LAT_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_CAD_LAT_LOCAL_ATENDIMENTO
    (
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_LAT_DS_LOCAL_ATENDIMENTO,
       CAD_LAT_FL_ATIVO_OK,
       CAD_LAT_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_LAT_CD_LOCAL_ATENDIMENTO,
       CAD_LAT_FL_PERMITE_ATEND
    )
    VALUES
    (
	     lIdtRetorno,
	     UPPER(pCAD_LAT_DS_LOCAL_ATENDIMENTO),
	     pCAD_LAT_FL_ATIVO_OK,
	     sysdate,
	     pSEG_USU_ID_USUARIO,
	     UPPER(pCAD_LAT_CD_LOCAL_ATENDIMENTO),
       pCAD_LAT_FL_PERMITE_ATEND
    );
    pNewIdt := lIdtRetorno;
  end PRC_CAD_LAT_LOCAL_ATEND_I;
/
