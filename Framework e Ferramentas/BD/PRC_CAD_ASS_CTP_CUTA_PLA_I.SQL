create or replace procedure PRC_CAD_ASS_CTP_CUTA_PLA_I
  (
     pNewIdt OUT integer,     
     pASS_CUT_ID IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CUT_ID%type,
     pASS_CTP_DT_INI_VIGENCIA IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_DT_INI_VIGENCIA%type,
     pASS_CTP_DT_FIM_VIGENCIA IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_DT_FIM_VIGENCIA%type default NULL,
     pCAD_PLA_ID_PLANO IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.CAD_PLA_ID_PLANO%type,
     pASS_CTP_DT_ULTIMA_ATUALIZACAO IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.SEG_USU_ID_USUARIO%type,
     pASS_CTP_PC_HM_ACOMODACAO IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_PC_HM_ACOMODACAO%type,     
     pASS_CTP_PC_HM_ARTROSCOPIA IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_PC_HM_ARTROSCOPIA%type,
     pASS_CTP_PC_HM_LAPAROSCOPIA IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_PC_HM_LAPAROSCOPIA%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_ASS_CTP_CUTA_PLA_I
  * 
  *    Data Criacao: 	 08/09       Por: Caio
  *    Data Alteracao: 27/10/2010  Por: André Souza Monaco
  *         Alteracao: Adição de campos percentuais
  *
  *    Funcao: Insere tipo acomodação para o plano
  *
  *******************************************************************/  
	lIdtRetorno integer; 
  begin
  
    SELECT SEQ_ASS_CTP_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ASS_CTP_CNV_UN_TPACOM_PLA
    (
       ASS_CTP_ID,
       ASS_CUT_ID,
       ASS_CTP_DT_INI_VIGENCIA,
       ASS_CTP_DT_FIM_VIGENCIA,
       CAD_PLA_ID_PLANO,
       ASS_CTP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ASS_CTP_PC_HM_ACOMODACAO,
       ASS_CTP_PC_HM_ARTROSCOPIA,
       ASS_CTP_PC_HM_LAPAROSCOPIA
    )
    VALUES
    (
	     lIdtRetorno,
	     pASS_CUT_ID,
	     pASS_CTP_DT_INI_VIGENCIA,
	     pASS_CTP_DT_FIM_VIGENCIA,
	     pCAD_PLA_ID_PLANO,
	     pASS_CTP_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO,
       pASS_CTP_PC_HM_ACOMODACAO,
       pASS_CTP_PC_HM_ARTROSCOPIA,
       pASS_CTP_PC_HM_LAPAROSCOPIA
    );
	  
    pNewIdt := lIdtRetorno;
  end PRC_CAD_ASS_CTP_CUTA_PLA_I;

