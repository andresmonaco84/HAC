  create or replace procedure PRC_ASS_PLC_PLANO_CBOS_I
  (
     pCAD_PLA_ID_PLANO			IN TB_ASS_PLC_PLANO_CBOS.CAD_PLA_ID_PLANO%type,
     pTIS_CBO_CD_CBOS			IN TB_ASS_PLC_PLANO_CBOS.TIS_CBO_CD_CBOS%type,
     pASS_PLC_FL_STATUS			IN TB_ASS_PLC_PLANO_CBOS.ASS_PLC_FL_STATUS%type,
     pSEG_USU_ID_USUARIO		IN TB_ASS_PLC_PLANO_CBOS.SEG_USU_ID_USUARIO%type,
     pASS_PLC_FL_ENCAMINHA_OK	IN TB_ASS_PLC_PLANO_CBOS.ASS_PLC_FL_ENCAMINHA_OK%TYPE DEFAULT NULL, 
     pASS_PLC_FL_EXIGE_SENHA_OK  IN TB_ASS_PLC_PLANO_CBOS.ASS_PLC_FL_EXIGE_SENHA_OK%TYPE
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PLC_PLANO_CBOS_I
  * 
  *    Data Criacao: 	16/08/2007   Por: Andréa Cazuca
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: Inclusao de Associacao Plano X Especialidade
  *
  *    
  *    Data Alteração:	22/10/07	Por: Fabíola R. Lopes
  *	   Ateração:		Inclusão de um parâmetro
  *    Data Alteração:	09/11/07	Por: Bruno Costa
  *	   Ateração:		Inclusão de um campo
  *	
  *  
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_ASS_PLC_PLANO_CBOS
    (
       CAD_PLA_ID_PLANO,
       TIS_CBO_CD_CBOS,
       ASS_PLC_FL_STATUS,
       SEG_USU_ID_USUARIO,
       ASS_PLC_DT_ULTIMA_ATUALIZACAO,
       ASS_PLC_FL_ENCAMINHA_OK,
       ASS_PLC_FL_EXIGE_SENHA_OK
    )
    VALUES
    (
	     pCAD_PLA_ID_PLANO,
	     pTIS_CBO_CD_CBOS,
	     pASS_PLC_FL_STATUS,
	     pSEG_USU_ID_USUARIO,
	     SYSDATE,
	     pASS_PLC_FL_ENCAMINHA_OK,
	     pASS_PLC_FL_EXIGE_SENHA_OK
    );
	
  end PRC_ASS_PLC_PLANO_CBOS_I;