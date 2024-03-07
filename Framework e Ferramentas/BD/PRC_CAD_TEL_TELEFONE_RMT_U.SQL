  --PRC_CAD_TEL_TELEFONE_RMT_U
  create or replace procedure PRC_CAD_TEL_TELEFONE_RMT_U
  (
     pCAD_TEL_ID_TELEFONE IN TB_CAD_TEL_TELEFONE.CAD_TEL_ID_TELEFONE%type,
     pCAD_TEL_NR_NUM_TEL IN TB_CAD_TEL_TELEFONE.CAD_TEL_NR_NUM_TEL%type,
     pCAD_TEL_NR_RAMAL_TEL IN TB_CAD_TEL_TELEFONE.CAD_TEL_NR_RAMAL_TEL%type default NULL,
     pCAD_TEL_NM_CONTATO IN TB_CAD_TEL_TELEFONE.CAD_TEL_NM_CONTATO%type default NULL,
     pCAD_TEL_DT_ULTIMA_ATUALIZACAO IN TB_CAD_TEL_TELEFONE.CAD_TEL_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_TEL_TELEFONE.SEG_USU_ID_USUARIO%type,
     pAUX_TTE_CD_TP_TEL_END IN TB_CAD_TEL_TELEFONE.AUX_TTE_CD_TP_TEL_END%type,
     pCAD_PES_ID_PESSOA IN TB_CAD_TEL_TELEFONE.CAD_PES_ID_PESSOA%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TEL_TELEFONE_RMT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_TEL_TELEFONE
    SET	   
        CAD_TEL_NR_NUM_TEL = pCAD_TEL_NR_NUM_TEL,
        CAD_TEL_NR_RAMAL_TEL = pCAD_TEL_NR_RAMAL_TEL,
        CAD_TEL_NM_CONTATO = pCAD_TEL_NM_CONTATO,
        CAD_TEL_DT_ULTIMA_ATUALIZACAO = pCAD_TEL_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        AUX_TTE_CD_TP_TEL_END = pAUX_TTE_CD_TP_TEL_END,
        CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA 
    WHERE
        CAD_TEL_ID_TELEFONE = pCAD_TEL_ID_TELEFONE;	
  end PRC_CAD_TEL_TELEFONE_RMT_U;

