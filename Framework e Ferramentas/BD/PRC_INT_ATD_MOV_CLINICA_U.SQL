  --PRC_INT_ATD_MOV_CLINICA_U
  create or replace procedure PRC_INT_ATD_MOV_CLINICA_U
  (
     pATD_ATE_ID IN TB_ATD_IMC_INT_MOV_CLINICA.ATD_ATE_ID%type,
     pATD_IMC_DT_ENTRADA IN TB_ATD_IMC_INT_MOV_CLINICA.ATD_IMC_DT_ENTRADA%type,
     pATD_IMC_HR_ENTRADA IN TB_ATD_IMC_INT_MOV_CLINICA.ATD_IMC_HR_ENTRADA%type,
     pATD_IMC_DT_SAIDA IN TB_ATD_IMC_INT_MOV_CLINICA.ATD_IMC_DT_SAIDA%type default NULL,
     pCAD_CLC_ID IN TB_ATD_IMC_INT_MOV_CLINICA.CAD_CLC_ID%type,
     pATD_IMC_DT_ULTIMA_ATUALIZACAO IN TB_ATD_IMC_INT_MOV_CLINICA.ATD_IMC_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ATD_IMC_INT_MOV_CLINICA.SEG_USU_ID_USUARIO%type,
     pATD_IMC_DS_OBSERVACAO IN TB_ATD_IMC_INT_MOV_CLINICA.ATD_IMC_DS_OBSERVACAO%type default NULL,
     pATD_IMC_HR_SAIDA IN TB_ATD_IMC_INT_MOV_CLINICA.ATD_IMC_HR_SAIDA%type default NULL,
     pATD_IMC_ID IN TB_ATD_IMC_INT_MOV_CLINICA.ATD_IMC_ID%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_MOV_CLINICA_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_ATD_IMC_INT_MOV_CLINICA
    SET	   
        ATD_ATE_ID = pATD_ATE_ID,
        ATD_IMC_DT_ENTRADA = pATD_IMC_DT_ENTRADA,
        ATD_IMC_HR_ENTRADA = pATD_IMC_HR_ENTRADA,
        ATD_IMC_DT_SAIDA = pATD_IMC_DT_SAIDA,
        CAD_CLC_ID = pCAD_CLC_ID,
        ATD_IMC_DT_ULTIMA_ATUALIZACAO = pATD_IMC_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ATD_IMC_DS_OBSERVACAO = pATD_IMC_DS_OBSERVACAO,
        ATD_IMC_HR_SAIDA = pATD_IMC_HR_SAIDA 
    WHERE
        ATD_IMC_ID = pATD_IMC_ID;	
  end PRC_INT_ATD_MOV_CLINICA_U;

