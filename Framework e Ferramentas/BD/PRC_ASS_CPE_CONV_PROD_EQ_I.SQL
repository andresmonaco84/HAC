create or replace procedure PRC_ASS_CPE_CONV_PROD_EQ_I
  (
     pNewIdt OUT integer,
     pASS_CPE_ID IN TB_ASS_CPE_CONV_PROD_EQUIVALE.ASS_CPE_ID%type default NULL,
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CPE_CONV_PROD_EQUIVALE.CAD_CNV_ID_CONVENIO%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_CPE_CONV_PROD_EQUIVALE.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_PRD_ID_ORIGEM IN TB_ASS_CPE_CONV_PROD_EQUIVALE.CAD_PRD_ID_ORIGEM%type,
     pCAD_PRD_ID_DESTINO IN TB_ASS_CPE_CONV_PROD_EQUIVALE.CAD_PRD_ID_DESTINO%type,
     pCAD_CPE_DT_INICIO_VIGENCIA IN TB_ASS_CPE_CONV_PROD_EQUIVALE.CAD_CPE_DT_INICIO_VIGENCIA%type,
     pCAD_CPE_DT_FIM_VIGENCIA IN TB_ASS_CPE_CONV_PROD_EQUIVALE.CAD_CPE_DT_FIM_VIGENCIA%type default NULL,
     pCAD_CPE_DT_ULTIMA_ATUALIZACAO IN TB_ASS_CPE_CONV_PROD_EQUIVALE.CAD_CPE_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CPE_CONV_PROD_EQUIVALE.SEG_USU_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CPE_CONV_PROD_EQUIVALE_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_ASS_CPE_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ASS_CPE_CONV_PROD_EQUIVALE
    (
       ASS_CPE_ID,
       CAD_CNV_ID_CONVENIO,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_PRD_ID_ORIGEM,
       CAD_PRD_ID_DESTINO,
       CAD_CPE_DT_INICIO_VIGENCIA,
       CAD_CPE_DT_FIM_VIGENCIA,
       CAD_CPE_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
      lIdtRetorno,
	     pCAD_CNV_ID_CONVENIO,
	     pCAD_LAT_ID_LOCAL_ATENDIMENTO,
	     pCAD_PRD_ID_ORIGEM,
	     pCAD_PRD_ID_DESTINO,
	     pCAD_CPE_DT_INICIO_VIGENCIA,
	     pCAD_CPE_DT_FIM_VIGENCIA,
	     pCAD_CPE_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_ASS_CPE_CONV_PROD_EQ_I;