create or replace procedure PRC_AGE_SAU_SALA_UNID_AND_U
  (
     pAGE_SAU_ID IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_ID%type,
     pAGE_SAU_CD_ANDAR IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_CD_ANDAR%type,
     pAGE_SAU_NR_SALA IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_NR_SALA%type default NULL,
     pCAD_UNI_ID_UNIDADE IN TB_AGE_SAU_SALA_UNID_AND.CAD_UNI_ID_UNIDADE%type,
     pAGE_SAU_FL_STATUS IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_FL_STATUS%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_AGE_SAU_SALA_UNID_AND.SEG_USU_ID_USUARIO%type default null,
      pAGE_SAU_DS_SALA IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_DS_SALA%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGE_SAU_SALA_UNID_AND_U
  * 
  *    Data Criacao: 	13/08/2007           Por: Guilherme Holdack
  *    Data Alteracao:	24/04/2008           Por: Silmara
  *    Inclusão campo 
  *    Funcao: Atualiza cadastro de Salas X Andar X Unidade
  *
  *******************************************************************/  
  begin
    UPDATE TB_AGE_SAU_SALA_UNID_AND
    SET	   
        AGE_SAU_CD_ANDAR = pAGE_SAU_CD_ANDAR,
        AGE_SAU_NR_SALA = pAGE_SAU_NR_SALA,
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE,
        AGE_SAU_FL_STATUS = pAGE_SAU_FL_STATUS, 
        AGE_SAU_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        AGE_SAU_DS_SALA = pAGE_SAU_DS_SALA
    WHERE
        AGE_SAU_ID = pAGE_SAU_ID;	
  end PRC_AGE_SAU_SALA_UNID_AND_U;
/
