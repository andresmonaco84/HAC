CREATE OR REPLACE PROCEDURE "PRC_ASS_CDP_CNV_DC_LOC_PLANO_I" (
     pNewIdt OUT integer,
     pASS_CDL_ID IN TB_ASS_CDP_CNV_DC_LOC_PLANO.ASS_CDL_ID%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_CDP_CNV_DC_LOC_PLANO.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_CDP_CNV_DC_LOC_PLANO.SEG_USU_ID_USUARIO%type DEFAULT NULL	
  ) 
  is
  	lIdtRetorno integer;
  /********************************************************************
  *    Procedure: PRC_ASS_CDP_CNV_DC_LOC_PLANO_I
  * 
  *    Data Criacao: 	28/06/2007         Por: Fabiola Lopes
  *    Data Alteracao:	data da alteracao  Por: Nome do Analista
  *
  *    Funcao: Inclui as associacoes de ConvÃªnio x Plano x Local de Atendimento x Documentos
  *
  *******************************************************************/  
	  
  begin
	    
    SELECT SEQ_ASS_CDP.NextVal INTO lIdtRetorno FROM DUAL;
      
    INSERT INTO TB_ASS_CDP_CNV_DC_LOC_PLANO
    (
       ASS_CDP_ID,
       ASS_CDL_ID,
       CAD_PLA_ID_PLANO,
       ASS_CDP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
       lIdtRetorno,
	     pASS_CDL_ID,
	     pCAD_PLA_ID_PLANO,
	     SYSDATE,
	     pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;
  end PRC_ASS_CDP_CNV_DC_LOC_PLANO_I;
