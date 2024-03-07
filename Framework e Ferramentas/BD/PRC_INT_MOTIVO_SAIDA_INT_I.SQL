  --PRC_INT_MOTIVO_SAIDA_INT_I
  create or replace procedure PRC_INT_MOTIVO_SAIDA_INT_I
  (
     pTIS_MSI_CD_MOTIVOSAIDAINT IN TB_TIS_MSI_MOTIVO_SAIDA_INT.TIS_MSI_CD_MOTIVOSAIDAINT%type,
     pTIS_MSI_CD_TIPOALTA IN TB_TIS_MSI_MOTIVO_SAIDA_INT.TIS_MSI_CD_TIPOALTA%type,
     pTIS_MSI_DS_MOTIVOSAIDAINT IN TB_TIS_MSI_MOTIVO_SAIDA_INT.TIS_MSI_DS_MOTIVOSAIDAINT%type	,
     pTIS_MSI_FL_STATUS IN TB_TIS_MSI_MOTIVO_SAIDA_INT.TIS_MSI_FL_STATUS%type DEFAULT NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_MOTIVO_SAIDA_INT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_TIS_MSI_MOTIVO_SAIDA_INT
    (
       TIS_MSI_CD_MOTIVOSAIDAINT,
       TIS_MSI_CD_TIPOALTA,
       TIS_MSI_DS_MOTIVOSAIDAINT,
       TIS_MSI_FL_STATUS
    )
    VALUES
    (
	     pTIS_MSI_CD_MOTIVOSAIDAINT,
	     pTIS_MSI_CD_TIPOALTA,
	     pTIS_MSI_DS_MOTIVOSAIDAINT,
	     pTIS_MSI_FL_STATUS
    );
	
  end PRC_INT_MOTIVO_SAIDA_INT_I;

